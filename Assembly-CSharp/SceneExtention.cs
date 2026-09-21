using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000A04 RID: 2564
public static class SceneExtention
{
	// Token: 0x060045B7 RID: 17847 RVA: 0x001C2D5D File Offset: 0x001C115D
	public static string DoubleToString(this double number)
	{
		return number.ToString("0");
	}

	// Token: 0x060045B8 RID: 17848 RVA: 0x001C2D6C File Offset: 0x001C116C
	public static string DoubleToShortNumber(this double number)
	{
		if (999999.0 >= number && number >= 10000.0)
		{
			return (number / 1000.0).RoundDouble(1) + "K";
		}
		if (999999999.0 >= number && number >= 1000000.0)
		{
			return (number / 1000000.0).RoundDouble(1) + "M";
		}
		if (999999999999.0 >= number && number >= 1000000000.0)
		{
			return (number / 1000000000.0).RoundDouble(1) + "B";
		}
		if (number >= 1000000000000.0)
		{
			return (number / 1000000000000.0).RoundDouble(1) + "T";
		}
		if (-999999.0 <= number && number <= -10000.0)
		{
			return (number / 1000.0).RoundDouble(1) + "K";
		}
		if (-999999999.0 <= number && number <= -1000000.0)
		{
			return (number / 1000000.0).RoundDouble(1) + "M";
		}
		if (-999999999999.0 <= number && number <= -1000000000.0)
		{
			return (number / 1000000000.0).RoundDouble(1) + "B";
		}
		if (number <= -1000000000000.0)
		{
			return (number / 1000000000000.0).RoundDouble(1) + "T";
		}
		return number.DoubleToString();
	}

	// Token: 0x060045B9 RID: 17849 RVA: 0x001C2F5C File Offset: 0x001C135C
	public static string LargeDoubleToShortNumber(this double number)
	{
		if (999999999.0 >= number && number >= 1000000.0)
		{
			return (number / 1000000.0).RoundDouble(1) + "M";
		}
		if (999999999999.0 >= number && number >= 1000000000.0)
		{
			return (number / 1000000000.0).RoundDouble(1) + "B";
		}
		if (number >= 1000000000000.0)
		{
			return (number / 1000000000000.0).RoundDouble(1) + "T";
		}
		if (-999999999.0 <= number && number <= -1000000.0)
		{
			return (number / 1000000.0).RoundDouble(1) + "M";
		}
		if (-999999999999.0 <= number && number <= -1000000000.0)
		{
			return (number / 1000000000.0).RoundDouble(1) + "B";
		}
		if (number <= -1000000000000.0)
		{
			return (number / 1000000000000.0).RoundDouble(1) + "T";
		}
		return number.DoubleToString();
	}

	// Token: 0x060045BA RID: 17850 RVA: 0x001C30CB File Offset: 0x001C14CB
	public static string ToColor(this string text, Color color)
	{
		return ColorPicker.GetHaxString(color, text);
	}

	// Token: 0x060045BB RID: 17851 RVA: 0x001C30D4 File Offset: 0x001C14D4
	public static string ToCommaFormat(this double number)
	{
		return number.ToString("N0");
	}

	// Token: 0x060045BC RID: 17852 RVA: 0x001C30E2 File Offset: 0x001C14E2
	public static string DoubleToStringDecimal(this double number)
	{
		return number.ToString("0.0");
	}

	// Token: 0x060045BD RID: 17853 RVA: 0x001C30F0 File Offset: 0x001C14F0
	public static int DoubleToInt(this double number)
	{
		return (int)number;
	}

	// Token: 0x060045BE RID: 17854 RVA: 0x001C30F4 File Offset: 0x001C14F4
	public static double RoundDouble(this double number, int numberOfDecimal)
	{
		if (number < 1.0 && number > 0.0)
		{
			return 1.0;
		}
		return Math.Round(number, numberOfDecimal);
	}

	// Token: 0x060045BF RID: 17855 RVA: 0x001C3125 File Offset: 0x001C1525
	public static double RoundDoubleToNoDecimal(this double number)
	{
		return Math.Round(number, 0);
	}

	// Token: 0x060045C0 RID: 17856 RVA: 0x001C312E File Offset: 0x001C152E
	public static string FloatToString(this float number)
	{
		return number.ToString("0.0");
	}

	// Token: 0x060045C1 RID: 17857 RVA: 0x001C313C File Offset: 0x001C153C
	public static string ToLevelText(this int level)
	{
		return "Lv." + level;
	}

	// Token: 0x060045C2 RID: 17858 RVA: 0x001C3150 File Offset: 0x001C1550
	public static void MoveItemAtIndexToFront<T>(this List<T> list, int index)
	{
		if (list.Count >= 1 && index >= 0)
		{
			T value = list[index];
			for (int i = index; i > 0; i--)
			{
				list[i] = list[i - 1];
			}
			list[0] = value;
		}
	}

	// Token: 0x060045C3 RID: 17859 RVA: 0x001C31A2 File Offset: 0x001C15A2
	public static string ToGameCurrency(this int price)
	{
		return SceneExtention.ChangeCurrencyColor(price.ToString());
	}

	// Token: 0x060045C4 RID: 17860 RVA: 0x001C31B6 File Offset: 0x001C15B6
	public static string ToGameCurrency(this double price)
	{
		return SceneExtention.ChangeCurrencyColor(price.DoubleToString());
	}

	// Token: 0x060045C5 RID: 17861 RVA: 0x001C31C3 File Offset: 0x001C15C3
	public static string ToGameCurrency(this string price)
	{
		return SceneExtention.ChangeCurrencyColor(price);
	}

	// Token: 0x060045C6 RID: 17862 RVA: 0x001C31CB File Offset: 0x001C15CB
	public static string ToAshCurrency(this string price)
	{
		return SceneExtention.ChangeAshCurrencyColor(price);
	}

