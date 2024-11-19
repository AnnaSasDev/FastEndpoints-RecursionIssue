// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpoints_RecursionIssue.Endpoints;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CreateFirstModelEndpoint : Endpoint<
    CreateFirstModelRequest,
    Results<
        Ok<Guid>,
        BadRequest
    >,
    FirstModelMapper
> {
    public override void Configure() {
        Post("/{UserId:guid}/first-models/{FirstModelId:guid}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(CreateFirstModelRequest req, CancellationToken ct) {
        await SendAsync(TypedResults.Ok(Guid.NewGuid()), cancellation: ct);
    }
}