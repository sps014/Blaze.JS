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
		public async Task<int> myFunc(int data1)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc",data1);
		}
		public async Task<int> myFunc(int data1 , string woff)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc",data1,woff);
		}
		public async Task<int> myFunc3(int d3)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc3",d3);
		}
		public async Task<int> myFunc3(int d3 , string woff)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc3",d3,woff);
		}
		public async Task<int> myFunc4(int d1)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc4",d1);
		}
		public async Task<int> myFunc4(int d1 , string woff)
		{
			return await Runtime.InvokeAsync<int>("TestClass_myFunc4",d1,woff);
		}
	}
}
