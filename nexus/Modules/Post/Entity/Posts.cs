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
        public Guid UserId { get; set; }

        [Column("category_id")]
        public Guid CategoryId { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("article")]
        public string Article { get; set; }

        [Required]
        [Column("slug")]
        public string Slug { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        public Categories Category { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public Users User { get; set; }
    }
}
