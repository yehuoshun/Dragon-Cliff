using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002E8 RID: 744
public class EquipmentSlotDisplayController : MonoBehaviour
{
	// Token: 0x060013CB RID: 5067 RVA: 0x0007CAAB File Offset: 0x0007AEAB
	public EquipmentSlotDisplayController()
	{
	}

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x060013CC RID: 5068 RVA: 0x0007CAB3 File Offset: 0x0007AEB3
	// (set) Token: 0x060013CD RID: 5069 RVA: 0x0007CABB File Offset: 0x0007AEBB
	public ItemController CurrentEquipment
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentEquipment>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentEquipment>k__BackingField = value;
		}
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x0007CAC4 File Offset: 0x0007AEC4
	public void Init(PageItem item)
	{
		this.Reset();
		ItemController itemController = null;
		if (item != null)
		{
			this.EquipedItem = item;
			itemController = UnityEngine.Object.Instantiate<ItemController>(this.ItemGameObject);
			itemController.Init(item);
			itemController.transform.SetParent(base.transform, false);
		}
		this.CurrentEquipment = itemController;
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x0007CB12 File Offset: 0x0007AF12
	protected void Reset()
	{
		if (this.CurrentEquipment != null && this.CurrentEquipment.gameObject != null)
		{
			UnityEngine.Object.Destroy(this.CurrentEquipment.gameObject);
			this.EquipedItem = null;
		}
	}

	// Token: 0x04001438 RID: 5176
	public ItemController ItemGameObject;

	// Token: 0x04001439 RID: 5177
	public UiSlotType SlotType;

	// Token: 0x0400143A RID: 5178
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ItemController <CurrentEquipment>k__BackingField;

	// Token: 0x0400143B RID: 5179
	protected PageItem EquipedItem;
}
