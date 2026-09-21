using System;
using System.Collections.Generic;

// Token: 0x02000A71 RID: 2673
public class StreetManConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048AE RID: 18606 RVA: 0x001E01F2 File Offset: 0x001DE5F2
	public StreetManConfiguration()
	{
	}

	// Token: 0x17000EDA RID: 3802
	// (get) Token: 0x060048AF RID: 18607 RVA: 0x001E0201 File Offset: 0x001DE601
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.StreetMan;
		}
	}

	// Token: 0x17000EDB RID: 3803
	// (get) Token: 0x060048B0 RID: 18608 RVA: 0x001E0204 File Offset: 0x001DE604
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EDC RID: 3804
	// (get) Token: 0x060048B1 RID: 18609 RVA: 0x001E020C File Offset: 0x001DE60C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.StreetManInvitation;
		}
	}

	// Token: 0x17000EDD RID: 3805
	// (get) Token: 0x060048B2 RID: 18610 RVA: 0x001E0214 File Offset: 0x001DE614
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 2.5, false).SetValue(AttributeType.Agility, 5.0, false).SetValue(AttributeType.CritRate, 0.079999998211860657, false).SetValue(AttributeType.Vitality, 7.0, false);
		}
	}

	// Token: 0x17000EDE RID: 3806
	// (get) Token: 0x060048B3 RID: 18611 RVA: 0x001E0266 File Offset: 0x001DE666
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Swordmanship;
		}
	}

	// Token: 0x17000EDF RID: 3807
	// (get) Token: 0x060048B4 RID: 18612 RVA: 0x001E026D File Offset: 0x001DE66D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x17000EE0 RID: 3808
	// (get) Token: 0x060048B5 RID: 18613 RVA: 0x001E0270 File Offset: 0x001DE670
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Crash
			};
		}
	}

	// Token: 0x17000EE1 RID: 3809
	// (get) Token: 0x060048B6 RID: 18614 RVA: 0x001E028F File Offset: 0x001DE68F
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 300;
		}
	}

	// Token: 0x04003A7E RID: 14974
	private OutputType _outputType = OutputType.Physical;
}
