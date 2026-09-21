using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000187 RID: 391
public class EnchantPanelController : MonoBehaviour
{
	// Token: 0x06000A40 RID: 2624 RVA: 0x0007EBDB File Offset: 0x0007CFDB
	public EnchantPanelController()
	{
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x0007EBE3 File Offset: 0x0007CFE3
	private void OnEnable()
	{
		this.ResetPanel();
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x0007EBEC File Offset: 0x0007CFEC
	public void PutInItem(Item item)
	{
		if (item == null)
		{
			return;
		}
		this.SelectedItem = item;
		this.ItemIcon.Init(item);
		this.PropertyPanel.Init(item.GetEnchantableAttributes());
		this.RequirementPanel.Init(item.GetEnchantingCost());
		this.SetPanelContent(true);
		this.ScrollRect.verticalNormalizedPosition = 1f;
		this.ReplacePropertyTextObj.SetActive(item.GetNumberOfEnchantedTimes() > 0);
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x0007EC60 File Offset: 0x0007D060
	public void StartEnchant()
	{
		this.Enchanting();
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0007EC6C File Offset: 0x0007D06C
	public List<List<AttributeModifier>> Enchanting()
	{
		this.ScrollRect.verticalNormalizedPosition = 1f;
		if (this.SelectedItem != null && this.SelectedItem.IsEnchantable())
		{
			List<List<AttributeModifier>> list = this.SelectedItem.Enchanting();
			this.AttributePanel.Init(list);
			this.SetPanelContent(false);
			return list;
		}
		this.DisplayWarningText(UIComponentType.FurnacePanelNotEnchantable.GetName());
		return null;
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x0007ECD8 File Offset: 0x0007D0D8
	public void SelectAttributes(List<AttributeModifier> modifiers)
	{
		if (this.SelectedItem != null)
		{
			this.SelectedItem.SelectAttributesForEnchanting(modifiers, true);
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.SuccessfulText.GetName(),
				Textcolor = ColorPicker.PositiveGreen
			});
			this.PutInItem(this.SelectedItem);
		}
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x0007ED31 File Offset: 0x0007D131
	public void SaveOriginalAttribute()
	{
		if (this.SelectedItem != null)
		{
			this.PutInItem(this.SelectedItem);
		}
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0007ED4C File Offset: 0x0007D14C
	private void SetPanelContent(bool beforeEnchanting)
	{
		this.RequirementPanel.gameObject.SetActive(beforeEnchanting);
		this.PropertyPanel.gameObject.SetActive(true);
		this.AttributePanel.gameObject.SetActive(!beforeEnchanting);
		bool interactable = beforeEnchanting && this.SelectedItem != null && this.SelectedItem.IsEnchantable() && this.SelectedItem.GetEnchantingCost().MetRequirements();
		this.EnchantButton.interactable = interactable;
		this.AutoEnchantButton.interactable = interactable;
		this.SaveOriginalAttributeButton.gameObject.SetActive(!beforeEnchanting);
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0007EDF0 File Offset: 0x0007D1F0
	public bool MetCostRequirement()
	{
		return this.SelectedItem.GetEnchantingCost().MetRequirements();
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x0007EE02 File Offset: 0x0007D202
	public void TakeOffItem()
	{
		this.ResetPanel();
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0007EE0C File Offset: 0x0007D20C
	public void ResetPanel()
	{
		this.ItemIcon.HideIcon();
		this.RequirementPanel.gameObject.SetActive(false);
		this.PropertyPanel.gameObject.SetActive(false);
		this.AttributePanel.gameObject.SetActive(false);
		this.EnchantButton.interactable = false;
		this.AutoEnchantButton.interactable = false;
		this.SaveOriginalAttributeButton.gameObject.SetActive(false);
		this.ReplacePropertyTextObj.gameObject.SetActive(false);
		this.ScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x04000CFD RID: 3325
	public EnchantPropertiesController PropertyPanel;

	// Token: 0x04000CFE RID: 3326
	public EnchantAttributesController AttributePanel;

	// Token: 0x04000CFF RID: 3327
	public EnchantRequirementPanelController RequirementPanel;

	// Token: 0x04000D00 RID: 3328
	public EnchantItemController ItemIcon;

	// Token: 0x04000D01 RID: 3329
	public ScrollRect ScrollRect;

	// Token: 0x04000D02 RID: 3330
	public Button EnchantButton;

	// Token: 0x04000D03 RID: 3331
	public Button AutoEnchantButton;

	// Token: 0x04000D04 RID: 3332
	public GameObject ReplacePropertyTextObj;

	// Token: 0x04000D05 RID: 3333
	public GameObject SaveOriginalAttributeButton;

	// Token: 0x04000D06 RID: 3334
	public Item SelectedItem;
}
