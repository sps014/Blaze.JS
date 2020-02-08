# Blaze.JS
 1. Blazor C# and JS interops Generator tool [Basic]
 2. JSDoc Parser ...
 3. JSDoc Analyzer...
 
 ## Tool Usage
 1. navigate to ``` Blaze.JS\Blaze.JS\bin\Debug\netcoreapp3.1\JSDocAnalyzer.exe```
 2. pass target directory of js file with jsDoc styled as argument.
 alternatively you can place js doc file content in ```Blaze.JS\Blaze.JS\bin\Debug\netcoreapp3.1\dir``` folder
 3. example:run ``` path/to/JSanalyzer.exe path/to/folder/with/jsfiles ``` in terminal
 
 #### Advanced user
 
 you can modify ```JSDocHelper.cs``` to support more data type mapping.
 eg. ``` Boolean``` in jsdoc->``` bool``` in C# is added with simple Dictionary 
 ```c# 
 map.Add("Boolean", "bool");
```
 
 ### For mac,linux
 please compile dotnet core project yourself with ```dotnet build``` command 
 
