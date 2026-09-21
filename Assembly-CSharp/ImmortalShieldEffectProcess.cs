using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008FA RID: 2298
public class ImmortalShieldEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004016 RID: 16406 RVA: 0x00199909 File Offset: 0x00197D09
	public ImmortalShieldEffectProcess()
	{
	}

	// Token: 0x17000BB4 RID: 2996
	// (get) Token: 0x06004017 RID: 16407 RVA: 0x00199911 File Offset: 0x00197D11
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ImmortalShield;
		}
	}

	// Token: 0x17000BB5 RID: 2997
	// (get) Token: 0x06004018 RID: 16408 RVA: 0x00199918 File Offset: 0x00197D18
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06004019 RID: 16409 RVA: 0x00199934 File Offset: 0x00197D34
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is ImmortalShieldEffectData)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(effectCarrier);
			ImmortalShieldEffectData data = specialEffectData as ImmortalShieldEffectData;
			foreach (IBattleUnit battleUnit in targets)
			{
				for (int i = 0; i < data.NumberOfShields; i++)
				{
					IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), effectCarrier, true), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x0600401A RID: 16410 RVA: 0x0019996D File Offset: 0x00197D6D
	public override int GetPresence()
	{
		return 20;
	}

	// Token: 0x0600401B RID: 16411 RVA: 0x00199971 File Offset: 0x00197D71
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x0600401C RID: 16412 RVA: 0x00199974 File Offset: 0x00197D74
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ImmortalShieldEffectData
			{
				IsStarEf = new bool?(true),
				NumberOfShields = UnityEngine.Random.Range(1, 3)
			}
		};
	}

	// Token: 0x02000F81 RID: 3969
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600646C RID: 25708 RVA: 0x001999AE File Offset: 0x00197DAE
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600646D RID: 25709 RVA: 0x001999B8 File Offset: 0x00197DB8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is ImmortalShieldEffectData))
				{
					goto IL_1C3;
				}
				targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(effectCarrier);
				data = (specialEffectData as ImmortalShieldEffectData);
				enumerator = targets.GetEnumerator();
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
					Block_7:
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
					goto IL_198;
				}
				IL_182:
				if (i < data.NumberOfShields)
				{
					enumerator2 = battleUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), effectCarrier, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
				IL_198:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					i = 0;
					goto IL_182;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1C3:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001507 RID: 5383
		// (get) Token: 0x0600646E RID: 25710 RVA: 0x00199BC8 File Offset: 0x00197FC8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001508 RID: 5384
		// (get) Token: 0x0600646F RID: 25711 RVA: 0x00199BD0 File Offset: 0x00197FD0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006470 RID: 25712 RVA: 0x00199BD8 File Offset: 0x00197FD8
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

		// Token: 0x06006471 RID: 25713 RVA: 0x00199C6C File Offset: 0x0019806C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006472 RID: 25714 RVA: 0x00199C73 File Offset: 0x00198073
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006473 RID: 25715 RVA: 0x00199C7C File Offset: 0x0019807C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ImmortalShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ImmortalShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005C4C RID: 23628
		internal AdventureEventType evtType;

		// Token: 0x04005C4D RID: 23629
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C4E RID: 23630
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C4F RID: 23631
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C50 RID: 23632
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005C51 RID: 23633
		internal ImmortalShieldEffectData <data>__1;

		// Token: 0x04005C52 RID: 23634
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005C53 RID: 23635
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005C54 RID: 23636
		internal int <i>__3;

		// Token: 0x04005C55 RID: 23637
		internal IEnumerator $locvar1;

		// Token: 0x04005C56 RID: 23638
		internal object <_>__4;

		// Token: 0x04005C57 RID: 23639
		internal IDisposable $locvar2;

		// Token: 0x04005C58 RID: 23640
		internal object $current;

		// Token: 0x04005C59 RID: 23641
		internal bool $disposing;

		// Token: 0x04005C5A RID: 23642
		internal int $PC;
	}
}
