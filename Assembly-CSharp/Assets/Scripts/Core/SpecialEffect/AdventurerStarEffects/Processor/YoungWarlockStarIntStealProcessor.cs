using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A7 RID: 1959
	public class YoungWarlockStarIntStealProcessor : SpecialEffectProcessBase
	{
		// Token: 0x0600397E RID: 14718 RVA: 0x00175F68 File Offset: 0x00174368
		public YoungWarlockStarIntStealProcessor()
		{
		}

		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x0600397F RID: 14719 RVA: 0x00175F9B File Offset: 0x0017439B
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06003980 RID: 14720 RVA: 0x00175FA3 File Offset: 0x001743A3
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003981 RID: 14721 RVA: 0x00175FAC File Offset: 0x001743AC
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitPreKilled && effectCarrier.GetUnitType() == UnitClass.YoungWarlock && evtData is BattleDamage)
			{
				BattleDamage damage = evtData as BattleDamage;
				if (damage.Dealer == effectCarrier)
				{
					YoungWarlockStarIntStealData data = specialEffectData as YoungWarlockStarIntStealData;
					double boost = damage.Target.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * data.Rate;
					string key = "youngwarlockstarunique";
					if (boost > 0.0 && (double)UnityEngine.Random.value <= data.Chance)
					{
						var currentBuffs = (from e in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
						where e.EffectSourceIdentityCode == key
						select e into b
						select new
						{
							buff = b,
							value = b._modifiers.First<AttributeModifier>().Value
						} into f
						orderby f.value
						select f).ToList();
						bool canApply = true;
						if (currentBuffs.Count >= 10)
						{
							if (currentBuffs.First().value < boost)
							{
								IEnumerator enumerator = effectCarrier.LooseSkillEffect(currentBuffs.First().buff, EffectWearsOffType.Duplicate).GetEnumerator();
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
							else
							{
								canApply = false;
							}
						}
						if (canApply)
						{
							IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeModifierType = AttributeModifierType.Skill,
									AttributeType = AttributeType.Intelligience,
									Key = string.Empty,
									ModificationType = ModificationType.Addition,
									Value = boost
								}
							}, key, new int?(10), null, null, false, false, true), false).GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									object _2 = enumerator2.Current;
									yield return _2;
								}
							}
							finally
							{
								IDisposable disposable2;
								if ((disposable2 = (enumerator2 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04002C83 RID: 11395
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.YoungWarlockStarIntSteal;

		// Token: 0x04002C84 RID: 11396
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};

		// Token: 0x02000EF5 RID: 3829
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600609A RID: 24730 RVA: 0x00175FE6 File Offset: 0x001743E6
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x0600609B RID: 24731 RVA: 0x00175FF0 File Offset: 0x001743F0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
				{
					if (evtType != AdventureEventType.UnitPreKilled || effectCarrier.GetUnitType() != UnitClass.YoungWarlock || !(evtData is BattleDamage))
					{
						goto IL_389;
					}
					damage = (evtData as BattleDamage);
					if (damage.Dealer != effectCarrier)
					{
						goto IL_389;
					}
					data = (specialEffectData as YoungWarlockStarIntStealData);
					boost = damage.Target.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * data.Rate;
					string key = "youngwarlockstarunique";
					if (boost <= 0.0 || (double)UnityEngine.Random.value > data.Chance)
					{
						goto IL_389;
					}
					currentBuffs = (from e in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
					where e.EffectSourceIdentityCode == key
					select e into b
					select new
					{
						buff = b,
						value = b._modifiers.First<AttributeModifier>().Value
					} into f
					orderby f.value
					select f).ToList();
					canApply = true;
					if (currentBuffs.Count < 10)
					{
						goto IL_267;
					}
					if (currentBuffs.First().value >= boost)
					{
						canApply = false;
						goto IL_267;
					}
					enumerator = effectCarrier.LooseSkillEffect(currentBuffs.First().buff, EffectWearsOffType.Duplicate).GetEnumerator();
					num = 4294967293u;
					break;
				}
				case 1u:
					break;
				case 2u:
					Block_14:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_2 = enumerator2.Current;
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
							if ((disposable2 = (enumerator2 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					goto IL_389;
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
				IL_267:
				if (canApply)
				{
					enumerator2 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.Intelligience,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = boost
						}
					}, <AsActiveUnitProcess>c__AnonStorey.key, new int?(10), null, null, false, false, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
				IL_389:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001436 RID: 5174
			// (get) Token: 0x0600609C RID: 24732 RVA: 0x001763AC File Offset: 0x001747AC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001437 RID: 5175
			// (get) Token: 0x0600609D RID: 24733 RVA: 0x001763B4 File Offset: 0x001747B4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600609E RID: 24734 RVA: 0x001763BC File Offset: 0x001747BC
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
				case 2u:
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x0600609F RID: 24735 RVA: 0x0017646C File Offset: 0x0017486C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060A0 RID: 24736 RVA: 0x00176473 File Offset: 0x00174873
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060A1 RID: 24737 RVA: 0x0017647C File Offset: 0x0017487C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				YoungWarlockStarIntStealProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new YoungWarlockStarIntStealProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.evtData = evtData;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x060060A2 RID: 24738 RVA: 0x001764D4 File Offset: 0x001748D4
			private static <>__AnonType5<AttributeModificationEffect, double> <>m__0(AttributeModificationEffect b)
			{
				return new
				{
					buff = b,
					value = b._modifiers.First<AttributeModifier>().Value
				};
			}

			// Token: 0x060060A3 RID: 24739 RVA: 0x001764EC File Offset: 0x001748EC
			private static double <>m__1(<>__AnonType5<AttributeModificationEffect, double> f)
			{
				return f.value;
			}

			// Token: 0x040055E4 RID: 21988
			internal AdventureEventType evtType;

			// Token: 0x040055E5 RID: 21989
			internal IBattleUnit effectCarrier;

			// Token: 0x040055E6 RID: 21990
			internal object evtData;

			// Token: 0x040055E7 RID: 21991
			internal BattleDamage <damage>__1;

			// Token: 0x040055E8 RID: 21992
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x040055E9 RID: 21993
			internal YoungWarlockStarIntStealData <data>__2;

			// Token: 0x040055EA RID: 21994
			internal double <boost>__2;

			// Token: 0x040055EB RID: 21995
			internal List<<>__AnonType5<AttributeModificationEffect, double>> <currentBuffs>__3;

			// Token: 0x040055EC RID: 21996
			internal bool <canApply>__3;

			// Token: 0x040055ED RID: 21997
			internal IEnumerator $locvar0;

			// Token: 0x040055EE RID: 21998
			internal object <_>__4;

			// Token: 0x040055EF RID: 21999
			internal IDisposable $locvar1;

			// Token: 0x040055F0 RID: 22000
			internal IEnumerator $locvar2;

			// Token: 0x040055F1 RID: 22001
			internal object <_>__5;

			// Token: 0x040055F2 RID: 22002
			internal IDisposable $locvar3;

			// Token: 0x040055F3 RID: 22003
			internal object $current;

			// Token: 0x040055F4 RID: 22004
			internal bool $disposing;

			// Token: 0x040055F5 RID: 22005
			internal int $PC;

			// Token: 0x040055F6 RID: 22006
			private YoungWarlockStarIntStealProcessor.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar4;

			// Token: 0x040055F7 RID: 22007
			private static Func<AttributeModificationEffect, <>__AnonType5<AttributeModificationEffect, double>> <>f__am$cache0;

			// Token: 0x040055F8 RID: 22008
			private static Func<<>__AnonType5<AttributeModificationEffect, double>, double> <>f__am$cache1;

			// Token: 0x02000EF6 RID: 3830
			private sealed class <AsActiveUnitProcess>c__AnonStorey1
			{
				// Token: 0x060060A4 RID: 24740 RVA: 0x001764F4 File Offset: 0x001748F4
				public <AsActiveUnitProcess>c__AnonStorey1()
				{
				}

				// Token: 0x060060A5 RID: 24741 RVA: 0x001764FC File Offset: 0x001748FC
				internal bool <>m__0(AttributeModificationEffect e)
				{
					return e.EffectSourceIdentityCode == this.key;
				}

				// Token: 0x040055F9 RID: 22009
				internal string key;

				// Token: 0x040055FA RID: 22010
				internal YoungWarlockStarIntStealProcessor.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
			}
		}
	}
}
