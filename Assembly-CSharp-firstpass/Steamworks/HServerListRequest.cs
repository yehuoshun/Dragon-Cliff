using System;

namespace Steamworks
{
	// Token: 0x020001AB RID: 427
	[Serializable]
	public struct HServerListRequest : IEquatable<HServerListRequest>
	{
		// Token: 0x06000B45 RID: 2885 RVA: 0x0001A5CF File Offset: 0x000189CF
		public HServerListRequest(IntPtr value)
		{
			this.m_HServerListRequest = value;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0001A5D8 File Offset: 0x000189D8
		public override string ToString()
		{
			return this.m_HServerListRequest.ToString();
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0001A5EB File Offset: 0x000189EB
		public override bool Equals(object other)
		{
			return other is HServerListRequest && this == (HServerListRequest)other;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0001A60C File Offset: 0x00018A0C
		public override int GetHashCode()
		{
			return this.m_HServerListRequest.GetHashCode();
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0001A61F File Offset: 0x00018A1F
		public static bool operator ==(HServerListRequest x, HServerListRequest y)
		{
			return x.m_HServerListRequest == y.m_HServerListRequest;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0001A634 File Offset: 0x00018A34
		public static bool operator !=(HServerListRequest x, HServerListRequest y)
		{
			return !(x == y);
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0001A640 File Offset: 0x00018A40
		public static explicit operator HServerListRequest(IntPtr value)
		{
			return new HServerListRequest(value);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0001A648 File Offset: 0x00018A48
		public static explicit operator IntPtr(HServerListRequest that)
		{
			return that.m_HServerListRequest;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0001A651 File Offset: 0x00018A51
		public bool Equals(HServerListRequest other)
		{
			return this.m_HServerListRequest == other.m_HServerListRequest;
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x0001A665 File Offset: 0x00018A65
		// Note: this type is marked as 'beforefieldinit'.
		static HServerListRequest()
		{
		}

		// Token: 0x04000988 RID: 2440
		public static readonly HServerListRequest Invalid = new HServerListRequest(IntPtr.Zero);

		// Token: 0x04000989 RID: 2441
		public IntPtr m_HServerListRequest;
	}
}
