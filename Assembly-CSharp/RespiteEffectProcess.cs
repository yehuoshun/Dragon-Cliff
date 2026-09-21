using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091A RID: 2330
public class RespiteEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040A7 RID: 16551 RVA: 0x001A22E4 File Offset: 0x001A06E4
	public RespiteEffectProcess()
	{
	}

	// Token: 0x17000BF5 RID: 3061
	// (get) Token: 0x060040A8 RID: 16552 RVA: 0x001A22EC File Offset: 0x001A06EC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Respite;
		}
	}

	// Token: 0x17000BF6 RID: 3062
	// (get) Token: 0x060040A9 RID: 16553 RVA: 0x001A22F0 File Offset: 0x001A06F0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitCompletesTurn
			};
		}
	}

	// Token: 0x060040AA RID: 16554 RVA: 0x001A2314 File Offset: 0x001A0714
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitReadyInBattle || evtType == AdventureEventType.UnitCompletesTurn) && triggerUnit == effectCarrier && specialEffectData is RespiteData)
		{
			RespiteData data = specialEffectData as RespiteData;
			IEnumerator enumerator = triggerUnit.ApplySkillEffect(new RespiteShieldEffect(new int?(data.RespiteShieldTime), null, data.FearTime, data.ArrogancePunishmentTime, effectCarrier), false).GetEnumerator();
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

	// Token: 0x02000FAB RID: 4011
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600659B RID: 26011 RVA: 0x001A234D File Offset: 0x001A074D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600659C RID: 26012 RVA: 0x001A2358 File Offset: 0x001A0758
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitReadyInBattle && evtType != AdventureEventType.UnitCompletesTurn) || triggerUnit != effectCarrier || !(specialEffectData is RespiteData))
				{
					goto IL_145;
				}
				data = (specialEffectData as RespiteData);
				enumerator = triggerUnit.ApplySkillEffect(new RespiteShieldEffect(new int?(data.RespiteShieldTime), null, data.FearTime, data.ArrogancePunishmentTime, effectCarrier), false).GetEnumerator();
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
			IL_145:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700154B RID: 5451
		// (get) Token: 0x0600659D RID: 26013 RVA: 0x001A24C4 File Offset: 0x001A08C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700154C RID: 5452
		// (get) Token: 0x0600659E RID: 26014 RVA: 0x001A24CC File Offset: 0x001A08CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600659F RID: 26015 RVA: 0x001A24D4 File Offset: 0x001A08D4
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

		// Token: 0x060065A0 RID: 26016 RVA: 0x001A2544 File Offset: 0x001A0944
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065A1 RID: 26017 RVA: 0x001A254B File Offset: 0x001A094B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065A2 RID: 26018 RVA: 0x001A2554 File Offset: 0x001A0954
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RespiteEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new RespiteEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E56 RID: 24150
		internal AdventureEventType evtType;

		// Token: 0x04005E57 RID: 24151
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E58 RID: 24152
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E59 RID: 24153
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E5A RID: 24154
		internal RespiteData <data>__1;

		// Token: 0x04005E5B RID: 24155
		internal IEnumerator $locvar0;

		// Token: 0x04005E5C RID: 24156
		internal object <_>__2;

		// Token: 0x04005E5D RID: 24157
		internal IDisposable $locvar1;

		// Token: 0x04005E5E RID: 24158
		internal object $current;

		// Token: 0x04005E5F RID: 24159
		internal bool $disposing;

		// Token: 0x04005E60 RID: 24160
		internal int $PC;
	}
}
