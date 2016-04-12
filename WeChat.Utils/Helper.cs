using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Utils
{
    public static class Helper
    {
        
        public static string CheckSignature(string token, string encodingAESKey, string signature, string timestamp, string nonce,  string echostr)
        {
            
            var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            var arrString = string.Join("", arr);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            ////对比，
            //if (enText.ToString() == signature)
            //{
            //    return (echostr);
            //}
            //return string.Empty;
            return enText.ToString();
        }
    }
}
