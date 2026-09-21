using System;
using System.Collections.Generic;

// Token: 0x02000A6A RID: 2666
public class MissionaryConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004872 RID: 18546 RVA: 0x001DFDC6 File Offset: 0x001DE1C6
	public MissionaryConfiguration()
	{
	}

	// Token: 0x17000EA5 RID: 3749
	// (get) Token: 0x06004873 RID: 18547 RVA: 0x001DFDD5 File Offset: 0x001DE1D5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Missionary;
		}
	}

	// Token: 0x17000EA6 RID: 3750
	// (get) Token: 0x06004874 RID: 18548 RVA: 0x001DFDDC File Offset: 0x001DE1DC
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EA7 RID: 3751
	// (get) Token: 0x06004875 RID: 18549 RVA: 0x001DFDE4 File Offset: 0x001DE1E4
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Pray;
		}
	}

	// Token: 0x17000EA8 RID: 3752
	// (get) Token: 0x06004876 RID: 18550 RVA: 0x001DFDEB File Offset: 0x001DE1EB
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.MissionaryInvitation;
		}
	}

	// Token: 0x17000EA9 RID: 3753
	// (get) Token: 0x06004877 RID: 18551 RVA: 0x001DFDF4 File Offset: 0x001DE1F4
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				IntelligiencePotential = 3.3f,
				FocusPotential = 0.05f,
				AgilityPotential = 6.5f,
				VitalityPotential = 9f
			};
		}
	}

	// Token: 0x17000EAA RID: 3754
	// (get) Token: 0x06004878 RID: 18552 RVA: 0x001DFE34 File Offset: 0x001DE234
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x17000EAB RID: 3755
	// (get) Token: 0x06004879 RID: 18553 RVA: 0x001DFE38 File Offset: 0x001DE238
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.SpellOfHoliness
			};
		}
	}

	// Token: 0x17000EAC RID: 3756
	// (get) Token: 0x0600487A RID: 18554 RVA: 0x001DFE57 File Offset: 0x001DE257
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 500;
		}
	}

	// Token: 0x04003A77 RID: 14967
	private OutputType _outputType = OutputType.Divine;
}
