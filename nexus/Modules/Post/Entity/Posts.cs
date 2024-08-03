using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Config.Database;
using nexus.Modules.Category.Entity;
using nexus.Modules.Comment.Entity;
using nexus.Modules.User.Entity;

namespace nexus.Modules.Post.Entity
{
    public class Posts : Timestamps
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid? UserId { get; set; }

        [Column("category_id")]
        public Guid? CategoryId { get; set; }

        [Required]
        [Column("title")]
        public required string Title { get; set; }

        [Required]
        [Column("article")]
        public required string Article { get; set; }

        [Required]
        [Column("slug")]
        public required string Slug { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Required]
        [Column("status")]
        public required string Status { get; set; }

        public Categories Category { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public Users User { get; set; }
    }
}
