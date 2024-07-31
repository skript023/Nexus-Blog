using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using nexus.Utils;

namespace nexus.Modules.User.Dto
{
    public class UserCreate
    {
        public Guid? RoleId { get; set; }

        public Guid? PostId { get; set; }

        public long Nik { get; set; } = NikGenerate.Instance.SixDigit();

        public string? Image { get; set; }

        [Required]
        public required string Fullname { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public string Status { get; set; } = "active";
    }
}
