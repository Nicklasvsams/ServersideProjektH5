using Microsoft.AspNetCore.DataProtection;

namespace ServersideProjektH5.Codes
{
    public class Encryption
    {
        private readonly IDataProtector _dataProtector;

        public Encryption(IDataProtectionProvider dataProtector)
        {
            _dataProtector = dataProtector.CreateProtector("ServersideProjektH5.codes.Encryption.Nicklas");
        }

        public string Protect(string valueToEncrypt) => _dataProtector.Protect(valueToEncrypt);

        public string Unprotect(string valueToDecrypt) => _dataProtector.Unprotect(valueToDecrypt);
    }
}
