using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000932 RID: 2354
public class TattoringFoesEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004118 RID: 16664 RVA: 0x001A79C0 File Offset: 0x001A5DC0
	public TattoringFoesEffectProcess()
	{
	}

	// Token: 0x17000C23 RID: 3107
	// (get) Token: 0x06004119 RID: 16665 RVA: 0x001A79D0 File Offset: 0x001A5DD0
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C24 RID: 3108
	// (get) Token: 0x0600411A RID: 16666 RVA: 0x001A79D8 File Offset: 0x001A5DD8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x0600411B RID: 16667 RVA: 0x001A79E0 File Offset: 0x001A5DE0
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is TattoringFoesData)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Asc, new int?(1)).GetTargets(effectCarrier);
			TattoringFoesData data = specialEffectData as TattoringFoesData;
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(effectCarrier, t, data.DamageType, data.DamageRate)
				}, t, effectCarrier, true, false)
			})).ToList<BattleDamage>(), effectCarrier);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600411C RID: 16668 RVA: 0x001A7A11 File Offset: 0x001A5E11
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return false;
	}

	// Token: 0x0600411D RID: 16669 RVA: 0x001A7A14 File Offset: 0x001A5E14
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		return new List<ISpecialEffectDataLoad>
		{
			new TattoringFoesData
			{
				DamageType = allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)],
				DamageRate = 0.8 * (double)UnityEngine.Random.Range(0.5f, 1f),
				IsStar = true
			}
		};
	}

	// Token: 0x040030DF RID: 12511
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.TattoringFoes;

	// Token: 0x02000FD0 RID: 4048
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006695 RID: 26261 RVA: 0x001A7A7A File Offset: 0x001A5E7A
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006696 RID: 26262 RVA: 0x001A7A84 File Offset: 0x001A5E84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitPerSecondProcess>c__AnonStorey = new TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1();
				<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (!(specialEffectData is TattoringFoesData))
				{
					goto IL_183;
				}
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Asc, new int?(1)).GetTargets(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
				TattoringFoesData data = specialEffectData as TattoringFoesData;
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, t, data.DamageType, data.DamageRate)
					}, t, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, true, false)
				})).ToList<BattleDamage>(), <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
				enumerator = releaseableDamage.Release().GetEnumerator();
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
			IL_183:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001585 RID: 5509
		// (get) Token: 0x06006697 RID: 26263 RVA: 0x001A7C30 File Offset: 0x001A6030
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001586 RID: 5510
		// (get) Token: 0x06006698 RID: 26264 RVA: 0x001A7C38 File Offset: 0x001A6038
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006699 RID: 26265 RVA: 0x001A7C40 File Offset: 0x001A6040
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

		// Token: 0x0600669A RID: 26266 RVA: 0x001A7CB0 File Offset: 0x001A60B0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600669B RID: 26267 RVA: 0x001A7CB7 File Offset: 0x001A60B7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600669C RID: 26268 RVA: 0x001A7CC0 File Offset: 0x001A60C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005FBA RID: 24506
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FBB RID: 24507
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FBC RID: 24508
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005FBD RID: 24509
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x04005FBE RID: 24510
		internal IEnumerator $locvar0;

		// Token: 0x04005FBF RID: 24511
		internal object <_>__2;

		// Token: 0x04005FC0 RID: 24512
		internal IDisposable $locvar1;

		// Token: 0x04005FC1 RID: 24513
		internal TattoringFoesEffectProcess $this;

		// Token: 0x04005FC2 RID: 24514
		internal object $current;

		// Token: 0x04005FC3 RID: 24515
		internal bool $disposing;

		// Token: 0x04005FC4 RID: 24516
		internal int $PC;

		// Token: 0x04005FC5 RID: 24517
		private TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 $locvar2;

		// Token: 0x04005FC6 RID: 24518
		private TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000FD1 RID: 4049
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey1
		{
			// Token: 0x0600669D RID: 26269 RVA: 0x001A7D0C File Offset: 0x001A610C
			public <AsActiveUnitPerSecondProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04005FC7 RID: 24519
			internal IBattleUnit effectCarrier;
		}

		// Token: 0x02000FD2 RID: 4050
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x0600669E RID: 26270 RVA: 0x001A7D14 File Offset: 0x001A6114
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x0600669F RID: 26271 RVA: 0x001A7D1C File Offset: 0x001A611C
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$1.effectCarrier, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$1.effectCarrier, t, this.data.DamageType, this.data.DamageRate)
					}, t, this.<>f__ref$1.effectCarrier, true, false)
				});
			}

			// Token: 0x04005FC8 RID: 24520
			internal TattoringFoesData data;

			// Token: 0x04005FC9 RID: 24521
			internal TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005FCA RID: 24522
			internal TattoringFoesEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
