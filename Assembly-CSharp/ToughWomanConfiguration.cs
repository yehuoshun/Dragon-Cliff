using System;
using System.Collections.Generic;

// Token: 0x02000A73 RID: 2675
public class ToughWomanConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048C0 RID: 18624 RVA: 0x001E033E File Offset: 0x001DE73E
	public ToughWomanConfiguration()
	{
	}

	// Token: 0x17000EEA RID: 3818
	// (get) Token: 0x060048C1 RID: 18625 RVA: 0x001E034D File Offset: 0x001DE74D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ToughWoman;
		}
	}

	// Token: 0x17000EEB RID: 3819
	// (get) Token: 0x060048C2 RID: 18626 RVA: 0x001E0354 File Offset: 0x001DE754
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EEC RID: 3820
	// (get) Token: 0x060048C3 RID: 18627 RVA: 0x001E035C File Offset: 0x001DE75C
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.CritRate, 0.079999998211860657, false).SetValue(AttributeType.Strength, 2.7999999523162842, false).SetValue(AttributeType.Agility, 8.0, false).SetValue(AttributeType.Vitality, 5.0, false);
		}
	}

	// Token: 0x17000EED RID: 3821
	// (get) Token: 0x060048C4 RID: 18628 RVA: 0x001E03AE File Offset: 0x001DE7AE
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Shadowless;
		}
	}

	// Token: 0x17000EEE RID: 3822
	// (get) Token: 0x060048C5 RID: 18629 RVA: 0x001E03B5 File Offset: 0x001DE7B5
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.ToughWomanInvitation;
		}
	}

	// Token: 0x17000EEF RID: 3823
	// (get) Token: 0x060048C6 RID: 18630 RVA: 0x001E03BC File Offset: 0x001DE7BC
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x17000EF0 RID: 3824
	// (get) Token: 0x060048C7 RID: 18631 RVA: 0x001E03C0 File Offset: 0x001DE7C0
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.SwiftWind
			};
		}
	}

	// Token: 0x17000EF1 RID: 3825
	// (get) Token: 0x060048C8 RID: 18632 RVA: 0x001E03DF File Offset: 0x001DE7DF
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 600;
		}
	}

	// Token: 0x04003A80 RID: 14976
	private OutputType _outputType = OutputType.Physical;
}
