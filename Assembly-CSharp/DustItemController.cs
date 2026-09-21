using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002C1 RID: 705
public class DustItemController : PageItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060012D5 RID: 4821 RVA: 0x000A020E File Offset: 0x0009E60E
	public DustItemController()
	{
	}

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x060012D6 RID: 4822 RVA: 0x000A0216 File Offset: 0x0009E616
	// (set) Token: 0x060012D7 RID: 4823 RVA: 0x000A021E File Offset: 0x0009E61E
	public DustItem DustItem
	{
		[CompilerGenerated]
		get
		{
			return this.<DustItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DustItem>k__BackingField = value;
		}
	}

	// Token: 0x060012D8 RID: 4824 RVA: 0x000A0228 File Offset: 0x0009E628
	public override void Init(PageElement element)
	{
		this.DustItem = (DustItem)element;
		this.AmountText.text = this.DustItem.Amount.ToString("0");
		this.AmountText.gameObject.SetActive(this.DustItem.Amount != 0.0);
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.DustItem.ResourceType);
		this.GradeImage.sprite = FilePath.GetItemGradeBackground(this.DustItem.Grade, false);
		this.AmountText.text = this.DustItem.Amount.DoubleToString();
	}

	// Token: 0x060012D9 RID: 4825 RVA: 0x000A02E0 File Offset: 0x0009E6E0
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.DustItem == null)
		{
			return;
		}
		Description description = this.DustItem.ResourceType.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position,
			Image = FilePath.GetRecipeImage(this.DustItem.ResourceType)
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x060012DA RID: 4826 RVA: 0x000A0362 File Offset: 0x0009E762
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x060012DB RID: 4827 RVA: 0x000A036A File Offset: 0x0009E76A
	public void OnPointerClick(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x0400137D RID: 4989
	public Image GradeImage;

	// Token: 0x0400137E RID: 4990
	public TextMeshProUGUI AmountText;

	// Token: 0x0400137F RID: 4991
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DustItem <DustItem>k__BackingField;
}
