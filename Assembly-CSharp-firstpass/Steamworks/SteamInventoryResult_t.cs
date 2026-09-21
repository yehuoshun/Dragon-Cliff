using System;

namespace Steamworks
{
	// Token: 0x020001A8 RID: 424
	[Serializable]
	public struct SteamInventoryResult_t : IEquatable<SteamInventoryResult_t>, IComparable<SteamInventoryResult_t>
	{
		// Token: 0x06000B25 RID: 2853 RVA: 0x0001A3C8 File Offset: 0x000187C8
		public SteamInventoryResult_t(int value)
		{
			this.m_SteamInventoryResult = value;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0001A3D1 File Offset: 0x000187D1
		public override string ToString()
		{
			return this.m_SteamInventoryResult.ToString();
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0001A3E4 File Offset: 0x000187E4
		public override bool Equals(object other)
		{
			return other is SteamInventoryResult_t && this == (SteamInventoryResult_t)other;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0001A405 File Offset: 0x00018805
		public override int GetHashCode()
		{
			return this.m_SteamInventoryResult.GetHashCode();
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0001A418 File Offset: 0x00018818
		public static bool operator ==(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return x.m_SteamInventoryResult == y.m_SteamInventoryResult;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0001A42A File Offset: 0x0001882A
		public static bool operator !=(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0001A436 File Offset: 0x00018836
		public static explicit operator SteamInventoryResult_t(int value)
		{
			return new SteamInventoryResult_t(value);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0001A43E File Offset: 0x0001883E
		public static explicit operator int(SteamInventoryResult_t that)
		{
			return that.m_SteamInventoryResult;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0001A447 File Offset: 0x00018847
		public bool Equals(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult == other.m_SteamInventoryResult;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0001A458 File Offset: 0x00018858
		public int CompareTo(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult.CompareTo(other.m_SteamInventoryResult);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0001A46C File Offset: 0x0001886C
		// Note: this type is marked as 'beforefieldinit'.
		static SteamInventoryResult_t()
		{
		}

		// Token: 0x04000983 RID: 2435
		public static readonly SteamInventoryResult_t Invalid = new SteamInventoryResult_t(-1);

		// Token: 0x04000984 RID: 2436
		public int m_SteamInventoryResult;
	}
}
