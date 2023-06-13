using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BashTest.Model
{
    public class ProjectItem : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }
        public Project Project { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public ProjectItem? Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual List<ProjectItem> Children { get; set; } = new();
        public virtual List<ProjectItemsDocuments> DocumentsItems { get; set; } = new();
    }
}
