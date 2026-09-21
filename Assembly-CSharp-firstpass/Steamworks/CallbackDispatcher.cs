using System;
using UnityEngine;

namespace Steamworks
{
	// Token: 0x0200002F RID: 47
	public static class CallbackDispatcher
	{
		// Token: 0x060002FE RID: 766 RVA: 0x0000F28C File Offset: 0x0000D68C
		public static void ExceptionHandler(Exception e)
		{
			Debug.LogException(e);
		}
	}
}
