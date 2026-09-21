using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BA3 RID: 2979
	[Serializable]
	public class TileSelection
	{
		// Token: 0x06004F11 RID: 20241 RVA: 0x0020473F File Offset: 0x00202B3F
		public TileSelection(List<uint> tileIds, int rowLength)
		{
			this.m_tileIds = ((tileIds == null) ? new List<uint>() : tileIds);
			this.m_rowLength = Mathf.Max(1, rowLength);
		}

		// Token: 0x170010C4 RID: 4292
		// (get) Token: 0x06004F12 RID: 20242 RVA: 0x00204772 File Offset: 0x00202B72
		public IList<uint> selectionData
		{
			get
			{
				return (this.m_tileIds == null) ? null : this.m_tileIds.AsReadOnly();
			}
		}

		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x06004F13 RID: 20243 RVA: 0x00204790 File Offset: 0x00202B90
		public int rowLength
		{
			get
			{
				return this.m_rowLength;
			}
		}

		// Token: 0x06004F14 RID: 20244 RVA: 0x00204798 File Offset: 0x00202B98
		public TileSelection Clone()
		{
			List<uint> tileIds = new List<uint>(this.m_tileIds);
			int rowLength = this.m_rowLength;
			return new TileSelection(tileIds, rowLength);
		}

		// Token: 0x06004F15 RID: 20245 RVA: 0x002047C0 File Offset: 0x00202BC0
		public void FlipVertical()
		{
			List<uint> list = new List<uint>();
			int num = 1 + (this.m_tileIds.Count - 1) / this.rowLength;
			for (int i = num - 1; i >= 0; i--)
			{
				for (int j = 0; j < this.rowLength; j++)
				{
					int index = i * this.rowLength + j;
					list.Add(this.m_tileIds[index]);
				}
			}
			this.m_tileIds = list;
		}

		// Token: 0x04003CF7 RID: 15607
		[SerializeField]
		private int m_rowLength = 1;

		// Token: 0x04003CF8 RID: 15608
		[SerializeField]
		private List<uint> m_tileIds;
	}
}
