using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B75 RID: 2933
	public class TextMeshSpawner : MonoBehaviour
	{
		// Token: 0x06004D81 RID: 19841 RVA: 0x001F8C74 File Offset: 0x001F7074
		public TextMeshSpawner()
		{
		}

		// Token: 0x06004D82 RID: 19842 RVA: 0x001F8C84 File Offset: 0x001F7084
		private void Awake()
		{
		}

		// Token: 0x06004D83 RID: 19843 RVA: 0x001F8C88 File Offset: 0x001F7088
		private void Start()
		{
			for (int i = 0; i < this.NumberOfNPC; i++)
			{
				if (this.SpawnType == 0)
				{
					GameObject gameObject = new GameObject();
					gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-95f, 95f), 0.5f, UnityEngine.Random.Range(-95f, 95f));
					TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
					textMeshPro.fontSize = 96f;
					textMeshPro.text = "!";
					textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					this.floatingText_Script = gameObject.AddComponent<TextMeshProFloatingText>();
					this.floatingText_Script.SpawnType = 0;
				}
				else
				{
					GameObject gameObject2 = new GameObject();
					gameObject2.transform.position = new Vector3(UnityEngine.Random.Range(-95f, 95f), 0.5f, UnityEngine.Random.Range(-95f, 95f));
					TextMesh textMesh = gameObject2.AddComponent<TextMesh>();
					textMesh.GetComponent<Renderer>().sharedMaterial = this.TheFont.material;
					textMesh.font = this.TheFont;
					textMesh.anchor = TextAnchor.LowerCenter;
					textMesh.fontSize = 96;
					textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					textMesh.text = "!";
					this.floatingText_Script = gameObject2.AddComponent<TextMeshProFloatingText>();
					this.floatingText_Script.SpawnType = 1;
				}
			}
		}

		// Token: 0x04003C06 RID: 15366
		public int SpawnType;

		// Token: 0x04003C07 RID: 15367
		public int NumberOfNPC = 12;

		// Token: 0x04003C08 RID: 15368
		public Font TheFont;

		// Token: 0x04003C09 RID: 15369
		private TextMeshProFloatingText floatingText_Script;
	}
}
