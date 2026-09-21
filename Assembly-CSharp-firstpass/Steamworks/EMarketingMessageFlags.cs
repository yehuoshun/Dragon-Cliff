using System;

namespace Steamworks
{
	// Token: 0x02000163 RID: 355
	[Flags]
	public enum EMarketingMessageFlags
	{
		// Token: 0x04000894 RID: 2196
		k_EMarketingMessageFlagsNone = 0,
		// Token: 0x04000895 RID: 2197
		k_EMarketingMessageFlagsHighPriority = 1,
		// Token: 0x04000896 RID: 2198
		k_EMarketingMessageFlagsPlatformWindows = 2,
		// Token: 0x04000897 RID: 2199
		k_EMarketingMessageFlagsPlatformMac = 4,
		// Token: 0x04000898 RID: 2200
		k_EMarketingMessageFlagsPlatformLinux = 8,
		// Token: 0x04000899 RID: 2201
		k_EMarketingMessageFlagsPlatformRestrictions = 14
	}
}
