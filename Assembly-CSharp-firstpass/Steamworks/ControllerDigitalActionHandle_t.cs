using System;

namespace Steamworks
{
	// Token: 0x020001A2 RID: 418
	[Serializable]
	public struct ControllerDigitalActionHandle_t : IEquatable<ControllerDigitalActionHandle_t>, IComparable<ControllerDigitalActionHandle_t>
	{
		// Token: 0x06000AE5 RID: 2789 RVA: 0x00019FBC File Offset: 0x000183BC
		public ControllerDigitalActionHandle_t(ulong value)
		{
			this.m_ControllerDigitalActionHandle = value;
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00019FC5 File Offset: 0x000183C5
		public override string ToString()
		{
			return this.m_ControllerDigitalActionHandle.ToString();
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00019FD8 File Offset: 0x000183D8
		public override bool Equals(object other)
		{
			return other is ControllerDigitalActionHandle_t && this == (ControllerDigitalActionHandle_t)other;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00019FF9 File Offset: 0x000183F9
		public override int GetHashCode()
		{
			return this.m_ControllerDigitalActionHandle.GetHashCode();
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0001A00C File Offset: 0x0001840C
		public static bool operator ==(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y)
		{
			return x.m_ControllerDigitalActionHandle == y.m_ControllerDigitalActionHandle;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0001A01E File Offset: 0x0001841E
		public static bool operator !=(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0001A02A File Offset: 0x0001842A
		public static explicit operator ControllerDigitalActionHandle_t(ulong value)
		{
			return new ControllerDigitalActionHandle_t(value);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0001A032 File Offset: 0x00018432
		public static explicit operator ulong(ControllerDigitalActionHandle_t that)
		{
			return that.m_ControllerDigitalActionHandle;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0001A03B File Offset: 0x0001843B
		public bool Equals(ControllerDigitalActionHandle_t other)
		{
			return this.m_ControllerDigitalActionHandle == other.m_ControllerDigitalActionHandle;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0001A04C File Offset: 0x0001844C
		public int CompareTo(ControllerDigitalActionHandle_t other)
		{
			return this.m_ControllerDigitalActionHandle.CompareTo(other.m_ControllerDigitalActionHandle);
		}

		// Token: 0x04000979 RID: 2425
		public ulong m_ControllerDigitalActionHandle;
	}
}
