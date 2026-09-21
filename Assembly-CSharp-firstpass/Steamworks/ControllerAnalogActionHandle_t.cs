using System;

namespace Steamworks
{
	// Token: 0x020001A1 RID: 417
	[Serializable]
	public struct ControllerAnalogActionHandle_t : IEquatable<ControllerAnalogActionHandle_t>, IComparable<ControllerAnalogActionHandle_t>
	{
		// Token: 0x06000ADB RID: 2779 RVA: 0x00019F18 File Offset: 0x00018318
		public ControllerAnalogActionHandle_t(ulong value)
		{
			this.m_ControllerAnalogActionHandle = value;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00019F21 File Offset: 0x00018321
		public override string ToString()
		{
			return this.m_ControllerAnalogActionHandle.ToString();
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00019F34 File Offset: 0x00018334
		public override bool Equals(object other)
		{
			return other is ControllerAnalogActionHandle_t && this == (ControllerAnalogActionHandle_t)other;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00019F55 File Offset: 0x00018355
		public override int GetHashCode()
		{
			return this.m_ControllerAnalogActionHandle.GetHashCode();
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00019F68 File Offset: 0x00018368
		public static bool operator ==(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y)
		{
			return x.m_ControllerAnalogActionHandle == y.m_ControllerAnalogActionHandle;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00019F7A File Offset: 0x0001837A
		public static bool operator !=(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x00019F86 File Offset: 0x00018386
		public static explicit operator ControllerAnalogActionHandle_t(ulong value)
		{
			return new ControllerAnalogActionHandle_t(value);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x00019F8E File Offset: 0x0001838E
		public static explicit operator ulong(ControllerAnalogActionHandle_t that)
		{
			return that.m_ControllerAnalogActionHandle;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00019F97 File Offset: 0x00018397
		public bool Equals(ControllerAnalogActionHandle_t other)
		{
			return this.m_ControllerAnalogActionHandle == other.m_ControllerAnalogActionHandle;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00019FA8 File Offset: 0x000183A8
		public int CompareTo(ControllerAnalogActionHandle_t other)
		{
			return this.m_ControllerAnalogActionHandle.CompareTo(other.m_ControllerAnalogActionHandle);
		}

		// Token: 0x04000978 RID: 2424
		public ulong m_ControllerAnalogActionHandle;
	}
}
