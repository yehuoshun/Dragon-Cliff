using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200038A RID: 906
public static class ItemHoverTooltip
{
	// Token: 0x06001849 RID: 6217 RVA: 0x000B99E4 File Offset: 0x000B7DE4
	public static TooltipItem GetTooltipByItem(Item ItemToPresentTooltip, Transform toDisplayOn)
	{
		Color gradeColor = FilePath.GetGradeColor(ItemToPresentTooltip.ItemGrade);
		List<ItemSocket> sockets = ItemToPresentTooltip.Sockets;
		string text = string.Empty;
		List<Sprite> list = new List<Sprite>();
		List<Sprite> list2 = new List<Sprite>();
		string text2 = string.Empty;
		string text3 = string.Empty;
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in ItemToPresentTooltip.GetSpecialEffects())
		{
			text3 = text3 + specialEffectDataLoad.GetDescription().Details1 + "\n";
		}
		foreach (AttributeModifier attributeModifier in ItemToPresentTooltip.GetAttributeModifiers())
		{
			string text4 = text2;
			text2 = string.Concat(new string[]
			{
				text4,
				attributeModifier.AttributeType.GetDescription().Title,
				": ",
				attributeModifier.GetDisplayValue().ToDisplayValueFormat(),
				"\n"
			});
		}
		text = string.Concat(new string[]
		{
			ItemToPresentTooltip.GetDescription().Details1,
			"\n",
			string.IsNullOrEmpty(text3) ? string.Empty : string.Concat(new string[]
			{
				"\n<size=13><color=#",
				ColorUtility.ToHtmlStringRGB(ColorPicker.Legendary),
				">",
				text3,
				"</color></size>\n"
			}),
			"<color=#",
			ColorUtility.ToHtmlStringRGB(ColorPicker.Rare),
			">",
			text2,
			"</color>"
		});
		text += ((sockets.Count <= 0) ? string.Empty : ("\n" + UIComponentType.ItemControllerGemSocketTitle.GetName() + ": "));
		foreach (ItemSocket itemSocket in sockets)
		{
			list.Add(FilePath.GetSocketImage(itemSocket.SocketType));
		}
		foreach (ItemSocket itemSocket2 in sockets)
		{
			list2.Add((!(itemSocket2.Gem is Item)) ? null : FilePath.GetRecipeImage((itemSocket2.Gem as Item).Type));
		}
		return new TooltipItem
		{
			Title = ItemToPresentTooltip.Type.GetDescription().Title,
			Type = ItemToPresentTooltip.ItemGrade.GetDescription().Title + " " + ItemToPresentTooltip.Type.GetResourceCategory().GetDescription().Title,
			Description = text,
			Icons = list,
			InnerIcons = list2,
			Value = ItemToPresentTooltip.GetPrice().DoubleToString() + " G",
			TitleColor = gradeColor,
			Position = toDisplayOn.position,
			Image = FilePath.GetRecipeImage(ItemToPresentTooltip.Type),
			BackgroundImage = FilePath.GetItemGradeBackground(ItemToPresentTooltip.ItemGrade, ItemToPresentTooltip.IsStarItem()),
			Level = "Lv " + ItemToPresentTooltip.Level,
			PrimaryNumber = ((Math.Abs(ItemToPresentTooltip.GetMainAttributeValue()) <= 0.01) ? string.Empty : ItemToPresentTooltip.GetMainAttributeValue().ToString("0"))
		};
	}
}
