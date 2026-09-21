using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BA4 RID: 2980
	[Serializable]
	public class TileView
	{
		// Token: 0x06004F16 RID: 20246 RVA: 0x0020483B File Offset: 0x00202C3B
		public TileView(string name, TileSelection tileSelection)
		{
			this.m_name = name;
			this.m_tileSelection = tileSelection;
		}

		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x06004F17 RID: 20247 RVA: 0x00204851 File Offset: 0x00202C51
		public string name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06004F18 RID: 20248 RVA: 0x00204859 File Offset: 0x00202C59
		public TileSelection tileSelection
		{
			get
			{
				return this.m_tileSelection;
			}
		}

		// Token: 0x04003CF9 RID: 15609
		[SerializeField]
		private string m_name;

		// Token: 0x04003CFA RID: 15610
		[SerializeField]
		private TileSelection m_tileSelection;
	}
}
