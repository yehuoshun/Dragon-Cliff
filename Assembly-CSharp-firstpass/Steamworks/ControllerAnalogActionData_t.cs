using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200016B RID: 363
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ControllerAnalogActionData_t
	{
		// Token: 0x04000908 RID: 2312
		public EControllerSourceMode eMode;

		// Token: 0x04000909 RID: 2313
		public float x;

		// Token: 0x0400090A RID: 2314
		public float y;

		// Token: 0x0400090B RID: 2315
		public byte bActive;
	}
}
