using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class ItemOperationPanelController : MonoBehaviour
{
	// Token: 0x06001099 RID: 4249 RVA: 0x000982FE File Offset: 0x000966FE
	public ItemOperationPanelController()
	{
	}

	// Token: 0x0600109A RID: 4250 RVA: 0x00098306 File Offset: 0x00096706
	private void Start()
	{
		this._menu = base.GetComponentInParent<InventoryMenuController>();
	}

	// Token: 0x0600109B RID: 4251 RVA: 0x00098314 File Offset: 0x00096714
	public void Init()
	{
		if (this._menu == null)
		{
			this._menu = base.GetComponentInParent<InventoryMenuController>();
		}
		this._selectedItem = this._menu.SelectedItem;
		if (this._selectedItem == null)
		{
			return;
		}
		ResourceCategory resourceCategory = this._selectedItem.Item.Type.GetResourceCategory();
		bool flag = this._selectedItem.Item.IsEquipment() || resourceCategory == ResourceCategory.Scrolls || resourceCategory == ResourceCategory.Amulet || resourceCategory == ResourceCategory.Device;
		bool flag2 = resourceCategory == ResourceCategory.Usable;
		bool flag3 = resourceCategory == ResourceCategory.Gem;
		bool locked = this._selectedItem.Item.Locked;
		bool flag4 = this._selectedItem.Item.HasGemToExtract();
		bool flag5 = ResourceType.GrindingTable.HasObtained();
		bool flag6 = resourceCategory == ResourceCategory.Amulet;
		this._numberOfActiveButton = 0;
		bool flag7 = flag2 || flag3;
		this.UseButton.SetActive(flag7);
		this._numberOfActiveButton += ((!flag7) ? 0 : 1);
		bool flag8 = (flag || flag3) && !locked;
		this.SellButton.SetActive(flag8);
		this._numberOfActiveButton += ((!flag8) ? 0 : 1);
		bool flag9 = flag2 && !locked;
		this.SellAllButton.SetActive(flag9);
		this._numberOfActiveButton += ((!flag9) ? 0 : 1);
		bool flag10 = flag6;
		this.UpgradeButton.SetActive(flag10);
		this._numberOfActiveButton += ((!flag10) ? 0 : 1);
		bool flag11 = (flag || flag3) && !locked;
		this.SellSameTypeButton.SetActive(flag11);
		this._numberOfActiveButton += ((!flag11) ? 0 : 1);
		bool flag12 = flag && TownManager.Instance.Ui.HeroMenu.SelectedHero != null;
		this.EquipButton.SetActive(flag12);
		this._numberOfActiveButton += ((!flag12) ? 0 : 1);
		bool flag13 = flag5 && (((this._selectedItem.Item.Type.GetResourceCategory().IsWeapon() || this._selectedItem.Item.Type.GetResourceCategory().IsArmor()) && this._selectedItem.ItemGrade == QualityGrade.Ancient) || flag3) && !locked;
		this.BreakButton.SetActive(flag13);
		this._numberOfActiveButton += ((!flag13) ? 0 : 1);
		bool flag14 = !locked && (flag || flag3);
		this.LockButton.SetActive(flag14);
		this._numberOfActiveButton += ((!flag14) ? 0 : 1);
		bool flag15 = locked;
		this.UnlockButton.SetActive(flag15);
		this._numberOfActiveButton += ((!flag15) ? 0 : 1);
		this.ExtractButton.SetActive(flag4);
		this._numberOfActiveButton += ((!flag4) ? 0 : 1);
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x0009866C File Offset: 0x00096A6C
	public float GetWidth()
	{
		return this.UseButton.GetComponent<RectTransform>().rect.width;
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x00098694 File Offset: 0x00096A94
	public float GetHeight()
	{
		float height = this.UseButton.GetComponent<RectTransform>().rect.height;
		return (height + 5f) * (float)this._numberOfActiveButton;
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x000986C9 File Offset: 0x00096AC9
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x040011BC RID: 4540
	public GameObject EquipButton;

	// Token: 0x040011BD RID: 4541
	public GameObject UseButton;

	// Token: 0x040011BE RID: 4542
	public GameObject SellButton;

	// Token: 0x040011BF RID: 4543
	public GameObject SellAllButton;

	// Token: 0x040011C0 RID: 4544
	public GameObject UpgradeButton;

	// Token: 0x040011C1 RID: 4545
	public GameObject SellSameTypeButton;

	// Token: 0x040011C2 RID: 4546
	public GameObject ExtractButton;

	// Token: 0x040011C3 RID: 4547
	public GameObject BreakButton;

	// Token: 0x040011C4 RID: 4548
	public GameObject LockButton;

	// Token: 0x040011C5 RID: 4549
	public GameObject UnlockButton;

	// Token: 0x040011C6 RID: 4550
	public GameObject DiscardButton;

	// Token: 0x040011C7 RID: 4551
	private InventoryMenuController _menu;

	// Token: 0x040011C8 RID: 4552
	private NormalItem _selectedItem;

	// Token: 0x040011C9 RID: 4553
	private int _numberOfActiveButton;
}
