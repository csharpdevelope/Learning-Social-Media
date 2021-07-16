using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.InfraStructure.Repositories
{
    public class PostMongoRepository : IPostRepository
    {
        Task<IEnumerable<Post>> IPostRepository.GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
