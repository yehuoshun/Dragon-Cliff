using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200090C RID: 2316
public class PoisonMistEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004067 RID: 16487 RVA: 0x0019E8C4 File Offset: 0x0019CCC4
	public PoisonMistEffectProcess()
	{
	}

	// Token: 0x17000BD8 RID: 3032
	// (get) Token: 0x06004068 RID: 16488 RVA: 0x0019E8D4 File Offset: 0x0019CCD4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BD9 RID: 3033
	// (get) Token: 0x06004069 RID: 16489 RVA: 0x0019E8DC File Offset: 0x0019CCDC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x0600406A RID: 16490 RVA: 0x0019E8E4 File Offset: 0x0019CCE4
	public override IEnumerable AsAdventureEffectPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IEncounter encounter)
	{
		PoisonMistData data = specialEffectData as PoisonMistData;
		if (data != null && (double)UnityEngine.Random.value <= data.Chance)
		{
			BattleEncounter battleEncounter = encounter as BattleEncounter;
			if (battleEncounter != null)
			{
				List<IBattleUnit> friendlyUnits = (from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				List<IBattleUnit> enemyUnits = (from u in battleEncounter.EnemyUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				IBattleUnit effectSourceUnit = enemyUnits.FirstOrDefault<IBattleUnit>();
				foreach (IBattleUnit friendlyUnit in friendlyUnits)
				{
					IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(friendlyUnit, effectSourceUnit ?? friendlyUnit, data.DamageValue, (int)data.LastingSeconds, OutputType.Poison).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002FA2 RID: 12194
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.PoisonMist;

	// Token: 0x02000F99 RID: 3993
	[CompilerGenerated]
	private sealed class <AsAdventureEffectPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006522 RID: 25890 RVA: 0x0019E90E File Offset: 0x0019CD0E
		[DebuggerHidden]
		public <AsAdventureEffectPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006523 RID: 25891 RVA: 0x0019E918 File Offset: 0x0019CD18
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as PoisonMistData);
				if (data == null || (double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_219;
				}
				battleEncounter = (encounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_219;
				}
				friendlyUnits = (from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				enemyUnits = (from u in battleEncounter.EnemyUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				effectSourceUnit = enemyUnits.FirstOrDefault<IBattleUnit>();
				enumerator = friendlyUnits.GetEnumerator();
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
					Block_10:
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
					friendlyUnit = enumerator.Current;
					enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(friendlyUnit, effectSourceUnit ?? friendlyUnit, data.DamageValue, (int)data.LastingSeconds, OutputType.Poison).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_219:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001531 RID: 5425
		// (get) Token: 0x06006524 RID: 25892 RVA: 0x0019EB64 File Offset: 0x0019CF64
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001532 RID: 5426
		// (get) Token: 0x06006525 RID: 25893 RVA: 0x0019EB6C File Offset: 0x0019CF6C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006526 RID: 25894 RVA: 0x0019EB74 File Offset: 0x0019CF74
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

		// Token: 0x06006527 RID: 25895 RVA: 0x0019EC08 File Offset: 0x0019D008
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006528 RID: 25896 RVA: 0x0019EC0F File Offset: 0x0019D00F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006529 RID: 25897 RVA: 0x0019EC18 File Offset: 0x0019D018
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonMistEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator0 <AsAdventureEffectPerSecondProcess>c__Iterator = new PoisonMistEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator0();
			<AsAdventureEffectPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsAdventureEffectPerSecondProcess>c__Iterator.encounter = encounter;
			return <AsAdventureEffectPerSecondProcess>c__Iterator;
		}

		// Token: 0x0600652A RID: 25898 RVA: 0x0019EC58 File Offset: 0x0019D058
		private static bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x0600652B RID: 25899 RVA: 0x0019EC63 File Offset: 0x0019D063
		private static bool <>m__1(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04005D7F RID: 23935
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D80 RID: 23936
		internal PoisonMistData <data>__0;

		// Token: 0x04005D81 RID: 23937
		internal IEncounter encounter;

		// Token: 0x04005D82 RID: 23938
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04005D83 RID: 23939
		internal List<IBattleUnit> <friendlyUnits>__2;

		// Token: 0x04005D84 RID: 23940
		internal List<IBattleUnit> <enemyUnits>__2;

		// Token: 0x04005D85 RID: 23941
		internal IBattleUnit <effectSourceUnit>__2;

		// Token: 0x04005D86 RID: 23942
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005D87 RID: 23943
		internal IBattleUnit <friendlyUnit>__3;

		// Token: 0x04005D88 RID: 23944
		internal IEnumerator $locvar1;

		// Token: 0x04005D89 RID: 23945
		internal object <_>__4;

		// Token: 0x04005D8A RID: 23946
		internal IDisposable $locvar2;

		// Token: 0x04005D8B RID: 23947
		internal object $current;

		// Token: 0x04005D8C RID: 23948
		internal bool $disposing;

		// Token: 0x04005D8D RID: 23949
		internal int $PC;

		// Token: 0x04005D8E RID: 23950
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x04005D8F RID: 23951
		private static Func<IBattleUnit, bool> <>f__am$cache1;
	}
}
