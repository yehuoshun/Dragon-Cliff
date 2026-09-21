using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C5 RID: 2245
public class DarknessEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F33 RID: 16179 RVA: 0x0018B7DC File Offset: 0x00189BDC
	public DarknessEffectProcess()
	{
	}

	// Token: 0x17000B4C RID: 2892
	// (get) Token: 0x06003F34 RID: 16180 RVA: 0x0018B7EC File Offset: 0x00189BEC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B4D RID: 2893
	// (get) Token: 0x06003F35 RID: 16181 RVA: 0x0018B7F4 File Offset: 0x00189BF4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x06003F36 RID: 16182 RVA: 0x0018B810 File Offset: 0x00189C10
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
			DarknessData data = specialEffectData as DarknessData;
			if (battleEncounter != null && data != null)
			{
				foreach (IBattleUnit enemyUnit in battleEncounter.EnemyUnits)
				{
					IEnumerator enumerator2 = enemyUnit.ApplySkillEffect(AttributeModificationEffect.CreateDarknessOutputDepressionEffect(enemyUnit, data.MonsterDepression), false).GetEnumerator();
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
				foreach (IBattleUnit playerUnit in (from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>())
				{
					IEnumerator enumerator4 = playerUnit.ApplySkillEffect(AttributeModificationEffect.CreateDarknessHealDepressionEffect(playerUnit, data.HealDepression), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x04002F75 RID: 12149
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DarknessEffect;

	// Token: 0x02000F3F RID: 3903
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600629D RID: 25245 RVA: 0x0018B83A File Offset: 0x00189C3A
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600629E RID: 25246 RVA: 0x0018B844 File Offset: 0x00189C44
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.BattleEncounterStarts)
				{
					goto IL_2D2;
				}
				battleEncounter = (evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter);
				data = (specialEffectData as DarknessData);
				if (battleEncounter == null || data == null)
				{
					goto IL_2D2;
				}
				enumerator = battleEncounter.EnemyUnits.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1D3;
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
				if (enumerator.MoveNext())
				{
					enemyUnit = enumerator.Current;
					enumerator2 = enemyUnit.ApplySkillEffect(AttributeModificationEffect.CreateDarknessOutputDepressionEffect(enemyUnit, data.MonsterDepression), false).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = (from u in battleEncounter.PlayerUnits
			where u.Status == BattleUnitStatus.Active
			select u).ToList<IBattleUnit>().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1D3:
				switch (num)
				{
				case 2u:
					Block_20:
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
					playerUnit = enumerator3.Current;
					enumerator4 = playerUnit.ApplySkillEffect(AttributeModificationEffect.CreateDarknessHealDepressionEffect(playerUnit, data.HealDepression), false).GetEnumerator();
					num = 4294967293u;
					goto Block_20;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			IL_2D2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014A3 RID: 5283
		// (get) Token: 0x0600629F RID: 25247 RVA: 0x0018BB64 File Offset: 0x00189F64
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014A4 RID: 5284
		// (get) Token: 0x060062A0 RID: 25248 RVA: 0x0018BB6C File Offset: 0x00189F6C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062A1 RID: 25249 RVA: 0x0018BB74 File Offset: 0x00189F74
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
			}
		}

		// Token: 0x060062A2 RID: 25250 RVA: 0x0018BC68 File Offset: 0x0018A068
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062A3 RID: 25251 RVA: 0x0018BC6F File Offset: 0x0018A06F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062A4 RID: 25252 RVA: 0x0018BC78 File Offset: 0x0018A078
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DarknessEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new DarknessEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060062A5 RID: 25253 RVA: 0x0018BCB8 File Offset: 0x0018A0B8
		private static bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04005919 RID: 22809
		internal BroadcastEvent evt;

		// Token: 0x0400591A RID: 22810
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x0400591B RID: 22811
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400591C RID: 22812
		internal DarknessData <data>__1;

		// Token: 0x0400591D RID: 22813
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x0400591E RID: 22814
		internal IBattleUnit <enemyUnit>__2;

		// Token: 0x0400591F RID: 22815
		internal IEnumerator $locvar1;

		// Token: 0x04005920 RID: 22816
		internal object <_>__3;

		// Token: 0x04005921 RID: 22817
		internal IDisposable $locvar2;

		// Token: 0x04005922 RID: 22818
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x04005923 RID: 22819
		internal IBattleUnit <playerUnit>__4;

		// Token: 0x04005924 RID: 22820
		internal IEnumerator $locvar4;

		// Token: 0x04005925 RID: 22821
		internal object <_>__5;

		// Token: 0x04005926 RID: 22822
		internal IDisposable $locvar5;

		// Token: 0x04005927 RID: 22823
		internal object $current;

		// Token: 0x04005928 RID: 22824
		internal bool $disposing;

		// Token: 0x04005929 RID: 22825
		internal int $PC;

		// Token: 0x0400592A RID: 22826
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}
}
