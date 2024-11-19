// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace FastEndpoints_RecursionIssue;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class Program {
    public async static Task Main(string[] args) {
        // -------------------------------------------------------------------------------------------------------------
        // Builder
        // -------------------------------------------------------------------------------------------------------------
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        MsSqlContainer? container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04")
            .WithPassword("FastEndpointsIsGre4t!")
            .WithName("FastEndpointsRecursion-db")
            .Build();

        if (container is null) throw new Exception("Could not create MsSqlContainer");
        await container.StartAsync();

        builder.Services.AddDbContextFactory<RecursionDbContext>(options =>
            options.UseSqlServer(container.GetConnectionString())
        );

        builder.Services.AddIdentityCore<RecursionUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RecursionDbContext>()
            .AddSignInManager();
        
        builder.Services.AddAuthentication(o => {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });
        
        builder.Services.AddAuthorization();
        
        builder.Services
            .AddFastEndpoints(options => {
                options.Assemblies = [
                    typeof(IAssemblyEntry).Assembly
                ];
            })
            .SwaggerDocument();

        builder.Services.AddIdentityApiEndpoints<RecursionUser>();
        
        // -------------------------------------------------------------------------------------------------------------
        // App
        // -------------------------------------------------------------------------------------------------------------
        WebApplication app = builder.Build();
        
        if (app.Environment.IsDevelopment()) {
            // app.UseWebAssemblyDebugging();
        }
        else {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseFastEndpoints(ctx => {
            ctx.Endpoints.RoutePrefix = "api";
            ctx.Binding.ReflectionCache
                .AddFromFastEndpointsRecursionIssue();
            ctx.Errors.UseProblemDetails();
        });
        app.UseSwaggerGen();
        
        await using AsyncServiceScope scope = app.Services.CreateAsyncScope();// CreateAsyncScope
        await Task.WhenAll(
            MigrateDatabaseAsync(app), // Db Migrations on startup
            app.RunAsync()
        );
    }

    private async static Task MigrateDatabaseAsync(WebApplication app) {
        await using RecursionDbContext db = await app.Services.GetRequiredService<IDbContextFactory<RecursionDbContext>>().CreateDbContextAsync();
        await db.Database.MigrateAsync();
        await db.SaveChangesAsync();
    }
}