	// Token: 0x060045C7 RID: 17863 RVA: 0x001C31D4 File Offset: 0x001C15D4
	public static GameObject PoolObject(this MonoBehaviour gameObj, PoolType type, Vector3 position = default(Vector3))
	{
		GameObject gameObject = ObjectPoolManager.Instance.Spawn(type, position);
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	// Token: 0x060045C8 RID: 17864 RVA: 0x001C31FF File Offset: 0x001C15FF
	public static void PoolDestroy(this GameObject gameObject, PoolType type)
	{
		ObjectPoolManager.Instance.Destroy(type, gameObject);
	}

	// Token: 0x060045C9 RID: 17865 RVA: 0x001C320D File Offset: 0x001C160D
	private static string ChangeCurrencyColor(string price)
	{
		return ColorPicker.GetHaxString(ColorPicker.MoneyTextColor, price + " G");
	}

	// Token: 0x060045CA RID: 17866 RVA: 0x001C3224 File Offset: 0x001C1624
	private static string ChangeAshCurrencyColor(string price)
	{
		return ColorPicker.GetHaxString(ColorPicker.AshTextColor, price + " " + UIComponentType.AshTitle.GetName());
	}

	// Token: 0x060045CB RID: 17867 RVA: 0x001C3248 File Offset: 0x001C1648
	public static float GetWidth(this RectTransform rectTran)
	{
		return rectTran.rect.width * TownManager.Instance.Ui.GetComponent<Canvas>().scaleFactor;
	}

	// Token: 0x060045CC RID: 17868 RVA: 0x001C3278 File Offset: 0x001C1678
	public static float GetHeight(this RectTransform rectTran)
	{
		return rectTran.rect.height * TownManager.Instance.Ui.GetComponent<Canvas>().scaleFactor;
	}

	// Token: 0x060045CD RID: 17869 RVA: 0x001C32A8 File Offset: 0x001C16A8
	public static float ToScale(this float number)
	{
		return number * TownManager.Instance.Ui.GetComponent<Canvas>().scaleFactor;
	}

	// Token: 0x060045CE RID: 17870 RVA: 0x001C32C0 File Offset: 0x001C16C0
	public static LogTexts SplitLogText(this string text, LogTextType textType, object obj)
	{
		string[] array = text.Split(new char[]
		{
			'[',
			']'
		});
		return new LogTexts
		{
			Texts = new List<LogText>
			{
				new LogText
				{
					Text = array[0] + "["
				},
				new LogText
				{
					Text = array[1],
					TextType = textType,
					RelatedObject = obj
				},
				new LogText
				{
					Text = "]" + array[2]
				}
			}
		};
	}

	// Token: 0x060045CF RID: 17871 RVA: 0x001C336C File Offset: 0x001C176C
	public static string GetColoredRequiredAmountText(this ResourceType type, double requiredAmount, bool titled = true)
	{
		double resourceAmount_AvaliableForProduction = GameWorld.instance.PlayerProfile.GetResourceAmount_AvaliableForProduction(type);
		if (titled)
		{
			return ColorPicker.GetColoredCompareText(requiredAmount, resourceAmount_AvaliableForProduction, type.GetDescription().Title);
		}
		return ColorPicker.GetColoredCompareText(requiredAmount, resourceAmount_AvaliableForProduction, null);
	}

	// Token: 0x060045D0 RID: 17872 RVA: 0x001C33AB File Offset: 0x001C17AB
	public static void OpenTooltip(this MonoBehaviour gameObject, TooltipItem item, TooltipItem secondItem = null, TooltipPosition tooltipPosition = TooltipPosition.None, float widthOffset = 0f, float heightOffset = 0f)
	{
		TownManager.Instance.Ui.OpenTooltip(item, secondItem, tooltipPosition, widthOffset, heightOffset);
	}

	// Token: 0x060045D1 RID: 17873 RVA: 0x001C33C3 File Offset: 0x001C17C3
	public static void CloseTooltip(this MonoBehaviour gameObject)
	{
		TownManager.Instance.Ui.CloseTooltip();
	}

	// Token: 0x060045D2 RID: 17874 RVA: 0x001C33D4 File Offset: 0x001C17D4
	public static void OpenDescriptionTooltip(this MonoBehaviour gameObject, TooltipItem item)
	{
		TownManager.Instance.Ui.OpenDescriptionTooltip(item);
	}

	// Token: 0x060045D3 RID: 17875 RVA: 0x001C33E6 File Offset: 0x001C17E6
	public static void CloseDescriptionTooltip(this MonoBehaviour gameObject)
	{
		TownManager.Instance.Ui.CloseDescriptionTooltip();
	}

	// Token: 0x060045D4 RID: 17876 RVA: 0x001C33F7 File Offset: 0x001C17F7
	public static void DisplyMovingNotification(this MonoBehaviour gameObject, FlyingText text)
	{
		NotificationMovingPanelController.Instance.DisplyNewText(text);
	}

	// Token: 0x060045D5 RID: 17877 RVA: 0x001C3404 File Offset: 0x001C1804
	public static void SetMainVolume(this MonoBehaviour gameObject, float value)
	{
		AudioListener.volume = value;
	}

	// Token: 0x060045D6 RID: 17878 RVA: 0x001C340C File Offset: 0x001C180C
	public static void SetMusicVolume(this MonoBehaviour gameObject, float value)
	{
		GameMusicController.Instance.SetMusicVolume(value);
	}

	// Token: 0x060045D7 RID: 17879 RVA: 0x001C341C File Offset: 0x001C181C
	public static void SetEffectVolume(this MonoBehaviour gameObject, float value)
	{
		TownManager.Instance.Ui.MainCamera.GetComponent<AudioSource>().volume = value;
		TownManager.Instance.Ui.BattleCamera.GetComponent<AudioSource>().volume = value;
		GameMusicController.Instance.SetEffectVolume(value);
	}

	// Token: 0x060045D8 RID: 17880 RVA: 0x001C3468 File Offset: 0x001C1868
	public static void AddLogText(this MonoBehaviour gameObject, LogTexts texts)
	{
		LogPanelController.Instance.AddText(texts);
	}

	// Token: 0x060045D9 RID: 17881 RVA: 0x001C3478 File Offset: 0x001C1878
	public static void AddLogTextOneLine(this MonoBehaviour gameObject, LogText text)
	{
		gameObject.AddLogText(new LogTexts
		{
			Texts = new List<LogText>
			{
				text
			}
		});
	}

	// Token: 0x060045DA RID: 17882 RVA: 0x001C34A8 File Offset: 0x001C18A8
	public static void DisplayWarningText(this MonoBehaviour gameObject, string text)
	{
		gameObject.DisplyMovingNotification(new FlyingText
		{
			Textcolor = ColorPicker.NagetiveRed,
			DisplyingText = text
		});
	}

	// Token: 0x060045DB RID: 17883 RVA: 0x001C34D4 File Offset: 0x001C18D4
	public static void InProgress(this MonoBehaviour gameObject, string description)
	{
		TownManager.Instance.Ui.ShowInProgressPanel(description);
	}

	// Token: 0x060045DC RID: 17884 RVA: 0x001C34E6 File Offset: 0x001C18E6
	public static void FinishedProgress(this MonoBehaviour gameObject)
	{
		TownManager.Instance.Ui.HideInProgressPanel();
	}

	// Token: 0x060045DD RID: 17885 RVA: 0x001C34F7 File Offset: 0x001C18F7
	public static void UpdateTimeState(this MonoBehaviour gameObject, float timeScale)
	{
		TownManager.Instance.Ui.GameSpeedPanel.UpdateTimeState(timeScale);
	}

	// Token: 0x060045DE RID: 17886 RVA: 0x001C3510 File Offset: 0x001C1910
	public static List<AttributeDisplayValue> OrderHeroDisplayValues(this IHeroInfoController infoC, List<AttributeDisplayValue> values)
	{
		AttributeDisplayValue attributeDisplayValue = values.FirstOrDefault((AttributeDisplayValue a) => a.AttributeType == AttributeType.Vitality);
		AttributeDisplayValue attributeDisplayValue2 = values.FirstOrDefault((AttributeDisplayValue a) => a.AttributeType == AttributeType.Strength);
		AttributeDisplayValue attributeDisplayValue3 = values.FirstOrDefault((AttributeDisplayValue a) => a.AttributeType == AttributeType.Intelligience);
		if (attributeDisplayValue != null)
		{
			values.Remove(attributeDisplayValue);
			values.Insert(0, attributeDisplayValue);
		}
		if (attributeDisplayValue3 != null)
		{
			values.Remove(attributeDisplayValue3);
			values.Insert(0, attributeDisplayValue3);
		}
		if (attributeDisplayValue2 != null)
		{
			values.Remove(attributeDisplayValue2);
			values.Insert(0, attributeDisplayValue2);
		}
		return values;
	}

	// Token: 0x060045DF RID: 17887 RVA: 0x001C35D0 File Offset: 0x001C19D0
	public static TooltipItem GetItemTooltip(this IItemControl itemControl, NormalItem normalItem)
	{
		Color titleColor = Color.white;
		List<Sprite> list = null;
		List<Sprite> list2 = null;
		string text = string.Empty;
		string type = string.Empty;
		if (normalItem.Item != null)
		{
			titleColor = ColorPicker.GetGradeColor(normalItem.Item.ItemGrade, false);
			List<ItemSocket> sockets = normalItem.Item.Sockets;
			list = ((sockets.Count <= 0) ? null : new List<Sprite>());
			list2 = ((!sockets.Any((ItemSocket s) => s.Gem != null)) ? null : new List<Sprite>());
			Item item = normalItem.Item;
			string text2 = string.Empty;
			string text3 = string.Empty;
			IOrderedEnumerable<ISpecialEffectDataLoad> orderedEnumerable = from e in item.GetSpecialEffects()
			orderby (!e.IsStarEffect()) ? 1 : 0
			select e;
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in orderedEnumerable)
			{
				Color color = (!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Star;
				text3 += ColorPicker.GetHaxString(color, specialEffectDataLoad.GetDescription().Details1 + "\n\n");
			}
			foreach (AttributeModifier attributeModifier in item.GetAttributeModifiers())
			{
				double value = attributeModifier.Value;
				bool flag = attributeModifier.AttributeModifierType == AttributeModifierType.Embeded;
				bool flag2 = attributeModifier.IsEnchanted();
				bool flag3 = attributeModifier.IsReforged();
				string text4 = string.Concat(new string[]
				{
					attributeModifier.AttributeType.GetDescription().Title,
					" ",
					(value <= 0.0) ? string.Empty : "+ ",
					attributeModifier.GetDisplayValue().ToDisplayValueFormat(),
					"\n"
				});
				if (flag)
				{
					text4 = ColorPicker.GetHaxString(Color.cyan, text4);
				}
				if (flag2)
				{
					text4 = ColorPicker.GetHaxString(ColorPicker.Epic, text4);
				}
				if (flag3)
				{
					text4 = ColorPicker.GetHaxString(ColorPicker.PositiveGreen, text4);
				}
				text2 += text4;
			}
			text = normalItem.Item.GetDescription().Details1 + "\n\n" + text3 + ColorPicker.GetHaxString(ColorPicker.Rare, text2);
			text += ((sockets.Count <= 0) ? string.Empty : ("\n" + UIComponentType.ItemControllerGemSocketTitle.GetName() + ": "));
			foreach (ItemSocket itemSocket in sockets)
			{
				list.Add(FilePath.GetSocketImage(itemSocket.SocketType));
			}
			foreach (ItemSocket itemSocket2 in sockets)
			{
				if (itemSocket2.Gem is Item)
				{
					list2.Add(FilePath.GetRecipeImage((itemSocket2.Gem as Item).Type));
				}
				else if (list2 != null)
				{
					list2.Add(null);
				}
			}
		}
		string powerLevel = string.Empty;
		if (normalItem.Item != null)
		{
			ResourceCategory resourceCategory = normalItem.Item.Type.GetResourceCategory();
			if (normalItem.Item.IsEquipment() || resourceCategory == ResourceCategory.Scrolls || resourceCategory == ResourceCategory.Device)
			{
				powerLevel = "(P" + normalItem.Item.ItemTierLevel + ")";
			}
			if (resourceCategory == ResourceCategory.Amulet)
			{
				type = (UIComponentType.EquipmentSet.GetName() + " " + normalItem.Item.Type.GetResourceCategory().GetDescription().Title).ToColor(ColorPicker.Set);
				text += "\n\n";
				TeamSetBase teamSetBase = normalItem.Item.Type.GetTeamSetBase();
				text = text + teamSetBase.SetType.GetName().ToColor(ColorPicker.Set) + "\n\n";
				BattleTeam battleTeam = GameWorld.instance.PlayerProfile.BattleTeams.FirstOrDefault((BattleTeam b) => b.Adventurers.Any((AdventurerProfile a) => a.GetEquipments().Any((Item e) => e.Id == normalItem.Item.Id)));
				int num = 0;
				using (List<ResourceType>.Enumerator enumerator5 = teamSetBase.TeamSetPieces.GetEnumerator())
				{
					while (enumerator5.MoveNext())
					{
						ResourceType setPiece = enumerator5.Current;
						string text5 = "   " + setPiece.GetDescription().Title + "\n";
						if (battleTeam != null)
						{
							bool flag4 = battleTeam.Adventurers.Any((AdventurerProfile a) => a.GetEquipments().Any((Item e) => e.Type == setPiece));
							Color color2 = ColorPicker.Grey;
							if (flag4)
							{
								color2 = ColorPicker.White;
								num++;
							}
							text += text5.ToColor(color2);
						}
						else
						{
							text += text5.ToColor((setPiece != normalItem.Item.Type) ? ColorPicker.Grey : ColorPicker.White);
						}
					}
				}
				text = text + "\n" + (UIComponentType.EquipmentSet.GetName() + "(3):\n").ToColor((num < 3) ? ColorPicker.Grey : ColorPicker.Set) + "\n";
				foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in teamSetBase.GetTeamBonus())
				{
					text = text + "   " + specialEffectDataLoad2.GetDescription().Details1.ToColor((num < 3) ? ColorPicker.Grey : ColorPicker.Set) + "\n";
				}
			}
			else
			{
				type = normalItem.Item.ItemGrade.GetDescription().Title + " " + normalItem.Item.Type.GetResourceCategory().GetDescription().Title;
			}
		}
		return new TooltipItem
		{
			Title = normalItem.ResourceType.GetDescription().Title,
			Type = type,
			Description = ((normalItem.Item == null) ? normalItem.ResourceType.GetDescription().Details1 : text),
			Icons = list,
			InnerIcons = list2,
			Value = normalItem.Price.DoubleToString() + " G",
			TitleColor = titleColor,
			ShowTypeIcon = (normalItem.Item != null && normalItem.Item.IsStarItem()),
			Position = (itemControl as MonoBehaviour).transform.position,
			Image = FilePath.GetRecipeImage(normalItem.ResourceType),
			BackgroundImage = ((normalItem.Item == null) ? FilePath.GetItemGradeBackground(QualityGrade.Normal, false) : FilePath.GetItemGradeBackground(normalItem.Item.ItemGrade, normalItem.Item.IsStarItem())),
			Level = ((normalItem.Item == null) ? string.Empty : ("Lv " + normalItem.Item.Level)),
			PowerLevel = powerLevel,
			PrimaryNumber = ((normalItem.Item == null) ? string.Empty : ((Math.Abs(normalItem.Item.GetMainAttributeValue()) <= 0.01) ? string.Empty : ((int)normalItem.Item.GetMainAttributeValue()).ToString()))
		};
	}

