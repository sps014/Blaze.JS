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
		public async void plane()
		{
			await Runtime.InvokeVoidAsync("TestClass_plane");
		}
		public async void plane(double width)
		{
			await Runtime.InvokeVoidAsync("TestClass_plane",width);
		}
		public async void box()
		{
			await Runtime.InvokeVoidAsync("TestClass_box");
		}
		public async void box(double width)
		{
			await Runtime.InvokeVoidAsync("TestClass_box",width);
		}
		public async void sphere()
		{
			await Runtime.InvokeVoidAsync("TestClass_sphere");
		}
		public async void sphere(double radius)
		{
			await Runtime.InvokeVoidAsync("TestClass_sphere",radius);
		}
		public async void cylinder()
		{
			await Runtime.InvokeVoidAsync("TestClass_cylinder");
		}
		public async void cylinder(double radius)
		{
			await Runtime.InvokeVoidAsync("TestClass_cylinder",radius);
		}
		public async void cone()
		{
			await Runtime.InvokeVoidAsync("TestClass_cone");
		}
		public async void cone(double radius)
		{
			await Runtime.InvokeVoidAsync("TestClass_cone",radius);
		}
		public async void ellipsoid()
		{
			await Runtime.InvokeVoidAsync("TestClass_ellipsoid");
		}
		public async void ellipsoid(double radiusx)
		{
			await Runtime.InvokeVoidAsync("TestClass_ellipsoid",radiusx);
		}
		public async void torus()
		{
			await Runtime.InvokeVoidAsync("TestClass_torus");
		}
		public async void torus(double radius)
		{
			await Runtime.InvokeVoidAsync("TestClass_torus",radius);
		}
	}
}
