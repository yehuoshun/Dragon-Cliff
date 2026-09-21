using System;

namespace Steamworks
{
	// Token: 0x0200019F RID: 415
	[Serializable]
	public struct HAuthTicket : IEquatable<HAuthTicket>, IComparable<HAuthTicket>
	{
		// Token: 0x06000AC6 RID: 2758 RVA: 0x00019DC3 File Offset: 0x000181C3
		public HAuthTicket(uint value)
		{
			this.m_HAuthTicket = value;
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00019DCC File Offset: 0x000181CC
		public override string ToString()
		{
			return this.m_HAuthTicket.ToString();
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00019DDF File Offset: 0x000181DF
		public override bool Equals(object other)
		{
			return other is HAuthTicket && this == (HAuthTicket)other;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00019E00 File Offset: 0x00018200
		public override int GetHashCode()
		{
			return this.m_HAuthTicket.GetHashCode();
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00019E13 File Offset: 0x00018213
		public static bool operator ==(HAuthTicket x, HAuthTicket y)
		{
			return x.m_HAuthTicket == y.m_HAuthTicket;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00019E25 File Offset: 0x00018225
		public static bool operator !=(HAuthTicket x, HAuthTicket y)
		{
			return !(x == y);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00019E31 File Offset: 0x00018231
		public static explicit operator HAuthTicket(uint value)
		{
			return new HAuthTicket(value);
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00019E39 File Offset: 0x00018239
		public static explicit operator uint(HAuthTicket that)
		{
			return that.m_HAuthTicket;
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00019E42 File Offset: 0x00018242
		public bool Equals(HAuthTicket other)
		{
			return this.m_HAuthTicket == other.m_HAuthTicket;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00019E53 File Offset: 0x00018253
		public int CompareTo(HAuthTicket other)
		{
			return this.m_HAuthTicket.CompareTo(other.m_HAuthTicket);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00019E67 File Offset: 0x00018267
		// Note: this type is marked as 'beforefieldinit'.
		static HAuthTicket()
		{
		}

		// Token: 0x04000975 RID: 2421
		public static readonly HAuthTicket Invalid = new HAuthTicket(0u);

		// Token: 0x04000976 RID: 2422
		public uint m_HAuthTicket;
	}
}
