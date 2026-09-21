using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006E2 RID: 1762
public class TargetDefinition
{
	// Token: 0x06002FC4 RID: 12228 RVA: 0x00146401 File Offset: 0x00144801
	public TargetDefinition(TargetCandidateType candidateRange, CandidateOrderringMetric orderringMetric, OrderingType orderingType, int? numberOfTargets)
	{
		this.CandidateRange = candidateRange;
		this.OrderringMetric = orderringMetric;
		this.OrderingType = orderingType;
		this.NumberOfTargets = numberOfTargets;
	}

	// Token: 0x17000649 RID: 1609
	// (get) Token: 0x06002FC5 RID: 12229 RVA: 0x00146426 File Offset: 0x00144826
	// (set) Token: 0x06002FC6 RID: 12230 RVA: 0x0014642E File Offset: 0x0014482E
	public TargetCandidateType CandidateRange
	{
		[CompilerGenerated]
		get
		{
			return this.<CandidateRange>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CandidateRange>k__BackingField = value;
		}
	}

	// Token: 0x1700064A RID: 1610
	// (get) Token: 0x06002FC7 RID: 12231 RVA: 0x00146437 File Offset: 0x00144837
	// (set) Token: 0x06002FC8 RID: 12232 RVA: 0x0014643F File Offset: 0x0014483F
	public CandidateOrderringMetric OrderringMetric
	{
		[CompilerGenerated]
		get
		{
			return this.<OrderringMetric>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<OrderringMetric>k__BackingField = value;
		}
	}

	// Token: 0x1700064B RID: 1611
	// (get) Token: 0x06002FC9 RID: 12233 RVA: 0x00146448 File Offset: 0x00144848
	// (set) Token: 0x06002FCA RID: 12234 RVA: 0x00146450 File Offset: 0x00144850
	public OrderingType OrderingType
	{
		[CompilerGenerated]
		get
		{
			return this.<OrderingType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<OrderingType>k__BackingField = value;
		}
	}

