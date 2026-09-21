using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000189 RID: 393
	public static class SteamMatchmakingServers
	{
		// Token: 0x060008FD RID: 2301 RVA: 0x00016119 File Offset: 0x00014519
		public static HServerListRequest RequestInternetServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestInternetServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, new MMKVPMarshaller(ppchFilters), nFilters, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00016142 File Offset: 0x00014542
		public static HServerListRequest RequestLANServerList(AppId_t iApp, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestLANServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0001615F File Offset: 0x0001455F
		public static HServerListRequest RequestFriendsServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestFriendsServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, new MMKVPMarshaller(ppchFilters), nFilters, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00016188 File Offset: 0x00014588
		public static HServerListRequest RequestFavoritesServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestFavoritesServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, new MMKVPMarshaller(ppchFilters), nFilters, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x000161B1 File Offset: 0x000145B1
		public static HServerListRequest RequestHistoryServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestHistoryServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, new MMKVPMarshaller(ppchFilters), nFilters, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000161DA File Offset: 0x000145DA
		public static HServerListRequest RequestSpectatorServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerListRequest)NativeMethods.ISteamMatchmakingServers_RequestSpectatorServerList(CSteamAPIContext.GetSteamMatchmakingServers(), iApp, new MMKVPMarshaller(ppchFilters), nFilters, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00016203 File Offset: 0x00014603
		public static void ReleaseRequest(HServerListRequest hServerListRequest)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmakingServers_ReleaseRequest(CSteamAPIContext.GetSteamMatchmakingServers(), hServerListRequest);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00016215 File Offset: 0x00014615
		public static gameserveritem_t GetServerDetails(HServerListRequest hRequest, int iServer)
		{
			InteropHelp.TestIfAvailableClient();
			return (gameserveritem_t)Marshal.PtrToStructure(NativeMethods.ISteamMatchmakingServers_GetServerDetails(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest, iServer), typeof(gameserveritem_t));
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0001623C File Offset: 0x0001463C
		public static void CancelQuery(HServerListRequest hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmakingServers_CancelQuery(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0001624E File Offset: 0x0001464E
		public static void RefreshQuery(HServerListRequest hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmakingServers_RefreshQuery(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00016260 File Offset: 0x00014660
		public static bool IsRefreshing(HServerListRequest hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmakingServers_IsRefreshing(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00016272 File Offset: 0x00014672
		public static int GetServerCount(HServerListRequest hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmakingServers_GetServerCount(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00016284 File Offset: 0x00014684
		public static void RefreshServer(HServerListRequest hRequest, int iServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmakingServers_RefreshServer(CSteamAPIContext.GetSteamMatchmakingServers(), hRequest, iServer);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00016297 File Offset: 0x00014697
		public static HServerQuery PingServer(uint unIP, ushort usPort, ISteamMatchmakingPingResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerQuery)NativeMethods.ISteamMatchmakingServers_PingServer(CSteamAPIContext.GetSteamMatchmakingServers(), unIP, usPort, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x000162B5 File Offset: 0x000146B5
		public static HServerQuery PlayerDetails(uint unIP, ushort usPort, ISteamMatchmakingPlayersResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerQuery)NativeMethods.ISteamMatchmakingServers_PlayerDetails(CSteamAPIContext.GetSteamMatchmakingServers(), unIP, usPort, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x000162D3 File Offset: 0x000146D3
		public static HServerQuery ServerRules(uint unIP, ushort usPort, ISteamMatchmakingRulesResponse pRequestServersResponse)
		{
			InteropHelp.TestIfAvailableClient();
			return (HServerQuery)NativeMethods.ISteamMatchmakingServers_ServerRules(CSteamAPIContext.GetSteamMatchmakingServers(), unIP, usPort, (IntPtr)pRequestServersResponse);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x000162F1 File Offset: 0x000146F1
		public static void CancelServerQuery(HServerQuery hServerQuery)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmakingServers_CancelServerQuery(CSteamAPIContext.GetSteamMatchmakingServers(), hServerQuery);
		}
	}
}
