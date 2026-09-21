using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000949 RID: 2377
public abstract class BossFightSequenceBase : GenericBattleSequenceBase
{
	// Token: 0x06004173 RID: 16755 RVA: 0x001AE683 File Offset: 0x001ACA83
	protected BossFightSequenceBase()
	{
	}

	// Token: 0x17000C47 RID: 3143
	// (get) Token: 0x06004174 RID: 16756
	public abstract UnitClass CorrespondingBossType { get; }

	// Token: 0x17000C48 RID: 3144
	// (get) Token: 0x06004175 RID: 16757
	public abstract AdventureType CorrespondingAdventureType { get; }

	// Token: 0x17000C49 RID: 3145
	// (get) Token: 0x06004176 RID: 16758
	public abstract List<int> CorrespondingAdventureLevels { get; }

	// Token: 0x17000C4A RID: 3146
	// (get) Token: 0x06004177 RID: 16759
	public abstract AdventureEventType TriggeredEventType { get; }

	// Token: 0x17000C4B RID: 3147
	// (get) Token: 0x06004178 RID: 16760
	public abstract List<ISequence> Sequences { get; }

	// Token: 0x17000C4C RID: 3148
	// (get) Token: 0x06004179 RID: 16761
	public abstract QuestIdentifier ActiveQuest { get; }

	// Token: 0x0600417A RID: 16762 RVA: 0x001AE68C File Offset: 0x001ACA8C
	public override bool MetRequirement(BroadcastEvent evt)
	{
		return evt.EventType == this.TriggeredEventType && evt.EventTriggeringUnit is EnemyBattleUnit && (evt.EventTriggeringUnit as EnemyBattleUnit).SlotSelection == AdventureEncounterSlotType.Boss && evt.EventTriggeringUnit.GetUnitType() == this.CorrespondingBossType && evt.EventTriggeringUnit.CurrentAdventure.AdventureType == this.CorrespondingAdventureType && this.CorrespondingAdventureLevels.Any((int l) => l == evt.EventTriggeringUnit.CurrentAdventure.LevelNumber) && base.QuestIsActive(this.ActiveQuest);
	}

	// Token: 0x0600417B RID: 16763 RVA: 0x001AE754 File Offset: 0x001ACB54
	public override IEnumerable Run(BroadcastEvent evt)
	{
		foreach (ISequence sequence in this.Sequences)
		{
			IEnumerator enumerator2 = sequence.RunSequence(evt, this).GetEnumerator();
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
		IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(evt.EventTriggeringUnit, AdventureEventType.BattleUnitSequenceCompleted, null)).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				object _2 = enumerator3.Current;
				yield return _2;
			}
		}
		finally
		{
			IDisposable disposable2;
			if ((disposable2 = (enumerator3 as IDisposable)) != null)
			{
				disposable2.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x02000FF1 RID: 4081
	[CompilerGenerated]
	private sealed class <MetRequirement>c__AnonStorey1
	{
		// Token: 0x06006765 RID: 26469 RVA: 0x001AE77E File Offset: 0x001ACB7E
		public <MetRequirement>c__AnonStorey1()
		{
		}

		// Token: 0x06006766 RID: 26470 RVA: 0x001AE786 File Offset: 0x001ACB86
		internal bool <>m__0(int l)
		{
			return l == this.evt.EventTriggeringUnit.CurrentAdventure.LevelNumber;
		}

		// Token: 0x04006155 RID: 24917
		internal BroadcastEvent evt;
	}

	// Token: 0x02000FF2 RID: 4082
	[CompilerGenerated]
	private sealed class <Run>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006767 RID: 26471 RVA: 0x001AE7A0 File Offset: 0x001ACBA0
		[DebuggerHidden]
		public <Run>c__Iterator0()
		{
		}

		// Token: 0x06006768 RID: 26472 RVA: 0x001AE7A8 File Offset: 0x001ACBA8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = this.Sequences.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_15F;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_5:
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
					sequence = enumerator.Current;
					enumerator2 = sequence.RunSequence(evt, this).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(evt.EventTriggeringUnit, AdventureEventType.BattleUnitSequenceCompleted, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_15F:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_2 = enumerator3.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015B1 RID: 5553
		// (get) Token: 0x06006769 RID: 26473 RVA: 0x001AE9C8 File Offset: 0x001ACDC8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015B2 RID: 5554
		// (get) Token: 0x0600676A RID: 26474 RVA: 0x001AE9D0 File Offset: 0x001ACDD0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600676B RID: 26475 RVA: 0x001AE9D8 File Offset: 0x001ACDD8
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600676C RID: 26476 RVA: 0x001AEAAC File Offset: 0x001ACEAC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600676D RID: 26477 RVA: 0x001AEAB3 File Offset: 0x001ACEB3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600676E RID: 26478 RVA: 0x001AEABC File Offset: 0x001ACEBC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BossFightSequenceBase.<Run>c__Iterator0 <Run>c__Iterator = new BossFightSequenceBase.<Run>c__Iterator0();
			<Run>c__Iterator.$this = this;
			<Run>c__Iterator.evt = evt;
			return <Run>c__Iterator;
		}

		// Token: 0x04006156 RID: 24918
		internal List<ISequence>.Enumerator $locvar0;

		// Token: 0x04006157 RID: 24919
		internal ISequence <sequence>__1;

		// Token: 0x04006158 RID: 24920
		internal BroadcastEvent evt;

		// Token: 0x04006159 RID: 24921
		internal IEnumerator $locvar1;

		// Token: 0x0400615A RID: 24922
		internal object <_>__2;

		// Token: 0x0400615B RID: 24923
		internal IDisposable $locvar2;

		// Token: 0x0400615C RID: 24924
		internal IEnumerator $locvar3;

		// Token: 0x0400615D RID: 24925
		internal object <_>__3;

		// Token: 0x0400615E RID: 24926
		internal IDisposable $locvar4;

		// Token: 0x0400615F RID: 24927
		internal BossFightSequenceBase $this;

		// Token: 0x04006160 RID: 24928
		internal object $current;

		// Token: 0x04006161 RID: 24929
		internal bool $disposing;

		// Token: 0x04006162 RID: 24930
		internal int $PC;
	}
}
