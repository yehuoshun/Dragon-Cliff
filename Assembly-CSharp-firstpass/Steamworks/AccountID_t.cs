using System;

namespace Steamworks
{
	// Token: 0x020001B4 RID: 436
	[Serializable]
	public struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t>
	{
		// Token: 0x06000BA5 RID: 2981 RVA: 0x0001ABE8 File Offset: 0x00018FE8
		public AccountID_t(uint value)
		{
			this.m_AccountID = value;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0001ABF1 File Offset: 0x00018FF1
		public override string ToString()
		{
			return this.m_AccountID.ToString();
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0001AC04 File Offset: 0x00019004
		public override bool Equals(object other)
		{
			return other is AccountID_t && this == (AccountID_t)other;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0001AC25 File Offset: 0x00019025
		public override int GetHashCode()
		{
			return this.m_AccountID.GetHashCode();
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0001AC38 File Offset: 0x00019038
		public static bool operator ==(AccountID_t x, AccountID_t y)
		{
			return x.m_AccountID == y.m_AccountID;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0001AC4A File Offset: 0x0001904A
		public static bool operator !=(AccountID_t x, AccountID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0001AC56 File Offset: 0x00019056
		public static explicit operator AccountID_t(uint value)
		{
			return new AccountID_t(value);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0001AC5E File Offset: 0x0001905E
		public static explicit operator uint(AccountID_t that)
		{
			return that.m_AccountID;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0001AC67 File Offset: 0x00019067
		public bool Equals(AccountID_t other)
		{
			return this.m_AccountID == other.m_AccountID;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0001AC78 File Offset: 0x00019078
		public int CompareTo(AccountID_t other)
		{
			return this.m_AccountID.CompareTo(other.m_AccountID);
		}

		// Token: 0x04000998 RID: 2456
		public uint m_AccountID;
	}
}
