using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000437 RID: 1079
public abstract class BattleSelectorBase
{
	// Token: 0x06001E42 RID: 7746 RVA: 0x000D4DE4 File Offset: 0x000D31E4
	protected BattleSelectorBase()
	{
	}

	// Token: 0x06001E43 RID: 7747 RVA: 0x000D4DEC File Offset: 0x000D31EC
	public bool IsResolved()
	{
		return this.Resolved;
	}

	// Token: 0x06001E44 RID: 7748
	protected abstract IEnumerable RunConsequence(IBattleOption option, BattleEncounter encounter);

	// Token: 0x06001E45 RID: 7749
	public abstract List<IBattleOption> GetOptions();

	// Token: 0x06001E46 RID: 7750 RVA: 0x000D4DF4 File Offset: 0x000D31F4
	public IEnumerable ResolveOption(IBattleOption type)
	{
		this.Resolved = true;
		Adventure adventure = GameWorld.instance.GetCurrentAdventure();
		if (adventure != null)
		{
			BattleEncounter battleEncounter = adventure.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				IEnumerator enumerator = this.RunConsequence(type, battleEncounter).GetEnumerator();
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

	// Token: 0x06001E47 RID: 7751 RVA: 0x000D4E20 File Offset: 0x000D3220
	public IEnumerable Start(IBattleUnit selectorTriggeringUnit)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(selectorTriggeringUnit, AdventureEventType.BattleEncounterOptionsTriggered, this)).GetEnumerator();
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
		while (!this.IsResolved())
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04001BEB RID: 7147
	private bool Resolved;

	// Token: 0x02000CEC RID: 3308
	[CompilerGenerated]
	private sealed class <ResolveOption>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005583 RID: 21891 RVA: 0x000D4E4A File Offset: 0x000D324A
		[DebuggerHidden]
		public <ResolveOption>c__Iterator0()
		{
		}

		// Token: 0x06005584 RID: 21892 RVA: 0x000D4E54 File Offset: 0x000D3254
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.Resolved = true;
				adventure = GameWorld.instance.GetCurrentAdventure();
				if (adventure == null)
				{
					goto IL_112;
				}
				battleEncounter = (adventure.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_112;
				}
				enumerator = this.RunConsequence(type, battleEncounter).GetEnumerator();
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
			IL_112:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001226 RID: 4646
		// (get) Token: 0x06005585 RID: 21893 RVA: 0x000D4F90 File Offset: 0x000D3390
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001227 RID: 4647
		// (get) Token: 0x06005586 RID: 21894 RVA: 0x000D4F98 File Offset: 0x000D3398
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005587 RID: 21895 RVA: 0x000D4FA0 File Offset: 0x000D33A0
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

		// Token: 0x06005588 RID: 21896 RVA: 0x000D5010 File Offset: 0x000D3410
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005589 RID: 21897 RVA: 0x000D5017 File Offset: 0x000D3417
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600558A RID: 21898 RVA: 0x000D5020 File Offset: 0x000D3420
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleSelectorBase.<ResolveOption>c__Iterator0 <ResolveOption>c__Iterator = new BattleSelectorBase.<ResolveOption>c__Iterator0();
			<ResolveOption>c__Iterator.$this = this;
			<ResolveOption>c__Iterator.type = type;
			return <ResolveOption>c__Iterator;
		}

		// Token: 0x0400441A RID: 17434
		internal Adventure <adventure>__0;

		// Token: 0x0400441B RID: 17435
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x0400441C RID: 17436
		internal IBattleOption type;

		// Token: 0x0400441D RID: 17437
		internal IEnumerator $locvar0;

		// Token: 0x0400441E RID: 17438
		internal object <_>__2;

		// Token: 0x0400441F RID: 17439
		internal IDisposable $locvar1;

		// Token: 0x04004420 RID: 17440
		internal BattleSelectorBase $this;

		// Token: 0x04004421 RID: 17441
		internal object $current;

		// Token: 0x04004422 RID: 17442
		internal bool $disposing;

		// Token: 0x04004423 RID: 17443
		internal int $PC;
	}

	// Token: 0x02000CED RID: 3309
	[CompilerGenerated]
	private sealed class <Start>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600558B RID: 21899 RVA: 0x000D5060 File Offset: 0x000D3460
		[DebuggerHidden]
		public <Start>c__Iterator1()
		{
		}

		// Token: 0x0600558C RID: 21900 RVA: 0x000D5068 File Offset: 0x000D3468
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(selectorTriggeringUnit, AdventureEventType.BattleEncounterOptionsTriggered, this)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_F4;
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
			IL_F4:
			if (!base.IsResolved())
			{
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001228 RID: 4648
		// (get) Token: 0x0600558D RID: 21901 RVA: 0x000D5194 File Offset: 0x000D3594
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001229 RID: 4649
		// (get) Token: 0x0600558E RID: 21902 RVA: 0x000D519C File Offset: 0x000D359C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600558F RID: 21903 RVA: 0x000D51A4 File Offset: 0x000D35A4
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

		// Token: 0x06005590 RID: 21904 RVA: 0x000D5218 File Offset: 0x000D3618
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005591 RID: 21905 RVA: 0x000D521F File Offset: 0x000D361F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005592 RID: 21906 RVA: 0x000D5228 File Offset: 0x000D3628
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleSelectorBase.<Start>c__Iterator1 <Start>c__Iterator = new BattleSelectorBase.<Start>c__Iterator1();
			<Start>c__Iterator.$this = this;
			<Start>c__Iterator.selectorTriggeringUnit = selectorTriggeringUnit;
			return <Start>c__Iterator;
		}

		// Token: 0x04004424 RID: 17444
		internal IBattleUnit selectorTriggeringUnit;

		// Token: 0x04004425 RID: 17445
		internal IEnumerator $locvar0;

		// Token: 0x04004426 RID: 17446
		internal object <_>__1;

		// Token: 0x04004427 RID: 17447
		internal IDisposable $locvar1;

		// Token: 0x04004428 RID: 17448
		internal BattleSelectorBase $this;

		// Token: 0x04004429 RID: 17449
		internal object $current;

		// Token: 0x0400442A RID: 17450
		internal bool $disposing;

		// Token: 0x0400442B RID: 17451
		internal int $PC;
	}
}
