using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200017D RID: 381
	public static class SteamGameServerApps
	{
		// Token: 0x0600078D RID: 1933 RVA: 0x00012ABC File Offset: 0x00010EBC
		public static bool BIsSubscribed()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsSubscribed(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00012ACD File Offset: 0x00010ECD
		public static bool BIsLowViolence()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsLowViolence(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00012ADE File Offset: 0x00010EDE
		public static bool BIsCybercafe()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsCybercafe(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00012AEF File Offset: 0x00010EEF
		public static bool BIsVACBanned()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsVACBanned(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00012B00 File Offset: 0x00010F00
		public static string GetCurrentGameLanguage()
		{
			InteropHelp.TestIfAvailableGameServer();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetCurrentGameLanguage(CSteamGameServerAPIContext.GetSteamApps()));
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00012B16 File Offset: 0x00010F16
		public static string GetAvailableGameLanguages()
		{
			InteropHelp.TestIfAvailableGameServer();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetAvailableGameLanguages(CSteamGameServerAPIContext.GetSteamApps()));
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00012B2C File Offset: 0x00010F2C
		public static bool BIsSubscribedApp(AppId_t appID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsSubscribedApp(CSteamGameServerAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00012B3E File Offset: 0x00010F3E
		public static bool BIsDlcInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsDlcInstalled(CSteamGameServerAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00012B50 File Offset: 0x00010F50
		public static uint GetEarliestPurchaseUnixTime(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_GetEarliestPurchaseUnixTime(CSteamGameServerAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00012B62 File Offset: 0x00010F62
		public static bool BIsSubscribedFromFreeWeekend()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsSubscribedFromFreeWeekend(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00012B73 File Offset: 0x00010F73
		public static int GetDLCCount()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_GetDLCCount(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00012B84 File Offset: 0x00010F84
		public static bool BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_BGetDLCDataByIndex(CSteamGameServerAPIContext.GetSteamApps(), iDLC, out pAppID, out pbAvailable, intPtr, cchNameBufferSize);
			pchName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00012BCA File Offset: 0x00010FCA
		public static void InstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamApps_InstallDLC(CSteamGameServerAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00012BDC File Offset: 0x00010FDC
		public static void UninstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamApps_UninstallDLC(CSteamGameServerAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00012BEE File Offset: 0x00010FEE
		public static void RequestAppProofOfPurchaseKey(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamApps_RequestAppProofOfPurchaseKey(CSteamGameServerAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00012C00 File Offset: 0x00011000
		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_GetCurrentBetaName(CSteamGameServerAPIContext.GetSteamApps(), intPtr, cchNameBufferSize);
			pchName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00012C41 File Offset: 0x00011041
		public static bool MarkContentCorrupt(bool bMissingFilesOnly)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_MarkContentCorrupt(CSteamGameServerAPIContext.GetSteamApps(), bMissingFilesOnly);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00012C53 File Offset: 0x00011053
		public static uint GetInstalledDepots(AppId_t appID, DepotId_t[] pvecDepots, uint cMaxDepots)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_GetInstalledDepots(CSteamGameServerAPIContext.GetSteamApps(), appID, pvecDepots, cMaxDepots);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00012C68 File Offset: 0x00011068
		public static uint GetAppInstallDir(AppId_t appID, out string pchFolder, uint cchFolderBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderBufferSize);
			uint num = NativeMethods.ISteamApps_GetAppInstallDir(CSteamGameServerAPIContext.GetSteamApps(), appID, intPtr, cchFolderBufferSize);
			pchFolder = ((num == 0u) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00012CAA File Offset: 0x000110AA
		public static bool BIsAppInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_BIsAppInstalled(CSteamGameServerAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00012CBC File Offset: 0x000110BC
		public static CSteamID GetAppOwner()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (CSteamID)NativeMethods.ISteamApps_GetAppOwner(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00012CD4 File Offset: 0x000110D4
		public static string GetLaunchQueryParam(string pchKey)
		{
			InteropHelp.TestIfAvailableGameServer();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetLaunchQueryParam(CSteamGameServerAPIContext.GetSteamApps(), utf8StringHandle));
			}
			return result;
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00012D24 File Offset: 0x00011124
		public static bool GetDlcDownloadProgress(AppId_t nAppID, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_GetDlcDownloadProgress(CSteamGameServerAPIContext.GetSteamApps(), nAppID, out punBytesDownloaded, out punBytesTotal);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00012D38 File Offset: 0x00011138
		public static int GetAppBuildId()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamApps_GetAppBuildId(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00012D49 File Offset: 0x00011149
		public static void RequestAllProofOfPurchaseKeys()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamApps_RequestAllProofOfPurchaseKeys(CSteamGameServerAPIContext.GetSteamApps());
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00012D5C File Offset: 0x0001115C
		public static SteamAPICall_t GetFileDetails(string pszFileName)
		{
			InteropHelp.TestIfAvailableGameServer();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszFileName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamApps_GetFileDetails(CSteamGameServerAPIContext.GetSteamApps(), utf8StringHandle);
			}
			return result;
		}
	}
}
