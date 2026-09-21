using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011A RID: 282
	[CallbackIdentity(4605)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct BroadcastUploadStop_t
	{
		// Token: 0x04000477 RID: 1143
		public const int k_iCallback = 4605;

		// Token: 0x04000478 RID: 1144
		public EBroadcastUploadResult m_eResult;
	}
}
