using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000526 RID: 1318
public class StunOnHitProcessor : AttributeProcessBase
{
	// Token: 0x060026B6 RID: 9910 RVA: 0x00114A3B File Offset: 0x00112E3B
	public StunOnHitProcessor()
	{
	}

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x060026B7 RID: 9911 RVA: 0x00114A43 File Offset: 0x00112E43
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.StunOnHit;
		}
	}

	// Token: 0x060026B8 RID: 9912 RVA: 0x00114A4C File Offset: 0x00112E4C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x060026B9 RID: 9913 RVA: 0x00114A68 File Offset: 0x00112E68
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage && eventTriggerUnit == listener)
		{
			BattleDamage battleDamage = data as BattleDamage;
			foreach (DamageComponent damage in battleDamage.Damages)
			{
				if (!damage.IsMissed && damage.IsDirectDamage)
				{
					double rate = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.StunOnHit, AttributeRetrievalLevel.Skill);
					if ((double)UnityEngine.Random.value <= rate)
					{
						IEnumerator enumerator2 = LockTimeEffect.AddStunSeconds(listener, 2f, damage.Dealer, false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x02000DBC RID: 3516
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058C3 RID: 22723 RVA: 0x00114AA1 File Offset: 0x00112EA1
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058C4 RID: 22724 RVA: 0x00114AAC File Offset: 0x00112EAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage || eventTriggerUnit != listener)
				{
					goto IL_1B1;
				}
				battleDamage = (data as BattleDamage);
				enumerator = battleDamage.Damages.GetEnumerator();
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
				case 1u:
					Block_9:
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
				while (enumerator.MoveNext())
				{
					damage = enumerator.Current;
					if (!damage.IsMissed && damage.IsDirectDamage)
					{
						rate = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.StunOnHit, AttributeRetrievalLevel.Skill);
						if ((double)UnityEngine.Random.value <= rate)
						{
							enumerator2 = LockTimeEffect.AddStunSeconds(listener, 2f, damage.Dealer, false).GetEnumerator();
							num = 4294967293u;
							goto Block_9;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1B1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001292 RID: 4754
		// (get) Token: 0x060058C5 RID: 22725 RVA: 0x00114CA8 File Offset: 0x001130A8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001293 RID: 4755
		// (get) Token: 0x060058C6 RID: 22726 RVA: 0x00114CB0 File Offset: 0x001130B0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058C7 RID: 22727 RVA: 0x00114CB8 File Offset: 0x001130B8
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

		// Token: 0x060058C8 RID: 22728 RVA: 0x00114D4C File Offset: 0x0011314C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058C9 RID: 22729 RVA: 0x00114D53 File Offset: 0x00113153
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058CA RID: 22730 RVA: 0x00114D5C File Offset: 0x0011315C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StunOnHitProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new StunOnHitProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.data = data;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x040048AA RID: 18602
		internal AdventureEventType eventType;

		// Token: 0x040048AB RID: 18603
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040048AC RID: 18604
		internal IBattleUnit listener;

		// Token: 0x040048AD RID: 18605
		internal object data;

		// Token: 0x040048AE RID: 18606
		internal BattleDamage <battleDamage>__1;

		// Token: 0x040048AF RID: 18607
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x040048B0 RID: 18608
		internal DamageComponent <damage>__2;

		// Token: 0x040048B1 RID: 18609
		internal double <rate>__3;

		// Token: 0x040048B2 RID: 18610
		internal IEnumerator $locvar1;

		// Token: 0x040048B3 RID: 18611
		internal object <_>__4;

		// Token: 0x040048B4 RID: 18612
		internal IDisposable $locvar2;

		// Token: 0x040048B5 RID: 18613
		internal object $current;

		// Token: 0x040048B6 RID: 18614
		internal bool $disposing;

		// Token: 0x040048B7 RID: 18615
		internal int $PC;
	}
}
