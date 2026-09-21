using System;

namespace Steamworks
{
	// Token: 0x0200017E RID: 382
	public static class SteamGameServerClient
	{
		// Token: 0x060007A7 RID: 1959 RVA: 0x00012DAC File Offset: 0x000111AC
		public static HSteamPipe CreateSteamPipe()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HSteamPipe)NativeMethods.ISteamClient_CreateSteamPipe(CSteamGameServerAPIContext.GetSteamClient());
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00012DC2 File Offset: 0x000111C2
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamClient_BReleaseSteamPipe(CSteamGameServerAPIContext.GetSteamClient(), hSteamPipe);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00012DD4 File Offset: 0x000111D4
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HSteamUser)NativeMethods.ISteamClient_ConnectToGlobalUser(CSteamGameServerAPIContext.GetSteamClient(), hSteamPipe);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00012DEB File Offset: 0x000111EB
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HSteamUser)NativeMethods.ISteamClient_CreateLocalUser(CSteamGameServerAPIContext.GetSteamClient(), out phSteamPipe, eAccountType);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00012E03 File Offset: 0x00011203
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamClient_ReleaseUser(CSteamGameServerAPIContext.GetSteamClient(), hSteamPipe, hUser);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00012E18 File Offset: 0x00011218
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUser(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00012E64 File Offset: 0x00011264
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGameServer(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00012EB0 File Offset: 0x000112B0
		public static void SetLocalIPBinding(uint unIP, ushort usPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamClient_SetLocalIPBinding(CSteamGameServerAPIContext.GetSteamClient(), unIP, usPort);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00012EC4 File Offset: 0x000112C4
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamFriends(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00012F10 File Offset: 0x00011310
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUtils(CSteamGameServerAPIContext.GetSteamClient(), hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00012F5C File Offset: 0x0001135C
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMatchmaking(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00012FA8 File Offset: 0x000113A8
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMatchmakingServers(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00012FF4 File Offset: 0x000113F4
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGenericInterface(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00013040 File Offset: 0x00011440
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUserStats(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001308C File Offset: 0x0001148C
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamGameServerStats(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000130D8 File Offset: 0x000114D8
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamApps(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00013124 File Offset: 0x00011524
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamNetworking(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00013170 File Offset: 0x00011570
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamRemoteStorage(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000131BC File Offset: 0x000115BC
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamScreenshots(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00013208 File Offset: 0x00011608
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamClient_GetIPCCallCount(CSteamGameServerAPIContext.GetSteamClient());
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00013219 File Offset: 0x00011619
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamClient_SetWarningMessageHook(CSteamGameServerAPIContext.GetSteamClient(), pFunction);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0001322B File Offset: 0x0001162B
		public static bool BShutdownIfAllPipesClosed()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamClient_BShutdownIfAllPipesClosed(CSteamGameServerAPIContext.GetSteamClient());
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001323C File Offset: 0x0001163C
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamHTTP(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00013288 File Offset: 0x00011688
		public static IntPtr GetISteamUnifiedMessages(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUnifiedMessages(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000132D4 File Offset: 0x000116D4
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamController(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00013320 File Offset: 0x00011720
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamUGC(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0001336C File Offset: 0x0001176C
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamAppList(CSteamGameServerAPIContext.GetSteamClient(), hSteamUser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x000133B8 File Offset: 0x000117B8
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMusic(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00013404 File Offset: 0x00011804
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamMusicRemote(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00013450 File Offset: 0x00011850
		public static IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamHTMLSurface(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0001349C File Offset: 0x0001189C
		public static IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamInventory(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000134E8 File Offset: 0x000118E8
		public static IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamVideo(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00013534 File Offset: 0x00011934
		public static IntPtr GetISteamParentalSettings(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersion))
			{
				result = NativeMethods.ISteamClient_GetISteamParentalSettings(CSteamGameServerAPIContext.GetSteamClient(), hSteamuser, hSteamPipe, utf8StringHandle);
			}
			return result;
		}
	}
}
