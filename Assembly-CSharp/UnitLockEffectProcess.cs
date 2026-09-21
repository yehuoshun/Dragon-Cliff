using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093D RID: 2365
public class UnitLockEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600414D RID: 16717 RVA: 0x001AC338 File Offset: 0x001AA738
	public UnitLockEffectProcess()
	{
	}

	// Token: 0x17000C39 RID: 3129
	// (get) Token: 0x0600414E RID: 16718 RVA: 0x001AC340 File Offset: 0x001AA740
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.UnitLock;
		}
	}

	// Token: 0x17000C3A RID: 3130
	// (get) Token: 0x0600414F RID: 16719 RVA: 0x001AC348 File Offset: 0x001AA748
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.EncounterSetupCompleted
			};
		}
	}

	// Token: 0x06004150 RID: 16720 RVA: 0x001AC364 File Offset: 0x001AA764
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.EncounterSetupCompleted && specialEffectData is UnitLockData)
		{
			UnitLockData data = specialEffectData as UnitLockData;
			List<IBattleUnit> players = (from s in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
			select s).ToList<IBattleUnit>();
			players.Shuffle<IBattleUnit>();
			List<IBattleUnit> toSilience = players.Take(data.NumberOfUnits).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in toSilience)
			{
				IEnumerator enumerator2 = LockTimeEffect.AddFearSeconds(battleUnit, 300f, evt.EventTriggeringUnit.CurrentEncounter.EnemyUnits.FirstOrDefault<IBattleUnit>(), false).GetEnumerator();
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

	// Token: 0x02000FE4 RID: 4068
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006711 RID: 26385 RVA: 0x001AC38E File Offset: 0x001AA78E
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006712 RID: 26386 RVA: 0x001AC398 File Offset: 0x001AA798
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.EncounterSetupCompleted || !(specialEffectData is UnitLockData))
				{
					goto IL_1E0;
				}
				data = (specialEffectData as UnitLockData);
				players = (from s in evt.EventTriggeringUnit.CurrentEncounter.PlayerUnits
				select s).ToList<IBattleUnit>();
				players.Shuffle<IBattleUnit>();
				toSilience = players.Take(data.NumberOfUnits).ToList<IBattleUnit>();
				enumerator = toSilience.GetEnumerator();
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
					battleUnit = enumerator.Current;
					enumerator2 = LockTimeEffect.AddFearSeconds(battleUnit, 300f, evt.EventTriggeringUnit.CurrentEncounter.EnemyUnits.FirstOrDefault<IBattleUnit>(), false).GetEnumerator();
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
			IL_1E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700159F RID: 5535
		// (get) Token: 0x06006713 RID: 26387 RVA: 0x001AC5AC File Offset: 0x001AA9AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015A0 RID: 5536
		// (get) Token: 0x06006714 RID: 26388 RVA: 0x001AC5B4 File Offset: 0x001AA9B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006715 RID: 26389 RVA: 0x001AC5BC File Offset: 0x001AA9BC
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

		// Token: 0x06006716 RID: 26390 RVA: 0x001AC650 File Offset: 0x001AAA50
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006717 RID: 26391 RVA: 0x001AC657 File Offset: 0x001AAA57
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006718 RID: 26392 RVA: 0x001AC660 File Offset: 0x001AAA60
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitLockEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new UnitLockEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x06006719 RID: 26393 RVA: 0x001AC6A0 File Offset: 0x001AAAA0
		private static IBattleUnit <>m__0(IBattleUnit s)
		{
			return s;
		}

		// Token: 0x040060D1 RID: 24785
		internal BroadcastEvent evt;

		// Token: 0x040060D2 RID: 24786
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060D3 RID: 24787
		internal UnitLockData <data>__1;

		// Token: 0x040060D4 RID: 24788
		internal List<IBattleUnit> <players>__1;

		// Token: 0x040060D5 RID: 24789
		internal List<IBattleUnit> <toSilience>__1;

		// Token: 0x040060D6 RID: 24790
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040060D7 RID: 24791
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040060D8 RID: 24792
		internal IEnumerator $locvar1;

		// Token: 0x040060D9 RID: 24793
		internal object <_>__3;

		// Token: 0x040060DA RID: 24794
		internal IDisposable $locvar2;

		// Token: 0x040060DB RID: 24795
		internal object $current;

		// Token: 0x040060DC RID: 24796
		internal bool $disposing;

		// Token: 0x040060DD RID: 24797
		internal int $PC;

		// Token: 0x040060DE RID: 24798
		private static Func<IBattleUnit, IBattleUnit> <>f__am$cache0;
	}
}
