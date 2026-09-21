using System;
using System.Collections.Generic;

// Token: 0x02000A6F RID: 2671
public class SnowMaidenConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x0600489C RID: 18588 RVA: 0x001E009C File Offset: 0x001DE49C
	public SnowMaidenConfiguration()
	{
	}

	// Token: 0x17000ECA RID: 3786
	// (get) Token: 0x0600489D RID: 18589 RVA: 0x001E00AB File Offset: 0x001DE4AB
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.SnowMaiden;
		}
	}

	// Token: 0x17000ECB RID: 3787
	// (get) Token: 0x0600489E RID: 18590 RVA: 0x001E00B2 File Offset: 0x001DE4B2
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000ECC RID: 3788
	// (get) Token: 0x0600489F RID: 18591 RVA: 0x001E00BA File Offset: 0x001DE4BA
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.SnowMaidenInvitation;
		}
	}

	// Token: 0x17000ECD RID: 3789
	// (get) Token: 0x060048A0 RID: 18592 RVA: 0x001E00C4 File Offset: 0x001DE4C4
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 2.2000000476837158, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Agility, 8.3000001907348633, false).SetValue(AttributeType.Vitality, 5.8000001907348633, false);
		}
	}

	// Token: 0x17000ECE RID: 3790
	// (get) Token: 0x060048A1 RID: 18593 RVA: 0x001E0116 File Offset: 0x001DE516
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Freeze;
		}
	}

	// Token: 0x17000ECF RID: 3791
	// (get) Token: 0x060048A2 RID: 18594 RVA: 0x001E0120 File Offset: 0x001DE520
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.Seduction
			};
		}
	}

	// Token: 0x17000ED0 RID: 3792
	// (get) Token: 0x060048A3 RID: 18595 RVA: 0x001E013F File Offset: 0x001DE53F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}

	// Token: 0x17000ED1 RID: 3793
	// (get) Token: 0x060048A4 RID: 18596 RVA: 0x001E0143 File Offset: 0x001DE543
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1500;
		}
	}

	// Token: 0x04003A7C RID: 14972
	private OutputType _outputType = OutputType.Ice;
}
