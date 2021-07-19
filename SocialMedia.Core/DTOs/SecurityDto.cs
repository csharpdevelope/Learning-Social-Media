﻿using SocialMedia.Core.Enumerations;

namespace SocialMedia.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
