using System;

namespace Steamworks
{
	// Token: 0x020001B6 RID: 438
	[Serializable]
	public struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t>
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x0001AD3D File Offset: 0x0001913D
		public DepotId_t(uint value)
		{
			this.m_DepotId = value;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0001AD46 File Offset: 0x00019146
		public override string ToString()
		{
			return this.m_DepotId.ToString();
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0001AD59 File Offset: 0x00019159
		public override bool Equals(object other)
		{
			return other is DepotId_t && this == (DepotId_t)other;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0001AD7A File Offset: 0x0001917A
		public override int GetHashCode()
		{
			return this.m_DepotId.GetHashCode();
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0001AD8D File Offset: 0x0001918D
		public static bool operator ==(DepotId_t x, DepotId_t y)
		{
			return x.m_DepotId == y.m_DepotId;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0001AD9F File Offset: 0x0001919F
		public static bool operator !=(DepotId_t x, DepotId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0001ADAB File Offset: 0x000191AB
		public static explicit operator DepotId_t(uint value)
		{
			return new DepotId_t(value);
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0001ADB3 File Offset: 0x000191B3
		public static explicit operator uint(DepotId_t that)
		{
			return that.m_DepotId;
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0001ADBC File Offset: 0x000191BC
		public bool Equals(DepotId_t other)
		{
			return this.m_DepotId == other.m_DepotId;
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0001ADCD File Offset: 0x000191CD
		public int CompareTo(DepotId_t other)
		{
			return this.m_DepotId.CompareTo(other.m_DepotId);
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0001ADE1 File Offset: 0x000191E1
		// Note: this type is marked as 'beforefieldinit'.
		static DepotId_t()
		{
		}

		// Token: 0x0400099B RID: 2459
		public static readonly DepotId_t Invalid = new DepotId_t(0u);

		// Token: 0x0400099C RID: 2460
		public uint m_DepotId;
	}
}
