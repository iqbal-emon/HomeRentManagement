using System;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HomeRentManagement.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.JSInterop;

namespace HomeRentManagement.Data
{
    public class UserIdDecrypt
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserSessionKey = "userSession";
        private readonly IDataProtector _dataProtector;

        public UserIdDecrypt(IJSRuntime jsRuntime, IDataProtectionProvider dataProtectionProvider)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
            _dataProtector = dataProtectionProvider?.CreateProtector(typeof(CustomAuthenticationStateProvider).FullName)
                             ?? throw new ArgumentNullException(nameof(dataProtectionProvider));
        }

        public async Task<string> GetDecryptedUserId()
        {
            var encryptedUserSessionJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "UserSession");
            if (string.IsNullOrEmpty(encryptedUserSessionJson))
                return null;

            try
            {
                var userSessionJson = Decrypt(encryptedUserSessionJson);
                var userSession = JsonSerializer.Deserialize<UserSession>(userSessionJson);
                return userSession?.Id;
            }
            catch (Exception ex)
            {
                // Handle decryption or deserialization errors
                Console.WriteLine($"Error decrypting user session: {ex.Message}");
                return null;
            }
        }

        // Assuming you have a Decrypt method here to decrypt the user session JSON
        private string Decrypt(string encryptedData)
        {
            if (string.IsNullOrEmpty(encryptedData))
                return null;

            var protectedData = Convert.FromBase64String(encryptedData);
            var unprotectedData = _dataProtector.Unprotect(protectedData);
            return Encoding.UTF8.GetString(unprotectedData);
        }
    }
}
