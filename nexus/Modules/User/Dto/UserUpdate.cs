using nexus.Utils;
using System.ComponentModel.DataAnnotations;

namespace nexus.Modules.User.Dto
{
    public class UserUpdate
    {
        public Guid? RoleId { get; set; }

        public Guid? PostId { get; set; }

        public long ?Nik { get; set; }

        public string? Image { get; set; }

        public string? Fullname { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Status { get; set; }
    }
}
