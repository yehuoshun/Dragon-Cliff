using System;
using UnityEngine;

namespace CodeStage.AntiCheat.Examples
{
	// Token: 0x02000004 RID: 4
	internal class HorizontalLayout : IDisposable
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000040D6 File Offset: 0x000024D6
		public HorizontalLayout(params GUILayoutOption[] options)
		{
			GUILayout.BeginHorizontal(options);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000040E4 File Offset: 0x000024E4
		public void Dispose()
		{
			GUILayout.EndHorizontal();
		}
	}
}
