using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000106 RID: 262
	[CallbackIdentity(165)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct StoreAuthURLResponse_t
	{
		// Token: 0x04000439 RID: 1081
		public const int k_iCallback = 165;

		// Token: 0x0400043A RID: 1082
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
		public string m_szURL;
	}
}
