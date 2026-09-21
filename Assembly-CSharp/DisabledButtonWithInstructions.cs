using System;
using UnityEngine.UI;

// Token: 0x02000388 RID: 904
public class DisabledButtonWithInstructions : GenericHoverController
{
	// Token: 0x0600183B RID: 6203 RVA: 0x000B98B9 File Offset: 0x000B7CB9
	public DisabledButtonWithInstructions()
	{
	}

	// Token: 0x0600183C RID: 6204 RVA: 0x000B98C4 File Offset: 0x000B7CC4
	public override void Start()
	{
		base.Start();
		this._button = base.GetComponent<Button>();
		this._backgroundImage = base.GetComponent<Image>();
		this._buttonText = base.transform.GetChild(0).GetComponent<Text>();
		this._buttonText.text = UIComponentType.StartAdventure.GetName();
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x000B9918 File Offset: 0x000B7D18
	public void Update()
	{
		if (this._pointerIn && !this._button.enabled)
		{
			this.HoverWithInstructiveInfo();
		}
		else
		{
			this.CloseUITooltip();
		}
	}

	// Token: 0x0600183E RID: 6206 RVA: 0x000B9948 File Offset: 0x000B7D48
	public void HoverWithInstructiveInfo()
	{
		this._backgroundImage.sprite = FilePath.GetFillSpriteBaseOnPercentage(0.1f);
		string name = UIComponentType.CandidateValidationNotification.GetName();
		this.OpenTooltip(new TooltipItem
		{
			Title = name,
			Image = null,
			Description = string.Empty,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x0600183F RID: 6207 RVA: 0x000B99B5 File Offset: 0x000B7DB5
	public void CloseUITooltip()
	{
		this.CloseTooltip();
		if (this._button.enabled)
		{
			this._backgroundImage.sprite = FilePath.GetFillSpriteBaseOnPercentage(1f);
		}
	}

	// Token: 0x040017FB RID: 6139
	private Text _buttonText;

	// Token: 0x040017FC RID: 6140
	private Button _button;

	// Token: 0x040017FD RID: 6141
	private Image _backgroundImage;

	// Token: 0x040017FE RID: 6142
	private const UIComponentType _buttonType = UIComponentType.StartAdventure;

	// Token: 0x040017FF RID: 6143
	private const UIComponentType _hoveredInfo = UIComponentType.CandidateValidationNotification;
}
