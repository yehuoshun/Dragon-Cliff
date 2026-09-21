using System;

namespace Steamworks
{
	// Token: 0x020001A5 RID: 421
	[Serializable]
	public struct HHTMLBrowser : IEquatable<HHTMLBrowser>, IComparable<HHTMLBrowser>
	{
		// Token: 0x06000B04 RID: 2820 RVA: 0x0001A1B5 File Offset: 0x000185B5
		public HHTMLBrowser(uint value)
		{
			this.m_HHTMLBrowser = value;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0001A1BE File Offset: 0x000185BE
		public override string ToString()
		{
			return this.m_HHTMLBrowser.ToString();
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0001A1D1 File Offset: 0x000185D1
		public override bool Equals(object other)
		{
			return other is HHTMLBrowser && this == (HHTMLBrowser)other;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0001A1F2 File Offset: 0x000185F2
		public override int GetHashCode()
		{
			return this.m_HHTMLBrowser.GetHashCode();
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0001A205 File Offset: 0x00018605
		public static bool operator ==(HHTMLBrowser x, HHTMLBrowser y)
		{
			return x.m_HHTMLBrowser == y.m_HHTMLBrowser;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0001A217 File Offset: 0x00018617
		public static bool operator !=(HHTMLBrowser x, HHTMLBrowser y)
		{
			return !(x == y);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0001A223 File Offset: 0x00018623
		public static explicit operator HHTMLBrowser(uint value)
		{
			return new HHTMLBrowser(value);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0001A22B File Offset: 0x0001862B
		public static explicit operator uint(HHTMLBrowser that)
		{
			return that.m_HHTMLBrowser;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0001A234 File Offset: 0x00018634
		public bool Equals(HHTMLBrowser other)
		{
			return this.m_HHTMLBrowser == other.m_HHTMLBrowser;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0001A245 File Offset: 0x00018645
		public int CompareTo(HHTMLBrowser other)
		{
			return this.m_HHTMLBrowser.CompareTo(other.m_HHTMLBrowser);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0001A259 File Offset: 0x00018659
		// Note: this type is marked as 'beforefieldinit'.
		static HHTMLBrowser()
		{
		}

		// Token: 0x0400097D RID: 2429
		public static readonly HHTMLBrowser Invalid = new HHTMLBrowser(0u);

		// Token: 0x0400097E RID: 2430
		public uint m_HHTMLBrowser;
	}
}
