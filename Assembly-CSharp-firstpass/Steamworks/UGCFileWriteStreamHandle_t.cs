using System;

namespace Steamworks
{
	// Token: 0x020001B1 RID: 433
	[Serializable]
	public struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t>
	{
		// Token: 0x06000B84 RID: 2948 RVA: 0x0001A9D3 File Offset: 0x00018DD3
		public UGCFileWriteStreamHandle_t(ulong value)
		{
			this.m_UGCFileWriteStreamHandle = value;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0001A9DC File Offset: 0x00018DDC
		public override string ToString()
		{
			return this.m_UGCFileWriteStreamHandle.ToString();
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0001A9EF File Offset: 0x00018DEF
		public override bool Equals(object other)
		{
			return other is UGCFileWriteStreamHandle_t && this == (UGCFileWriteStreamHandle_t)other;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0001AA10 File Offset: 0x00018E10
		public override int GetHashCode()
		{
			return this.m_UGCFileWriteStreamHandle.GetHashCode();
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0001AA23 File Offset: 0x00018E23
		public static bool operator ==(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return x.m_UGCFileWriteStreamHandle == y.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0001AA35 File Offset: 0x00018E35
		public static bool operator !=(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0001AA41 File Offset: 0x00018E41
		public static explicit operator UGCFileWriteStreamHandle_t(ulong value)
		{
			return new UGCFileWriteStreamHandle_t(value);
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0001AA49 File Offset: 0x00018E49
		public static explicit operator ulong(UGCFileWriteStreamHandle_t that)
		{
			return that.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x0001AA52 File Offset: 0x00018E52
		public bool Equals(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle == other.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0001AA63 File Offset: 0x00018E63
		public int CompareTo(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle.CompareTo(other.m_UGCFileWriteStreamHandle);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0001AA77 File Offset: 0x00018E77
		// Note: this type is marked as 'beforefieldinit'.
		static UGCFileWriteStreamHandle_t()
		{
		}

		// Token: 0x04000992 RID: 2450
		public static readonly UGCFileWriteStreamHandle_t Invalid = new UGCFileWriteStreamHandle_t(ulong.MaxValue);

		// Token: 0x04000993 RID: 2451
		public ulong m_UGCFileWriteStreamHandle;
	}
}
