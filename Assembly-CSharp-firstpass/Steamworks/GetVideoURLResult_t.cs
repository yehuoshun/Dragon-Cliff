using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011B RID: 283
	[CallbackIdentity(4611)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetVideoURLResult_t
	{
		// Token: 0x04000479 RID: 1145
		public const int k_iCallback = 4611;

		// Token: 0x0400047A RID: 1146
		public EResult m_eResult;

		// Token: 0x0400047B RID: 1147
		public AppId_t m_unVideoAppID;

		// Token: 0x0400047C RID: 1148
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;
	}
}
