using nexus.Config.Database;
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
        
        [Column("fullname")]
        public string Fullname { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("fullname")]
        public string Comment { get; set; }
        
        [Column("status")]
        public string Status { get; set; }
    }
}
