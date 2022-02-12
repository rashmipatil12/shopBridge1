﻿using shopBridge.Service;  
using Microsoft.AspNetCore.Authentication;  
using Microsoft.Extensions.Logging;  
using Microsoft.Extensions.Options;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net.Http.Headers;  
using System.Security.Claims;  
using System.Text;  
using System.Text.Encodings.Web;  
using System.Threading.Tasks;  
  
namespace shopBridge.Model
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Property  
        readonly IProductService _productService;
        #endregion

        #region Constructor  
        public BasicAuthenticationHandler(IProductService productService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _productService = productService;
        }
        #endregion

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                if (!_productService.ValidateCredentials(username, password))
                    throw new ArgumentException("Invalid credentials");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }

            var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

    }
}