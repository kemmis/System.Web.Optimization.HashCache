using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Optimization.HashCache
{
    internal static class BundleFileExtensions
    {
        internal static string GetContentHashCode(this BundleFile bundleFile)
        {
            string content = null;
            string hash = null;

            using (var reader = new StreamReader(bundleFile.VirtualFile.Open()))
            {
                content = reader.ReadToEnd();
            }

            if (String.IsNullOrEmpty(content))
            {
                hash = String.Empty;
            }
            else
            {
                hash = ContentHasher.ComputeHash(content);
            }

            return hash;
        }
    }
}
