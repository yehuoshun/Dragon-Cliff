using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000177 RID: 375
	public static class SteamAppList
	{
		// Token: 0x060006C1 RID: 1729 RVA: 0x00010E27 File Offset: 0x0000F227
		public static uint GetNumInstalledApps()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetNumInstalledApps(CSteamAPIContext.GetSteamAppList());
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00010E38 File Offset: 0x0000F238
		public static uint GetInstalledApps(AppId_t[] pvecAppID, uint unMaxAppIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetInstalledApps(CSteamAPIContext.GetSteamAppList(), pvecAppID, unMaxAppIDs);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00010E4C File Offset: 0x0000F24C
		public static int GetAppName(AppId_t nAppID, out string pchName, int cchNameMax)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameMax);
			int num = NativeMethods.ISteamAppList_GetAppName(CSteamAPIContext.GetSteamAppList(), nAppID, intPtr, cchNameMax);
			pchName = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00010E90 File Offset: 0x0000F290
		public static int GetAppInstallDir(AppId_t nAppID, out string pchDirectory, int cchNameMax)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameMax);
			int num = NativeMethods.ISteamAppList_GetAppInstallDir(CSteamAPIContext.GetSteamAppList(), nAppID, intPtr, cchNameMax);
			pchDirectory = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00010ED3 File Offset: 0x0000F2D3
		public static int GetAppBuildId(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetAppBuildId(CSteamAPIContext.GetSteamAppList(), nAppID);
		}
	}
}
