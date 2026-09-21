using System;

namespace Steamworks
{
	// Token: 0x020001BA RID: 442
	[Serializable]
	public struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t>
	{
		// Token: 0x06000BE6 RID: 3046 RVA: 0x0001B004 File Offset: 0x00019404
		public UGCUpdateHandle_t(ulong value)
		{
			this.m_UGCUpdateHandle = value;
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x0001B00D File Offset: 0x0001940D
		public override string ToString()
		{
			return this.m_UGCUpdateHandle.ToString();
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0001B020 File Offset: 0x00019420
		public override bool Equals(object other)
		{
			return other is UGCUpdateHandle_t && this == (UGCUpdateHandle_t)other;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0001B041 File Offset: 0x00019441
		public override int GetHashCode()
		{
			return this.m_UGCUpdateHandle.GetHashCode();
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0001B054 File Offset: 0x00019454
		public static bool operator ==(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return x.m_UGCUpdateHandle == y.m_UGCUpdateHandle;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0001B066 File Offset: 0x00019466
		public static bool operator !=(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0001B072 File Offset: 0x00019472
		public static explicit operator UGCUpdateHandle_t(ulong value)
		{
			return new UGCUpdateHandle_t(value);
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0001B07A File Offset: 0x0001947A
		public static explicit operator ulong(UGCUpdateHandle_t that)
		{
			return that.m_UGCUpdateHandle;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0001B083 File Offset: 0x00019483
		public bool Equals(UGCUpdateHandle_t other)
		{
			return this.m_UGCUpdateHandle == other.m_UGCUpdateHandle;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0001B094 File Offset: 0x00019494
		public int CompareTo(UGCUpdateHandle_t other)
		{
			return this.m_UGCUpdateHandle.CompareTo(other.m_UGCUpdateHandle);
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0001B0A8 File Offset: 0x000194A8
		// Note: this type is marked as 'beforefieldinit'.
		static UGCUpdateHandle_t()
		{
		}

		// Token: 0x040009A3 RID: 2467
		public static readonly UGCUpdateHandle_t Invalid = new UGCUpdateHandle_t(ulong.MaxValue);

		// Token: 0x040009A4 RID: 2468
		public ulong m_UGCUpdateHandle;
	}
}
