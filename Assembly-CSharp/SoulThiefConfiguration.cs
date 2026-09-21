using System;
using System.Collections.Generic;

// Token: 0x02000A70 RID: 2672
public class SoulThiefConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048A5 RID: 18597 RVA: 0x001E014A File Offset: 0x001DE54A
	public SoulThiefConfiguration()
	{
	}

	// Token: 0x17000ED2 RID: 3794
	// (get) Token: 0x060048A6 RID: 18598 RVA: 0x001E0159 File Offset: 0x001DE559
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.SoulThief;
		}
	}

	// Token: 0x17000ED3 RID: 3795
	// (get) Token: 0x060048A7 RID: 18599 RVA: 0x001E0160 File Offset: 0x001DE560
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000ED4 RID: 3796
	// (get) Token: 0x060048A8 RID: 18600 RVA: 0x001E0168 File Offset: 0x001DE568
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Agility, 8.1999998092651367, false).SetValue(AttributeType.CritRate, 0.11999999731779099, false).SetValue(AttributeType.Vitality, 6.5, false).SetValue(AttributeType.Strength, 2.7999999523162842, false);
		}
	}

	// Token: 0x17000ED5 RID: 3797
	// (get) Token: 0x060048A9 RID: 18601 RVA: 0x001E01BA File Offset: 0x001DE5BA
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.StealSoul;
		}
	}

	// Token: 0x17000ED6 RID: 3798
	// (get) Token: 0x060048AA RID: 18602 RVA: 0x001E01C1 File Offset: 0x001DE5C1
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.SoulThiefInvitation;
		}
	}

	// Token: 0x17000ED7 RID: 3799
	// (get) Token: 0x060048AB RID: 18603 RVA: 0x001E01C8 File Offset: 0x001DE5C8
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x17000ED8 RID: 3800
	// (get) Token: 0x060048AC RID: 18604 RVA: 0x001E01CC File Offset: 0x001DE5CC
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.GhostlySmoke
			};
		}
	}

	// Token: 0x17000ED9 RID: 3801
	// (get) Token: 0x060048AD RID: 18605 RVA: 0x001E01EB File Offset: 0x001DE5EB
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 800;
		}
	}

	// Token: 0x04003A7D RID: 14973
	private OutputType _outputType = OutputType.Shadow;
}
