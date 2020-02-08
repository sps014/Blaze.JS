using System;
using Microsoft.JSInterop;
using System.Collections.Generic;
namespace Test
{
	public class TestClass
	{
		public IJSRuntime Runtime { get; set; }

		public TestClass(IJSRuntime runtime)
		{
			Runtime=runtime;
		}
		public async Task<Object> loadJSON(string path)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadJSON",path);
		}
		public async Task<Object> loadJSON(string path)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadJSON",path);
		}
		public async Task<Object> loadJSON(string path)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadJSON",path);
		}
		public async Task<String[]> loadStrings(string filename)
		{
			return await Runtime.InvokeAsync<String[]>("TestClass_loadStrings",filename);
		}
		public async Task<Object> loadTable(string filename)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadTable",filename);
		}
		public async Task<Object> loadTable(string filename)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadTable",filename);
		}
		public async Task<Object> loadXML(string filename)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadXML",filename);
		}
		public async Task<Object> loadBytes(string file)
		{
			return await Runtime.InvokeAsync<Object>("TestClass_loadBytes",file);
		}
		public async Task<Promise> httpGet(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpGet",path);
		}
		public async Task<Promise> httpGet(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpGet",path);
		}
		public async Task<Promise> httpGet(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpGet",path);
		}
		public async Task<Promise> httpPost(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpPost",path);
		}
		public async Task<Promise> httpPost(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpPost",path);
		}
		public async Task<Promise> httpPost(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpPost",path);
		}
		public async Task<Promise> httpDo(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpDo",path);
		}
		public async Task<Promise> httpDo(string path)
		{
			return await Runtime.InvokeAsync<Promise>("TestClass_httpDo",path);
		}
		public async Task<p5.PrintWriter> createWriter(string name)
		{
			return await Runtime.InvokeAsync<p5.PrintWriter>("TestClass_createWriter",name);
		}
		public async void write(Array data)
		{
			await Runtime.InvokeVoidAsync("TestClass_write",data);
		}
		public async void print(Array data)
		{
			await Runtime.InvokeVoidAsync("TestClass_print",data);
		}
		public async void clear()
		{
			await Runtime.InvokeVoidAsync("TestClass_clear");
		}
		public async void close()
		{
			await Runtime.InvokeVoidAsync("TestClass_close");
		}
		public async void save()
		{
			await Runtime.InvokeVoidAsync("TestClass_save");
		}
		public async void save(Object objectOrFilename)
		{
			await Runtime.InvokeVoidAsync("TestClass_save",objectOrFilename);
		}
		public async void saveJSON(Array json)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveJSON",json);
		}
		public async void saveStrings(String[] list)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveStrings",list);
		}
		public async void saveTable(p5.Table Table)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveTable",Table);
		}
		public async void downloadFile(string data)
		{
			await Runtime.InvokeVoidAsync("TestClass_downloadFile",data);
		}
	}
}
