using System;

namespace Steamworks
{
	// Token: 0x0200018D RID: 397
	public static class SteamParentalSettings
	{
		// Token: 0x0600094D RID: 2381 RVA: 0x000168BA File Offset: 0x00014CBA
		public static bool BIsParentalLockEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsParentalLockEnabled(CSteamAPIContext.GetSteamParentalSettings());
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000168CB File Offset: 0x00014CCB
		public static bool BIsParentalLockLocked()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsParentalLockLocked(CSteamAPIContext.GetSteamParentalSettings());
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000168DC File Offset: 0x00014CDC
		public static bool BIsAppBlocked(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsAppBlocked(CSteamAPIContext.GetSteamParentalSettings(), nAppID);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000168EE File Offset: 0x00014CEE
		public static bool BIsAppInBlockList(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsAppInBlockList(CSteamAPIContext.GetSteamParentalSettings(), nAppID);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00016900 File Offset: 0x00014D00
		public static bool BIsFeatureBlocked(EParentalFeature eFeature)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsFeatureBlocked(CSteamAPIContext.GetSteamParentalSettings(), eFeature);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00016912 File Offset: 0x00014D12
		public static bool BIsFeatureInBlockList(EParentalFeature eFeature)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsFeatureInBlockList(CSteamAPIContext.GetSteamParentalSettings(), eFeature);
		}
	}
}
