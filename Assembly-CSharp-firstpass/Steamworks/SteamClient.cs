using System;

namespace Steamworks
{
	// Token: 0x02000179 RID: 377
	public static class SteamClient
	{
		// Token: 0x060006E0 RID: 1760 RVA: 0x000111D8 File Offset: 0x0000F5D8
		public static HSteamPipe CreateSteamPipe()
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamPipe)NativeMethods.ISteamClient_CreateSteamPipe(CSteamAPIContext.GetSteamClient());
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x000111EE File Offset: 0x0000F5EE
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BReleaseSteamPipe(CSteamAPIContext.GetSteamClient(), hSteamPipe);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00011200 File Offset: 0x0000F600
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_ConnectToGlobalUser(CSteamAPIContext.GetSteamClient(), hSteamPipe);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00011217 File Offset: 0x0000F617
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType)
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_CreateLocalUser(CSteamAPIContext.GetSteamClient(), out phSteamPipe, eAccountType);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0001122F File Offset: 0x0000F62F
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_ReleaseUser(CSteamAPIContext.GetSteamClient(), hSteamPipe, hUser);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00011244 File Offset: 0x0000F644
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUser(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00011290 File Offset: 0x0000F690
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGameServer(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000112DC File Offset: 0x0000F6DC
		public static void SetLocalIPBinding(uint unIP, ushort usPort)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetLocalIPBinding(CSteamAPIContext.GetSteamClient(), unIP, usPort);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x000112F0 File Offset: 0x0000F6F0
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamFriends(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001133C File Offset: 0x0000F73C
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUtils(CSteamAPIContext.GetSteamClient(), hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00011388 File Offset: 0x0000F788
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMatchmaking(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x000113D4 File Offset: 0x0000F7D4
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMatchmakingServers(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00011420 File Offset: 0x0000F820
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGenericInterface(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001146C File Offset: 0x0000F86C
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUserStats(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000114B8 File Offset: 0x0000F8B8
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGameServerStats(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00011504 File Offset: 0x0000F904
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamApps(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00011550 File Offset: 0x0000F950
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamNetworking(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001159C File Offset: 0x0000F99C
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamRemoteStorage(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000115E8 File Offset: 0x0000F9E8
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamScreenshots(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00011634 File Offset: 0x0000FA34
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetIPCCallCount(CSteamAPIContext.GetSteamClient());
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00011645 File Offset: 0x0000FA45
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetWarningMessageHook(CSteamAPIContext.GetSteamClient(), pFunction);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00011657 File Offset: 0x0000FA57
		public static bool BShutdownIfAllPipesClosed()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BShutdownIfAllPipesClosed(CSteamAPIContext.GetSteamClient());
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00011668 File Offset: 0x0000FA68
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamHTTP(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000116B4 File Offset: 0x0000FAB4
		public static IntPtr GetISteamUnifiedMessages(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUnifiedMessages(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00011700 File Offset: 0x0000FB00
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamController(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001174C File Offset: 0x0000FB4C
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUGC(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00011798 File Offset: 0x0000FB98
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamAppList(CSteamAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x000117E4 File Offset: 0x0000FBE4
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMusic(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00011830 File Offset: 0x0000FC30
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMusicRemote(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001187C File Offset: 0x0000FC7C
		public static IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamHTMLSurface(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000118C8 File Offset: 0x0000FCC8
		public static IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamInventory(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00011914 File Offset: 0x0000FD14
		public static IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamVideo(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00011960 File Offset: 0x0000FD60
		public static IntPtr GetISteamParentalSettings(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamParentalSettings(CSteamAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}
	}
}