	// Token: 0x060045E0 RID: 17888 RVA: 0x001C3EE8 File Offset: 0x001C22E8
	public static TooltipItem GetGemSecondTooltip(this IGemControl control, ResourceType type)
	{
		string text = string.Empty;
		SetItemLogicBase setItemLogicBase = ItemExtensions.SetItemLogics[type];
		List<AttributeModifier> modifiers = setItemLogicBase.MinorAttributeModifiers();
		List<AttributeModifier> modifiers2 = setItemLogicBase.MajorAttributeModifiers();
		List<ISpecialEffectDataLoad> list = setItemLogicBase.MinorEffects();
		List<ISpecialEffectDataLoad> list2 = setItemLogicBase.MajorEffects();
		if (modifiers.GetDisplayValues().Count > 0 || list.Count > 0)
		{
			text = text + "\n<b>" + UIComponentType.GemItemMinorEffectTitle.GetName().ToColor(ColorPicker.PositiveGreen) + ":</b>\n";
		}
		foreach (AttributeDisplayValue attributeDisplayValue in modifiers.GetDisplayValues())
		{
			string title = attributeDisplayValue.AttributeType.GetDescription().Title;
			string str = string.Concat(new string[]
			{
				"   ",
				title,
				": ",
				(attributeDisplayValue.Value <= 0.0) ? string.Empty : "+",
				attributeDisplayValue.ToDisplayValueFormat()
			});
			text = text + str + "\n";
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in list)
		{
			text = text + "   " + specialEffectDataLoad.GetDescription().Details1 + "\n";
		}
		if (list2.Count > 0 || modifiers2.GetDisplayValues().Count > 0)
		{
			string text2 = "\n<b>" + UIComponentType.GemItemMajorEffectTitle.GetName().ToColor(ColorPicker.PositiveGreen) + ":</b>";
			if (list2.Count > 0)
			{
				text2 = text2 + " [" + list2[0].GetDescription().Title + "]\n";
			}
			else
			{
				text2 += "\n";
			}
			text += text2;
		}
		foreach (AttributeDisplayValue attributeDisplayValue2 in modifiers2.GetDisplayValues())
		{
			string title2 = attributeDisplayValue2.AttributeType.GetDescription().Title;
			string str2 = string.Concat(new string[]
			{
				"   ",
				title2,
				": ",
				(attributeDisplayValue2.Value <= 0.0) ? string.Empty : "+",
				attributeDisplayValue2.ToDisplayValueFormat()
			});
			text = text + str2 + "\n";
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in list2)
		{
			text = text + "   " + specialEffectDataLoad2.GetDescription().Details1 + "\n";
		}
		text = "<size=11>" + text + "</size>";
		return new TooltipItem
		{
			Title = UIComponentType.GemItemSecondTooltipTitle.GetName(),
			Description = text
		};
	}

