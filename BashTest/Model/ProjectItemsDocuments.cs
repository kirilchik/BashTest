using System.ComponentModel.DataAnnotations;

namespace BashTest.Model
{
    public class ProjectItemsDocuments : BaseEntity
    {        
        public DocumentsPack DocumentsPack { get; set; }        
        public int DocumentsPackId { get; set; }
        public ProjectItem ProjectItem { get; set; }        
        public int ProjectItemId { get; set; }

    }
}
