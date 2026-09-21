using System;

namespace Steamworks
{
	// Token: 0x020001B7 RID: 439
	[Serializable]
	public struct ManifestId_t : IEquatable<ManifestId_t>, IComparable<ManifestId_t>
	{
		// Token: 0x06000BC5 RID: 3013 RVA: 0x0001ADEE File Offset: 0x000191EE
		public ManifestId_t(ulong value)
		{
			this.m_ManifestId = value;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0001ADF7 File Offset: 0x000191F7
		public override string ToString()
		{
			return this.m_ManifestId.ToString();
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0001AE0A File Offset: 0x0001920A
		public override bool Equals(object other)
		{
			return other is ManifestId_t && this == (ManifestId_t)other;
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0001AE2B File Offset: 0x0001922B
		public override int GetHashCode()
		{
			return this.m_ManifestId.GetHashCode();
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0001AE3E File Offset: 0x0001923E
		public static bool operator ==(ManifestId_t x, ManifestId_t y)
		{
			return x.m_ManifestId == y.m_ManifestId;
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0001AE50 File Offset: 0x00019250
		public static bool operator !=(ManifestId_t x, ManifestId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0001AE5C File Offset: 0x0001925C
		public static explicit operator ManifestId_t(ulong value)
		{
			return new ManifestId_t(value);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0001AE64 File Offset: 0x00019264
		public static explicit operator ulong(ManifestId_t that)
		{
			return that.m_ManifestId;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0001AE6D File Offset: 0x0001926D
		public bool Equals(ManifestId_t other)
		{
			return this.m_ManifestId == other.m_ManifestId;
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0001AE7E File Offset: 0x0001927E
		public int CompareTo(ManifestId_t other)
		{
			return this.m_ManifestId.CompareTo(other.m_ManifestId);
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0001AE92 File Offset: 0x00019292
		// Note: this type is marked as 'beforefieldinit'.
		static ManifestId_t()
		{
		}

		// Token: 0x0400099D RID: 2461
		public static readonly ManifestId_t Invalid = new ManifestId_t(0UL);

		// Token: 0x0400099E RID: 2462
		public ulong m_ManifestId;
	}
}
