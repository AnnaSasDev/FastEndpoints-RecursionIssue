// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoints_RecursionIssue.Database;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RecursionDbContext : IdentityDbContext<RecursionUser, IdentityRole, string> {
    public DbSet<FirstModel> FirstModels { get; init; }
    public DbSet<SecondModel> SecondModels { get; init; }
    public DbSet<ThirdModel> ThirdModels { get; init; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        #region RecursionUser Config
        builder.Entity<RecursionUser>().HasMany(user => user.FirstModels)
            .WithOne(firstModel => firstModel.Owner)
            .HasForeignKey(x => x.OwnerId);

        builder.Entity<RecursionUser>().HasMany(user => user.SecondModels)
            .WithOne(secondModel => secondModel.Owner)
            .HasForeignKey(x => x.OwnerId);

        builder.Entity<RecursionUser>().HasMany(user => user.ThirdModels)
            .WithOne(thirdModel => thirdModel.Owner)
            .HasForeignKey(x => x.OwnerId);
        #endregion

        #region FirstModel Config
        builder.Entity<FirstModel>().HasKey(x => x.Id);
        builder.Entity<FirstModel>().HasIndex(x => x.Id).IsUnique();
        builder.Entity<FirstModel>().HasMany(model => model.SecondModels)
            .WithOne(secondModel => secondModel.FirstModel)
            .HasForeignKey(x => x.FirstModelId)
            .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region SecondModel Config
        builder.Entity<SecondModel>().HasKey(x => x.Id);
        builder.Entity<SecondModel>().HasIndex(x => x.Id).IsUnique();
        builder.Entity<SecondModel>().HasMany(model => model.ThirdModels)
            .WithOne(secondModel => secondModel.SecondModel)
            .HasForeignKey(x => x.SecondModelId)
            .OnDelete(DeleteBehavior.NoAction);
        #endregion
        
    }
}
