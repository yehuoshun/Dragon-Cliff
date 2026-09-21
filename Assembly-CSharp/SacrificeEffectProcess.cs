using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091D RID: 2333
public class SacrificeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040B3 RID: 16563 RVA: 0x001A2C87 File Offset: 0x001A1087
	public SacrificeEffectProcess()
	{
	}

	// Token: 0x17000BFB RID: 3067
	// (get) Token: 0x060040B4 RID: 16564 RVA: 0x001A2C8F File Offset: 0x001A108F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Sacrifice;
		}
	}

	// Token: 0x17000BFC RID: 3068
	// (get) Token: 0x060040B5 RID: 16565 RVA: 0x001A2C94 File Offset: 0x001A1094
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPreKilled,
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x060040B6 RID: 16566 RVA: 0x001A2CB8 File Offset: 0x001A10B8
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 50;
	}

	// Token: 0x060040B7 RID: 16567 RVA: 0x001A2CC0 File Offset: 0x001A10C0
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SacrificeEffectData
			{
				IsStarEf = new bool?(true),
				HealRate = 0.4,
				SacrificeRate = 0.2,
				MinimumSelfRate = 0.2
			}
		};
	}

	// Token: 0x060040B8 RID: 16568 RVA: 0x001A2D1C File Offset: 0x001A111C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit)
		{
			SacrificeEffectData sacrificeEffectData = specialEffectData as SacrificeEffectData;
			if (sacrificeEffectData != null)
			{
				sacrificeEffectData.InTrigger = false;
			}
		}
		if (evtType == AdventureEventType.UnitPreKilled && effectCarrier != triggerUnit && effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false).Any((IBattleUnit u) => u == triggerUnit) && triggerUnit.HealthPoints <= 0.0 && !triggerUnit.SpecialEffects.OfType<SacrificeEffectData>().Any<SacrificeEffectData>())
		{
			SacrificeEffectData data = specialEffectData as SacrificeEffectData;
			if (data != null && !data.InTrigger)
			{
				double currentRatio = effectCarrier.HealthPoints / effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				if (currentRatio > data.MinimumSelfRate)
				{
					data.InTrigger = true;
					double healRate = data.SacrificeRate;
					if (currentRatio - healRate < data.MinimumSelfRate)
					{
						healRate = currentRatio - data.MinimumSelfRate;
					}
					double totalHealvalue = healRate * data.HealRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
					ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = totalHealvalue,
								HealType = OutputType.RealHeal,
								IsDirectHeal = false
							}
						}, true)
					}, effectCarrier);
					IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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
					ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
					{
						new BattleDamage(effectCarrier, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								DamagePotionValue.CreateRawValuedDamageComponent(effectCarrier, effectCarrier, OutputType.RealDamage, healRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill))
							}, effectCarrier, effectCarrier, false, false)
						})
					}, effectCarrier);
					IEnumerator enumerator2 = releaseableDamage.Release().GetEnumerator();
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
					data.InTrigger = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x02000FB0 RID: 4016
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065B6 RID: 26038 RVA: 0x001A2D5C File Offset: 0x001A115C
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065B7 RID: 26039 RVA: 0x001A2D64 File Offset: 0x001A1164
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
					SacrificeEffectData sacrificeEffectData = specialEffectData as SacrificeEffectData;
					if (sacrificeEffectData != null)
					{
						sacrificeEffectData.InTrigger = false;
					}
				}
				if (evtType != AdventureEventType.UnitPreKilled || effectCarrier == triggerUnit || !effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false).Any((IBattleUnit u) => u == triggerUnit) || triggerUnit.HealthPoints > 0.0 || triggerUnit.SpecialEffects.OfType<SacrificeEffectData>().Any<SacrificeEffectData>())
				{
					goto IL_435;
				}
				data = (specialEffectData as SacrificeEffectData);
				if (data == null || data.InTrigger)
				{
					goto IL_435;
				}
				currentRatio = effectCarrier.HealthPoints / effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				if (currentRatio <= data.MinimumSelfRate)
				{
					goto IL_435;
				}
				data.InTrigger = true;
				healRate = data.SacrificeRate;
				if (currentRatio - healRate < data.MinimumSelfRate)
				{
					healRate = currentRatio - data.MinimumSelfRate;
				}
				totalHealvalue = healRate * data.HealRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHealvalue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_3A5;
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
			releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(effectCarrier, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(effectCarrier, effectCarrier, OutputType.RealDamage, healRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill))
					}, effectCarrier, effectCarrier, false, false)
				})
			}, effectCarrier);
			enumerator2 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_3A5:
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
			data.InTrigger = false;
			IL_435:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001551 RID: 5457
		// (get) Token: 0x060065B8 RID: 26040 RVA: 0x001A31CC File Offset: 0x001A15CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001552 RID: 5458
		// (get) Token: 0x060065B9 RID: 26041 RVA: 0x001A31D4 File Offset: 0x001A15D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065BA RID: 26042 RVA: 0x001A31DC File Offset: 0x001A15DC
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

		// Token: 0x060065BB RID: 26043 RVA: 0x001A328C File Offset: 0x001A168C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065BC RID: 26044 RVA: 0x001A3293 File Offset: 0x001A1693
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065BD RID: 26045 RVA: 0x001A329C File Offset: 0x001A169C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SacrificeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SacrificeEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E81 RID: 24193
		internal AdventureEventType evtType;

		// Token: 0x04005E82 RID: 24194
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E83 RID: 24195
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E84 RID: 24196
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E85 RID: 24197
		internal SacrificeEffectData <data>__1;

		// Token: 0x04005E86 RID: 24198
		internal double <currentRatio>__2;

		// Token: 0x04005E87 RID: 24199
		internal double <healRate>__3;

		// Token: 0x04005E88 RID: 24200
		internal double <totalHealvalue>__3;

		// Token: 0x04005E89 RID: 24201
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04005E8A RID: 24202
		internal IEnumerator $locvar0;

		// Token: 0x04005E8B RID: 24203
		internal object <_>__4;

		// Token: 0x04005E8C RID: 24204
		internal IDisposable $locvar1;

		// Token: 0x04005E8D RID: 24205
		internal ReleaseableDamage <releaseableDamage>__3;

		// Token: 0x04005E8E RID: 24206
		internal IEnumerator $locvar2;

		// Token: 0x04005E8F RID: 24207
		internal object <_>__5;

		// Token: 0x04005E90 RID: 24208
		internal IDisposable $locvar3;

		// Token: 0x04005E91 RID: 24209
		internal SacrificeEffectProcess $this;

		// Token: 0x04005E92 RID: 24210
		internal object $current;

		// Token: 0x04005E93 RID: 24211
		internal bool $disposing;

		// Token: 0x04005E94 RID: 24212
		internal int $PC;

		// Token: 0x04005E95 RID: 24213
		private SacrificeEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar4;

		// Token: 0x02000FB1 RID: 4017
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060065BE RID: 26046 RVA: 0x001A3300 File Offset: 0x001A1700
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060065BF RID: 26047 RVA: 0x001A3308 File Offset: 0x001A1708
			internal bool <>m__0(IBattleUnit u)
			{
				return u == this.triggerUnit;
			}

			// Token: 0x04005E96 RID: 24214
			internal IBattleUnit triggerUnit;

			// Token: 0x04005E97 RID: 24215
			internal SacrificeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
