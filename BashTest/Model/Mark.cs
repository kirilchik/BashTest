using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BashTest.Model
{
    public class Mark : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string ShortName { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string FullName { get; set; }
    }
}
