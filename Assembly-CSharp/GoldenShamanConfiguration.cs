using System;
using System.Collections.Generic;

// Token: 0x02000A67 RID: 2663
public class GoldenShamanConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004857 RID: 18519 RVA: 0x001DFBFE File Offset: 0x001DDFFE
	public GoldenShamanConfiguration()
	{
	}

	// Token: 0x17000E8D RID: 3725
	// (get) Token: 0x06004858 RID: 18520 RVA: 0x001DFC0D File Offset: 0x001DE00D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GoldenShaman;
		}
	}

	// Token: 0x17000E8E RID: 3726
	// (get) Token: 0x06004859 RID: 18521 RVA: 0x001DFC14 File Offset: 0x001DE014
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E8F RID: 3727
	// (get) Token: 0x0600485A RID: 18522 RVA: 0x001DFC1C File Offset: 0x001DE01C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.GoldenShamanInvitation;
		}
	}

	// Token: 0x17000E90 RID: 3728
	// (get) Token: 0x0600485B RID: 18523 RVA: 0x001DFC24 File Offset: 0x001DE024
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				IntelligiencePotential = 3.5f,
				FocusPotential = 0.05f,
				AgilityPotential = 7.5f,
				VitalityPotential = 6f
			};
		}
	}

	// Token: 0x17000E91 RID: 3729
	// (get) Token: 0x0600485C RID: 18524 RVA: 0x001DFC64 File Offset: 0x001DE064
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.DivineHammer;
		}
	}

	// Token: 0x17000E92 RID: 3730
	// (get) Token: 0x0600485D RID: 18525 RVA: 0x001DFC6B File Offset: 0x001DE06B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x17000E93 RID: 3731
	// (get) Token: 0x0600485E RID: 18526 RVA: 0x001DFC70 File Offset: 0x001DE070
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.DivineRemedy
			};
		}
	}

	// Token: 0x17000E94 RID: 3732
	// (get) Token: 0x0600485F RID: 18527 RVA: 0x001DFC8F File Offset: 0x001DE08F
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 2500;
		}
	}

	// Token: 0x04003A74 RID: 14964
	private OutputType _outputType = OutputType.Divine;
}
