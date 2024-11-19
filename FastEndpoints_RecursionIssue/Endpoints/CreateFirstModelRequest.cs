// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using FastEndpoints_RecursionIssue.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastEndpoints_RecursionIssue.Endpoints;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record CreateFirstModelRequest(
    [property: FromRoute] Guid UserId,
    [property: FromRoute] Guid FirstModelId, 
    [property: FastEndpoints.FromBody] 
    FirstModel Model    
);
