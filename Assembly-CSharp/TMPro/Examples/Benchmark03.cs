using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B55 RID: 2901
	public class Benchmark03 : MonoBehaviour
	{
		// Token: 0x06004D12 RID: 19730 RVA: 0x001F3E88 File Offset: 0x001F2288
		public Benchmark03()
		{
		}

		// Token: 0x06004D13 RID: 19731 RVA: 0x001F3E98 File Offset: 0x001F2298
		private void Awake()
		{
		}

		// Token: 0x06004D14 RID: 19732 RVA: 0x001F3E9C File Offset: 0x001F229C
		private void Start()
		{
			for (int i = 0; i < this.NumberOfNPC; i++)
			{
				if (this.SpawnType == 0)
				{
					TextMeshPro textMeshPro = new GameObject
					{
						transform = 
						{
							position = new Vector3(0f, 0f, 0f)
						}
					}.AddComponent<TextMeshPro>();
					textMeshPro.alignment = TextAlignmentOptions.Center;
					textMeshPro.fontSize = 96f;
					textMeshPro.text = "@";
					textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				}
				else
				{
					TextMesh textMesh = new GameObject
					{
						transform = 
						{
							position = new Vector3(0f, 0f, 0f)
						}
					}.AddComponent<TextMesh>();
					textMesh.GetComponent<Renderer>().sharedMaterial = this.TheFont.material;
					textMesh.font = this.TheFont;
					textMesh.anchor = TextAnchor.MiddleCenter;
					textMesh.fontSize = 96;
					textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					textMesh.text = "@";
				}
			}
		}

		// Token: 0x04003B5A RID: 15194
		public int SpawnType;

		// Token: 0x04003B5B RID: 15195
		public int NumberOfNPC = 12;

		// Token: 0x04003B5C RID: 15196
		public Font TheFont;
	}
}
