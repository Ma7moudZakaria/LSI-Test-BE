using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSIEntities.Entities;

public class Premise
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}