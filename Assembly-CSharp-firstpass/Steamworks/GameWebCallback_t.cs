using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000105 RID: 261
	[CallbackIdentity(164)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameWebCallback_t
	{
		// Token: 0x04000437 RID: 1079
		public const int k_iCallback = 164;

		// Token: 0x04000438 RID: 1080
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szURL;
	}
}
