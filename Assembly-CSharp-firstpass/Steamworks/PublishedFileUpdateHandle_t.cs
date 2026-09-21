using System;

namespace Steamworks
{
	// Token: 0x020001B0 RID: 432
	[Serializable]
	public struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		// Token: 0x06000B79 RID: 2937 RVA: 0x0001A921 File Offset: 0x00018D21
		public PublishedFileUpdateHandle_t(ulong value)
		{
			this.m_PublishedFileUpdateHandle = value;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0001A92A File Offset: 0x00018D2A
		public override string ToString()
		{
			return this.m_PublishedFileUpdateHandle.ToString();
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0001A93D File Offset: 0x00018D3D
		public override bool Equals(object other)
		{
			return other is PublishedFileUpdateHandle_t && this == (PublishedFileUpdateHandle_t)other;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0001A95E File Offset: 0x00018D5E
		public override int GetHashCode()
		{
			return this.m_PublishedFileUpdateHandle.GetHashCode();
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0001A971 File Offset: 0x00018D71
		public static bool operator ==(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return x.m_PublishedFileUpdateHandle == y.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0001A983 File Offset: 0x00018D83
		public static bool operator !=(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0001A98F File Offset: 0x00018D8F
		public static explicit operator PublishedFileUpdateHandle_t(ulong value)
		{
			return new PublishedFileUpdateHandle_t(value);
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0001A997 File Offset: 0x00018D97
		public static explicit operator ulong(PublishedFileUpdateHandle_t that)
		{
			return that.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0001A9A0 File Offset: 0x00018DA0
		public bool Equals(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle == other.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0001A9B1 File Offset: 0x00018DB1
		public int CompareTo(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle.CompareTo(other.m_PublishedFileUpdateHandle);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0001A9C5 File Offset: 0x00018DC5
		// Note: this type is marked as 'beforefieldinit'.
		static PublishedFileUpdateHandle_t()
		{
		}

		// Token: 0x04000990 RID: 2448
		public static readonly PublishedFileUpdateHandle_t Invalid = new PublishedFileUpdateHandle_t(ulong.MaxValue);

		// Token: 0x04000991 RID: 2449
		public ulong m_PublishedFileUpdateHandle;
	}
}
