using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MindSpringsTest.Models;

namespace MindSpringsTest.Services.IServices
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(User user);
        Task<(bool, string)> LoginAsync(Login login, ModelStateDictionary modelState);
    }
}
