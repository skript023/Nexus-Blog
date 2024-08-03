using nexus.Config.Database;
using nexus.Modules.Post.Entity;
using nexus.Modules.User.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nexus.Modules.Comment.Entity
{
    public class Comments : Timestamps
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid? UserId { get; set; }

        [Column("post_id")]
        public Guid? PostId { get; set; }

        [Required]
        [Column("fullname")]
        public required string Fullname { get; set; }

        [Required]
        [Column("email")]
        public required string Email { get; set; }

        [Required]
        [Column("comment")]
        public required string Comment { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        public Posts Post { get; set; }

        public Users User { get; set; }
    }
}
