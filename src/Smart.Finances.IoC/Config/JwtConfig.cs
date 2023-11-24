using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Smart.Finances.IoC.Config
{
    public static class JwtConfig
    {
        public static void ConfigureJwt(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "Smart.Finances",
                        ValidAudience = "Smart.Finances",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Esta e Minha Senha Secreta Para Proteger Meus Tokens!"))
                    };
                });
        }
    }
}
