using System.ComponentModel.DataAnnotations;

namespace BashTest.Dto
{
    public class DocumentsPackCreateDto
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int MarkId { get; set; }
    }
}
