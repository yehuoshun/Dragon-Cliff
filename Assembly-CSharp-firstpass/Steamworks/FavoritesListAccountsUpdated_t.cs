using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B6 RID: 182
	[CallbackIdentity(516)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FavoritesListAccountsUpdated_t
	{
		// Token: 0x04000320 RID: 800
		public const int k_iCallback = 516;

		// Token: 0x04000321 RID: 801
		public EResult m_eResult;
	}
}
