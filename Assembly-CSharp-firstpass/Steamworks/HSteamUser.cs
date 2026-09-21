using System;

namespace Steamworks
{
	// Token: 0x02000199 RID: 409
	[Serializable]
	public struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser>
	{
		// Token: 0x06000A72 RID: 2674 RVA: 0x0001962B File Offset: 0x00017A2B
		public HSteamUser(int value)
		{
			this.m_HSteamUser = value;
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00019634 File Offset: 0x00017A34
		public override string ToString()
		{
			return this.m_HSteamUser.ToString();
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00019647 File Offset: 0x00017A47
		public override bool Equals(object other)
		{
			return other is HSteamUser && this == (HSteamUser)other;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00019668 File Offset: 0x00017A68
		public override int GetHashCode()
		{
			return this.m_HSteamUser.GetHashCode();
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0001967B File Offset: 0x00017A7B
		public static bool operator ==(HSteamUser x, HSteamUser y)
		{
			return x.m_HSteamUser == y.m_HSteamUser;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0001968D File Offset: 0x00017A8D
		public static bool operator !=(HSteamUser x, HSteamUser y)
		{
			return !(x == y);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00019699 File Offset: 0x00017A99
		public static explicit operator HSteamUser(int value)
		{
			return new HSteamUser(value);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x000196A1 File Offset: 0x00017AA1
		public static explicit operator int(HSteamUser that)
		{
			return that.m_HSteamUser;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x000196AA File Offset: 0x00017AAA
		public bool Equals(HSteamUser other)
		{
			return this.m_HSteamUser == other.m_HSteamUser;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x000196BB File Offset: 0x00017ABB
		public int CompareTo(HSteamUser other)
		{
			return this.m_HSteamUser.CompareTo(other.m_HSteamUser);
		}

		// Token: 0x04000968 RID: 2408
		public int m_HSteamUser;
	}
}
