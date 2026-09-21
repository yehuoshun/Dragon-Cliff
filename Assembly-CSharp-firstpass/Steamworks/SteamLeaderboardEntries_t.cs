using System;

namespace Steamworks
{
	// Token: 0x020001BC RID: 444
	[Serializable]
	public struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		// Token: 0x06000BFC RID: 3068 RVA: 0x0001B168 File Offset: 0x00019568
		public SteamLeaderboardEntries_t(ulong value)
		{
			this.m_SteamLeaderboardEntries = value;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0001B171 File Offset: 0x00019571
		public override string ToString()
		{
			return this.m_SteamLeaderboardEntries.ToString();
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0001B184 File Offset: 0x00019584
		public override bool Equals(object other)
		{
			return other is SteamLeaderboardEntries_t && this == (SteamLeaderboardEntries_t)other;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x0001B1A5 File Offset: 0x000195A5
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboardEntries.GetHashCode();
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0001B1B8 File Offset: 0x000195B8
		public static bool operator ==(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return x.m_SteamLeaderboardEntries == y.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0001B1CA File Offset: 0x000195CA
		public static bool operator !=(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0001B1D6 File Offset: 0x000195D6
		public static explicit operator SteamLeaderboardEntries_t(ulong value)
		{
			return new SteamLeaderboardEntries_t(value);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0001B1DE File Offset: 0x000195DE
		public static explicit operator ulong(SteamLeaderboardEntries_t that)
		{
			return that.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0001B1E7 File Offset: 0x000195E7
		public bool Equals(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries == other.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0001B1F8 File Offset: 0x000195F8
		public int CompareTo(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries.CompareTo(other.m_SteamLeaderboardEntries);
		}

		// Token: 0x040009A7 RID: 2471
		public ulong m_SteamLeaderboardEntries;
	}
}
