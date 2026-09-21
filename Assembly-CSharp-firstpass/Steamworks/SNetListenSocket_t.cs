using System;

namespace Steamworks
{
	// Token: 0x020001AD RID: 429
	[Serializable]
	public struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		// Token: 0x06000B5A RID: 2906 RVA: 0x0001A727 File Offset: 0x00018B27
		public SNetListenSocket_t(uint value)
		{
			this.m_SNetListenSocket = value;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0001A730 File Offset: 0x00018B30
		public override string ToString()
		{
			return this.m_SNetListenSocket.ToString();
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0001A743 File Offset: 0x00018B43
		public override bool Equals(object other)
		{
			return other is SNetListenSocket_t && this == (SNetListenSocket_t)other;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0001A764 File Offset: 0x00018B64
		public override int GetHashCode()
		{
			return this.m_SNetListenSocket.GetHashCode();
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0001A777 File Offset: 0x00018B77
		public static bool operator ==(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return x.m_SNetListenSocket == y.m_SNetListenSocket;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0001A789 File Offset: 0x00018B89
		public static bool operator !=(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0001A795 File Offset: 0x00018B95
		public static explicit operator SNetListenSocket_t(uint value)
		{
			return new SNetListenSocket_t(value);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0001A79D File Offset: 0x00018B9D
		public static explicit operator uint(SNetListenSocket_t that)
		{
			return that.m_SNetListenSocket;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0001A7A6 File Offset: 0x00018BA6
		public bool Equals(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket == other.m_SNetListenSocket;
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0001A7B7 File Offset: 0x00018BB7
		public int CompareTo(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket.CompareTo(other.m_SNetListenSocket);
		}

		// Token: 0x0400098C RID: 2444
		public uint m_SNetListenSocket;
	}
}
