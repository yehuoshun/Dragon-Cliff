using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200092B RID: 2347
public class StoneOfSoulbringerProcess : SpecialEffectProcessBase
{
	// Token: 0x060040FA RID: 16634 RVA: 0x001A5FB4 File Offset: 0x001A43B4
	public StoneOfSoulbringerProcess()
	{
	}

	// Token: 0x17000C15 RID: 3093
	// (get) Token: 0x060040FB RID: 16635 RVA: 0x001A5FC4 File Offset: 0x001A43C4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C16 RID: 3094
	// (get) Token: 0x060040FC RID: 16636 RVA: 0x001A5FCC File Offset: 0x001A43CC
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

	// Token: 0x060040FD RID: 16637 RVA: 0x001A5FE8 File Offset: 0x001A43E8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single)
		{
			DamageComponent damage = evtData as DamageComponent;
			StoneOfSoulbringerData data = specialEffectData as StoneOfSoulbringerData;
			if (damage != null && damage.Dealer == effectCarrier && !damage.IsMissed && damage.IsDirectDamage && damage.IsCrit && data != null)
			{
				IEnumerator enumerator = LockTimeEffect.AddStunSeconds(damage.Target, data.LastingSeconds, effectCarrier, true).GetEnumerator();
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

	// Token: 0x040030DB RID: 12507
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.StoneOfSoulbringerEffect;

	// Token: 0x02000FC8 RID: 4040
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600665B RID: 26203 RVA: 0x001A6022 File Offset: 0x001A4422
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600665C RID: 26204 RVA: 0x001A602C File Offset: 0x001A442C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single)
				{
					goto IL_160;
				}
				damage = (evtData as DamageComponent);
				data = (specialEffectData as StoneOfSoulbringerData);
				if (damage == null || damage.Dealer != effectCarrier || damage.IsMissed || !damage.IsDirectDamage || !damage.IsCrit || data == null)
				{
					goto IL_160;
				}
				enumerator = LockTimeEffect.AddStunSeconds(damage.Target, data.LastingSeconds, effectCarrier, true).GetEnumerator();
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
			IL_160:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001577 RID: 5495
		// (get) Token: 0x0600665D RID: 26205 RVA: 0x001A61B4 File Offset: 0x001A45B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001578 RID: 5496
		// (get) Token: 0x0600665E RID: 26206 RVA: 0x001A61BC File Offset: 0x001A45BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600665F RID: 26207 RVA: 0x001A61C4 File Offset: 0x001A45C4
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

		// Token: 0x06006660 RID: 26208 RVA: 0x001A6234 File Offset: 0x001A4634
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006661 RID: 26209 RVA: 0x001A623B File Offset: 0x001A463B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006662 RID: 26210 RVA: 0x001A6244 File Offset: 0x001A4644
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoneOfSoulbringerProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StoneOfSoulbringerProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F5C RID: 24412
		internal AdventureEventType evtType;

		// Token: 0x04005F5D RID: 24413
		internal object evtData;

		// Token: 0x04005F5E RID: 24414
		internal DamageComponent <damage>__1;

		// Token: 0x04005F5F RID: 24415
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F60 RID: 24416
		internal StoneOfSoulbringerData <data>__1;

		// Token: 0x04005F61 RID: 24417
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F62 RID: 24418
		internal IEnumerator $locvar0;

		// Token: 0x04005F63 RID: 24419
		internal object <_>__2;

		// Token: 0x04005F64 RID: 24420
		internal IDisposable $locvar1;

		// Token: 0x04005F65 RID: 24421
		internal object $current;

		// Token: 0x04005F66 RID: 24422
		internal bool $disposing;

		// Token: 0x04005F67 RID: 24423
		internal int $PC;
	}
}
