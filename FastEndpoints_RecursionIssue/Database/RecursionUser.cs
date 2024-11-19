// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace FastEndpoints_RecursionIssue.Database;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RecursionUser : IdentityUser {
    public ICollection<FirstModel> FirstModels { get; init; } = [];
    public ICollection<SecondModel> SecondModels { get; init; } = [];
    public ICollection<ThirdModel> ThirdModels { get; init; } = [];
}
