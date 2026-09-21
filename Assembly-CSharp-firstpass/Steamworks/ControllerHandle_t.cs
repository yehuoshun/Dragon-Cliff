using System;

namespace Steamworks
{
	// Token: 0x020001A3 RID: 419
	[Serializable]
	public struct ControllerHandle_t : IEquatable<ControllerHandle_t>, IComparable<ControllerHandle_t>
	{
		// Token: 0x06000AEF RID: 2799 RVA: 0x0001A060 File Offset: 0x00018460
		public ControllerHandle_t(ulong value)
		{
			this.m_ControllerHandle = value;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0001A069 File Offset: 0x00018469
		public override string ToString()
		{
			return this.m_ControllerHandle.ToString();
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0001A07C File Offset: 0x0001847C
		public override bool Equals(object other)
		{
			return other is ControllerHandle_t && this == (ControllerHandle_t)other;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0001A09D File Offset: 0x0001849D
		public override int GetHashCode()
		{
			return this.m_ControllerHandle.GetHashCode();
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0001A0B0 File Offset: 0x000184B0
		public static bool operator ==(ControllerHandle_t x, ControllerHandle_t y)
		{
			return x.m_ControllerHandle == y.m_ControllerHandle;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0001A0C2 File Offset: 0x000184C2
		public static bool operator !=(ControllerHandle_t x, ControllerHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0001A0CE File Offset: 0x000184CE
		public static explicit operator ControllerHandle_t(ulong value)
		{
			return new ControllerHandle_t(value);
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0001A0D6 File Offset: 0x000184D6
		public static explicit operator ulong(ControllerHandle_t that)
		{
			return that.m_ControllerHandle;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0001A0DF File Offset: 0x000184DF
		public bool Equals(ControllerHandle_t other)
		{
			return this.m_ControllerHandle == other.m_ControllerHandle;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0001A0F0 File Offset: 0x000184F0
		public int CompareTo(ControllerHandle_t other)
		{
			return this.m_ControllerHandle.CompareTo(other.m_ControllerHandle);
		}

		// Token: 0x0400097A RID: 2426
		public ulong m_ControllerHandle;
	}
}
