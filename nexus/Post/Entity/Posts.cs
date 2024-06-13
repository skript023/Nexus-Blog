using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Config.Database;

namespace nexus.Post.Entity
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
    }
}