	// Token: 0x060045E1 RID: 17889 RVA: 0x001C4264 File Offset: 0x001C2664
	public static TooltipItem GetSkillItemTooltip(this ISkillItemController skillItem, Skill skill, bool isDisplayingImage = false, AdventureUnitSkill unitSkill = null)
	{
		if (skill == null)
		{
			return new TooltipItem();
		}
		Description description = skill.GetDescription();
		string title = description.Title;
		string text = string.Empty;
		if (skill.CommandType == SkillCommandType.Active)
		{
			text = text + "\n<b>" + UIComponentType.SkillIconActiveSkillDetails1Title.GetName() + ": </b>\n";
		}
		text += description.Details1;
		if (skill.CommandType == SkillCommandType.Active)
		{
			string text2 = "\n\n<b>" + UIComponentType.SkillIconActiveSkillDetails2Title.GetName() + ": </b>\n" + description.Details2;
			ActiveSkillLogicBase activeSkillLogicBase = skill.GetSkillLogic() as ActiveSkillLogicBase;
			if (unitSkill != null && !activeSkillLogicBase.PassiveIsActive(unitSkill))
			{
				text2 = ColorPicker.GetHaxString(ColorPicker.Grey, text2);
			}
			text += text2;
		}
		string type = string.Empty;
		if (skill.CommandType == SkillCommandType.Active)
		{
			ActiveSkillLogicBase activeSkillLogicBase2 = skill.SkillType.GetSkillLogic() as ActiveSkillLogicBase;
			if (activeSkillLogicBase2 != null)
			{
				type = string.Concat(new object[]
				{
					UIComponentType.SkillIconGaugeCostTitle.GetName(),
					"： ",
					activeSkillLogicBase2.GetGaugeCost(skill),
					"\n",
					UIComponentType.SkillIconCoolingDownSecondesTitle.GetName(),
					"：",
					activeSkillLogicBase2.CoolingDownSeconds(skill)
				});
			}
		}
		text = ColorPicker.ReplaceSkillTag(text);
		Sprite image = (!isDisplayingImage) ? null : FilePath.GetSkillIconImage(skill.SkillType);
		MonoBehaviour monoBehaviour = skillItem as MonoBehaviour;
		return new TooltipItem
		{
			Title = title,
			Level = "Lv. " + skill.Level,
			Type = type,
			Description = text,
			Position = monoBehaviour.transform.position,
			Image = image
		};
	}

	// Token: 0x060045E2 RID: 17890 RVA: 0x001C4432 File Offset: 0x001C2832
	public static Vector3 MoveRectPosition(this MonoBehaviour obj, Vector3 direction, float distance)
	{
		return obj.transform.position + direction * distance * obj.GetComponentInParent<Canvas>().scaleFactor;
	}

