using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019B RID: 411
	// (Invoke) Token: 0x06000A81 RID: 2689
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void SteamAPI_CheckCallbackRegistered_t(int iCallbackNum);
}
