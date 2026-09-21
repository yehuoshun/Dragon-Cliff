using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000309 RID: 777
public class WorldSelectUsableItemPanelController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060014A2 RID: 5282 RVA: 0x000A80FD File Offset: 0x000A64FD
	public WorldSelectUsableItemPanelController()
	{
	}

	// Token: 0x060014A3 RID: 5283 RVA: 0x000A8105 File Offset: 0x000A6505
	private void OnEnable()
	{
		this.CloseOperationPanel();
	}

	// Token: 0x060014A4 RID: 5284 RVA: 0x000A8110 File Offset: 0x000A6510
	public void Init()
	{
		List<ResourceProfileAntiCheat> list = GameWorld.instance.PlayerProfile.GetConsumables();
		list = (from c in list
		orderby c.ResourceType
		select c).ToList<ResourceProfileAntiCheat>();
		this.ItemPage.ResetPage();
		foreach (ResourceProfileAntiCheat resourceProfileAntiCheat in list)
		{
			if (resourceProfileAntiCheat.Amount > 0.0)
			{
				NormalItem normalItem = resourceProfileAntiCheat.ResourceType.ItemGenerate(ResourceSourceType.None, ItemGenerationQuality.CreateGraded(QualityGrade.Normal), 0, 1).ConvertToUiNormalItem();
				normalItem.Amount = resourceProfileAntiCheat.GetValue();
				this.ItemPage.AddNewItem(normalItem);
			}
		}
		if (this._selectedItem != null)
		{
			this.ItemPage.SelectElement(this._selectedItem.Id);
		}
		else
		{
			this.ItemPage.DiselectAllElement();
		}
	}

	// Token: 0x060014A5 RID: 5285 RVA: 0x000A822C File Offset: 0x000A662C
	public void SellItems()
	{
		if (this._selectedItem != null)
		{
			int num = GameWorld.instance.PlayerProfile.Items.Count((Item i) => i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level);
			if (this._sellAmountValue > num)
			{
				this._sellAmountValue = num;
			}
			if (this._sellAmountValue >= 0)
			{
				GameWorld.instance.PlayerProfile.ItemPutOnSale((from i in GameWorld.instance.PlayerProfile.Items
				where i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level
				select i).Take(this._sellAmountValue).ToList<Item>());
				this.Init();
				base.GetComponentInParent<WorldMapController>().UpdateUsableItem();
			}
		}
		this.CloseOperationPanel();
	}

	// Token: 0x060014A6 RID: 5286 RVA: 0x000A82DA File Offset: 0x000A66DA
	public void AutoSelectedItem(Item item)
	{
		this._selectedItem = item;
	}

	// Token: 0x060014A7 RID: 5287 RVA: 0x000A82E3 File Offset: 0x000A66E3
	public void LeftClickItem(ItemController item)
	{
		this.RightClickItem(item.NormalItem.Item);
	}

	// Token: 0x060014A8 RID: 5288 RVA: 0x000A82F6 File Offset: 0x000A66F6
	public void RightClickItem(Item item)
	{
		this._selectedItem = item;
		this.SelectItem();
		this.CloseOperationPanel();
	}

	// Token: 0x060014A9 RID: 5289 RVA: 0x000A830B File Offset: 0x000A670B
	public void SelectItem()
	{
		if (this._selectedItem == null)
		{
			return;
		}
		this.ItemPage.SelectElement(this._selectedItem.Id);
		this.Comfirm();
	}

	// Token: 0x060014AA RID: 5290 RVA: 0x000A8335 File Offset: 0x000A6735
	public void Comfirm()
	{
		if (this._selectedItem == null)
		{
			return;
		}
		base.GetComponentInParent<WorldMapController>().SelectUsableItem(this._selectedItem);
		this.CloseTooltip();
		base.gameObject.SetActive(false);
	}

	// Token: 0x060014AB RID: 5291 RVA: 0x000A8366 File Offset: 0x000A6766
	public void OpenOperationPanel()
	{
		this.ItemOperactionPanel.SetActive(true);
		this._sellAmountValue = 0;
		this.InputField.text = string.Empty;
	}

	// Token: 0x060014AC RID: 5292 RVA: 0x000A838B File Offset: 0x000A678B
	public void CloseOperationPanel()
	{
		this.ItemOperactionPanel.SetActive(false);
		this._sellAmountValue = 0;
		this.InputField.text = string.Empty;
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x000A83B0 File Offset: 0x000A67B0
	public void OnInputFieldChange()
	{
		if (this._selectedItem == null)
		{
			return;
		}
		Regex regex = new Regex("^[1-9]\\d*$");
		if (regex.IsMatch(this.InputField.text))
		{
			this._sellAmountValue = this.GetInputFieldValue();
			int num = GameWorld.instance.PlayerProfile.Items.Count((Item i) => i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level);
			if (this._sellAmountValue > num)
			{
				this._sellAmountValue = num;
				this.InputField.text = this._sellAmountValue.ToString();
			}
		}
		else
		{
			this.InputField.text = this._sellAmountValue.ToString();
		}
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x000A8468 File Offset: 0x000A6868
	public int GetInputFieldValue()
	{
		int result;
		if (string.IsNullOrEmpty(this.InputField.text))
		{
			result = 0;
		}
		else
		{
			int.TryParse(this.InputField.text, out result);
		}
		return result;
	}

	// Token: 0x060014AF RID: 5295 RVA: 0x000A84A5 File Offset: 0x000A68A5
	public void OnPointerClick(PointerEventData eventData)
	{
		this.CloseOperationPanel();
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x000A84AD File Offset: 0x000A68AD
	[CompilerGenerated]
	private static ResourceType <Init>m__0(ResourceProfileAntiCheat c)
	{
		return c.ResourceType;
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x000A84B5 File Offset: 0x000A68B5
	[CompilerGenerated]
	private bool <SellItems>m__1(Item i)
	{
		return i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level;
	}

	// Token: 0x060014B2 RID: 5298 RVA: 0x000A84E3 File Offset: 0x000A68E3
	[CompilerGenerated]
	private bool <SellItems>m__2(Item i)
	{
		return i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level;
	}

	// Token: 0x060014B3 RID: 5299 RVA: 0x000A8511 File Offset: 0x000A6911
	[CompilerGenerated]
	private bool <OnInputFieldChange>m__3(Item i)
	{
		return i.Type == this._selectedItem.Type && i.Level == this._selectedItem.Level;
	}

	// Token: 0x040014CE RID: 5326
	public ItemPaginationController ItemPage;

	// Token: 0x040014CF RID: 5327
	public GameObject ItemOperactionPanel;

	// Token: 0x040014D0 RID: 5328
	public TMP_InputField InputField;

	// Token: 0x040014D1 RID: 5329
	private Item _selectedItem;

	// Token: 0x040014D2 RID: 5330
	private int _sellAmountValue;

	// Token: 0x040014D3 RID: 5331
	[CompilerGenerated]
	private static Func<ResourceProfileAntiCheat, ResourceType> <>f__am$cache0;
}
