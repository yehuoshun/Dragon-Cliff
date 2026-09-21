using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CF RID: 207
	[CallbackIdentity(1307)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageFileShareResult_t
	{
		// Token: 0x04000355 RID: 853
		public const int k_iCallback = 1307;

		// Token: 0x04000356 RID: 854
		public EResult m_eResult;

		// Token: 0x04000357 RID: 855
		public UGCHandle_t m_hFile;

		// Token: 0x04000358 RID: 856
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_rgchFilename;
	}
}
