using System;

namespace Steamworks
{
	// Token: 0x0200015D RID: 349
	[Flags]
	public enum EAppOwnershipFlags
	{
		// Token: 0x04000844 RID: 2116
		k_EAppOwnershipFlags_None = 0,
		// Token: 0x04000845 RID: 2117
		k_EAppOwnershipFlags_OwnsLicense = 1,
		// Token: 0x04000846 RID: 2118
		k_EAppOwnershipFlags_FreeLicense = 2,
		// Token: 0x04000847 RID: 2119
		k_EAppOwnershipFlags_RegionRestricted = 4,
		// Token: 0x04000848 RID: 2120
		k_EAppOwnershipFlags_LowViolence = 8,
		// Token: 0x04000849 RID: 2121
		k_EAppOwnershipFlags_InvalidPlatform = 16,
		// Token: 0x0400084A RID: 2122
		k_EAppOwnershipFlags_SharedLicense = 32,
		// Token: 0x0400084B RID: 2123
		k_EAppOwnershipFlags_FreeWeekend = 64,
		// Token: 0x0400084C RID: 2124
		k_EAppOwnershipFlags_RetailLicense = 128,
		// Token: 0x0400084D RID: 2125
		k_EAppOwnershipFlags_LicenseLocked = 256,
		// Token: 0x0400084E RID: 2126
		k_EAppOwnershipFlags_LicensePending = 512,
		// Token: 0x0400084F RID: 2127
		k_EAppOwnershipFlags_LicenseExpired = 1024,
		// Token: 0x04000850 RID: 2128
		k_EAppOwnershipFlags_LicensePermanent = 2048,
		// Token: 0x04000851 RID: 2129
		k_EAppOwnershipFlags_LicenseRecurring = 4096,
		// Token: 0x04000852 RID: 2130
		k_EAppOwnershipFlags_LicenseCanceled = 8192,
		// Token: 0x04000853 RID: 2131
		k_EAppOwnershipFlags_AutoGrant = 16384,
		// Token: 0x04000854 RID: 2132
		k_EAppOwnershipFlags_PendingGift = 32768,
		// Token: 0x04000855 RID: 2133
		k_EAppOwnershipFlags_RentalNotActivated = 65536,
		// Token: 0x04000856 RID: 2134
		k_EAppOwnershipFlags_Rental = 131072,
		// Token: 0x04000857 RID: 2135
		k_EAppOwnershipFlags_SiteLicense = 262144
	}
}
