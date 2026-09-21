using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200090E RID: 2318
public class PossessionSpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600406F RID: 16495 RVA: 0x0019F04D File Offset: 0x0019D44D
	public PossessionSpecialEffectProcess()
	{
	}

	// Token: 0x17000BDC RID: 3036
	// (get) Token: 0x06004070 RID: 16496 RVA: 0x0019F055 File Offset: 0x0019D455
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Possession;
		}
	}

	// Token: 0x17000BDD RID: 3037
	// (get) Token: 0x06004071 RID: 16497 RVA: 0x0019F058 File Offset: 0x0019D458
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitRegularTurnStarts,
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage,
				AdventureEventType.DamageReleased,
				AdventureEventType.UnitCompletesTurn
			};
		}
	}

	// Token: 0x06004072 RID: 16498 RVA: 0x0019F094 File Offset: 0x0019D494
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (triggerUnit == effectCarrier)
		{
			PossessionData data = specialEffectData as PossessionData;
			if (data != null && data.TriggerEventType == evtType)
			{
				double chance = data.Chance;
				if ((double)UnityEngine.Random.value <= chance)
				{
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreatePossessedEffect(effectCarrier, data.Boosts, data.PossessionEffectSourceIdentityCode, data.LastingTurns), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06004073 RID: 16499 RVA: 0x0019F0CD File Offset: 0x0019D4CD
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06004074 RID: 16500 RVA: 0x0019F0D0 File Offset: 0x0019D4D0
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		if (resourceCategory.IsWeapon() || resourceCategory.IsArmor())
		{
			List<AttributePresentable> list = new List<AttributePresentable>
			{
				new AttributePresentable(100, AttributeType.Agility),
				new AttributePresentable(100, AttributeType.Resilience),
				new AttributePresentable(100, AttributeType.DamageReduction)
			};
			if (resourceCategory.IsCasterArmor() || resourceCategory.IsCasterWeapon())
			{
				list.Add(new AttributePresentable(100, AttributeType.Intelligience));
			}
			if (resourceCategory.IsMeleeArmor() || resourceCategory.IsMeleeWeapon())
			{
				list.Add(new AttributePresentable(100, AttributeType.Strength));
			}
			list.AddRange(from s in BattleUnitExtensions.ElementAttributeTypes
			select s.Value into a
			select new AttributePresentable(100, a));
			AttributePresentable attributePresentable = list.WeightedRandomSelect<AttributePresentable>();
			double num = SpecialEffectProcessBase.GetItemRootValue(itemTierLevel, itemType, attributePresentable.AttributeType);
			if (attributePresentable.AttributeType == AttributeType.DamageReduction)
			{
				num *= 3.0;
			}
			if (attributePresentable.AttributeType.IsDamageEffectiveness())
			{
				num *= 4.0;
			}
			num *= 0.7;
			num *= (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f));
			List<BoostSetting> boosts = new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = num,
					BoostAttribute = attributePresentable.AttributeType
				}
			};
			List<PossessionSpecialEffectProcess.TriggerPresentable> presences = new List<PossessionSpecialEffectProcess.TriggerPresentable>
			{
				new PossessionSpecialEffectProcess.TriggerPresentable
				{
					Presence = 100,
					Chance = 0.7,
					AdventureEventType = AdventureEventType.UnitReadyInBattle
				},
				new PossessionSpecialEffectProcess.TriggerPresentable
				{
					Presence = 100,
					Chance = 0.6,
					AdventureEventType = AdventureEventType.UnitRegularTurnStarts
				},
				new PossessionSpecialEffectProcess.TriggerPresentable
				{
					Presence = 100,
					Chance = 0.8,
					AdventureEventType = AdventureEventType.UnitCompletesTurn
				},
				new PossessionSpecialEffectProcess.TriggerPresentable
				{
					Presence = 100,
					Chance = 0.3,
					AdventureEventType = AdventureEventType.DamageReleased
				}
			};
			PossessionSpecialEffectProcess.TriggerPresentable triggerPresentable = presences.WeightedRandomSelect<PossessionSpecialEffectProcess.TriggerPresentable>();
			return new List<ISpecialEffectDataLoad>
			{
				new PossessionData
				{
					Chance = triggerPresentable.Chance,
					TriggerEventType = triggerPresentable.AdventureEventType,
					LastingTurns = 2,
					PossessionEffectSourceIdentityCode = Guid.NewGuid().ToString() + "-possession",
					Boosts = boosts,
					IsStarEf = new bool?(false)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004075 RID: 16501 RVA: 0x0019F3E5 File Offset: 0x0019D7E5
	[CompilerGenerated]
	private static AttributeType <GenerateRandomEffect>m__0(KeyValuePair<OutputType, AttributeType> s)
	{
		return s.Value;
	}

	// Token: 0x06004076 RID: 16502 RVA: 0x0019F3EE File Offset: 0x0019D7EE
	[CompilerGenerated]
	private static AttributePresentable <GenerateRandomEffect>m__1(AttributeType a)
	{
		return new AttributePresentable(100, a);
	}

	// Token: 0x04002FA3 RID: 12195
	[CompilerGenerated]
	private static Func<KeyValuePair<OutputType, AttributeType>, AttributeType> <>f__am$cache0;

	// Token: 0x04002FA4 RID: 12196
	[CompilerGenerated]
	private static Func<AttributeType, AttributePresentable> <>f__am$cache1;

	// Token: 0x0200090F RID: 2319
	private class TriggerPresentable : IPresentable
	{
		// Token: 0x06004077 RID: 16503 RVA: 0x0019F3F8 File Offset: 0x0019D7F8
		public TriggerPresentable()
		{
		}

		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x06004078 RID: 16504 RVA: 0x0019F400 File Offset: 0x0019D800
		// (set) Token: 0x06004079 RID: 16505 RVA: 0x0019F408 File Offset: 0x0019D808
		public AdventureEventType AdventureEventType
		{
			[CompilerGenerated]
			get
			{
				return this.<AdventureEventType>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<AdventureEventType>k__BackingField = value;
			}
		}

		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x0600407A RID: 16506 RVA: 0x0019F411 File Offset: 0x0019D811
		// (set) Token: 0x0600407B RID: 16507 RVA: 0x0019F419 File Offset: 0x0019D819
		public double Chance
		{
			[CompilerGenerated]
			get
			{
				return this.<Chance>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Chance>k__BackingField = value;
			}
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x0600407C RID: 16508 RVA: 0x0019F422 File Offset: 0x0019D822
		// (set) Token: 0x0600407D RID: 16509 RVA: 0x0019F42A File Offset: 0x0019D82A
		public int Presence
		{
			[CompilerGenerated]
			get
			{
				return this.<Presence>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Presence>k__BackingField = value;
			}
		}

		// Token: 0x0600407E RID: 16510 RVA: 0x0019F433 File Offset: 0x0019D833
		public int GetPresence()
		{
			return this.Presence;
		}

		// Token: 0x04002FA5 RID: 12197
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AdventureEventType <AdventureEventType>k__BackingField;

		// Token: 0x04002FA6 RID: 12198
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double <Chance>k__BackingField;

		// Token: 0x04002FA7 RID: 12199
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int <Presence>k__BackingField;
	}

	// Token: 0x02000F9B RID: 3995
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006535 RID: 25909 RVA: 0x0019F43B File Offset: 0x0019D83B
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006536 RID: 25910 RVA: 0x0019F444 File Offset: 0x0019D844
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (triggerUnit != effectCarrier)
				{
					goto IL_150;
				}
				data = (specialEffectData as PossessionData);
				if (data == null || data.TriggerEventType != evtType)
				{
					goto IL_150;
				}
				chance = data.Chance;
				if ((double)UnityEngine.Random.value > chance)
				{
					goto IL_150;
				}
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreatePossessedEffect(effectCarrier, data.Boosts, data.PossessionEffectSourceIdentityCode, data.LastingTurns), false).GetEnumerator();
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
			IL_150:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001535 RID: 5429
		// (get) Token: 0x06006537 RID: 25911 RVA: 0x0019F5BC File Offset: 0x0019D9BC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001536 RID: 5430
		// (get) Token: 0x06006538 RID: 25912 RVA: 0x0019F5C4 File Offset: 0x0019D9C4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006539 RID: 25913 RVA: 0x0019F5CC File Offset: 0x0019D9CC
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

		// Token: 0x0600653A RID: 25914 RVA: 0x0019F63C File Offset: 0x0019DA3C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600653B RID: 25915 RVA: 0x0019F643 File Offset: 0x0019DA43
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600653C RID: 25916 RVA: 0x0019F64C File Offset: 0x0019DA4C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PossessionSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new PossessionSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005DA0 RID: 23968
		internal IBattleUnit triggerUnit;

		// Token: 0x04005DA1 RID: 23969
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DA2 RID: 23970
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DA3 RID: 23971
		internal PossessionData <data>__1;

		// Token: 0x04005DA4 RID: 23972
		internal AdventureEventType evtType;

		// Token: 0x04005DA5 RID: 23973
		internal double <chance>__2;

		// Token: 0x04005DA6 RID: 23974
		internal IEnumerator $locvar0;

		// Token: 0x04005DA7 RID: 23975
		internal object <_>__3;

		// Token: 0x04005DA8 RID: 23976
		internal IDisposable $locvar1;

		// Token: 0x04005DA9 RID: 23977
		internal object $current;

		// Token: 0x04005DAA RID: 23978
		internal bool $disposing;

		// Token: 0x04005DAB RID: 23979
		internal int $PC;
	}
}
