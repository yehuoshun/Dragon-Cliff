using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class AdventurerEquipmentsSection : MonoBehaviour
{
	// Token: 0x060015A4 RID: 5540 RVA: 0x000AC143 File Offset: 0x000AA543
	public AdventurerEquipmentsSection()
	{
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000AC14C File Offset: 0x000AA54C
	public void SetEquipments(List<Item> equipments)
	{
		int i;
		for (i = 0; i < this.ItemControls.Length; i++)
		{
			Item item = equipments.FirstOrDefault((Item e) => e.SlotType == i + ItemType.Weapon);
			if (item != null)
			{
				this.ItemControls[i].SetItem(item, false);
			}
			else
			{
				this.ItemControls[i].SetDefaultItem(i + EquipmentType.Weapon);
			}
		}
	}

	// Token: 0x040015BF RID: 5567
	public ItemControl[] ItemControls;

	// Token: 0x02000C92 RID: 3218
	[CompilerGenerated]
	private sealed class <SetEquipments>c__AnonStorey0
	{
		// Token: 0x06005349 RID: 21321 RVA: 0x000AC1D8 File Offset: 0x000AA5D8
		public <SetEquipments>c__AnonStorey0()
		{
		}

		// Token: 0x0600534A RID: 21322 RVA: 0x000AC1E0 File Offset: 0x000AA5E0
		internal bool <>m__0(Item e)
		{
			return e.SlotType == this.i + ItemType.Weapon;
		}

		// Token: 0x040040D8 RID: 16600
		internal int i;
	}
}
