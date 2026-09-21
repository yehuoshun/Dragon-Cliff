using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000933 RID: 2355
public class TauntBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600411E RID: 16670 RVA: 0x001A7DA4 File Offset: 0x001A61A4
	public TauntBoostEffectProcess()
	{
	}

	// Token: 0x17000C25 RID: 3109
	// (get) Token: 0x0600411F RID: 16671 RVA: 0x001A7DD7 File Offset: 0x001A61D7
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C26 RID: 3110
	// (get) Token: 0x06004120 RID: 16672 RVA: 0x001A7DDF File Offset: 0x001A61DF
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06004121 RID: 16673 RVA: 0x001A7DE8 File Offset: 0x001A61E8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && (triggerUnit.GetUnitClassStyle() == UnitClassStyle.Protector || triggerUnit.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || triggerUnit.GetUnitClassStyle() == UnitClassStyle.SpellDefender) && specialEffectData is TauntBoostData)
		{
			TauntBoostData data = specialEffectData as TauntBoostData;
			IEnumerator enumerator = triggerUnit.ApplySkillEffect(new TauntBoostEffect(data.DamageReflectionBoost, triggerUnit), false).GetEnumerator();
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

	// Token: 0x040030E0 RID: 12512
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.TauntBoost;

	// Token: 0x040030E1 RID: 12513
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitReadyInBattle
	};

	// Token: 0x02000FD3 RID: 4051
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066A0 RID: 26272 RVA: 0x001A7E21 File Offset: 0x001A6221
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066A1 RID: 26273 RVA: 0x001A7E2C File Offset: 0x001A622C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || (triggerUnit.GetUnitClassStyle() != UnitClassStyle.Protector && triggerUnit.GetUnitClassStyle() != UnitClassStyle.PhysicalDefender && triggerUnit.GetUnitClassStyle() != UnitClassStyle.SpellDefender) || !(specialEffectData is TauntBoostData))
				{
					goto IL_147;
				}
				data = (specialEffectData as TauntBoostData);
				enumerator = triggerUnit.ApplySkillEffect(new TauntBoostEffect(data.DamageReflectionBoost, triggerUnit), false).GetEnumerator();
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
			IL_147:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001587 RID: 5511
		// (get) Token: 0x060066A2 RID: 26274 RVA: 0x001A7F9C File Offset: 0x001A639C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001588 RID: 5512
		// (get) Token: 0x060066A3 RID: 26275 RVA: 0x001A7FA4 File Offset: 0x001A63A4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066A4 RID: 26276 RVA: 0x001A7FAC File Offset: 0x001A63AC
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

		// Token: 0x060066A5 RID: 26277 RVA: 0x001A801C File Offset: 0x001A641C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066A6 RID: 26278 RVA: 0x001A8023 File Offset: 0x001A6423
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066A7 RID: 26279 RVA: 0x001A802C File Offset: 0x001A642C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TauntBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TauntBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005FCB RID: 24523
		internal AdventureEventType evtType;

		// Token: 0x04005FCC RID: 24524
		internal IBattleUnit triggerUnit;

		// Token: 0x04005FCD RID: 24525
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FCE RID: 24526
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FCF RID: 24527
		internal TauntBoostData <data>__1;

		// Token: 0x04005FD0 RID: 24528
		internal IEnumerator $locvar0;

		// Token: 0x04005FD1 RID: 24529
		internal object <_>__2;

		// Token: 0x04005FD2 RID: 24530
		internal IDisposable $locvar1;

		// Token: 0x04005FD3 RID: 24531
		internal object $current;

		// Token: 0x04005FD4 RID: 24532
		internal bool $disposing;

		// Token: 0x04005FD5 RID: 24533
		internal int $PC;
	}
}
