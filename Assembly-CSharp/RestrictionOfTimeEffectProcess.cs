using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091B RID: 2331
public class RestrictionOfTimeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040AB RID: 16555 RVA: 0x001A25AC File Offset: 0x001A09AC
	public RestrictionOfTimeEffectProcess()
	{
	}

	// Token: 0x17000BF7 RID: 3063
	// (get) Token: 0x060040AC RID: 16556 RVA: 0x001A25B4 File Offset: 0x001A09B4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.RestrictionOfTime;
		}
	}

	// Token: 0x17000BF8 RID: 3064
	// (get) Token: 0x060040AD RID: 16557 RVA: 0x001A25BC File Offset: 0x001A09BC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReceivesEffect
			};
		}
	}

	// Token: 0x060040AE RID: 16558 RVA: 0x001A25D8 File Offset: 0x001A09D8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect && triggerUnit == effectCarrier && evtData is LockTimeEffect && specialEffectData is RestrictionOfTimeData)
		{
			RestrictionOfTimeData data = specialEffectData as RestrictionOfTimeData;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, effectCarrier, effectCarrier, "restrictionoftime", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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

	// Token: 0x02000FAC RID: 4012
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065A3 RID: 26019 RVA: 0x001A2619 File Offset: 0x001A0A19
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065A4 RID: 26020 RVA: 0x001A2624 File Offset: 0x001A0A24
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect || triggerUnit != effectCarrier || !(evtData is LockTimeEffect) || !(specialEffectData is RestrictionOfTimeData))
				{
					goto IL_165;
				}
				data = (specialEffectData as RestrictionOfTimeData);
				enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate), null, OutputType.RealHeal, effectCarrier, effectCarrier, "restrictionoftime", new int?(data.HealSeconds), false, false, true, new int?(1)), false).GetEnumerator();
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
			IL_165:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700154D RID: 5453
		// (get) Token: 0x060065A5 RID: 26021 RVA: 0x001A27B0 File Offset: 0x001A0BB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700154E RID: 5454
		// (get) Token: 0x060065A6 RID: 26022 RVA: 0x001A27B8 File Offset: 0x001A0BB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065A7 RID: 26023 RVA: 0x001A27C0 File Offset: 0x001A0BC0
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

		// Token: 0x060065A8 RID: 26024 RVA: 0x001A2830 File Offset: 0x001A0C30
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065A9 RID: 26025 RVA: 0x001A2837 File Offset: 0x001A0C37
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065AA RID: 26026 RVA: 0x001A2840 File Offset: 0x001A0C40
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RestrictionOfTimeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new RestrictionOfTimeEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E61 RID: 24161
		internal AdventureEventType evtType;

		// Token: 0x04005E62 RID: 24162
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E63 RID: 24163
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E64 RID: 24164
		internal object evtData;

		// Token: 0x04005E65 RID: 24165
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E66 RID: 24166
		internal RestrictionOfTimeData <data>__1;

		// Token: 0x04005E67 RID: 24167
		internal IEnumerator $locvar0;

		// Token: 0x04005E68 RID: 24168
		internal object <_>__2;

		// Token: 0x04005E69 RID: 24169
		internal IDisposable $locvar1;

		// Token: 0x04005E6A RID: 24170
		internal object $current;

		// Token: 0x04005E6B RID: 24171
		internal bool $disposing;

		// Token: 0x04005E6C RID: 24172
		internal int $PC;
	}
}
