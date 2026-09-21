using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200049C RID: 1180
public static class SkillEffectExtensions
{
	// Token: 0x06002316 RID: 8982 RVA: 0x00100F14 File Offset: 0x000FF314
	public static IEnumerable CollectTurnEvent(this BattleEffectBase effect, AdventureEventType evt)
	{
		if (evt == AdventureEventType.UnitEntersTurn || evt == AdventureEventType.UnitCompletesTurn)
		{
			int? originalRemainingTurns = effect.NumberOfRemainingTurns();
			effect.TurnEventsCollected.Add(evt);
			int? updatedRemainingTurns = effect.NumberOfRemainingTurns();
			if (originalRemainingTurns != null && updatedRemainingTurns != null && (originalRemainingTurns.GetValueOrDefault() != updatedRemainingTurns.GetValueOrDefault() || (originalRemainingTurns != null ^ updatedRemainingTurns != null)))
			{
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effect.EffectSource.SourceUnit, AdventureEventType.BattleEffectTurnProgresses, effect)).GetEnumerator();
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

	// Token: 0x02000D83 RID: 3459
	[CompilerGenerated]
	private sealed class <CollectTurnEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060057EA RID: 22506 RVA: 0x00100F3E File Offset: 0x000FF33E
		[DebuggerHidden]
		public <CollectTurnEvent>c__Iterator0()
		{
		}

		// Token: 0x060057EB RID: 22507 RVA: 0x00100F48 File Offset: 0x000FF348
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt != AdventureEventType.UnitEntersTurn && evt != AdventureEventType.UnitCompletesTurn)
				{
					goto IL_182;
				}
				originalRemainingTurns = effect.NumberOfRemainingTurns();
				effect.TurnEventsCollected.Add(evt);
				updatedRemainingTurns = effect.NumberOfRemainingTurns();
				if (originalRemainingTurns == null || updatedRemainingTurns == null || (originalRemainingTurns.GetValueOrDefault() == updatedRemainingTurns.GetValueOrDefault() && !(originalRemainingTurns != null ^ updatedRemainingTurns != null)))
				{
					goto IL_182;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effect.EffectSource.SourceUnit, AdventureEventType.BattleEffectTurnProgresses, effect)).GetEnumerator();
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
			IL_182:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001272 RID: 4722
		// (get) Token: 0x060057EC RID: 22508 RVA: 0x001010F4 File Offset: 0x000FF4F4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001273 RID: 4723
		// (get) Token: 0x060057ED RID: 22509 RVA: 0x001010FC File Offset: 0x000FF4FC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060057EE RID: 22510 RVA: 0x00101104 File Offset: 0x000FF504
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

		// Token: 0x060057EF RID: 22511 RVA: 0x00101174 File Offset: 0x000FF574
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060057F0 RID: 22512 RVA: 0x0010117B File Offset: 0x000FF57B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060057F1 RID: 22513 RVA: 0x00101184 File Offset: 0x000FF584
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SkillEffectExtensions.<CollectTurnEvent>c__Iterator0 <CollectTurnEvent>c__Iterator = new SkillEffectExtensions.<CollectTurnEvent>c__Iterator0();
			<CollectTurnEvent>c__Iterator.evt = evt;
			<CollectTurnEvent>c__Iterator.effect = effect;
			return <CollectTurnEvent>c__Iterator;
		}

		// Token: 0x040047AA RID: 18346
		internal AdventureEventType evt;

		// Token: 0x040047AB RID: 18347
		internal BattleEffectBase effect;

		// Token: 0x040047AC RID: 18348
		internal int? <originalRemainingTurns>__1;

		// Token: 0x040047AD RID: 18349
		internal int? <updatedRemainingTurns>__1;

		// Token: 0x040047AE RID: 18350
		internal IEnumerator $locvar0;

		// Token: 0x040047AF RID: 18351
		internal object <_>__2;

		// Token: 0x040047B0 RID: 18352
		internal IDisposable $locvar1;

		// Token: 0x040047B1 RID: 18353
		internal object $current;

		// Token: 0x040047B2 RID: 18354
		internal bool $disposing;

		// Token: 0x040047B3 RID: 18355
		internal int $PC;
	}
}
