using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGrease.Css.Extensions;

namespace System.Web.Optimization.HashCache
{
    public static class BundleCollectionExtensions
    {
        public static BundleCollection ApplyHashCache(this BundleCollection bundleCollection, bool addHashToPath = true,
           bool useServerCache = false, HttpCacheability httpCacheability = HttpCacheability.NoCache, string hashPathParameterName = null)
        {
            var transform = new HashCacheTransform()
            {
                AddHashToPath = addHashToPath,
                HttpCacheability = httpCacheability,
                HashPathParameterName = hashPathParameterName,
                UseServerCache = useServerCache
            };
            bundleCollection.ForEach(bundle => bundle.Transforms.Add(transform));
            return bundleCollection;
        }
    }
}
