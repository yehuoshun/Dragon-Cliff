using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000946 RID: 2374
public class BattleDialogueModule : ISequence
{
	// Token: 0x06004167 RID: 16743 RVA: 0x001ADB5E File Offset: 0x001ABF5E
	public BattleDialogueModule()
	{
	}

	// Token: 0x17000C43 RID: 3139
	// (get) Token: 0x06004168 RID: 16744 RVA: 0x001ADB66 File Offset: 0x001ABF66
	// (set) Token: 0x06004169 RID: 16745 RVA: 0x001ADB6E File Offset: 0x001ABF6E
	public BattleDialogueSideType Side
	{
		[CompilerGenerated]
		get
		{
			return this.<Side>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Side>k__BackingField = value;
		}
	}

	// Token: 0x17000C44 RID: 3140
	// (get) Token: 0x0600416A RID: 16746 RVA: 0x001ADB77 File Offset: 0x001ABF77
	// (set) Token: 0x0600416B RID: 16747 RVA: 0x001ADB7F File Offset: 0x001ABF7F
	public UnitClass? GuarranteedClass
	{
		[CompilerGenerated]
		get
		{
			return this.<GuarranteedClass>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GuarranteedClass>k__BackingField = value;
		}
	}

	// Token: 0x17000C45 RID: 3141
	// (get) Token: 0x0600416C RID: 16748 RVA: 0x001ADB88 File Offset: 0x001ABF88
	// (set) Token: 0x0600416D RID: 16749 RVA: 0x001ADB90 File Offset: 0x001ABF90
	public List<DialogIdentifier> DialogIdentifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<DialogIdentifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DialogIdentifiers>k__BackingField = value;
		}
	}

	// Token: 0x0600416E RID: 16750 RVA: 0x001ADB9C File Offset: 0x001ABF9C
	public IEnumerable RunSequence(BroadcastEvent evt, GenericBattleSequenceBase runner)
	{
		BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
		BossFightSequenceBase bossFightRunner = runner as BossFightSequenceBase;
		if (battleEncounter != null && bossFightRunner != null)
		{
			IBattleUnit relatedBoss = battleEncounter.EnemyUnits.FirstOrDefault((IBattleUnit e) => e.Status == BattleUnitStatus.Active && e.IsBoss() && e.GetUnitType() == bossFightRunner.CorrespondingBossType);
			List<IBattleUnit> minions = (from e in battleEncounter.EnemyUnits
			where e.Status == BattleUnitStatus.Active && !e.IsBoss()
			select e).ToList<IBattleUnit>();
			List<IBattleUnit> adventurers = (from p in battleEncounter.PlayerUnits
			where p.Status == BattleUnitStatus.Active
			select p).ToList<IBattleUnit>();
			if (this.Side == BattleDialogueSideType.Adventurers && adventurers.Any<IBattleUnit>())
			{
				IBattleUnit speaker = null;
				if (this.GuarranteedClass != null && adventurers.Any((IBattleUnit a) => a.GetUnitType() == this.GuarranteedClass))
				{
					speaker = adventurers.First((IBattleUnit a) => a.GetUnitType() == this.GuarranteedClass);
				}
				else
				{
					speaker = adventurers.First<IBattleUnit>();
				}
				foreach (DialogIdentifier dialogueDialogIdentifier in this.DialogIdentifiers)
				{
					IEnumerator enumerator2 = speaker.Speaks(dialogueDialogIdentifier).GetEnumerator();
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
			else if (this.Side == BattleDialogueSideType.Boss && relatedBoss != null)
			{
				foreach (DialogIdentifier dialogueDialogIdentifier2 in this.DialogIdentifiers)
				{
					IEnumerator enumerator4 = relatedBoss.Speaks(dialogueDialogIdentifier2).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _2 = enumerator4.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
			else if (this.Side == BattleDialogueSideType.Minion && minions.Any<IBattleUnit>())
			{
				IBattleUnit speaker2 = minions.First<IBattleUnit>();
				foreach (DialogIdentifier dialogueDialogIdentifier3 in this.DialogIdentifiers)
				{
					IEnumerator enumerator6 = speaker2.Speaks(dialogueDialogIdentifier3).GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _3 = enumerator6.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator6 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04003116 RID: 12566
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleDialogueSideType <Side>k__BackingField;

	// Token: 0x04003117 RID: 12567
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass? <GuarranteedClass>k__BackingField;

	// Token: 0x04003118 RID: 12568
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogIdentifier> <DialogIdentifiers>k__BackingField;

	// Token: 0x02000FEE RID: 4078
	[CompilerGenerated]
	private sealed class <RunSequence>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600674F RID: 26447 RVA: 0x001ADBCD File Offset: 0x001ABFCD
		[DebuggerHidden]
		public <RunSequence>c__Iterator0()
		{
		}

		// Token: 0x06006750 RID: 26448 RVA: 0x001ADBD8 File Offset: 0x001ABFD8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				battleEncounter = (evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter);
				BossFightSequenceBase bossFightRunner = runner as BossFightSequenceBase;
				if (battleEncounter == null || bossFightRunner == null)
				{
					goto IL_52B;
				}
				relatedBoss = battleEncounter.EnemyUnits.FirstOrDefault((IBattleUnit e) => e.Status == BattleUnitStatus.Active && e.IsBoss() && e.GetUnitType() == bossFightRunner.CorrespondingBossType);
				minions = (from e in battleEncounter.EnemyUnits
				where e.Status == BattleUnitStatus.Active && !e.IsBoss()
				select e).ToList<IBattleUnit>();
				adventurers = (from p in battleEncounter.PlayerUnits
				where p.Status == BattleUnitStatus.Active
				select p).ToList<IBattleUnit>();
				if (base.Side == BattleDialogueSideType.Adventurers && adventurers.Any<IBattleUnit>())
				{
					speaker = null;
					if (base.GuarranteedClass != null && adventurers.Any((IBattleUnit a) => a.GetUnitType() == this.GuarranteedClass))
					{
						speaker = adventurers.First((IBattleUnit a) => a.GetUnitType() == this.GuarranteedClass);
					}
					else
					{
						speaker = adventurers.First<IBattleUnit>();
					}
					enumerator = base.DialogIdentifiers.GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (base.Side == BattleDialogueSideType.Boss && relatedBoss != null)
					{
						enumerator3 = base.DialogIdentifiers.GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
					if (base.Side == BattleDialogueSideType.Minion && minions.Any<IBattleUnit>())
					{
						speaker2 = minions.First<IBattleUnit>();
						enumerator5 = base.DialogIdentifiers.GetEnumerator();
						num = 4294967293u;
						goto Block_16;
					}
					goto IL_52B;
				}
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_2FF;
			case 3u:
				goto IL_43D;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_18:
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
					dialogueDialogIdentifier = enumerator.Current;
					enumerator2 = speaker.Speaks(dialogueDialogIdentifier).GetEnumerator();
					num = 4294967293u;
					goto Block_18;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			goto IL_52B;
			Block_13:
			try
			{
				IL_2FF:
				switch (num)
				{
				case 2u:
					Block_29:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_2 = enumerator4.Current;
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
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator3.MoveNext())
				{
					dialogueDialogIdentifier2 = enumerator3.Current;
					enumerator4 = relatedBoss.Speaks(dialogueDialogIdentifier2).GetEnumerator();
					num = 4294967293u;
					goto Block_29;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			goto IL_52B;
			Block_16:
			try
			{
				IL_43D:
				switch (num)
				{
				case 3u:
					Block_40:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_3 = enumerator6.Current;
							this.$current = _3;
							if (!this.$disposing)
							{
								this.$PC = 3;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator5.MoveNext())
				{
					dialogueDialogIdentifier3 = enumerator5.Current;
					enumerator6 = speaker2.Speaks(dialogueDialogIdentifier3).GetEnumerator();
					num = 4294967293u;
					goto Block_40;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			IL_52B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015AD RID: 5549
		// (get) Token: 0x06006751 RID: 26449 RVA: 0x001AE168 File Offset: 0x001AC568
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015AE RID: 5550
		// (get) Token: 0x06006752 RID: 26450 RVA: 0x001AE170 File Offset: 0x001AC570
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006753 RID: 26451 RVA: 0x001AE178 File Offset: 0x001AC578
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
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator6 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006754 RID: 26452 RVA: 0x001AE2D0 File Offset: 0x001AC6D0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006755 RID: 26453 RVA: 0x001AE2D7 File Offset: 0x001AC6D7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006756 RID: 26454 RVA: 0x001AE2E0 File Offset: 0x001AC6E0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleDialogueModule.<RunSequence>c__Iterator0 <RunSequence>c__Iterator = new BattleDialogueModule.<RunSequence>c__Iterator0();
			<RunSequence>c__Iterator.$this = this;
			<RunSequence>c__Iterator.evt = evt;
			<RunSequence>c__Iterator.runner = runner;
			return <RunSequence>c__Iterator;
		}

		// Token: 0x06006757 RID: 26455 RVA: 0x001AE32C File Offset: 0x001AC72C
		private static bool <>m__0(IBattleUnit e)
		{
			return e.Status == BattleUnitStatus.Active && !e.IsBoss();
		}

		// Token: 0x06006758 RID: 26456 RVA: 0x001AE346 File Offset: 0x001AC746
		private static bool <>m__1(IBattleUnit p)
		{
			return p.Status == BattleUnitStatus.Active;
		}

		// Token: 0x0400612D RID: 24877
		internal BroadcastEvent evt;

		// Token: 0x0400612E RID: 24878
		internal BattleEncounter <battleEncounter>__0;

		// Token: 0x0400612F RID: 24879
		internal GenericBattleSequenceBase runner;

		// Token: 0x04006130 RID: 24880
		internal IBattleUnit <relatedBoss>__1;

		// Token: 0x04006131 RID: 24881
		internal List<IBattleUnit> <minions>__1;

		// Token: 0x04006132 RID: 24882
		internal List<IBattleUnit> <adventurers>__1;

		// Token: 0x04006133 RID: 24883
		internal IBattleUnit <speaker>__2;

		// Token: 0x04006134 RID: 24884
		internal List<DialogIdentifier>.Enumerator $locvar0;

		// Token: 0x04006135 RID: 24885
		internal DialogIdentifier <dialogueDialogIdentifier>__3;

		// Token: 0x04006136 RID: 24886
		internal IEnumerator $locvar1;

		// Token: 0x04006137 RID: 24887
		internal object <_>__4;

		// Token: 0x04006138 RID: 24888
		internal IDisposable $locvar2;

		// Token: 0x04006139 RID: 24889
		internal List<DialogIdentifier>.Enumerator $locvar3;

		// Token: 0x0400613A RID: 24890
		internal DialogIdentifier <dialogueDialogIdentifier>__5;

		// Token: 0x0400613B RID: 24891
		internal IEnumerator $locvar4;

		// Token: 0x0400613C RID: 24892
		internal object <_>__6;

		// Token: 0x0400613D RID: 24893
		internal IDisposable $locvar5;

		// Token: 0x0400613E RID: 24894
		internal IBattleUnit <speaker>__7;

		// Token: 0x0400613F RID: 24895
		internal List<DialogIdentifier>.Enumerator $locvar6;

		// Token: 0x04006140 RID: 24896
		internal DialogIdentifier <dialogueDialogIdentifier>__8;

		// Token: 0x04006141 RID: 24897
		internal IEnumerator $locvar7;

		// Token: 0x04006142 RID: 24898
		internal object <_>__9;

		// Token: 0x04006143 RID: 24899
		internal IDisposable $locvar8;

		// Token: 0x04006144 RID: 24900
		internal BattleDialogueModule $this;

		// Token: 0x04006145 RID: 24901
		internal object $current;

		// Token: 0x04006146 RID: 24902
		internal bool $disposing;

		// Token: 0x04006147 RID: 24903
		internal int $PC;

		// Token: 0x04006148 RID: 24904
		private BattleDialogueModule.<RunSequence>c__Iterator0.<RunSequence>c__AnonStorey1 $locvar9;

		// Token: 0x04006149 RID: 24905
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x0400614A RID: 24906
		private static Func<IBattleUnit, bool> <>f__am$cache1;

		// Token: 0x02000FEF RID: 4079
		private sealed class <RunSequence>c__AnonStorey1
		{
			// Token: 0x06006759 RID: 26457 RVA: 0x001AE351 File Offset: 0x001AC751
			public <RunSequence>c__AnonStorey1()
			{
			}

			// Token: 0x0600675A RID: 26458 RVA: 0x001AE359 File Offset: 0x001AC759
			internal bool <>m__0(IBattleUnit e)
			{
				return e.Status == BattleUnitStatus.Active && e.IsBoss() && e.GetUnitType() == this.bossFightRunner.CorrespondingBossType;
			}

			// Token: 0x0600675B RID: 26459 RVA: 0x001AE388 File Offset: 0x001AC788
			internal bool <>m__1(IBattleUnit a)
			{
				return a.GetUnitType() == this.<>f__ref$0.$this.GuarranteedClass;
			}

			// Token: 0x0600675C RID: 26460 RVA: 0x001AE3C0 File Offset: 0x001AC7C0
			internal bool <>m__2(IBattleUnit a)
			{
				return a.GetUnitType() == this.<>f__ref$0.$this.GuarranteedClass;
			}

			// Token: 0x0400614B RID: 24907
			internal BossFightSequenceBase bossFightRunner;

			// Token: 0x0400614C RID: 24908
			internal BattleDialogueModule.<RunSequence>c__Iterator0 <>f__ref$0;
		}
	}
}
