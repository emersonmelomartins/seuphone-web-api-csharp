using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seuphone.Api.Helpers
{

    public static class CommonMethods
    {
        public static string SecretKey = "abc!@#$593)(*";

        public static string WordEncrypter(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return "";
            }

            word += SecretKey;
            var wordBytes = Encoding.UTF8.GetBytes(word);
            return Convert.ToBase64String(wordBytes);
        }

        public static string WordDecrypter(string base64Word)
        {
            if(string.IsNullOrEmpty(base64Word))
            {
                return "";
            }

            var base64Bytes = Convert.FromBase64String(base64Word);
            var result = Encoding.UTF8.GetString(base64Bytes);
            result = result.Substring(0, result.Length - SecretKey.Length);

            return result;
        }

    }
}
