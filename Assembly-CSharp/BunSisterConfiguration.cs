using System;
using System.Collections.Generic;

// Token: 0x02000A5C RID: 2652
public class BunSisterConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060047F4 RID: 18420 RVA: 0x001DF566 File Offset: 0x001DD966
	public BunSisterConfiguration()
	{
	}

	// Token: 0x17000E35 RID: 3637
	// (get) Token: 0x060047F5 RID: 18421 RVA: 0x001DF575 File Offset: 0x001DD975
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BunSister;
		}
	}

	// Token: 0x17000E36 RID: 3638
	// (get) Token: 0x060047F6 RID: 18422 RVA: 0x001DF57C File Offset: 0x001DD97C
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E37 RID: 3639
	// (get) Token: 0x060047F7 RID: 18423 RVA: 0x001DF584 File Offset: 0x001DD984
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.BunSisterInvitation;
		}
	}

	// Token: 0x17000E38 RID: 3640
	// (get) Token: 0x060047F8 RID: 18424 RVA: 0x001DF58B File Offset: 0x001DD98B
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.BrightCircle;
		}
	}

	// Token: 0x17000E39 RID: 3641
	// (get) Token: 0x060047F9 RID: 18425 RVA: 0x001DF594 File Offset: 0x001DD994
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.08f,
				StrengthPotential = 1f,
				AgilityPotential = 7.3f,
				VitalityPotential = 12f
			};
		}
	}

	// Token: 0x17000E3A RID: 3642
	// (get) Token: 0x060047FA RID: 18426 RVA: 0x001DF5D4 File Offset: 0x001DD9D4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x17000E3B RID: 3643
	// (get) Token: 0x060047FB RID: 18427 RVA: 0x001DF5D8 File Offset: 0x001DD9D8
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Punishment
			};
		}
	}

	// Token: 0x17000E3C RID: 3644
	// (get) Token: 0x060047FC RID: 18428 RVA: 0x001DF5F7 File Offset: 0x001DD9F7
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1300;
		}
	}

	// Token: 0x04003A69 RID: 14953
	private OutputType _outputType = OutputType.Physical;
}
