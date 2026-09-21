using System;

namespace Steamworks
{
	// Token: 0x02000061 RID: 97
	public static class SteamAPI
	{
		// Token: 0x060003BA RID: 954 RVA: 0x00010488 File Offset: 0x0000E888
		public static bool Init()
		{
			InteropHelp.TestIfPlatformSupported();
			bool flag = NativeMethods.SteamAPI_Init();
			if (flag)
			{
				flag = CSteamAPIContext.Init();
			}
			return flag;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000104AD File Offset: 0x0000E8AD
		public static void Shutdown()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_Shutdown();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000104B9 File Offset: 0x0000E8B9
		public static bool RestartAppIfNecessary(AppId_t unOwnAppID)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_RestartAppIfNecessary(unOwnAppID);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000104C6 File Offset: 0x0000E8C6
		public static void ReleaseCurrentThreadMemory()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_ReleaseCurrentThreadMemory();
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000104D2 File Offset: 0x0000E8D2
		public static void RunCallbacks()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_RunCallbacks();
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000104DE File Offset: 0x0000E8DE
		public static bool IsSteamRunning()
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_IsSteamRunning();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000104EA File Offset: 0x0000E8EA
		public static HSteamUser GetHSteamUserCurrent()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.Steam_GetHSteamUserCurrent();
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000104FB File Offset: 0x0000E8FB
		public static HSteamPipe GetHSteamPipe()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamAPI_GetHSteamPipe();
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0001050C File Offset: 0x0000E90C
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamAPI_GetHSteamUser();
		}
	}
}
