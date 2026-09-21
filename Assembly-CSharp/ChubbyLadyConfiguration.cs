using System;
using System.Collections.Generic;

// Token: 0x02000A5D RID: 2653
public class ChubbyLadyConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060047FD RID: 18429 RVA: 0x001DF5FE File Offset: 0x001DD9FE
	public ChubbyLadyConfiguration()
	{
	}

	// Token: 0x17000E3D RID: 3645
	// (get) Token: 0x060047FE RID: 18430 RVA: 0x001DF60D File Offset: 0x001DDA0D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ChubbyLady;
		}
	}

	// Token: 0x17000E3E RID: 3646
	// (get) Token: 0x060047FF RID: 18431 RVA: 0x001DF614 File Offset: 0x001DDA14
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E3F RID: 3647
	// (get) Token: 0x06004800 RID: 18432 RVA: 0x001DF61C File Offset: 0x001DDA1C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.ChubbyLadyInvitation;
		}
	}

	// Token: 0x17000E40 RID: 3648
	// (get) Token: 0x06004801 RID: 18433 RVA: 0x001DF624 File Offset: 0x001DDA24
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.08f,
				StrengthPotential = 3f,
				AgilityPotential = 7f,
				VitalityPotential = 7f
			};
		}
	}

	// Token: 0x17000E41 RID: 3649
	// (get) Token: 0x06004802 RID: 18434 RVA: 0x001DF664 File Offset: 0x001DDA64
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1500;
		}
	}

	// Token: 0x17000E42 RID: 3650
	// (get) Token: 0x06004803 RID: 18435 RVA: 0x001DF66B File Offset: 0x001DDA6B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x17000E43 RID: 3651
	// (get) Token: 0x06004804 RID: 18436 RVA: 0x001DF66E File Offset: 0x001DDA6E
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Assassination;
		}
	}

	// Token: 0x17000E44 RID: 3652
	// (get) Token: 0x06004805 RID: 18437 RVA: 0x001DF678 File Offset: 0x001DDA78
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Rotation
			};
		}
	}

	// Token: 0x04003A6A RID: 14954
	private OutputType _outputType = OutputType.Physical;
}
