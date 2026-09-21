using System;

namespace Steamworks
{
	// Token: 0x020001B3 RID: 435
	[Serializable]
	public struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle>
	{
		// Token: 0x06000B9A RID: 2970 RVA: 0x0001AB37 File Offset: 0x00018F37
		public ScreenshotHandle(uint value)
		{
			this.m_ScreenshotHandle = value;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0001AB40 File Offset: 0x00018F40
		public override string ToString()
		{
			return this.m_ScreenshotHandle.ToString();
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0001AB53 File Offset: 0x00018F53
		public override bool Equals(object other)
		{
			return other is ScreenshotHandle && this == (ScreenshotHandle)other;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0001AB74 File Offset: 0x00018F74
		public override int GetHashCode()
		{
			return this.m_ScreenshotHandle.GetHashCode();
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0001AB87 File Offset: 0x00018F87
		public static bool operator ==(ScreenshotHandle x, ScreenshotHandle y)
		{
			return x.m_ScreenshotHandle == y.m_ScreenshotHandle;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0001AB99 File Offset: 0x00018F99
		public static bool operator !=(ScreenshotHandle x, ScreenshotHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0001ABA5 File Offset: 0x00018FA5
		public static explicit operator ScreenshotHandle(uint value)
		{
			return new ScreenshotHandle(value);
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0001ABAD File Offset: 0x00018FAD
		public static explicit operator uint(ScreenshotHandle that)
		{
			return that.m_ScreenshotHandle;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0001ABB6 File Offset: 0x00018FB6
		public bool Equals(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle == other.m_ScreenshotHandle;
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0001ABC7 File Offset: 0x00018FC7
		public int CompareTo(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle.CompareTo(other.m_ScreenshotHandle);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0001ABDB File Offset: 0x00018FDB
		// Note: this type is marked as 'beforefieldinit'.
		static ScreenshotHandle()
		{
		}

		// Token: 0x04000996 RID: 2454
		public static readonly ScreenshotHandle Invalid = new ScreenshotHandle(0u);

		// Token: 0x04000997 RID: 2455
		public uint m_ScreenshotHandle;
	}
}
