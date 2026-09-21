using System;

namespace Steamworks
{
	// Token: 0x020001B5 RID: 437
	[Serializable]
	public struct AppId_t : IEquatable<AppId_t>, IComparable<AppId_t>
	{
		// Token: 0x06000BAF RID: 2991 RVA: 0x0001AC8C File Offset: 0x0001908C
		public AppId_t(uint value)
		{
			this.m_AppId = value;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0001AC95 File Offset: 0x00019095
		public override string ToString()
		{
			return this.m_AppId.ToString();
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0001ACA8 File Offset: 0x000190A8
		public override bool Equals(object other)
		{
			return other is AppId_t && this == (AppId_t)other;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0001ACC9 File Offset: 0x000190C9
		public override int GetHashCode()
		{
			return this.m_AppId.GetHashCode();
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0001ACDC File Offset: 0x000190DC
		public static bool operator ==(AppId_t x, AppId_t y)
		{
			return x.m_AppId == y.m_AppId;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0001ACEE File Offset: 0x000190EE
		public static bool operator !=(AppId_t x, AppId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0001ACFA File Offset: 0x000190FA
		public static explicit operator AppId_t(uint value)
		{
			return new AppId_t(value);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0001AD02 File Offset: 0x00019102
		public static explicit operator uint(AppId_t that)
		{
			return that.m_AppId;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0001AD0B File Offset: 0x0001910B
		public bool Equals(AppId_t other)
		{
			return this.m_AppId == other.m_AppId;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0001AD1C File Offset: 0x0001911C
		public int CompareTo(AppId_t other)
		{
			return this.m_AppId.CompareTo(other.m_AppId);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0001AD30 File Offset: 0x00019130
		// Note: this type is marked as 'beforefieldinit'.
		static AppId_t()
		{
		}

		// Token: 0x04000999 RID: 2457
		public static readonly AppId_t Invalid = new AppId_t(0u);

		// Token: 0x0400099A RID: 2458
		public uint m_AppId;
	}
}
