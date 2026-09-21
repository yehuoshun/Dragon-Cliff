using System;
using System.Collections.Generic;

// Token: 0x02000A75 RID: 2677
public class YoungWorlockConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x060048D2 RID: 18642 RVA: 0x001E048A File Offset: 0x001DE88A
	public YoungWorlockConfiguration()
	{
	}

	// Token: 0x17000EFA RID: 3834
	// (get) Token: 0x060048D3 RID: 18643 RVA: 0x001E0499 File Offset: 0x001DE899
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YoungWarlock;
		}
	}

	// Token: 0x17000EFB RID: 3835
	// (get) Token: 0x060048D4 RID: 18644 RVA: 0x001E04A0 File Offset: 0x001DE8A0
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000EFC RID: 3836
	// (get) Token: 0x060048D5 RID: 18645 RVA: 0x001E04A8 File Offset: 0x001DE8A8
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Vitality, 6.0, false).SetValue(AttributeType.Intelligience, 3.2000000476837158, false).SetValue(AttributeType.Agility, 3.0, false).SetValue(AttributeType.CritRate, 0.11999999731779099, false);
		}
	}

	// Token: 0x17000EFD RID: 3837
	// (get) Token: 0x060048D6 RID: 18646 RVA: 0x001E04FA File Offset: 0x001DE8FA
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.ShadowSacrifice;
		}
	}

	// Token: 0x17000EFE RID: 3838
	// (get) Token: 0x060048D7 RID: 18647 RVA: 0x001E0501 File Offset: 0x001DE901
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.YoungWarlockInvitation;
		}
	}

	// Token: 0x17000EFF RID: 3839
	// (get) Token: 0x060048D8 RID: 18648 RVA: 0x001E0508 File Offset: 0x001DE908
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000F00 RID: 3840
	// (get) Token: 0x060048D9 RID: 18649 RVA: 0x001E050C File Offset: 0x001DE90C
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.CurseOfTheDead
			};
		}
	}

	// Token: 0x17000F01 RID: 3841
	// (get) Token: 0x060048DA RID: 18650 RVA: 0x001E052B File Offset: 0x001DE92B
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1500;
		}
	}

	// Token: 0x04003A82 RID: 14978
	private OutputType _outputType = OutputType.Shadow;
}
