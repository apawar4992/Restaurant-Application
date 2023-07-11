using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Enums
{
    public enum TokenValidationError
    {
        SecurityTokenExpiredException,
        InvalidSignatureException,
        UnAuthorized,
        Unknown,
        Ok
    }
}
