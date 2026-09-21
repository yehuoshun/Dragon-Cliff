using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000193 RID: 403
	public static class SteamUserStats
	{
		// Token: 0x060009FF RID: 2559 RVA: 0x00018558 File Offset: 0x00016958
		public static bool RequestCurrentStats()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_RequestCurrentStats(CSteamAPIContext.GetSteamUserStats());
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0001856C File Offset: 0x0001696C
		public static bool GetStat(string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetStat(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000185B8 File Offset: 0x000169B8
		public static bool GetStat(string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetStat0(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00018604 File Offset: 0x00016A04
		public static bool SetStat(string pchName, int nData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_SetStat(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, nData);
			}
			return result;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00018650 File Offset: 0x00016A50
		public static bool SetStat(string pchName, float fData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_SetStat0(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, fData);
			}
			return result;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0001869C File Offset: 0x00016A9C
		public static bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_UpdateAvgRateStat(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, flCountThisSession, dSessionLength);
			}
			return result;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000186E8 File Offset: 0x00016AE8
		public static bool GetAchievement(string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetAchievement(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pbAchieved);
			}
			return result;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00018734 File Offset: 0x00016B34
		public static bool SetAchievement(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_SetAchievement(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0001877C File Offset: 0x00016B7C
		public static bool ClearAchievement(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_ClearAchievement(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000187C4 File Offset: 0x00016BC4
		public static bool GetAchievementAndUnlockTime(string pchName, out bool pbAchieved, out uint punUnlockTime)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetAchievementAndUnlockTime(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pbAchieved, out punUnlockTime);
			}
			return result;
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00018810 File Offset: 0x00016C10
		public static bool StoreStats()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_StoreStats(CSteamAPIContext.GetSteamUserStats());
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00018824 File Offset: 0x00016C24
		public static int GetAchievementIcon(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			int result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetAchievementIcon(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0001886C File Offset: 0x00016C6C
		public static string GetAchievementDisplayAttribute(string pchName, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchKey))
				{
					result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementDisplayAttribute(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, utf8StringHandle2));
				}
			}
			return result;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000188DC File Offset: 0x00016CDC
		public static bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_IndicateAchievementProgress(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, nCurProgress, nMaxProgress);
			}
			return result;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00018928 File Offset: 0x00016D28
		public static uint GetNumAchievements()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetNumAchievements(CSteamAPIContext.GetSteamUserStats());
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00018939 File Offset: 0x00016D39
		public static string GetAchievementName(uint iAchievement)
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementName(CSteamAPIContext.GetSteamUserStats(), iAchievement));
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00018950 File Offset: 0x00016D50
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestUserStats(CSteamAPIContext.GetSteamUserStats(), steamIDUser);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00018968 File Offset: 0x00016D68
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetUserStat(CSteamAPIContext.GetSteamUserStats(), steamIDUser, utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x000189B4 File Offset: 0x00016DB4
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetUserStat0(CSteamAPIContext.GetSteamUserStats(), steamIDUser, utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00018A00 File Offset: 0x00016E00
		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetUserAchievement(CSteamAPIContext.GetSteamUserStats(), steamIDUser, utf8StringHandle, out pbAchieved);
			}
			return result;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00018A4C File Offset: 0x00016E4C
		public static bool GetUserAchievementAndUnlockTime(CSteamID steamIDUser, string pchName, out bool pbAchieved, out uint punUnlockTime)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetUserAchievementAndUnlockTime(CSteamAPIContext.GetSteamUserStats(), steamIDUser, utf8StringHandle, out pbAchieved, out punUnlockTime);
			}
			return result;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00018A98 File Offset: 0x00016E98
		public static bool ResetAllStats(bool bAchievementsToo)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_ResetAllStats(CSteamAPIContext.GetSteamUserStats(), bAchievementsToo);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00018AAC File Offset: 0x00016EAC
		public static SteamAPICall_t FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLeaderboardName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUserStats_FindOrCreateLeaderboard(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, eLeaderboardSortMethod, eLeaderboardDisplayType);
			}
			return result;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00018AFC File Offset: 0x00016EFC
		public static SteamAPICall_t FindLeaderboard(string pchLeaderboardName)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLeaderboardName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUserStats_FindLeaderboard(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00018B4C File Offset: 0x00016F4C
		public static string GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetLeaderboardName(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard));
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00018B63 File Offset: 0x00016F63
		public static int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardEntryCount(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00018B75 File Offset: 0x00016F75
		public static ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardSortMethod(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00018B87 File Offset: 0x00016F87
		public static ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardDisplayType(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00018B99 File Offset: 0x00016F99
		public static SteamAPICall_t DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntries(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00018BB3 File Offset: 0x00016FB3
		public static SteamAPICall_t DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, CSteamID[] prgUsers, int cUsers)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntriesForUsers(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, prgUsers, cUsers);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00018BCC File Offset: 0x00016FCC
		public static bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, out LeaderboardEntry_t pLeaderboardEntry, int[] pDetails, int cDetailsMax)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetDownloadedLeaderboardEntry(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboardEntries, index, out pLeaderboardEntry, pDetails, cDetailsMax);
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00018BE3 File Offset: 0x00016FE3
		public static SteamAPICall_t UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int[] pScoreDetails, int cScoreDetailsCount)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_UploadLeaderboardScore(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00018BFF File Offset: 0x00016FFF
		public static SteamAPICall_t AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_AttachLeaderboardUGC(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, hUGC);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00018C17 File Offset: 0x00017017
		public static SteamAPICall_t GetNumberOfCurrentPlayers()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_GetNumberOfCurrentPlayers(CSteamAPIContext.GetSteamUserStats());
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00018C2D File Offset: 0x0001702D
		public static SteamAPICall_t RequestGlobalAchievementPercentages()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalAchievementPercentages(CSteamAPIContext.GetSteamUserStats());
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00018C44 File Offset: 0x00017044
		public static int GetMostAchievedAchievementInfo(out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)unNameBufLen);
			int num = NativeMethods.ISteamUserStats_GetMostAchievedAchievementInfo(CSteamAPIContext.GetSteamUserStats(), intPtr, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x00018C88 File Offset: 0x00017088
		public static int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)unNameBufLen);
			int num = NativeMethods.ISteamUserStats_GetNextMostAchievedAchievementInfo(CSteamAPIContext.GetSteamUserStats(), iIteratorPrevious, intPtr, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00018CD0 File Offset: 0x000170D0
		public static bool GetAchievementAchievedPercent(string pchName, out float pflPercent)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamUserStats_GetAchievementAchievedPercent(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pflPercent);
			}
			return result;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00018D1C File Offset: 0x0001711C
		public static SteamAPICall_t RequestGlobalStats(int nHistoryDays)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalStats(CSteamAPIContext.GetSteamUserStats(), nHistoryDays);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00018D34 File Offset: 0x00017134
		public static bool GetGlobalStat(string pchStatName, out long pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchStatName))
			{
				result = NativeMethods.ISteamUserStats_GetGlobalStat(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00018D80 File Offset: 0x00017180
		public static bool GetGlobalStat(string pchStatName, out double pData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchStatName))
			{
				result = NativeMethods.ISteamUserStats_GetGlobalStat0(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, out pData);
			}
			return result;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00018DCC File Offset: 0x000171CC
		public static int GetGlobalStatHistory(string pchStatName, long[] pData, uint cubData)
		{
			InteropHelp.TestIfAvailableClient();
			int result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchStatName))
			{
				result = NativeMethods.ISteamUserStats_GetGlobalStatHistory(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, pData, cubData);
			}
			return result;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00018E18 File Offset: 0x00017218
		public static int GetGlobalStatHistory(string pchStatName, double[] pData, uint cubData)
		{
			InteropHelp.TestIfAvailableClient();
			int result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchStatName))
			{
				result = NativeMethods.ISteamUserStats_GetGlobalStatHistory0(CSteamAPIContext.GetSteamUserStats(), utf8StringHandle, pData, cubData);
			}
			return result;
		}
	}
}
