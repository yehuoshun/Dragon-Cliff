using System;

namespace Steamworks
{
	// Token: 0x0200017F RID: 383
	public static class SteamGameServerHTTP
	{
		// Token: 0x060007C8 RID: 1992 RVA: 0x00013580 File Offset: 0x00011980
		public static HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL)
		{
			InteropHelp.TestIfAvailableGameServer();
			HTTPRequestHandle result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchAbsoluteURL))
			{
				result = (HTTPRequestHandle)NativeMethods.ISteamHTTP_CreateHTTPRequest(CSteamGameServerAPIContext.GetSteamHTTP(), eHTTPRequestMethod, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x000135D0 File Offset: 0x000119D0
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SetHTTPRequestContextValue(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, ulContextValue);
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x000135E3 File Offset: 0x000119E3
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, unTimeoutSeconds);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x000135F8 File Offset: 0x000119F8
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchHeaderValue))
				{
					result = NativeMethods.ISteamHTTP_SetHTTPRequestHeaderValue(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00013664 File Offset: 0x00011A64
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string pchParamName, string pchParamValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchParamName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchParamValue))
				{
					result = NativeMethods.ISteamHTTP_SetHTTPRequestGetOrPostParameter(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x000136D0 File Offset: 0x00011AD0
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SendHTTPRequest(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, out pCallHandle);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x000136E3 File Offset: 0x00011AE3
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SendHTTPRequestAndStreamResponse(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, out pCallHandle);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x000136F6 File Offset: 0x00011AF6
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_DeferHTTPRequest(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00013708 File Offset: 0x00011B08
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_PrioritizeHTTPRequest(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001371C File Offset: 0x00011B1C
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string pchHeaderName, out uint unResponseHeaderSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				result = NativeMethods.ISteamHTTP_GetHTTPResponseHeaderSize(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, out unResponseHeaderSize);
			}
			return result;
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00013768 File Offset: 0x00011B68
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, byte[] pHeaderValueBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				result = NativeMethods.ISteamHTTP_GetHTTPResponseHeaderValue(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, pHeaderValueBuffer, unBufferSize);
			}
			return result;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x000137B4 File Offset: 0x00011BB4
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodySize(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, out unBodySize);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000137C7 File Offset: 0x00011BC7
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodyData(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000137DB File Offset: 0x00011BDB
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_GetHTTPStreamingResponseBodyData(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, cOffset, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000137F0 File Offset: 0x00011BF0
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_ReleaseHTTPRequest(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00013802 File Offset: 0x00011C02
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_GetHTTPDownloadProgressPct(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, out pflPercentOut);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00013818 File Offset: 0x00011C18
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string pchContentType, byte[] pubBody, uint unBodyLen)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchContentType))
			{
				result = NativeMethods.ISteamHTTP_SetHTTPRequestRawPostBody(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, pubBody, unBodyLen);
			}
			return result;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00013864 File Offset: 0x00011C64
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HTTPCookieContainerHandle)NativeMethods.ISteamHTTP_CreateCookieContainer(CSteamGameServerAPIContext.GetSteamHTTP(), bAllowResponsesToModify);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001387B File Offset: 0x00011C7B
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_ReleaseCookieContainer(CSteamGameServerAPIContext.GetSteamHTTP(), hCookieContainer);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00013890 File Offset: 0x00011C90
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHost))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchUrl))
				{
					using (InteropHelp.UTF8StringHandle utf8StringHandle3 = new InteropHelp.UTF8StringHandle(pchCookie))
					{
						result = NativeMethods.ISteamHTTP_SetCookie(CSteamGameServerAPIContext.GetSteamHTTP(), hCookieContainer, utf8StringHandle, utf8StringHandle2, utf8StringHandle3);
					}
				}
			}
			return result;
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001391C File Offset: 0x00011D1C
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SetHTTPRequestCookieContainer(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, hCookieContainer);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00013930 File Offset: 0x00011D30
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string pchUserAgentInfo)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchUserAgentInfo))
			{
				result = NativeMethods.ISteamHTTP_SetHTTPRequestUserAgentInfo(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001397C File Offset: 0x00011D7C
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, bRequireVerifiedCertificate);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0001398F File Offset: 0x00011D8F
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, unMilliseconds);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x000139A2 File Offset: 0x00011DA2
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamHTTP_GetHTTPRequestWasTimedOut(CSteamGameServerAPIContext.GetSteamHTTP(), hRequest, out pbWasTimedOut);
		}
	}
}
