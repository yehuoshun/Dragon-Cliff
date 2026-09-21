using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000A76 RID: 2678
public abstract class AdventurerUnitConfigurationBase : UnitConfigurationBase
{
	// Token: 0x060048DB RID: 18651 RVA: 0x001DF144 File Offset: 0x001DD544
	protected AdventurerUnitConfigurationBase()
	{
	}

	// Token: 0x17000F02 RID: 3842
	// (get) Token: 0x060048DC RID: 18652
	public abstract OutputType OutputType { get; }

	// Token: 0x17000F03 RID: 3843
	// (get) Token: 0x060048DD RID: 18653 RVA: 0x001DF14C File Offset: 0x001DD54C
	public virtual SkillType DefaultPrimarySkill
	{
		get
		{
			return SkillType.None;
		}
	}

	// Token: 0x17000F04 RID: 3844
	// (get) Token: 0x060048DE RID: 18654 RVA: 0x001DF14F File Offset: 0x001DD54F
	public virtual List<SkillType> DefaultSecondarySkills
	{
		get
		{
			return new List<SkillType>();
		}
	}

	// Token: 0x17000F05 RID: 3845
	// (get) Token: 0x060048DF RID: 18655 RVA: 0x001DF156 File Offset: 0x001DD556
	public virtual List<SkillType> DefaultActiveSkills
	{
		get
		{
			return new List<SkillType>();
		}
	}

	// Token: 0x060048E0 RID: 18656 RVA: 0x001DF160 File Offset: 0x001DD560
	public List<SkillType> GenerateSkills()
	{
		List<SkillType> list = new List<SkillType>();
		if (this.DefaultPrimarySkill != SkillType.None)
		{
			list.Add(this.DefaultPrimarySkill);
		}
		if (this.DefaultSecondarySkills.Any<SkillType>())
		{
			list.AddRange(this.DefaultSecondarySkills);
		}
		if (this.DefaultActiveSkills.Any<SkillType>())
		{
			list.AddRange(this.DefaultActiveSkills);
		}
		return (from s in list.Distinct<SkillType>()
		select s).ToList<SkillType>();
	}

