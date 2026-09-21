using System;

namespace Steamworks
{
	// Token: 0x02000185 RID: 389
	public static class SteamHTMLSurface
	{
		// Token: 0x06000881 RID: 2177 RVA: 0x00014FB8 File Offset: 0x000133B8
		public static bool Init()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTMLSurface_Init(CSteamAPIContext.GetSteamHTMLSurface());
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00014FC9 File Offset: 0x000133C9
		public static bool Shutdown()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTMLSurface_Shutdown(CSteamAPIContext.GetSteamHTMLSurface());
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00014FDC File Offset: 0x000133DC
		public static SteamAPICall_t CreateBrowser(string pchUserAgent, string pchUserCSS)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchUserAgent))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchUserCSS))
				{
					result = (SteamAPICall_t)NativeMethods.ISteamHTMLSurface_CreateBrowser(CSteamAPIContext.GetSteamHTMLSurface(), utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0001504C File Offset: 0x0001344C
		public static void RemoveBrowser(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_RemoveBrowser(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00015060 File Offset: 0x00013460
		public static void LoadURL(HHTMLBrowser unBrowserHandle, string pchURL, string pchPostData)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchURL))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchPostData))
				{
					NativeMethods.ISteamHTMLSurface_LoadURL(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, utf8StringHandle, utf8StringHandle2);
				}
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x000150D0 File Offset: 0x000134D0
		public static void SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetSize(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, unWidth, unHeight);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x000150E4 File Offset: 0x000134E4
		public static void StopLoad(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_StopLoad(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000150F6 File Offset: 0x000134F6
		public static void Reload(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_Reload(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00015108 File Offset: 0x00013508
		public static void GoBack(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GoBack(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0001511A File Offset: 0x0001351A
		public static void GoForward(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GoForward(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0001512C File Offset: 0x0001352C
		public static void AddHeader(HHTMLBrowser unBrowserHandle, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					NativeMethods.ISteamHTMLSurface_AddHeader(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, utf8StringHandle, utf8StringHandle2);
				}
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0001519C File Offset: 0x0001359C
		public static void ExecuteJavascript(HHTMLBrowser unBrowserHandle, string pchScript)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchScript))
			{
				NativeMethods.ISteamHTMLSurface_ExecuteJavascript(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, utf8StringHandle);
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000151E4 File Offset: 0x000135E4
		public static void MouseUp(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseUp(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, eMouseButton);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x000151F7 File Offset: 0x000135F7
		public static void MouseDown(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseDown(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, eMouseButton);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0001520A File Offset: 0x0001360A
		public static void MouseDoubleClick(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseDoubleClick(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0001521D File Offset: 0x0001361D
		public static void MouseMove(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseMove(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, x, y);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00015231 File Offset: 0x00013631
		public static void MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseWheel(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, nDelta);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00015244 File Offset: 0x00013644
		public static void KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyDown(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00015258 File Offset: 0x00013658
		public static void KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyUp(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0001526C File Offset: 0x0001366C
		public static void KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyChar(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, cUnicodeChar, eHTMLKeyModifiers);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00015280 File Offset: 0x00013680
		public static void SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetHorizontalScroll(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00015293 File Offset: 0x00013693
		public static void SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetVerticalScroll(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x000152A6 File Offset: 0x000136A6
		public static void SetKeyFocus(HHTMLBrowser unBrowserHandle, bool bHasKeyFocus)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetKeyFocus(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, bHasKeyFocus);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x000152B9 File Offset: 0x000136B9
		public static void ViewSource(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_ViewSource(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x000152CB File Offset: 0x000136CB
		public static void CopyToClipboard(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_CopyToClipboard(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x000152DD File Offset: 0x000136DD
		public static void PasteFromClipboard(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_PasteFromClipboard(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000152F0 File Offset: 0x000136F0
		public static void Find(HHTMLBrowser unBrowserHandle, string pchSearchStr, bool bCurrentlyInFind, bool bReverse)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchSearchStr))
			{
				NativeMethods.ISteamHTMLSurface_Find(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, utf8StringHandle, bCurrentlyInFind, bReverse);
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0001533C File Offset: 0x0001373C
		public static void StopFind(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_StopFind(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001534E File Offset: 0x0001374E
		public static void GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GetLinkAtPosition(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, x, y);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00015364 File Offset: 0x00013764
		public static void SetCookie(string pchHostname, string pchKey, string pchValue, string pchPath = "/", uint nExpires = 0u, bool bSecure = false, bool bHTTPOnly = false)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHostname))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchKey))
				{
					using (InteropHelp.UTF8StringHandle utf8StringHandle3 = new InteropHelp.UTF8StringHandle(pchValue))
					{
						using (InteropHelp.UTF8StringHandle utf8StringHandle4 = new InteropHelp.UTF8StringHandle(pchPath))
						{
							NativeMethods.ISteamHTMLSurface_SetCookie(CSteamAPIContext.GetSteamHTMLSurface(), utf8StringHandle, utf8StringHandle2, utf8StringHandle3, utf8StringHandle4, nExpires, bSecure, bHTTPOnly);
						}
					}
				}
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00015424 File Offset: 0x00013824
		public static void SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetPageScaleFactor(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, flZoom, nPointX, nPointY);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00015439 File Offset: 0x00013839
		public static void SetBackgroundMode(HHTMLBrowser unBrowserHandle, bool bBackgroundMode)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetBackgroundMode(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, bBackgroundMode);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001544C File Offset: 0x0001384C
		public static void SetDPIScalingFactor(HHTMLBrowser unBrowserHandle, float flDPIScaling)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetDPIScalingFactor(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, flDPIScaling);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0001545F File Offset: 0x0001385F
		public static void AllowStartRequest(HHTMLBrowser unBrowserHandle, bool bAllowed)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_AllowStartRequest(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, bAllowed);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00015472 File Offset: 0x00013872
		public static void JSDialogResponse(HHTMLBrowser unBrowserHandle, bool bResult)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_JSDialogResponse(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, bResult);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00015485 File Offset: 0x00013885
		public static void FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_FileLoadDialogResponse(CSteamAPIContext.GetSteamHTMLSurface(), unBrowserHandle, pchSelectedFiles);
		}
	}
}
