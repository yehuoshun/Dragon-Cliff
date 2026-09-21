using System;

namespace Steamworks
{
	// Token: 0x02000198 RID: 408
	[Serializable]
	public struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe>
	{
		// Token: 0x06000A68 RID: 2664 RVA: 0x00019587 File Offset: 0x00017987
		public HSteamPipe(int value)
		{
			this.m_HSteamPipe = value;
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00019590 File Offset: 0x00017990
		public override string ToString()
		{
			return this.m_HSteamPipe.ToString();
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x000195A3 File Offset: 0x000179A3
		public override bool Equals(object other)
		{
			return other is HSteamPipe && this == (HSteamPipe)other;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x000195C4 File Offset: 0x000179C4
		public override int GetHashCode()
		{
			return this.m_HSteamPipe.GetHashCode();
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x000195D7 File Offset: 0x000179D7
		public static bool operator ==(HSteamPipe x, HSteamPipe y)
		{
			return x.m_HSteamPipe == y.m_HSteamPipe;
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x000195E9 File Offset: 0x000179E9
		public static bool operator !=(HSteamPipe x, HSteamPipe y)
		{
			return !(x == y);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x000195F5 File Offset: 0x000179F5
		public static explicit operator HSteamPipe(int value)
		{
			return new HSteamPipe(value);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x000195FD File Offset: 0x000179FD
		public static explicit operator int(HSteamPipe that)
		{
			return that.m_HSteamPipe;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00019606 File Offset: 0x00017A06
		public bool Equals(HSteamPipe other)
		{
			return this.m_HSteamPipe == other.m_HSteamPipe;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00019617 File Offset: 0x00017A17
		public int CompareTo(HSteamPipe other)
		{
			return this.m_HSteamPipe.CompareTo(other.m_HSteamPipe);
		}

		// Token: 0x04000967 RID: 2407
		public int m_HSteamPipe;
	}
}
