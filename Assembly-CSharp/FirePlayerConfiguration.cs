using System;
using System.Collections.Generic;

// Token: 0x02000A65 RID: 2661
public class FirePlayerConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004845 RID: 18501 RVA: 0x001DFACE File Offset: 0x001DDECE
	public FirePlayerConfiguration()
	{
	}

	// Token: 0x17000E7D RID: 3709
	// (get) Token: 0x06004846 RID: 18502 RVA: 0x001DFADD File Offset: 0x001DDEDD
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FirePlayer;
		}
	}

	// Token: 0x17000E7E RID: 3710
	// (get) Token: 0x06004847 RID: 18503 RVA: 0x001DFAE4 File Offset: 0x001DDEE4
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E7F RID: 3711
	// (get) Token: 0x06004848 RID: 18504 RVA: 0x001DFAEC File Offset: 0x001DDEEC
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				AgilityPotential = 7f,
				FocusPotential = 0.1f,
				IntelligiencePotential = 3.2f,
				VitalityPotential = 5.5f
			};
		}
	}

	// Token: 0x17000E80 RID: 3712
	// (get) Token: 0x06004849 RID: 18505 RVA: 0x001DFB2C File Offset: 0x001DDF2C
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.FireBreath;
		}
	}

	// Token: 0x17000E81 RID: 3713
	// (get) Token: 0x0600484A RID: 18506 RVA: 0x001DFB33 File Offset: 0x001DDF33
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.FirePlayerInvitation;
		}
	}

	// Token: 0x17000E82 RID: 3714
	// (get) Token: 0x0600484B RID: 18507 RVA: 0x001DFB3A File Offset: 0x001DDF3A
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E83 RID: 3715
	// (get) Token: 0x0600484C RID: 18508 RVA: 0x001DFB40 File Offset: 0x001DDF40
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.HeartlessFire
			};
		}
	}

	// Token: 0x17000E84 RID: 3716
	// (get) Token: 0x0600484D RID: 18509 RVA: 0x001DFB5F File Offset: 0x001DDF5F
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 700;
		}
	}

	// Token: 0x04003A72 RID: 14962
	private OutputType _outputType = OutputType.Fire;
}
