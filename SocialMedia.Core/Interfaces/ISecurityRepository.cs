using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}