using Restaurant.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Manager.Interfaces
{
    public interface ITokenManager
    {
        TokenValidationError ValidateToken(string token);
    }
}
