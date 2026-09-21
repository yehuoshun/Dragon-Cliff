using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000360 RID: 864
public class ItemControl : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IEventSystemHandler
{
	// Token: 0x06001742 RID: 5954 RVA: 0x000AAE68 File Offset: 0x000A9268
	public ItemControl()
	{
	}

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000AAE70 File Offset: 0x000A9270
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000AAE78 File Offset: 0x000A9278
	public Image Background
	{
		[CompilerGenerated]
		get
		{
			return this.<Background>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Background>k__BackingField = value;
		}
	}

	// Token: 0x06001745 RID: 5957 RVA: 0x000AAE81 File Offset: 0x000A9281
	public void Awake()
	{
		this._pointIn = false;
		this.Background = base.GetComponent<Image>();
		if (this.GradeImage != null)
		{
			this.GradeImage.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001746 RID: 5958 RVA: 0x000AAEB8 File Offset: 0x000A92B8
	private void Update()
	{
		if (this._pointIn)
		{
			this.PresentInfo();
		}
	}

	// Token: 0x06001747 RID: 5959 RVA: 0x000AAECC File Offset: 0x000A92CC
	public void SetItem(Item item, bool isConsumable = false)
	{
		this._item = item;
		this.ItemSprite.sprite = FilePath.GetRecipeImage(item.Type);
		this._isConsumable = isConsumable;
		if (!isConsumable)
		{
			this.GradeImage.gameObject.SetActive(true);
			this.GradeImage.sprite = FilePath.GetItemGradeBackground(item.ItemGrade, item.IsStarItem());
		}
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x000AAF30 File Offset: 0x000A9330
	public Item GetItem()
	{
		return this._item;
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x000AAF38 File Offset: 0x000A9338
	public void SetDefaultItem(EquipmentType type)
	{
		if (this.GradeImage != null)
		{
			this.GradeImage.gameObject.SetActive(false);
		}
		this._type = type;
		this.ItemSprite.sprite = FilePath.GetDefaultEquipmentIconByEquipmentType(type);
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x000AAF74 File Offset: 0x000A9374
	private void PresentInfo()
	{
		if (this._item == null)
		{
			this.OpenTooltip(new TooltipItem
			{
				Title = "No item on " + this._type,
				Description = "No item on " + this._type,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
		else
		{
			Color gradeColor = FilePath.GetGradeColor(this._item.ItemGrade);
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._item.GetSpecialEffects())
			{
				text4 = text4 + specialEffectDataLoad.GetDescription().Details1 + "\n";
			}
			foreach (AttributeModifier attributeModifier in this._item.PrimaryAttributeModifiers)
			{
				string text5 = text2;
				text2 = string.Concat(new string[]
				{
					text5,
					attributeModifier.AttributeType.GetDescription().Title,
					": ",
					attributeModifier.GetDisplayValue().ToDisplayValueFormat(),
					"\n"
				});
			}
			foreach (AttributeModifier attributeModifier2 in this._item.AdditionalAttributeModifiers)
			{
				string text5 = text3;
				text3 = string.Concat(new string[]
				{
					text5,
					attributeModifier2.AttributeType.GetDescription().Title,
					": ",
					attributeModifier2.GetDisplayValue().ToDisplayValueFormat(),
					"\n"
				});
			}
			text = string.Concat(new string[]
			{
				this._item.GetDescription().Details1,
				"\n",
				(!string.IsNullOrEmpty(text4)) ? string.Empty : ("\n<size=13><color=yellow>" + text4 + "</color></size>\n"),
				"<color=blue>",
				text2,
				"</color><color=purple>",
				text3,
				"</color>"
			});
			TooltipItem item = new TooltipItem
			{
				Title = this._item.GetDescription().Title,
				Description = ((this._item == null) ? this._item.Type.GetDescription().Details1 : text),
				TitleColor = gradeColor,
				Position = base.transform.position,
				Image = FilePath.GetRecipeImage(this._item.Type),
				BackgroundImage = ((this._item == null) ? FilePath.GetItemGradeBackground(QualityGrade.Normal, false) : FilePath.GetItemGradeBackground(this._item.ItemGrade, this._item.IsStarItem())),
				Level = ((this._item == null) ? string.Empty : ("Lv " + this._item.Level)),
				PrimaryNumber = ((this._item == null) ? string.Empty : ((Math.Abs(this._item.GetMainAttributeValue()) <= 0.01) ? string.Empty : this._item.GetMainAttributeValue().ToString("0")))
			};
			this.OpenTooltip(item, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x000AB374 File Offset: 0x000A9774
	public void OnPointerExit(PointerEventData eventData)
	{
		this._pointIn = false;
		this.CloseTooltip();
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x000AB383 File Offset: 0x000A9783
	public void OnPointerEnter(PointerEventData eventData)
	{
		this._pointIn = true;
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x000AB38C File Offset: 0x000A978C
	public void AdventurerFinished()
	{
		this._item = null;
		this._pointIn = false;
		this.SetDefaultItem(this._type);
	}

	// Token: 0x0400173C RID: 5948
	public Image ItemSprite;

	// Token: 0x0400173D RID: 5949
	public Image GradeImage;

	// Token: 0x0400173E RID: 5950
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image <Background>k__BackingField;

	// Token: 0x0400173F RID: 5951
	private Item _item;

	// Token: 0x04001740 RID: 5952
	private bool _pointIn;

	// Token: 0x04001741 RID: 5953
	private EquipmentType _type;

	// Token: 0x04001742 RID: 5954
	private bool _isConsumable;
}
