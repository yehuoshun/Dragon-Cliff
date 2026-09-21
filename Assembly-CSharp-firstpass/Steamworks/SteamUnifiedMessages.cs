using System;

namespace Steamworks
{
	// Token: 0x02000191 RID: 401
	public static class SteamUnifiedMessages
	{
		// Token: 0x060009DD RID: 2525 RVA: 0x0001818C File Offset: 0x0001658C
		public static ClientUnifiedMessageHandle SendMethod(string pchServiceMethod, byte[] pRequestBuffer, uint unRequestBufferSize, ulong unContext)
		{
			InteropHelp.TestIfAvailableClient();
			ClientUnifiedMessageHandle result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchServiceMethod))
			{
				result = (ClientUnifiedMessageHandle)NativeMethods.ISteamUnifiedMessages_SendMethod(CSteamAPIContext.GetSteamUnifiedMessages(), utf8StringHandle, pRequestBuffer, unRequestBufferSize, unContext);
			}
			return result;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x000181DC File Offset: 0x000165DC
		public static bool GetMethodResponseInfo(ClientUnifiedMessageHandle hHandle, out uint punResponseSize, out EResult peResult)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_GetMethodResponseInfo(CSteamAPIContext.GetSteamUnifiedMessages(), hHandle, out punResponseSize, out peResult);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000181F0 File Offset: 0x000165F0
		public static bool GetMethodResponseData(ClientUnifiedMessageHandle hHandle, byte[] pResponseBuffer, uint unResponseBufferSize, bool bAutoRelease)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_GetMethodResponseData(CSteamAPIContext.GetSteamUnifiedMessages(), hHandle, pResponseBuffer, unResponseBufferSize, bAutoRelease);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00018205 File Offset: 0x00016605
		public static bool ReleaseMethod(ClientUnifiedMessageHandle hHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_ReleaseMethod(CSteamAPIContext.GetSteamUnifiedMessages(), hHandle);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00018218 File Offset: 0x00016618
		public static bool SendNotification(string pchServiceNotification, byte[] pNotificationBuffer, uint unNotificationBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchServiceNotification))
			{
				result = NativeMethods.ISteamUnifiedMessages_SendNotification(CSteamAPIContext.GetSteamUnifiedMessages(), utf8StringHandle, pNotificationBuffer, unNotificationBufferSize);
			}
			return result;
		}
	}
}
