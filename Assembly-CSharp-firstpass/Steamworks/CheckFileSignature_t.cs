using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000117 RID: 279
	[CallbackIdentity(705)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CheckFileSignature_t
	{
		// Token: 0x04000471 RID: 1137
		public const int k_iCallback = 705;

		// Token: 0x04000472 RID: 1138
		public ECheckFileSignature m_eCheckFileSignature;
	}
}
