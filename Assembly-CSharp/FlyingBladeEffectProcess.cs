using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008EB RID: 2283
public class FlyingBladeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FD7 RID: 16343 RVA: 0x001960F4 File Offset: 0x001944F4
	public FlyingBladeEffectProcess()
	{
	}

	// Token: 0x17000B98 RID: 2968
	// (get) Token: 0x06003FD8 RID: 16344 RVA: 0x001960FC File Offset: 0x001944FC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.FlyingBlade;
		}
	}

	// Token: 0x17000B99 RID: 2969
	// (get) Token: 0x06003FD9 RID: 16345 RVA: 0x00196100 File Offset: 0x00194500
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostCastSkill
			};
		}
	}

	// Token: 0x06003FDA RID: 16346 RVA: 0x0019611C File Offset: 0x0019451C
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitPostCastSkill && evt.EventTriggeringUnit.IsPlayer && specialEffectData is FlyingBladeData)
		{
			FlyingBladeData data = specialEffectData as FlyingBladeData;
			if ((double)UnityEngine.Random.value <= data.Chance)
			{
				List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(evt.EventTriggeringUnit);
				if (targets.Any<IBattleUnit>())
				{
					ReleaseableDamage damage = new ReleaseableDamage((from t in targets
					select new BattleDamage(t, new SpecialEffectTriggerSource(evt.EventTriggeringUnit, this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(evt.EventTriggeringUnit, t, evt.EventTriggeringUnit.GetOutputType(), data.DamageRate)
						}, t, evt.EventTriggeringUnit, true, false)
					})).ToList<BattleDamage>(), evt.EventTriggeringUnit);
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
			}
		}
		yield break;
	}

	// Token: 0x02000F6B RID: 3947
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063E4 RID: 25572 RVA: 0x0019614D File Offset: 0x0019454D
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060063E5 RID: 25573 RVA: 0x00196158 File Offset: 0x00194558
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsAdventureEffectProcess>c__AnonStorey = new FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1();
				<AsAdventureEffectProcess>c__AnonStorey.evt = evt;
				if (<AsAdventureEffectProcess>c__AnonStorey.evt.EventType != AdventureEventType.UnitPostCastSkill || !<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.IsPlayer || !(specialEffectData is FlyingBladeData))
				{
					goto IL_1E9;
				}
				FlyingBladeData data = specialEffectData as FlyingBladeData;
				if ((double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_1E9;
				}
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_1E9;
				}
				damage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, t, <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.GetOutputType(), data.DamageRate)
					}, t, <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, true, false)
				})).ToList<BattleDamage>(), <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit);
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
			IL_1E9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014EB RID: 5355
		// (get) Token: 0x060063E6 RID: 25574 RVA: 0x00196368 File Offset: 0x00194768
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014EC RID: 5356
		// (get) Token: 0x060063E7 RID: 25575 RVA: 0x00196370 File Offset: 0x00194770
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063E8 RID: 25576 RVA: 0x00196378 File Offset: 0x00194778
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

		// Token: 0x060063E9 RID: 25577 RVA: 0x001963E8 File Offset: 0x001947E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063EA RID: 25578 RVA: 0x001963EF File Offset: 0x001947EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063EB RID: 25579 RVA: 0x001963F8 File Offset: 0x001947F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.$this = this;
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005B7B RID: 23419
		internal BroadcastEvent evt;

		// Token: 0x04005B7C RID: 23420
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B7D RID: 23421
		internal List<IBattleUnit> <targets>__2;

		// Token: 0x04005B7E RID: 23422
		internal ReleaseableDamage <damage>__3;

		// Token: 0x04005B7F RID: 23423
		internal IEnumerator $locvar0;

		// Token: 0x04005B80 RID: 23424
		internal object <_>__4;

		// Token: 0x04005B81 RID: 23425
		internal IDisposable $locvar1;

		// Token: 0x04005B82 RID: 23426
		internal FlyingBladeEffectProcess $this;

		// Token: 0x04005B83 RID: 23427
		internal object $current;

		// Token: 0x04005B84 RID: 23428
		internal bool $disposing;

		// Token: 0x04005B85 RID: 23429
		internal int $PC;

		// Token: 0x04005B86 RID: 23430
		private FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 $locvar2;

		// Token: 0x04005B87 RID: 23431
		private FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000F6C RID: 3948
		private sealed class <AsAdventureEffectProcess>c__AnonStorey1
		{
			// Token: 0x060063EC RID: 25580 RVA: 0x00196444 File Offset: 0x00194844
			public <AsAdventureEffectProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04005B88 RID: 23432
			internal BroadcastEvent evt;
		}

		// Token: 0x02000F6D RID: 3949
		private sealed class <AsAdventureEffectProcess>c__AnonStorey2
		{
			// Token: 0x060063ED RID: 25581 RVA: 0x0019644C File Offset: 0x0019484C
			public <AsAdventureEffectProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060063EE RID: 25582 RVA: 0x00196454 File Offset: 0x00194854
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$1.evt.EventTriggeringUnit, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$1.evt.EventTriggeringUnit, t, this.<>f__ref$1.evt.EventTriggeringUnit.GetOutputType(), this.data.DamageRate)
					}, t, this.<>f__ref$1.evt.EventTriggeringUnit, true, false)
				});
			}

			// Token: 0x04005B89 RID: 23433
			internal FlyingBladeData data;

			// Token: 0x04005B8A RID: 23434
			internal FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005B8B RID: 23435
			internal FlyingBladeEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
