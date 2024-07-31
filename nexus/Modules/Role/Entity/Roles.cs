using nexus.Modules.Post.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Modules.User.Entity;
using nexus.Config.Database;
using nexus.Modules.Role.Dto;

namespace nexus.Modules.Role.Entity
{
    public class Roles : Timestamps
    {
        // Constructor to initialize properties
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Roles(RoleCreate role)
        {
            Name = role.Name;
            Status = role.Status;
        }

        // Parameterless constructor (optional, for Entity Framework or other uses)
        public Roles() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
