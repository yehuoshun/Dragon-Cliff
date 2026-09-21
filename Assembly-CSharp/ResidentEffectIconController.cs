using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200024A RID: 586
public class ResidentEffectIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000F23 RID: 3875 RVA: 0x000935EC File Offset: 0x000919EC
	public ResidentEffectIconController()
	{
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x000935F4 File Offset: 0x000919F4
	public void Init(IResidentEffect effect)
	{
		this.IconImage.sprite = FilePath.GetResidentEffectIcon(effect.CorrespondingEffectType);
		this.AmountText.text = this.GetAttribute(effect);
		this._effect = effect;
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x00093628 File Offset: 0x00091A28
	public string GetAttribute(IResidentEffect effect)
	{
		if (effect is ArmorSaleResidentEffect)
		{
			return "+" + ((ArmorSaleResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is DeterminationResidentEffect)
		{
			return "+" + 1;
		}
		if (effect is DivineHeartResidentEffect)
		{
			return "+" + ((DivineHeartResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is LuckResidentEffect)
		{
			return "+" + ((LuckResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is MysticStoneResidentEffect)
		{
			return "+" + ((MysticStoneResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is PracticeResidentEffect)
		{
			return "+" + ((PracticeResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is ProductionResidentEffect)
		{
			return "+" + ((ProductionResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		if (effect is WealthResidentEffect)
		{
			return string.Empty;
		}
		if (effect is WeaponSaleResidentEffect)
		{
			return "+" + ((WeaponSaleResidentEffect)effect).CurrentRate.ToExpressionMultiply100();
		}
		return string.Empty;
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x00093774 File Offset: 0x00091B74
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this._effect.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x000937CF File Offset: 0x00091BCF
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04001083 RID: 4227
	public Image IconImage;

	// Token: 0x04001084 RID: 4228
	public TextMeshProUGUI AmountText;

	// Token: 0x04001085 RID: 4229
	private IResidentEffect _effect;
}
