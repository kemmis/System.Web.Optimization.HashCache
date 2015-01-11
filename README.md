# System.Web.Optimization.HashCache


A helper bundle transform which prevents caching of bundle contents when optimizations 
are disabled - when debug is enabled or BundleTable.EnableOptimizations is false.

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

* Add cache-busting content hash to the unbundled file paths output by Scripts.Render() and Styles.Render() calls.
* Disable caching bundle output in the HttpContext.Cache
* Set the Cache-Control HTTP header to tell browser not to cache bundle contents.