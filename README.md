# System.Web.Optimization.HashCache


A helper bundle transform which prevents caching of bundle contents when optimizations 
are disabled - when debug is enabled or BundleTable.EnableOptimizations is false.

**NuGet package coming soon!!**

## Usage

### You can apply HashCache to all bundles in a BundlesCollection

Execute the ApplyHashCache() extension method on the BundlesCollection Instance 
**after all bundles have been added to the collection**. 

```cs
BundleTable.Bundles.ApplyHashCache();
```

### Or you can apply HashCache to a single Bundle

Create an instance of the HashCacheTransform and add it to the bundle instance you want 
to apply HashCache to.

```cs
var myBundle = new ScriptBundle("~/bundle_virtual_path").Include("~/scripts/jsfile.js");
myBundle.Transforms.Add(new HashCacheTransform());
```

## Options

* **AddHashToPath:** Add cache-busting content hash to the unbundled file paths output by Scripts.Render() and Styles.Render() calls.
* **HttpCacheability:** Disable caching bundle output in the HttpContext.Cache
* **UseServerCache:** Set the Cache-Control HTTP header to tell browser not to cache bundle contents.

## Applying Options

The above options can either be passed into the ApplyHacheCache() extension method call
or set on individual instances of the HashCachTransform class.

```cs
bundles.ApplyHashCache(true, false, HttpCacheability.NoCache);)
```

```cs
var hashCacheTransform = new HashCacheTransform
{
    AddHashToPath = true,
    HttpCacheability = HttpCacheability.NoCache,
    UseServerCache = false
};
```