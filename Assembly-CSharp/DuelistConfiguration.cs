using System;
using System.Collections.Generic;

// Token: 0x02000A61 RID: 2657
public class DuelistConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004821 RID: 18465 RVA: 0x001DF862 File Offset: 0x001DDC62
	public DuelistConfiguration()
	{
	}

	// Token: 0x17000E5D RID: 3677
	// (get) Token: 0x06004822 RID: 18466 RVA: 0x001DF871 File Offset: 0x001DDC71
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Duelist;
		}
	}

	// Token: 0x17000E5E RID: 3678
	// (get) Token: 0x06004823 RID: 18467 RVA: 0x001DF874 File Offset: 0x001DDC74
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E5F RID: 3679
	// (get) Token: 0x06004824 RID: 18468 RVA: 0x001DF87C File Offset: 0x001DDC7C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.DuelistInvitation;
		}
	}

	// Token: 0x17000E60 RID: 3680
	// (get) Token: 0x06004825 RID: 18469 RVA: 0x001DF883 File Offset: 0x001DDC83
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Scorn;
		}
	}

	// Token: 0x17000E61 RID: 3681
	// (get) Token: 0x06004826 RID: 18470 RVA: 0x001DF88C File Offset: 0x001DDC8C
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				VitalityPotential = 8.7f,
				StrengthPotential = 2.4f,
				AgilityPotential = 4f,
				FocusPotential = 0.1f
			};
		}
	}

	// Token: 0x17000E62 RID: 3682
	// (get) Token: 0x06004827 RID: 18471 RVA: 0x001DF8CC File Offset: 0x001DDCCC
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x17000E63 RID: 3683
	// (get) Token: 0x06004828 RID: 18472 RVA: 0x001DF8D0 File Offset: 0x001DDCD0
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.IronBlood
			};
		}
	}

	// Token: 0x17000E64 RID: 3684
	// (get) Token: 0x06004829 RID: 18473 RVA: 0x001DF8EF File Offset: 0x001DDCEF
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1000;
		}
	}

	// Token: 0x04003A6E RID: 14958
	private OutputType _outputType = OutputType.Physical;
}
