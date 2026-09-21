using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008ED RID: 2285
public class FocusEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FDF RID: 16351 RVA: 0x00196758 File Offset: 0x00194B58
	public FocusEffectProcess()
	{
	}

	// Token: 0x17000B9C RID: 2972
	// (get) Token: 0x06003FE0 RID: 16352 RVA: 0x0019678B File Offset: 0x00194B8B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B9D RID: 2973
	// (get) Token: 0x06003FE1 RID: 16353 RVA: 0x00196793 File Offset: 0x00194B93
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003FE2 RID: 16354 RVA: 0x0019679C File Offset: 0x00194B9C
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts && specialEffectData is FocusEffectData)
		{
			FocusEffectData data = specialEffectData as FocusEffectData;
			IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
			if (FocusEffectProcess.<>f__mg$cache0 == null)
			{
				FocusEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			foreach (IBattleUnit playerUnit in playerUnits.Where(FocusEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>())
			{
				IEnumerator enumerator2 = playerUnit.ApplySkillEffect(new FocusEffect(data.DamageBoostRate, data.DamageReductionRate, evt.EventTriggeringUnit), false).GetEnumerator();
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

	// Token: 0x04002F8D RID: 12173
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Focus;

	// Token: 0x04002F8E RID: 12174
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.BattleEncounterStarts
	};

	// Token: 0x04002F8F RID: 12175
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x02000F6F RID: 3951
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063F7 RID: 25591 RVA: 0x001967C6 File Offset: 0x00194BC6
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060063F8 RID: 25592 RVA: 0x001967D0 File Offset: 0x00194BD0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts || !(specialEffectData is FocusEffectData))
				{
					goto IL_1AF;
				}
				data = (specialEffectData as FocusEffectData);
				IEnumerable<IBattleUnit> playerUnits = evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits;
				if (FocusEffectProcess.<>f__mg$cache0 == null)
				{
					FocusEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				enumerator = playerUnits.Where(FocusEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>().GetEnumerator();
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
					enumerator2 = playerUnit.ApplySkillEffect(new FocusEffect(data.DamageBoostRate, data.DamageReductionRate, evt.EventTriggeringUnit), false).GetEnumerator();
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
			IL_1AF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014EF RID: 5359
		// (get) Token: 0x060063F9 RID: 25593 RVA: 0x001969B4 File Offset: 0x00194DB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014F0 RID: 5360
		// (get) Token: 0x060063FA RID: 25594 RVA: 0x001969BC File Offset: 0x00194DBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063FB RID: 25595 RVA: 0x001969C4 File Offset: 0x00194DC4
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

		// Token: 0x060063FC RID: 25596 RVA: 0x00196A58 File Offset: 0x00194E58
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063FD RID: 25597 RVA: 0x00196A5F File Offset: 0x00194E5F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063FE RID: 25598 RVA: 0x00196A68 File Offset: 0x00194E68
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FocusEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new FocusEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005B95 RID: 23445
		internal BroadcastEvent evt;

		// Token: 0x04005B96 RID: 23446
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B97 RID: 23447
		internal FocusEffectData <data>__1;

		// Token: 0x04005B98 RID: 23448
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005B99 RID: 23449
		internal IBattleUnit <playerUnit>__2;

		// Token: 0x04005B9A RID: 23450
		internal IEnumerator $locvar1;

		// Token: 0x04005B9B RID: 23451
		internal object <_>__3;

		// Token: 0x04005B9C RID: 23452
		internal IDisposable $locvar2;

		// Token: 0x04005B9D RID: 23453
		internal object $current;

		// Token: 0x04005B9E RID: 23454
		internal bool $disposing;

		// Token: 0x04005B9F RID: 23455
		internal int $PC;
	}
}
