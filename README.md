# System.Web.Optimization.HashCache

<img src="https://ci.appveyor.com/api/projects/status/e0xqdpo0078xd94w/branch/master?svg=true&passingText=build%20status%20-%20awesomesauce" width="100%" />

A helper bundle transform which prevents caching of bundle contents when optimizations 
are disabled - when debug is enabled or BundleTable.EnableOptimizations is false.

## Get it on Nuget!

    Install-Package System.Web.Optimization.HashCache

## Elevator Speech

This transform prevents browsers from loading old cached versions of your 
code when you are running in debug mode, by adding a hash of the file content
to the end of the file path:

```
<link href="/css/styles.css?~v=Iz7DDyL6DCDnT_L414h7aec4VUNOlN9dDYVRGoD2ZB01" rel="stylesheet"/><script src="/js/app.js?~v=QWNK55__txkMIVFvtdF3fy5lDLK7GLkwLzP8nzCV6nw1"></script>
```

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
* **HashPathParameterName:** Set the parameter name used in the query string when AddHashToPath is enabled. The default parameter name is "~v".

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