using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000FE RID: 254
	[CallbackIdentity(113)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ClientGameServerDeny_t
	{
		// Token: 0x04000421 RID: 1057
		public const int k_iCallback = 113;

		// Token: 0x04000422 RID: 1058
		public uint m_uAppID;

		// Token: 0x04000423 RID: 1059
		public uint m_unGameServerIP;

		// Token: 0x04000424 RID: 1060
		public ushort m_usGameServerPort;

		// Token: 0x04000425 RID: 1061
		public ushort m_bSecure;

		// Token: 0x04000426 RID: 1062
		public uint m_uReason;
	}
}
