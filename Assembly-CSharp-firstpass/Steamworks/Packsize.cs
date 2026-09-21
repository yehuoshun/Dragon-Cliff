using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200005E RID: 94
	public static class Packsize
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x00010444 File Offset: 0x0000E844
		public static bool Test()
		{
			int num = Marshal.SizeOf(typeof(Packsize.ValvePackingSentinel_t));
			int num2 = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSubscribedFilesResult_t));
			return num == 32 && num2 == 616;
		}

		// Token: 0x040001C2 RID: 450
		public const int value = 8;

		// Token: 0x0200005F RID: 95
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		private struct ValvePackingSentinel_t
		{
			// Token: 0x040001C3 RID: 451
			private uint m_u32;

			// Token: 0x040001C4 RID: 452
			private ulong m_u64;

			// Token: 0x040001C5 RID: 453
			private ushort m_u16;

			// Token: 0x040001C6 RID: 454
			private double m_d;
		}
	}
}
