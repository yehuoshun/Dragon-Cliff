using System;

namespace Steamworks
{
	// Token: 0x02000181 RID: 385
	public static class SteamGameServerNetworking
	{
		// Token: 0x060007FA RID: 2042 RVA: 0x00013C73 File Offset: 0x00012073
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00013C8A File Offset: 0x0001208A
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsP2PPacketAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), out pcubMsgSize, nChannel);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00013C9D File Offset: 0x0001209D
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_ReadP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00013CB4 File Offset: 0x000120B4
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AcceptP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00013CC6 File Offset: 0x000120C6
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00013CD8 File Offset: 0x000120D8
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PChannelWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, nChannel);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00013CEB File Offset: 0x000120EB
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetP2PSessionState(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, out pConnectionState);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00013CFE File Offset: 0x000120FE
		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AllowP2PPacketRelay(CSteamGameServerAPIContext.GetSteamNetworking(), bAllow);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00013D10 File Offset: 0x00012110
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetListenSocket_t)NativeMethods.ISteamNetworking_CreateListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00013D2A File Offset: 0x0001212A
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateP2PConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00013D44 File Offset: 0x00012144
		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nIP, nPort, nTimeoutSec);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00013D5D File Offset: 0x0001215D
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroySocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00013D70 File Offset: 0x00012170
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroyListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00013D83 File Offset: 0x00012183
		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendDataOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubData, cubData, bReliable);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00013D98 File Offset: 0x00012198
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailableOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pcubMsgSize);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00013DAB File Offset: 0x000121AB
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveDataFromSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00013DC0 File Offset: 0x000121C0
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pcubMsgSize, out phSocket);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00013DD4 File Offset: 0x000121D4
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveData(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00013DEB File Offset: 0x000121EB
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00013E02 File Offset: 0x00012202
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetListenSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pnIP, out pnPort);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00013E16 File Offset: 0x00012216
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketConnectionType(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00013E28 File Offset: 0x00012228
		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetMaxPacketSize(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}
	}
}
