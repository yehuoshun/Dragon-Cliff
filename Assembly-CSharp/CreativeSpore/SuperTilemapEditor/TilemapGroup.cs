using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B9D RID: 2973
	[AddComponentMenu("SuperTilemapEditor/TilemapGroup", 10)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class TilemapGroup : MonoBehaviour
	{
		// Token: 0x06004EF1 RID: 20209 RVA: 0x0020406E File Offset: 0x0020246E
		public TilemapGroup()
		{
		}

		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x06004EF2 RID: 20210 RVA: 0x0020408F File Offset: 0x0020248F
		// (set) Token: 0x06004EF3 RID: 20211 RVA: 0x002040CA File Offset: 0x002024CA
		public Tilemap SelectedTilemap
		{
			get
			{
				return (this.m_selectedIndex < 0 || this.m_selectedIndex >= this.m_tilemaps.Count) ? null : this.m_tilemaps[this.m_selectedIndex];
			}
			set
			{
				this.m_selectedIndex = ((this.m_tilemaps == null) ? -1 : this.m_tilemaps.IndexOf(value));
			}
		}

		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06004EF4 RID: 20212 RVA: 0x002040EF File Offset: 0x002024EF
		public List<Tilemap> Tilemaps
		{
			get
			{
				return this.m_tilemaps;
			}
		}

		// Token: 0x170010C0 RID: 4288
		// (get) Token: 0x06004EF5 RID: 20213 RVA: 0x002040F7 File Offset: 0x002024F7
		// (set) Token: 0x06004EF6 RID: 20214 RVA: 0x002040FF File Offset: 0x002024FF
		public float UnselectedColorMultiplier
		{
			get
			{
				return this.m_unselectedColorMultiplier;
			}
			set
			{
				this.m_unselectedColorMultiplier = value;
			}
		}

		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06004EF7 RID: 20215 RVA: 0x00204108 File Offset: 0x00202508
		// (set) Token: 0x06004EF8 RID: 20216 RVA: 0x00204110 File Offset: 0x00202510
		public bool DisplayTilemapRList
		{
			get
			{
				return this.m_displayTilemapRList;
			}
			set
			{
				this.m_displayTilemapRList = value;
			}
		}

		// Token: 0x170010C2 RID: 4290
		public Tilemap this[int idx]
		{
			get
			{
				return this.m_tilemaps[idx];
			}
		}

		// Token: 0x170010C3 RID: 4291
		public Tilemap this[string name]
		{
			get
			{
				return this.FindTilemapByName(name);
			}
		}

		// Token: 0x06004EFB RID: 20219 RVA: 0x00204130 File Offset: 0x00202530
		private void OnValidate()
		{
			if (this.Tilemaps.Count != base.transform.childCount)
			{
				this.Refresh();
			}
		}

		// Token: 0x06004EFC RID: 20220 RVA: 0x00204153 File Offset: 0x00202553
		private void OnTransformChildrenChanged()
		{
			this.Refresh();
		}

		// Token: 0x06004EFD RID: 20221 RVA: 0x0020415B File Offset: 0x0020255B
		private void Start()
		{
			this.Refresh();
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x00204163 File Offset: 0x00202563
		private void OnDrawGizmosSelected()
		{
			if (this.SelectedTilemap)
			{
				this.SelectedTilemap.SendMessage("DoDrawGizmos", SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06004EFF RID: 20223 RVA: 0x00204188 File Offset: 0x00202588
		public Tilemap FindTilemapByName(string name)
		{
			return this.Tilemaps.Find((Tilemap x) => x.name == name);
		}

		// Token: 0x06004F00 RID: 20224 RVA: 0x002041BC File Offset: 0x002025BC
		public void Refresh()
		{
			this.m_tilemaps = new List<Tilemap>(base.GetComponentsInChildren<Tilemap>(true));
			if (this.m_tilemaps.Count > 0 && this.m_selectedIndex < 0)
			{
				this.m_selectedIndex = 0;
			}
			this.m_selectedIndex = Mathf.Clamp(this.m_selectedIndex, -1, this.m_tilemaps.Count);
		}

		// Token: 0x04003CDF RID: 15583
		[SerializeField]
		private List<Tilemap> m_tilemaps;

		// Token: 0x04003CE0 RID: 15584
		[SerializeField]
		private int m_selectedIndex = -1;

		// Token: 0x04003CE1 RID: 15585
		[SerializeField]
		[Range(0f, 1f)]
		private float m_unselectedColorMultiplier = 1f;

		// Token: 0x04003CE2 RID: 15586
		[SerializeField]
		private bool m_displayTilemapRList = true;

		// Token: 0x0200109D RID: 4253
		[CompilerGenerated]
		private sealed class <FindTilemapByName>c__AnonStorey0
		{
			// Token: 0x060069F9 RID: 27129 RVA: 0x0020421C File Offset: 0x0020261C
			public <FindTilemapByName>c__AnonStorey0()
			{
			}

			// Token: 0x060069FA RID: 27130 RVA: 0x00204224 File Offset: 0x00202624
			internal bool <>m__0(Tilemap x)
			{
				return x.name == this.name;
			}

			// Token: 0x0400649C RID: 25756
			internal string name;
		}
	}
}
