using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091C RID: 2332
public class ReviveDamageProcess : SpecialEffectProcessBase
{
	// Token: 0x060040AF RID: 16559 RVA: 0x001A28A4 File Offset: 0x001A0CA4
	public ReviveDamageProcess()
	{
	}

	// Token: 0x17000BF9 RID: 3065
	// (get) Token: 0x060040B0 RID: 16560 RVA: 0x001A28AC File Offset: 0x001A0CAC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ReviveDamage;
		}
	}

	// Token: 0x17000BFA RID: 3066
	// (get) Token: 0x060040B1 RID: 16561 RVA: 0x001A28B0 File Offset: 0x001A0CB0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitRevived
			};
		}
	}

	// Token: 0x060040B2 RID: 16562 RVA: 0x001A28CC File Offset: 0x001A0CCC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitRevived && specialEffectData is ReviveDamageData && triggerUnit.IsPlayer == effectCarrier.IsPlayer)
		{
			ReviveDamageData data = specialEffectData as ReviveDamageData;
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(effectCarrier);
			ReleaseableDamage damage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(effectCarrier, t, data.DamageType, data.DamageRate)
				}, t, effectCarrier, false, false)
			})).ToList<BattleDamage>(), effectCarrier);
			IEnumerator enumerator = damage.Release().GetEnumerator();
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

	// Token: 0x02000FAD RID: 4013
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065AB RID: 26027 RVA: 0x001A290C File Offset: 0x001A0D0C
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065AC RID: 26028 RVA: 0x001A2914 File Offset: 0x001A0D14
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitProcess>c__AnonStorey = new ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1();
				<AsActiveUnitProcess>c__AnonStorey.<>f__ref$0 = this;
				<AsActiveUnitProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (evtType != AdventureEventType.UnitRevived || !(specialEffectData is ReviveDamageData) || triggerUnit.IsPlayer != <AsActiveUnitProcess>c__AnonStorey.effectCarrier.IsPlayer)
				{
					goto IL_1BF;
				}
				ReviveDamageData data = specialEffectData as ReviveDamageData;
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<AsActiveUnitProcess>c__AnonStorey.effectCarrier);
				damage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, t, data.DamageType, data.DamageRate)
					}, t, <AsActiveUnitProcess>c__AnonStorey.effectCarrier, false, false)
				})).ToList<BattleDamage>(), <AsActiveUnitProcess>c__AnonStorey.effectCarrier);
				enumerator = damage.Release().GetEnumerator();
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
			IL_1BF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700154F RID: 5455
		// (get) Token: 0x060065AD RID: 26029 RVA: 0x001A2AFC File Offset: 0x001A0EFC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001550 RID: 5456
		// (get) Token: 0x060065AE RID: 26030 RVA: 0x001A2B04 File Offset: 0x001A0F04
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065AF RID: 26031 RVA: 0x001A2B0C File Offset: 0x001A0F0C
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

		// Token: 0x060065B0 RID: 26032 RVA: 0x001A2B7C File Offset: 0x001A0F7C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065B1 RID: 26033 RVA: 0x001A2B83 File Offset: 0x001A0F83
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065B2 RID: 26034 RVA: 0x001A2B8C File Offset: 0x001A0F8C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E6D RID: 24173
		internal AdventureEventType evtType;

		// Token: 0x04005E6E RID: 24174
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E6F RID: 24175
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E70 RID: 24176
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E71 RID: 24177
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005E72 RID: 24178
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005E73 RID: 24179
		internal IEnumerator $locvar0;

		// Token: 0x04005E74 RID: 24180
		internal object <_>__2;

		// Token: 0x04005E75 RID: 24181
		internal IDisposable $locvar1;

		// Token: 0x04005E76 RID: 24182
		internal ReviveDamageProcess $this;

		// Token: 0x04005E77 RID: 24183
		internal object $current;

		// Token: 0x04005E78 RID: 24184
		internal bool $disposing;

		// Token: 0x04005E79 RID: 24185
		internal int $PC;

		// Token: 0x04005E7A RID: 24186
		private ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x04005E7B RID: 24187
		private ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000FAE RID: 4014
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060065B3 RID: 26035 RVA: 0x001A2BF0 File Offset: 0x001A0FF0
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04005E7C RID: 24188
			internal IBattleUnit effectCarrier;

			// Token: 0x04005E7D RID: 24189
			internal ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000FAF RID: 4015
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x060065B4 RID: 26036 RVA: 0x001A2BF8 File Offset: 0x001A0FF8
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060065B5 RID: 26037 RVA: 0x001A2C00 File Offset: 0x001A1000
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$1.effectCarrier, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$1.effectCarrier, t, this.data.DamageType, this.data.DamageRate)
					}, t, this.<>f__ref$1.effectCarrier, false, false)
				});
			}

			// Token: 0x04005E7E RID: 24190
			internal ReviveDamageData data;

			// Token: 0x04005E7F RID: 24191
			internal ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005E80 RID: 24192
			internal ReviveDamageProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
