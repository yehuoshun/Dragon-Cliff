using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008E3 RID: 2275
public class ExtremeTauntEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FB5 RID: 16309 RVA: 0x00194005 File Offset: 0x00192405
	public ExtremeTauntEffectProcess()
	{
	}

	// Token: 0x17000B88 RID: 2952
	// (get) Token: 0x06003FB6 RID: 16310 RVA: 0x0019400D File Offset: 0x0019240D
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ExtremeTaunt;
		}
	}

	// Token: 0x17000B89 RID: 2953
	// (get) Token: 0x06003FB7 RID: 16311 RVA: 0x00194014 File Offset: 0x00192414
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003FB8 RID: 16312 RVA: 0x00194030 File Offset: 0x00192430
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is ExtremeTauntData)
		{
			DamageComponent damage = evtData as DamageComponent;
			ExtremeTauntData data = specialEffectData as ExtremeTauntData;
			IEnumerator enumerator = damage.Dealer.ApplySkillEffect(new TauntEffect(effectCarrier, effectCarrier, effectCarrier, new int?(data.TauntSeconds), true), false).GetEnumerator();
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

	// Token: 0x02000F60 RID: 3936
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600639B RID: 25499 RVA: 0x00194071 File Offset: 0x00192471
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600639C RID: 25500 RVA: 0x0019407C File Offset: 0x0019247C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is ExtremeTauntData))
				{
					goto IL_14C;
				}
				damage = (evtData as DamageComponent);
				data = (specialEffectData as ExtremeTauntData);
				enumerator = damage.Dealer.ApplySkillEffect(new TauntEffect(effectCarrier, effectCarrier, effectCarrier, new int?(data.TauntSeconds), true), false).GetEnumerator();
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
			IL_14C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014DB RID: 5339
		// (get) Token: 0x0600639D RID: 25501 RVA: 0x001941F0 File Offset: 0x001925F0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014DC RID: 5340
		// (get) Token: 0x0600639E RID: 25502 RVA: 0x001941F8 File Offset: 0x001925F8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600639F RID: 25503 RVA: 0x00194200 File Offset: 0x00192600
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

		// Token: 0x060063A0 RID: 25504 RVA: 0x00194270 File Offset: 0x00192670
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063A1 RID: 25505 RVA: 0x00194277 File Offset: 0x00192677
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063A2 RID: 25506 RVA: 0x00194280 File Offset: 0x00192680
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ExtremeTauntEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ExtremeTauntEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005AF4 RID: 23284
		internal AdventureEventType evtType;

		// Token: 0x04005AF5 RID: 23285
		internal IBattleUnit triggerUnit;

		// Token: 0x04005AF6 RID: 23286
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AF7 RID: 23287
		internal object evtData;

		// Token: 0x04005AF8 RID: 23288
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AF9 RID: 23289
		internal DamageComponent <damage>__1;

		// Token: 0x04005AFA RID: 23290
		internal ExtremeTauntData <data>__1;

		// Token: 0x04005AFB RID: 23291
		internal IEnumerator $locvar0;

		// Token: 0x04005AFC RID: 23292
		internal object <_>__2;

		// Token: 0x04005AFD RID: 23293
		internal IDisposable $locvar1;

		// Token: 0x04005AFE RID: 23294
		internal object $current;

		// Token: 0x04005AFF RID: 23295
		internal bool $disposing;

		// Token: 0x04005B00 RID: 23296
		internal int $PC;
	}
}
