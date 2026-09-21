using System;
using System.Collections.Generic;

// Token: 0x02000A5F RID: 2655
public class CubeConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600480F RID: 18447 RVA: 0x001DF732 File Offset: 0x001DDB32
	public CubeConfiguration()
	{
	}

	// Token: 0x17000E4D RID: 3661
	// (get) Token: 0x06004810 RID: 18448 RVA: 0x001DF741 File Offset: 0x001DDB41
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Cube;
		}
	}

	// Token: 0x17000E4E RID: 3662
	// (get) Token: 0x06004811 RID: 18449 RVA: 0x001DF748 File Offset: 0x001DDB48
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E4F RID: 3663
	// (get) Token: 0x06004812 RID: 18450 RVA: 0x001DF750 File Offset: 0x001DDB50
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.CubeInvitation;
		}
	}

	// Token: 0x17000E50 RID: 3664
	// (get) Token: 0x06004813 RID: 18451 RVA: 0x001DF757 File Offset: 0x001DDB57
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.CurseOfCube;
		}
	}

	// Token: 0x17000E51 RID: 3665
	// (get) Token: 0x06004814 RID: 18452 RVA: 0x001DF760 File Offset: 0x001DDB60
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				VitalityPotential = 7f,
				IntelligiencePotential = 3.2f,
				AgilityPotential = 8f,
				FocusPotential = 0.08f
			};
		}
	}

	// Token: 0x17000E52 RID: 3666
	// (get) Token: 0x06004815 RID: 18453 RVA: 0x001DF7A0 File Offset: 0x001DDBA0
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Formless
			};
		}
	}

	// Token: 0x17000E53 RID: 3667
	// (get) Token: 0x06004816 RID: 18454 RVA: 0x001DF7BF File Offset: 0x001DDBBF
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E54 RID: 3668
	// (get) Token: 0x06004817 RID: 18455 RVA: 0x001DF7C2 File Offset: 0x001DDBC2
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2000;
		}
	}

	// Token: 0x04003A6C RID: 14956
	private OutputType _outputType = OutputType.Fire;
}
