using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001B6 RID: 438
public class GemDescriptionItemController : MonoBehaviour
{
	// Token: 0x06000B76 RID: 2934 RVA: 0x0008633B File Offset: 0x0008473B
	public GemDescriptionItemController()
	{
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x00086344 File Offset: 0x00084744
	public void Init(GemSetDescription gemItem)
	{
		this._gemItem = gemItem;
		this.GemImage.sprite = FilePath.GetGemImage(gemItem.SetItemLogicBase.CorrespondingSetResourceType);
		this.TitleText.text = gemItem.SetItemLogicBase.CorrespondingSetResourceType.GetDescription().Title;
		List<AttributeModifier> modifiers = gemItem.SetItemLogicBase.MinorAttributeModifiers();
		List<AttributeModifier> modifiers2 = gemItem.SetItemLogicBase.MajorAttributeModifiers();
		List<ISpecialEffectDataLoad> list = gemItem.SetItemLogicBase.MinorEffects();
		List<ISpecialEffectDataLoad> list2 = gemItem.SetItemLogicBase.MajorEffects();
		string text = string.Empty;
		string text2 = string.Empty;
		if (modifiers.GetDisplayValues().Count > 0 || list.Count > 0)
		{
			text = "<b>" + UIComponentType.GemItemMinorEffectTitle.GetName() + ": </b>\n";
		}
		if (list2.Count > 0 || modifiers2.GetDisplayValues().Count > 0)
		{
			text2 = "<b>" + UIComponentType.GemItemMajorEffectTitle.GetName() + ": </b>\n";
		}
		foreach (AttributeDisplayValue attributeDisplayValue in modifiers.GetDisplayValues())
		{
			string title = attributeDisplayValue.AttributeType.GetDescription().Title;
			string str = string.Concat(new string[]
			{
				title,
				": ",
				(attributeDisplayValue.Value <= 0.0) ? string.Empty : "+",
				attributeDisplayValue.ToDisplayValueFormat(),
				" "
			});
			text += str;
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in list)
		{
			text = text + specialEffectDataLoad.GetDescription().Details1 + " ";
		}
		foreach (AttributeDisplayValue attributeDisplayValue2 in modifiers2.GetDisplayValues())
		{
			string title2 = attributeDisplayValue2.AttributeType.GetDescription().Title;
			string str2 = string.Concat(new string[]
			{
				title2,
				": ",
				(attributeDisplayValue2.Value <= 0.0) ? string.Empty : "+",
				attributeDisplayValue2.ToDisplayValueFormat(),
				" "
			});
			text2 += str2;
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in list2)
		{
			text2 = text2 + specialEffectDataLoad2.GetDescription().Details1 + " ";
		}
		this.MinorText.text = text;
		this.MajorText.text = text2;
	}

	// Token: 0x04000DE5 RID: 3557
	public Image GemImage;

	// Token: 0x04000DE6 RID: 3558
	public TextMeshProUGUI TitleText;

	// Token: 0x04000DE7 RID: 3559
	public TextMeshProUGUI MinorText;

	// Token: 0x04000DE8 RID: 3560
	public TextMeshProUGUI MajorText;

	// Token: 0x04000DE9 RID: 3561
	private GemSetDescription _gemItem;
}
