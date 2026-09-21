using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000114 RID: 276
	[CallbackIdentity(702)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LowBatteryPower_t
	{
		// Token: 0x0400046A RID: 1130
		public const int k_iCallback = 702;

		// Token: 0x0400046B RID: 1131
		public byte m_nMinutesBatteryLeft;
	}
}
