using System;

namespace Steamworks
{
	// Token: 0x020001A7 RID: 423
	[Serializable]
	public struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>, IComparable<HTTPRequestHandle>
	{
		// Token: 0x06000B1A RID: 2842 RVA: 0x0001A317 File Offset: 0x00018717
		public HTTPRequestHandle(uint value)
		{
			this.m_HTTPRequestHandle = value;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0001A320 File Offset: 0x00018720
		public override string ToString()
		{
			return this.m_HTTPRequestHandle.ToString();
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0001A333 File Offset: 0x00018733
		public override bool Equals(object other)
		{
			return other is HTTPRequestHandle && this == (HTTPRequestHandle)other;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0001A354 File Offset: 0x00018754
		public override int GetHashCode()
		{
			return this.m_HTTPRequestHandle.GetHashCode();
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0001A367 File Offset: 0x00018767
		public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return x.m_HTTPRequestHandle == y.m_HTTPRequestHandle;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0001A379 File Offset: 0x00018779
		public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0001A385 File Offset: 0x00018785
		public static explicit operator HTTPRequestHandle(uint value)
		{
			return new HTTPRequestHandle(value);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0001A38D File Offset: 0x0001878D
		public static explicit operator uint(HTTPRequestHandle that)
		{
			return that.m_HTTPRequestHandle;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0001A396 File Offset: 0x00018796
		public bool Equals(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle == other.m_HTTPRequestHandle;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0001A3A7 File Offset: 0x000187A7
		public int CompareTo(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle.CompareTo(other.m_HTTPRequestHandle);
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0001A3BB File Offset: 0x000187BB
		// Note: this type is marked as 'beforefieldinit'.
		static HTTPRequestHandle()
		{
		}

		// Token: 0x04000981 RID: 2433
		public static readonly HTTPRequestHandle Invalid = new HTTPRequestHandle(0u);

		// Token: 0x04000982 RID: 2434
		public uint m_HTTPRequestHandle;
	}
}
