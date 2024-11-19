// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace FastEndpoints_RecursionIssue.Database.Models.BaseModels;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class UserContentAccess<T> : BaseContent<T> where T : BaseContent<T> {
    public required RecursionUser User { get; set; }
    public required AccessLevel AccessLevel { get; set; }
}

public enum AccessLevel {
    Read,
    Write,
    Manage,
    Owner
}
