using nexus.Modules.Post.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Modules.User.Entity;

namespace nexus.Modules.Role.Entity
{
    public class Roles
    {
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
