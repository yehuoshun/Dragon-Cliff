using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200019A RID: 410
public class ReforgePanelController : MonoBehaviour
{
	// Token: 0x06000AE6 RID: 2790 RVA: 0x000838B9 File Offset: 0x00081CB9
	public ReforgePanelController()
	{
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000838C1 File Offset: 0x00081CC1
	private void OnEnable()
	{
		this.ResetPanel();
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000838CC File Offset: 0x00081CCC
	public void PutInItem(Item item)
	{
		if (item == null)
		{
			return;
		}
		this._replacingAttribute = null;
		this.SelectedItem = item;
		this.ItemIcon.Init(item);
		this.PropertyPanel.Init(item.GetReforgePotentialAttributes());
		this.RequirementPanel.Init(item.GetReforgingCost());
		this.SelectAttributePanel.gameObject.SetActive(false);
		this.SetPanelContent(true);
		this.PreReforge();
		this.ScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x06000AE9 RID: 2793 RVA: 0x0008394C File Offset: 0x00081D4C
	public void PreReforge()
	{
		if (this.SelectedItem != null && this.SelectedItem.IsReforgeable())
		{
			this.SelectAttributePanel.Init(this.SelectedItem.GetReforgeableAttributes());
			this.SelectAttributePanel.gameObject.SetActive(true);
		}
		else
		{
			this.DisplayWarningText(UIComponentType.FurnacePanelNotReforgable.GetName());
		}
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x000839B0 File Offset: 0x00081DB0
	public void SelectReplacingAttribute(AttributeModifier attribute)
	{
		this._replacingAttribute = attribute;
		this.SetPanelContent(true);
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x000839C0 File Offset: 0x00081DC0
	public void SaveOriginalAttribute()
	{
		if (this.SelectedItem != null)
		{
			this.PutInItem(this.SelectedItem);
		}
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000839D9 File Offset: 0x00081DD9
	public void StartReforge()
	{
		this.Reforging();
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000839E4 File Offset: 0x00081DE4
	public List<AttributeModifier> Reforging()
	{
		this.ScrollRect.verticalNormalizedPosition = 1f;
		if (this.SelectedItem != null && this.SelectedItem.IsReforgeable())
		{
			List<AttributeModifier> list = this.SelectedItem.Reforging();
			this.AttributePanel.Init(list);
			this.SetPanelContent(false);
			return list;
		}
		this.DisplayWarningText(UIComponentType.FurnacePanelNotReforgable.GetName());
		return null;
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x00083A50 File Offset: 0x00081E50
	private void SetPanelContent(bool beforeReforging)
	{
		this.RequirementPanel.gameObject.SetActive(beforeReforging);
		this.PropertyPanel.gameObject.SetActive(true);
		this.SaveOriginalAttributeButton.gameObject.SetActive(!beforeReforging);
		this.AttributePanel.gameObject.SetActive(!beforeReforging);
		bool interactable = beforeReforging && this.SelectedItem != null && this.SelectedItem.IsReforgeable() && this._replacingAttribute != null && this.SelectedItem.GetReforgingCost().MetRequirements();
		this.ReforgeButton.interactable = interactable;
		this.AutoReforgeButton.interactable = interactable;
		this.SelectAttributePanel.gameObject.SetActive(beforeReforging);
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x00083B10 File Offset: 0x00081F10
	public void SelectAttributes(AttributeModifier modifier)
	{
		if (this.SelectedItem != null && this._replacingAttribute != null)
		{
			this.SelectedItem.SelectAttributeForReforging(modifier, this._replacingAttribute, true);
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.SuccessfulText.GetName(),
				Textcolor = ColorPicker.PositiveGreen
			});
			this.PutInItem(this.SelectedItem);
		}
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x00083B7A File Offset: 0x00081F7A
	public void TakeOffItem()
	{
		this.ResetPanel();
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x00083B84 File Offset: 0x00081F84
	public void ResetPanel()
	{
		this._replacingAttribute = null;
		this.ItemIcon.HideIcon();
		this.RequirementPanel.gameObject.SetActive(false);
		this.AttributePanel.gameObject.SetActive(false);
		this.PropertyPanel.gameObject.SetActive(false);
		this.SelectAttributePanel.gameObject.SetActive(false);
		this.SaveOriginalAttributeButton.gameObject.SetActive(false);
		this.ReforgeButton.interactable = false;
		this.AutoReforgeButton.interactable = false;
		this.ScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x00083C20 File Offset: 0x00082020
	public bool MetCostRequirement()
	{
		return this.SelectedItem.GetReforgingCost().MetRequirements();
	}

	// Token: 0x04000D81 RID: 3457
	public ReforgePreSelectAttributeController SelectAttributePanel;

	// Token: 0x04000D82 RID: 3458
	public EnchantPropertiesController PropertyPanel;

	// Token: 0x04000D83 RID: 3459
	public ReforgingAttributesController AttributePanel;

	// Token: 0x04000D84 RID: 3460
	public EnchantRequirementPanelController RequirementPanel;

	// Token: 0x04000D85 RID: 3461
	public EnchantItemController ItemIcon;

	// Token: 0x04000D86 RID: 3462
	public ScrollRect ScrollRect;

	// Token: 0x04000D87 RID: 3463
	public Button ReforgeButton;

	// Token: 0x04000D88 RID: 3464
	public Button AutoReforgeButton;

	// Token: 0x04000D89 RID: 3465
	public GameObject SaveOriginalAttributeButton;

	// Token: 0x04000D8A RID: 3466
	public Item SelectedItem;

	// Token: 0x04000D8B RID: 3467
	private AttributeModifier _replacingAttribute;
}
