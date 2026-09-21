using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B89 RID: 2953
	public class RandomBrush : TilesetBrush
	{
		// Token: 0x06004E1A RID: 19994 RVA: 0x001FE1D4 File Offset: 0x001FC5D4
		public RandomBrush()
		{
		}

		// Token: 0x06004E1B RID: 19995 RVA: 0x001FE1F4 File Offset: 0x001FC5F4
		private void OnEnable()
		{
			if ((this.RandomTileList == null || this.RandomTileList.Count == 0) && this.RandomTiles != null && this.RandomTiles.Count > 0)
			{
				this.RandomTileList = new List<RandomBrush.RandomTileData>(from x in this.RandomTiles
				select new RandomBrush.RandomTileData
				{
					tileData = x,
					probabilityFactor = 1f
				});
				this.RandomTiles = null;
			}
			this.InvalidateSortedList();
		}

		// Token: 0x06004E1C RID: 19996 RVA: 0x001FE278 File Offset: 0x001FC678
		public void InvalidateSortedList()
		{
			this.m_sortedList = new List<RandomBrush.RandomTileData>(from x in this.RandomTileList
			orderby x.probabilityFactor
			select x);
			this.m_sumProbabilityFactor = Mathf.Max(this.GetSumProbabilityFactor(), float.Epsilon);
		}

		// Token: 0x06004E1D RID: 19997 RVA: 0x001FE2D0 File Offset: 0x001FC6D0
		public uint GetRandomTile()
		{
			float num = UnityEngine.Random.value;
			if (this.m_sortedList == null || this.m_sortedList.Count == 0)
			{
				this.InvalidateSortedList();
			}
			for (int i = 0; i < this.m_sortedList.Count; i++)
			{
				RandomBrush.RandomTileData randomTileData = this.m_sortedList[i];
				float num2 = randomTileData.probabilityFactor / this.m_sumProbabilityFactor;
				if (num <= num2)
				{
					return randomTileData.tileData;
				}
				num -= num2;
			}
			return (this.m_sortedList.Count <= 0) ? uint.MaxValue : this.m_sortedList[this.m_sortedList.Count - 1].tileData;
		}

		// Token: 0x06004E1E RID: 19998 RVA: 0x001FE381 File Offset: 0x001FC781
		public float GetSumProbabilityFactor()
		{
			return this.RandomTileList.Sum((RandomBrush.RandomTileData x) => x.probabilityFactor);
		}

		// Token: 0x06004E1F RID: 19999 RVA: 0x001FE3AB File Offset: 0x001FC7AB
		public override uint PreviewTileData()
		{
			return (this.RandomTileList.Count <= 0) ? uint.MaxValue : this.RandomTileList[0].tileData;
		}

		// Token: 0x06004E20 RID: 20000 RVA: 0x001FE3D8 File Offset: 0x001FC7D8
		public override uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			if (this.RandomTileList.Count > 0)
			{
				uint num = this.GetRandomTile();
				if (this.RandomizeFlagMask != 0u)
				{
					uint num2 = (uint)(UnityEngine.Random.Range(0, 8) << 29 & (int)this.RandomizeFlagMask);
					num &= ~this.RandomizeFlagMask;
					num |= num2;
				}
				uint num3 = base.RefreshLinkedBrush(tilemap, gridX, gridY, num);
				num3 &= 268435455u;
				num3 |= (num & 4026531840u);
				TilesetBrush tilesetBrush = this.Tileset.FindBrush(Tileset.GetBrushIdFromTileData(num3));
				if (tilesetBrush && tilesetBrush.IsAnimated())
				{
					num3 &= 4026597375u;
					num3 |= (num & 268369920u);
				}
				if (!this.RemoveBrushIdAfterRefresh)
				{
					num3 &= 4026597375u;
					num3 |= (tileData & 268369920u);
				}
				return num3;
			}
			return tileData;
		}

		// Token: 0x06004E21 RID: 20001 RVA: 0x001FE4A8 File Offset: 0x001FC8A8
		[CompilerGenerated]
		private static RandomBrush.RandomTileData <OnEnable>m__0(uint x)
		{
			return new RandomBrush.RandomTileData
			{
				tileData = x,
				probabilityFactor = 1f
			};
		}

		// Token: 0x06004E22 RID: 20002 RVA: 0x001FE4CE File Offset: 0x001FC8CE
		[CompilerGenerated]
		private static float <InvalidateSortedList>m__1(RandomBrush.RandomTileData x)
		{
			return x.probabilityFactor;
		}

		// Token: 0x06004E23 RID: 20003 RVA: 0x001FE4D6 File Offset: 0x001FC8D6
		[CompilerGenerated]
		private static float <GetSumProbabilityFactor>m__2(RandomBrush.RandomTileData x)
		{
			return x.probabilityFactor;
		}

		// Token: 0x04003C5C RID: 15452
		[Obsolete("Use RandomTileList instead")]
		public List<uint> RandomTiles = new List<uint>();

		// Token: 0x04003C5D RID: 15453
		public List<RandomBrush.RandomTileData> RandomTileList = new List<RandomBrush.RandomTileData>();

		// Token: 0x04003C5E RID: 15454
		public uint RandomizeFlagMask;

		// Token: 0x04003C5F RID: 15455
		[Tooltip("If activated, the brush id for this brush will be overwritten by the brush id of the selected tile. This should be activated to support animated brushes.")]
		public bool RemoveBrushIdAfterRefresh;

		// Token: 0x04003C60 RID: 15456
		private List<RandomBrush.RandomTileData> m_sortedList;

		// Token: 0x04003C61 RID: 15457
		private float m_sumProbabilityFactor;

		// Token: 0x04003C62 RID: 15458
		[CompilerGenerated]
		private static Func<uint, RandomBrush.RandomTileData> <>f__am$cache0;

		// Token: 0x04003C63 RID: 15459
		[CompilerGenerated]
		private static Func<RandomBrush.RandomTileData, float> <>f__am$cache1;

		// Token: 0x04003C64 RID: 15460
		[CompilerGenerated]
		private static Func<RandomBrush.RandomTileData, float> <>f__am$cache2;

		// Token: 0x02000B8A RID: 2954
		[Serializable]
		public class RandomTileData
		{
			// Token: 0x06004E24 RID: 20004 RVA: 0x001FE4DE File Offset: 0x001FC8DE
			public RandomTileData()
			{
			}

			// Token: 0x04003C65 RID: 15461
			public uint tileData;

			// Token: 0x04003C66 RID: 15462
			[Range(0f, 1f)]
			public float probabilityFactor;
		}
	}
}
