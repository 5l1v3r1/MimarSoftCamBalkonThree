using System.Linq;
using System.Text;

namespace Repository.Business.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // TODO : passwordHash string mi yoksa byte disizi mi?
        public static void CreatePasswordHash
            (string password, out string passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString();
        }

        public static bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
        }
    }
}