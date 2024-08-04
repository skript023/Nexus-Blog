using Microsoft.AspNetCore.Identity;
using nexus.Config.Database;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Post.Entity;
using nexus.Modules.Role.Entity;
using nexus.Modules.User.Dto;
using nexus.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nexus.Modules.User.Entity
{
    public class Users : Timestamps
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Users() { }

        public Users(UserCreate value) 
        {
            RoleId = value.RoleId;
            Nik = NikGenerate.Instance.EightDigit();
            Image = value.Image;
            Fullname = value.Fullname;
            Username = value.Username;
            Email = value.Email;
            HashPassword(value.Password);
            Status = "active";
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Column("role_id")]
        public Guid? RoleId { get; set; }

        [Column("nik")]
        public long Nik { get; set; }

        [Column("image")]
        public string? Image { get; set; }

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

        public void HashPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
