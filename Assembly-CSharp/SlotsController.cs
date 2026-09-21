using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
public class SlotsController : MonoBehaviour
{
	// Token: 0x060008D1 RID: 2257 RVA: 0x0007847B File Offset: 0x0007687B
	public SlotsController()
	{
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x00078483 File Offset: 0x00076883
	public void PlaceBuilding(TownSlot slot, GameObject building)
	{
		building.transform.SetParent(this.GetSlotGameObject(slot).transform, false);
		building.transform.localPosition = Vector3.zero;
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000784B0 File Offset: 0x000768B0
	public GameObject GetSlotGameObject(TownSlot slot)
	{
		switch (slot)
		{
		case TownSlot.One:
			return this.Slot1;
		case TownSlot.Two:
			return this.Slot2;
		case TownSlot.Three:
			return this.Slot3;
		case TownSlot.Four:
			return this.Slot4;
		case TownSlot.Five:
			return this.Slot5;
		case TownSlot.Six:
			return this.Slot6;
		case TownSlot.Seven:
			return this.Slot7;
		case TownSlot.Eight:
			return this.Slot8;
		case TownSlot.Nine:
			return this.Slot9;
		default:
			return this.Slot9;
		}
	}

	// Token: 0x04000B5A RID: 2906
	public GameObject Slot1;

	// Token: 0x04000B5B RID: 2907
	public GameObject Slot2;

	// Token: 0x04000B5C RID: 2908
	public GameObject Slot3;

	// Token: 0x04000B5D RID: 2909
	public GameObject Slot4;

	// Token: 0x04000B5E RID: 2910
	public GameObject Slot5;

	// Token: 0x04000B5F RID: 2911
	public GameObject Slot6;

	// Token: 0x04000B60 RID: 2912
	public GameObject Slot7;

	// Token: 0x04000B61 RID: 2913
	public GameObject Slot8;

	// Token: 0x04000B62 RID: 2914
	public GameObject Slot9;

	// Token: 0x04000B63 RID: 2915
	public GameObject ItemPurchasedCanvasPrefab;
}
