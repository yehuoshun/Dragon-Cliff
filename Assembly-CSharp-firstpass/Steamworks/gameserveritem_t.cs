using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x02000196 RID: 406
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 372)]
	public class gameserveritem_t
	{
		// Token: 0x06000A4B RID: 2635 RVA: 0x000191C3 File Offset: 0x000175C3
		public gameserveritem_t()
		{
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x000191CB File Offset: 0x000175CB
		public string GetGameDir()
		{
			return Encoding.UTF8.GetString(this.m_szGameDir, 0, Array.IndexOf<byte>(this.m_szGameDir, 0));
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x000191EA File Offset: 0x000175EA
		public void SetGameDir(string dir)
		{
			this.m_szGameDir = Encoding.UTF8.GetBytes(dir + '\0');
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00019208 File Offset: 0x00017608
		public string GetMap()
		{
			return Encoding.UTF8.GetString(this.m_szMap, 0, Array.IndexOf<byte>(this.m_szMap, 0));
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00019227 File Offset: 0x00017627
		public void SetMap(string map)
		{
			this.m_szMap = Encoding.UTF8.GetBytes(map + '\0');
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00019245 File Offset: 0x00017645
		public string GetGameDescription()
		{
			return Encoding.UTF8.GetString(this.m_szGameDescription, 0, Array.IndexOf<byte>(this.m_szGameDescription, 0));
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00019264 File Offset: 0x00017664
		public void SetGameDescription(string desc)
		{
			this.m_szGameDescription = Encoding.UTF8.GetBytes(desc + '\0');
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00019282 File Offset: 0x00017682
		public string GetServerName()
		{
			if (this.m_szServerName[0] == 0)
			{
				return this.m_NetAdr.GetConnectionAddressString();
			}
			return Encoding.UTF8.GetString(this.m_szServerName, 0, Array.IndexOf<byte>(this.m_szServerName, 0));
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x000192BA File Offset: 0x000176BA
		public void SetServerName(string name)
		{
			this.m_szServerName = Encoding.UTF8.GetBytes(name + '\0');
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x000192D8 File Offset: 0x000176D8
		public string GetGameTags()
		{
			return Encoding.UTF8.GetString(this.m_szGameTags, 0, Array.IndexOf<byte>(this.m_szGameTags, 0));
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x000192F7 File Offset: 0x000176F7
		public void SetGameTags(string tags)
		{
			this.m_szGameTags = Encoding.UTF8.GetBytes(tags + '\0');
		}

		// Token: 0x04000952 RID: 2386
		public servernetadr_t m_NetAdr;

		// Token: 0x04000953 RID: 2387
		public int m_nPing;

		// Token: 0x04000954 RID: 2388
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bHadSuccessfulResponse;

		// Token: 0x04000955 RID: 2389
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDoNotRefresh;

		// Token: 0x04000956 RID: 2390
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] m_szGameDir;

		// Token: 0x04000957 RID: 2391
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] m_szMap;

		// Token: 0x04000958 RID: 2392
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_szGameDescription;

		// Token: 0x04000959 RID: 2393
		public uint m_nAppID;

		// Token: 0x0400095A RID: 2394
		public int m_nPlayers;

		// Token: 0x0400095B RID: 2395
		public int m_nMaxPlayers;

		// Token: 0x0400095C RID: 2396
		public int m_nBotPlayers;

		// Token: 0x0400095D RID: 2397
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPassword;

		// Token: 0x0400095E RID: 2398
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSecure;

		// Token: 0x0400095F RID: 2399
		public uint m_ulTimeLastPlayed;

		// Token: 0x04000960 RID: 2400
		public int m_nServerVersion;

		// Token: 0x04000961 RID: 2401
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_szServerName;

		// Token: 0x04000962 RID: 2402
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] m_szGameTags;

		// Token: 0x04000963 RID: 2403
		public CSteamID m_steamID;
	}
}
