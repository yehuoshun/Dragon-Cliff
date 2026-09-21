using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006B8 RID: 1720
public class ArmorOfWind : ActiveSkillLogicBase
{
	// Token: 0x06002DA9 RID: 11689 RVA: 0x0012FE24 File Offset: 0x0012E224
	public ArmorOfWind()
	{
	}

	// Token: 0x06002DAA RID: 11690 RVA: 0x0012FE48 File Offset: 0x0012E248
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ArmorOfWindExtraHitTalent(SkillType.ArmorOfWind, 1),
			new ArmorOfWindBoostTalent(SkillType.ArmorOfWind, 2),
			new ArmorOfWindBoostTalent(SkillType.ArmorOfWind, 3)
		};
	}

	// Token: 0x170005CA RID: 1482
	// (get) Token: 0x06002DAB RID: 11691 RVA: 0x0012FE8F File Offset: 0x0012E28F
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005CB RID: 1483
	// (get) Token: 0x06002DAC RID: 11692 RVA: 0x0012FE97 File Offset: 0x0012E297
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005CC RID: 1484
	// (get) Token: 0x06002DAD RID: 11693 RVA: 0x0012FE9F File Offset: 0x0012E29F
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005CD RID: 1485
	// (get) Token: 0x06002DAE RID: 11694 RVA: 0x0012FEA7 File Offset: 0x0012E2A7
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002DAF RID: 11695 RVA: 0x0012FEAF File Offset: 0x0012E2AF
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002DB0 RID: 11696 RVA: 0x0012FEB6 File Offset: 0x0012E2B6
	public override double GetGaugeCost(Skill skill)
	{
		return 60.0;
	}

	// Token: 0x06002DB1 RID: 11697 RVA: 0x0012FEC1 File Offset: 0x0012E2C1
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002DB2 RID: 11698 RVA: 0x0012FECD File Offset: 0x0012E2CD
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002DB3 RID: 11699 RVA: 0x0012FED5 File Offset: 0x0012E2D5
	private double PassiveChance(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002DB4 RID: 11700 RVA: 0x0012FEF4 File Offset: 0x0012E2F4
	private int NumberOfShields(Skill skill)
	{
		return skill.Level;
	}

	// Token: 0x06002DB5 RID: 11701 RVA: 0x0012FEFC File Offset: 0x0012E2FC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.NumberOfActiveShields, this.NumberOfShields(skill).ToString());
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002DB6 RID: 11702 RVA: 0x0012FF5C File Offset: 0x0012E35C
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		foreach (IBattleUnit unit in strategy.Selections)
		{
			int i = 0;
			for (;;)
			{
				if (i >= this.NumberOfShields(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<ArmorOfWindNumberEnhancementData>().Sum((ArmorOfWindNumberEnhancementData s) => s.Extra))
				{
					break;
				}
				IEnumerator enumerator2 = unit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), skill, true), false).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				i++;
			}
		}
		yield break;
	}

	// Token: 0x06002DB7 RID: 11703 RVA: 0x0012FF90 File Offset: 0x0012E390
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002DB8 RID: 11704 RVA: 0x0012FFAC File Offset: 0x0012E3AC
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && eventTriggerUnit == skillOwner)
		{
			List<IBattleUnit> friendlyUnits = eventTriggerUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			if ((double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill) && friendlyUnits.Any<IBattleUnit>())
			{
				IBattleUnit selected = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
				IEnumerator enumerator = selected.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), processingSkill, true), false).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object _ = enumerator.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040026DC RID: 9948
	private SkillCategory _skillCategory = SkillCategory.Defensive;

	// Token: 0x040026DD RID: 9949
	private OutputType _skillOutputType;

	// Token: 0x040026DE RID: 9950
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x040026DF RID: 9951
	private SkillType _skillType = SkillType.ArmorOfWind;

	// Token: 0x02000DF0 RID: 3568
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005980 RID: 22912 RVA: 0x0012FFEC File Offset: 0x0012E3EC
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005981 RID: 22913 RVA: 0x0012FFF4 File Offset: 0x0012E3F4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_4:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
							this.$current = _;
							if (!this.$disposing)
							{
								this.$PC = 1;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					i++;
					break;
				default:
					goto IL_17F;
				}
				IL_126:
				if (i < base.NumberOfShields(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<ArmorOfWindNumberEnhancementData>().Sum((ArmorOfWindNumberEnhancementData s) => s.Extra))
				{
					enumerator2 = unit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), skill, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				IL_17F:
				if (enumerator.MoveNext())
				{
					unit = enumerator.Current;
					i = 0;
					goto IL_126;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012A8 RID: 4776
		// (get) Token: 0x06005982 RID: 22914 RVA: 0x001301EC File Offset: 0x0012E5EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012A9 RID: 4777
		// (get) Token: 0x06005983 RID: 22915 RVA: 0x001301F4 File Offset: 0x0012E5F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005984 RID: 22916 RVA: 0x001301FC File Offset: 0x0012E5FC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005985 RID: 22917 RVA: 0x00130290 File Offset: 0x0012E690
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005986 RID: 22918 RVA: 0x00130297 File Offset: 0x0012E697
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005987 RID: 22919 RVA: 0x001302A0 File Offset: 0x0012E6A0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ArmorOfWind.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new ArmorOfWind.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005988 RID: 22920 RVA: 0x001302EC File Offset: 0x0012E6EC
		private static int <>m__0(ArmorOfWindNumberEnhancementData s)
		{
			return s.Extra;
		}

		// Token: 0x040049AA RID: 18858
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x040049AB RID: 18859
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040049AC RID: 18860
		internal IBattleUnit <unit>__1;

		// Token: 0x040049AD RID: 18861
		internal int <i>__2;

		// Token: 0x040049AE RID: 18862
		internal AdventureUnitSkill skill;

		// Token: 0x040049AF RID: 18863
		internal IEnumerator $locvar1;

		// Token: 0x040049B0 RID: 18864
		internal object <_>__3;

		// Token: 0x040049B1 RID: 18865
		internal IDisposable $locvar2;

		// Token: 0x040049B2 RID: 18866
		internal ArmorOfWind $this;

		// Token: 0x040049B3 RID: 18867
		internal object $current;

		// Token: 0x040049B4 RID: 18868
		internal bool $disposing;

		// Token: 0x040049B5 RID: 18869
		internal int $PC;

		// Token: 0x040049B6 RID: 18870
		private static Func<ArmorOfWindNumberEnhancementData, int> <>f__am$cache0;
	}

	// Token: 0x02000DF1 RID: 3569
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005989 RID: 22921 RVA: 0x001302F4 File Offset: 0x0012E6F4
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x0600598A RID: 22922 RVA: 0x001302FC File Offset: 0x0012E6FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || eventTriggerUnit != skillOwner)
				{
					goto IL_153;
				}
				friendlyUnits = eventTriggerUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				if ((double)UnityEngine.Random.value > base.PassiveChance(processingSkill.Skill) || !friendlyUnits.Any<IBattleUnit>())
				{
					goto IL_153;
				}
				selected = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
				enumerator = selected.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), processingSkill, true), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_153:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012AA RID: 4778
		// (get) Token: 0x0600598B RID: 22923 RVA: 0x00130478 File Offset: 0x0012E878
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012AB RID: 4779
		// (get) Token: 0x0600598C RID: 22924 RVA: 0x00130480 File Offset: 0x0012E880
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600598D RID: 22925 RVA: 0x00130488 File Offset: 0x0012E888
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600598E RID: 22926 RVA: 0x001304F8 File Offset: 0x0012E8F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600598F RID: 22927 RVA: 0x001304FF File Offset: 0x0012E8FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x00130508 File Offset: 0x0012E908
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ArmorOfWind.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new ArmorOfWind.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x040049B7 RID: 18871
		internal AdventureEventType eventType;

		// Token: 0x040049B8 RID: 18872
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040049B9 RID: 18873
		internal IBattleUnit skillOwner;

		// Token: 0x040049BA RID: 18874
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x040049BB RID: 18875
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040049BC RID: 18876
		internal IBattleUnit <selected>__2;

		// Token: 0x040049BD RID: 18877
		internal IEnumerator $locvar0;

		// Token: 0x040049BE RID: 18878
		internal object <_>__3;

		// Token: 0x040049BF RID: 18879
		internal IDisposable $locvar1;

		// Token: 0x040049C0 RID: 18880
		internal ArmorOfWind $this;

		// Token: 0x040049C1 RID: 18881
		internal object $current;

		// Token: 0x040049C2 RID: 18882
		internal bool $disposing;

		// Token: 0x040049C3 RID: 18883
		internal int $PC;
	}
}
