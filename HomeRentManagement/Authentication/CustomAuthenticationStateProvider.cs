using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.JSInterop;

namespace HomeRentManagement.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private const string UserSessionKey = "UserSession";
        private readonly IJSRuntime _jsRuntime;
        private readonly IDataProtector _dataProtector;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IDataProtectionProvider dataProtectionProvider)
        {
            _jsRuntime = jsRuntime;
            _dataProtector = dataProtectionProvider.CreateProtector(typeof(CustomAuthenticationStateProvider).FullName);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var encryptedUserSessionJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UserSessionKey);
                var decryptedUserSessionJson = Decrypt(encryptedUserSessionJson);
                var userSession = decryptedUserSessionJson != null ? JsonSerializer.Deserialize<UserSession>(decryptedUserSessionJson) : null;

                if (userSession == null)
                    return new AuthenticationState(_anonymous);

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));

                return new AuthenticationState(claimsPrincipal);
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            string encryptedUserSessionJson = null;
            if (userSession != null)
            {
                var userSessionJson = JsonSerializer.Serialize(userSession);
                encryptedUserSessionJson = Encrypt(userSessionJson);
            }

            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UserSessionKey, encryptedUserSessionJson);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(userSession != null ?
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Role, userSession.Role)
                })) : _anonymous)));
        }

        private string Encrypt(string input)
        {
            var protectedData = _dataProtector.Protect(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(protectedData);
        }

        private string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            var protectedData = Convert.FromBase64String(input);
            var unprotectedData = _dataProtector.Unprotect(protectedData);
            return Encoding.UTF8.GetString(unprotectedData);
        }
    }
}
