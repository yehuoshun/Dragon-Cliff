using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x0200019A RID: 410
	// (Invoke) Token: 0x06000A7D RID: 2685
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SteamAPIWarningMessageHook_t(int nSeverity, StringBuilder pchDebugText);
}
