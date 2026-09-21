using System;
using System.Collections.Generic;

// Token: 0x02000A62 RID: 2658
public class ElementalWizardConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600482A RID: 18474 RVA: 0x001DF8F6 File Offset: 0x001DDCF6
	public ElementalWizardConfiguration()
	{
	}

	// Token: 0x17000E65 RID: 3685
	// (get) Token: 0x0600482B RID: 18475 RVA: 0x001DF905 File Offset: 0x001DDD05
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ElementalWizard;
		}
	}

	// Token: 0x17000E66 RID: 3686
	// (get) Token: 0x0600482C RID: 18476 RVA: 0x001DF90C File Offset: 0x001DDD0C
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E67 RID: 3687
	// (get) Token: 0x0600482D RID: 18477 RVA: 0x001DF914 File Offset: 0x001DDD14
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Vitality, 7.0, false).SetValue(AttributeType.Intelligience, 3.2000000476837158, false).SetValue(AttributeType.Agility, 6.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false);
		}
	}

	// Token: 0x17000E68 RID: 3688
	// (get) Token: 0x0600482E RID: 18478 RVA: 0x001DF966 File Offset: 0x001DDD66
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Lightning;
		}
	}

	// Token: 0x17000E69 RID: 3689
	// (get) Token: 0x0600482F RID: 18479 RVA: 0x001DF96D File Offset: 0x001DDD6D
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.ElementalWizardInvitation;
		}
	}

	// Token: 0x17000E6A RID: 3690
	// (get) Token: 0x06004830 RID: 18480 RVA: 0x001DF974 File Offset: 0x001DDD74
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E6B RID: 3691
	// (get) Token: 0x06004831 RID: 18481 RVA: 0x001DF978 File Offset: 0x001DDD78
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.ArmorOfWind
			};
		}
	}

	// Token: 0x17000E6C RID: 3692
	// (get) Token: 0x06004832 RID: 18482 RVA: 0x001DF997 File Offset: 0x001DDD97
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1500;
		}
	}

	// Token: 0x04003A6F RID: 14959
	private OutputType _outputType = OutputType.Lightening;
}
