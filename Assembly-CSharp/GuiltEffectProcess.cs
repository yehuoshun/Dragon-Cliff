using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F1 RID: 2289
public class GuiltEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FF1 RID: 16369 RVA: 0x001974B0 File Offset: 0x001958B0
	public GuiltEffectProcess()
	{
	}

	// Token: 0x17000BA4 RID: 2980
	// (get) Token: 0x06003FF2 RID: 16370 RVA: 0x001974E3 File Offset: 0x001958E3
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BA5 RID: 2981
	// (get) Token: 0x06003FF3 RID: 16371 RVA: 0x001974EB File Offset: 0x001958EB
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003FF4 RID: 16372 RVA: 0x001974F4 File Offset: 0x001958F4
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts && specialEffectData is GuiltEffectData)
		{
			IEnumerable<IBattleUnit> playerUnits2 = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
			if (GuiltEffectProcess.<>f__mg$cache0 == null)
			{
				GuiltEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			List<IBattleUnit> playerUnits = playerUnits2.Where(GuiltEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>();
			GuiltEffectData data = specialEffectData as GuiltEffectData;
			foreach (IBattleUnit playerUnit in playerUnits)
			{
				IEnumerator enumerator2 = playerUnit.ApplySkillEffect(new GuiltEffect(data.HitRatingBoost, data.DirectDamageBoostRate, data.EffectHitReduction, playerUnit), false).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F91 RID: 12177
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Guilt;

	// Token: 0x04002F92 RID: 12178
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.BattleEncounterStarts
	};

	// Token: 0x04002F93 RID: 12179
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x02000F75 RID: 3957
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006416 RID: 25622 RVA: 0x0019751E File Offset: 0x0019591E
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006417 RID: 25623 RVA: 0x00197528 File Offset: 0x00195928
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts || !(specialEffectData is GuiltEffectData))
				{
					goto IL_1C1;
				}
				IEnumerable<IBattleUnit> playerUnits2 = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (GuiltEffectProcess.<>f__mg$cache0 == null)
				{
					GuiltEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				playerUnits = playerUnits2.Where(GuiltEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>();
				data = (specialEffectData as GuiltEffectData);
				enumerator = playerUnits.GetEnumerator();
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
				case 1u:
					Block_7:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					playerUnit = enumerator.Current;
					enumerator2 = playerUnit.ApplySkillEffect(new GuiltEffect(data.HitRatingBoost, data.DirectDamageBoostRate, data.EffectHitReduction, playerUnit), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1C1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014F5 RID: 5365
		// (get) Token: 0x06006418 RID: 25624 RVA: 0x0019771C File Offset: 0x00195B1C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014F6 RID: 5366
		// (get) Token: 0x06006419 RID: 25625 RVA: 0x00197724 File Offset: 0x00195B24
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600641A RID: 25626 RVA: 0x0019772C File Offset: 0x00195B2C
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
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600641B RID: 25627 RVA: 0x001977C0 File Offset: 0x00195BC0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600641C RID: 25628 RVA: 0x001977C7 File Offset: 0x00195BC7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600641D RID: 25629 RVA: 0x001977D0 File Offset: 0x00195BD0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GuiltEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new GuiltEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005BBC RID: 23484
		internal BroadcastEvent evt;

		// Token: 0x04005BBD RID: 23485
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BBE RID: 23486
		internal List<IBattleUnit> <playerUnits>__1;

		// Token: 0x04005BBF RID: 23487
		internal GuiltEffectData <data>__1;

		// Token: 0x04005BC0 RID: 23488
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005BC1 RID: 23489
		internal IBattleUnit <playerUnit>__2;

		// Token: 0x04005BC2 RID: 23490
		internal IEnumerator $locvar1;

		// Token: 0x04005BC3 RID: 23491
		internal object <_>__3;

		// Token: 0x04005BC4 RID: 23492
		internal IDisposable $locvar2;

		// Token: 0x04005BC5 RID: 23493
		internal object $current;

		// Token: 0x04005BC6 RID: 23494
		internal bool $disposing;

		// Token: 0x04005BC7 RID: 23495
		internal int $PC;
	}
}
