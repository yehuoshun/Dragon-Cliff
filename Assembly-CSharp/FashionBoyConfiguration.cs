using System;
using System.Collections.Generic;

// Token: 0x02000A63 RID: 2659
public class FashionBoyConfiguration : AdventurerUnitConfigurationBase
{
	// Token: 0x06004833 RID: 18483 RVA: 0x001DF99E File Offset: 0x001DDD9E
	public FashionBoyConfiguration()
	{
	}

	// Token: 0x17000E6D RID: 3693
	// (get) Token: 0x06004834 RID: 18484 RVA: 0x001DF9AD File Offset: 0x001DDDAD
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FashionBoy;
		}
	}

	// Token: 0x17000E6E RID: 3694
	// (get) Token: 0x06004835 RID: 18485 RVA: 0x001DF9B4 File Offset: 0x001DDDB4
	public override OutputType OutputType
	{
		get
		{
			return this._outputType;
		}
	}

	// Token: 0x17000E6F RID: 3695
	// (get) Token: 0x06004836 RID: 18486 RVA: 0x001DF9BC File Offset: 0x001DDDBC
	public override ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.FashionBoyInvitation;
		}
	}

	// Token: 0x17000E70 RID: 3696
	// (get) Token: 0x06004837 RID: 18487 RVA: 0x001DF9C3 File Offset: 0x001DDDC3
	public override SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.Meteorolite;
		}
	}

	// Token: 0x17000E71 RID: 3697
	// (get) Token: 0x06004838 RID: 18488 RVA: 0x001DF9CC File Offset: 0x001DDDCC
	public override UnitGrowthProfile AdventurerGrowthProfile
	{
		get
		{
			return new UnitGrowthProfile
			{
				IntelligiencePotential = 3.5f,
				FocusPotential = 0.08f,
				AgilityPotential = 5f,
				VitalityPotential = 4.3f
			};
		}
	}

	// Token: 0x17000E72 RID: 3698
	// (get) Token: 0x06004839 RID: 18489 RVA: 0x001DFA0C File Offset: 0x001DDE0C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x17000E73 RID: 3699
	// (get) Token: 0x0600483A RID: 18490 RVA: 0x001DFA10 File Offset: 0x001DDE10
	public override List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>
			{
				SkillType.GrandMeteorolite
			};
		}
	}

	// Token: 0x17000E74 RID: 3700
	// (get) Token: 0x0600483B RID: 18491 RVA: 0x001DFA2F File Offset: 0x001DDE2F
	public override int RecruitmentPriceRaw
	{
		get
		{
			return 1000;
		}
	}

	// Token: 0x04003A70 RID: 14960
	private OutputType _outputType = OutputType.Fire;
}
