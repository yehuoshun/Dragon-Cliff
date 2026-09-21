using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000034 RID: 52
	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBase
	{
		// Token: 0x06000324 RID: 804 RVA: 0x0000F9D3 File Offset: 0x0000DDD3
		public CCallbackBase()
		{
		}

		// Token: 0x04000191 RID: 401
		public const byte k_ECallbackFlagsRegistered = 1;

		// Token: 0x04000192 RID: 402
		public const byte k_ECallbackFlagsGameServer = 2;

		// Token: 0x04000193 RID: 403
		public IntPtr m_vfptr;

		// Token: 0x04000194 RID: 404
		public byte m_nCallbackFlags;

		// Token: 0x04000195 RID: 405
		public int m_iCallback;
	}
}
