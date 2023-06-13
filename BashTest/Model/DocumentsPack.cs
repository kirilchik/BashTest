using System.ComponentModel.DataAnnotations;

namespace BashTest.Model
{
    public class DocumentsPack : BaseEntity
    {
        [Required]
        public int Number { get; set; }        
        public Mark Mark { get; set; }
        [Required]
        public int MarkId { get; set; }
        public virtual List<ProjectItemsDocuments> DocumentsItems { get; set; } = new();
    }
}
