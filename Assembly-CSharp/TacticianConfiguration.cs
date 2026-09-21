using System;
using System.Collections.Generic;

// Token: 0x02000A72 RID: 2674
public class TacticianConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048B7 RID: 18615 RVA: 0x001E0296 File Offset: 0x001DE696
	public TacticianConfiguration()
	{
	}

	// Token: 0x17000EE2 RID: 3810
	// (get) Token: 0x060048B8 RID: 18616 RVA: 0x001E02A5 File Offset: 0x001DE6A5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Tactician;
		}
	}

	// Token: 0x17000EE3 RID: 3811
	// (get) Token: 0x060048B9 RID: 18617 RVA: 0x001E02A8 File Offset: 0x001DE6A8
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EE4 RID: 3812
	// (get) Token: 0x060048BA RID: 18618 RVA: 0x001E02B0 File Offset: 0x001DE6B0
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.TacticianInvitation;
		}
	}

	// Token: 0x17000EE5 RID: 3813
	// (get) Token: 0x060048BB RID: 18619 RVA: 0x001E02B7 File Offset: 0x001DE6B7
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.GrandStrategy;
		}
	}

	// Token: 0x17000EE6 RID: 3814
	// (get) Token: 0x060048BC RID: 18620 RVA: 0x001E02C0 File Offset: 0x001DE6C0
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Vitality, 9.8999996185302734, false).SetValue(AttributeType.Strength, 2.9000000953674316, false).SetValue(AttributeType.Agility, 5.0, false).SetValue(AttributeType.CritRate, 0.05000000074505806, false);
		}
	}

	// Token: 0x17000EE7 RID: 3815
	// (get) Token: 0x060048BD RID: 18621 RVA: 0x001E0312 File Offset: 0x001DE712
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x17000EE8 RID: 3816
	// (get) Token: 0x060048BE RID: 18622 RVA: 0x001E0318 File Offset: 0x001DE718
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.EmbracedShield
			};
		}
	}

	// Token: 0x17000EE9 RID: 3817
	// (get) Token: 0x060048BF RID: 18623 RVA: 0x001E0337 File Offset: 0x001DE737
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 100000;
		}
	}

	// Token: 0x04003A7F RID: 14975
	private OutputType _outputType = OutputType.Physical;
}
