using System.ComponentModel.DataAnnotations;

namespace SoftDevPlusAssessment.Dtos
{
    public class FileSearchDto
    {
        [Required]
        public string FolderPath { get; set; }
        [Required]
        public string SearchString { get; set; }
    }
}
