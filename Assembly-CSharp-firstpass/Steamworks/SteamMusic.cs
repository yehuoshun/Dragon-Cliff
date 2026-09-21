using System;

namespace Steamworks
{
	// Token: 0x0200018A RID: 394
	public static class SteamMusic
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x00016303 File Offset: 0x00014703
		public static bool BIsEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsEnabled(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00016314 File Offset: 0x00014714
		public static bool BIsPlaying()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsPlaying(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00016325 File Offset: 0x00014725
		public static AudioPlayback_Status GetPlaybackStatus()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetPlaybackStatus(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00016336 File Offset: 0x00014736
		public static void Play()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Play(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00016347 File Offset: 0x00014747
		public static void Pause()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Pause(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00016358 File Offset: 0x00014758
		public static void PlayPrevious()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayPrevious(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00016369 File Offset: 0x00014769
		public static void PlayNext()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayNext(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0001637A File Offset: 0x0001477A
		public static void SetVolume(float flVolume)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_SetVolume(CSteamAPIContext.GetSteamMusic(), flVolume);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0001638C File Offset: 0x0001478C
		public static float GetVolume()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetVolume(CSteamAPIContext.GetSteamMusic());
		}
	}
}
