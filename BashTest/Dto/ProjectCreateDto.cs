using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BashTest.Model;

namespace BashTest.Dto
{
    public class ProjectCreateDto
    {
        [Required]
        public string Shifr { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
