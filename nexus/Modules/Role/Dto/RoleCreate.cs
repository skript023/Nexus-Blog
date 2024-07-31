using System.ComponentModel.DataAnnotations;

namespace nexus.Modules.Role.Dto
{
    public class RoleCreate
    {
        [Required]
        public required string Name { get; set; }

        [Required] 
        public required string Status { get; set; }
    }
}
