using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200016D RID: 365
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ControllerMotionData_t
	{
		// Token: 0x0400090E RID: 2318
		public float rotQuatX;

		// Token: 0x0400090F RID: 2319
		public float rotQuatY;

		// Token: 0x04000910 RID: 2320
		public float rotQuatZ;

		// Token: 0x04000911 RID: 2321
		public float rotQuatW;

		// Token: 0x04000912 RID: 2322
		public float posAccelX;

		// Token: 0x04000913 RID: 2323
		public float posAccelY;

		// Token: 0x04000914 RID: 2324
		public float posAccelZ;

		// Token: 0x04000915 RID: 2325
		public float rotVelX;

		// Token: 0x04000916 RID: 2326
		public float rotVelY;

		// Token: 0x04000917 RID: 2327
		public float rotVelZ;
	}
}
