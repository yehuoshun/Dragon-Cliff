using System;

namespace Steamworks
{
	// Token: 0x020001B8 RID: 440
	[Serializable]
	public struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t>
	{
		// Token: 0x06000BD0 RID: 3024 RVA: 0x0001AEA0 File Offset: 0x000192A0
		public SteamAPICall_t(ulong value)
		{
			this.m_SteamAPICall = value;
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x0001AEA9 File Offset: 0x000192A9
		public override string ToString()
		{
			return this.m_SteamAPICall.ToString();
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0001AEBC File Offset: 0x000192BC
		public override bool Equals(object other)
		{
			return other is SteamAPICall_t && this == (SteamAPICall_t)other;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0001AEDD File Offset: 0x000192DD
		public override int GetHashCode()
		{
			return this.m_SteamAPICall.GetHashCode();
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0001AEF0 File Offset: 0x000192F0
		public static bool operator ==(SteamAPICall_t x, SteamAPICall_t y)
		{
			return x.m_SteamAPICall == y.m_SteamAPICall;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0001AF02 File Offset: 0x00019302
		public static bool operator !=(SteamAPICall_t x, SteamAPICall_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0001AF0E File Offset: 0x0001930E
		public static explicit operator SteamAPICall_t(ulong value)
		{
			return new SteamAPICall_t(value);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0001AF16 File Offset: 0x00019316
		public static explicit operator ulong(SteamAPICall_t that)
		{
			return that.m_SteamAPICall;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0001AF1F File Offset: 0x0001931F
		public bool Equals(SteamAPICall_t other)
		{
			return this.m_SteamAPICall == other.m_SteamAPICall;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0001AF30 File Offset: 0x00019330
		public int CompareTo(SteamAPICall_t other)
		{
			return this.m_SteamAPICall.CompareTo(other.m_SteamAPICall);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0001AF44 File Offset: 0x00019344
		// Note: this type is marked as 'beforefieldinit'.
		static SteamAPICall_t()
		{
		}

		// Token: 0x0400099F RID: 2463
		public static readonly SteamAPICall_t Invalid = new SteamAPICall_t(0UL);

		// Token: 0x040009A0 RID: 2464
		public ulong m_SteamAPICall;
	}
}
