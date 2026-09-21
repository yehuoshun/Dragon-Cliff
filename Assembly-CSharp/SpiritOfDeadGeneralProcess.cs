using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000925 RID: 2341
public class SpiritOfDeadGeneralProcess : SpecialEffectProcessBase
{
	// Token: 0x060040E0 RID: 16608 RVA: 0x001A4863 File Offset: 0x001A2C63
	public SpiritOfDeadGeneralProcess()
	{
	}

	// Token: 0x17000C09 RID: 3081
	// (get) Token: 0x060040E1 RID: 16609 RVA: 0x001A4873 File Offset: 0x001A2C73
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C0A RID: 3082
	// (get) Token: 0x060040E2 RID: 16610 RVA: 0x001A487C File Offset: 0x001A2C7C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitKilled
			};
		}
	}

	// Token: 0x060040E3 RID: 16611 RVA: 0x001A4898 File Offset: 0x001A2C98
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		SpiritOfDeadGeneralData processData = specialEffectData as SpiritOfDeadGeneralData;
		if (evtType == AdventureEventType.UnitKilled && processData != null)
		{
			BattleDamage damage = evtData as BattleDamage;
			if (damage != null && damage.Dealer == effectCarrier && (double)UnityEngine.Random.value <= processData.Chance)
			{
				UnitTurnProgressUpdateEvent push = new UnitTurnProgressUpdateEvent
				{
					Dealer = effectCarrier,
					CausingSource = effectCarrier,
					ChangePercentage = processData.SpeedUpRate
				};
				IEnumerator enumerator = effectCarrier.ChangeTurnCounterProgress(push).GetEnumerator();
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

	// Token: 0x040030D9 RID: 12505
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.SpiritOfDeadGeneralEffect;

	// Token: 0x02000FC0 RID: 4032
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006626 RID: 26150 RVA: 0x001A48D2 File Offset: 0x001A2CD2
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006627 RID: 26151 RVA: 0x001A48DC File Offset: 0x001A2CDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				processData = (specialEffectData as SpiritOfDeadGeneralData);
				if (evtType != AdventureEventType.UnitKilled || processData == null)
				{
					goto IL_16B;
				}
				damage = (evtData as BattleDamage);
				if (damage == null || damage.Dealer != effectCarrier || (double)UnityEngine.Random.value > processData.Chance)
				{
					goto IL_16B;
				}
				push = new UnitTurnProgressUpdateEvent
				{
					Dealer = effectCarrier,
					CausingSource = effectCarrier,
					ChangePercentage = processData.SpeedUpRate
				};
				enumerator = effectCarrier.ChangeTurnCounterProgress(push).GetEnumerator();
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
			IL_16B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700156B RID: 5483
		// (get) Token: 0x06006628 RID: 26152 RVA: 0x001A4A70 File Offset: 0x001A2E70
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700156C RID: 5484
		// (get) Token: 0x06006629 RID: 26153 RVA: 0x001A4A78 File Offset: 0x001A2E78
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600662A RID: 26154 RVA: 0x001A4A80 File Offset: 0x001A2E80
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

		// Token: 0x0600662B RID: 26155 RVA: 0x001A4AF0 File Offset: 0x001A2EF0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600662C RID: 26156 RVA: 0x001A4AF7 File Offset: 0x001A2EF7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600662D RID: 26157 RVA: 0x001A4B00 File Offset: 0x001A2F00
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritOfDeadGeneralProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SpiritOfDeadGeneralProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F05 RID: 24325
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F06 RID: 24326
		internal SpiritOfDeadGeneralData <processData>__0;

		// Token: 0x04005F07 RID: 24327
		internal AdventureEventType evtType;

		// Token: 0x04005F08 RID: 24328
		internal object evtData;

		// Token: 0x04005F09 RID: 24329
		internal BattleDamage <damage>__1;

		// Token: 0x04005F0A RID: 24330
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F0B RID: 24331
		internal UnitTurnProgressUpdateEvent <push>__2;

		// Token: 0x04005F0C RID: 24332
		internal IEnumerator $locvar0;

		// Token: 0x04005F0D RID: 24333
		internal object <_>__3;

		// Token: 0x04005F0E RID: 24334
		internal IDisposable $locvar1;

		// Token: 0x04005F0F RID: 24335
		internal object $current;

		// Token: 0x04005F10 RID: 24336
		internal bool $disposing;

		// Token: 0x04005F11 RID: 24337
		internal int $PC;
	}
}
