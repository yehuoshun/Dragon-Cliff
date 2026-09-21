using System;
using System.Collections.Generic;

// Token: 0x02000A69 RID: 2665
public class KillerConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004869 RID: 18537 RVA: 0x001DFD2E File Offset: 0x001DE12E
	public KillerConfiguration()
	{
	}

	// Token: 0x17000E9D RID: 3741
	// (get) Token: 0x0600486A RID: 18538 RVA: 0x001DFD3D File Offset: 0x001DE13D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Killer;
		}
	}

	// Token: 0x17000E9E RID: 3742
	// (get) Token: 0x0600486B RID: 18539 RVA: 0x001DFD44 File Offset: 0x001DE144
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E9F RID: 3743
	// (get) Token: 0x0600486C RID: 18540 RVA: 0x001DFD4C File Offset: 0x001DE14C
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.KillerInvitation;
		}
	}

	// Token: 0x17000EA0 RID: 3744
	// (get) Token: 0x0600486D RID: 18541 RVA: 0x001DFD54 File Offset: 0x001DE154
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				FocusPotential = 0.05f,
				StrengthPotential = 2.8f,
				AgilityPotential = 4.5f,
				VitalityPotential = 6f
			};
		}
	}

	// Token: 0x17000EA1 RID: 3745
	// (get) Token: 0x0600486E RID: 18542 RVA: 0x001DFD94 File Offset: 0x001DE194
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.DeadlyBlade;
		}
	}

	// Token: 0x17000EA2 RID: 3746
	// (get) Token: 0x0600486F RID: 18543 RVA: 0x001DFD9B File Offset: 0x001DE19B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x17000EA3 RID: 3747
	// (get) Token: 0x06004870 RID: 18544 RVA: 0x001DFDA0 File Offset: 0x001DE1A0
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.ThousandKnives
			};
		}
	}

	// Token: 0x17000EA4 RID: 3748
	// (get) Token: 0x06004871 RID: 18545 RVA: 0x001DFDBF File Offset: 0x001DE1BF
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1200;
		}
	}

	// Token: 0x04003A76 RID: 14966
	private OutputType _outputType = OutputType.Poison;
}
