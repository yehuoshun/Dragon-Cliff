using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000195 RID: 405
	public static class SteamVideo
	{
		// Token: 0x06000A47 RID: 2631 RVA: 0x00019148 File Offset: 0x00017548
		public static void GetVideoURL(AppId_t unVideoAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamVideo_GetVideoURL(CSteamAPIContext.GetSteamVideo(), unVideoAppID);
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0001915A File Offset: 0x0001755A
		public static bool IsBroadcasting(out int pnNumViewers)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamVideo_IsBroadcasting(CSteamAPIContext.GetSteamVideo(), out pnNumViewers);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0001916C File Offset: 0x0001756C
		public static void GetOPFSettings(AppId_t unVideoAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamVideo_GetOPFSettings(CSteamAPIContext.GetSteamVideo(), unVideoAppID);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00019180 File Offset: 0x00017580
		public static bool GetOPFStringForApp(AppId_t unVideoAppID, out string pchBuffer, ref int pnBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(pnBufferSize);
			bool flag = NativeMethods.ISteamVideo_GetOPFStringForApp(CSteamAPIContext.GetSteamVideo(), unVideoAppID, intPtr, ref pnBufferSize);
			pchBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}
	}
}
