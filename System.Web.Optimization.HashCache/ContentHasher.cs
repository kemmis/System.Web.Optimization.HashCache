using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Optimization.HashCache
{
    internal class ContentHasher
    {
        internal static string ComputeHash(string input)
        {
            using (SHA256 sha256 = CreateHashAlgorithm())
            {
                byte[] hash = sha256.ComputeHash(Encoding.Unicode.GetBytes(input));
                return HttpServerUtility.UrlTokenEncode(hash);
            }
        }

        private static SHA256 CreateHashAlgorithm()
        {
            if (AllowOnlyFipsAlgorithms)
            {
                return new SHA256CryptoServiceProvider();
            }
            else
            {
                return new SHA256Managed();
            }
        }

        private static readonly bool _isMonoRuntime = Type.GetType("Mono.Runtime") != null;
        /// <summary>
        /// Determines if we are to only allow Fips compliant algorithms. 
        /// </summary>
        /// <remarks>
        /// CryptoConfig.AllowOnlyFipsAlgorithms does not exist in Mono. 
        /// </remarks>
        private static bool AllowOnlyFipsAlgorithms
        {
            get
            {
                return !_isMonoRuntime && CryptoConfig.AllowOnlyFipsAlgorithms;
            }
        }
    }
}
