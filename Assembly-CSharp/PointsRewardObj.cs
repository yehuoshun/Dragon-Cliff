using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200033D RID: 829
public class PointsRewardObj : GenericHoverController
{
	// Token: 0x06001608 RID: 5640 RVA: 0x000ADDA4 File Offset: 0x000AC1A4
	public PointsRewardObj()
	{
	}

	// Token: 0x06001609 RID: 5641 RVA: 0x000ADDB8 File Offset: 0x000AC1B8
	public void SetPointInfo(ResourceType type, double amount, bool setColor = false)
	{
		this.PointTitle.text = type.GetDescription().Title;
		this.Amount.text = amount.ToExpression();
		this.PointImage.sprite = FilePath.GetRecipeImage(type);
		this.HoverInfo = type.GetDescription().Details1;
		if (setColor)
		{
			this.Amount.color = ((amount <= 0.0) ? Color.white : Color.green);
		}
	}

	// Token: 0x0600160A RID: 5642 RVA: 0x000ADE3D File Offset: 0x000AC23D
	public void Update()
	{
		if (this._pointerIn && !string.IsNullOrEmpty(this.HoverInfo))
		{
			this.UpdateHoverInfo();
		}
	}

	// Token: 0x0600160B RID: 5643 RVA: 0x000ADE60 File Offset: 0x000AC260
	public override void UpdateHoverInfo()
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = this.PointTitle.text,
			Description = this.HoverInfo,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x04001632 RID: 5682
	public TextMeshProUGUI PointTitle;

	// Token: 0x04001633 RID: 5683
	public TextMeshProUGUI Amount;

	// Token: 0x04001634 RID: 5684
	public Image PointImage;

	// Token: 0x04001635 RID: 5685
	private string HoverInfo = string.Empty;
}
