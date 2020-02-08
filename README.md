# Blaze.JS
Main Aim is to auto generate most of the C# and JS Code for Blazor interop.
 1. Blazor C# and JS interops Generator tool [Basic]
 2. JSDoc Parser ...
 
 ## Tool Usage
 1. navigate to ``` Blaze.JS\Blaze.JS\bin\Debug\netcoreapp3.1\Blaze.JS.exe```
 2. pass target directory of js file with jsDoc styled as argument.
 alternatively you can place js doc file content in ```Blaze.JS\Blaze.JS\bin\Debug\netcoreapp3.1\dir``` folder
 3. example:run ``` path/to/\Blaze.JS.exe path/to/folder/with/jsfiles ``` in terminal
 
 #### Advanced user
 
 you can modify ```JSDocHelper.cs``` to support more data type mapping.
 eg. ``` Boolean``` in jsdoc->``` bool``` in C# is added with simple Dictionary 
 ```c# 
 map.Add("Boolean", "bool");
```
 
 ### For mac,linux
 please compile dotnet core project yourself with ```dotnet build``` command 
 
