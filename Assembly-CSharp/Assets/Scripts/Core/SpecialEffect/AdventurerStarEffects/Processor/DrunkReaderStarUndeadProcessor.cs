using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x0200079F RID: 1951
	public class DrunkReaderStarUndeadProcessor : SpecialEffectProcessBase
	{
		// Token: 0x0600395C RID: 14684 RVA: 0x00173DB0 File Offset: 0x001721B0
		public DrunkReaderStarUndeadProcessor()
		{
		}

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x0600395D RID: 14685 RVA: 0x00173DEB File Offset: 0x001721EB
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x0600395E RID: 14686 RVA: 0x00173DF3 File Offset: 0x001721F3
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x0600395F RID: 14687 RVA: 0x00173DFC File Offset: 0x001721FC
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit)
			{
				(specialEffectData as DrunkReaderStarUndeadData).IsInTrigger = false;
			}
			if (evtType == AdventureEventType.UnitPreKilledFinal && triggerUnit == effectCarrier && specialEffectData is DrunkReaderStarUndeadData && triggerUnit.HealthPoints <= 0.0)
			{
				DrunkReaderStarUndeadData data = specialEffectData as DrunkReaderStarUndeadData;
				if (!data.IsInTrigger && GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.Money) >= (double)data.Cost && (double)UnityEngine.Random.value <= data.Chance)
				{
					data.IsInTrigger = true;
					ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								HealType = OutputType.Heal,
								IsDirectHeal = false,
								RawHeal = data.RevivieRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill)
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
					GameWorld.instance.PlayerProfile.SpendMoney((double)data.Cost);
					data.IsInTrigger = false;
				}
			}
			yield break;
		}

		// Token: 0x04002C73 RID: 11379
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.DrunkReaderStarUndead;

		// Token: 0x04002C74 RID: 11380
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilledFinal,
			AdventureEventType.UnitReadyInBattle
		};

		// Token: 0x02000EEB RID: 3819
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006058 RID: 24664 RVA: 0x00173E35 File Offset: 0x00172235
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x06006059 RID: 24665 RVA: 0x00173E40 File Offset: 0x00172240
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit)
					{
						(specialEffectData as DrunkReaderStarUndeadData).IsInTrigger = false;
					}
					if (evtType != AdventureEventType.UnitPreKilledFinal || triggerUnit != effectCarrier || !(specialEffectData is DrunkReaderStarUndeadData) || triggerUnit.HealthPoints > 0.0)
					{
						goto IL_23B;
					}
					data = (specialEffectData as DrunkReaderStarUndeadData);
					if (data.IsInTrigger || GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.Money) < (double)data.Cost || (double)UnityEngine.Random.value > data.Chance)
					{
						goto IL_23B;
					}
					data.IsInTrigger = true;
					heal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								HealType = OutputType.Heal,
								IsDirectHeal = false,
								RawHeal = data.RevivieRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill)
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
				GameWorld.instance.PlayerProfile.SpendMoney((double)data.Cost);
				data.IsInTrigger = false;
				IL_23B:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001426 RID: 5158
			// (get) Token: 0x0600605A RID: 24666 RVA: 0x001740A4 File Offset: 0x001724A4
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001427 RID: 5159
			// (get) Token: 0x0600605B RID: 24667 RVA: 0x001740AC File Offset: 0x001724AC
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600605C RID: 24668 RVA: 0x001740B4 File Offset: 0x001724B4
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

			// Token: 0x0600605D RID: 24669 RVA: 0x00174124 File Offset: 0x00172524
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600605E RID: 24670 RVA: 0x0017412B File Offset: 0x0017252B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600605F RID: 24671 RVA: 0x00174134 File Offset: 0x00172534
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				DrunkReaderStarUndeadProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DrunkReaderStarUndeadProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x04005571 RID: 21873
			internal AdventureEventType evtType;

			// Token: 0x04005572 RID: 21874
			internal IBattleUnit effectCarrier;

			// Token: 0x04005573 RID: 21875
			internal IBattleUnit triggerUnit;

			// Token: 0x04005574 RID: 21876
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x04005575 RID: 21877
			internal DrunkReaderStarUndeadData <data>__1;

			// Token: 0x04005576 RID: 21878
			internal ReleaseableHeal <heal>__2;

			// Token: 0x04005577 RID: 21879
			internal IEnumerator $locvar0;

			// Token: 0x04005578 RID: 21880
			internal object <_>__3;

			// Token: 0x04005579 RID: 21881
			internal IDisposable $locvar1;

			// Token: 0x0400557A RID: 21882
			internal object $current;

			// Token: 0x0400557B RID: 21883
			internal bool $disposing;

			// Token: 0x0400557C RID: 21884
			internal int $PC;
		}
	}
}