	// Token: 0x060048E1 RID: 18657 RVA: 0x001DF1EF File Offset: 0x001DD5EF
	public virtual List<ISpecialEffectDataLoad> GetSpecialEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060048E2 RID: 18658 RVA: 0x001DF1F8 File Offset: 0x001DD5F8
	public List<IAdventurerTalent> GenerateTalents()
	{
		List<IAdventurerTalent> list = new List<IAdventurerTalent>();
		list.Add(new HitRateEnhancementTalent());
		list.Add(new NegativeEffectEnhancementTalent());
		list.Add(new ElementDamageEnhancementTalent());
		if (this.OutputType == OutputType.Fire)
		{
			list.Add(new FireShieldTalent());
		}
		if (this.OutputType == OutputType.Poison)
		{
			list.Add(new PoisonEnhancementTalent());
		}
		if (this.OutputType == OutputType.Physical)
		{
			list.Add(new PhysicalEnhancementTalent());
		}
		if (this.OutputType == OutputType.Shadow)
		{
			list.Add(new ShadowEffectEnhancementTalent());
		}
		if (this.OutputType == OutputType.Ice)
		{
			list.Add(new IceEnhancementTalent());
		}
		if (this.OutputType == OutputType.Divine)
		{
			list.Add(new DivineEnhancementTalent());
		}
		if (this.OutputType == OutputType.Lightening)
		{
			list.Add(new LightningShieldTalent());
		}
		if (this.CorrespondingClassStyle == UnitClassStyle.SpellKiller || this.CorrespondingClassStyle == UnitClassStyle.PhysicalKiller)
		{
			list.AddRange(new List<IAdventurerTalent>
			{
				new DodgeEnhancementTalent(),
				new EnhancedEffectMasteryTalent(),
				new EnhancedResistancesTalent(),
				new CritDamageBoostTalent(),
				new EfficiencyTalent(),
				new StunEnhancementTalent(),
				new ShadowOfGhostTalent()
			});
		}
		if (this.CorrespondingClassStyle == UnitClassStyle.SpellWarrior || this.CorrespondingClassStyle == UnitClassStyle.PhysicalWarrior)
		{
			list.AddRange(new List<IAdventurerTalent>
			{
				new VitalityEnhancementTalent(),
				new TauntEnhancementTalent(),
				new EnhancedEffectMasteryTalent(),
				new EnhancedResistancesTalent(),
				new EfficiencyTalent(),
				new StunEnhancementTalent(),
				new RestrictionOfTimeTalent()
			});
		}
		if (this.CorrespondingClassStyle == UnitClassStyle.PhysicalDefender || this.CorrespondingClassStyle == UnitClassStyle.SpellDefender || this.CorrespondingClassStyle == UnitClassStyle.Protector)
		{
			list.AddRange(new List<IAdventurerTalent>
			{
				new VitalityEnhancementTalent(),
				new TauntEnhancementTalent(),
				new FurySpeedTalent(),
				new EnhancedEffectMasteryTalent(),
				new EnhancedResistancesTalent(),
				new RecoveryEnhancementTalent(),
				new ProtectorTalent()
			});
		}
		if (this.CorrespondingClassStyle == UnitClassStyle.PhysicalSupporter || this.CorrespondingClassStyle == UnitClassStyle.SpellSupporter)
		{
			list.AddRange(new List<IAdventurerTalent>
			{
				new DodgeEnhancementTalent(),
				new FurySpeedTalent(),
				new EnhancedEffectMasteryTalent(),
				new EnhancedResistancesTalent(),
				new EfficiencyTalent(),
				new RecoveryEnhancementTalent(),
				new BlackBloodTalent()
			});
		}
		if (this.CorrespondingClassStyle == UnitClassStyle.Healer)
		{
			list.AddRange(new List<IAdventurerTalent>
			{
				new DodgeEnhancementTalent(),
				new FurySpeedTalent(),
				new EnhancedEffectMasteryTalent(),
				new EnhancedResistancesTalent(),
				new EfficiencyTalent(),
				new RecoveryEnhancementTalent(),
				new DivineHeartTalent()
			});
		}
		List<IAdventurerTalent> list2 = list;
		IEnumerable<SkillType> source = this.GenerateSkills();
		if (AdventurerUnitConfigurationBase.<>f__mg$cache0 == null)
		{
			AdventurerUnitConfigurationBase.<>f__mg$cache0 = new Func<SkillType, SkillLogicBase>(SkillExtensions.GetSkillLogic);
		}
		list2.AddRange(source.Select(AdventurerUnitConfigurationBase.<>f__mg$cache0).SelectMany((SkillLogicBase s) => s.CreateSkillTalents()));
		return list;
	}

	// Token: 0x17000F06 RID: 3846
	// (get) Token: 0x060048E3 RID: 18659
	public abstract UnitGrowthProfile AdventurerGrowthProfile { get; }

	// Token: 0x060048E4 RID: 18660 RVA: 0x001DF55B File Offset: 0x001DD95B
	[CompilerGenerated]
	private static SkillType <GenerateSkills>m__0(SkillType s)
	{
		return s;
	}

	// Token: 0x060048E5 RID: 18661 RVA: 0x001DF55E File Offset: 0x001DD95E
	[CompilerGenerated]
	private static IEnumerable<IAdventurerTalent> <GenerateTalents>m__1(SkillLogicBase s)
	{
		return s.CreateSkillTalents();
	}

	// Token: 0x04003A83 RID: 14979
	[CompilerGenerated]
	private static Func<SkillType, SkillType> <>f__am$cache0;

	// Token: 0x04003A84 RID: 14980
	[CompilerGenerated]
	private static Func<SkillType, SkillLogicBase> <>f__mg$cache0;

	// Token: 0x04003A85 RID: 14981
	[CompilerGenerated]
	private static Func<SkillLogicBase, IEnumerable<IAdventurerTalent>> <>f__am$cache1;
}
