using System;

namespace Steamworks
{
	// Token: 0x0200017C RID: 380
	public static class SteamGameServer
	{
		// Token: 0x06000761 RID: 1889 RVA: 0x0001248C File Offset: 0x0001088C
		public static bool InitGameServer(uint unIP, ushort usGamePort, ushort usQueryPort, uint unFlags, AppId_t nGameAppId, string pchVersionString)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersionString))
			{
				result = NativeMethods.ISteamGameServer_InitGameServer(CSteamGameServerAPIContext.GetSteamGameServer(), unIP, usGamePort, usQueryPort, unFlags, nGameAppId, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x000124DC File Offset: 0x000108DC
		public static void SetProduct(string pszProduct)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszProduct))
			{
				NativeMethods.ISteamGameServer_SetProduct(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00012524 File Offset: 0x00010924
		public static void SetGameDescription(string pszGameDescription)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszGameDescription))
			{
				NativeMethods.ISteamGameServer_SetGameDescription(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001256C File Offset: 0x0001096C
		public static void SetModDir(string pszModDir)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszModDir))
			{
				NativeMethods.ISteamGameServer_SetModDir(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x000125B4 File Offset: 0x000109B4
		public static void SetDedicatedServer(bool bDedicated)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetDedicatedServer(CSteamGameServerAPIContext.GetSteamGameServer(), bDedicated);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000125C8 File Offset: 0x000109C8
		public static void LogOn(string pszToken)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszToken))
			{
				NativeMethods.ISteamGameServer_LogOn(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00012610 File Offset: 0x00010A10
		public static void LogOnAnonymous()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_LogOnAnonymous(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00012621 File Offset: 0x00010A21
		public static void LogOff()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_LogOff(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00012632 File Offset: 0x00010A32
		public static bool BLoggedOn()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BLoggedOn(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00012643 File Offset: 0x00010A43
		public static bool BSecure()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BSecure(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00012654 File Offset: 0x00010A54
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (CSteamID)NativeMethods.ISteamGameServer_GetSteamID(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001266A File Offset: 0x00010A6A
		public static bool WasRestartRequested()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_WasRestartRequested(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0001267B File Offset: 0x00010A7B
		public static void SetMaxPlayerCount(int cPlayersMax)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetMaxPlayerCount(CSteamGameServerAPIContext.GetSteamGameServer(), cPlayersMax);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001268D File Offset: 0x00010A8D
		public static void SetBotPlayerCount(int cBotplayers)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetBotPlayerCount(CSteamGameServerAPIContext.GetSteamGameServer(), cBotplayers);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x000126A0 File Offset: 0x00010AA0
		public static void SetServerName(string pszServerName)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszServerName))
			{
				NativeMethods.ISteamGameServer_SetServerName(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x000126E8 File Offset: 0x00010AE8
		public static void SetMapName(string pszMapName)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszMapName))
			{
				NativeMethods.ISteamGameServer_SetMapName(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00012730 File Offset: 0x00010B30
		public static void SetPasswordProtected(bool bPasswordProtected)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetPasswordProtected(CSteamGameServerAPIContext.GetSteamGameServer(), bPasswordProtected);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00012742 File Offset: 0x00010B42
		public static void SetSpectatorPort(ushort unSpectatorPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetSpectatorPort(CSteamGameServerAPIContext.GetSteamGameServer(), unSpectatorPort);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00012754 File Offset: 0x00010B54
		public static void SetSpectatorServerName(string pszSpectatorServerName)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszSpectatorServerName))
			{
				NativeMethods.ISteamGameServer_SetSpectatorServerName(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001279C File Offset: 0x00010B9C
		public static void ClearAllKeyValues()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_ClearAllKeyValues(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000127B0 File Offset: 0x00010BB0
		public static void SetKeyValue(string pKey, string pValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pValue))
				{
					NativeMethods.ISteamGameServer_SetKeyValue(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle, utf8StringHandle2);
				}
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001281C File Offset: 0x00010C1C
		public static void SetGameTags(string pchGameTags)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchGameTags))
			{
				NativeMethods.ISteamGameServer_SetGameTags(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00012864 File Offset: 0x00010C64
		public static void SetGameData(string pchGameData)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchGameData))
			{
				NativeMethods.ISteamGameServer_SetGameData(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x000128AC File Offset: 0x00010CAC
		public static void SetRegion(string pszRegion)
		{
			InteropHelp.TestIfAvailableGameServer();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszRegion))
			{
				NativeMethods.ISteamGameServer_SetRegion(CSteamGameServerAPIContext.GetSteamGameServer(), utf8StringHandle);
			}
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x000128F4 File Offset: 0x00010CF4
		public static bool SendUserConnectAndAuthenticate(uint unIPClient, byte[] pvAuthBlob, uint cubAuthBlobSize, out CSteamID pSteamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_SendUserConnectAndAuthenticate(CSteamGameServerAPIContext.GetSteamGameServer(), unIPClient, pvAuthBlob, cubAuthBlobSize, out pSteamIDUser);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00012909 File Offset: 0x00010D09
		public static CSteamID CreateUnauthenticatedUserConnection()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (CSteamID)NativeMethods.ISteamGameServer_CreateUnauthenticatedUserConnection(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001291F File Offset: 0x00010D1F
		public static void SendUserDisconnect(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SendUserDisconnect(CSteamGameServerAPIContext.GetSteamGameServer(), steamIDUser);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00012934 File Offset: 0x00010D34
		public static bool BUpdateUserData(CSteamID steamIDUser, string pchPlayerName, uint uScore)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPlayerName))
			{
				result = NativeMethods.ISteamGameServer_BUpdateUserData(CSteamGameServerAPIContext.GetSteamGameServer(), steamIDUser, utf8StringHandle, uScore);
			}
			return result;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00012980 File Offset: 0x00010D80
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HAuthTicket)NativeMethods.ISteamGameServer_GetAuthSessionTicket(CSteamGameServerAPIContext.GetSteamGameServer(), pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00012999 File Offset: 0x00010D99
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BeginAuthSession(CSteamGameServerAPIContext.GetSteamGameServer(), pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x000129AD File Offset: 0x00010DAD
		public static void EndAuthSession(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_EndAuthSession(CSteamGameServerAPIContext.GetSteamGameServer(), steamID);
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x000129BF File Offset: 0x00010DBF
		public static void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_CancelAuthTicket(CSteamGameServerAPIContext.GetSteamGameServer(), hAuthTicket);
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x000129D1 File Offset: 0x00010DD1
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_UserHasLicenseForApp(CSteamGameServerAPIContext.GetSteamGameServer(), steamID, appID);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x000129E4 File Offset: 0x00010DE4
		public static bool RequestUserGroupStatus(CSteamID steamIDUser, CSteamID steamIDGroup)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_RequestUserGroupStatus(CSteamGameServerAPIContext.GetSteamGameServer(), steamIDUser, steamIDGroup);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x000129F7 File Offset: 0x00010DF7
		public static void GetGameplayStats()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_GetGameplayStats(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00012A08 File Offset: 0x00010E08
		public static SteamAPICall_t GetServerReputation()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_GetServerReputation(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00012A1E File Offset: 0x00010E1E
		public static uint GetPublicIP()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_GetPublicIP(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00012A2F File Offset: 0x00010E2F
		public static bool HandleIncomingPacket(byte[] pData, int cbData, uint srcIP, ushort srcPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_HandleIncomingPacket(CSteamGameServerAPIContext.GetSteamGameServer(), pData, cbData, srcIP, srcPort);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00012A44 File Offset: 0x00010E44
		public static int GetNextOutgoingPacket(byte[] pOut, int cbMaxOut, out uint pNetAdr, out ushort pPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_GetNextOutgoingPacket(CSteamGameServerAPIContext.GetSteamGameServer(), pOut, cbMaxOut, out pNetAdr, out pPort);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00012A59 File Offset: 0x00010E59
		public static void EnableHeartbeats(bool bActive)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_EnableHeartbeats(CSteamGameServerAPIContext.GetSteamGameServer(), bActive);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00012A6B File Offset: 0x00010E6B
		public static void SetHeartbeatInterval(int iHeartbeatInterval)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetHeartbeatInterval(CSteamGameServerAPIContext.GetSteamGameServer(), iHeartbeatInterval);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00012A7D File Offset: 0x00010E7D
		public static void ForceHeartbeat()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_ForceHeartbeat(CSteamGameServerAPIContext.GetSteamGameServer());
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00012A8E File Offset: 0x00010E8E
		public static SteamAPICall_t AssociateWithClan(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_AssociateWithClan(CSteamGameServerAPIContext.GetSteamGameServer(), steamIDClan);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00012AA5 File Offset: 0x00010EA5
		public static SteamAPICall_t ComputeNewPlayerCompatibility(CSteamID steamIDNewPlayer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_ComputeNewPlayerCompatibility(CSteamGameServerAPIContext.GetSteamGameServer(), steamIDNewPlayer);
		}
	}
}
