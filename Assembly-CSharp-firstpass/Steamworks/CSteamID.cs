using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019E RID: 414
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CSteamID : IEquatable<CSteamID>, IComparable<CSteamID>
	{
		// Token: 0x06000A9D RID: 2717 RVA: 0x00019929 File Offset: 0x00017D29
		public CSteamID(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.Set(unAccountID, eUniverse, eAccountType);
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0001993C File Offset: 0x00017D3C
		public CSteamID(AccountID_t unAccountID, uint unAccountInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.InstancedSet(unAccountID, unAccountInstance, eUniverse, eAccountType);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00019951 File Offset: 0x00017D51
		public CSteamID(ulong ulSteamID)
		{
			this.m_SteamID = ulSteamID;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0001995A File Offset: 0x00017D5A
		public void Set(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			if (eAccountType == EAccountType.k_EAccountTypeClan || eAccountType == EAccountType.k_EAccountTypeGameServer)
			{
				this.SetAccountInstance(0u);
			}
			else
			{
				this.SetAccountInstance(1u);
			}
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00019992 File Offset: 0x00017D92
		public void InstancedSet(AccountID_t unAccountID, uint unInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			this.SetAccountInstance(unInstance);
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x000199B1 File Offset: 0x00017DB1
		public void Clear()
		{
			this.m_SteamID = 0UL;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x000199BB File Offset: 0x00017DBB
		public void CreateBlankAnonLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0u));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonGameServer);
			this.SetAccountInstance(0u);
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x000199DE File Offset: 0x00017DDE
		public void CreateBlankAnonUserLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0u));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonUser);
			this.SetAccountInstance(0u);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00019A02 File Offset: 0x00017E02
		public bool BBlankAnonAccount()
		{
			return this.GetAccountID() == new AccountID_t(0u) && this.BAnonAccount() && this.GetUnAccountInstance() == 0u;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00019A31 File Offset: 0x00017E31
		public bool BGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00019A4B File Offset: 0x00017E4B
		public bool BPersistentGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00019A56 File Offset: 0x00017E56
		public bool BAnonGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00019A61 File Offset: 0x00017E61
		public bool BContentServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeContentServer;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x00019A6C File Offset: 0x00017E6C
		public bool BClanAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeClan;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00019A77 File Offset: 0x00017E77
		public bool BChatAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat;
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00019A82 File Offset: 0x00017E82
		public bool IsLobby()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat && (this.GetUnAccountInstance() & 262144u) != 0u;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00019AA5 File Offset: 0x00017EA5
		public bool BIndividualAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeIndividual || this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x00019AC0 File Offset: 0x00017EC0
		public bool BAnonAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00019ADB File Offset: 0x00017EDB
		public bool BAnonUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00019AE7 File Offset: 0x00017EE7
		public bool BConsoleUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00019AF3 File Offset: 0x00017EF3
		public void SetAccountID(AccountID_t other)
		{
			this.m_SteamID = ((this.m_SteamID & 18446744069414584320UL) | ((ulong)((uint)other) & (ulong)-1) << 0);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00019B18 File Offset: 0x00017F18
		public void SetAccountInstance(uint other)
		{
			this.m_SteamID = ((this.m_SteamID & 18442240478377148415UL) | ((ulong)other & 1048575UL) << 32);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00019B3D File Offset: 0x00017F3D
		public void SetEAccountType(EAccountType other)
		{
			this.m_SteamID = ((this.m_SteamID & 18379190079298994175UL) | (ulong)((ulong)((long)other & 15L) << 52));
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00019B5F File Offset: 0x00017F5F
		public void SetEUniverse(EUniverse other)
		{
			this.m_SteamID = ((this.m_SteamID & 72057594037927935UL) | (ulong)((ulong)((long)other & 255L) << 56));
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x00019B84 File Offset: 0x00017F84
		public void ClearIndividualInstance()
		{
			if (this.BIndividualAccount())
			{
				this.SetAccountInstance(0u);
			}
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00019B98 File Offset: 0x00017F98
		public bool HasNoIndividualInstance()
		{
			return this.BIndividualAccount() && this.GetUnAccountInstance() == 0u;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x00019BB1 File Offset: 0x00017FB1
		public AccountID_t GetAccountID()
		{
			return new AccountID_t((uint)(this.m_SteamID & (ulong)-1));
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00019BC2 File Offset: 0x00017FC2
		public uint GetUnAccountInstance()
		{
			return (uint)(this.m_SteamID >> 32 & 1048575UL);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00019BD5 File Offset: 0x00017FD5
		public EAccountType GetEAccountType()
		{
			return (EAccountType)(this.m_SteamID >> 52 & 15UL);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00019BE5 File Offset: 0x00017FE5
		public EUniverse GetEUniverse()
		{
			return (EUniverse)(this.m_SteamID >> 56 & 255UL);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00019BF8 File Offset: 0x00017FF8
		public bool IsValid()
		{
			return this.GetEAccountType() > EAccountType.k_EAccountTypeInvalid && this.GetEAccountType() < EAccountType.k_EAccountTypeMax && this.GetEUniverse() > EUniverse.k_EUniverseInvalid && this.GetEUniverse() < EUniverse.k_EUniverseMax && (this.GetEAccountType() != EAccountType.k_EAccountTypeIndividual || (!(this.GetAccountID() == new AccountID_t(0u)) && this.GetUnAccountInstance() <= 4u)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeClan || (!(this.GetAccountID() == new AccountID_t(0u)) && this.GetUnAccountInstance() == 0u)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeGameServer || !(this.GetAccountID() == new AccountID_t(0u)));
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00019CBE File Offset: 0x000180BE
		public override string ToString()
		{
			return this.m_SteamID.ToString();
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00019CD1 File Offset: 0x000180D1
		public override bool Equals(object other)
		{
			return other is CSteamID && this == (CSteamID)other;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00019CF2 File Offset: 0x000180F2
		public override int GetHashCode()
		{
			return this.m_SteamID.GetHashCode();
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00019D05 File Offset: 0x00018105
		public static bool operator ==(CSteamID x, CSteamID y)
		{
			return x.m_SteamID == y.m_SteamID;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00019D17 File Offset: 0x00018117
		public static bool operator !=(CSteamID x, CSteamID y)
		{
			return !(x == y);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00019D23 File Offset: 0x00018123
		public static explicit operator CSteamID(ulong value)
		{
			return new CSteamID(value);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00019D2B File Offset: 0x0001812B
		public static explicit operator ulong(CSteamID that)
		{
			return that.m_SteamID;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00019D34 File Offset: 0x00018134
		public bool Equals(CSteamID other)
		{
			return this.m_SteamID == other.m_SteamID;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00019D45 File Offset: 0x00018145
		public int CompareTo(CSteamID other)
		{
			return this.m_SteamID.CompareTo(other.m_SteamID);
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00019D5C File Offset: 0x0001815C
		// Note: this type is marked as 'beforefieldinit'.
		static CSteamID()
		{
		}

		// Token: 0x0400096F RID: 2415
		public static readonly CSteamID Nil = default(CSteamID);

		// Token: 0x04000970 RID: 2416
		public static readonly CSteamID OutofDateGS = new CSteamID(new AccountID_t(0u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000971 RID: 2417
		public static readonly CSteamID LanModeGS = new CSteamID(new AccountID_t(0u), 0u, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000972 RID: 2418
		public static readonly CSteamID NotInitYetGS = new CSteamID(new AccountID_t(1u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000973 RID: 2419
		public static readonly CSteamID NonSteamGS = new CSteamID(new AccountID_t(2u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000974 RID: 2420
		public ulong m_SteamID;
	}
}
