using System.ComponentModel.DataAnnotations;

namespace DataBaseLayer.ViewModels.Email
{
    public class EmailViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Subject { get; set; }
    }
}
