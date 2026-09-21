using System;

namespace Steamworks
{
	// Token: 0x020001BD RID: 445
	[Serializable]
	public struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t>
	{
		// Token: 0x06000C06 RID: 3078 RVA: 0x0001B20C File Offset: 0x0001960C
		public SteamLeaderboard_t(ulong value)
		{
			this.m_SteamLeaderboard = value;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0001B215 File Offset: 0x00019615
		public override string ToString()
		{
			return this.m_SteamLeaderboard.ToString();
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0001B228 File Offset: 0x00019628
		public override bool Equals(object other)
		{
			return other is SteamLeaderboard_t && this == (SteamLeaderboard_t)other;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0001B249 File Offset: 0x00019649
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboard.GetHashCode();
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0001B25C File Offset: 0x0001965C
		public static bool operator ==(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return x.m_SteamLeaderboard == y.m_SteamLeaderboard;
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0001B26E File Offset: 0x0001966E
		public static bool operator !=(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0001B27A File Offset: 0x0001967A
		public static explicit operator SteamLeaderboard_t(ulong value)
		{
			return new SteamLeaderboard_t(value);
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0001B282 File Offset: 0x00019682
		public static explicit operator ulong(SteamLeaderboard_t that)
		{
			return that.m_SteamLeaderboard;
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x0001B28B File Offset: 0x0001968B
		public bool Equals(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard == other.m_SteamLeaderboard;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x0001B29C File Offset: 0x0001969C
		public int CompareTo(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard.CompareTo(other.m_SteamLeaderboard);
		}

		// Token: 0x040009A8 RID: 2472
		public ulong m_SteamLeaderboard;
	}
}
