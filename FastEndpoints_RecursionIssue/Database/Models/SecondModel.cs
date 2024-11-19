// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models.BaseModels;

namespace FastEndpoints_RecursionIssue.Database.Models;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class SecondModel : UserContent<SecondModel> {
    public required FirstModel FirstModel { get; set; }
    public Guid FirstModelId { get; set; }
    
    public ICollection<ThirdModel> ThirdModels { get; init; } = [];
}
