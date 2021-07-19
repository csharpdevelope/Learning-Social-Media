using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.InfraStructure.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool check(string hash, string password);
    }
}
