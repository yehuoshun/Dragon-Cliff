using System;

namespace Steamworks
{
	// Token: 0x020001A0 RID: 416
	[Serializable]
	public struct ControllerActionSetHandle_t : IEquatable<ControllerActionSetHandle_t>, IComparable<ControllerActionSetHandle_t>
	{
		// Token: 0x06000AD1 RID: 2769 RVA: 0x00019E74 File Offset: 0x00018274
		public ControllerActionSetHandle_t(ulong value)
		{
			this.m_ControllerActionSetHandle = value;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00019E7D File Offset: 0x0001827D
		public override string ToString()
		{
			return this.m_ControllerActionSetHandle.ToString();
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00019E90 File Offset: 0x00018290
		public override bool Equals(object other)
		{
			return other is ControllerActionSetHandle_t && this == (ControllerActionSetHandle_t)other;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00019EB1 File Offset: 0x000182B1
		public override int GetHashCode()
		{
			return this.m_ControllerActionSetHandle.GetHashCode();
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00019EC4 File Offset: 0x000182C4
		public static bool operator ==(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y)
		{
			return x.m_ControllerActionSetHandle == y.m_ControllerActionSetHandle;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00019ED6 File Offset: 0x000182D6
		public static bool operator !=(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00019EE2 File Offset: 0x000182E2
		public static explicit operator ControllerActionSetHandle_t(ulong value)
		{
			return new ControllerActionSetHandle_t(value);
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00019EEA File Offset: 0x000182EA
		public static explicit operator ulong(ControllerActionSetHandle_t that)
		{
			return that.m_ControllerActionSetHandle;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00019EF3 File Offset: 0x000182F3
		public bool Equals(ControllerActionSetHandle_t other)
		{
			return this.m_ControllerActionSetHandle == other.m_ControllerActionSetHandle;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x00019F04 File Offset: 0x00018304
		public int CompareTo(ControllerActionSetHandle_t other)
		{
			return this.m_ControllerActionSetHandle.CompareTo(other.m_ControllerActionSetHandle);
		}

		// Token: 0x04000977 RID: 2423
		public ulong m_ControllerActionSetHandle;
	}
}
