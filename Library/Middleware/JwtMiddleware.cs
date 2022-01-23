using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RizkiHendraFrameWork.BussLogic.Custom;
using RizkiHendraFrameWork.Common;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizkiHendraFrameWork.Library.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly appSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<appSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context,tokenBL tokenBL )
        {
            var token = context.Request.Headers[clsConstantClass.tokenName].FirstOrDefault()?.Split(" ").Last(); 

            if (token != null)
                attachUserToContext(context , token );

            await _next(context);
        }

        private void attachUserToContext(HttpContext context , string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userDt = JsonConvert.DeserializeObject<userSessoionModel>((jwtToken.Claims.First(x => x.Type == clsConstantClass.sessionName).Value));
                context.Items[clsConstantClass.sessionName] = userDt;  
            }
            catch(Exception ex)
            {
                throw new ArgumentException("There Something wrong while validation token => " + ex.Message);
            }
        }
    }
}
