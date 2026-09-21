using System;
using System.Collections.Generic;

// Token: 0x02000A6D RID: 2669
public class RedHornConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600488D RID: 18573 RVA: 0x001DFF8A File Offset: 0x001DE38A
	public RedHornConfiguration()
	{
	}

	// Token: 0x17000EBD RID: 3773
	// (get) Token: 0x0600488E RID: 18574 RVA: 0x001DFF99 File Offset: 0x001DE399
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedHorn;
		}
	}

	// Token: 0x17000EBE RID: 3774
	// (get) Token: 0x0600488F RID: 18575 RVA: 0x001DFFA0 File Offset: 0x001DE3A0
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EBF RID: 3775
	// (get) Token: 0x06004890 RID: 18576 RVA: 0x001DFFA8 File Offset: 0x001DE3A8
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.RedHornInvitation;
		}
	}

	// Token: 0x17000EC0 RID: 3776
	// (get) Token: 0x06004891 RID: 18577 RVA: 0x001DFFB0 File Offset: 0x001DE3B0
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.35f,
				StrengthPotential = 4.1f,
				AgilityPotential = 5.8f,
				VitalityPotential = 5.8f
			};
		}
	}

	// Token: 0x17000EC1 RID: 3777
	// (get) Token: 0x06004892 RID: 18578 RVA: 0x001DFFF0 File Offset: 0x001DE3F0
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.BladeRain;
		}
	}

	// Token: 0x17000EC2 RID: 3778
	// (get) Token: 0x06004893 RID: 18579 RVA: 0x001DFFF7 File Offset: 0x001DE3F7
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x17000EC3 RID: 3779
	// (get) Token: 0x06004894 RID: 18580 RVA: 0x001DFFFC File Offset: 0x001DE3FC
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Brutality
			};
		}
	}

	// Token: 0x17000EC4 RID: 3780
	// (get) Token: 0x06004895 RID: 18581 RVA: 0x001E001B File Offset: 0x001DE41B
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2500;
		}
	}

	// Token: 0x04003A7A RID: 14970
	private OutputType _outputType = OutputType.Physical;
}
