using System.ComponentModel.DataAnnotations;

namespace LSIEntities.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}