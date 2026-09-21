using System;

namespace Steamworks
{
	// Token: 0x02000062 RID: 98
	public static class GameServer
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x00010520 File Offset: 0x0000E920
		public static bool Init(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
		{
			InteropHelp.TestIfPlatformSupported();
			bool flag;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersionString))
			{
				flag = NativeMethods.SteamGameServer_Init(unIP, usSteamPort, usGamePort, usQueryPort, eServerMode, utf8StringHandle);
			}
			if (flag)
			{
				flag = CSteamGameServerAPIContext.Init();
			}
			return flag;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00010578 File Offset: 0x0000E978
		public static void Shutdown()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_Shutdown();
			CSteamGameServerAPIContext.Clear();
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00010589 File Offset: 0x0000E989
		public static void RunCallbacks()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_RunCallbacks();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00010595 File Offset: 0x0000E995
		public static void ReleaseCurrentThreadMemory()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_ReleaseCurrentThreadMemory();
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000105A1 File Offset: 0x0000E9A1
		public static bool BSecure()
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_BSecure();
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000105AD File Offset: 0x0000E9AD
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfPlatformSupported();
			return (CSteamID)NativeMethods.SteamGameServer_GetSteamID();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000105BE File Offset: 0x0000E9BE
		public static HSteamPipe GetHSteamPipe()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamGameServer_GetHSteamPipe();
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000105CF File Offset: 0x0000E9CF
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamGameServer_GetHSteamUser();
		}
	}
}
