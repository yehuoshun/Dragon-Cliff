using System;
using System.Collections.Generic;

// Token: 0x02000A64 RID: 2660
public class FireAssasinConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600483C RID: 18492 RVA: 0x001DFA36 File Offset: 0x001DDE36
	public FireAssasinConfiguration()
	{
	}

	// Token: 0x17000E75 RID: 3701
	// (get) Token: 0x0600483D RID: 18493 RVA: 0x001DFA45 File Offset: 0x001DDE45
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FireAssassin;
		}
	}

	// Token: 0x17000E76 RID: 3702
	// (get) Token: 0x0600483E RID: 18494 RVA: 0x001DFA4C File Offset: 0x001DDE4C
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E77 RID: 3703
	// (get) Token: 0x0600483F RID: 18495 RVA: 0x001DFA54 File Offset: 0x001DDE54
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.FireAssassinInvitation;
		}
	}

	// Token: 0x17000E78 RID: 3704
	// (get) Token: 0x06004840 RID: 18496 RVA: 0x001DFA5B File Offset: 0x001DDE5B
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.SwallowFire;
		}
	}

	// Token: 0x17000E79 RID: 3705
	// (get) Token: 0x06004841 RID: 18497 RVA: 0x001DFA64 File Offset: 0x001DDE64
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.1f,
				StrengthPotential = 3.4f,
				AgilityPotential = 7.5f,
				VitalityPotential = 7.2f
			};
		}
	}

	// Token: 0x17000E7A RID: 3706
	// (get) Token: 0x06004842 RID: 18498 RVA: 0x001DFAA4 File Offset: 0x001DDEA4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x17000E7B RID: 3707
	// (get) Token: 0x06004843 RID: 18499 RVA: 0x001DFAA8 File Offset: 0x001DDEA8
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.GodsFire
			};
		}
	}

	// Token: 0x17000E7C RID: 3708
	// (get) Token: 0x06004844 RID: 18500 RVA: 0x001DFAC7 File Offset: 0x001DDEC7
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1000;
		}
	}

	// Token: 0x04003A71 RID: 14961
	private OutputType _outputType = OutputType.Physical;
}
