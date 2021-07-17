using SocialMedia.Core.QueryFilter;
using System;

namespace SocialMedia.InfraStructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionurl);
    }
}