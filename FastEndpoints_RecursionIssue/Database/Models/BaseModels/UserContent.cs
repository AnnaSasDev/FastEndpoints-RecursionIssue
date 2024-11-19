// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace FastEndpoints_RecursionIssue.Database.Models.BaseModels;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public abstract class UserContent<T> : BaseContent<T> where T : BaseContent<T> {

    public bool IsPublic { get; set; }
    public ICollection<UserContentAccess<T>> UserAccess { get; set; } = [];
    public required virtual RecursionUser Owner { get; set; }
    public string OwnerId { get; set; } = null!;
}
