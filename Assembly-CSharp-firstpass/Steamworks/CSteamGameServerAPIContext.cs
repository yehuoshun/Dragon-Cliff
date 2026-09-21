using System;

namespace Steamworks
{
	// Token: 0x02000065 RID: 101
	internal static class CSteamGameServerAPIContext
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x00010BBC File Offset: 0x0000EFBC
		internal static void Clear()
		{
			CSteamGameServerAPIContext.m_pSteamClient = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamGameServer = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamUtils = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamNetworking = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamGameServerStats = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamHTTP = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamInventory = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamUGC = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamApps = IntPtr.Zero;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00010C24 File Offset: 0x0000F024
		internal static bool Init()
		{
			HSteamUser hsteamUser = GameServer.GetHSteamUser();
			HSteamPipe hsteamPipe = GameServer.GetHSteamPipe();
			if (hsteamPipe == (HSteamPipe)0)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle("SteamClient017"))
			{
				CSteamGameServerAPIContext.m_pSteamClient = NativeMethods.SteamInternal_CreateInterface(utf8StringHandle);
			}
			if (CSteamGameServerAPIContext.m_pSteamClient == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamGameServer = SteamGameServerClient.GetISteamGameServer(hsteamUser, hsteamPipe, "SteamGameServer012");
			if (CSteamGameServerAPIContext.m_pSteamGameServer == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamUtils = SteamGameServerClient.GetISteamUtils(hsteamPipe, "SteamUtils009");
			if (CSteamGameServerAPIContext.m_pSteamUtils == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamNetworking = SteamGameServerClient.GetISteamNetworking(hsteamUser, hsteamPipe, "SteamNetworking005");
			if (CSteamGameServerAPIContext.m_pSteamNetworking == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamGameServerStats = SteamGameServerClient.GetISteamGameServerStats(hsteamUser, hsteamPipe, "SteamGameServerStats001");
			if (CSteamGameServerAPIContext.m_pSteamGameServerStats == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamHTTP = SteamGameServerClient.GetISteamHTTP(hsteamUser, hsteamPipe, "STEAMHTTP_INTERFACE_VERSION002");
			if (CSteamGameServerAPIContext.m_pSteamHTTP == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamInventory = SteamGameServerClient.GetISteamInventory(hsteamUser, hsteamPipe, "STEAMINVENTORY_INTERFACE_V002");
			if (CSteamGameServerAPIContext.m_pSteamInventory == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamUGC = SteamGameServerClient.GetISteamUGC(hsteamUser, hsteamPipe, "STEAMUGC_INTERFACE_VERSION010");
			if (CSteamGameServerAPIContext.m_pSteamUGC == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamApps = SteamGameServerClient.GetISteamApps(hsteamUser, hsteamPipe, "STEAMAPPS_INTERFACE_VERSION008");
			return !(CSteamGameServerAPIContext.m_pSteamApps == IntPtr.Zero);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00010DD8 File Offset: 0x0000F1D8
		internal static IntPtr GetSteamClient()
		{
			return CSteamGameServerAPIContext.m_pSteamClient;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00010DDF File Offset: 0x0000F1DF
		internal static IntPtr GetSteamGameServer()
		{
			return CSteamGameServerAPIContext.m_pSteamGameServer;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00010DE6 File Offset: 0x0000F1E6
		internal static IntPtr GetSteamUtils()
		{
			return CSteamGameServerAPIContext.m_pSteamUtils;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00010DED File Offset: 0x0000F1ED
		internal static IntPtr GetSteamNetworking()
		{
			return CSteamGameServerAPIContext.m_pSteamNetworking;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00010DF4 File Offset: 0x0000F1F4
		internal static IntPtr GetSteamGameServerStats()
		{
			return CSteamGameServerAPIContext.m_pSteamGameServerStats;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00010DFB File Offset: 0x0000F1FB
		internal static IntPtr GetSteamHTTP()
		{
			return CSteamGameServerAPIContext.m_pSteamHTTP;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00010E02 File Offset: 0x0000F202
		internal static IntPtr GetSteamInventory()
		{
			return CSteamGameServerAPIContext.m_pSteamInventory;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00010E09 File Offset: 0x0000F209
		internal static IntPtr GetSteamUGC()
		{
			return CSteamGameServerAPIContext.m_pSteamUGC;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00010E10 File Offset: 0x0000F210
		internal static IntPtr GetSteamApps()
		{
			return CSteamGameServerAPIContext.m_pSteamApps;
		}

		// Token: 0x040001E2 RID: 482
		private static IntPtr m_pSteamClient;

		// Token: 0x040001E3 RID: 483
		private static IntPtr m_pSteamGameServer;

		// Token: 0x040001E4 RID: 484
		private static IntPtr m_pSteamUtils;

		// Token: 0x040001E5 RID: 485
		private static IntPtr m_pSteamNetworking;

		// Token: 0x040001E6 RID: 486
		private static IntPtr m_pSteamGameServerStats;

		// Token: 0x040001E7 RID: 487
		private static IntPtr m_pSteamHTTP;

		// Token: 0x040001E8 RID: 488
		private static IntPtr m_pSteamInventory;

		// Token: 0x040001E9 RID: 489
		private static IntPtr m_pSteamUGC;

		// Token: 0x040001EA RID: 490
		private static IntPtr m_pSteamApps;
	}
}
