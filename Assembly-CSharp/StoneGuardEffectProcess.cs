using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200092A RID: 2346
public class StoneGuardEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040F6 RID: 16630 RVA: 0x001A59C9 File Offset: 0x001A3DC9
	public StoneGuardEffectProcess()
	{
	}

	// Token: 0x17000C13 RID: 3091
	// (get) Token: 0x060040F7 RID: 16631 RVA: 0x001A59D1 File Offset: 0x001A3DD1
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.StoneGuard;
		}
	}

	// Token: 0x17000C14 RID: 3092
	// (get) Token: 0x060040F8 RID: 16632 RVA: 0x001A59D5 File Offset: 0x001A3DD5
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x060040F9 RID: 16633 RVA: 0x001A59DC File Offset: 0x001A3DDC
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is StoneGuardEffectData)
		{
			StoneGuardEffectData data = specialEffectData as StoneGuardEffectData;
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(effectCarrier);
			foreach (IBattleUnit battleUnit in targets)
			{
				if (battleUnit.BattleEffects.OfType<TauntEffect>().Any((TauntEffect e) => e.SourceUnit == effectCarrier))
				{
					if (battleUnit.IsAliveInBattle())
					{
						IEnumerator enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, effectCarrier, -data.ProgressPush).GetEnumerator();
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
						IEnumerator enumerator3 = LockTimeEffect.AddStunSeconds(battleUnit, Convert.ToSingle(data.StunSeconds), effectCarrier, false).GetEnumerator();
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
				else if ((double)UnityEngine.Random.value <= data.ChancePerSecond)
				{
					IEnumerator enumerator4 = battleUnit.ApplySkillEffect(new TauntEffect(effectCarrier, battleUnit, effectCarrier, new int?(2), true), false).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _3 = enumerator4.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000FC6 RID: 4038
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006651 RID: 26193 RVA: 0x001A5A06 File Offset: 0x001A3E06
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006652 RID: 26194 RVA: 0x001A5A10 File Offset: 0x001A3E10
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(specialEffectData is StoneGuardEffectData))
				{
					goto IL_384;
				}
				data = (specialEffectData as StoneGuardEffectData);
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(effectCarrier);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
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
					enumerator3 = LockTimeEffect.AddStunSeconds(battleUnit, Convert.ToSingle(data.StunSeconds), <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				case 2u:
					goto IL_1F8;
				case 3u:
					Block_10:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_3 = enumerator4.Current;
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
							if ((disposable3 = (enumerator4 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					break;
				}
				IL_359:
				while (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					if (battleUnit.BattleEffects.OfType<TauntEffect>().Any((TauntEffect e) => e.SourceUnit == <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier))
					{
						if (battleUnit.IsAliveInBattle())
						{
							enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(battleUnit, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, -data.ProgressPush).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
						}
					}
					else if ((double)UnityEngine.Random.value <= data.ChancePerSecond)
					{
						enumerator4 = battleUnit.ApplySkillEffect(new TauntEffect(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, battleUnit, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, new int?(2), true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_10;
					}
				}
				goto IL_384;
				Block_8:
				try
				{
					IL_1F8:
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
				goto IL_359;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_384:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001575 RID: 5493
		// (get) Token: 0x06006653 RID: 26195 RVA: 0x001A5E10 File Offset: 0x001A4210
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001576 RID: 5494
		// (get) Token: 0x06006654 RID: 26196 RVA: 0x001A5E18 File Offset: 0x001A4218
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006655 RID: 26197 RVA: 0x001A5E20 File Offset: 0x001A4220
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					case 1u:
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
						}
						finally
						{
							if ((disposable3 = (enumerator4 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006656 RID: 26198 RVA: 0x001A5F4C File Offset: 0x001A434C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006657 RID: 26199 RVA: 0x001A5F53 File Offset: 0x001A4353
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006658 RID: 26200 RVA: 0x001A5F5C File Offset: 0x001A435C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoneGuardEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new StoneGuardEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005F47 RID: 24391
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F48 RID: 24392
		internal StoneGuardEffectData <data>__1;

		// Token: 0x04005F49 RID: 24393
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F4A RID: 24394
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005F4B RID: 24395
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005F4C RID: 24396
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005F4D RID: 24397
		internal IEnumerator $locvar1;

		// Token: 0x04005F4E RID: 24398
		internal object <_>__3;

		// Token: 0x04005F4F RID: 24399
		internal IDisposable $locvar2;

		// Token: 0x04005F50 RID: 24400
		internal IEnumerator $locvar3;

		// Token: 0x04005F51 RID: 24401
		internal object <_>__4;

		// Token: 0x04005F52 RID: 24402
		internal IDisposable $locvar4;

		// Token: 0x04005F53 RID: 24403
		internal IEnumerator $locvar5;

		// Token: 0x04005F54 RID: 24404
		internal object <_>__5;

		// Token: 0x04005F55 RID: 24405
		internal IDisposable $locvar6;

		// Token: 0x04005F56 RID: 24406
		internal object $current;

		// Token: 0x04005F57 RID: 24407
		internal bool $disposing;

		// Token: 0x04005F58 RID: 24408
		internal int $PC;

		// Token: 0x04005F59 RID: 24409
		private StoneGuardEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 $locvar7;

		// Token: 0x02000FC7 RID: 4039
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey1
		{
			// Token: 0x06006659 RID: 26201 RVA: 0x001A5F9C File Offset: 0x001A439C
			public <AsActiveUnitPerSecondProcess>c__AnonStorey1()
			{
			}

			// Token: 0x0600665A RID: 26202 RVA: 0x001A5FA4 File Offset: 0x001A43A4
			internal bool <>m__0(TauntEffect e)
			{
				return e.SourceUnit == this.effectCarrier;
			}

			// Token: 0x04005F5A RID: 24410
			internal IBattleUnit effectCarrier;

			// Token: 0x04005F5B RID: 24411
			internal StoneGuardEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
