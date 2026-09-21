using System;

namespace Steamworks
{
	// Token: 0x020001B2 RID: 434
	[Serializable]
	public struct UGCHandle_t : IEquatable<UGCHandle_t>, IComparable<UGCHandle_t>
	{
		// Token: 0x06000B8F RID: 2959 RVA: 0x0001AA85 File Offset: 0x00018E85
		public UGCHandle_t(ulong value)
		{
			this.m_UGCHandle = value;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0001AA8E File Offset: 0x00018E8E
		public override string ToString()
		{
			return this.m_UGCHandle.ToString();
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0001AAA1 File Offset: 0x00018EA1
		public override bool Equals(object other)
		{
			return other is UGCHandle_t && this == (UGCHandle_t)other;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0001AAC2 File Offset: 0x00018EC2
		public override int GetHashCode()
		{
			return this.m_UGCHandle.GetHashCode();
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0001AAD5 File Offset: 0x00018ED5
		public static bool operator ==(UGCHandle_t x, UGCHandle_t y)
		{
			return x.m_UGCHandle == y.m_UGCHandle;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0001AAE7 File Offset: 0x00018EE7
		public static bool operator !=(UGCHandle_t x, UGCHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0001AAF3 File Offset: 0x00018EF3
		public static explicit operator UGCHandle_t(ulong value)
		{
			return new UGCHandle_t(value);
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0001AAFB File Offset: 0x00018EFB
		public static explicit operator ulong(UGCHandle_t that)
		{
			return that.m_UGCHandle;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0001AB04 File Offset: 0x00018F04
		public bool Equals(UGCHandle_t other)
		{
			return this.m_UGCHandle == other.m_UGCHandle;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0001AB15 File Offset: 0x00018F15
		public int CompareTo(UGCHandle_t other)
		{
			return this.m_UGCHandle.CompareTo(other.m_UGCHandle);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0001AB29 File Offset: 0x00018F29
		// Note: this type is marked as 'beforefieldinit'.
		static UGCHandle_t()
		{
		}

		// Token: 0x04000994 RID: 2452
		public static readonly UGCHandle_t Invalid = new UGCHandle_t(ulong.MaxValue);

		// Token: 0x04000995 RID: 2453
		public ulong m_UGCHandle;
	}
}
