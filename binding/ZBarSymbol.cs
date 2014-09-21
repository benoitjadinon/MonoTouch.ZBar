using System;
using MonoTouch.ObjCRuntime;

namespace ZBar
{
	public partial class ZBarSymbol {
		public static ZBarSymbol Create (IntPtr symbol) { 
			ZBarSymbol a = new ZBarSymbol(); 
			var ptr = Messaging.IntPtr_objc_msgSend (Class.GetHandle (a.GetType ()), Selector.GetHandle ("alloc")); 
			ptr = Messaging.IntPtr_objc_msgSend_IntPtr (ptr, Selector.GetHandle ("initWithSymbol:"), symbol); 
			var obj = new ZBarSymbol (ptr); 
			obj.DangerousRelease (); // this is because we get a ref when creating/initing the object manually above 
			return obj; 
		}
	}

}