using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList2
{
    public class AuthOptions
    {
        public const string ISSUER = "TaskLst";
        public const string AUDIENCE = "AuthClient"; 
        const string KEY = "secretcretkeyTaskiikList";   // ключ для шифрации
        public const int LIFETIME = 40; // время жизни токена (
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
