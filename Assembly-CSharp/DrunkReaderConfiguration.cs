using System;
using System.Collections.Generic;

// Token: 0x02000A60 RID: 2656
public class DrunkReaderConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004818 RID: 18456 RVA: 0x001DF7C9 File Offset: 0x001DDBC9
	public DrunkReaderConfiguration()
	{
	}

	// Token: 0x17000E55 RID: 3669
	// (get) Token: 0x06004819 RID: 18457 RVA: 0x001DF7D8 File Offset: 0x001DDBD8
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DrunkReader;
		}
	}

	// Token: 0x17000E56 RID: 3670
	// (get) Token: 0x0600481A RID: 18458 RVA: 0x001DF7DF File Offset: 0x001DDBDF
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E57 RID: 3671
	// (get) Token: 0x0600481B RID: 18459 RVA: 0x001DF7E7 File Offset: 0x001DDBE7
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.DrunkReaderInvitation;
		}
	}

	// Token: 0x17000E58 RID: 3672
	// (get) Token: 0x0600481C RID: 18460 RVA: 0x001DF7EE File Offset: 0x001DDBEE
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Arcane;
		}
	}

	// Token: 0x17000E59 RID: 3673
	// (get) Token: 0x0600481D RID: 18461 RVA: 0x001DF7F8 File Offset: 0x001DDBF8
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				AgilityPotential = 5f,
				IntelligiencePotential = 2.8f,
				FocusPotential = 0.1f,
				VitalityPotential = 6.5f
			};
		}
	}

	// Token: 0x17000E5A RID: 3674
	// (get) Token: 0x0600481E RID: 18462 RVA: 0x001DF838 File Offset: 0x001DDC38
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E5B RID: 3675
	// (get) Token: 0x0600481F RID: 18463 RVA: 0x001DF83C File Offset: 0x001DDC3C
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Drunkenness
			};
		}
	}

	// Token: 0x17000E5C RID: 3676
	// (get) Token: 0x06004820 RID: 18464 RVA: 0x001DF85B File Offset: 0x001DDC5B
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 600;
		}
	}

	// Token: 0x04003A6D RID: 14957
	private OutputType _outputType = OutputType.Lightening;
}
