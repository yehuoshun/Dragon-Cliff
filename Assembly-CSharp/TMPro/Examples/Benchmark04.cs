using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B56 RID: 2902
	public class Benchmark04 : MonoBehaviour
	{
		// Token: 0x06004D15 RID: 19733 RVA: 0x001F3FCC File Offset: 0x001F23CC
		public Benchmark04()
		{
		}

		// Token: 0x06004D16 RID: 19734 RVA: 0x001F3FEC File Offset: 0x001F23EC
		private void Start()
		{
			this.m_Transform = base.transform;
			float num = 0f;
			float num2 = (float)(Screen.height / 2);
			Camera.main.orthographicSize = num2;
			float num3 = num2;
			float num4 = (float)Screen.width / (float)Screen.height;
			for (int i = this.MinPointSize; i <= this.MaxPointSize; i += this.Steps)
			{
				if (this.SpawnType == 0)
				{
					GameObject gameObject = new GameObject("Text - " + i + " Pts");
					if (num > num3 * 2f)
					{
						return;
					}
					gameObject.transform.position = this.m_Transform.position + new Vector3(num4 * -num3 * 0.975f, num3 * 0.975f - num, 0f);
					TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
					textMeshPro.rectTransform.pivot = new Vector2(0f, 0.5f);
					textMeshPro.enableWordWrapping = false;
					textMeshPro.extraPadding = true;
					textMeshPro.isOrthographic = true;
					textMeshPro.fontSize = (float)i;
					textMeshPro.text = i + " pts - Lorem ipsum dolor sit...";
					textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					num += (float)i;
				}
			}
		}

		// Token: 0x04003B5D RID: 15197
		public int SpawnType;

		// Token: 0x04003B5E RID: 15198
		public int MinPointSize = 12;

		// Token: 0x04003B5F RID: 15199
		public int MaxPointSize = 64;

		// Token: 0x04003B60 RID: 15200
		public int Steps = 4;

		// Token: 0x04003B61 RID: 15201
		private Transform m_Transform;
	}
}
