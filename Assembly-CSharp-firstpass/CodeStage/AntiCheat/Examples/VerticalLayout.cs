using System;
using UnityEngine;

namespace CodeStage.AntiCheat.Examples
{
	// Token: 0x02000005 RID: 5
	internal class VerticalLayout : IDisposable
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000040EB File Offset: 0x000024EB
		public VerticalLayout(params GUILayoutOption[] options)
		{
			GUILayout.BeginVertical(options);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000040F9 File Offset: 0x000024F9
		public VerticalLayout(GUIStyle style)
		{
			GUILayout.BeginVertical(style, new GUILayoutOption[0]);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000410D File Offset: 0x0000250D
		public void Dispose()
		{
			GUILayout.EndHorizontal();
		}
	}
}
