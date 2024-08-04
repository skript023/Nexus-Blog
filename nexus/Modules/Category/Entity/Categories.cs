using nexus.Config.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Modules.Post.Entity;

namespace nexus.Modules.Category.Entity
{
    public class Categories : Timestamps
    {
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
