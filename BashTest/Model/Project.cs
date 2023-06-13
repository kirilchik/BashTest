using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BashTest.Model
{
    public class Project : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Shifr { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        public virtual List<ProjectItem> ProjectItems { get; set; } = new();
    }
}
