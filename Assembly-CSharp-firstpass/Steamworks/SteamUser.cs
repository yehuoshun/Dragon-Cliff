using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000192 RID: 402
	public static class SteamUser
	{
		// Token: 0x060009E2 RID: 2530 RVA: 0x00018264 File Offset: 0x00016664
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamUser_GetHSteamUser(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0001827A File Offset: 0x0001667A
		public static bool BLoggedOn()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BLoggedOn(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0001828B File Offset: 0x0001668B
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamUser_GetSteamID(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x000182A1 File Offset: 0x000166A1
		public static int InitiateGameConnection(byte[] pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, bool bSecure)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_InitiateGameConnection(CSteamAPIContext.GetSteamUser(), pAuthBlob, cbMaxAuthBlob, steamIDGameServer, unIPServer, usPortServer, bSecure);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x000182BA File Offset: 0x000166BA
		public static void TerminateGameConnection(uint unIPServer, ushort usPortServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_TerminateGameConnection(CSteamAPIContext.GetSteamUser(), unIPServer, usPortServer);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x000182D0 File Offset: 0x000166D0
		public static void TrackAppUsageEvent(CGameID gameID, int eAppUsageEvent, string pchExtraInfo = "")
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchExtraInfo))
			{
				NativeMethods.ISteamUser_TrackAppUsageEvent(CSteamAPIContext.GetSteamUser(), gameID, eAppUsageEvent, utf8StringHandle);
			}
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00018318 File Offset: 0x00016718
		public static bool GetUserDataFolder(out string pchBuffer, int cubBuffer)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cubBuffer);
			bool flag = NativeMethods.ISteamUser_GetUserDataFolder(CSteamAPIContext.GetSteamUser(), intPtr, cubBuffer);
			pchBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00018359 File Offset: 0x00016759
		public static void StartVoiceRecording()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_StartVoiceRecording(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0001836A File Offset: 0x0001676A
		public static void StopVoiceRecording()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_StopVoiceRecording(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0001837B File Offset: 0x0001677B
		public static EVoiceResult GetAvailableVoice(out uint pcbCompressed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetAvailableVoice(CSteamAPIContext.GetSteamUser(), out pcbCompressed, IntPtr.Zero, 0u);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00018394 File Offset: 0x00016794
		public static EVoiceResult GetVoice(bool bWantCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetVoice(CSteamAPIContext.GetSteamUser(), bWantCompressed, pDestBuffer, cbDestBufferSize, out nBytesWritten, false, IntPtr.Zero, 0u, IntPtr.Zero, 0u);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x000183C1 File Offset: 0x000167C1
		public static EVoiceResult DecompressVoice(byte[] pCompressed, uint cbCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, uint nDesiredSampleRate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_DecompressVoice(CSteamAPIContext.GetSteamUser(), pCompressed, cbCompressed, pDestBuffer, cbDestBufferSize, out nBytesWritten, nDesiredSampleRate);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000183DA File Offset: 0x000167DA
		public static uint GetVoiceOptimalSampleRate()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetVoiceOptimalSampleRate(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x000183EB File Offset: 0x000167EB
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableClient();
			return (HAuthTicket)NativeMethods.ISteamUser_GetAuthSessionTicket(CSteamAPIContext.GetSteamUser(), pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00018404 File Offset: 0x00016804
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BeginAuthSession(CSteamAPIContext.GetSteamUser(), pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00018418 File Offset: 0x00016818
		public static void EndAuthSession(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_EndAuthSession(CSteamAPIContext.GetSteamUser(), steamID);
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0001842A File Offset: 0x0001682A
		public static void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_CancelAuthTicket(CSteamAPIContext.GetSteamUser(), hAuthTicket);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0001843C File Offset: 0x0001683C
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_UserHasLicenseForApp(CSteamAPIContext.GetSteamUser(), steamID, appID);
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0001844F File Offset: 0x0001684F
		public static bool BIsBehindNAT()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsBehindNAT(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00018460 File Offset: 0x00016860
		public static void AdvertiseGame(CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_AdvertiseGame(CSteamAPIContext.GetSteamUser(), steamIDGameServer, unIPServer, usPortServer);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00018474 File Offset: 0x00016874
		public static SteamAPICall_t RequestEncryptedAppTicket(byte[] pDataToInclude, int cbDataToInclude)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUser_RequestEncryptedAppTicket(CSteamAPIContext.GetSteamUser(), pDataToInclude, cbDataToInclude);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0001848C File Offset: 0x0001688C
		public static bool GetEncryptedAppTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetEncryptedAppTicket(CSteamAPIContext.GetSteamUser(), pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x000184A0 File Offset: 0x000168A0
		public static int GetGameBadgeLevel(int nSeries, bool bFoil)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetGameBadgeLevel(CSteamAPIContext.GetSteamUser(), nSeries, bFoil);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x000184B3 File Offset: 0x000168B3
		public static int GetPlayerSteamLevel()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetPlayerSteamLevel(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x000184C4 File Offset: 0x000168C4
		public static SteamAPICall_t RequestStoreAuthURL(string pchRedirectURL)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchRedirectURL))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUser_RequestStoreAuthURL(CSteamAPIContext.GetSteamUser(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00018514 File Offset: 0x00016914
		public static bool BIsPhoneVerified()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsPhoneVerified(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00018525 File Offset: 0x00016925
		public static bool BIsTwoFactorEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsTwoFactorEnabled(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00018536 File Offset: 0x00016936
		public static bool BIsPhoneIdentifying()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsPhoneIdentifying(CSteamAPIContext.GetSteamUser());
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00018547 File Offset: 0x00016947
		public static bool BIsPhoneRequiringVerification()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsPhoneRequiringVerification(CSteamAPIContext.GetSteamUser());
		}
	}
}
