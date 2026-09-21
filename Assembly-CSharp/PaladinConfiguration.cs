using System;
using System.Collections.Generic;

// Token: 0x02000A6C RID: 2668
public class PaladinConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004884 RID: 18564 RVA: 0x001DFEF6 File Offset: 0x001DE2F6
	public PaladinConfiguration()
	{
	}

	// Token: 0x17000EB5 RID: 3765
	// (get) Token: 0x06004885 RID: 18565 RVA: 0x001DFF05 File Offset: 0x001DE305
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Paladin;
		}
	}

	// Token: 0x17000EB6 RID: 3766
	// (get) Token: 0x06004886 RID: 18566 RVA: 0x001DFF08 File Offset: 0x001DE308
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EB7 RID: 3767
	// (get) Token: 0x06004887 RID: 18567 RVA: 0x001DFF10 File Offset: 0x001DE310
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.PaladinInvitation;
		}
	}

	// Token: 0x17000EB8 RID: 3768
	// (get) Token: 0x06004888 RID: 18568 RVA: 0x001DFF18 File Offset: 0x001DE318
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.08f,
				StrengthPotential = 1.3f,
				AgilityPotential = 6.5f,
				VitalityPotential = 6.8f
			};
		}
	}

	// Token: 0x17000EB9 RID: 3769
	// (get) Token: 0x06004889 RID: 18569 RVA: 0x001DFF58 File Offset: 0x001DE358
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Taunt;
		}
	}

	// Token: 0x17000EBA RID: 3770
	// (get) Token: 0x0600488A RID: 18570 RVA: 0x001DFF5F File Offset: 0x001DE35F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x17000EBB RID: 3771
	// (get) Token: 0x0600488B RID: 18571 RVA: 0x001DFF64 File Offset: 0x001DE364
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Encouragement
			};
		}
	}

	// Token: 0x17000EBC RID: 3772
	// (get) Token: 0x0600488C RID: 18572 RVA: 0x001DFF83 File Offset: 0x001DE383
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 600;
		}
	}

	// Token: 0x04003A79 RID: 14969
	private OutputType _outputType = OutputType.Physical;
}
