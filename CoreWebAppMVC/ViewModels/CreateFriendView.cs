using CoreWebAppMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace CoreWebAppMVC.ViewModels
{
    public class CreateFriendView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), MaxLength(100, ErrorMessage = "The Name must be least than 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Email Wrong Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must select a skill from the list")]
        public SkillEnum? Skill { get; set; }

        public IFormFile ImagePath { get; set; }
    }
}
