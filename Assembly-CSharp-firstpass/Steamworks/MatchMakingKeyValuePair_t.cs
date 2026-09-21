using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000176 RID: 374
	public struct MatchMakingKeyValuePair_t
	{
		// Token: 0x060006C0 RID: 1728 RVA: 0x00010E17 File Offset: 0x0000F217
		private MatchMakingKeyValuePair_t(string strKey, string strValue)
		{
			this.m_szKey = strKey;
			this.m_szValue = strValue;
		}

		// Token: 0x04000950 RID: 2384
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szKey;

		// Token: 0x04000951 RID: 2385
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szValue;
	}
}
