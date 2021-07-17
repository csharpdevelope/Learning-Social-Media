using SocialMedia.Core.QueryFilter;
using SocialMedia.InfraStructure.Interfaces;
using System;

namespace SocialMedia.InfraStructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionurl)
        {
            string baseUrl = $"{_baseUri}{actionurl}";
            return new Uri(baseUrl);
        }
    }
}
