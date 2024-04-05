using Microsoft.AspNetCore.Identity;

namespace MindSpringsTest.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<StringText> StringTexts { get; set; }
    }
}
