using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000118 RID: 280
	[CallbackIdentity(714)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GamepadTextInputDismissed_t
	{
		// Token: 0x04000473 RID: 1139
		public const int k_iCallback = 714;

		// Token: 0x04000474 RID: 1140
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSubmitted;

		// Token: 0x04000475 RID: 1141
		public uint m_unSubmittedText;
	}
}