	// Token: 0x1700064C RID: 1612
	// (get) Token: 0x06002FCB RID: 12235 RVA: 0x00146459 File Offset: 0x00144859
	// (set) Token: 0x06002FCC RID: 12236 RVA: 0x00146461 File Offset: 0x00144861
	public int? NumberOfTargets
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfTargets>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<NumberOfTargets>k__BackingField = value;
		}
	}

	// Token: 0x06002FCD RID: 12237 RVA: 0x0014646A File Offset: 0x0014486A
	public void SetNumberOfTargets(int? targets)
	{
		this.NumberOfTargets = targets;
	}

	// Token: 0x06002FCE RID: 12238 RVA: 0x00146474 File Offset: 0x00144874
	public List<IBattleUnit> GetTargets(IBattleUnit caster)
	{
		List<IBattleUnit> list = new List<IBattleUnit>();
		if (this.CandidateRange == TargetCandidateType.FriendlyAlive)
		{
			list = caster.GetAllLiveFriendlyTargetsIncSelf(true);
		}
		if (this.CandidateRange == TargetCandidateType.FriendlyAliveWithoutSelf)
		{
			list = (from s in caster.GetAllLiveFriendlyTargetsIncSelf(true)
			where s != caster
			select s).ToList<IBattleUnit>();
		}
		if (this.CandidateRange == TargetCandidateType.FriendlyDead)
		{
			list = caster.GetAllDeadFriendlyTargetsIncSelf();
		}
		if (this.CandidateRange == TargetCandidateType.HostileAlive)
		{
			list = caster.GetLiveEnemyTargets(true, true);
		}
		if (this.CandidateRange == TargetCandidateType.HostileDead)
		{
			list = caster.GetDeadEnemyTargets();
		}
		list = TargetDefinition.FilterCandidates(list, this.OrderringMetric, this.OrderingType);
		if (this.NumberOfTargets != null)
		{
			List<ISpecialEffectDataLoad> source = (from s in caster.SpecialEffects
			select s).ToList<ISpecialEffectDataLoad>();
			int num = (from d in source.OfType<ExtraTargetingData>()
			where d.CandidateTypes.Any((TargetCandidateType t) => t == this.CandidateRange)
			select d).Sum((ExtraTargetingData s) => s.Extra);
			int num2 = this.NumberOfTargets.Value;
			num2 += num;
			List<AdditionaTargetEffect> source2 = caster.BattleEffects.OfType<AdditionaTargetEffect>().ToList<AdditionaTargetEffect>();
			if (source2.Any((AdditionaTargetEffect ef) => ef.AdditionalNumber == null))
			{
				num2 += 100;
			}
			if (source2.Any<AdditionaTargetEffect>())
			{
				num2 += source2.Sum((AdditionaTargetEffect ef) => ef.AdditionalNumber).GetValueOrDefault();
			}
			list = list.Take(num2).ToList<IBattleUnit>();
		}
		if (this.CandidateRange == TargetCandidateType.HostileAlive)
		{
			List<IBattleUnit> collection = (from t in caster.GetLiveEnemyTargets(false, false)
			where t.BattleEffects.OfType<TargettedEffect>().Any<TargettedEffect>()
			select t).ToList<IBattleUnit>();
			list.AddRange(collection);
		}
		return list;
	}

	// Token: 0x06002FCF RID: 12239 RVA: 0x001466B8 File Offset: 0x00144AB8
	public static List<IBattleUnit> FilterCandidates(List<IBattleUnit> candidates, CandidateOrderringMetric orderringMetric, OrderingType orderingType)
	{
		if (orderringMetric == CandidateOrderringMetric.PhysicalResistance)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.HealthPointPercentage)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.HealthPoints / c.GetMaxLife(AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.Intelligience)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.Speed)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.Strength)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.OutputCapacity)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetAttributeValue_Final(c.GetOutputAttributeType(), AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.PositiveEffectCounts)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => (double)c.BattleEffects.GetPositiveEffects().Count<BattleEffectBase>());
		}
		if (orderringMetric == CandidateOrderringMetric.NegativeEffectCounts)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => (double)c.BattleEffects.GetHarmfulEffects().Count<BattleEffectBase>());
		}
		if (orderringMetric == CandidateOrderringMetric.HealthPoints)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.HealthPoints);
		}
		if (orderringMetric == CandidateOrderringMetric.MaxHealth)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => c.GetMaxLife(AttributeRetrievalLevel.Skill));
		}
		if (orderringMetric == CandidateOrderringMetric.MonsterType)
		{
			candidates = TargetDefinition.GetOrderredList(candidates, orderingType, (IBattleUnit c) => (double)((!(c is EnemyBattleUnit)) ? AdventureEncounterSlotType.MiniBoss : (c as EnemyBattleUnit).SlotSelection));
		}
		if (orderringMetric == CandidateOrderringMetric.Random)
		{
			candidates.Shuffle<IBattleUnit>();
		}
		return candidates;
	}

	// Token: 0x06002FD0 RID: 12240 RVA: 0x001468C4 File Offset: 0x00144CC4
	private static List<IBattleUnit> GetOrderredList(List<IBattleUnit> units, OrderingType orderingType, Func<IBattleUnit, double> metricFunc)
	{
		if (orderingType == OrderingType.Asc)
		{
			return units.OrderBy(metricFunc).ToList<IBattleUnit>();
		}
		if (orderingType == OrderingType.Desc)
		{
			return units.OrderByDescending(metricFunc).ToList<IBattleUnit>();
		}
		return units;
	}

	// Token: 0x06002FD1 RID: 12241 RVA: 0x001468EF File Offset: 0x00144CEF
	[CompilerGenerated]
	private static ISpecialEffectDataLoad <GetTargets>m__0(ISpecialEffectDataLoad s)
	{
		return s;
	}

	// Token: 0x06002FD2 RID: 12242 RVA: 0x001468F2 File Offset: 0x00144CF2
	[CompilerGenerated]
	private static int <GetTargets>m__1(ExtraTargetingData s)
	{
		return s.Extra;
	}

	// Token: 0x06002FD3 RID: 12243 RVA: 0x001468FC File Offset: 0x00144CFC
	[CompilerGenerated]
	private static bool <GetTargets>m__2(AdditionaTargetEffect ef)
	{
		return ef.AdditionalNumber == null;
	}

	// Token: 0x06002FD4 RID: 12244 RVA: 0x0014691A File Offset: 0x00144D1A
	[CompilerGenerated]
	private static int? <GetTargets>m__3(AdditionaTargetEffect ef)
	{
		return ef.AdditionalNumber;
	}

	// Token: 0x06002FD5 RID: 12245 RVA: 0x00146922 File Offset: 0x00144D22
	[CompilerGenerated]
	private static bool <GetTargets>m__4(IBattleUnit t)
	{
		return t.BattleEffects.OfType<TargettedEffect>().Any<TargettedEffect>();
	}

	// Token: 0x06002FD6 RID: 12246 RVA: 0x00146934 File Offset: 0x00144D34
	[CompilerGenerated]
	private static double <FilterCandidates>m__5(IBattleUnit c)
	{
		return c.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FD7 RID: 12247 RVA: 0x0014693E File Offset: 0x00144D3E
	[CompilerGenerated]
	private static double <FilterCandidates>m__6(IBattleUnit c)
	{
		return c.HealthPoints / c.GetMaxLife(AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FD8 RID: 12248 RVA: 0x0014694E File Offset: 0x00144D4E
	[CompilerGenerated]
	private static double <FilterCandidates>m__7(IBattleUnit c)
	{
		return c.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FD9 RID: 12249 RVA: 0x00146958 File Offset: 0x00144D58
	[CompilerGenerated]
	private static double <FilterCandidates>m__8(IBattleUnit c)
	{
		return c.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FDA RID: 12250 RVA: 0x00146962 File Offset: 0x00144D62
	[CompilerGenerated]
	private static double <FilterCandidates>m__9(IBattleUnit c)
	{
		return c.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FDB RID: 12251 RVA: 0x0014696C File Offset: 0x00144D6C
	[CompilerGenerated]
	private static double <FilterCandidates>m__A(IBattleUnit c)
	{
		return c.GetAttributeValue_Final(c.GetOutputAttributeType(), AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FDC RID: 12252 RVA: 0x0014697B File Offset: 0x00144D7B
	[CompilerGenerated]
	private static double <FilterCandidates>m__B(IBattleUnit c)
	{
		return (double)c.BattleEffects.GetPositiveEffects().Count<BattleEffectBase>();
	}

	// Token: 0x06002FDD RID: 12253 RVA: 0x0014698E File Offset: 0x00144D8E
	[CompilerGenerated]
	private static double <FilterCandidates>m__C(IBattleUnit c)
	{
		return (double)c.BattleEffects.GetHarmfulEffects().Count<BattleEffectBase>();
	}

	// Token: 0x06002FDE RID: 12254 RVA: 0x001469A1 File Offset: 0x00144DA1
	[CompilerGenerated]
	private static double <FilterCandidates>m__D(IBattleUnit c)
	{
		return c.HealthPoints;
	}

	// Token: 0x06002FDF RID: 12255 RVA: 0x001469A9 File Offset: 0x00144DA9
	[CompilerGenerated]
	private static double <FilterCandidates>m__E(IBattleUnit c)
	{
		return c.GetMaxLife(AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002FE0 RID: 12256 RVA: 0x001469B2 File Offset: 0x00144DB2
	[CompilerGenerated]
	private static double <FilterCandidates>m__F(IBattleUnit c)
	{
		return (double)((!(c is EnemyBattleUnit)) ? AdventureEncounterSlotType.MiniBoss : (c as EnemyBattleUnit).SlotSelection);
	}

	// Token: 0x0400275F RID: 10079
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TargetCandidateType <CandidateRange>k__BackingField;

	// Token: 0x04002760 RID: 10080
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CandidateOrderringMetric <OrderringMetric>k__BackingField;

	// Token: 0x04002761 RID: 10081
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OrderingType <OrderingType>k__BackingField;

	// Token: 0x04002762 RID: 10082
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfTargets>k__BackingField;

	// Token: 0x04002763 RID: 10083
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, ISpecialEffectDataLoad> <>f__am$cache0;

	// Token: 0x04002764 RID: 10084
	[CompilerGenerated]
	private static Func<ExtraTargetingData, int> <>f__am$cache1;

	// Token: 0x04002765 RID: 10085
	[CompilerGenerated]
	private static Func<AdditionaTargetEffect, bool> <>f__am$cache2;

	// Token: 0x04002766 RID: 10086
	[CompilerGenerated]
	private static Func<AdditionaTargetEffect, int?> <>f__am$cache3;

	// Token: 0x04002767 RID: 10087
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache4;

	// Token: 0x04002768 RID: 10088
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache5;

	// Token: 0x04002769 RID: 10089
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache6;

	// Token: 0x0400276A RID: 10090
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache7;

	// Token: 0x0400276B RID: 10091
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache8;

	// Token: 0x0400276C RID: 10092
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache9;

	// Token: 0x0400276D RID: 10093
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheA;

	// Token: 0x0400276E RID: 10094
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheB;

	// Token: 0x0400276F RID: 10095
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheC;

	// Token: 0x04002770 RID: 10096
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheD;

	// Token: 0x04002771 RID: 10097
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheE;

	// Token: 0x04002772 RID: 10098
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cacheF;

	// Token: 0x02000E4B RID: 3659
	[CompilerGenerated]
	private sealed class <GetTargets>c__AnonStorey0
	{
		// Token: 0x06005BEF RID: 23535 RVA: 0x001469D1 File Offset: 0x00144DD1
		public <GetTargets>c__AnonStorey0()
		{
		}

		// Token: 0x06005BF0 RID: 23536 RVA: 0x001469D9 File Offset: 0x00144DD9
		internal bool <>m__0(IBattleUnit s)
		{
			return s != this.caster;
		}

		// Token: 0x06005BF1 RID: 23537 RVA: 0x001469E7 File Offset: 0x00144DE7
		internal bool <>m__1(ExtraTargetingData d)
		{
			return d.CandidateTypes.Any((TargetCandidateType t) => t == this.$this.CandidateRange);
		}

		// Token: 0x06005BF2 RID: 23538 RVA: 0x00146A00 File Offset: 0x00144E00
		internal bool <>m__2(TargetCandidateType t)
		{
			return t == this.$this.CandidateRange;
		}

		// Token: 0x04004E12 RID: 19986
		internal IBattleUnit caster;

		// Token: 0x04004E13 RID: 19987
		internal TargetDefinition $this;
	}
}
