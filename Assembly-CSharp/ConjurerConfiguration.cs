using System;
using System.Collections.Generic;

// Token: 0x02000A5E RID: 2654
public class ConjurerConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004806 RID: 18438 RVA: 0x001DF697 File Offset: 0x001DDA97
	public ConjurerConfiguration()
	{
	}

	// Token: 0x17000E45 RID: 3653
	// (get) Token: 0x06004807 RID: 18439 RVA: 0x001DF6A6 File Offset: 0x001DDAA6
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Conjurer;
		}
	}

	// Token: 0x17000E46 RID: 3654
	// (get) Token: 0x06004808 RID: 18440 RVA: 0x001DF6AD File Offset: 0x001DDAAD
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E47 RID: 3655
	// (get) Token: 0x06004809 RID: 18441 RVA: 0x001DF6B8 File Offset: 0x001DDAB8
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				VitalityPotential = 9f,
				IntelligiencePotential = 3.8f,
				AgilityPotential = 8f,
				FocusPotential = 0.1f
			};
		}
	}

	// Token: 0x17000E48 RID: 3656
	// (get) Token: 0x0600480A RID: 18442 RVA: 0x001DF6F8 File Offset: 0x001DDAF8
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.SeedsOfSin;
		}
	}

	// Token: 0x17000E49 RID: 3657
	// (get) Token: 0x0600480B RID: 18443 RVA: 0x001DF6FF File Offset: 0x001DDAFF
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.ConjurerInvitation;
		}
	}

	// Token: 0x17000E4A RID: 3658
	// (get) Token: 0x0600480C RID: 18444 RVA: 0x001DF706 File Offset: 0x001DDB06
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E4B RID: 3659
	// (get) Token: 0x0600480D RID: 18445 RVA: 0x001DF70C File Offset: 0x001DDB0C
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.SpiritOfDemon
			};
		}
	}

	// Token: 0x17000E4C RID: 3660
	// (get) Token: 0x0600480E RID: 18446 RVA: 0x001DF72B File Offset: 0x001DDB2B
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2000;
		}
	}

	// Token: 0x04003A6B RID: 14955
	private OutputType _outputType = OutputType.Shadow;
}
