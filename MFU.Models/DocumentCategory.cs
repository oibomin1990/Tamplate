using MFU.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFU.Models
{
    public class DocumentCategory : EntityBase
    {
        [Display(ResourceType = typeof(Resource), Name = "DocumentCategoryName")]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "DocumentCategoryDescription")]
        public string Description { get; set; }
        public List<Document> Documents { get; set; }
    }
}
