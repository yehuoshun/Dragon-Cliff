using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000172 RID: 370
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamParamStringArray_t
	{
		// Token: 0x0400092B RID: 2347
		public IntPtr m_ppStrings;

		// Token: 0x0400092C RID: 2348
		public int m_nNumStrings;
	}
}
