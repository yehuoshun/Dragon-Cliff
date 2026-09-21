using System;

namespace Steamworks
{
	// Token: 0x0200017A RID: 378
	public static class SteamController
	{
		// Token: 0x06000701 RID: 1793 RVA: 0x000119AC File Offset: 0x0000FDAC
		public static bool Init()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_Init(CSteamAPIContext.GetSteamController());
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000119BD File Offset: 0x0000FDBD
		public static bool Shutdown()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_Shutdown(CSteamAPIContext.GetSteamController());
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000119CE File Offset: 0x0000FDCE
		public static void RunFrame()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_RunFrame(CSteamAPIContext.GetSteamController());
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x000119DF File Offset: 0x0000FDDF
		public static int GetConnectedControllers(ControllerHandle_t[] handlesOut)
		{
			InteropHelp.TestIfAvailableClient();
			if (handlesOut.Length != 16)
			{
				throw new ArgumentException("handlesOut must be the same size as Constants.STEAM_CONTROLLER_MAX_COUNT!");
			}
			return NativeMethods.ISteamController_GetConnectedControllers(CSteamAPIContext.GetSteamController(), handlesOut);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00011A06 File Offset: 0x0000FE06
		public static bool ShowBindingPanel(ControllerHandle_t controllerHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_ShowBindingPanel(CSteamAPIContext.GetSteamController(), controllerHandle);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00011A18 File Offset: 0x0000FE18
		public static ControllerActionSetHandle_t GetActionSetHandle(string pszActionSetName)
		{
			InteropHelp.TestIfAvailableClient();
			ControllerActionSetHandle_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszActionSetName))
			{
				result = (ControllerActionSetHandle_t)NativeMethods.ISteamController_GetActionSetHandle(CSteamAPIContext.GetSteamController(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00011A68 File Offset: 0x0000FE68
		public static void ActivateActionSet(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_ActivateActionSet(CSteamAPIContext.GetSteamController(), controllerHandle, actionSetHandle);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00011A7B File Offset: 0x0000FE7B
		public static ControllerActionSetHandle_t GetCurrentActionSet(ControllerHandle_t controllerHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return (ControllerActionSetHandle_t)NativeMethods.ISteamController_GetCurrentActionSet(CSteamAPIContext.GetSteamController(), controllerHandle);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00011A94 File Offset: 0x0000FE94
		public static ControllerDigitalActionHandle_t GetDigitalActionHandle(string pszActionName)
		{
			InteropHelp.TestIfAvailableClient();
			ControllerDigitalActionHandle_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszActionName))
			{
				result = (ControllerDigitalActionHandle_t)NativeMethods.ISteamController_GetDigitalActionHandle(CSteamAPIContext.GetSteamController(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00011AE4 File Offset: 0x0000FEE4
		public static ControllerDigitalActionData_t GetDigitalActionData(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetDigitalActionData(CSteamAPIContext.GetSteamController(), controllerHandle, digitalActionHandle);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00011AF7 File Offset: 0x0000FEF7
		public static int GetDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, EControllerActionOrigin[] originsOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetDigitalActionOrigins(CSteamAPIContext.GetSteamController(), controllerHandle, actionSetHandle, digitalActionHandle, originsOut);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00011B0C File Offset: 0x0000FF0C
		public static ControllerAnalogActionHandle_t GetAnalogActionHandle(string pszActionName)
		{
			InteropHelp.TestIfAvailableClient();
			ControllerAnalogActionHandle_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszActionName))
			{
				result = (ControllerAnalogActionHandle_t)NativeMethods.ISteamController_GetAnalogActionHandle(CSteamAPIContext.GetSteamController(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00011B5C File Offset: 0x0000FF5C
		public static ControllerAnalogActionData_t GetAnalogActionData(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetAnalogActionData(CSteamAPIContext.GetSteamController(), controllerHandle, analogActionHandle);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00011B6F File Offset: 0x0000FF6F
		public static int GetAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, EControllerActionOrigin[] originsOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetAnalogActionOrigins(CSteamAPIContext.GetSteamController(), controllerHandle, actionSetHandle, analogActionHandle, originsOut);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00011B84 File Offset: 0x0000FF84
		public static void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_StopAnalogActionMomentum(CSteamAPIContext.GetSteamController(), controllerHandle, eAction);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00011B97 File Offset: 0x0000FF97
		public static void TriggerHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_TriggerHapticPulse(CSteamAPIContext.GetSteamController(), controllerHandle, eTargetPad, usDurationMicroSec);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00011BAB File Offset: 0x0000FFAB
		public static void TriggerRepeatedHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_TriggerRepeatedHapticPulse(CSteamAPIContext.GetSteamController(), controllerHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00011BC4 File Offset: 0x0000FFC4
		public static void TriggerVibration(ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_TriggerVibration(CSteamAPIContext.GetSteamController(), controllerHandle, usLeftSpeed, usRightSpeed);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00011BD8 File Offset: 0x0000FFD8
		public static void SetLEDColor(ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_SetLEDColor(CSteamAPIContext.GetSteamController(), controllerHandle, nColorR, nColorG, nColorB, nFlags);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00011BEF File Offset: 0x0000FFEF
		public static int GetGamepadIndexForController(ControllerHandle_t ulControllerHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetGamepadIndexForController(CSteamAPIContext.GetSteamController(), ulControllerHandle);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00011C01 File Offset: 0x00010001
		public static ControllerHandle_t GetControllerForGamepadIndex(int nIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (ControllerHandle_t)NativeMethods.ISteamController_GetControllerForGamepadIndex(CSteamAPIContext.GetSteamController(), nIndex);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00011C18 File Offset: 0x00010018
		public static ControllerMotionData_t GetMotionData(ControllerHandle_t controllerHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetMotionData(CSteamAPIContext.GetSteamController(), controllerHandle);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00011C2A File Offset: 0x0001002A
		public static bool ShowDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle, float flScale, float flXPosition, float flYPosition)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_ShowDigitalActionOrigins(CSteamAPIContext.GetSteamController(), controllerHandle, digitalActionHandle, flScale, flXPosition, flYPosition);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00011C41 File Offset: 0x00010041
		public static bool ShowAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle, float flScale, float flXPosition, float flYPosition)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_ShowAnalogActionOrigins(CSteamAPIContext.GetSteamController(), controllerHandle, analogActionHandle, flScale, flXPosition, flYPosition);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00011C58 File Offset: 0x00010058
		public static string GetStringForActionOrigin(EControllerActionOrigin eOrigin)
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamController_GetStringForActionOrigin(CSteamAPIContext.GetSteamController(), eOrigin));
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00011C6F File Offset: 0x0001006F
		public static string GetGlyphForActionOrigin(EControllerActionOrigin eOrigin)
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamController_GetGlyphForActionOrigin(CSteamAPIContext.GetSteamController(), eOrigin));
		}
	}
}
