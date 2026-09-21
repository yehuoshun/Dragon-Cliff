using System;
using System.Collections.Generic;

// Token: 0x02000A68 RID: 2664
public class IronSoliderConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004860 RID: 18528 RVA: 0x001DFC96 File Offset: 0x001DE096
	public IronSoliderConfiguration()
	{
	}

	// Token: 0x17000E95 RID: 3733
	// (get) Token: 0x06004861 RID: 18529 RVA: 0x001DFCA5 File Offset: 0x001DE0A5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.IronSolider;
		}
	}

	// Token: 0x17000E96 RID: 3734
	// (get) Token: 0x06004862 RID: 18530 RVA: 0x001DFCAC File Offset: 0x001DE0AC
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E97 RID: 3735
	// (get) Token: 0x06004863 RID: 18531 RVA: 0x001DFCB4 File Offset: 0x001DE0B4
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.IronSoliderInvitation;
		}
	}

	// Token: 0x17000E98 RID: 3736
	// (get) Token: 0x06004864 RID: 18532 RVA: 0x001DFCBB File Offset: 0x001DE0BB
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.BurningHeart;
		}
	}

	// Token: 0x17000E99 RID: 3737
	// (get) Token: 0x06004865 RID: 18533 RVA: 0x001DFCC4 File Offset: 0x001DE0C4
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.05f,
				StrengthPotential = 3.2f,
				AgilityPotential = 15f,
				VitalityPotential = 7.9f
			};
		}
	}

	// Token: 0x17000E9A RID: 3738
	// (get) Token: 0x06004866 RID: 18534 RVA: 0x001DFD04 File Offset: 0x001DE104
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x17000E9B RID: 3739
	// (get) Token: 0x06004867 RID: 18535 RVA: 0x001DFD08 File Offset: 0x001DE108
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Frenzy
			};
		}
	}

	// Token: 0x17000E9C RID: 3740
	// (get) Token: 0x06004868 RID: 18536 RVA: 0x001DFD27 File Offset: 0x001DE127
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1800;
		}
	}

	// Token: 0x04003A75 RID: 14965
	private OutputType _outputType = OutputType.Physical;
}
