using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000937 RID: 2359
public class ThugPowerEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004132 RID: 16690 RVA: 0x001AA379 File Offset: 0x001A8779
	public ThugPowerEffectProcess()
	{
	}

	// Token: 0x17000C2D RID: 3117
	// (get) Token: 0x06004133 RID: 16691 RVA: 0x001AA389 File Offset: 0x001A8789
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C2E RID: 3118
	// (get) Token: 0x06004134 RID: 16692 RVA: 0x001AA394 File Offset: 0x001A8794
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitRegularTurnEnds,
				AdventureEventType.UnitKilled
			};
		}
	}

	// Token: 0x06004135 RID: 16693 RVA: 0x001AA3C0 File Offset: 0x001A87C0
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
			where t != effectCarrier
			select t).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new TurnFrozenEffect(null, effectCarrier), false).GetEnumerator();
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
			List<IBattleUnit> enemies = triggerUnit.GetLiveEnemyTargets(false, false);
			if (enemies.Any<IBattleUnit>())
			{
				IBattleUnit selected = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				IEnumerator enumerator3 = selected.ApplySkillEffect(new TargettedEffect(new float?(6f), effectCarrier), false).GetEnumerator();
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
			}
		}
		if (evtType == AdventureEventType.UnitRegularTurnEnds && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> targets2 = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
			where t.BattleEffects.OfType<TurnFrozenEffect>().Any((TurnFrozenEffect tt) => tt.SourceUnit == effectCarrier)
			select t).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit2 in targets2)
			{
				IEnumerator enumerator5 = battleUnit2.DoTurn().GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			List<IBattleUnit> enemies2 = triggerUnit.GetLiveEnemyTargets(false, false);
			if (enemies2.Any<IBattleUnit>())
			{
				IBattleUnit selected2 = enemies2[UnityEngine.Random.Range(0, enemies2.Count)];
				IEnumerator enumerator6 = selected2.ApplySkillEffect(new TargettedEffect(new float?(6f), effectCarrier), false).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _4 = enumerator6.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06004136 RID: 16694 RVA: 0x001AA3F4 File Offset: 0x001A87F4
	public override IEnumerable AsInactiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
			where t != effectCarrier
			select t).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in targets)
			{
				List<TurnFrozenEffect> toremove = (from t in battleUnit.BattleEffects.OfType<TurnFrozenEffect>()
				where t.SourceUnit == effectCarrier
				select t).ToList<TurnFrozenEffect>();
				foreach (TurnFrozenEffect remove in toremove)
				{
					IEnumerator enumerator3 = battleUnit.LooseSkillEffect(remove, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040030E7 RID: 12519
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.ThugPower;

	// Token: 0x02000FD9 RID: 4057
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066CD RID: 26317 RVA: 0x001AA426 File Offset: 0x001A8826
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066CE RID: 26318 RVA: 0x001AA430 File Offset: 0x001A8830
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier)
				{
					goto IL_2B8;
				}
				targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
				where t != effectCarrier
				select t).ToList<IBattleUnit>();
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_236;
			case 3u:
				Block_9:
				try
				{
					switch (num)
					{
					case 3u:
						Block_30:
						try
						{
							switch (num)
							{
							}
							if (enumerator5.MoveNext())
							{
								_3 = enumerator5.Current;
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
								if ((disposable3 = (enumerator5 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator4.MoveNext())
					{
						battleUnit2 = enumerator4.Current;
						enumerator5 = battleUnit2.DoTurn().GetEnumerator();
						num = 4294967293u;
						goto Block_30;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator4).Dispose();
					}
				}
				enemies2 = triggerUnit.GetLiveEnemyTargets(false, false);
				if (enemies2.Any<IBattleUnit>())
				{
					selected2 = enemies2[UnityEngine.Random.Range(0, enemies2.Count)];
					enumerator6 = selected2.ApplySkillEffect(new TargettedEffect(new float?(6f), <AsActiveUnitProcess>c__AnonStorey.effectCarrier), false).GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
				goto IL_4FE;
			case 4u:
				goto IL_47C;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_13:
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
					enumerator2 = battleUnit.ApplySkillEffect(new TurnFrozenEffect(null, <AsActiveUnitProcess>c__AnonStorey.effectCarrier), false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enemies = triggerUnit.GetLiveEnemyTargets(false, false);
			if (!enemies.Any<IBattleUnit>())
			{
				goto IL_2B8;
			}
			selected = enemies[UnityEngine.Random.Range(0, enemies.Count)];
			enumerator3 = selected.ApplySkillEffect(new TargettedEffect(new float?(6f), <AsActiveUnitProcess>c__AnonStorey.effectCarrier), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_236:
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
			IL_2B8:
			if (evtType == AdventureEventType.UnitRegularTurnEnds && triggerUnit == <AsActiveUnitProcess>c__AnonStorey.effectCarrier)
			{
				targets2 = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
				where t.BattleEffects.OfType<TurnFrozenEffect>().Any((TurnFrozenEffect tt) => tt.SourceUnit == <AsActiveUnitProcess>c__AnonStorey.effectCarrier)
				select t).ToList<IBattleUnit>();
				enumerator4 = targets2.GetEnumerator();
				num = 4294967293u;
				goto Block_9;
			}
			goto IL_4FE;
			Block_11:
			try
			{
				IL_47C:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_4 = enumerator6.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_4FE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001591 RID: 5521
		// (get) Token: 0x060066CF RID: 26319 RVA: 0x001AA994 File Offset: 0x001A8D94
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001592 RID: 5522
		// (get) Token: 0x060066D0 RID: 26320 RVA: 0x001AA99C File Offset: 0x001A8D9C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066D1 RID: 26321 RVA: 0x001AA9A4 File Offset: 0x001A8DA4
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
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060066D2 RID: 26322 RVA: 0x001AAB18 File Offset: 0x001A8F18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066D3 RID: 26323 RVA: 0x001AAB1F File Offset: 0x001A8F1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066D4 RID: 26324 RVA: 0x001AAB28 File Offset: 0x001A8F28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThugPowerEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ThugPowerEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04006052 RID: 24658
		internal AdventureEventType evtType;

		// Token: 0x04006053 RID: 24659
		internal IBattleUnit triggerUnit;

		// Token: 0x04006054 RID: 24660
		internal IBattleUnit effectCarrier;

		// Token: 0x04006055 RID: 24661
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04006056 RID: 24662
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04006057 RID: 24663
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04006058 RID: 24664
		internal IEnumerator $locvar1;

		// Token: 0x04006059 RID: 24665
		internal object <_>__3;

		// Token: 0x0400605A RID: 24666
		internal IDisposable $locvar2;

		// Token: 0x0400605B RID: 24667
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x0400605C RID: 24668
		internal IBattleUnit <selected>__4;

		// Token: 0x0400605D RID: 24669
		internal IEnumerator $locvar3;

		// Token: 0x0400605E RID: 24670
		internal object <_>__5;

		// Token: 0x0400605F RID: 24671
		internal IDisposable $locvar4;

		// Token: 0x04006060 RID: 24672
		internal List<IBattleUnit> <targets>__6;

		// Token: 0x04006061 RID: 24673
		internal List<IBattleUnit>.Enumerator $locvar5;

		// Token: 0x04006062 RID: 24674
		internal IBattleUnit <battleUnit>__7;

		// Token: 0x04006063 RID: 24675
		internal IEnumerator $locvar6;

		// Token: 0x04006064 RID: 24676
		internal object <_>__8;

		// Token: 0x04006065 RID: 24677
		internal IDisposable $locvar7;

		// Token: 0x04006066 RID: 24678
		internal List<IBattleUnit> <enemies>__6;

		// Token: 0x04006067 RID: 24679
		internal IBattleUnit <selected>__9;

		// Token: 0x04006068 RID: 24680
		internal IEnumerator $locvar8;

		// Token: 0x04006069 RID: 24681
		internal object <_>__10;

		// Token: 0x0400606A RID: 24682
		internal IDisposable $locvar9;

		// Token: 0x0400606B RID: 24683
		internal object $current;

		// Token: 0x0400606C RID: 24684
		internal bool $disposing;

		// Token: 0x0400606D RID: 24685
		internal int $PC;

		// Token: 0x0400606E RID: 24686
		private ThugPowerEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvarA;

		// Token: 0x02000FDB RID: 4059
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x060066DD RID: 26333 RVA: 0x001AAB74 File Offset: 0x001A8F74
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060066DE RID: 26334 RVA: 0x001AAB7C File Offset: 0x001A8F7C
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.effectCarrier;
			}

			// Token: 0x060066DF RID: 26335 RVA: 0x001AAB8A File Offset: 0x001A8F8A
			internal bool <>m__1(IBattleUnit t)
			{
				return t.BattleEffects.OfType<TurnFrozenEffect>().Any((TurnFrozenEffect tt) => tt.SourceUnit == this.effectCarrier);
			}

			// Token: 0x060066E0 RID: 26336 RVA: 0x001AABA8 File Offset: 0x001A8FA8
			internal bool <>m__2(TurnFrozenEffect tt)
			{
				return tt.SourceUnit == this.effectCarrier;
			}

			// Token: 0x0400607F RID: 24703
			internal IBattleUnit effectCarrier;

			// Token: 0x04006080 RID: 24704
			internal ThugPowerEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000FDA RID: 4058
	[CompilerGenerated]
	private sealed class <AsInactiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066D5 RID: 26325 RVA: 0x001AABB8 File Offset: 0x001A8FB8
		[DebuggerHidden]
		public <AsInactiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060066D6 RID: 26326 RVA: 0x001AABC0 File Offset: 0x001A8FC0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitKilled || triggerUnit != effectCarrier)
				{
					goto IL_230;
				}
				targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
				where t != effectCarrier
				select t).ToList<IBattleUnit>();
				enumerator = targets.GetEnumerator();
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
					Block_6:
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
								if (enumerator3.MoveNext())
								{
									_ = enumerator3.Current;
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator2.MoveNext())
						{
							remove = enumerator2.Current;
							enumerator3 = battleUnit.LooseSkillEffect(remove, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_9;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					toremove = (from t in battleUnit.BattleEffects.OfType<TurnFrozenEffect>()
					where t.SourceUnit == <AsInactiveUnitProcess>c__AnonStorey.effectCarrier
					select t).ToList<TurnFrozenEffect>();
					enumerator2 = toremove.GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_230:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001593 RID: 5523
		// (get) Token: 0x060066D7 RID: 26327 RVA: 0x001AAE54 File Offset: 0x001A9254
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001594 RID: 5524
		// (get) Token: 0x060066D8 RID: 26328 RVA: 0x001AAE5C File Offset: 0x001A925C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066D9 RID: 26329 RVA: 0x001AAE64 File Offset: 0x001A9264
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
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060066DA RID: 26330 RVA: 0x001AAF1C File Offset: 0x001A931C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066DB RID: 26331 RVA: 0x001AAF23 File Offset: 0x001A9323
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066DC RID: 26332 RVA: 0x001AAF2C File Offset: 0x001A932C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThugPowerEffectProcess.<AsInactiveUnitProcess>c__Iterator1 <AsInactiveUnitProcess>c__Iterator = new ThugPowerEffectProcess.<AsInactiveUnitProcess>c__Iterator1();
			<AsInactiveUnitProcess>c__Iterator.evtType = evtType;
			<AsInactiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsInactiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsInactiveUnitProcess>c__Iterator;
		}

		// Token: 0x0400606F RID: 24687
		internal AdventureEventType evtType;

		// Token: 0x04006070 RID: 24688
		internal IBattleUnit triggerUnit;

		// Token: 0x04006071 RID: 24689
		internal IBattleUnit effectCarrier;

		// Token: 0x04006072 RID: 24690
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04006073 RID: 24691
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04006074 RID: 24692
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04006075 RID: 24693
		internal List<TurnFrozenEffect> <toremove>__3;

		// Token: 0x04006076 RID: 24694
		internal List<TurnFrozenEffect>.Enumerator $locvar1;

		// Token: 0x04006077 RID: 24695
		internal TurnFrozenEffect <remove>__4;

		// Token: 0x04006078 RID: 24696
		internal IEnumerator $locvar2;

		// Token: 0x04006079 RID: 24697
		internal object <_>__5;

		// Token: 0x0400607A RID: 24698
		internal IDisposable $locvar3;

		// Token: 0x0400607B RID: 24699
		internal object $current;

		// Token: 0x0400607C RID: 24700
		internal bool $disposing;

		// Token: 0x0400607D RID: 24701
		internal int $PC;

		// Token: 0x0400607E RID: 24702
		private ThugPowerEffectProcess.<AsInactiveUnitProcess>c__Iterator1.<AsInactiveUnitProcess>c__AnonStorey3 $locvar4;

		// Token: 0x02000FDC RID: 4060
		private sealed class <AsInactiveUnitProcess>c__AnonStorey3
		{
			// Token: 0x060066E1 RID: 26337 RVA: 0x001AAF78 File Offset: 0x001A9378
			public <AsInactiveUnitProcess>c__AnonStorey3()
			{
			}

			// Token: 0x060066E2 RID: 26338 RVA: 0x001AAF80 File Offset: 0x001A9380
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.effectCarrier;
			}

			// Token: 0x060066E3 RID: 26339 RVA: 0x001AAF8E File Offset: 0x001A938E
			internal bool <>m__1(TurnFrozenEffect t)
			{
				return t.SourceUnit == this.effectCarrier;
			}

			// Token: 0x04006081 RID: 24705
			internal IBattleUnit effectCarrier;

			// Token: 0x04006082 RID: 24706
			internal ThugPowerEffectProcess.<AsInactiveUnitProcess>c__Iterator1 <>f__ref$1;
		}
	}
}
