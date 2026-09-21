using System;

namespace Steamworks
{
	// Token: 0x020001B9 RID: 441
	[Serializable]
	public struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t>
	{
		// Token: 0x06000BDB RID: 3035 RVA: 0x0001AF52 File Offset: 0x00019352
		public UGCQueryHandle_t(ulong value)
		{
			this.m_UGCQueryHandle = value;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0001AF5B File Offset: 0x0001935B
		public override string ToString()
		{
			return this.m_UGCQueryHandle.ToString();
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0001AF6E File Offset: 0x0001936E
		public override bool Equals(object other)
		{
			return other is UGCQueryHandle_t && this == (UGCQueryHandle_t)other;
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0001AF8F File Offset: 0x0001938F
		public override int GetHashCode()
		{
			return this.m_UGCQueryHandle.GetHashCode();
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0001AFA2 File Offset: 0x000193A2
		public static bool operator ==(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return x.m_UGCQueryHandle == y.m_UGCQueryHandle;
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0001AFB4 File Offset: 0x000193B4
		public static bool operator !=(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0001AFC0 File Offset: 0x000193C0
		public static explicit operator UGCQueryHandle_t(ulong value)
		{
			return new UGCQueryHandle_t(value);
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0001AFC8 File Offset: 0x000193C8
		public static explicit operator ulong(UGCQueryHandle_t that)
		{
			return that.m_UGCQueryHandle;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0001AFD1 File Offset: 0x000193D1
		public bool Equals(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle == other.m_UGCQueryHandle;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0001AFE2 File Offset: 0x000193E2
		public int CompareTo(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle.CompareTo(other.m_UGCQueryHandle);
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0001AFF6 File Offset: 0x000193F6
		// Note: this type is marked as 'beforefieldinit'.
		static UGCQueryHandle_t()
		{
		}

		// Token: 0x040009A1 RID: 2465
		public static readonly UGCQueryHandle_t Invalid = new UGCQueryHandle_t(ulong.MaxValue);

		// Token: 0x040009A2 RID: 2466
		public ulong m_UGCQueryHandle;
	}
}
