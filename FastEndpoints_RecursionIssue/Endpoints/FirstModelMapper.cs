// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models;
using FastEndpoints;

namespace FastEndpoints_RecursionIssue.Endpoints;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class FirstModelMapper : ResponseMapper<FirstModelResponse, FirstModel> {
    public override FirstModelResponse FromEntity(FirstModel ls) => new(
        ls.Id,
        ls.OwnerId,
        ls.SecondModels.Select(m => m.Id).ToArray()
    );
}
