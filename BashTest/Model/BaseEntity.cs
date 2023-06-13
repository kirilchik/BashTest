using System.ComponentModel.DataAnnotations;

namespace BashTest.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
