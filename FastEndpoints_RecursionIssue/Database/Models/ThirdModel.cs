// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models.BaseModels;

namespace FastEndpoints_RecursionIssue.Database.Models;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ThirdModel : UserContent<ThirdModel> {
    public required SecondModel SecondModel { get; set; }
    public Guid SecondModelId { get; set; }
}
