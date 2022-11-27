using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSIEntities.Entities;

public class Report
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfExport { get; set; }
    public Guid UserId { get; set; }
    public Guid PremiseId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; }
    [ForeignKey(nameof(PremiseId))] public Premise Premise { get; set; }
}