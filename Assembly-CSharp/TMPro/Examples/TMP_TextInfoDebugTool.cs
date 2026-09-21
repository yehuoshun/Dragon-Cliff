using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B6B RID: 2923
	[ExecuteInEditMode]
	public class TMP_TextInfoDebugTool : MonoBehaviour
	{
		// Token: 0x06004D58 RID: 19800 RVA: 0x001F63CA File Offset: 0x001F47CA
		public TMP_TextInfoDebugTool()
		{
		}

		// Token: 0x04003BC1 RID: 15297
		public bool ShowCharacters;

		// Token: 0x04003BC2 RID: 15298
		public bool ShowWords;

		// Token: 0x04003BC3 RID: 15299
		public bool ShowLinks;

		// Token: 0x04003BC4 RID: 15300
		public bool ShowLines;

		// Token: 0x04003BC5 RID: 15301
		public bool ShowMeshBounds;

		// Token: 0x04003BC6 RID: 15302
		public bool ShowTextBounds;

		// Token: 0x04003BC7 RID: 15303
		[Space(10f)]
		[TextArea(2, 2)]
		public string ObjectStats;

		// Token: 0x04003BC8 RID: 15304
		private TMP_Text m_TextComponent;

		// Token: 0x04003BC9 RID: 15305
		private Transform m_Transform;
	}
}
