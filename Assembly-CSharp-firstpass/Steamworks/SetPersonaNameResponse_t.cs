using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007F RID: 127
	[CallbackIdentity(347)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SetPersonaNameResponse_t
	{
		// Token: 0x0400023C RID: 572
		public const int k_iCallback = 347;

		// Token: 0x0400023D RID: 573
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess;

		// Token: 0x0400023E RID: 574
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocalSuccess;

		// Token: 0x0400023F RID: 575
		public EResult m_result;
	}
}
