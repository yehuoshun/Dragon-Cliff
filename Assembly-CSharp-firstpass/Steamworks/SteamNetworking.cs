using System;

namespace Steamworks
{
	// Token: 0x0200018C RID: 396
	public static class SteamNetworking
	{
		// Token: 0x06000937 RID: 2359 RVA: 0x000166F3 File Offset: 0x00014AF3
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_SendP2PPacket(CSteamAPIContext.GetSteamNetworking(), steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0001670A File Offset: 0x00014B0A
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsP2PPacketAvailable(CSteamAPIContext.GetSteamNetworking(), out pcubMsgSize, nChannel);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001671D File Offset: 0x00014B1D
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_ReadP2PPacket(CSteamAPIContext.GetSteamNetworking(), pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00016734 File Offset: 0x00014B34
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_AcceptP2PSessionWithUser(CSteamAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00016746 File Offset: 0x00014B46
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_CloseP2PSessionWithUser(CSteamAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00016758 File Offset: 0x00014B58
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_CloseP2PChannelWithUser(CSteamAPIContext.GetSteamNetworking(), steamIDRemote, nChannel);
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001676B File Offset: 0x00014B6B
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetP2PSessionState(CSteamAPIContext.GetSteamNetworking(), steamIDRemote, out pConnectionState);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001677E File Offset: 0x00014B7E
		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_AllowP2PPacketRelay(CSteamAPIContext.GetSteamNetworking(), bAllow);
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00016790 File Offset: 0x00014B90
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetListenSocket_t)NativeMethods.ISteamNetworking_CreateListenSocket(CSteamAPIContext.GetSteamNetworking(), nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000167AA File Offset: 0x00014BAA
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateP2PConnectionSocket(CSteamAPIContext.GetSteamNetworking(), steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x000167C4 File Offset: 0x00014BC4
		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateConnectionSocket(CSteamAPIContext.GetSteamNetworking(), nIP, nPort, nTimeoutSec);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x000167DD File Offset: 0x00014BDD
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_DestroySocket(CSteamAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x000167F0 File Offset: 0x00014BF0
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_DestroyListenSocket(CSteamAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00016803 File Offset: 0x00014C03
		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_SendDataOnSocket(CSteamAPIContext.GetSteamNetworking(), hSocket, pubData, cubData, bReliable);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00016818 File Offset: 0x00014C18
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsDataAvailableOnSocket(CSteamAPIContext.GetSteamNetworking(), hSocket, out pcubMsgSize);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001682B File Offset: 0x00014C2B
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_RetrieveDataFromSocket(CSteamAPIContext.GetSteamNetworking(), hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00016840 File Offset: 0x00014C40
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsDataAvailable(CSteamAPIContext.GetSteamNetworking(), hListenSocket, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00016854 File Offset: 0x00014C54
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_RetrieveData(CSteamAPIContext.GetSteamNetworking(), hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0001686B File Offset: 0x00014C6B
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetSocketInfo(CSteamAPIContext.GetSteamNetworking(), hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00016882 File Offset: 0x00014C82
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetListenSocketInfo(CSteamAPIContext.GetSteamNetworking(), hListenSocket, out pnIP, out pnPort);
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00016896 File Offset: 0x00014C96
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetSocketConnectionType(CSteamAPIContext.GetSteamNetworking(), hSocket);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x000168A8 File Offset: 0x00014CA8
		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetMaxPacketSize(CSteamAPIContext.GetSteamNetworking(), hSocket);
		}
	}
}
