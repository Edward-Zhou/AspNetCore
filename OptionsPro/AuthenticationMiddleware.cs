using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OptionsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPro
{
    public static class AuthenticationMiddleware
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string issuer, string key)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // validate the server that created that token
                        ValidateIssuer = true,
                        // ensure that the recipient of the token is authorized to receive it
                        ValidateAudience = true,
                        // check that the token is not expired and that the signing key of the issuer is valid
                        ValidateLifetime = true,
                        // verify that the key used to sign the incoming token is part of a list of trusted keys
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            return services;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtOptions opt)
        {
            string issuer = opt.Issuer;
            string key = opt.Key;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // validate the server that created that token
                        ValidateIssuer = true,
                        // ensure that the recipient of the token is authorized to receive it
                        ValidateAudience = true,
                        // check that the token is not expired and that the signing key of the issuer is valid
                        ValidateLifetime = true,
                        // verify that the key used to sign the incoming token is part of a list of trusted keys
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            return services;
        }

    }
}
