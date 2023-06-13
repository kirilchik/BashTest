using BashTest.Model;

namespace BashTest.Dto
{
    public class ProjectItemViewDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual List<ProjectItemViewDto> Children { get; set; } = new();
    }
}
