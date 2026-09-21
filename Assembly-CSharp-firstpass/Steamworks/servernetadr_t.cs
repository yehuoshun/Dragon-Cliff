using System;

namespace Steamworks
{
	// Token: 0x02000197 RID: 407
	[Serializable]
	public struct servernetadr_t
	{
		// Token: 0x06000A56 RID: 2646 RVA: 0x00019315 File Offset: 0x00017715
		public void Init(uint ip, ushort usQueryPort, ushort usConnectionPort)
		{
			this.m_unIP = ip;
			this.m_usQueryPort = usQueryPort;
			this.m_usConnectionPort = usConnectionPort;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0001932C File Offset: 0x0001772C
		public ushort GetQueryPort()
		{
			return this.m_usQueryPort;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00019334 File Offset: 0x00017734
		public void SetQueryPort(ushort usPort)
		{
			this.m_usQueryPort = usPort;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0001933D File Offset: 0x0001773D
		public ushort GetConnectionPort()
		{
			return this.m_usConnectionPort;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00019345 File Offset: 0x00017745
		public void SetConnectionPort(ushort usPort)
		{
			this.m_usConnectionPort = usPort;
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0001934E File Offset: 0x0001774E
		public uint GetIP()
		{
			return this.m_unIP;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00019356 File Offset: 0x00017756
		public void SetIP(uint unIP)
		{
			this.m_unIP = unIP;
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0001935F File Offset: 0x0001775F
		public string GetConnectionAddressString()
		{
			return servernetadr_t.ToString(this.m_unIP, this.m_usConnectionPort);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00019372 File Offset: 0x00017772
		public string GetQueryAddressString()
		{
			return servernetadr_t.ToString(this.m_unIP, this.m_usQueryPort);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00019388 File Offset: 0x00017788
		public static string ToString(uint unIP, ushort usPort)
		{
			return string.Format("{0}.{1}.{2}.{3}:{4}", new object[]
			{
				(ulong)(unIP >> 24) & 255UL,
				(ulong)(unIP >> 16) & 255UL,
				(ulong)(unIP >> 8) & 255UL,
				(ulong)unIP & 255UL,
				usPort
			});
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x000193FA File Offset: 0x000177FA
		public static bool operator <(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP < y.m_unIP || (x.m_unIP == y.m_unIP && x.m_usQueryPort < y.m_usQueryPort);
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00019438 File Offset: 0x00017838
		public static bool operator >(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP > y.m_unIP || (x.m_unIP == y.m_unIP && x.m_usQueryPort > y.m_usQueryPort);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00019476 File Offset: 0x00017876
		public override bool Equals(object other)
		{
			return other is servernetadr_t && this == (servernetadr_t)other;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00019497 File Offset: 0x00017897
		public override int GetHashCode()
		{
			return this.m_unIP.GetHashCode() + this.m_usQueryPort.GetHashCode() + this.m_usConnectionPort.GetHashCode();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x000194CE File Offset: 0x000178CE
		public static bool operator ==(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP == y.m_unIP && x.m_usQueryPort == y.m_usQueryPort && x.m_usConnectionPort == y.m_usConnectionPort;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00019509 File Offset: 0x00017909
		public static bool operator !=(servernetadr_t x, servernetadr_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00019515 File Offset: 0x00017915
		public bool Equals(servernetadr_t other)
		{
			return this.m_unIP == other.m_unIP && this.m_usQueryPort == other.m_usQueryPort && this.m_usConnectionPort == other.m_usConnectionPort;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0001954D File Offset: 0x0001794D
		public int CompareTo(servernetadr_t other)
		{
			return this.m_unIP.CompareTo(other.m_unIP) + this.m_usQueryPort.CompareTo(other.m_usQueryPort) + this.m_usConnectionPort.CompareTo(other.m_usConnectionPort);
		}

		// Token: 0x04000964 RID: 2404
		private ushort m_usConnectionPort;

		// Token: 0x04000965 RID: 2405
		private ushort m_usQueryPort;

		// Token: 0x04000966 RID: 2406
		private uint m_unIP;
	}
}
