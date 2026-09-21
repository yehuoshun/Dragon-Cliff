using System;

namespace Steamworks
{
	// Token: 0x020001A4 RID: 420
	[Serializable]
	public struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		// Token: 0x06000AF9 RID: 2809 RVA: 0x0001A104 File Offset: 0x00018504
		public FriendsGroupID_t(short value)
		{
			this.m_FriendsGroupID = value;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0001A10D File Offset: 0x0001850D
		public override string ToString()
		{
			return this.m_FriendsGroupID.ToString();
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0001A120 File Offset: 0x00018520
		public override bool Equals(object other)
		{
			return other is FriendsGroupID_t && this == (FriendsGroupID_t)other;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0001A141 File Offset: 0x00018541
		public override int GetHashCode()
		{
			return this.m_FriendsGroupID.GetHashCode();
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0001A154 File Offset: 0x00018554
		public static bool operator ==(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return x.m_FriendsGroupID == y.m_FriendsGroupID;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0001A166 File Offset: 0x00018566
		public static bool operator !=(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0001A172 File Offset: 0x00018572
		public static explicit operator FriendsGroupID_t(short value)
		{
			return new FriendsGroupID_t(value);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0001A17A File Offset: 0x0001857A
		public static explicit operator short(FriendsGroupID_t that)
		{
			return that.m_FriendsGroupID;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0001A183 File Offset: 0x00018583
		public bool Equals(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID == other.m_FriendsGroupID;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0001A194 File Offset: 0x00018594
		public int CompareTo(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID.CompareTo(other.m_FriendsGroupID);
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0001A1A8 File Offset: 0x000185A8
		// Note: this type is marked as 'beforefieldinit'.
		static FriendsGroupID_t()
		{
		}

		// Token: 0x0400097B RID: 2427
		public static readonly FriendsGroupID_t Invalid = new FriendsGroupID_t(-1);

		// Token: 0x0400097C RID: 2428
		public short m_FriendsGroupID;
	}
}
