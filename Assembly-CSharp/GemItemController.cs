using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x02000219 RID: 537
public class GemItemController : PageItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000E1A RID: 3610 RVA: 0x00090A04 File Offset: 0x0008EE04
	public GemItemController()
	{
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00090A0C File Offset: 0x0008EE0C
	// (set) Token: 0x06000E1C RID: 3612 RVA: 0x00090A14 File Offset: 0x0008EE14
	public GemItem GemItem
	{
		[CompilerGenerated]
		get
		{
			return this.<GemItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GemItem>k__BackingField = value;
		}
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x00090A20 File Offset: 0x0008EE20
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.MyItem = (PageItem)item;
		GemItem gemItem = item as GemItem;
		this.GemItem = gemItem;
		this.Level.text = this.GemItem.Gem.Level.ToLevelText();
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x00090A8C File Offset: 0x0008EE8C
	public override void OnPointerEnter(PointerEventData eventData)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		if (this.GemItem == null)
		{
			return;
		}
		foreach (AttributeModifier attributeModifier in this.GemItem.Gem.PrimaryAttributeModifiers)
		{
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				attributeModifier.AttributeType.GetDescription().Title,
				": ",
				attributeModifier.Value.ToString("0"),
				"\n"
			});
		}
		foreach (AttributeModifier attributeModifier2 in this.GemItem.Gem.AdditionalAttributeModifiers)
		{
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				attributeModifier2.AttributeType.GetDescription().Title,
				": ",
				attributeModifier2.Value.ToString("0"),
				"\n"
			});
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = this.GemItem.Gem.GetDescription().Title,
			Description = string.Concat(new object[]
			{
				"Gem Level: ",
				this.GemItem.Gem.Level,
				"\n<color=blue>",
				text,
				"</color><color=purple>",
				text2,
				"</color>"
			}),
			Position = base.transform.position,
			Image = FilePath.GetRecipeImage(this.GemItem.Gem.Type)
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x00090CA0 File Offset: 0x0008F0A0
	private TooltipItem GetSecondTooltip()
	{
		string text = string.Empty;
		SetItemLogicBase setItemLogicBase = ItemExtensions.SetItemLogics[this.GemItem.Gem.Type];
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in setItemLogicBase.MinorEffects())
		{
			Description description = specialEffectDataLoad.GetDescription();
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				description.Title,
				": ",
				description.Details1,
				"\n"
			});
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in setItemLogicBase.MajorEffects())
		{
			Description description2 = specialEffectDataLoad2.GetDescription();
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				description2.Title,
				": ",
				description2.Details1,
				"\n"
			});
		}
		return new TooltipItem
		{
			Title = "Special Effect",
			Description = text
		};
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x00090DFC File Offset: 0x0008F1FC
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000E21 RID: 3617 RVA: 0x00090E04 File Offset: 0x0008F204
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<InventoryGemPanelController>().SelectGem(this.GemItem);
	}

	// Token: 0x04000FE9 RID: 4073
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GemItem <GemItem>k__BackingField;

	// Token: 0x04000FEA RID: 4074
	public TextMeshProUGUI Level;
}
