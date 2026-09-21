using System;

namespace Steamworks
{
	// Token: 0x020001AF RID: 431
	[Serializable]
	public struct PublishedFileId_t : IEquatable<PublishedFileId_t>, IComparable<PublishedFileId_t>
	{
		// Token: 0x06000B6E RID: 2926 RVA: 0x0001A86F File Offset: 0x00018C6F
		public PublishedFileId_t(ulong value)
		{
			this.m_PublishedFileId = value;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0001A878 File Offset: 0x00018C78
		public override string ToString()
		{
			return this.m_PublishedFileId.ToString();
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0001A88B File Offset: 0x00018C8B
		public override bool Equals(object other)
		{
			return other is PublishedFileId_t && this == (PublishedFileId_t)other;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0001A8AC File Offset: 0x00018CAC
		public override int GetHashCode()
		{
			return this.m_PublishedFileId.GetHashCode();
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0001A8BF File Offset: 0x00018CBF
		public static bool operator ==(PublishedFileId_t x, PublishedFileId_t y)
		{
			return x.m_PublishedFileId == y.m_PublishedFileId;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0001A8D1 File Offset: 0x00018CD1
		public static bool operator !=(PublishedFileId_t x, PublishedFileId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0001A8DD File Offset: 0x00018CDD
		public static explicit operator PublishedFileId_t(ulong value)
		{
			return new PublishedFileId_t(value);
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0001A8E5 File Offset: 0x00018CE5
		public static explicit operator ulong(PublishedFileId_t that)
		{
			return that.m_PublishedFileId;
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0001A8EE File Offset: 0x00018CEE
		public bool Equals(PublishedFileId_t other)
		{
			return this.m_PublishedFileId == other.m_PublishedFileId;
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0001A8FF File Offset: 0x00018CFF
		public int CompareTo(PublishedFileId_t other)
		{
			return this.m_PublishedFileId.CompareTo(other.m_PublishedFileId);
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0001A913 File Offset: 0x00018D13
		// Note: this type is marked as 'beforefieldinit'.
		static PublishedFileId_t()
		{
		}

		// Token: 0x0400098E RID: 2446
		public static readonly PublishedFileId_t Invalid = new PublishedFileId_t(0UL);

		// Token: 0x0400098F RID: 2447
		public ulong m_PublishedFileId;
	}
}
