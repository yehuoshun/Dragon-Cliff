using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender;

namespace Core.SpecialEffect.RunePowerProcessors
{
	// Token: 0x02000941 RID: 2369
	public class DeathPreventProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06004160 RID: 16736 RVA: 0x001AD698 File Offset: 0x001ABA98
		public DeathPreventProcessor()
		{
		}

		// Token: 0x17000C41 RID: 3137
		// (get) Token: 0x06004161 RID: 16737 RVA: 0x001AD6CB File Offset: 0x001ABACB
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000C42 RID: 3138
		// (get) Token: 0x06004162 RID: 16738 RVA: 0x001AD6D3 File Offset: 0x001ABAD3
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06004163 RID: 16739 RVA: 0x001AD6DC File Offset: 0x001ABADC
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (effectCarrier.IsPlayer && specialEffectData is DeathPreventData && triggerUnit.IsPlayer && evtType == AdventureEventType.UnitPreKilled)
			{
				DeathPreventData data = specialEffectData as DeathPreventData;
				if (triggerUnit.HealthPoints <= 0.0 && data.CurrentReviveables > 0)
				{
					data.CurrentReviveables--;
					ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								IsDirectHeal = false,
								RawHeal = triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.3,
								HealType = OutputType.RealHeal
							}
						}, true)
					}, effectCarrier);
					IEnumerator enumerator = heal.Release().GetEnumerator();
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

		// Token: 0x040030EB RID: 12523
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.DeathPrevent;

		// Token: 0x040030EC RID: 12524
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};

		// Token: 0x02000FEC RID: 4076
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006745 RID: 26437 RVA: 0x001AD715 File Offset: 0x001ABB15
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x06006746 RID: 26438 RVA: 0x001AD720 File Offset: 0x001ABB20
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (!effectCarrier.IsPlayer || !(specialEffectData is DeathPreventData) || !triggerUnit.IsPlayer || evtType != AdventureEventType.UnitPreKilled)
					{
						goto IL_1BF;
					}
					data = (specialEffectData as DeathPreventData);
					if (triggerUnit.HealthPoints > 0.0 || data.CurrentReviveables <= 0)
					{
						goto IL_1BF;
					}
					data.CurrentReviveables--;
					heal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								IsDirectHeal = false,
								RawHeal = triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.3,
								HealType = OutputType.RealHeal
							}
						}, true)
					}, effectCarrier);
					enumerator = heal.Release().GetEnumerator();
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
				IL_1BF:
				this.$PC = -1;
				return false;
			}

			// Token: 0x170015AB RID: 5547
			// (get) Token: 0x06006747 RID: 26439 RVA: 0x001AD908 File Offset: 0x001ABD08
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170015AC RID: 5548
			// (get) Token: 0x06006748 RID: 26440 RVA: 0x001AD910 File Offset: 0x001ABD10
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006749 RID: 26441 RVA: 0x001AD918 File Offset: 0x001ABD18
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

			// Token: 0x0600674A RID: 26442 RVA: 0x001AD988 File Offset: 0x001ABD88
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600674B RID: 26443 RVA: 0x001AD98F File Offset: 0x001ABD8F
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600674C RID: 26444 RVA: 0x001AD998 File Offset: 0x001ABD98
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				DeathPreventProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DeathPreventProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x0400611F RID: 24863
			internal IBattleUnit effectCarrier;

			// Token: 0x04006120 RID: 24864
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x04006121 RID: 24865
			internal IBattleUnit triggerUnit;

			// Token: 0x04006122 RID: 24866
			internal AdventureEventType evtType;

			// Token: 0x04006123 RID: 24867
			internal DeathPreventData <data>__1;

			// Token: 0x04006124 RID: 24868
			internal ReleaseableHeal <heal>__2;

			// Token: 0x04006125 RID: 24869
			internal IEnumerator $locvar0;

			// Token: 0x04006126 RID: 24870
			internal object <_>__3;

			// Token: 0x04006127 RID: 24871
			internal IDisposable $locvar1;

			// Token: 0x04006128 RID: 24872
			internal object $current;

			// Token: 0x04006129 RID: 24873
			internal bool $disposing;

			// Token: 0x0400612A RID: 24874
			internal int $PC;
		}
	}
}
