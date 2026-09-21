using System;
using System.Collections.Generic;

// Token: 0x02000A6B RID: 2667
public class NightBladeConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600487B RID: 18555 RVA: 0x001DFE5E File Offset: 0x001DE25E
	public NightBladeConfiguration()
	{
	}

	// Token: 0x17000EAD RID: 3757
	// (get) Token: 0x0600487C RID: 18556 RVA: 0x001DFE6D File Offset: 0x001DE26D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.NightBlade;
		}
	}

	// Token: 0x17000EAE RID: 3758
	// (get) Token: 0x0600487D RID: 18557 RVA: 0x001DFE74 File Offset: 0x001DE274
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EAF RID: 3759
	// (get) Token: 0x0600487E RID: 18558 RVA: 0x001DFE7C File Offset: 0x001DE27C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.NightBladeInvitation;
		}
	}

	// Token: 0x17000EB0 RID: 3760
	// (get) Token: 0x0600487F RID: 18559 RVA: 0x001DFE84 File Offset: 0x001DE284
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				VitalityPotential = 7.2f,
				StrengthPotential = 3f,
				AgilityPotential = 6f,
				FocusPotential = 0.05f
			};
		}
	}

	// Token: 0x17000EB1 RID: 3761
	// (get) Token: 0x06004880 RID: 18560 RVA: 0x001DFEC4 File Offset: 0x001DE2C4
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.PoisonBlade;
		}
	}

	// Token: 0x17000EB2 RID: 3762
	// (get) Token: 0x06004881 RID: 18561 RVA: 0x001DFECB File Offset: 0x001DE2CB
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x17000EB3 RID: 3763
	// (get) Token: 0x06004882 RID: 18562 RVA: 0x001DFED0 File Offset: 0x001DE2D0
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.PoisonousMist
			};
		}
	}

	// Token: 0x17000EB4 RID: 3764
	// (get) Token: 0x06004883 RID: 18563 RVA: 0x001DFEEF File Offset: 0x001DE2EF
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2000;
		}
	}

	// Token: 0x04003A78 RID: 14968
	private OutputType _outputType = OutputType.Poison;
}
