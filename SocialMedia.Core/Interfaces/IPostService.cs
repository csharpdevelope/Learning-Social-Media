using SocialMedia.Core.CustomEntity;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Post> GetPosts(PostQueryFilter filter);
        Task<Post> GetPost(int id);
        Task InsertPost(Post post);
        bool UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}