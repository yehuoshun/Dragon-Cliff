using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B7D RID: 2941
	public class RogueLikeMapGenerator : MonoBehaviour
	{
		// Token: 0x06004DA9 RID: 19881 RVA: 0x001FB577 File Offset: 0x001F9977
		public RogueLikeMapGenerator()
		{
		}

		// Token: 0x06004DAA RID: 19882 RVA: 0x001FB595 File Offset: 0x001F9995
		private void OnGUI()
		{
			if (GUI.Button(new Rect(20f, 20f, 100f, 50f), "Generate Map"))
			{
				this.GenerateMap();
			}
		}

		// Token: 0x06004DAB RID: 19883 RVA: 0x001FB5C8 File Offset: 0x001F99C8
		[ContextMenu("GenerateMap")]
		public void GenerateMap()
		{
			this.GroundOverlay.ClearMap();
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num = 25f;
			float num2 = UnityEngine.Random.value * 100f;
			float num3 = UnityEngine.Random.value * 100f;
			uint tileData = 524288u;
			uint tileData2 = 1572864u;
			uint tileData3 = 66u;
			uint tileData4 = 589824u;
			uint tileData5 = 1441792u;
			uint tileData6 = 1507328u;
			for (int i = 0; i < this.Width; i++)
			{
				for (int j = 0; j < this.Height; j++)
				{
					float value = UnityEngine.Random.value;
					float num4 = Mathf.PerlinNoise(((float)i + num2) / num, ((float)j + num3) / num);
					if ((double)num4 < 0.3)
					{
						this.Ground.SetTileData(i, j, tileData);
					}
					else if ((double)num4 < 0.4)
					{
						this.Ground.SetTileData(i, j, tileData);
						if (value < num4 / 3f)
						{
							this.GroundOverlay.SetTileData(i, j, tileData2);
						}
					}
					else if ((double)num4 < 0.5 && value < 1f - num4 / 2f)
					{
						this.Ground.SetTileData(i, j, tileData3);
					}
					else if ((double)num4 < 0.6 && (double)value < 1.0 - 1.2 * (double)num4)
					{
						this.Ground.SetTileData(i, j, tileData4);
						this.GroundOverlay.SetTileData(i, j, tileData5);
					}
					else if ((double)num4 < 0.7)
					{
						this.Ground.SetTileData(i, j, tileData4);
					}
					else
					{
						this.Ground.SetTileData(i, j, tileData4);
						this.GroundOverlay.SetTileData(i, j, tileData6);
					}
				}
			}
			Debug.Log("Generation time(ms): " + (Time.realtimeSinceStartup - realtimeSinceStartup) * 1000f);
			realtimeSinceStartup = Time.realtimeSinceStartup;
			this.Ground.UpdateMesh();
			this.GroundOverlay.UpdateMesh();
			Debug.Log("UpdateMesh time(ms): " + (Time.realtimeSinceStartup - realtimeSinceStartup) * 1000f);
		}

		// Token: 0x04003C28 RID: 15400
		public Tilemap Ground;

		// Token: 0x04003C29 RID: 15401
		public Tilemap GroundOverlay;

		// Token: 0x04003C2A RID: 15402
		public int Width = 300;

		// Token: 0x04003C2B RID: 15403
		public int Height = 300;
	}
}
