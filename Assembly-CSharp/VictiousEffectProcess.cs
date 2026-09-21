using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093E RID: 2366
public class VictiousEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004151 RID: 16721 RVA: 0x001AC6A3 File Offset: 0x001AAAA3
	public VictiousEffectProcess()
	{
	}

	// Token: 0x17000C3B RID: 3131
	// (get) Token: 0x06004152 RID: 16722 RVA: 0x001AC6AB File Offset: 0x001AAAAB
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Victious;
		}
	}

	// Token: 0x17000C3C RID: 3132
	// (get) Token: 0x06004153 RID: 16723 RVA: 0x001AC6B0 File Offset: 0x001AAAB0
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

	// Token: 0x06004154 RID: 16724 RVA: 0x001AC6CC File Offset: 0x001AAACC
	private void SelectTarget(VictiousEffectData data, IBattleUnit effectCarrier)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(effectCarrier);
		data.CurrentTargets = targets;
	}

	// Token: 0x06004155 RID: 16725 RVA: 0x001AC6F8 File Offset: 0x001AAAF8
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is VictiousEffectData)
		{
			VictiousEffectData data = specialEffectData as VictiousEffectData;
			data.CurrentTargetCounter++;
			if (data.CurrentTargetCounter >= data.TargetSwitchTimerCap)
			{
				data.CurrentTargetCounter -= data.TargetSwitchTimerCap;
				this.SelectTarget(data, effectCarrier);
			}
			if (data.CurrentTargets != null && data.CurrentTargets.Any<IBattleUnit>())
			{
				ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in data.CurrentTargets
				select new BattleDamage(t, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(effectCarrier, t, data.DamageType, data.DamageRatePerSecond)
					}, t, effectCarrier, false, false)
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
		}
		yield break;
	}

	// Token: 0x06004156 RID: 16726 RVA: 0x001AC72C File Offset: 0x001AAB2C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType != AdventureEventType.UnitReadyInBattle)
		{
			yield break;
		}
		if (triggerUnit != effectCarrier)
		{
			yield break;
		}
		if (specialEffectData is VictiousEffectData)
		{
			VictiousEffectData victiousEffectData = specialEffectData as VictiousEffectData;
			victiousEffectData.CurrentTargetCounter = 0;
			victiousEffectData.CurrentTargets = new List<IBattleUnit>();
			this.SelectTarget(victiousEffectData, effectCarrier);
			yield break;
		}
		yield break;
	}

	// Token: 0x02000FE5 RID: 4069
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600671A RID: 26394 RVA: 0x001AC76C File Offset: 0x001AAB6C
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x0600671B RID: 26395 RVA: 0x001AC774 File Offset: 0x001AAB74
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitPerSecondProcess>c__AnonStorey = new VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2();
				<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (!(specialEffectData is VictiousEffectData))
				{
					goto IL_21D;
				}
				VictiousEffectData data = specialEffectData as VictiousEffectData;
				data.CurrentTargetCounter++;
				if (data.CurrentTargetCounter >= data.TargetSwitchTimerCap)
				{
					data.CurrentTargetCounter -= data.TargetSwitchTimerCap;
					base.SelectTarget(data, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
				}
				if (data.CurrentTargets == null || !data.CurrentTargets.Any<IBattleUnit>())
				{
					goto IL_21D;
				}
				releaseableDamage = new ReleaseableDamage((from t in data.CurrentTargets
				select new BattleDamage(t, new SpecialEffectTriggerSource(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, t, data.DamageType, data.DamageRatePerSecond)
					}, t, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, false, false)
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
			IL_21D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015A1 RID: 5537
		// (get) Token: 0x0600671C RID: 26396 RVA: 0x001AC9B8 File Offset: 0x001AADB8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015A2 RID: 5538
		// (get) Token: 0x0600671D RID: 26397 RVA: 0x001AC9C0 File Offset: 0x001AADC0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600671E RID: 26398 RVA: 0x001AC9C8 File Offset: 0x001AADC8
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

		// Token: 0x0600671F RID: 26399 RVA: 0x001ACA38 File Offset: 0x001AAE38
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006720 RID: 26400 RVA: 0x001ACA3F File Offset: 0x001AAE3F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006721 RID: 26401 RVA: 0x001ACA48 File Offset: 0x001AAE48
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x040060DF RID: 24799
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060E0 RID: 24800
		internal IBattleUnit effectCarrier;

		// Token: 0x040060E1 RID: 24801
		internal ReleaseableDamage <releaseableDamage>__2;

		// Token: 0x040060E2 RID: 24802
		internal IEnumerator $locvar0;

		// Token: 0x040060E3 RID: 24803
		internal object <_>__3;

		// Token: 0x040060E4 RID: 24804
		internal IDisposable $locvar1;

		// Token: 0x040060E5 RID: 24805
		internal VictiousEffectProcess $this;

		// Token: 0x040060E6 RID: 24806
		internal object $current;

		// Token: 0x040060E7 RID: 24807
		internal bool $disposing;

		// Token: 0x040060E8 RID: 24808
		internal int $PC;

		// Token: 0x040060E9 RID: 24809
		private VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvar2;

		// Token: 0x040060EA RID: 24810
		private VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey3 $locvar3;

		// Token: 0x02000FE7 RID: 4071
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x0600672A RID: 26410 RVA: 0x001ACA94 File Offset: 0x001AAE94
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x040060F3 RID: 24819
			internal IBattleUnit effectCarrier;
		}

		// Token: 0x02000FE8 RID: 4072
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey3
		{
			// Token: 0x0600672B RID: 26411 RVA: 0x001ACA9C File Offset: 0x001AAE9C
			public <AsActiveUnitPerSecondProcess>c__AnonStorey3()
			{
			}

			// Token: 0x0600672C RID: 26412 RVA: 0x001ACAA4 File Offset: 0x001AAEA4
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$2.effectCarrier, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$2.effectCarrier, t, this.data.DamageType, this.data.DamageRatePerSecond)
					}, t, this.<>f__ref$2.effectCarrier, false, false)
				});
			}

			// Token: 0x040060F4 RID: 24820
			internal VictiousEffectData data;

			// Token: 0x040060F5 RID: 24821
			internal VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x040060F6 RID: 24822
			internal VictiousEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000FE6 RID: 4070
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006722 RID: 26402 RVA: 0x001ACB2B File Offset: 0x001AAF2B
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x06006723 RID: 26403 RVA: 0x001ACB34 File Offset: 0x001AAF34
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag && evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is VictiousEffectData)
			{
				VictiousEffectData victiousEffectData = specialEffectData as VictiousEffectData;
				victiousEffectData.CurrentTargetCounter = 0;
				victiousEffectData.CurrentTargets = new List<IBattleUnit>();
				base.SelectTarget(victiousEffectData, effectCarrier);
			}
			return false;
		}

		// Token: 0x170015A3 RID: 5539
		// (get) Token: 0x06006724 RID: 26404 RVA: 0x001ACBB7 File Offset: 0x001AAFB7
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015A4 RID: 5540
		// (get) Token: 0x06006725 RID: 26405 RVA: 0x001ACBBF File Offset: 0x001AAFBF
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006726 RID: 26406 RVA: 0x001ACBC7 File Offset: 0x001AAFC7
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006727 RID: 26407 RVA: 0x001ACBC9 File Offset: 0x001AAFC9
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006728 RID: 26408 RVA: 0x001ACBD0 File Offset: 0x001AAFD0
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006729 RID: 26409 RVA: 0x001ACBD8 File Offset: 0x001AAFD8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			VictiousEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new VictiousEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040060EB RID: 24811
		internal AdventureEventType evtType;

		// Token: 0x040060EC RID: 24812
		internal IBattleUnit triggerUnit;

		// Token: 0x040060ED RID: 24813
		internal IBattleUnit effectCarrier;

		// Token: 0x040060EE RID: 24814
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060EF RID: 24815
		internal VictiousEffectProcess $this;

		// Token: 0x040060F0 RID: 24816
		internal object $current;

		// Token: 0x040060F1 RID: 24817
		internal bool $disposing;

		// Token: 0x040060F2 RID: 24818
		internal int $PC;
	}
}
