using nexus.Config.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nexus.Modules.Comment.Entity
{
    public class Comments : Timestamps
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("post_id")]
        public Guid PostId { get; set; }

        [Required]
        [Column("fullname")]
        public string Fullname { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("comment")]
        public string Comment { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }
    }
}
