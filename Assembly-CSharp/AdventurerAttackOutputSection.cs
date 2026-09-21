using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200032B RID: 811
public class AdventurerAttackOutputSection : GenericHoverController
{
	// Token: 0x0600159E RID: 5534 RVA: 0x000ABDF8 File Offset: 0x000AA1F8
	public AdventurerAttackOutputSection()
	{
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x000ABE00 File Offset: 0x000AA200
	public void SetDisplayValues(AdventurerProfile adventurer, float percentage)
	{
		if (this.HealthPercentageComparison != null)
		{
			this.HealthPercentageComparison.value = percentage;
		}
		this._adventurer = adventurer;
		this._avatar = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(this._adventurer.UnitClass));
		this.SetOutputCapacityOnly(this._adventurer.GetOutputCapacity(AttributeRetrievalLevel.Skill));
		this.SetBasicValues(adventurer.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
	}

	// Token: 0x060015A0 RID: 5536 RVA: 0x000ABE6B File Offset: 0x000AA26B
	public void SetOutputCapacityOnly(UnitOutputCapacity capacity)
	{
		this.AdventurerAttackTypeImage.sprite = FilePath.GetAttackTypeIconByOutputType(capacity.OutputAttribute);
		this.AttackText.text = capacity.Value.ToExpression();
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x000ABE9C File Offset: 0x000AA29C
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

	// Token: 0x060015A2 RID: 5538 RVA: 0x000ABF7B File Offset: 0x000AA37B
	private void Update()
	{
		if (this._pointerIn)
		{
			this.HoverAdventurerAttackOutput();
		}
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x000ABF90 File Offset: 0x000AA390
	private void HoverAdventurerAttackOutput()
	{
		RectTransform component = base.GetComponent<RectTransform>();
		Canvas componentInParent = base.GetComponentInParent<Canvas>();
		float x = base.transform.position.x + (component.rect.width + 70f) * componentInParent.scaleFactor / 2f;
		string unitName = this._adventurer.GetUnitName();
		this.OpenTooltip(new TooltipItem
		{
			Position = new Vector3(x, base.transform.position.y, base.transform.position.z),
			Image = this._avatar,
			Title = unitName,
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

	// Token: 0x040015A7 RID: 5543
	public Text AttackText;

	// Token: 0x040015A8 RID: 5544
	public Text MagicDef;

	// Token: 0x040015A9 RID: 5545
	public Text Defense;

	// Token: 0x040015AA RID: 5546
	public Text AttackMultiFier;

	// Token: 0x040015AB RID: 5547
	public Text MDEFMultifier;

	// Token: 0x040015AC RID: 5548
	public Text DefMultifer;

	// Token: 0x040015AD RID: 5549
	public Slider HealthPercentageComparison;

	// Token: 0x040015AE RID: 5550
	public Image AdventurerAttackTypeImage;

	// Token: 0x040015AF RID: 5551
	private AdventurerProfile _adventurer;

	// Token: 0x040015B0 RID: 5552
	private string adVitalityTitleLabel;

	// Token: 0x040015B1 RID: 5553
	private string adIntelligienceTitleLabel;

	// Token: 0x040015B2 RID: 5554
	private string adStrengthTitleLabel;

	// Token: 0x040015B3 RID: 5555
	private string adAgilityTitleLabel;

	// Token: 0x040015B4 RID: 5556
	private string adArmorTitleLabel;

	// Token: 0x040015B5 RID: 5557
	private string adMagicResistenceTitleLabel;

	// Token: 0x040015B6 RID: 5558
	private string adFocusTitleLabel;

	// Token: 0x040015B7 RID: 5559
	private string adVitality;

	// Token: 0x040015B8 RID: 5560
	private string adIntelligience;

	// Token: 0x040015B9 RID: 5561
	private string adStrength;

	// Token: 0x040015BA RID: 5562
	private string adAgility;

	// Token: 0x040015BB RID: 5563
	private string adArmor;

	// Token: 0x040015BC RID: 5564
	private string adMagicResistence;

	// Token: 0x040015BD RID: 5565
	private string adFocus;

	// Token: 0x040015BE RID: 5566
	private Sprite _avatar;
}
