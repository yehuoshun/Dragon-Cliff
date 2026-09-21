using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F6 RID: 2294
public class HealingStrengthEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004005 RID: 16389 RVA: 0x00198A7E File Offset: 0x00196E7E
	public HealingStrengthEffectProcess()
	{
	}

	// Token: 0x17000BAE RID: 2990
	// (get) Token: 0x06004006 RID: 16390 RVA: 0x00198A86 File Offset: 0x00196E86
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.HealingStrength;
		}
	}

	// Token: 0x17000BAF RID: 2991
	// (get) Token: 0x06004007 RID: 16391 RVA: 0x00198A8C File Offset: 0x00196E8C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.PostHealRelease
			};
		}
	}

	// Token: 0x06004008 RID: 16392 RVA: 0x00198AA8 File Offset: 0x00196EA8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.PostHealRelease && effectCarrier == triggerUnit && effectCarrier.GetUnitClassStyle().GetClassCategory() == ClassCategory.Healer && specialEffectData is HealingStrengthData && evtData is ReleaseableHeal)
		{
			HealingStrengthData data = specialEffectData as HealingStrengthData;
			List<IBattleUnit> targets = (from h in (evtData as ReleaseableHeal).BattleHeals
			select h.Target).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = data.BoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>(), "healingstrength", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x02000F7B RID: 3963
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006446 RID: 25670 RVA: 0x00198AE9 File Offset: 0x00196EE9
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006447 RID: 25671 RVA: 0x00198AF4 File Offset: 0x00196EF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.PostHealRelease || effectCarrier != triggerUnit || effectCarrier.GetUnitClassStyle().GetClassCategory() != ClassCategory.Healer || !(specialEffectData is HealingStrengthData) || !(evtData is ReleaseableHeal))
				{
					goto IL_226;
				}
				HealingStrengthData data = specialEffectData as HealingStrengthData;
				targets = (from h in (evtData as ReleaseableHeal).BattleHeals
				select h.Target).ToList<IBattleUnit>();
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			}
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
					Block_10:
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
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in UnitExtensions.GetAllResistances()
					select new AttributeModifier
					{
						AttributeType = r,
						ModificationType = ModificationType.Multiplication,
						Value = <AsActiveUnitProcess>c__AnonStorey.data.BoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}).ToList<AttributeModifier>(), "healingstrength", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_226:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014FF RID: 5375
		// (get) Token: 0x06006448 RID: 25672 RVA: 0x00198D68 File Offset: 0x00197168
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001500 RID: 5376
		// (get) Token: 0x06006449 RID: 25673 RVA: 0x00198D70 File Offset: 0x00197170
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600644A RID: 25674 RVA: 0x00198D78 File Offset: 0x00197178
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

		// Token: 0x0600644B RID: 25675 RVA: 0x00198E0C File Offset: 0x0019720C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600644C RID: 25676 RVA: 0x00198E13 File Offset: 0x00197213
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600644D RID: 25677 RVA: 0x00198E1C File Offset: 0x0019721C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealingStrengthEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new HealingStrengthEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600644E RID: 25678 RVA: 0x00198E80 File Offset: 0x00197280
		private static IBattleUnit <>m__0(BattleHeal h)
		{
			return h.Target;
		}

		// Token: 0x04005C11 RID: 23569
		internal AdventureEventType evtType;

		// Token: 0x04005C12 RID: 23570
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C13 RID: 23571
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C14 RID: 23572
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C15 RID: 23573
		internal object evtData;

		// Token: 0x04005C16 RID: 23574
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005C17 RID: 23575
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005C18 RID: 23576
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005C19 RID: 23577
		internal IEnumerator $locvar1;

		// Token: 0x04005C1A RID: 23578
		internal object <_>__3;

		// Token: 0x04005C1B RID: 23579
		internal IDisposable $locvar2;

		// Token: 0x04005C1C RID: 23580
		internal object $current;

		// Token: 0x04005C1D RID: 23581
		internal bool $disposing;

		// Token: 0x04005C1E RID: 23582
		internal int $PC;

		// Token: 0x04005C1F RID: 23583
		private HealingStrengthEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x04005C20 RID: 23584
		private static Func<BattleHeal, IBattleUnit> <>f__am$cache0;

		// Token: 0x02000F7C RID: 3964
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x0600644F RID: 25679 RVA: 0x00198E88 File Offset: 0x00197288
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006450 RID: 25680 RVA: 0x00198E90 File Offset: 0x00197290
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = this.data.BoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04005C21 RID: 23585
			internal HealingStrengthData data;

			// Token: 0x04005C22 RID: 23586
			internal HealingStrengthEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
