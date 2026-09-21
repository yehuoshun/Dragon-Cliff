using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000188 RID: 392
	public static class SteamMatchmaking
	{
		// Token: 0x060008D7 RID: 2263 RVA: 0x00015B8B File Offset: 0x00013F8B
		public static int GetFavoriteGameCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGameCount(CSteamAPIContext.GetSteamMatchmaking());
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00015B9C File Offset: 0x00013F9C
		public static bool GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), iGame, out pnAppID, out pnIP, out pnConnPort, out pnQueryPort, out punFlags, out pRTime32LastPlayedOnServer);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00015BB7 File Offset: 0x00013FB7
		public static int AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_AddFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), nAppID, nIP, nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00015BD0 File Offset: 0x00013FD0
		public static bool RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RemoveFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), nAppID, nIP, nConnPort, nQueryPort, unFlags);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00015BE7 File Offset: 0x00013FE7
		public static SteamAPICall_t RequestLobbyList()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_RequestLobbyList(CSteamAPIContext.GetSteamMatchmaking());
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00015C00 File Offset: 0x00014000
		public static void AddRequestLobbyListStringFilter(string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValueToMatch))
				{
					NativeMethods.ISteamMatchmaking_AddRequestLobbyListStringFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, utf8StringHandle2, eComparisonType);
				}
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00015C70 File Offset: 0x00014070
		public static void AddRequestLobbyListNumericalFilter(string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				NativeMethods.ISteamMatchmaking_AddRequestLobbyListNumericalFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, nValueToMatch, eComparisonType);
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00015CB8 File Offset: 0x000140B8
		public static void AddRequestLobbyListNearValueFilter(string pchKeyToMatch, int nValueToBeCloseTo)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				NativeMethods.ISteamMatchmaking_AddRequestLobbyListNearValueFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, nValueToBeCloseTo);
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00015D00 File Offset: 0x00014100
		public static void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(CSteamAPIContext.GetSteamMatchmaking(), nSlotsAvailable);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00015D12 File Offset: 0x00014112
		public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListDistanceFilter(CSteamAPIContext.GetSteamMatchmaking(), eLobbyDistanceFilter);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00015D24 File Offset: 0x00014124
		public static void AddRequestLobbyListResultCountFilter(int cMaxResults)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListResultCountFilter(CSteamAPIContext.GetSteamMatchmaking(), cMaxResults);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00015D36 File Offset: 0x00014136
		public static void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00015D48 File Offset: 0x00014148
		public static CSteamID GetLobbyByIndex(int iLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyByIndex(CSteamAPIContext.GetSteamMatchmaking(), iLobby);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00015D5F File Offset: 0x0001415F
		public static SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_CreateLobby(CSteamAPIContext.GetSteamMatchmaking(), eLobbyType, cMaxMembers);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00015D77 File Offset: 0x00014177
		public static SteamAPICall_t JoinLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_JoinLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00015D8E File Offset: 0x0001418E
		public static void LeaveLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_LeaveLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00015DA0 File Offset: 0x000141A0
		public static bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_InviteUserToLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDInvitee);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00015DB3 File Offset: 0x000141B3
		public static int GetNumLobbyMembers(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetNumLobbyMembers(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00015DC5 File Offset: 0x000141C5
		public static CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyMemberByIndex(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iMember);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00015DE0 File Offset: 0x000141E0
		public static string GetLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamMatchmaking_GetLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle));
			}
			return result;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00015E30 File Offset: 0x00014230
		public static bool SetLobbyData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					result = NativeMethods.ISteamMatchmaking_SetLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00015E9C File Offset: 0x0001429C
		public static int GetLobbyDataCount(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyDataCount(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00015EB0 File Offset: 0x000142B0
		public static bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchKeyBufferSize);
			IntPtr intPtr2 = Marshal.AllocHGlobal(cchValueBufferSize);
			bool flag = NativeMethods.ISteamMatchmaking_GetLobbyDataByIndex(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iLobbyData, intPtr, cchKeyBufferSize, intPtr2, cchValueBufferSize);
			pchKey = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			pchValue = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00015F1C File Offset: 0x0001431C
		public static bool DeleteLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = NativeMethods.ISteamMatchmaking_DeleteLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00015F68 File Offset: 0x00014368
		public static string GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamMatchmaking_GetLobbyMemberData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDUser, utf8StringHandle));
			}
			return result;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00015FB8 File Offset: 0x000143B8
		public static void SetLobbyMemberData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					NativeMethods.ISteamMatchmaking_SetLobbyMemberData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle, utf8StringHandle2);
				}
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00016028 File Offset: 0x00014428
		public static bool SendLobbyChatMsg(CSteamID steamIDLobby, byte[] pvMsgBody, int cubMsgBody)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SendLobbyChatMsg(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, pvMsgBody, cubMsgBody);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001603C File Offset: 0x0001443C
		public static int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, byte[] pvData, int cubData, out EChatEntryType peChatEntryType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyChatEntry(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iChatID, out pSteamIDUser, pvData, cubData, out peChatEntryType);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00016055 File Offset: 0x00014455
		public static bool RequestLobbyData(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RequestLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00016067 File Offset: 0x00014467
		public static void SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_SetLobbyGameServer(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, unGameServerIP, unGameServerPort, steamIDGameServer);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001607C File Offset: 0x0001447C
		public static bool GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyGameServer(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, out punGameServerIP, out punGameServerPort, out psteamIDGameServer);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00016091 File Offset: 0x00014491
		public static bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyMemberLimit(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, cMaxMembers);
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x000160A4 File Offset: 0x000144A4
		public static int GetLobbyMemberLimit(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyMemberLimit(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x000160B6 File Offset: 0x000144B6
		public static bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyType(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, eLobbyType);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x000160C9 File Offset: 0x000144C9
		public static bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyJoinable(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, bLobbyJoinable);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x000160DC File Offset: 0x000144DC
		public static CSteamID GetLobbyOwner(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyOwner(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x000160F3 File Offset: 0x000144F3
		public static bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyOwner(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDNewOwner);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00016106 File Offset: 0x00014506
		public static bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLinkedLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDLobbyDependent);
		}
	}
}
