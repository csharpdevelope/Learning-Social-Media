using SocialMedia.Core.CustomEntity;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Response
{
    public class ApiResponse<T>
    {
        private IEnumerable<PostDto> postDto;

        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public MetaData Meta { get; set; }
    }
}
