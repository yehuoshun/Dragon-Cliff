using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008A RID: 138
	[CallbackIdentity(210)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AssociateWithClanResult_t
	{
		// Token: 0x04000265 RID: 613
		public const int k_iCallback = 210;

		// Token: 0x04000266 RID: 614
		public EResult m_eResult;
	}
}
