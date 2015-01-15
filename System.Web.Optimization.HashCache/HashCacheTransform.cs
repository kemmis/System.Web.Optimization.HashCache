using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Web.Optimization.HashCache
{
    public class HashCacheTransform : IBundleTransform
    {
        public bool AddHashToPath { get; set; }
        public string HashPathParameterName { get; set; }
        public bool UseServerCache { get; set; }
        public HttpCacheability HttpCacheability { get; set; }

        public void Process(BundleContext context, BundleResponse response)
        {
            if (BundleTable.EnableOptimizations)
            {
                return;
            }
            
            context.UseServerCache = UseServerCache;
            response.Cacheability = HttpCacheability;
            response.AddHashToResponsePath(HashPathParameterName);
        }
    }
}
