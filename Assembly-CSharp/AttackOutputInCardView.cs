using System;
using TMPro;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class AttackOutputInCardView : GenericHoverController
{
	// Token: 0x06001678 RID: 5752 RVA: 0x000B1854 File Offset: 0x000AFC54
	public AttackOutputInCardView()
	{
	}

	// Token: 0x06001679 RID: 5753 RVA: 0x000B185C File Offset: 0x000AFC5C
	private void Awake()
	{
		this._attackoutputLableText = base.GetComponentInChildren<TextMeshProUGUI>();
	}

	// Token: 0x0600167A RID: 5754 RVA: 0x000B186A File Offset: 0x000AFC6A
	public void SetOriginalValue(double original, bool isInPercentage, UIBattleUnitRelatedValueType type, IBattleUnit battleUnit)
	{
		this._battleUnit = battleUnit;
		this._original = original;
		this._valueType = type;
		this._lastValue = original;
		this._isPercentage = isInPercentage;
		this.SetLableText(this._original);
	}

	// Token: 0x0600167B RID: 5755 RVA: 0x000B189C File Offset: 0x000AFC9C
	private void LateUpdate()
	{
		this._attackoutputLableText.color = this._currentColor;
	}

	// Token: 0x0600167C RID: 5756 RVA: 0x000B18B0 File Offset: 0x000AFCB0
	public void SetLableText(double valueToBe)
	{
		if (this._attackoutputLableText == null)
		{
			this.Awake();
		}
		this.Highlight(valueToBe);
		this._attackoutputLableText.text = valueToBe.DoubleToShortNumber();
		switch (AttackOutputInCardView.CompareFirstValueWithTheSecond(this._original, valueToBe))
		{
		case ComparisonResult.GreaterThan:
			this._currentColor = ColorPicker.NagetiveRed;
			break;
		case ComparisonResult.LessThan:
			this._currentColor = ColorPicker.PositiveGreen;
			break;
		case ComparisonResult.Equal:
			this._currentColor = ColorPicker.White;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	// Token: 0x0600167D RID: 5757 RVA: 0x000B1946 File Offset: 0x000AFD46
	public static ComparisonResult CompareFirstValueWithTheSecond(double first, double second)
	{
		if (first == second)
		{
			return ComparisonResult.Equal;
		}
		if (first < second)
		{
			return ComparisonResult.LessThan;
		}
		return ComparisonResult.GreaterThan;
	}

	// Token: 0x0600167E RID: 5758 RVA: 0x000B195B File Offset: 0x000AFD5B
	private void Update()
	{
		if (this._pointerIn)
		{
			this.HoverAttackOutputInfo();
		}
	}

	// Token: 0x0600167F RID: 5759 RVA: 0x000B1970 File Offset: 0x000AFD70
	private void HoverAttackOutputInfo()
	{
		if (this._battleUnit == null)
		{
			return;
		}
		BattleUnitAttributeBriefSet attributeBrief = this._battleUnit.GetAttributeBrief();
		switch (this._valueType)
		{
		case UIBattleUnitRelatedValueType.AttackOutput:
		{
			double outputValue = attributeBrief.NakedBrief.OutputValue;
			double outputValue2 = attributeBrief.WithGears.OutputValue;
			double outputValue3 = attributeBrief.WithBattleEffects.OutputValue;
			string description = this.ReCalculate(outputValue, outputValue2, outputValue3, string.Empty);
			this.OpenTooltip(this.GetTooltip(UIComponentType.AdventureAttributeAttackTitle.GetName(), description), null, TooltipPosition.None, 0f, 0f);
			return;
		}
		case UIBattleUnitRelatedValueType.MagicDefense:
		{
			double toughness = attributeBrief.NakedBrief.Toughness;
			double toughness2 = attributeBrief.WithGears.Toughness;
			double toughness3 = attributeBrief.WithBattleEffects.Toughness;
			string text = this.ReCalculate(toughness, toughness2, toughness3, string.Empty);
			text = UIComponentType.AdventureAttributeToughnessTitle.GetName() + ": " + text + "\n";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Physical, UIComponentType.AdventureAttributePhysicalDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.PhysicalDefenceRatio, attributeBrief.WithBattleEffects.PhysicalDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Fire, UIComponentType.AdventureAttributeFireDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.FireDefenceRatio, attributeBrief.WithBattleEffects.FireDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Ice, UIComponentType.AdventureAttributeIceDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.IceDefenceRatio, attributeBrief.WithBattleEffects.IceDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Lightening, UIComponentType.AdventureAttributeLighteningDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.LighteningDefenceRatio, attributeBrief.WithBattleEffects.LighteningDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Divine, UIComponentType.AdventureAttributeDivineDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.DivineDefenceRatio, attributeBrief.WithBattleEffects.DivineDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Poison, UIComponentType.AdventureAttributePoisonDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.PoisonDefenceRatio, attributeBrief.WithBattleEffects.PoisonDefenceRatio),
				"\n"
			});
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				ColorPicker.GetOutputTypeString(OutputType.Shadow, UIComponentType.AdventureAttributeShadowDefenceTitle.GetName()),
				": ",
				this.ReCalculateDefence(attributeBrief.WithGears.ShadowDefenceRatio, attributeBrief.WithBattleEffects.ShadowDefenceRatio),
				"\n"
			});
			this.OpenTooltip(this.GetTooltip(UIComponentType.AdventureAttributeToughnessTitle.GetName(), text), null, TooltipPosition.None, 0f, 0f);
			return;
		}
		case UIBattleUnitRelatedValueType.Speed:
		{
			double agility = attributeBrief.NakedBrief.Agility;
			double agility2 = attributeBrief.WithGears.Agility;
			double agility3 = attributeBrief.WithBattleEffects.Agility;
			string description2 = this.ReCalculate(agility, agility2, agility3, string.Empty);
			this.OpenTooltip(this.GetTooltip(UIComponentType.AdventureAttributeSpeedTitle.GetName(), description2), null, TooltipPosition.None, 0f, 0f);
			return;
		}
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06001680 RID: 5760 RVA: 0x000B1D68 File Offset: 0x000B0168
	public string ReCalculateDefence(double withGear, double withSkillFinal)
	{
		string text = (withSkillFinal - withGear).ToExpressionMultiply100();
		string result = string.Empty;
		if (withSkillFinal > withGear)
		{
			result = "<color=white> " + withGear.ToExpressionMultiply100() + "%</color> " + ColorPicker.GetPositiveColoredString("+" + text + "%");
		}
		else if (withSkillFinal == withGear)
		{
			result = "<color=white> " + withGear.ToExpressionMultiply100() + "%</color> ";
		}
		else
		{
			result = "<color=white> " + withGear.ToExpressionMultiply100() + "%</color> " + ColorPicker.GetNegativeColoredString(text + "%");
		}
		return result;
	}

	// Token: 0x06001681 RID: 5761 RVA: 0x000B1E04 File Offset: 0x000B0204
	public string ReCalculate(double naked, double withGear, double withSkillFinal, string sign = "")
	{
		double number = withGear - naked;
		string text = string.Empty;
		ComparisonResult comparisonResult = AttackOutputInCardView.CompareFirstValueWithTheSecond(naked, withGear);
		if (comparisonResult != ComparisonResult.GreaterThan)
		{
			if (comparisonResult == ComparisonResult.LessThan)
			{
				text = ColorPicker.GetPositiveColoredString("+" + number.DoubleToString() + sign);
			}
		}
		else
		{
			text = ColorPicker.GetNegativeColoredString(number.DoubleToString() + sign);
		}
		double num = withGear - withSkillFinal;
		string result = string.Empty;
		ComparisonResult comparisonResult2 = AttackOutputInCardView.CompareFirstValueWithTheSecond(withGear, withSkillFinal);
		if (comparisonResult2 != ComparisonResult.GreaterThan)
		{
			if (comparisonResult2 != ComparisonResult.LessThan)
			{
				if (comparisonResult2 == ComparisonResult.Equal)
				{
					result = string.Concat(new string[]
					{
						"<color=white> ",
						naked.DoubleToString(),
						sign,
						"</color> ",
						text
					});
				}
			}
			else
			{
				result = string.Concat(new string[]
				{
					"<color=white> ",
					naked.DoubleToString(),
					sign,
					"</color> ",
					text,
					ColorPicker.GetPositiveColoredString("+" + (-num).DoubleToString() + sign)
				});
			}
		}
		else
		{
			result = string.Concat(new string[]
			{
				"<color=white> ",
				naked.DoubleToString(),
				sign,
				"</color> ",
				text,
				ColorPicker.GetNegativeColoredString("-" + num.DoubleToString() + sign)
			});
		}
		return result;
	}

	// Token: 0x06001682 RID: 5762 RVA: 0x000B1F70 File Offset: 0x000B0370
	private TooltipItem GetTooltip(string title, string description)
	{
		return new TooltipItem
		{
			Title = title,
			Description = description,
			Position = base.transform.position
		};
	}

	// Token: 0x06001683 RID: 5763 RVA: 0x000B1FA3 File Offset: 0x000B03A3
	private void Highlight(double valueToUpdate)
	{
		this._lastValue = valueToUpdate;
	}

	// Token: 0x06001684 RID: 5764 RVA: 0x000B1FAC File Offset: 0x000B03AC
	public void LeavesEncounter()
	{
		this._lastValue = this._original;
	}

	// Token: 0x04001695 RID: 5781
	private TextMeshProUGUI _attackoutputLableText;

	// Token: 0x04001696 RID: 5782
	private double _original;

	// Token: 0x04001697 RID: 5783
	private IBattleUnit _battleUnit;

	// Token: 0x04001698 RID: 5784
	private UIBattleUnitRelatedValueType _valueType;

	// Token: 0x04001699 RID: 5785
	private double _lastValue;

	// Token: 0x0400169A RID: 5786
	private Color _currentColor;

	// Token: 0x0400169B RID: 5787
	private bool _isPercentage;
}
