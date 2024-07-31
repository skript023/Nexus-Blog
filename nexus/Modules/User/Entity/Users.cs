using nexus.Config.Database;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Post.Entity;
using nexus.Modules.Role.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nexus.Modules.User.Entity
{
    public class Users : Timestamps
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("role_id")]
        public Guid RoleId { get; set; }
        
        [Column("post_id")]
        public Guid PostId { get; set; }

        [Column("nik")]
        public long Nik { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Required]
        [Column("fullname")]
        public string Fullname { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("status")]
        public string Status { get; set; }

        public Roles Role { get; set; }

        public ICollection<Posts> Posts { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
