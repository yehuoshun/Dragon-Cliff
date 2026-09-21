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
	// Token: 0x020007A1 RID: 1953
	public class IronSoilderStarHitBoostProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003964 RID: 14692 RVA: 0x001746D4 File Offset: 0x00172AD4
		public IronSoilderStarHitBoostProcessor()
		{
		}

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06003965 RID: 14693 RVA: 0x00174707 File Offset: 0x00172B07
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06003966 RID: 14694 RVA: 0x0017470F File Offset: 0x00172B0F
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003967 RID: 14695 RVA: 0x00174718 File Offset: 0x00172B18
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier.IsPlayer == triggerUnit.IsPlayer && specialEffectData is IronSoilderStarHitBoostData)
			{
				IronSoilderStarHitBoostData data = specialEffectData as IronSoilderStarHitBoostData;
				if ((double)UnityEngine.Random.value <= data.Chance)
				{
					IEnumerator enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Addition,
							Value = data.HitBoost,
							AttributeType = AttributeType.HitRateAdjustment,
							Key = string.Empty
						},
						new AttributeModifier
						{
							ModificationType = ModificationType.Addition,
							Value = data.DodgeBoost,
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.DodgeRateAdjustment,
							Key = string.Empty
						}
					}, "ironstarhitdodge", new int?(1), null, null, false, true, false), false).GetEnumerator();
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

		// Token: 0x04002C77 RID: 11383
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.IronSoilderStarHitBoost;

		// Token: 0x04002C78 RID: 11384
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};

		// Token: 0x02000EEE RID: 3822
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600606A RID: 24682 RVA: 0x00174751 File Offset: 0x00172B51
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x0600606B RID: 24683 RVA: 0x0017475C File Offset: 0x00172B5C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier.IsPlayer != triggerUnit.IsPlayer || !(specialEffectData is IronSoilderStarHitBoostData))
					{
						goto IL_1D8;
					}
					data = (specialEffectData as IronSoilderStarHitBoostData);
					if ((double)UnityEngine.Random.value > data.Chance)
					{
						goto IL_1D8;
					}
					enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Addition,
							Value = data.HitBoost,
							AttributeType = AttributeType.HitRateAdjustment,
							Key = string.Empty
						},
						new AttributeModifier
						{
							ModificationType = ModificationType.Addition,
							Value = data.DodgeBoost,
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.DodgeRateAdjustment,
							Key = string.Empty
						}
					}, "ironstarhitdodge", new int?(1), null, null, false, true, false), false).GetEnumerator();
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
				IL_1D8:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700142A RID: 5162
			// (get) Token: 0x0600606C RID: 24684 RVA: 0x0017495C File Offset: 0x00172D5C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700142B RID: 5163
			// (get) Token: 0x0600606D RID: 24685 RVA: 0x00174964 File Offset: 0x00172D64
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600606E RID: 24686 RVA: 0x0017496C File Offset: 0x00172D6C
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

			// Token: 0x0600606F RID: 24687 RVA: 0x001749DC File Offset: 0x00172DDC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006070 RID: 24688 RVA: 0x001749E3 File Offset: 0x00172DE3
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006071 RID: 24689 RVA: 0x001749EC File Offset: 0x00172DEC
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				IronSoilderStarHitBoostProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new IronSoilderStarHitBoostProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x04005590 RID: 21904
			internal AdventureEventType evtType;

			// Token: 0x04005591 RID: 21905
			internal IBattleUnit effectCarrier;

			// Token: 0x04005592 RID: 21906
			internal IBattleUnit triggerUnit;

			// Token: 0x04005593 RID: 21907
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x04005594 RID: 21908
			internal IronSoilderStarHitBoostData <data>__1;

			// Token: 0x04005595 RID: 21909
			internal IEnumerator $locvar0;

			// Token: 0x04005596 RID: 21910
			internal object <_>__2;

			// Token: 0x04005597 RID: 21911
			internal IDisposable $locvar1;

			// Token: 0x04005598 RID: 21912
			internal object $current;

			// Token: 0x04005599 RID: 21913
			internal bool $disposing;

			// Token: 0x0400559A RID: 21914
			internal int $PC;
		}
	}
}
