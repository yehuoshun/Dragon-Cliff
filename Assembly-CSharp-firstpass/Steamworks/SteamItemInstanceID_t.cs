using System;

namespace Steamworks
{
	// Token: 0x020001AA RID: 426
	[Serializable]
	public struct SteamItemInstanceID_t : IEquatable<SteamItemInstanceID_t>, IComparable<SteamItemInstanceID_t>
	{
		// Token: 0x06000B3A RID: 2874 RVA: 0x0001A51D File Offset: 0x0001891D
		public SteamItemInstanceID_t(ulong value)
		{
			this.m_SteamItemInstanceID = value;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0001A526 File Offset: 0x00018926
		public override string ToString()
		{
			return this.m_SteamItemInstanceID.ToString();
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0001A539 File Offset: 0x00018939
		public override bool Equals(object other)
		{
			return other is SteamItemInstanceID_t && this == (SteamItemInstanceID_t)other;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0001A55A File Offset: 0x0001895A
		public override int GetHashCode()
		{
			return this.m_SteamItemInstanceID.GetHashCode();
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0001A56D File Offset: 0x0001896D
		public static bool operator ==(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return x.m_SteamItemInstanceID == y.m_SteamItemInstanceID;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0001A57F File Offset: 0x0001897F
		public static bool operator !=(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0001A58B File Offset: 0x0001898B
		public static explicit operator SteamItemInstanceID_t(ulong value)
		{
			return new SteamItemInstanceID_t(value);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0001A593 File Offset: 0x00018993
		public static explicit operator ulong(SteamItemInstanceID_t that)
		{
			return that.m_SteamItemInstanceID;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0001A59C File Offset: 0x0001899C
		public bool Equals(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID == other.m_SteamItemInstanceID;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0001A5AD File Offset: 0x000189AD
		public int CompareTo(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID.CompareTo(other.m_SteamItemInstanceID);
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0001A5C1 File Offset: 0x000189C1
		// Note: this type is marked as 'beforefieldinit'.
		static SteamItemInstanceID_t()
		{
		}

		// Token: 0x04000986 RID: 2438
		public static readonly SteamItemInstanceID_t Invalid = new SteamItemInstanceID_t(ulong.MaxValue);

		// Token: 0x04000987 RID: 2439
		public ulong m_SteamItemInstanceID;
	}
}
