using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000357 RID: 855
public class AdventurerAttackOutputInBattle : GenericHoverController
{
	// Token: 0x060016DE RID: 5854 RVA: 0x000B30E9 File Offset: 0x000B14E9
	public AdventurerAttackOutputInBattle()
	{
	}

	// Token: 0x060016DF RID: 5855 RVA: 0x000B30F1 File Offset: 0x000B14F1
	public void SetDisplayValues(IBattleUnit battleUnit)
	{
		this._avatar = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(battleUnit.GetUnitType()));
		this._iBattleUnit = battleUnit;
		this.SetOutputCapacityOnly(battleUnit);
		this.SetBasicValues(this._iBattleUnit.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
	}

	// Token: 0x060016E0 RID: 5856 RVA: 0x000B312C File Offset: 0x000B152C
	public void SetOutputCapacityOnly(IBattleUnit unit)
	{
		UnitOutputCapacity outputCapacity = unit.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		this.AdventurerAttackTypeImage.sprite = FilePath.GetAttackTypeIconByOutputType(outputCapacity.OutputAttribute);
		this.AttackText.text = outputCapacity.Value.ToExpression();
		this.DefMultifer.gameObject.SetActive(false);
		this.MDEFMultifier.gameObject.SetActive(false);
		this.DefMultifer.text = "+99%";
		this.MDEFMultifier.text = "+99%";
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x000B31B0 File Offset: 0x000B15B0
	public void SetBasicValues(List<AttributeDisplayValue> attributes)
	{
		this.adVitality = attributes.GetValue(AttributeType.Vitality).ToDisplayValueFormat();
		this.adIntelligience = attributes.GetValue(AttributeType.Intelligience).ToDisplayValueFormat();
		this.adStrength = attributes.GetValue(AttributeType.Strength).ToDisplayValueFormat();
		this.adAgility = attributes.GetValue(AttributeType.Agility).ToDisplayValueFormat();
		this.adArmor = attributes.GetValue(AttributeType.PhysicalResistance).ToDisplayValueFormat();
		this.adMagicResistence = attributes.GetValue(AttributeType.FireResistanceResistance).ToDisplayValueFormat();
		this.adVitalityTitleLabel = AttributeType.Vitality.GetLocalization().Name;
		this.adIntelligienceTitleLabel = AttributeType.Intelligience.GetLocalization().Name;
		this.adStrengthTitleLabel = AttributeType.Strength.GetLocalization().Name;
		this.adAgilityTitleLabel = AttributeType.Agility.GetLocalization().Name;
		this.adArmorTitleLabel = AttributeType.PhysicalResistance.GetLocalization().Name;
		this.adMagicResistenceTitleLabel = AttributeType.FireResistanceResistance.GetLocalization().Name;
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x000B328F File Offset: 0x000B168F
	private void Update()
	{
		if (this._pointerIn)
		{
			this.HoverAdventurerAttackOutput();
		}
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x000B32A4 File Offset: 0x000B16A4
	private void HoverAdventurerAttackOutput()
	{
		RectTransform component = base.GetComponent<RectTransform>();
		Canvas componentInParent = base.GetComponentInParent<Canvas>();
		float x = base.transform.position.x + (component.rect.width + 70f) * componentInParent.scaleFactor / 2f;
		string title = string.Empty;
		if (this._iBattleUnit != null)
		{
			title = this._iBattleUnit.GetUnitType().GetDescription().Title;
		}
		this.OpenTooltip(new TooltipItem
		{
			Position = new Vector3(x, base.transform.position.y, base.transform.position.z),
			Image = this._avatar,
			Title = title,
			Description = string.Concat(new string[]
			{
				this.adStrengthTitleLabel,
				" : ",
				this.adStrength,
				"\n",
				this.adIntelligienceTitleLabel,
				" : ",
				this.adIntelligience,
				"\n",
				this.adVitalityTitleLabel,
				" : ",
				this.adVitality,
				"\n",
				this.adAgilityTitleLabel,
				" : ",
				this.adAgility,
				"\n",
				this.adArmorTitleLabel,
				" : ",
				this.adArmor,
				"\n",
				this.adMagicResistenceTitleLabel,
				" : ",
				this.adMagicResistence,
				"\n"
			})
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x040016E3 RID: 5859
	public Text AttackText;

	// Token: 0x040016E4 RID: 5860
	public Text MagicDef;

	// Token: 0x040016E5 RID: 5861
	public Text Defense;

	// Token: 0x040016E6 RID: 5862
	public Text AttackMultiFier;

	// Token: 0x040016E7 RID: 5863
	public Text MDEFMultifier;

	// Token: 0x040016E8 RID: 5864
	public Text DefMultifer;

	// Token: 0x040016E9 RID: 5865
	public Image AdventurerAttackTypeImage;

	// Token: 0x040016EA RID: 5866
	private string adVitalityTitleLabel;

	// Token: 0x040016EB RID: 5867
	private string adIntelligienceTitleLabel;

	// Token: 0x040016EC RID: 5868
	private string adStrengthTitleLabel;

	// Token: 0x040016ED RID: 5869
	private string adAgilityTitleLabel;

	// Token: 0x040016EE RID: 5870
	private string adArmorTitleLabel;

	// Token: 0x040016EF RID: 5871
	private string adMagicResistenceTitleLabel;

	// Token: 0x040016F0 RID: 5872
	private string adFocusTitleLabel;

	// Token: 0x040016F1 RID: 5873
	private string adVitality;

	// Token: 0x040016F2 RID: 5874
	private string adIntelligience;

	// Token: 0x040016F3 RID: 5875
	private string adStrength;

	// Token: 0x040016F4 RID: 5876
	private string adAgility;

	// Token: 0x040016F5 RID: 5877
	private string adArmor;

	// Token: 0x040016F6 RID: 5878
	private string adMagicResistence;

	// Token: 0x040016F7 RID: 5879
	private string adFocus;

	// Token: 0x040016F8 RID: 5880
	private Sprite _avatar;

	// Token: 0x040016F9 RID: 5881
	private IBattleUnit _iBattleUnit;
}
