// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastEndpoints_RecursionIssue.Database.Models.BaseModels;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public abstract class BaseContent<T> where T : BaseContent<T> {
    [Key] public Guid Id { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

    #region SoftDelete
    [NotMapped] public bool IsSoftDeleted => SoftDeleteDate != null;
    public DateTime? SoftDeleteDate { get; private set; }
    public void SoftDelete() => SoftDeleteDate = DateTime.UtcNow;
    #endregion
}
