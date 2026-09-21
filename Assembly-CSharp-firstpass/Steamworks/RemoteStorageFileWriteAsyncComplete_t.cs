using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E5 RID: 229
	[CallbackIdentity(1331)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageFileWriteAsyncComplete_t
	{
		// Token: 0x040003C8 RID: 968
		public const int k_iCallback = 1331;

		// Token: 0x040003C9 RID: 969
		public EResult m_eResult;
	}
}
