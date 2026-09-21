using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B61 RID: 2913
	public class TMP_ExampleScript_01 : MonoBehaviour
	{
		// Token: 0x06004D34 RID: 19764 RVA: 0x001F5884 File Offset: 0x001F3C84
		public TMP_ExampleScript_01()
		{
		}

		// Token: 0x06004D35 RID: 19765 RVA: 0x001F588C File Offset: 0x001F3C8C
		private void Awake()
		{
			if (this.ObjectType == TMP_ExampleScript_01.objectType.TextMeshPro)
			{
				this.m_text = (base.GetComponent<TextMeshPro>() ?? base.gameObject.AddComponent<TextMeshPro>());
			}
			else
			{
				this.m_text = (base.GetComponent<TextMeshProUGUI>() ?? base.gameObject.AddComponent<TextMeshProUGUI>());
			}
			this.m_text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Anton SDF");
			this.m_text.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Anton SDF - Drop Shadow");
			this.m_text.fontSize = 120f;
			this.m_text.text = "A <#0080ff>simple</color> line of text.";
			Vector2 preferredValues = this.m_text.GetPreferredValues(float.PositiveInfinity, float.PositiveInfinity);
			this.m_text.rectTransform.sizeDelta = new Vector2(preferredValues.x, preferredValues.y);
		}

		// Token: 0x06004D36 RID: 19766 RVA: 0x001F5968 File Offset: 0x001F3D68
		private void Update()
		{
			if (!this.isStatic)
			{
				this.m_text.SetText("The count is <#0080ff>{0}</color>", (float)(this.count % 1000));
				this.count++;
			}
		}

		// Token: 0x04003B9E RID: 15262
		public TMP_ExampleScript_01.objectType ObjectType;

		// Token: 0x04003B9F RID: 15263
		public bool isStatic;

		// Token: 0x04003BA0 RID: 15264
		private TMP_Text m_text;

		// Token: 0x04003BA1 RID: 15265
		private const string k_label = "The count is <#0080ff>{0}</color>";

		// Token: 0x04003BA2 RID: 15266
		private int count;

		// Token: 0x02000B62 RID: 2914
		public enum objectType
		{
			// Token: 0x04003BA4 RID: 15268
			TextMeshPro,
			// Token: 0x04003BA5 RID: 15269
			TextMeshProUGUI
		}
	}
}
