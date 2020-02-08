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
		public async Task<p5.Image> createImage(Integer width)
		{
			return await Runtime.InvokeAsync<p5.Image>("TestClass_createImage",width);
		}
		public async void saveCanvas(p5.Element selectedCanvas)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveCanvas",selectedCanvas);
		}
		public async void saveCanvas()
		{
			await Runtime.InvokeVoidAsync("TestClass_saveCanvas");
		}
		public async void saveCanvas(String filename)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveCanvas",filename);
		}
		public async void saveFrames(String filename)
		{
			await Runtime.InvokeVoidAsync("TestClass_saveFrames",filename);
		}
	}
}
