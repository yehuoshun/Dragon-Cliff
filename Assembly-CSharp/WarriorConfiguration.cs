using System;
using System.Collections.Generic;

// Token: 0x02000A74 RID: 2676
public class WarriorConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048C9 RID: 18633 RVA: 0x001E03E6 File Offset: 0x001DE7E6
	public WarriorConfiguration()
	{
	}

	// Token: 0x17000EF2 RID: 3826
	// (get) Token: 0x060048CA RID: 18634 RVA: 0x001E03F5 File Offset: 0x001DE7F5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Warrior;
		}
	}

	// Token: 0x17000EF3 RID: 3827
	// (get) Token: 0x060048CB RID: 18635 RVA: 0x001E03F8 File Offset: 0x001DE7F8
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EF4 RID: 3828
	// (get) Token: 0x060048CC RID: 18636 RVA: 0x001E0400 File Offset: 0x001DE800
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Agility, 5.0, false).SetValue(AttributeType.CritRate, 0.05000000074505806, false).SetValue(AttributeType.Vitality, 8.0, false).SetValue(AttributeType.Strength, 3.0, false);
		}
	}

	// Token: 0x17000EF5 RID: 3829
	// (get) Token: 0x060048CD RID: 18637 RVA: 0x001E0452 File Offset: 0x001DE852
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Roar;
		}
	}

	// Token: 0x17000EF6 RID: 3830
	// (get) Token: 0x060048CE RID: 18638 RVA: 0x001E0459 File Offset: 0x001DE859
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.WarriorInvitation;
		}
	}

	// Token: 0x17000EF7 RID: 3831
	// (get) Token: 0x060048CF RID: 18639 RVA: 0x001E0460 File Offset: 0x001DE860
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x17000EF8 RID: 3832
	// (get) Token: 0x060048D0 RID: 18640 RVA: 0x001E0464 File Offset: 0x001DE864
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Sunder
			};
		}
	}

	// Token: 0x17000EF9 RID: 3833
	// (get) Token: 0x060048D1 RID: 18641 RVA: 0x001E0483 File Offset: 0x001DE883
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 950;
		}
	}

	// Token: 0x04003A81 RID: 14977
	private OutputType _outputType = OutputType.Physical;
}
