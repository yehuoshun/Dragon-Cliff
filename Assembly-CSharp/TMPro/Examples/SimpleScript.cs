using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B5E RID: 2910
	public class SimpleScript : MonoBehaviour
	{
		// Token: 0x06004D2A RID: 19754 RVA: 0x001F4F0C File Offset: 0x001F330C
		public SimpleScript()
		{
		}

		// Token: 0x06004D2B RID: 19755 RVA: 0x001F4F14 File Offset: 0x001F3314
		private void Start()
		{
			this.m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
			this.m_textMeshPro.autoSizeTextContainer = true;
			this.m_textMeshPro.fontSize = 48f;
			this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
			this.m_textMeshPro.enableWordWrapping = false;
		}

		// Token: 0x06004D2C RID: 19756 RVA: 0x001F4F6A File Offset: 0x001F336A
		private void Update()
		{
			this.m_textMeshPro.SetText("The <#0050FF>count is: </color>{0:2}", this.m_frame % 1000f);
			this.m_frame += 1f * Time.deltaTime;
		}

		// Token: 0x04003B97 RID: 15255
		private TextMeshPro m_textMeshPro;

		// Token: 0x04003B98 RID: 15256
		private const string label = "The <#0050FF>count is: </color>{0:2}";

		// Token: 0x04003B99 RID: 15257
		private float m_frame;
	}
}
