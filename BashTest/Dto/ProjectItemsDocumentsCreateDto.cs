using System.ComponentModel.DataAnnotations;

namespace BashTest.Dto
{
    public class ProjectItemsDocumentsCreateDto
    {
        [Required]
        public int DocumentsPackId { get; set; }
        [Required]        
        public int ProjectItemId { get; set; }
    }
    
}
