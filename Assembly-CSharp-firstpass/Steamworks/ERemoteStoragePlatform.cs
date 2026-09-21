using System;

namespace Steamworks
{
	// Token: 0x02000139 RID: 313
	[Flags]
	public enum ERemoteStoragePlatform
	{
		// Token: 0x040006CB RID: 1739
		k_ERemoteStoragePlatformNone = 0,
		// Token: 0x040006CC RID: 1740
		k_ERemoteStoragePlatformWindows = 1,
		// Token: 0x040006CD RID: 1741
		k_ERemoteStoragePlatformOSX = 2,
		// Token: 0x040006CE RID: 1742
		k_ERemoteStoragePlatformPS3 = 4,
		// Token: 0x040006CF RID: 1743
		k_ERemoteStoragePlatformLinux = 8,
		// Token: 0x040006D0 RID: 1744
		k_ERemoteStoragePlatformReserved2 = 16,
		// Token: 0x040006D1 RID: 1745
		k_ERemoteStoragePlatformAll = -1
	}
}
