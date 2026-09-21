using System;
using System.Collections.Generic;

// Token: 0x02000A66 RID: 2662
public class FireSpiritConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600484E RID: 18510 RVA: 0x001DFB66 File Offset: 0x001DDF66
	public FireSpiritConfiguration()
	{
	}

	// Token: 0x17000E85 RID: 3717
	// (get) Token: 0x0600484F RID: 18511 RVA: 0x001DFB75 File Offset: 0x001DDF75
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FireCharger;
		}
	}

	// Token: 0x17000E86 RID: 3718
	// (get) Token: 0x06004850 RID: 18512 RVA: 0x001DFB7C File Offset: 0x001DDF7C
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E87 RID: 3719
	// (get) Token: 0x06004851 RID: 18513 RVA: 0x001DFB84 File Offset: 0x001DDF84
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.FireSpiritInvitation;
		}
	}

	// Token: 0x17000E88 RID: 3720
	// (get) Token: 0x06004852 RID: 18514 RVA: 0x001DFB8C File Offset: 0x001DDF8C
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				IntelligiencePotential = 3f,
				FocusPotential = 0.08f,
				AgilityPotential = 6.8f,
				VitalityPotential = 4.2f
			};
		}
	}

	// Token: 0x17000E89 RID: 3721
	// (get) Token: 0x06004853 RID: 18515 RVA: 0x001DFBCC File Offset: 0x001DDFCC
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.FireBlast;
		}
	}

	// Token: 0x17000E8A RID: 3722
	// (get) Token: 0x06004854 RID: 18516 RVA: 0x001DFBD3 File Offset: 0x001DDFD3
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x17000E8B RID: 3723
	// (get) Token: 0x06004855 RID: 18517 RVA: 0x001DFBD8 File Offset: 0x001DDFD8
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.BloodCurse
			};
		}
	}

	// Token: 0x17000E8C RID: 3724
	// (get) Token: 0x06004856 RID: 18518 RVA: 0x001DFBF7 File Offset: 0x001DDFF7
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2200;
		}
	}

	// Token: 0x04003A73 RID: 14963
	private OutputType _outputType = OutputType.Fire;
}
