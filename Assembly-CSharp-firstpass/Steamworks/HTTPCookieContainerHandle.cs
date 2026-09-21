using System;

namespace Steamworks
{
	// Token: 0x020001A6 RID: 422
	[Serializable]
	public struct HTTPCookieContainerHandle : IEquatable<HTTPCookieContainerHandle>, IComparable<HTTPCookieContainerHandle>
	{
		// Token: 0x06000B0F RID: 2831 RVA: 0x0001A266 File Offset: 0x00018666
		public HTTPCookieContainerHandle(uint value)
		{
			this.m_HTTPCookieContainerHandle = value;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001A26F File Offset: 0x0001866F
		public override string ToString()
		{
			return this.m_HTTPCookieContainerHandle.ToString();
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0001A282 File Offset: 0x00018682
		public override bool Equals(object other)
		{
			return other is HTTPCookieContainerHandle && this == (HTTPCookieContainerHandle)other;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0001A2A3 File Offset: 0x000186A3
		public override int GetHashCode()
		{
			return this.m_HTTPCookieContainerHandle.GetHashCode();
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0001A2B6 File Offset: 0x000186B6
		public static bool operator ==(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return x.m_HTTPCookieContainerHandle == y.m_HTTPCookieContainerHandle;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0001A2C8 File Offset: 0x000186C8
		public static bool operator !=(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0001A2D4 File Offset: 0x000186D4
		public static explicit operator HTTPCookieContainerHandle(uint value)
		{
			return new HTTPCookieContainerHandle(value);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0001A2DC File Offset: 0x000186DC
		public static explicit operator uint(HTTPCookieContainerHandle that)
		{
			return that.m_HTTPCookieContainerHandle;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0001A2E5 File Offset: 0x000186E5
		public bool Equals(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle == other.m_HTTPCookieContainerHandle;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0001A2F6 File Offset: 0x000186F6
		public int CompareTo(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle.CompareTo(other.m_HTTPCookieContainerHandle);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0001A30A File Offset: 0x0001870A
		// Note: this type is marked as 'beforefieldinit'.
		static HTTPCookieContainerHandle()
		{
		}

		// Token: 0x0400097F RID: 2431
		public static readonly HTTPCookieContainerHandle Invalid = new HTTPCookieContainerHandle(0u);

		// Token: 0x04000980 RID: 2432
		public uint m_HTTPCookieContainerHandle;
	}
}
