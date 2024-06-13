using System.ComponentModel.DataAnnotations.Schema;

namespace nexus.Config.Database
{
    public abstract class Timestamps
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
