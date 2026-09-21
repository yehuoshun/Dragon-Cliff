using System;

namespace Steamworks
{
	// Token: 0x0200019C RID: 412
	[Serializable]
	public struct CGameID : IEquatable<CGameID>, IComparable<CGameID>
	{
		// Token: 0x06000A84 RID: 2692 RVA: 0x000196CF File Offset: 0x00017ACF
		public CGameID(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x000196D8 File Offset: 0x00017AD8
		public CGameID(AppId_t nAppID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x000196E9 File Offset: 0x00017AE9
		public CGameID(AppId_t nAppID, uint nModID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
			this.SetType(CGameID.EGameIDType.k_EGameIDTypeGameMod);
			this.SetModID(nModID);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00019708 File Offset: 0x00017B08
		public bool IsSteamApp()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeApp;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00019713 File Offset: 0x00017B13
		public bool IsMod()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeGameMod;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0001971E File Offset: 0x00017B1E
		public bool IsShortcut()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeShortcut;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00019729 File Offset: 0x00017B29
		public bool IsP2PFile()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeP2P;
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00019734 File Offset: 0x00017B34
		public AppId_t AppID()
		{
			return new AppId_t((uint)(this.m_GameID & 16777215UL));
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00019749 File Offset: 0x00017B49
		public CGameID.EGameIDType Type()
		{
			return (CGameID.EGameIDType)(this.m_GameID >> 24 & 255UL);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0001975C File Offset: 0x00017B5C
		public uint ModID()
		{
			return (uint)(this.m_GameID >> 32 & (ulong)-1);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x0001976C File Offset: 0x00017B6C
		public bool IsValid()
		{
			switch (this.Type())
			{
			case CGameID.EGameIDType.k_EGameIDTypeApp:
				return this.AppID() != AppId_t.Invalid;
			case CGameID.EGameIDType.k_EGameIDTypeGameMod:
				return this.AppID() != AppId_t.Invalid && (this.ModID() & 2147483648u) != 0u;
			case CGameID.EGameIDType.k_EGameIDTypeShortcut:
				return (this.ModID() & 2147483648u) != 0u;
			case CGameID.EGameIDType.k_EGameIDTypeP2P:
				return this.AppID() == AppId_t.Invalid && (this.ModID() & 2147483648u) != 0u;
			default:
				return false;
			}
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00019816 File Offset: 0x00017C16
		public void Reset()
		{
			this.m_GameID = 0UL;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00019820 File Offset: 0x00017C20
		public void Set(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00019829 File Offset: 0x00017C29
		private void SetAppID(AppId_t other)
		{
			this.m_GameID = ((this.m_GameID & 18446744073692774400UL) | ((ulong)((uint)other) & 16777215UL) << 0);
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0001984F File Offset: 0x00017C4F
		private void SetType(CGameID.EGameIDType other)
		{
			this.m_GameID = ((this.m_GameID & 18446744069431361535UL) | (ulong)((ulong)((long)other & 255L) << 24));
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00019874 File Offset: 0x00017C74
		private void SetModID(uint other)
		{
			this.m_GameID = ((this.m_GameID & (ulong)-1) | ((ulong)other & (ulong)-1) << 32);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0001988E File Offset: 0x00017C8E
		public override string ToString()
		{
			return this.m_GameID.ToString();
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x000198A1 File Offset: 0x00017CA1
		public override bool Equals(object other)
		{
			return other is CGameID && this == (CGameID)other;
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x000198C2 File Offset: 0x00017CC2
		public override int GetHashCode()
		{
			return this.m_GameID.GetHashCode();
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x000198D5 File Offset: 0x00017CD5
		public static bool operator ==(CGameID x, CGameID y)
		{
			return x.m_GameID == y.m_GameID;
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000198E7 File Offset: 0x00017CE7
		public static bool operator !=(CGameID x, CGameID y)
		{
			return !(x == y);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x000198F3 File Offset: 0x00017CF3
		public static explicit operator CGameID(ulong value)
		{
			return new CGameID(value);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x000198FB File Offset: 0x00017CFB
		public static explicit operator ulong(CGameID that)
		{
			return that.m_GameID;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00019904 File Offset: 0x00017D04
		public bool Equals(CGameID other)
		{
			return this.m_GameID == other.m_GameID;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00019915 File Offset: 0x00017D15
		public int CompareTo(CGameID other)
		{
			return this.m_GameID.CompareTo(other.m_GameID);
		}

		// Token: 0x04000969 RID: 2409
		public ulong m_GameID;

		// Token: 0x0200019D RID: 413
		public enum EGameIDType
		{
			// Token: 0x0400096B RID: 2411
			k_EGameIDTypeApp,
			// Token: 0x0400096C RID: 2412
			k_EGameIDTypeGameMod,
			// Token: 0x0400096D RID: 2413
			k_EGameIDTypeShortcut,
			// Token: 0x0400096E RID: 2414
			k_EGameIDTypeP2P
		}
	}
}
