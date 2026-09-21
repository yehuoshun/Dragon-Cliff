using System;

namespace Steamworks
{
	// Token: 0x020001BB RID: 443
	[Serializable]
	public struct ClientUnifiedMessageHandle : IEquatable<ClientUnifiedMessageHandle>, IComparable<ClientUnifiedMessageHandle>
	{
		// Token: 0x06000BF1 RID: 3057 RVA: 0x0001B0B6 File Offset: 0x000194B6
		public ClientUnifiedMessageHandle(ulong value)
		{
			this.m_ClientUnifiedMessageHandle = value;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0001B0BF File Offset: 0x000194BF
		public override string ToString()
		{
			return this.m_ClientUnifiedMessageHandle.ToString();
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0001B0D2 File Offset: 0x000194D2
		public override bool Equals(object other)
		{
			return other is ClientUnifiedMessageHandle && this == (ClientUnifiedMessageHandle)other;
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0001B0F3 File Offset: 0x000194F3
		public override int GetHashCode()
		{
			return this.m_ClientUnifiedMessageHandle.GetHashCode();
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0001B106 File Offset: 0x00019506
		public static bool operator ==(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return x.m_ClientUnifiedMessageHandle == y.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0001B118 File Offset: 0x00019518
		public static bool operator !=(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0001B124 File Offset: 0x00019524
		public static explicit operator ClientUnifiedMessageHandle(ulong value)
		{
			return new ClientUnifiedMessageHandle(value);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0001B12C File Offset: 0x0001952C
		public static explicit operator ulong(ClientUnifiedMessageHandle that)
		{
			return that.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0001B135 File Offset: 0x00019535
		public bool Equals(ClientUnifiedMessageHandle other)
		{
			return this.m_ClientUnifiedMessageHandle == other.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0001B146 File Offset: 0x00019546
		public int CompareTo(ClientUnifiedMessageHandle other)
		{
			return this.m_ClientUnifiedMessageHandle.CompareTo(other.m_ClientUnifiedMessageHandle);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0001B15A File Offset: 0x0001955A
		// Note: this type is marked as 'beforefieldinit'.
		static ClientUnifiedMessageHandle()
		{
		}

		// Token: 0x040009A5 RID: 2469
		public static readonly ClientUnifiedMessageHandle Invalid = new ClientUnifiedMessageHandle(0UL);

		// Token: 0x040009A6 RID: 2470
		public ulong m_ClientUnifiedMessageHandle;
	}
}
