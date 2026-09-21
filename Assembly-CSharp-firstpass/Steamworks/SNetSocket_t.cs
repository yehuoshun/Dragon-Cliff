using System;

namespace Steamworks
{
	// Token: 0x020001AE RID: 430
	[Serializable]
	public struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t>
	{
		// Token: 0x06000B64 RID: 2916 RVA: 0x0001A7CB File Offset: 0x00018BCB
		public SNetSocket_t(uint value)
		{
			this.m_SNetSocket = value;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0001A7D4 File Offset: 0x00018BD4
		public override string ToString()
		{
			return this.m_SNetSocket.ToString();
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0001A7E7 File Offset: 0x00018BE7
		public override bool Equals(object other)
		{
			return other is SNetSocket_t && this == (SNetSocket_t)other;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0001A808 File Offset: 0x00018C08
		public override int GetHashCode()
		{
			return this.m_SNetSocket.GetHashCode();
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0001A81B File Offset: 0x00018C1B
		public static bool operator ==(SNetSocket_t x, SNetSocket_t y)
		{
			return x.m_SNetSocket == y.m_SNetSocket;
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0001A82D File Offset: 0x00018C2D
		public static bool operator !=(SNetSocket_t x, SNetSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0001A839 File Offset: 0x00018C39
		public static explicit operator SNetSocket_t(uint value)
		{
			return new SNetSocket_t(value);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0001A841 File Offset: 0x00018C41
		public static explicit operator uint(SNetSocket_t that)
		{
			return that.m_SNetSocket;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0001A84A File Offset: 0x00018C4A
		public bool Equals(SNetSocket_t other)
		{
			return this.m_SNetSocket == other.m_SNetSocket;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0001A85B File Offset: 0x00018C5B
		public int CompareTo(SNetSocket_t other)
		{
			return this.m_SNetSocket.CompareTo(other.m_SNetSocket);
		}

		// Token: 0x0400098D RID: 2445
		public uint m_SNetSocket;
	}
}
