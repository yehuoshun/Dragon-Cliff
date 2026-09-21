using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000930 RID: 2352
public class SufferlessEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600410E RID: 16654 RVA: 0x001A6FCC File Offset: 0x001A53CC
	public SufferlessEffectProcess()
	{
	}

	// Token: 0x17000C1F RID: 3103
	// (get) Token: 0x0600410F RID: 16655 RVA: 0x001A6FDC File Offset: 0x001A53DC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C20 RID: 3104
	// (get) Token: 0x06004110 RID: 16656 RVA: 0x001A6FE4 File Offset: 0x001A53E4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.FirstEncounterStarted,
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x06004111 RID: 16657 RVA: 0x001A7008 File Offset: 0x001A5408
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 55;
	}

	// Token: 0x06004112 RID: 16658 RVA: 0x001A7010 File Offset: 0x001A5410
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SufferlessData
			{
				IsStarEf = new bool?(true),
				RecoveryRate = 0.03,
				NumberOfMaxTriggersPerBattle = 1,
				ImmuneTurns = 1
			}
		};
	}

	// Token: 0x06004113 RID: 16659 RVA: 0x001A705C File Offset: 0x001A545C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.FirstEncounterStarted & triggerUnit == effectCarrier & specialEffectData is SufferlessData)
		{
			(specialEffectData as SufferlessData).Counter = 0;
		}
		if (evtType == AdventureEventType.UnitPreKilled && specialEffectData is SufferlessData && triggerUnit == effectCarrier && triggerUnit.HealthPoints <= 0.0)
		{
			SufferlessData data = specialEffectData as SufferlessData;
			if (data.Counter < data.NumberOfMaxTriggersPerBattle)
			{
				data.Counter++;
				double heal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate;
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(DamageImmuneEffect.SingleSourceIdentityCode, new int?(1), null, effectCarrier, new List<OutputType>
				{
					OutputType.Fire,
					OutputType.Physical,
					OutputType.Ice,
					OutputType.Shadow,
					OutputType.Poison,
					OutputType.Divine,
					OutputType.Lightening,
					OutputType.RealDamage
				}, false, 1), false).GetEnumerator();
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
				IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(new EffectImmuneEffect(effectCarrier, new int?(1), null, EffectImmuneEffect.SingleSourceIdentityCode, 1.0), false).GetEnumerator();
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
				IEnumerator enumerator3 = releaseableHeal.Release().GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _3 = enumerator3.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040030DE RID: 12510
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Sufferless;

	// Token: 0x02000FCE RID: 4046
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006685 RID: 26245 RVA: 0x001A7095 File Offset: 0x001A5495
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006686 RID: 26246 RVA: 0x001A70A0 File Offset: 0x001A54A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.FirstEncounterStarted & triggerUnit == effectCarrier & specialEffectData is SufferlessData)
				{
					(specialEffectData as SufferlessData).Counter = 0;
				}
				if (evtType != AdventureEventType.UnitPreKilled || !(specialEffectData is SufferlessData) || triggerUnit != effectCarrier || triggerUnit.HealthPoints > 0.0)
				{
					goto IL_3DE;
				}
				data = (specialEffectData as SufferlessData);
				if (data.Counter >= data.NumberOfMaxTriggersPerBattle)
				{
					goto IL_3DE;
				}
				data.Counter++;
				heal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate;
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(DamageImmuneEffect.SingleSourceIdentityCode, new int?(1), null, effectCarrier, new List<OutputType>
				{
					OutputType.Fire,
					OutputType.Physical,
					OutputType.Ice,
					OutputType.Shadow,
					OutputType.Poison,
					OutputType.Divine,
					OutputType.Lightening,
					OutputType.RealDamage
				}, false, 1), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2BD;
			case 3u:
				goto IL_35A;
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
			enumerator2 = effectCarrier.ApplySkillEffect(new EffectImmuneEffect(effectCarrier, new int?(1), null, EffectImmuneEffect.SingleSourceIdentityCode, 1.0), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2BD:
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
			enumerator3 = releaseableHeal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_35A:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_3DE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001581 RID: 5505
		// (get) Token: 0x06006687 RID: 26247 RVA: 0x001A74C0 File Offset: 0x001A58C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001582 RID: 5506
		// (get) Token: 0x06006688 RID: 26248 RVA: 0x001A74C8 File Offset: 0x001A58C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006689 RID: 26249 RVA: 0x001A74D0 File Offset: 0x001A58D0
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600668A RID: 26250 RVA: 0x001A75C0 File Offset: 0x001A59C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600668B RID: 26251 RVA: 0x001A75C7 File Offset: 0x001A59C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600668C RID: 26252 RVA: 0x001A75D0 File Offset: 0x001A59D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SufferlessEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SufferlessEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F99 RID: 24473
		internal AdventureEventType evtType;

		// Token: 0x04005F9A RID: 24474
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F9B RID: 24475
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F9C RID: 24476
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F9D RID: 24477
		internal SufferlessData <data>__1;

		// Token: 0x04005F9E RID: 24478
		internal double <heal>__2;

		// Token: 0x04005F9F RID: 24479
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04005FA0 RID: 24480
		internal IEnumerator $locvar0;

		// Token: 0x04005FA1 RID: 24481
		internal object <_>__3;

		// Token: 0x04005FA2 RID: 24482
		internal IDisposable $locvar1;

		// Token: 0x04005FA3 RID: 24483
		internal IEnumerator $locvar2;

		// Token: 0x04005FA4 RID: 24484
		internal object <_>__4;

		// Token: 0x04005FA5 RID: 24485
		internal IDisposable $locvar3;

		// Token: 0x04005FA6 RID: 24486
		internal IEnumerator $locvar4;

		// Token: 0x04005FA7 RID: 24487
		internal object <_>__5;

		// Token: 0x04005FA8 RID: 24488
		internal IDisposable $locvar5;

		// Token: 0x04005FA9 RID: 24489
		internal object $current;

		// Token: 0x04005FAA RID: 24490
		internal bool $disposing;

		// Token: 0x04005FAB RID: 24491
		internal int $PC;
	}
}