	// Token: 0x060045E3 RID: 17891 RVA: 0x001C445C File Offset: 0x001C285C
	public static TooltipItem GetRecipeTooltip(this IRecipeControl controller, RecipeInfo recipe)
	{
		string description = string.Empty;
		if (recipe.ItemTierLevel >= 35)
		{
			description += ColorPicker.GetHaxString(ColorPicker.Legendary, UIComponentType.CapableRecipeSpecialEffectContained.GetName() + "\n\n");
		}
		if (recipe.Recipe.ProductType.GetResourceCategory() == ResourceCategory.Robe)
		{
			description = description + AttributeType.Intelligience.GetDescription().Title + ": +10%\n";
		}
		if (recipe.Recipe.ProductType.GetResourceCategory() == ResourceCategory.Leather)
		{
			description = description + AttributeType.Strength.GetDescription().Title + ": +10%\n";
		}
		List<AttributeType> extraAttributeTypes = recipe.Recipe.ProductType.GetCreationTemplate().ExtraGuarranteedSecondaryGradedAttributes(recipe.ItemTierLevel);
		extraAttributeTypes.AddRange(recipe.Recipe.ProductType.GetCreationTemplate().GuarranteedPrimaryGradedAttributes(recipe.ItemTierLevel));
		(from p in recipe.Recipe.ProductType.GetCreationTemplate().PropertyPotentials(recipe.ItemTierLevel)
		where p.IsGuaranteed
		select p).ToList<ItemPropertyPotential>().ForEach(delegate(ItemPropertyPotential p)
		{
			string text = string.Concat(new string[]
			{
				p.AttributeType.GetDescription().Title,
				": ",
				p.GetRangeFrom((double)ItemExtensions.ItemAttributeRandomness_Generation),
				" - ",
				p.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Generation),
				"\n"
			});
			text = ((!extraAttributeTypes.Contains(p.AttributeType)) ? text : ColorPicker.GetHaxString(ColorPicker.Yellow, text));
			description += text;
		});
		string powerLevel = "(P" + recipe.ItemTierLevel + ")";
		return new TooltipItem
		{
			Title = recipe.Recipe.ProductType.GetDescription().Title,
			Description = description,
			Type = recipe.Recipe.ProductType.GetResourceCategory().GetDescription().Title,
			Level = recipe.Recipe.GetRecipeLevel(recipe.ItemTierLevel).ToLevelText(),
			PowerLevel = powerLevel,
			Position = (controller as MonoBehaviour).transform.position,
			Image = FilePath.GetRecipeImage(recipe.Recipe.ProductType),
			Value = recipe.Recipe.ProductType.GetCreationTemplate().GetValueBase(recipe.ItemTierLevel) + " G"
		};
	}

	// Token: 0x060045E4 RID: 17892 RVA: 0x001C46A8 File Offset: 0x001C2AA8
	public static TooltipItem GetGemSetTooltip(this List<ItemController> items)
	{
		List<SetItemResult> setBenefits = (from e in items
		select e.NormalItem.Item).ToList<Item>().GetSetBenefits();
		string text = string.Empty;
		foreach (SetItemResult setItemResult in setBenefits)
		{
			List<AttributeModifier> minorModifiers = setItemResult.MinorModifiers;
			List<AttributeModifier> majorModifiers = setItemResult.MajorModifiers;
			List<ISpecialEffectDataLoad> minorEffects = setItemResult.MinorEffects;
			List<ISpecialEffectDataLoad> majorEffects = setItemResult.MajorEffects;
			if (minorModifiers.GetDisplayValues().Count > 0 || minorEffects.Count > 0)
			{
				text = text + "\n<b>" + UIComponentType.GemItemMinorEffectTitle.GetName().ToColor(ColorPicker.PositiveGreen) + ":</b>\n";
			}
			foreach (AttributeDisplayValue attributeDisplayValue in minorModifiers.GetDisplayValues())
			{
				string title = attributeDisplayValue.AttributeType.GetDescription().Title;
				string str = string.Concat(new string[]
				{
					"   ",
					title,
					": ",
					(attributeDisplayValue.Value <= 0.0) ? string.Empty : "+",
					attributeDisplayValue.ToDisplayValueFormat()
				});
				text = text + str + "\n";
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in minorEffects)
			{
				text = text + "   " + specialEffectDataLoad.GetDescription().Details1 + "\n";
			}
			if (majorEffects.Count > 0 || majorModifiers.GetDisplayValues().Count > 0)
			{
				string text2 = "\n<b>" + UIComponentType.GemItemMajorEffectTitle.GetName().ToColor(ColorPicker.PositiveGreen) + ":</b>";
				if (majorEffects.Count > 0)
				{
					text2 = text2 + " [" + majorEffects[0].GetDescription().Title + "]\n";
				}
				else
				{
					text2 += "\n";
				}
				text += text2;
			}
			foreach (AttributeDisplayValue attributeDisplayValue2 in majorModifiers.GetDisplayValues())
			{
				string title2 = attributeDisplayValue2.AttributeType.GetDescription().Title;
				string str2 = string.Concat(new string[]
				{
					"   ",
					title2,
					": ",
					(attributeDisplayValue2.Value <= 0.0) ? string.Empty : "+",
					attributeDisplayValue2.ToDisplayValueFormat()
				});
				text = text + str2 + "\n";
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in majorEffects)
			{
				text = text + "   " + specialEffectDataLoad2.GetDescription().Details1 + "\n";
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			return new TooltipItem
			{
				Title = UIComponentType.GemItemSecondTooltipTitle.GetName(),
				Description = text
			};
		}
		return null;
	}

	// Token: 0x060045E5 RID: 17893 RVA: 0x001C4AC4 File Offset: 0x001C2EC4
	public static TooltipItem GetInventoryEquipmentSecondTooltip(this NormalItem item)
	{
		PageHero selectedHero = TownManager.Instance.Ui.HeroMenu.SelectedHero;
		if (selectedHero == null)
		{
			return null;
		}
		EquipedItemResult itemEquipedResult = selectedHero.AdventurerProfile.GetItemEquipedResult(item.Item);
		string text = string.Empty;
		foreach (AttributeDisplayValue attributeDisplayValue in itemEquipedResult.Changes)
		{
			text += ((attributeDisplayValue.Value != 0.0) ? ((attributeDisplayValue.Value >= 0.0) ? (ColorPicker.GetPositiveColoredString(attributeDisplayValue.AttributeType.GetDescription().Title + ": +" + attributeDisplayValue.ToDisplayValueFormat()) + "\n") : (ColorPicker.GetNegativeColoredString(attributeDisplayValue.AttributeType.GetDescription().Title + ": " + attributeDisplayValue.ToDisplayValueFormat()) + "\n")) : string.Empty);
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in itemEquipedResult.AddedSpecialEffects)
		{
			text = text + "\n" + specialEffectDataLoad.GetDescription().Details1;
		}
		return new TooltipItem
		{
			Title = UIComponentType.EquipmentItemSecondTooltipTitle.GetName() + ":\n",
			Description = text,
			TitleColor = ColorPicker.Rare
		};
	}

	// Token: 0x060045E6 RID: 17894 RVA: 0x001C4C84 File Offset: 0x001C3084
	public static void SetUiActive(this CanvasGroup canvas, bool enable)
	{
		canvas.alpha = (float)((!enable) ? 0 : 1);
		canvas.interactable = enable;
		canvas.blocksRaycasts = enable;
	}

	// Token: 0x060045E7 RID: 17895 RVA: 0x001C4CA8 File Offset: 0x001C30A8
	public static string GetUiLocalizedText(UIComponentType type)
	{
		return type.GetName();
	}

	// Token: 0x060045E8 RID: 17896 RVA: 0x001C4CB0 File Offset: 0x001C30B0
	public static void PlaySoundClip(this MonoBehaviour gameObject, AudioClip clip)
	{
		if (TownManager.Instance.Ui.MainCamera.gameObject.activeSelf)
		{
			TownManager.Instance.Ui.MainCamera.GetComponent<AudioSource>().PlayOneShot(clip);
		}
	}

	// Token: 0x060045E9 RID: 17897 RVA: 0x001C4CEA File Offset: 0x001C30EA
	public static void PlaySoundClipInBattle(this MonoBehaviour gameObject, AudioClip clip)
	{
		TownManager.Instance.Ui.BattleCamera.GetComponent<AudioSource>().PlayOneShot(clip);
	}

	// Token: 0x060045EA RID: 17898 RVA: 0x001C4D08 File Offset: 0x001C3108
	public static TooltipPosition CalculatePivot()
	{
		Canvas component = TownManager.Instance.Ui.GetComponent<Canvas>();
		Rect rect = component.GetComponent<RectTransform>().rect;
		float num = rect.width / 2f * component.scaleFactor;
		float num2 = rect.height / 2f * component.scaleFactor;
		Vector3 mousePosition = Input.mousePosition;
		if (mousePosition.x <= num && mousePosition.y <= num2)
		{
			return TooltipPosition.BottomLeft;
		}
		if (mousePosition.x <= num && mousePosition.y > num2)
		{
			return TooltipPosition.TopLeft;
		}
		if (mousePosition.x > num && mousePosition.y <= num2)
		{
			return TooltipPosition.BottomRight;
		}
		if (mousePosition.x > num && mousePosition.y > num2)
		{
			return TooltipPosition.TopRight;
		}
		return TooltipPosition.TopLeft;
	}

	// Token: 0x060045EB RID: 17899 RVA: 0x001C4DD4 File Offset: 0x001C31D4
	public static bool GetAdditionalData(this MonoBehaviour obj, string key, bool defaultValue)
	{
		AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
		if (additionalData.ContainsBool(key))
		{
			return additionalData.GetBool(key);
		}
		return defaultValue;
	}

	// Token: 0x060045EC RID: 17900 RVA: 0x001C4E08 File Offset: 0x001C3208
	public static string GetAdditionalData(this MonoBehaviour obj, string key, string defaultValue)
	{
		AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
		if (additionalData.ContainsString(key))
		{
			return additionalData.GetString(key);
		}
		return defaultValue;
	}

	// Token: 0x060045ED RID: 17901 RVA: 0x001C4E3C File Offset: 0x001C323C
	public static double GetAdditionalData(this MonoBehaviour obj, string key, double defaultValue)
	{
		AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
		if (additionalData.ContainsDouble(key))
		{
			return additionalData.GetDouble(key);
		}
		return defaultValue;
	}

	// Token: 0x060045EE RID: 17902 RVA: 0x001C4E70 File Offset: 0x001C3270
	public static float GetAdditionalData(this MonoBehaviour obj, string key, float defaultValue)
	{
		AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
		if (additionalData.ContainsFloat(key))
		{
			return additionalData.GetFloat(key);
		}
		return defaultValue;
	}

	// Token: 0x060045EF RID: 17903 RVA: 0x001C4EA4 File Offset: 0x001C32A4
	public static int GetAdditionalData(this MonoBehaviour obj, string key, int defaultValue)
	{
		AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
		if (additionalData.ContainsInt(key))
		{
			return additionalData.GetInt(key);
		}
		return defaultValue;
	}

	// Token: 0x060045F0 RID: 17904 RVA: 0x001C4ED8 File Offset: 0x001C32D8
	public static IEnumerable<NormalItem> OrderByAttributeValue(this IEnumerable<NormalItem> items, AttributeType type)
	{
		return from i in items
		orderby i.Item.GetCachedAttributeValues()[type] descending, i.Item.Level descending, i.Item.IsStarItem() descending, i.ItemGrade descending, i.Item.Type descending
		select i;
	}

	// Token: 0x060045F1 RID: 17905 RVA: 0x001C4F8C File Offset: 0x001C338C
	public static List<NormalItem> OrderItems(this List<NormalItem> items, ItemOrderType orderType)
	{
		switch (orderType)
		{
		case ItemOrderType.OrderByGrade:
			items = (from i in items
			orderby i.Item.IsStarItem() descending, i.Item.ItemGrade descending, i.Item.Level descending, i.Item.Type descending
			select i).ToList<NormalItem>();
			break;
		case ItemOrderType.OrderByLevel:
			items = (from i in items
			orderby i.Item.Level descending, i.Item.ItemTierLevel descending, i.Item.IsStarItem() descending, i.Item.ItemGrade descending, i.Item.Type descending
			select i).ToList<NormalItem>();
			break;
		case ItemOrderType.OrderByType:
			items = (from i in items
			orderby i.Item.Type descending, i.Item.Level descending, i.Item.IsStarItem() descending, i.Item.ItemGrade descending
			select i).ToList<NormalItem>();
			break;
		case ItemOrderType.OrderByTime:
			items = (from i in items
			orderby i.Item.PurchasedOnTime descending, i.Item.Level descending, i.Item.IsStarItem() descending, i.ItemGrade descending, i.Item.Type descending
			select i).ToList<NormalItem>();
			break;
		case ItemOrderType.OrderByStrength:
		case ItemOrderType.OrderByIntelligence:
		case ItemOrderType.OrderBySpeed:
		case ItemOrderType.OrderByVitality:
		case ItemOrderType.OrderByCritRate:
		case ItemOrderType.OrderByCritDamage:
		case ItemOrderType.OrderByResilience:
		case ItemOrderType.OrderByReflectiveDamage:
		case ItemOrderType.OrderByLifeOnHit:
		case ItemOrderType.OrderByStunOnHit:
		case ItemOrderType.OrderByTauntOnHit:
		case ItemOrderType.OrderByHealAbsorbRate:
		case ItemOrderType.OrderByEffectMastery:
		case ItemOrderType.OrderByRageEfficiency:
		case ItemOrderType.OrderByBattleStartHeal:
		case ItemOrderType.OrderByTurnStartHeal:
		case ItemOrderType.OrderByReceivedHealEffectivenessChangeRate:
		case ItemOrderType.OrderByAllResistance:
		case ItemOrderType.OrderByMining:
		case ItemOrderType.OrderByLogging:
		case ItemOrderType.OrderByHunting:
		case ItemOrderType.OrderByHitRateAdjustment:
		case ItemOrderType.OrderByDodgeRateAdjustment:
		case ItemOrderType.OrderByEffectHitRating:
		case ItemOrderType.OrderByEffectResistanceRating:
		case ItemOrderType.OrderByFireEnhancement:
		case ItemOrderType.OrderByLightingEnhancement:
		case ItemOrderType.OrderByPoisonEnhancement:
		case ItemOrderType.OrderByPhysicalEnhancement:
		case ItemOrderType.OrderByIceEnhancement:
		case ItemOrderType.OrderByDivineEnhancement:
		case ItemOrderType.OrderByShadowEnhancement:
		case ItemOrderType.OrderByPhysicalPenetration:
		case ItemOrderType.OrderByFirePenetration:
		case ItemOrderType.OrderByIcePenetration:
		case ItemOrderType.OrderByShadowPenetration:
		case ItemOrderType.OrderByPoisonPenetration:
		case ItemOrderType.OrderByDivinePenetration:
		case ItemOrderType.OrderByLighteningPenetration:
			items = items.OrderByAttributeValue(orderType.GetAttributeTypeByOrderType()).ToList<NormalItem>();
			break;
		}
		return items;
	}

	// Token: 0x060045F2 RID: 17906 RVA: 0x001C5304 File Offset: 0x001C3704
	public static AttributeType GetAttributeTypeByOrderType(this ItemOrderType orderType)
	{
		switch (orderType)
		{
		case ItemOrderType.OrderByStrength:
			return AttributeType.Strength;
		case ItemOrderType.OrderByIntelligence:
			return AttributeType.Intelligience;
		case ItemOrderType.OrderBySpeed:
			return AttributeType.Agility;
		case ItemOrderType.OrderByVitality:
			return AttributeType.Vitality;
		case ItemOrderType.OrderByCritRate:
			return AttributeType.CritRate;
		case ItemOrderType.OrderByCritDamage:
			return AttributeType.CritDamage;
		case ItemOrderType.OrderByResilience:
			return AttributeType.Resilience;
		case ItemOrderType.OrderByReflectiveDamage:
			return AttributeType.ReflectiveDamage;
		case ItemOrderType.OrderByLifeOnHit:
			return AttributeType.LifeOnHit;
		case ItemOrderType.OrderByStunOnHit:
			return AttributeType.StunOnHit;
		case ItemOrderType.OrderByTauntOnHit:
			return AttributeType.TauntOnHit;
		case ItemOrderType.OrderByHealAbsorbRate:
			return AttributeType.HealingAbsorbRate;
		case ItemOrderType.OrderByEffectMastery:
			return AttributeType.EffectMastery;
		case ItemOrderType.OrderByRageEfficiency:
			return AttributeType.SkillRageEfficiencyRate;
		case ItemOrderType.OrderByBattleStartHeal:
			return AttributeType.BattleStartHeal;
		case ItemOrderType.OrderByTurnStartHeal:
			return AttributeType.TurnStartHeal;
		case ItemOrderType.OrderByReceivedHealEffectivenessChangeRate:
			return AttributeType.ReceivedHealEffectivenessChangeRate;
		case ItemOrderType.OrderByAllResistance:
			return AttributeType.Allresistances;
		case ItemOrderType.OrderByMining:
			return AttributeType.Mining;
		case ItemOrderType.OrderByLogging:
			return AttributeType.Logging;
		case ItemOrderType.OrderByHunting:
			return AttributeType.Hunting;
		case ItemOrderType.OrderByHitRateAdjustment:
			return AttributeType.HitRateAdjustment;
		case ItemOrderType.OrderByDodgeRateAdjustment:
			return AttributeType.DodgeRateAdjustment;
		case ItemOrderType.OrderByEffectHitRating:
			return AttributeType.EffectHitRating;
		case ItemOrderType.OrderByEffectResistanceRating:
			return AttributeType.EffectResistanceRating;
		case ItemOrderType.OrderByFireEnhancement:
			return AttributeType.DealFireDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByLightingEnhancement:
			return AttributeType.DealLightningDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByPoisonEnhancement:
			return AttributeType.DealPoisonDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByPhysicalEnhancement:
			return AttributeType.DealPhysicalDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByIceEnhancement:
			return AttributeType.DealIceDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByDivineEnhancement:
			return AttributeType.DealDivineDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByShadowEnhancement:
			return AttributeType.DealShadowDamageEffectivenessChangeRate;
		case ItemOrderType.OrderByPhysicalPenetration:
			return AttributeType.PhysicalPenetration;
		case ItemOrderType.OrderByFirePenetration:
			return AttributeType.FirePenetration;
		case ItemOrderType.OrderByIcePenetration:
			return AttributeType.IcePenetration;
		case ItemOrderType.OrderByShadowPenetration:
			return AttributeType.ShadowPenetration;
		case ItemOrderType.OrderByPoisonPenetration:
			return AttributeType.PoisonPenetration;
		case ItemOrderType.OrderByDivinePenetration:
			return AttributeType.DivinePenetration;
		case ItemOrderType.OrderByLighteningPenetration:
			return AttributeType.LighteningPenetration;
		default:
			return AttributeType.TauntOnHit;
		}
	}

	// Token: 0x060045F3 RID: 17907 RVA: 0x001C5490 File Offset: 0x001C3890
	public static double GetEffectValue(this IResidentEffect residentEffect)
	{
		switch (residentEffect.CorrespondingEffectType)
		{
		case ResidentEffectType.Production:
		{
			ProductionResidentEffect productionResidentEffect = residentEffect as ProductionResidentEffect;
			return productionResidentEffect.CurrentRate;
		}
		case ResidentEffectType.WeaponSale:
		{
			WeaponSaleResidentEffect weaponSaleResidentEffect = residentEffect as WeaponSaleResidentEffect;
			return weaponSaleResidentEffect.CurrentRate;
		}
		case ResidentEffectType.ArmorSale:
		{
			ArmorSaleResidentEffect armorSaleResidentEffect = residentEffect as ArmorSaleResidentEffect;
			return armorSaleResidentEffect.CurrentRate;
		}
		case ResidentEffectType.Luck:
		{
			LuckResidentEffect luckResidentEffect = residentEffect as LuckResidentEffect;
			return luckResidentEffect.CurrentRate;
		}
		case ResidentEffectType.Practice:
		{
			PracticeResidentEffect practiceResidentEffect = residentEffect as PracticeResidentEffect;
			return practiceResidentEffect.CurrentRate;
		}
		case ResidentEffectType.MysticStone:
		{
			MysticStoneResidentEffect mysticStoneResidentEffect = residentEffect as MysticStoneResidentEffect;
			return mysticStoneResidentEffect.CurrentRate;
		}
		case ResidentEffectType.DivineHeart:
		{
			DivineHeartResidentEffect divineHeartResidentEffect = residentEffect as DivineHeartResidentEffect;
			return divineHeartResidentEffect.CurrentRate;
		}
		case ResidentEffectType.Determination:
			return 0.0;
		case ResidentEffectType.Wealth:
		{
			WealthResidentEffect wealthResidentEffect = residentEffect as WealthResidentEffect;
			return wealthResidentEffect.ContributionAmount;
		}
		case ResidentEffectType.Recruitment:
		{
			RecruitmentResidentEffect recruitmentResidentEffect = residentEffect as RecruitmentResidentEffect;
			return recruitmentResidentEffect.Chance;
		}
		}
		return 0.0;
	}

	// Token: 0x060045F4 RID: 17908 RVA: 0x001C557C File Offset: 0x001C397C
	public static bool HasEnoughAmount(this ResourceType resource, double amount)
	{
		return GameWorld.instance.PlayerProfile.GetResourceQuantity(resource) >= amount;
	}

	// Token: 0x060045F5 RID: 17909 RVA: 0x001C5594 File Offset: 0x001C3994
	public static TooltipPosition CalculatePivot(this ITooltip tooltip)
	{
		Canvas canvas = TownManager.Instance.Ui.Canvas;
		Rect rect = canvas.GetComponent<RectTransform>().rect;
		float num = rect.width / 2f * canvas.scaleFactor;
		float num2 = rect.height / 2f * canvas.scaleFactor;
		Vector3 mousePosition = Input.mousePosition;
		TooltipPosition result = TooltipPosition.BottomLeft;
		if (mousePosition.x <= num && mousePosition.y <= num2)
		{
			result = TooltipPosition.BottomLeft;
		}
		if (mousePosition.x <= num && mousePosition.y > num2)
		{
			result = TooltipPosition.TopLeft;
		}
		if (mousePosition.x > num && mousePosition.y <= num2)
		{
			result = TooltipPosition.BottomRight;
		}
		if (mousePosition.x > num && mousePosition.y > num2)
		{
			result = TooltipPosition.TopRight;
		}
		return result;
	}

	// Token: 0x060045F6 RID: 17910 RVA: 0x001C5668 File Offset: 0x001C3A68
	public static void ChangeResolution(this MonoBehaviour obj, ResolutionType type)
	{
		PlayerPrefs.SetInt(PlayerPrefsAttribute.Resolution, (int)type);
		int num = 1280;
		int num2 = 720;
		bool flag = false;
		switch (type)
		{
		case ResolutionType.R800X450:
			num = 800;
			num2 = 450;
			break;
		case ResolutionType.R1280X720:
			num = 1280;
			num2 = 720;
			break;
		case ResolutionType.R1366X768:
			num = 1366;
			num2 = 768;
			break;
		case ResolutionType.R1600X900:
			num = 1600;
			num2 = 900;
			break;
		case ResolutionType.R1920X1080:
			num = 1920;
			num2 = 1080;
			break;
		case ResolutionType.FullScreen:
			num = 1920;
			num2 = 1080;
			flag = true;
			break;
		}
		PlayerPrefs.SetInt("Screenmanager Resolution Width", num);
		PlayerPrefs.SetInt("Screenmanager Resolution Height", num2);
		PlayerPrefs.SetInt("Screenmanager Is Fullscreen", (!flag) ? 0 : 1);
		Screen.SetResolution(num, num2, flag);
	}

	// Token: 0x060045F7 RID: 17911 RVA: 0x001C574E File Offset: 0x001C3B4E
	public static string GetGameDaysText(this PlayerProfile playerProfile)
	{
		return UIComponentType.DayPanelDays.GetName().ReplaceToBuilder(UIComponentKey.NumberOfDay, playerProfile.GameDays.ToString()).ToString();
	}

	// Token: 0x060045F8 RID: 17912 RVA: 0x001C5778 File Offset: 0x001C3B78
	public static string GetEnchantingPropertyString(this ItemPropertyPotential property)
	{
		return string.Concat(new string[]
		{
			property.AttributeType.GetDescription().Title,
			": ",
			property.GetRangeFrom((double)ItemExtensions.ItemAttributeRandomness_Enchanting),
			" - ",
			property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting)
		});
	}

	// Token: 0x060045F9 RID: 17913 RVA: 0x001C57D4 File Offset: 0x001C3BD4
	public static bool TryFirstOrDefault<T>(this IEnumerable<T> source, out T value)
	{
		value = default(T);
		bool result;
		using (IEnumerator<T> enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				value = enumerator.Current;
				result = true;
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	// Token: 0x060045FA RID: 17914 RVA: 0x001C583C File Offset: 0x001C3C3C
	[CompilerGenerated]
	private static bool <OrderHeroDisplayValues>m__0(AttributeDisplayValue a)
	{
		return a.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x060045FB RID: 17915 RVA: 0x001C5847 File Offset: 0x001C3C47
	[CompilerGenerated]
	private static bool <OrderHeroDisplayValues>m__1(AttributeDisplayValue a)
	{
		return a.AttributeType == AttributeType.Strength;
	}

	// Token: 0x060045FC RID: 17916 RVA: 0x001C5852 File Offset: 0x001C3C52
	[CompilerGenerated]
	private static bool <OrderHeroDisplayValues>m__2(AttributeDisplayValue a)
	{
		return a.AttributeType == AttributeType.Intelligience;
	}

	// Token: 0x060045FD RID: 17917 RVA: 0x001C585D File Offset: 0x001C3C5D
	[CompilerGenerated]
	private static bool <GetItemTooltip>m__3(ItemSocket s)
	{
		return s.Gem != null;
	}

	// Token: 0x060045FE RID: 17918 RVA: 0x001C586B File Offset: 0x001C3C6B
	[CompilerGenerated]
	private static int <GetItemTooltip>m__4(ISpecialEffectDataLoad e)
	{
		return (!e.IsStarEffect()) ? 1 : 0;
	}

	// Token: 0x060045FF RID: 17919 RVA: 0x001C587F File Offset: 0x001C3C7F
	[CompilerGenerated]
	private static bool <GetRecipeTooltip>m__5(ItemPropertyPotential p)
	{
		return p.IsGuaranteed;
	}

	// Token: 0x06004600 RID: 17920 RVA: 0x001C5887 File Offset: 0x001C3C87
	[CompilerGenerated]
	private static Item <GetGemSetTooltip>m__6(ItemController e)
	{
		return e.NormalItem.Item;
	}

	// Token: 0x06004601 RID: 17921 RVA: 0x001C5894 File Offset: 0x001C3C94
	[CompilerGenerated]
	private static int <OrderByAttributeValue>m__7(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x06004602 RID: 17922 RVA: 0x001C58A1 File Offset: 0x001C3CA1
	[CompilerGenerated]
	private static bool <OrderByAttributeValue>m__8(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06004603 RID: 17923 RVA: 0x001C58AE File Offset: 0x001C3CAE
	[CompilerGenerated]
	private static QualityGrade <OrderByAttributeValue>m__9(NormalItem i)
	{
		return i.ItemGrade;
	}

	// Token: 0x06004604 RID: 17924 RVA: 0x001C58B6 File Offset: 0x001C3CB6
	[CompilerGenerated]
	private static ResourceType <OrderByAttributeValue>m__A(NormalItem i)
	{
		return i.Item.Type;
	}

	// Token: 0x06004605 RID: 17925 RVA: 0x001C58C3 File Offset: 0x001C3CC3
	[CompilerGenerated]
	private static bool <OrderItems>m__B(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06004606 RID: 17926 RVA: 0x001C58D0 File Offset: 0x001C3CD0
	[CompilerGenerated]
	private static QualityGrade <OrderItems>m__C(NormalItem i)
	{
		return i.Item.ItemGrade;
	}

	// Token: 0x06004607 RID: 17927 RVA: 0x001C58DD File Offset: 0x001C3CDD
	[CompilerGenerated]
	private static int <OrderItems>m__D(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x06004608 RID: 17928 RVA: 0x001C58EA File Offset: 0x001C3CEA
	[CompilerGenerated]
	private static ResourceType <OrderItems>m__E(NormalItem i)
	{
		return i.Item.Type;
	}

	// Token: 0x06004609 RID: 17929 RVA: 0x001C58F7 File Offset: 0x001C3CF7
	[CompilerGenerated]
	private static int <OrderItems>m__F(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x0600460A RID: 17930 RVA: 0x001C5904 File Offset: 0x001C3D04
	[CompilerGenerated]
	private static int? <OrderItems>m__10(NormalItem i)
	{
		return i.Item.ItemTierLevel;
	}

	// Token: 0x0600460B RID: 17931 RVA: 0x001C5911 File Offset: 0x001C3D11
	[CompilerGenerated]
	private static bool <OrderItems>m__11(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x0600460C RID: 17932 RVA: 0x001C591E File Offset: 0x001C3D1E
	[CompilerGenerated]
	private static QualityGrade <OrderItems>m__12(NormalItem i)
	{
		return i.Item.ItemGrade;
	}

	// Token: 0x0600460D RID: 17933 RVA: 0x001C592B File Offset: 0x001C3D2B
	[CompilerGenerated]
	private static ResourceType <OrderItems>m__13(NormalItem i)
	{
		return i.Item.Type;
	}

	// Token: 0x0600460E RID: 17934 RVA: 0x001C5938 File Offset: 0x001C3D38
	[CompilerGenerated]
	private static ResourceType <OrderItems>m__14(NormalItem i)
	{
		return i.Item.Type;
	}

	// Token: 0x0600460F RID: 17935 RVA: 0x001C5945 File Offset: 0x001C3D45
	[CompilerGenerated]
	private static int <OrderItems>m__15(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x06004610 RID: 17936 RVA: 0x001C5952 File Offset: 0x001C3D52
	[CompilerGenerated]
	private static bool <OrderItems>m__16(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06004611 RID: 17937 RVA: 0x001C595F File Offset: 0x001C3D5F
	[CompilerGenerated]
	private static QualityGrade <OrderItems>m__17(NormalItem i)
	{
		return i.Item.ItemGrade;
	}

	// Token: 0x06004612 RID: 17938 RVA: 0x001C596C File Offset: 0x001C3D6C
	[CompilerGenerated]
	private static double <OrderItems>m__18(NormalItem i)
	{
		return i.Item.PurchasedOnTime;
	}

	// Token: 0x06004613 RID: 17939 RVA: 0x001C5979 File Offset: 0x001C3D79
	[CompilerGenerated]
	private static int <OrderItems>m__19(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x06004614 RID: 17940 RVA: 0x001C5986 File Offset: 0x001C3D86
	[CompilerGenerated]
	private static bool <OrderItems>m__1A(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06004615 RID: 17941 RVA: 0x001C5993 File Offset: 0x001C3D93
	[CompilerGenerated]
	private static QualityGrade <OrderItems>m__1B(NormalItem i)
	{
		return i.ItemGrade;
	}

	// Token: 0x06004616 RID: 17942 RVA: 0x001C599B File Offset: 0x001C3D9B
	[CompilerGenerated]
	private static ResourceType <OrderItems>m__1C(NormalItem i)
	{
		return i.Item.Type;
	}

	// Token: 0x04003504 RID: 13572
	[CompilerGenerated]
	private static Func<AttributeDisplayValue, bool> <>f__am$cache0;

	// Token: 0x04003505 RID: 13573
	[CompilerGenerated]
	private static Func<AttributeDisplayValue, bool> <>f__am$cache1;

	// Token: 0x04003506 RID: 13574
	[CompilerGenerated]
	private static Func<AttributeDisplayValue, bool> <>f__am$cache2;

	// Token: 0x04003507 RID: 13575
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache3;

	// Token: 0x04003508 RID: 13576
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, int> <>f__am$cache4;

	// Token: 0x04003509 RID: 13577
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, bool> <>f__am$cache5;

	// Token: 0x0400350A RID: 13578
	[CompilerGenerated]
	private static Func<ItemController, Item> <>f__am$cache6;

	// Token: 0x0400350B RID: 13579
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cache7;

	// Token: 0x0400350C RID: 13580
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache8;

	// Token: 0x0400350D RID: 13581
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cache9;

	// Token: 0x0400350E RID: 13582
	[CompilerGenerated]
	private static Func<NormalItem, ResourceType> <>f__am$cacheA;

	// Token: 0x0400350F RID: 13583
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheB;

	// Token: 0x04003510 RID: 13584
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cacheC;

	// Token: 0x04003511 RID: 13585
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cacheD;

	// Token: 0x04003512 RID: 13586
	[CompilerGenerated]
	private static Func<NormalItem, ResourceType> <>f__am$cacheE;

	// Token: 0x04003513 RID: 13587
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cacheF;

	// Token: 0x04003514 RID: 13588
	[CompilerGenerated]
	private static Func<NormalItem, int?> <>f__am$cache10;

	// Token: 0x04003515 RID: 13589
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache11;

	// Token: 0x04003516 RID: 13590
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cache12;

	// Token: 0x04003517 RID: 13591
	[CompilerGenerated]
	private static Func<NormalItem, ResourceType> <>f__am$cache13;

	// Token: 0x04003518 RID: 13592
	[CompilerGenerated]
	private static Func<NormalItem, ResourceType> <>f__am$cache14;

	// Token: 0x04003519 RID: 13593
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cache15;

	// Token: 0x0400351A RID: 13594
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache16;

	// Token: 0x0400351B RID: 13595
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cache17;

	// Token: 0x0400351C RID: 13596
	[CompilerGenerated]
	private static Func<NormalItem, double> <>f__am$cache18;

	// Token: 0x0400351D RID: 13597
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cache19;

	// Token: 0x0400351E RID: 13598
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache1A;

	// Token: 0x0400351F RID: 13599
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cache1B;

	// Token: 0x04003520 RID: 13600
	[CompilerGenerated]
	private static Func<NormalItem, ResourceType> <>f__am$cache1C;

	// Token: 0x0200103A RID: 4154
	[CompilerGenerated]
	private sealed class <GetItemTooltip>c__AnonStorey0
	{
		// Token: 0x06006840 RID: 26688 RVA: 0x001C59A8 File Offset: 0x001C3DA8
		public <GetItemTooltip>c__AnonStorey0()
		{
		}

		// Token: 0x06006841 RID: 26689 RVA: 0x001C59B0 File Offset: 0x001C3DB0
		internal bool <>m__0(BattleTeam b)
		{
			return b.Adventurers.Any((AdventurerProfile a) => a.GetEquipments().Any((Item e) => e.Id == this.normalItem.Item.Id));
		}

		// Token: 0x06006842 RID: 26690 RVA: 0x001C59C9 File Offset: 0x001C3DC9
		internal bool <>m__1(AdventurerProfile a)
		{
			return a.GetEquipments().Any((Item e) => e.Id == this.normalItem.Item.Id);
		}

		// Token: 0x06006843 RID: 26691 RVA: 0x001C59E2 File Offset: 0x001C3DE2
		internal bool <>m__2(Item e)
		{
			return e.Id == this.normalItem.Item.Id;
		}

		// Token: 0x04006207 RID: 25095
		internal NormalItem normalItem;
	}

	// Token: 0x0200103B RID: 4155
	[CompilerGenerated]
	private sealed class <GetItemTooltip>c__AnonStorey1
	{
		// Token: 0x06006844 RID: 26692 RVA: 0x001C59FF File Offset: 0x001C3DFF
		public <GetItemTooltip>c__AnonStorey1()
		{
		}

		// Token: 0x06006845 RID: 26693 RVA: 0x001C5A07 File Offset: 0x001C3E07
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.GetEquipments().Any((Item e) => e.Type == this.setPiece);
		}

		// Token: 0x06006846 RID: 26694 RVA: 0x001C5A20 File Offset: 0x001C3E20
		internal bool <>m__1(Item e)
		{
			return e.Type == this.setPiece;
		}

		// Token: 0x04006208 RID: 25096
		internal ResourceType setPiece;
	}

	// Token: 0x0200103C RID: 4156
	[CompilerGenerated]
	private sealed class <GetRecipeTooltip>c__AnonStorey2
	{
		// Token: 0x06006847 RID: 26695 RVA: 0x001C5A30 File Offset: 0x001C3E30
		public <GetRecipeTooltip>c__AnonStorey2()
		{
		}

		// Token: 0x06006848 RID: 26696 RVA: 0x001C5A38 File Offset: 0x001C3E38
		internal void <>m__0(ItemPropertyPotential p)
		{
			string text = string.Concat(new string[]
			{
				p.AttributeType.GetDescription().Title,
				": ",
				p.GetRangeFrom((double)ItemExtensions.ItemAttributeRandomness_Generation),
				" - ",
				p.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Generation),
				"\n"
			});
			text = ((!this.extraAttributeTypes.Contains(p.AttributeType)) ? text : ColorPicker.GetHaxString(ColorPicker.Yellow, text));
			this.description += text;
		}

		// Token: 0x04006209 RID: 25097
		internal List<AttributeType> extraAttributeTypes;

		// Token: 0x0400620A RID: 25098
		internal string description;
	}

	// Token: 0x0200103D RID: 4157
	[CompilerGenerated]
	private sealed class <OrderByAttributeValue>c__AnonStorey3
	{
		// Token: 0x06006849 RID: 26697 RVA: 0x001C5AD4 File Offset: 0x001C3ED4
		public <OrderByAttributeValue>c__AnonStorey3()
		{
		}

		// Token: 0x0600684A RID: 26698 RVA: 0x001C5ADC File Offset: 0x001C3EDC
		internal double <>m__0(NormalItem i)
		{
			return i.Item.GetCachedAttributeValues()[this.type];
		}

		// Token: 0x0400620B RID: 25099
		internal AttributeType type;
	}
}
