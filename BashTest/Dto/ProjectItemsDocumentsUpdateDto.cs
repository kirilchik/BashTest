using System.ComponentModel.DataAnnotations;

namespace BashTest.Dto
{
    public class ProjectItemsDocumentsUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DocumentsPackId { get; set; }

        [Required]
        public int ProjectItemId { get; set; }
    }

}
