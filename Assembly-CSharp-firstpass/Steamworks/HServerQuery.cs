using System;

namespace Steamworks
{
	// Token: 0x020001AC RID: 428
	[Serializable]
	public struct HServerQuery : IEquatable<HServerQuery>, IComparable<HServerQuery>
	{
		// Token: 0x06000B4F RID: 2895 RVA: 0x0001A676 File Offset: 0x00018A76
		public HServerQuery(int value)
		{
			this.m_HServerQuery = value;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0001A67F File Offset: 0x00018A7F
		public override string ToString()
		{
			return this.m_HServerQuery.ToString();
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0001A692 File Offset: 0x00018A92
		public override bool Equals(object other)
		{
			return other is HServerQuery && this == (HServerQuery)other;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0001A6B3 File Offset: 0x00018AB3
		public override int GetHashCode()
		{
			return this.m_HServerQuery.GetHashCode();
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0001A6C6 File Offset: 0x00018AC6
		public static bool operator ==(HServerQuery x, HServerQuery y)
		{
			return x.m_HServerQuery == y.m_HServerQuery;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0001A6D8 File Offset: 0x00018AD8
		public static bool operator !=(HServerQuery x, HServerQuery y)
		{
			return !(x == y);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0001A6E4 File Offset: 0x00018AE4
		public static explicit operator HServerQuery(int value)
		{
			return new HServerQuery(value);
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0001A6EC File Offset: 0x00018AEC
		public static explicit operator int(HServerQuery that)
		{
			return that.m_HServerQuery;
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0001A6F5 File Offset: 0x00018AF5
		public bool Equals(HServerQuery other)
		{
			return this.m_HServerQuery == other.m_HServerQuery;
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0001A706 File Offset: 0x00018B06
		public int CompareTo(HServerQuery other)
		{
			return this.m_HServerQuery.CompareTo(other.m_HServerQuery);
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0001A71A File Offset: 0x00018B1A
		// Note: this type is marked as 'beforefieldinit'.
		static HServerQuery()
		{
		}

		// Token: 0x0400098A RID: 2442
		public static readonly HServerQuery Invalid = new HServerQuery(-1);

		// Token: 0x0400098B RID: 2443
		public int m_HServerQuery;
	}
}
