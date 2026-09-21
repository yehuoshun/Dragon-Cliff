using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008EC RID: 2284
public class FlyingFeatherEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FDB RID: 16347 RVA: 0x001964F4 File Offset: 0x001948F4
	public FlyingFeatherEffectProcess()
	{
	}

	// Token: 0x17000B9A RID: 2970
	// (get) Token: 0x06003FDC RID: 16348 RVA: 0x00196504 File Offset: 0x00194904
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B9B RID: 2971
	// (get) Token: 0x06003FDD RID: 16349 RVA: 0x0019650C File Offset: 0x0019490C
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

	// Token: 0x06003FDE RID: 16350 RVA: 0x00196528 File Offset: 0x00194928
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(new FlyingFeatherEffect(effectCarrier, 0.6), false).GetEnumerator();
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

	// Token: 0x04002F8C RID: 12172
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.FlyingFeatherEffect;

	// Token: 0x02000F6E RID: 3950
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063EF RID: 25583 RVA: 0x0019655A File Offset: 0x0019495A
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063F0 RID: 25584 RVA: 0x00196564 File Offset: 0x00194964
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier)
				{
					goto IL_F1;
				}
				enumerator = effectCarrier.ApplySkillEffect(new FlyingFeatherEffect(effectCarrier, 0.6), false).GetEnumerator();
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
			IL_F1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014ED RID: 5357
		// (get) Token: 0x060063F1 RID: 25585 RVA: 0x0019667C File Offset: 0x00194A7C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014EE RID: 5358
		// (get) Token: 0x060063F2 RID: 25586 RVA: 0x00196684 File Offset: 0x00194A84
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063F3 RID: 25587 RVA: 0x0019668C File Offset: 0x00194A8C
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

		// Token: 0x060063F4 RID: 25588 RVA: 0x001966FC File Offset: 0x00194AFC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063F5 RID: 25589 RVA: 0x00196703 File Offset: 0x00194B03
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063F6 RID: 25590 RVA: 0x0019670C File Offset: 0x00194B0C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FlyingFeatherEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FlyingFeatherEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B8C RID: 23436
		internal AdventureEventType evtType;

		// Token: 0x04005B8D RID: 23437
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B8E RID: 23438
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B8F RID: 23439
		internal IEnumerator $locvar0;

		// Token: 0x04005B90 RID: 23440
		internal object <_>__1;

		// Token: 0x04005B91 RID: 23441
		internal IDisposable $locvar1;

		// Token: 0x04005B92 RID: 23442
		internal object $current;

		// Token: 0x04005B93 RID: 23443
		internal bool $disposing;

		// Token: 0x04005B94 RID: 23444
		internal int $PC;
	}
}
