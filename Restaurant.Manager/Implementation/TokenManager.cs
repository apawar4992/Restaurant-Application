using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Model.Enums;

namespace Restaurant.Manager.Implementation
{
    public class TokenManager : ITokenManager
    {
        private readonly JWTSettings setting;
        public TokenManager(IOptions<JWTSettings> options)
        {
            setting = options.Value;
        }

        public TokenValidationError ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            }

            catch (SecurityTokenExpiredException)
            {
                return TokenValidationError.SecurityTokenExpiredException;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return TokenValidationError.InvalidSignatureException;
            }
            catch
            {
                return TokenValidationError.Unknown;
            }

            return TokenValidationError.Ok;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                //ValidateLifetime = true,
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = true,
                ValidIssuer = setting.Issuer,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.SecurityKey))
            };
        }
    }
}
