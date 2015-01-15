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
        internal static BundleResponse AddHashToResponsePath(this BundleResponse bundleResponse, string hashPathParameterName = null)
        {
            bundleResponse.Files.ForEach(file =>
            {
                file.IncludedVirtualPath += "?" + (hashPathParameterName ?? Defaults.HashPathParameterName) + "=" + file.GetContentHashCode();
            });
            return bundleResponse;
        }
    }
}
