# Blaze.JS
Main Aim is to auto generate most of the C# and JS Code for Blazor interop.
 1. Blazor C# and JS interops Generator tool (Basic Data types)
 2. JSDoc Parser ...
 
 ## Showcase
 
 #### Input JSDoc
 ![input](https://user-images.githubusercontent.com/45932883/74593028-48a99a80-504d-11ea-93e5-d8ae7751077b.PNG)

 #### Output Generated C# and JS Wrapper
 ![output_cs](https://user-images.githubusercontent.com/45932883/74593040-7d1d5680-504d-11ea-9b53-f17fc93c7d65.PNG)
 ![output_js](https://user-images.githubusercontent.com/45932883/74593077-bc4ba780-504d-11ea-9a20-934368559655.PNG)


 
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
 
