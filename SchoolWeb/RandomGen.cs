using System.Security.Cryptography;

namespace SchoolWeb
{
    public static class RandomGen
    {
        public static string GenerateRandomString()
        {
            using Aes crypto = Aes.Create();
            crypto.GenerateKey();
            return Convert.ToBase64String(crypto.Key);
        }
    }
}
