using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B8 RID: 184
	[CallbackIdentity(4002)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct VolumeHasChanged_t
	{
		// Token: 0x04000323 RID: 803
		public const int k_iCallback = 4002;

		// Token: 0x04000324 RID: 804
		public float m_flNewVolume;
	}
}
