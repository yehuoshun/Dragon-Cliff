using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000194 RID: 404
	public static class SteamUtils
	{
		// Token: 0x06000A2A RID: 2602 RVA: 0x00018E64 File Offset: 0x00017264
		public static uint GetSecondsSinceAppActive()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceAppActive(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00018E75 File Offset: 0x00017275
		public static uint GetSecondsSinceComputerActive()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceComputerActive(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00018E86 File Offset: 0x00017286
		public static EUniverse GetConnectedUniverse()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetConnectedUniverse(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00018E97 File Offset: 0x00017297
		public static uint GetServerRealTime()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetServerRealTime(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00018EA8 File Offset: 0x000172A8
		public static string GetIPCountry()
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetIPCountry(CSteamAPIContext.GetSteamUtils()));
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00018EBE File Offset: 0x000172BE
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageSize(CSteamAPIContext.GetSteamUtils(), iImage, out pnWidth, out pnHeight);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00018ED2 File Offset: 0x000172D2
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageRGBA(CSteamAPIContext.GetSteamUtils(), iImage, pubDest, nDestBufferSize);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00018EE6 File Offset: 0x000172E6
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCSERIPPort(CSteamAPIContext.GetSteamUtils(), out unIP, out usPort);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00018EF9 File Offset: 0x000172F9
		public static byte GetCurrentBatteryPower()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCurrentBatteryPower(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00018F0A File Offset: 0x0001730A
		public static AppId_t GetAppID()
		{
			InteropHelp.TestIfAvailableClient();
			return (AppId_t)NativeMethods.ISteamUtils_GetAppID(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00018F20 File Offset: 0x00017320
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetOverlayNotificationPosition(CSteamAPIContext.GetSteamUtils(), eNotificationPosition);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00018F32 File Offset: 0x00017332
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsAPICallCompleted(CSteamAPIContext.GetSteamUtils(), hSteamAPICall, out pbFailed);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00018F45 File Offset: 0x00017345
		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallFailureReason(CSteamAPIContext.GetSteamUtils(), hSteamAPICall);
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00018F57 File Offset: 0x00017357
		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallResult(CSteamAPIContext.GetSteamUtils(), hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00018F6E File Offset: 0x0001736E
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCCallCount(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00018F7F File Offset: 0x0001737F
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetWarningMessageHook(CSteamAPIContext.GetSteamUtils(), pFunction);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00018F91 File Offset: 0x00017391
		public static bool IsOverlayEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsOverlayEnabled(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00018FA2 File Offset: 0x000173A2
		public static bool BOverlayNeedsPresent()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BOverlayNeedsPresent(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00018FB4 File Offset: 0x000173B4
		public static SteamAPICall_t CheckFileSignature(string szFileName)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(szFileName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUtils_CheckFileSignature(CSteamAPIContext.GetSteamUtils(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00019004 File Offset: 0x00017404
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchDescription))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchExistingText))
				{
					result = NativeMethods.ISteamUtils_ShowGamepadTextInput(CSteamAPIContext.GetSteamUtils(), eInputMode, eLineInputMode, utf8StringHandle, unCharMax, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00019074 File Offset: 0x00017474
		public static uint GetEnteredGamepadTextLength()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetEnteredGamepadTextLength(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00019088 File Offset: 0x00017488
		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchText);
			bool flag = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(CSteamAPIContext.GetSteamUtils(), intPtr, cchText);
			pchText = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x000190C9 File Offset: 0x000174C9
		public static string GetSteamUILanguage()
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetSteamUILanguage(CSteamAPIContext.GetSteamUtils()));
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x000190DF File Offset: 0x000174DF
		public static bool IsSteamRunningInVR()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsSteamRunningInVR(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x000190F0 File Offset: 0x000174F0
		public static void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetOverlayNotificationInset(CSteamAPIContext.GetSteamUtils(), nHorizontalInset, nVerticalInset);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00019103 File Offset: 0x00017503
		public static bool IsSteamInBigPictureMode()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsSteamInBigPictureMode(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00019114 File Offset: 0x00017514
		public static void StartVRDashboard()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_StartVRDashboard(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00019125 File Offset: 0x00017525
		public static bool IsVRHeadsetStreamingEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsVRHeadsetStreamingEnabled(CSteamAPIContext.GetSteamUtils());
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00019136 File Offset: 0x00017536
		public static void SetVRHeadsetStreamingEnabled(bool bEnabled)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetVRHeadsetStreamingEnabled(CSteamAPIContext.GetSteamUtils(), bEnabled);
		}
	}
}
