using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008B0 RID: 2224
public class BlackBloodEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003ED2 RID: 16082 RVA: 0x001852AA File Offset: 0x001836AA
	public BlackBloodEffectProcess()
	{
	}

	// Token: 0x17000B22 RID: 2850
	// (get) Token: 0x06003ED3 RID: 16083 RVA: 0x001852B2 File Offset: 0x001836B2
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.BlackBlood;
		}
	}

	// Token: 0x17000B23 RID: 2851
	// (get) Token: 0x06003ED4 RID: 16084 RVA: 0x001852BC File Offset: 0x001836BC
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

	// Token: 0x06003ED5 RID: 16085 RVA: 0x001852D8 File Offset: 0x001836D8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is BlackBloodData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && !damage.IsMissed)
			{
				BlackBloodData data = specialEffectData as BlackBloodData;
				IEnumerator enumerator = BlackBloodEffect.AddBlackBloodEffect(damage.Dealer, effectCarrier, (double)data.Seconds, 0.0, data.ResistanceDecayRate, 0.0, data.DodgeDecayRate).GetEnumerator();
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

	// Token: 0x02000F1A RID: 3866
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061B0 RID: 25008 RVA: 0x00185319 File Offset: 0x00183719
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061B1 RID: 25009 RVA: 0x00185324 File Offset: 0x00183724
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is BlackBloodData))
				{
					goto IL_17D;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_17D;
				}
				data = (specialEffectData as BlackBloodData);
				enumerator = BlackBloodEffect.AddBlackBloodEffect(damage.Dealer, effectCarrier, (double)data.Seconds, 0.0, data.ResistanceDecayRate, 0.0, data.DodgeDecayRate).GetEnumerator();
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
			IL_17D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001475 RID: 5237
		// (get) Token: 0x060061B2 RID: 25010 RVA: 0x001854C8 File Offset: 0x001838C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001476 RID: 5238
		// (get) Token: 0x060061B3 RID: 25011 RVA: 0x001854D0 File Offset: 0x001838D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061B4 RID: 25012 RVA: 0x001854D8 File Offset: 0x001838D8
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

		// Token: 0x060061B5 RID: 25013 RVA: 0x00185548 File Offset: 0x00183948
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061B6 RID: 25014 RVA: 0x0018554F File Offset: 0x0018394F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061B7 RID: 25015 RVA: 0x00185558 File Offset: 0x00183958
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BlackBloodEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new BlackBloodEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005784 RID: 22404
		internal AdventureEventType evtType;

		// Token: 0x04005785 RID: 22405
		internal IBattleUnit triggerUnit;

		// Token: 0x04005786 RID: 22406
		internal IBattleUnit effectCarrier;

		// Token: 0x04005787 RID: 22407
		internal object evtData;

		// Token: 0x04005788 RID: 22408
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005789 RID: 22409
		internal DamageComponent <damage>__1;

		// Token: 0x0400578A RID: 22410
		internal BlackBloodData <data>__2;

		// Token: 0x0400578B RID: 22411
		internal IEnumerator $locvar0;

		// Token: 0x0400578C RID: 22412
		internal object <_>__3;

		// Token: 0x0400578D RID: 22413
		internal IDisposable $locvar1;

		// Token: 0x0400578E RID: 22414
		internal object $current;

		// Token: 0x0400578F RID: 22415
		internal bool $disposing;

		// Token: 0x04005790 RID: 22416
		internal int $PC;
	}
}
