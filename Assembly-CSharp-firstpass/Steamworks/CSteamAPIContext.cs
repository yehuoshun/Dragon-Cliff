using System;

namespace Steamworks
{
	// Token: 0x02000064 RID: 100
	internal static class CSteamAPIContext
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x0001067C File Offset: 0x0000EA7C
		internal static void Clear()
		{
			CSteamAPIContext.m_pSteamClient = IntPtr.Zero;
			CSteamAPIContext.m_pSteamUser = IntPtr.Zero;
			CSteamAPIContext.m_pSteamFriends = IntPtr.Zero;
			CSteamAPIContext.m_pSteamUtils = IntPtr.Zero;
			CSteamAPIContext.m_pSteamMatchmaking = IntPtr.Zero;
			CSteamAPIContext.m_pSteamUserStats = IntPtr.Zero;
			CSteamAPIContext.m_pSteamApps = IntPtr.Zero;
			CSteamAPIContext.m_pSteamMatchmakingServers = IntPtr.Zero;
			CSteamAPIContext.m_pSteamNetworking = IntPtr.Zero;
			CSteamAPIContext.m_pSteamRemoteStorage = IntPtr.Zero;
			CSteamAPIContext.m_pSteamHTTP = IntPtr.Zero;
			CSteamAPIContext.m_pSteamScreenshots = IntPtr.Zero;
			CSteamAPIContext.m_pSteamMusic = IntPtr.Zero;
			CSteamAPIContext.m_pSteamUnifiedMessages = IntPtr.Zero;
			CSteamAPIContext.m_pController = IntPtr.Zero;
			CSteamAPIContext.m_pSteamUGC = IntPtr.Zero;
			CSteamAPIContext.m_pSteamAppList = IntPtr.Zero;
			CSteamAPIContext.m_pSteamMusic = IntPtr.Zero;
			CSteamAPIContext.m_pSteamMusicRemote = IntPtr.Zero;
			CSteamAPIContext.m_pSteamHTMLSurface = IntPtr.Zero;
			CSteamAPIContext.m_pSteamInventory = IntPtr.Zero;
			CSteamAPIContext.m_pSteamVideo = IntPtr.Zero;
			CSteamAPIContext.m_pSteamParentalSettings = IntPtr.Zero;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00010770 File Offset: 0x0000EB70
		internal static bool Init()
		{
			HSteamUser hsteamUser = SteamAPI.GetHSteamUser();
			HSteamPipe hsteamPipe = SteamAPI.GetHSteamPipe();
			if (hsteamPipe == (HSteamPipe)0)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle("SteamClient017"))
			{
				CSteamAPIContext.m_pSteamClient = NativeMethods.SteamInternal_CreateInterface(utf8StringHandle);
			}
			if (CSteamAPIContext.m_pSteamClient == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamUser = SteamClient.GetISteamUser(hsteamUser, hsteamPipe, "SteamUser019");
			if (CSteamAPIContext.m_pSteamUser == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamFriends = SteamClient.GetISteamFriends(hsteamUser, hsteamPipe, "SteamFriends015");
			if (CSteamAPIContext.m_pSteamFriends == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamUtils = SteamClient.GetISteamUtils(hsteamPipe, "SteamUtils009");
			if (CSteamAPIContext.m_pSteamUtils == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamMatchmaking = SteamClient.GetISteamMatchmaking(hsteamUser, hsteamPipe, "SteamMatchMaking009");
			if (CSteamAPIContext.m_pSteamMatchmaking == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamMatchmakingServers = SteamClient.GetISteamMatchmakingServers(hsteamUser, hsteamPipe, "SteamMatchMakingServers002");
			if (CSteamAPIContext.m_pSteamMatchmakingServers == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamUserStats = SteamClient.GetISteamUserStats(hsteamUser, hsteamPipe, "STEAMUSERSTATS_INTERFACE_VERSION011");
			if (CSteamAPIContext.m_pSteamUserStats == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamApps = SteamClient.GetISteamApps(hsteamUser, hsteamPipe, "STEAMAPPS_INTERFACE_VERSION008");
			if (CSteamAPIContext.m_pSteamApps == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamNetworking = SteamClient.GetISteamNetworking(hsteamUser, hsteamPipe, "SteamNetworking005");
			if (CSteamAPIContext.m_pSteamNetworking == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamRemoteStorage = SteamClient.GetISteamRemoteStorage(hsteamUser, hsteamPipe, "STEAMREMOTESTORAGE_INTERFACE_VERSION014");
			if (CSteamAPIContext.m_pSteamRemoteStorage == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamScreenshots = SteamClient.GetISteamScreenshots(hsteamUser, hsteamPipe, "STEAMSCREENSHOTS_INTERFACE_VERSION003");
			if (CSteamAPIContext.m_pSteamScreenshots == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamHTTP = SteamClient.GetISteamHTTP(hsteamUser, hsteamPipe, "STEAMHTTP_INTERFACE_VERSION002");
			if (CSteamAPIContext.m_pSteamHTTP == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamUnifiedMessages = SteamClient.GetISteamUnifiedMessages(hsteamUser, hsteamPipe, "STEAMUNIFIEDMESSAGES_INTERFACE_VERSION001");
			if (CSteamAPIContext.m_pSteamUnifiedMessages == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pController = SteamClient.GetISteamController(hsteamUser, hsteamPipe, "SteamController005");
			if (CSteamAPIContext.m_pController == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamUGC = SteamClient.GetISteamUGC(hsteamUser, hsteamPipe, "STEAMUGC_INTERFACE_VERSION010");
			if (CSteamAPIContext.m_pSteamUGC == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamAppList = SteamClient.GetISteamAppList(hsteamUser, hsteamPipe, "STEAMAPPLIST_INTERFACE_VERSION001");
			if (CSteamAPIContext.m_pSteamAppList == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamMusic = SteamClient.GetISteamMusic(hsteamUser, hsteamPipe, "STEAMMUSIC_INTERFACE_VERSION001");
			if (CSteamAPIContext.m_pSteamMusic == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamMusicRemote = SteamClient.GetISteamMusicRemote(hsteamUser, hsteamPipe, "STEAMMUSICREMOTE_INTERFACE_VERSION001");
			if (CSteamAPIContext.m_pSteamMusicRemote == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamHTMLSurface = SteamClient.GetISteamHTMLSurface(hsteamUser, hsteamPipe, "STEAMHTMLSURFACE_INTERFACE_VERSION_004");
			if (CSteamAPIContext.m_pSteamHTMLSurface == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamInventory = SteamClient.GetISteamInventory(hsteamUser, hsteamPipe, "STEAMINVENTORY_INTERFACE_V002");
			if (CSteamAPIContext.m_pSteamInventory == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamVideo = SteamClient.GetISteamVideo(hsteamUser, hsteamPipe, "STEAMVIDEO_INTERFACE_V002");
			if (CSteamAPIContext.m_pSteamVideo == IntPtr.Zero)
			{
				return false;
			}
			CSteamAPIContext.m_pSteamParentalSettings = SteamClient.GetISteamParentalSettings(hsteamUser, hsteamPipe, "STEAMPARENTALSETTINGS_INTERFACE_VERSION001");
			return !(CSteamAPIContext.m_pSteamParentalSettings == IntPtr.Zero);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00010B20 File Offset: 0x0000EF20
		internal static IntPtr GetSteamClient()
		{
			return CSteamAPIContext.m_pSteamClient;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00010B27 File Offset: 0x0000EF27
		internal static IntPtr GetSteamUser()
		{
			return CSteamAPIContext.m_pSteamUser;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00010B2E File Offset: 0x0000EF2E
		internal static IntPtr GetSteamFriends()
		{
			return CSteamAPIContext.m_pSteamFriends;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00010B35 File Offset: 0x0000EF35
		internal static IntPtr GetSteamUtils()
		{
			return CSteamAPIContext.m_pSteamUtils;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00010B3C File Offset: 0x0000EF3C
		internal static IntPtr GetSteamMatchmaking()
		{
			return CSteamAPIContext.m_pSteamMatchmaking;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00010B43 File Offset: 0x0000EF43
		internal static IntPtr GetSteamUserStats()
		{
			return CSteamAPIContext.m_pSteamUserStats;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00010B4A File Offset: 0x0000EF4A
		internal static IntPtr GetSteamApps()
		{
			return CSteamAPIContext.m_pSteamApps;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00010B51 File Offset: 0x0000EF51
		internal static IntPtr GetSteamMatchmakingServers()
		{
			return CSteamAPIContext.m_pSteamMatchmakingServers;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00010B58 File Offset: 0x0000EF58
		internal static IntPtr GetSteamNetworking()
		{
			return CSteamAPIContext.m_pSteamNetworking;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00010B5F File Offset: 0x0000EF5F
		internal static IntPtr GetSteamRemoteStorage()
		{
			return CSteamAPIContext.m_pSteamRemoteStorage;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00010B66 File Offset: 0x0000EF66
		internal static IntPtr GetSteamScreenshots()
		{
			return CSteamAPIContext.m_pSteamScreenshots;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00010B6D File Offset: 0x0000EF6D
		internal static IntPtr GetSteamHTTP()
		{
			return CSteamAPIContext.m_pSteamHTTP;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00010B74 File Offset: 0x0000EF74
		internal static IntPtr GetSteamUnifiedMessages()
		{
			return CSteamAPIContext.m_pSteamUnifiedMessages;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00010B7B File Offset: 0x0000EF7B
		internal static IntPtr GetSteamController()
		{
			return CSteamAPIContext.m_pController;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00010B82 File Offset: 0x0000EF82
		internal static IntPtr GetSteamUGC()
		{
			return CSteamAPIContext.m_pSteamUGC;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00010B89 File Offset: 0x0000EF89
		internal static IntPtr GetSteamAppList()
		{
			return CSteamAPIContext.m_pSteamAppList;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00010B90 File Offset: 0x0000EF90
		internal static IntPtr GetSteamMusic()
		{
			return CSteamAPIContext.m_pSteamMusic;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00010B97 File Offset: 0x0000EF97
		internal static IntPtr GetSteamMusicRemote()
		{
			return CSteamAPIContext.m_pSteamMusicRemote;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00010B9E File Offset: 0x0000EF9E
		internal static IntPtr GetSteamHTMLSurface()
		{
			return CSteamAPIContext.m_pSteamHTMLSurface;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00010BA5 File Offset: 0x0000EFA5
		internal static IntPtr GetSteamInventory()
		{
			return CSteamAPIContext.m_pSteamInventory;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00010BAC File Offset: 0x0000EFAC
		internal static IntPtr GetSteamVideo()
		{
			return CSteamAPIContext.m_pSteamVideo;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00010BB3 File Offset: 0x0000EFB3
		internal static IntPtr GetSteamParentalSettings()
		{
			return CSteamAPIContext.m_pSteamParentalSettings;
		}

		// Token: 0x040001CC RID: 460
		private static IntPtr m_pSteamClient;

		// Token: 0x040001CD RID: 461
		private static IntPtr m_pSteamUser;

		// Token: 0x040001CE RID: 462
		private static IntPtr m_pSteamFriends;

		// Token: 0x040001CF RID: 463
		private static IntPtr m_pSteamUtils;

		// Token: 0x040001D0 RID: 464
		private static IntPtr m_pSteamMatchmaking;

		// Token: 0x040001D1 RID: 465
		private static IntPtr m_pSteamUserStats;

		// Token: 0x040001D2 RID: 466
		private static IntPtr m_pSteamApps;

		// Token: 0x040001D3 RID: 467
		private static IntPtr m_pSteamMatchmakingServers;

		// Token: 0x040001D4 RID: 468
		private static IntPtr m_pSteamNetworking;

		// Token: 0x040001D5 RID: 469
		private static IntPtr m_pSteamRemoteStorage;

		// Token: 0x040001D6 RID: 470
		private static IntPtr m_pSteamScreenshots;

		// Token: 0x040001D7 RID: 471
		private static IntPtr m_pSteamHTTP;

		// Token: 0x040001D8 RID: 472
		private static IntPtr m_pSteamUnifiedMessages;

		// Token: 0x040001D9 RID: 473
		private static IntPtr m_pController;

		// Token: 0x040001DA RID: 474
		private static IntPtr m_pSteamUGC;

		// Token: 0x040001DB RID: 475
		private static IntPtr m_pSteamAppList;

		// Token: 0x040001DC RID: 476
		private static IntPtr m_pSteamMusic;

		// Token: 0x040001DD RID: 477
		private static IntPtr m_pSteamMusicRemote;

		// Token: 0x040001DE RID: 478
		private static IntPtr m_pSteamHTMLSurface;

		// Token: 0x040001DF RID: 479
		private static IntPtr m_pSteamInventory;

		// Token: 0x040001E0 RID: 480
		private static IntPtr m_pSteamVideo;

		// Token: 0x040001E1 RID: 481
		private static IntPtr m_pSteamParentalSettings;
	}
}
