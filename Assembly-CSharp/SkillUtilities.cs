using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200077C RID: 1916
public static class SkillUtilities
{
	// Token: 0x06003891 RID: 14481 RVA: 0x00172298 File Offset: 0x00170698
	public static List<IBattleUnit> GetLiveEnemyTargets(this IBattleUnit caster, bool isTauntConsiderred, bool isFadeConsiderred)
	{
		BattleEncounter battleEncounter = caster.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			if (isTauntConsiderred)
			{
				if (caster.BattleEffects.Any((BattleEffectBase ef) => ef is TauntEffect))
				{
					TauntEffect tauntEffect = caster.BattleEffects.First((BattleEffectBase t) => t is TauntEffect) as TauntEffect;
					IBattleUnit caster2 = tauntEffect.Caster;
					if (caster2.Status == BattleUnitStatus.Active)
					{
						return new List<IBattleUnit>
						{
							caster2
						};
					}
				}
			}
			return (from u in battleEncounter.GetOpponents(caster)
			where u.Status == BattleUnitStatus.Active && (!isFadeConsiderred || !u.BattleEffects.OfType<FadeEffect>().Any<FadeEffect>())
			select u).ToList<IBattleUnit>();
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06003892 RID: 14482 RVA: 0x00172370 File Offset: 0x00170770
	public static List<IBattleUnit> GetAllLiveFriendlyTargetsIncSelf(this IBattleUnit caster, bool fadeConsidered)
	{
		BattleEncounter battleEncounter = caster.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			return (from u in battleEncounter.GetAllFriendlyUnits(caster)
			where u.Status == BattleUnitStatus.Active && (!fadeConsidered || !u.BattleEffects.OfType<FadeEffect>().Any<FadeEffect>())
			select u).ToList<IBattleUnit>();
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06003893 RID: 14483 RVA: 0x001723C0 File Offset: 0x001707C0
	public static List<IBattleUnit> GetAllDeadFriendlyTargetsIncSelf(this IBattleUnit caster)
	{
		BattleEncounter battleEncounter = caster.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			return (from u in battleEncounter.GetAllFriendlyUnits(caster)
			where u.Status == BattleUnitStatus.Dead
			select u).ToList<IBattleUnit>();
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06003894 RID: 14484 RVA: 0x00172414 File Offset: 0x00170814
	public static List<IBattleUnit> GetDeadEnemyTargets(this IBattleUnit caster)
	{
		BattleEncounter battleEncounter = caster.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			return (from u in battleEncounter.GetOpponents(caster)
			where u.Status == BattleUnitStatus.Dead
			select u).ToList<IBattleUnit>();
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06003895 RID: 14485 RVA: 0x00172467 File Offset: 0x00170867
	public static IBattleUnit GetRandomUnit(this List<IBattleUnit> units)
	{
		if (units.Count > 0)
		{
			return units[UnityEngine.Random.Range(0, units.Count)];
		}
		return null;
	}

	// Token: 0x06003896 RID: 14486 RVA: 0x0017248C File Offset: 0x0017088C
	public static IBattleUnit GetLeastHpPercentageUnit(this List<IBattleUnit> units)
	{
		var <>__AnonType = (from u in units
		select new
		{
			life = u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill),
			u = u
		} into u
		orderby u.life
		select u).FirstOrDefault();
		if (<>__AnonType != null)
		{
			return <>__AnonType.u;
		}
		return null;
	}

	// Token: 0x06003897 RID: 14487 RVA: 0x001724F2 File Offset: 0x001708F2
	public static IBattleUnit GetHighestStrengthUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill) descending
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x06003898 RID: 14488 RVA: 0x0017251C File Offset: 0x0017091C
	public static IBattleUnit GetHighestHpPercentageUnit(this List<IBattleUnit> units)
	{
		var <>__AnonType = (from u in units
		select new
		{
			life = u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill),
			u = u
		} into u
		orderby u.life descending
		select u).FirstOrDefault();
		if (<>__AnonType != null)
		{
			return <>__AnonType.u;
		}
		return null;
	}

	// Token: 0x06003899 RID: 14489 RVA: 0x00172582 File Offset: 0x00170982
	public static IBattleUnit GetHighestSpeedUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetSpeed(AttributeRetrievalLevel.Skill) descending
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389A RID: 14490 RVA: 0x001725AC File Offset: 0x001709AC
	public static IBattleUnit GetLowestSpeedUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetSpeed(AttributeRetrievalLevel.Skill)
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389B RID: 14491 RVA: 0x001725D6 File Offset: 0x001709D6
	public static IBattleUnit GetHighestArmorUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill) descending
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389C RID: 14492 RVA: 0x00172600 File Offset: 0x00170A00
	public static IBattleUnit GetLowestArmorUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill)
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389D RID: 14493 RVA: 0x0017262A File Offset: 0x00170A2A
	public static IBattleUnit GetLowestSpellUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill)
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389E RID: 14494 RVA: 0x00172654 File Offset: 0x00170A54
	public static IBattleUnit GetHighestSpellUnit(this List<IBattleUnit> units)
	{
		return (from u in units
		orderby u.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) descending
		select u).FirstOrDefault<IBattleUnit>();
	}

	// Token: 0x0600389F RID: 14495 RVA: 0x00172680 File Offset: 0x00170A80
	public static bool EffectExpired(BattleEffectBase effect)
	{
		int? num = effect.NumberOfRemainingTurns();
		return num != null && num.Value <= 0;
	}

	// Token: 0x060038A0 RID: 14496 RVA: 0x001726B0 File Offset: 0x00170AB0
	public static List<BattleEffectBase> GetExpiredEffects(List<BattleEffectBase> effects)
	{
		if (SkillUtilities.<>f__mg$cache0 == null)
		{
			SkillUtilities.<>f__mg$cache0 = new Func<BattleEffectBase, bool>(SkillUtilities.EffectExpired);
		}
		return (from ef in effects.Where(SkillUtilities.<>f__mg$cache0)
		select ef).ToList<BattleEffectBase>();
	}

	// Token: 0x060038A1 RID: 14497 RVA: 0x00172708 File Offset: 0x00170B08
	public static int? NumberOfRemainingTurns(this BattleEffectBase effect)
	{
		if (effect.NumberOfLastingTurns != null && effect.TurnEventsCollected.Any<AdventureEventType>())
		{
			AdventureEventType initEvt = effect.TurnEventsCollected.First<AdventureEventType>();
			int num = (int)Math.Floor((double)effect.TurnEventsCollected.Count((AdventureEventType e) => e == initEvt) / 2.0);
			int value = effect.NumberOfLastingTurns.Value;
			return new int?(value - num);
		}
		return null;
	}

	// Token: 0x060038A2 RID: 14498 RVA: 0x0017279B File Offset: 0x00170B9B
	[CompilerGenerated]
	private static bool <GetLiveEnemyTargets>m__0(BattleEffectBase ef)
	{
		return ef is TauntEffect;
	}

	// Token: 0x060038A3 RID: 14499 RVA: 0x001727A6 File Offset: 0x00170BA6
	[CompilerGenerated]
	private static bool <GetLiveEnemyTargets>m__1(BattleEffectBase t)
	{
		return t is TauntEffect;
	}

	// Token: 0x060038A4 RID: 14500 RVA: 0x001727B1 File Offset: 0x00170BB1
	[CompilerGenerated]
	private static bool <GetAllDeadFriendlyTargetsIncSelf>m__2(IBattleUnit u)
	{
		return u.Status == BattleUnitStatus.Dead;
	}

	// Token: 0x060038A5 RID: 14501 RVA: 0x001727BC File Offset: 0x00170BBC
	[CompilerGenerated]
	private static bool <GetDeadEnemyTargets>m__3(IBattleUnit u)
	{
		return u.Status == BattleUnitStatus.Dead;
	}

	// Token: 0x060038A6 RID: 14502 RVA: 0x001727C7 File Offset: 0x00170BC7
	[CompilerGenerated]
	private static <>__AnonType4<double, IBattleUnit> <GetLeastHpPercentageUnit>m__4(IBattleUnit u)
	{
		return new
		{
			life = u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill),
			u = u
		};
	}

	// Token: 0x060038A7 RID: 14503 RVA: 0x001727DD File Offset: 0x00170BDD
	[CompilerGenerated]
	private static double <GetLeastHpPercentageUnit>m__5(<>__AnonType4<double, IBattleUnit> u)
	{
		return u.life;
	}

	// Token: 0x060038A8 RID: 14504 RVA: 0x001727E5 File Offset: 0x00170BE5
	[CompilerGenerated]
	private static double <GetHighestStrengthUnit>m__6(IBattleUnit u)
	{
		return u.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038A9 RID: 14505 RVA: 0x001727EF File Offset: 0x00170BEF
	[CompilerGenerated]
	private static <>__AnonType4<double, IBattleUnit> <GetHighestHpPercentageUnit>m__7(IBattleUnit u)
	{
		return new
		{
			life = u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill),
			u = u
		};
	}

	// Token: 0x060038AA RID: 14506 RVA: 0x00172805 File Offset: 0x00170C05
	[CompilerGenerated]
	private static double <GetHighestHpPercentageUnit>m__8(<>__AnonType4<double, IBattleUnit> u)
	{
		return u.life;
	}

	// Token: 0x060038AB RID: 14507 RVA: 0x0017280D File Offset: 0x00170C0D
	[CompilerGenerated]
	private static double <GetHighestSpeedUnit>m__9(IBattleUnit u)
	{
		return u.GetSpeed(AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038AC RID: 14508 RVA: 0x00172816 File Offset: 0x00170C16
	[CompilerGenerated]
	private static double <GetLowestSpeedUnit>m__A(IBattleUnit u)
	{
		return u.GetSpeed(AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038AD RID: 14509 RVA: 0x0017281F File Offset: 0x00170C1F
	[CompilerGenerated]
	private static double <GetHighestArmorUnit>m__B(IBattleUnit u)
	{
		return u.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038AE RID: 14510 RVA: 0x00172829 File Offset: 0x00170C29
	[CompilerGenerated]
	private static double <GetLowestArmorUnit>m__C(IBattleUnit u)
	{
		return u.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038AF RID: 14511 RVA: 0x00172833 File Offset: 0x00170C33
	[CompilerGenerated]
	private static double <GetLowestSpellUnit>m__D(IBattleUnit u)
	{
		return u.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038B0 RID: 14512 RVA: 0x0017283D File Offset: 0x00170C3D
	[CompilerGenerated]
	private static double <GetHighestSpellUnit>m__E(IBattleUnit u)
	{
		return u.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x060038B1 RID: 14513 RVA: 0x00172847 File Offset: 0x00170C47
	[CompilerGenerated]
	private static BattleEffectBase <GetExpiredEffects>m__F(BattleEffectBase ef)
	{
		return ef;
	}

	// Token: 0x04002C2F RID: 11311
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache0;

	// Token: 0x04002C30 RID: 11312
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache1;

	// Token: 0x04002C31 RID: 11313
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache2;

	// Token: 0x04002C32 RID: 11314
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache3;

	// Token: 0x04002C33 RID: 11315
	[CompilerGenerated]
	private static Func<IBattleUnit, <>__AnonType4<double, IBattleUnit>> <>f__am$cache4;

	// Token: 0x04002C34 RID: 11316
	[CompilerGenerated]
	private static Func<<>__AnonType4<double, IBattleUnit>, double> <>f__am$cache5;

	// Token: 0x04002C35 RID: 11317
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache6;

	// Token: 0x04002C36 RID: 11318
	[CompilerGenerated]
	private static Func<IBattleUnit, <>__AnonType4<double, IBattleUnit>> <>f__am$cache7;

	// Token: 0x04002C37 RID: 11319
	[CompilerGenerated]
	private static Func<<>__AnonType4<double, IBattleUnit>, double> <>f__am$cache8;

	// Token: 0x04002C38 RID: 11320
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache9;

	// Token: 0x04002C39 RID: 11321
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheA;

	// Token: 0x04002C3A RID: 11322
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheB;

	// Token: 0x04002C3B RID: 11323
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheC;

	// Token: 0x04002C3C RID: 11324
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheD;

	// Token: 0x04002C3D RID: 11325
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheE;

	// Token: 0x04002C3E RID: 11326
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__mg$cache0;

	// Token: 0x04002C3F RID: 11327
	[CompilerGenerated]
	private static Func<BattleEffectBase, BattleEffectBase> <>f__am$cacheF;

	// Token: 0x02000EE6 RID: 3814
	[CompilerGenerated]
	private sealed class <GetLiveEnemyTargets>c__AnonStorey0
	{
		// Token: 0x06006044 RID: 24644 RVA: 0x0017284A File Offset: 0x00170C4A
		public <GetLiveEnemyTargets>c__AnonStorey0()
		{
		}

		// Token: 0x06006045 RID: 24645 RVA: 0x00172852 File Offset: 0x00170C52
		internal bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active && (!this.isFadeConsiderred || !u.BattleEffects.OfType<FadeEffect>().Any<FadeEffect>());
		}

		// Token: 0x04005561 RID: 21857
		internal bool isFadeConsiderred;
	}

	// Token: 0x02000EE7 RID: 3815
	[CompilerGenerated]
	private sealed class <GetAllLiveFriendlyTargetsIncSelf>c__AnonStorey1
	{
		// Token: 0x06006046 RID: 24646 RVA: 0x00172884 File Offset: 0x00170C84
		public <GetAllLiveFriendlyTargetsIncSelf>c__AnonStorey1()
		{
		}

		// Token: 0x06006047 RID: 24647 RVA: 0x0017288C File Offset: 0x00170C8C
		internal bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active && (!this.fadeConsidered || !u.BattleEffects.OfType<FadeEffect>().Any<FadeEffect>());
		}

		// Token: 0x04005562 RID: 21858
		internal bool fadeConsidered;
	}

	// Token: 0x02000EE9 RID: 3817
	[CompilerGenerated]
	private sealed class <NumberOfRemainingTurns>c__AnonStorey2
	{
		// Token: 0x0600604E RID: 24654 RVA: 0x001728BE File Offset: 0x00170CBE
		public <NumberOfRemainingTurns>c__AnonStorey2()
		{
		}

		// Token: 0x0600604F RID: 24655 RVA: 0x001728C6 File Offset: 0x00170CC6
		internal bool <>m__0(AdventureEventType e)
		{
			return e == this.initEvt;
		}

		// Token: 0x04005565 RID: 21861
		internal AdventureEventType initEvt;
	}
}
