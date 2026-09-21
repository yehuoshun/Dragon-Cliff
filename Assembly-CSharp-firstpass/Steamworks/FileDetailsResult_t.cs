using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006D RID: 109
	[CallbackIdentity(1023)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FileDetailsResult_t
	{
		// Token: 0x040001FC RID: 508
		public const int k_iCallback = 1023;

		// Token: 0x040001FD RID: 509
		public EResult m_eResult;

		// Token: 0x040001FE RID: 510
		public ulong m_ulFileSize;

		// Token: 0x040001FF RID: 511
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] m_FileSHA;

		// Token: 0x04000200 RID: 512
		public uint m_unFlags;
	}
}
