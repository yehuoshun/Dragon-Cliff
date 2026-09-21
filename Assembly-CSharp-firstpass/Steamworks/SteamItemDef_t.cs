using System;

namespace Steamworks
{
	// Token: 0x020001A9 RID: 425
	[Serializable]
	public struct SteamItemDef_t : IEquatable<SteamItemDef_t>, IComparable<SteamItemDef_t>
	{
		// Token: 0x06000B30 RID: 2864 RVA: 0x0001A479 File Offset: 0x00018879
		public SteamItemDef_t(int value)
		{
			this.m_SteamItemDef = value;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0001A482 File Offset: 0x00018882
		public override string ToString()
		{
			return this.m_SteamItemDef.ToString();
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0001A495 File Offset: 0x00018895
		public override bool Equals(object other)
		{
			return other is SteamItemDef_t && this == (SteamItemDef_t)other;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0001A4B6 File Offset: 0x000188B6
		public override int GetHashCode()
		{
			return this.m_SteamItemDef.GetHashCode();
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0001A4C9 File Offset: 0x000188C9
		public static bool operator ==(SteamItemDef_t x, SteamItemDef_t y)
		{
			return x.m_SteamItemDef == y.m_SteamItemDef;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0001A4DB File Offset: 0x000188DB
		public static bool operator !=(SteamItemDef_t x, SteamItemDef_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0001A4E7 File Offset: 0x000188E7
		public static explicit operator SteamItemDef_t(int value)
		{
			return new SteamItemDef_t(value);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0001A4EF File Offset: 0x000188EF
		public static explicit operator int(SteamItemDef_t that)
		{
			return that.m_SteamItemDef;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0001A4F8 File Offset: 0x000188F8
		public bool Equals(SteamItemDef_t other)
		{
			return this.m_SteamItemDef == other.m_SteamItemDef;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0001A509 File Offset: 0x00018909
		public int CompareTo(SteamItemDef_t other)
		{
			return this.m_SteamItemDef.CompareTo(other.m_SteamItemDef);
		}

		// Token: 0x04000985 RID: 2437
		public int m_SteamItemDef;
	}
}
