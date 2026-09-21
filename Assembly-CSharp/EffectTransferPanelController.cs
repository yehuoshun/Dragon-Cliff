using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x02000183 RID: 387
public class EffectTransferPanelController : MonoBehaviour
{
	// Token: 0x06000A27 RID: 2599 RVA: 0x0007E471 File Offset: 0x0007C871
	public EffectTransferPanelController()
	{
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x0007E479 File Offset: 0x0007C879
	private void OnEnable()
	{
		this.Clear();
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x0007E481 File Offset: 0x0007C881
	public bool FirstItemSelected()
	{
		return this._equipment != null;
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x0007E490 File Offset: 0x0007C890
	public bool Transfer()
	{
		if (this._equipment == null || this._scroll == null || this._selectedSpecialEffects == null)
		{
			return false;
		}
		if (this._equipment == this._scroll)
		{
			this.DisplayWarningText(UIComponentType.TransferringSameItemWarning.GetName());
			this.Clear();
			return false;
		}
		FurnaceMenuController componentInParent = base.GetComponentInParent<FurnaceMenuController>();
		AdventurerProfile adventurerProfile = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.GetEquipments().Any((Item e) => e.Id == this._equipment.Id));
		if (adventurerProfile != null)
		{
			adventurerProfile.Disrobe(this._equipment, true);
			if (componentInParent.HeroPanel.gameObject.activeSelf)
			{
				componentInParent.HeroPanel.UpdateEquipments();
			}
		}
		this._scroll.EnchantEffectForScroll(this._equipment, this._selectedSpecialEffects);
		base.GetComponentInParent<FurnaceMenuController>().ShowFinishMakingPanel(true, this._scroll, 1);
		this.Clear();
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.SuccessfulText.GetName(),
			Textcolor = ColorPicker.PositiveGreen
		});
		return true;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x0007E59D File Offset: 0x0007C99D
	public void SelectedEquipment(Item equipment)
	{
		this._equipment = equipment;
		if (equipment != null)
		{
			this._selectedSpecialEffects = null;
			this.EquipmentItem.Init(equipment, true);
			this.EquipmentItem.gameObject.SetActive(true);
		}
		this.UpdateAttributeStatus();
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x0007E5D8 File Offset: 0x0007C9D8
	private void UpdateAttributeStatus()
	{
		if (this._equipment == null)
		{
			this.AttributePanel.gameObject.SetActive(false);
		}
		else
		{
			this.AttributePanel.Init(this._equipment.GetEnchantableEffects(), this.CanTransfer());
			this.AttributePanel.gameObject.SetActive(true);
		}
		if (this._scroll != null)
		{
			if (this._scroll.Type.GetResourceCategory() == ResourceCategory.Scrolls)
			{
				this.WillBeReplaceText.text = UIComponentType.FurnaceTransferEnchantedAttributeWillBeReplaceWarning.GetName();
				this.WillBeReplaceText.gameObject.SetActive(this._scroll.AddedSpecialEffects != null && this._scroll.AddedSpecialEffects.Count > 0);
			}
			else if (this._scroll.IsEquipment())
			{
				this.WillBeReplaceText.text = UIComponentType.TransferringEffectWillBeReplaced.GetName();
				this.WillBeReplaceText.gameObject.SetActive(true);
			}
			else
			{
				this.WillBeReplaceText.gameObject.SetActive(false);
			}
		}
		else
		{
			this.WillBeReplaceText.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x0007E708 File Offset: 0x0007CB08
	public void SelectedScroll(Item scroll)
	{
		this._scroll = scroll;
		if (scroll != null)
		{
			this.ScrollItem.Init(scroll, false);
			this.ScrollItem.gameObject.SetActive(true);
			this.RequirementPanel.Init(scroll.GetEffectEnchantingCost());
			this.RequirementPanel.gameObject.SetActive(true);
		}
		this.UpdateAttributeStatus();
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x0007E768 File Offset: 0x0007CB68
	public void SelectEffects(List<ISpecialEffectDataLoad> effects)
	{
		this._selectedSpecialEffects = effects;
		base.GetComponentInParent<FurnaceMenuController>().PreTransfer();
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x0007E77C File Offset: 0x0007CB7C
	public void HideEquipment()
	{
		this._equipment = null;
		this.EquipmentItem.gameObject.SetActive(false);
		this.UpdateAttributeStatus();
		this.RequirementPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x0007E7B0 File Offset: 0x0007CBB0
	public void HideScroll()
	{
		this._scroll = null;
		this.WillBeReplaceText.gameObject.SetActive(false);
		this.ScrollItem.gameObject.SetActive(false);
		this.UpdateAttributeStatus();
		this.RequirementPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x0007E7FD File Offset: 0x0007CBFD
	public bool CanTransfer()
	{
		return this._equipment != null && this._scroll != null && this._scroll.GetEffectEnchantingCost().MetRequirements();
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x0007E828 File Offset: 0x0007CC28
	public void Clear()
	{
		this.HideEquipment();
		this.HideScroll();
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x0007E836 File Offset: 0x0007CC36
	[CompilerGenerated]
	private bool <Transfer>m__0(AdventurerProfile a)
	{
		return a.GetEquipments().Any((Item e) => e.Id == this._equipment.Id);
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x0007E84F File Offset: 0x0007CC4F
	[CompilerGenerated]
	private bool <Transfer>m__1(Item e)
	{
		return e.Id == this._equipment.Id;
	}

	// Token: 0x04000CED RID: 3309
	public TransferDisplayItemController EquipmentItem;

	// Token: 0x04000CEE RID: 3310
	public TransferDisplayItemController ScrollItem;

	// Token: 0x04000CEF RID: 3311
	public TransferAttributePanelController AttributePanel;

	// Token: 0x04000CF0 RID: 3312
	public EnchantRequirementPanelController RequirementPanel;

	// Token: 0x04000CF1 RID: 3313
	public TextMeshProUGUI WillBeReplaceText;

	// Token: 0x04000CF2 RID: 3314
	private Item _equipment;

	// Token: 0x04000CF3 RID: 3315
	private Item _scroll;

	// Token: 0x04000CF4 RID: 3316
	private List<ISpecialEffectDataLoad> _selectedSpecialEffects;
}
