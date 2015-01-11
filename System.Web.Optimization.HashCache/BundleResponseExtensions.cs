using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGrease.Css.Extensions;

namespace System.Web.Optimization.HashCache
{
    internal static class BundleResponseExtensions
    {
        private const string VersionQueryString = "v";

        internal static BundleResponse AddHashToResponsePath(this BundleResponse bundleResponse)
        {
            bundleResponse.Files.ForEach(file =>
            {
                file.IncludedVirtualPath += "?" + VersionQueryString + "=" + file.GetContentHashCode();
            });
            return bundleResponse;
        }
    }
}
