using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.Skills.SkillEffect;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A4 RID: 1956
	public class SoulThiefStarEffectBoostProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003970 RID: 14704 RVA: 0x0017559C File Offset: 0x0017399C
		public SoulThiefStarEffectBoostProcessor()
		{
		}

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06003971 RID: 14705 RVA: 0x001755CF File Offset: 0x001739CF
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06003972 RID: 14706 RVA: 0x001755D7 File Offset: 0x001739D7
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x001755E0 File Offset: 0x001739E0
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && effectCarrier.GetUnitType() == UnitClass.SoulThief && specialEffectData is SoulThiefStarEffectBoostData)
			{
				SoulThiefStarEffectBoostData data = specialEffectData as SoulThiefStarEffectBoostData;
				List<IBattleUnit> targets = effectCarrier.GetLiveEnemyTargets(false, false);
				foreach (IBattleUnit battleUnit in targets)
				{
					IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectResistanceRating,
							ModificationType = ModificationType.Multiplication,
							Value = -0.3,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "soulthiefauraunique", new int?(1), null, null, false, false), false).GetEnumerator();
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
				if ((double)UnityEngine.Random.value <= data.Chance)
				{
					IEnumerator enumerator3 = effectCarrier.ApplySkillEffect(new EmbracedMindEffect(effectCarrier, false, false, null, null, false), false).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _2 = enumerator3.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04002C7D RID: 11389
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.SoulThiefStarEffectBoost;

		// Token: 0x04002C7E RID: 11390
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};

		// Token: 0x02000EF2 RID: 3826
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006084 RID: 24708 RVA: 0x00175619 File Offset: 0x00173A19
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x06006085 RID: 24709 RVA: 0x00175624 File Offset: 0x00173A24
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || effectCarrier.GetUnitType() != UnitClass.SoulThief || !(specialEffectData is SoulThiefStarEffectBoostData))
					{
						goto IL_2D6;
					}
					data = (specialEffectData as SoulThiefStarEffectBoostData);
					targets = effectCarrier.GetLiveEnemyTargets(false, false);
					enumerator = targets.GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
					break;
				case 2u:
					goto IL_252;
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
						enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectResistanceRating,
								ModificationType = ModificationType.Multiplication,
								Value = -0.3,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "soulthiefauraunique", new int?(1), null, null, false, false), false).GetEnumerator();
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
				if ((double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_2D6;
				}
				enumerator3 = effectCarrier.ApplySkillEffect(new EmbracedMindEffect(effectCarrier, false, false, null, null, false), false).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_252:
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IL_2D6:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001430 RID: 5168
			// (get) Token: 0x06006086 RID: 24710 RVA: 0x00175960 File Offset: 0x00173D60
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001431 RID: 5169
			// (get) Token: 0x06006087 RID: 24711 RVA: 0x00175968 File Offset: 0x00173D68
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006088 RID: 24712 RVA: 0x00175970 File Offset: 0x00173D70
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
				case 2u:
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x06006089 RID: 24713 RVA: 0x00175A44 File Offset: 0x00173E44
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600608A RID: 24714 RVA: 0x00175A4B File Offset: 0x00173E4B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600608B RID: 24715 RVA: 0x00175A54 File Offset: 0x00173E54
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SoulThiefStarEffectBoostProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SoulThiefStarEffectBoostProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x040055C5 RID: 21957
			internal AdventureEventType evtType;

			// Token: 0x040055C6 RID: 21958
			internal IBattleUnit effectCarrier;

			// Token: 0x040055C7 RID: 21959
			internal IBattleUnit triggerUnit;

			// Token: 0x040055C8 RID: 21960
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x040055C9 RID: 21961
			internal SoulThiefStarEffectBoostData <data>__1;

			// Token: 0x040055CA RID: 21962
			internal List<IBattleUnit> <targets>__1;

			// Token: 0x040055CB RID: 21963
			internal List<IBattleUnit>.Enumerator $locvar0;

			// Token: 0x040055CC RID: 21964
			internal IBattleUnit <battleUnit>__2;

			// Token: 0x040055CD RID: 21965
			internal IEnumerator $locvar1;

			// Token: 0x040055CE RID: 21966
			internal object <_>__3;

			// Token: 0x040055CF RID: 21967
			internal IDisposable $locvar2;

			// Token: 0x040055D0 RID: 21968
			internal IEnumerator $locvar3;

			// Token: 0x040055D1 RID: 21969
			internal object <_>__4;

			// Token: 0x040055D2 RID: 21970
			internal IDisposable $locvar4;

			// Token: 0x040055D3 RID: 21971
			internal object $current;

			// Token: 0x040055D4 RID: 21972
			internal bool $disposing;

			// Token: 0x040055D5 RID: 21973
			internal int $PC;
		}
	}
}
