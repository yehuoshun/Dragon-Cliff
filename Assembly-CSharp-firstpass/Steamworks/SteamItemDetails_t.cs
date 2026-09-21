using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000170 RID: 368
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamItemDetails_t
	{
		// Token: 0x0400091F RID: 2335
		public SteamItemInstanceID_t m_itemId;

		// Token: 0x04000920 RID: 2336
		public SteamItemDef_t m_iDefinition;

		// Token: 0x04000921 RID: 2337
		public ushort m_unQuantity;

		// Token: 0x04000922 RID: 2338
		public ushort m_unFlags;
	}
}
