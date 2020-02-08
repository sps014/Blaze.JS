using System;
using Microsoft.JSInterop;
using System.Collections.Generic;
namespace Test
{
	public class P6454
	{
		public IJSRuntime Runtime { get; set; }

		public P6454(IJSRuntime runtime)
		{
			Runtime=runtime;
		}
		public async void applyMatrix(double a , double b)
		{
			await Runtime.InvokeVoidAsync("P6454_applyMatrix",a,b);
		}
		public async void applyMatrix(double a , double b , double c)
		{
			await Runtime.InvokeVoidAsync("P6454_applyMatrix",a,b,c);
		}
		public async void applyMatrix(double a , double b , double c , double d)
		{
			await Runtime.InvokeVoidAsync("P6454_applyMatrix",a,b,c,d);
		}
		public async void applyMatrix(double a , double b , double c , double d , double e)
		{
			await Runtime.InvokeVoidAsync("P6454_applyMatrix",a,b,c,d,e);
		}
		public async void applyMatrix(double a , double b , double c , double d , double e , double f)
		{
			await Runtime.InvokeVoidAsync("P6454_applyMatrix",a,b,c,d,e,f);
		}
	}
}
