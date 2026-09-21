using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200016C RID: 364
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ControllerDigitalActionData_t
	{
		// Token: 0x0400090C RID: 2316
		public byte bState;

		// Token: 0x0400090D RID: 2317
		public byte bActive;
	}
}
