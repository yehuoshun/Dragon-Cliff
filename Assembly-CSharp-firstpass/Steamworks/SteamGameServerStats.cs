using System;

namespace Steamworks
{
	// Token: 0x02000182 RID: 386
	public static class SteamGameServerStats
	{
		// Token: 0x06000810 RID: 2064 RVA: 0x00013E3A File Offset: 0x0001223A
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServerStats_RequestUserStats(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00013E54 File Offset: 0x00012254
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_GetUserStat(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00013EA0 File Offset: 0x000122A0
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_GetUserStat0(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00013EEC File Offset: 0x000122EC
		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_GetUserAchievement(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, out pbAchieved);
			}
			return result;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00013F38 File Offset: 0x00012338
		public static bool SetUserStat(CSteamID steamIDUser, string pchName, int nData)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_SetUserStat(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, nData);
			}
			return result;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00013F84 File Offset: 0x00012384
		public static bool SetUserStat(CSteamID steamIDUser, string pchName, float fData)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_SetUserStat0(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, fData);
			}
			return result;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00013FD0 File Offset: 0x000123D0
		public static bool UpdateUserAvgRateStat(CSteamID steamIDUser, string pchName, float flCountThisSession, double dSessionLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_UpdateUserAvgRateStat(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle, flCountThisSession, dSessionLength);
			}
			return result;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0001401C File Offset: 0x0001241C
		public static bool SetUserAchievement(CSteamID steamIDUser, string pchName)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_SetUserAchievement(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00014068 File Offset: 0x00012468
		public static bool ClearUserAchievement(CSteamID steamIDUser, string pchName)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamGameServerStats_ClearUserAchievement(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x000140B4 File Offset: 0x000124B4
		public static SteamAPICall_t StoreUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServerStats_StoreUserStats(CSteamGameServerAPIContext.GetSteamGameServerStats(), steamIDUser);
		}
	}
}
