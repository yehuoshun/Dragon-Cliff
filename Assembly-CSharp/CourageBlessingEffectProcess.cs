using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008BF RID: 2239
public class CourageBlessingEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F1B RID: 16155 RVA: 0x00189AB2 File Offset: 0x00187EB2
	public CourageBlessingEffectProcess()
	{
	}

	// Token: 0x17000B40 RID: 2880
	// (get) Token: 0x06003F1C RID: 16156 RVA: 0x00189ABA File Offset: 0x00187EBA
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.CourageBlessing;
		}
	}

	// Token: 0x17000B41 RID: 2881
	// (get) Token: 0x06003F1D RID: 16157 RVA: 0x00189AC0 File Offset: 0x00187EC0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitCompletesTurn,
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06003F1E RID: 16158 RVA: 0x00189AE4 File Offset: 0x00187EE4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitCompletesTurn || evtType == AdventureEventType.UnitReadyInBattle) && specialEffectData is CourageBlessingData && triggerUnit == effectCarrier)
		{
			CourageBlessingData data = specialEffectData as CourageBlessingData;
			List<IBattleUnit> targets = (from e in effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true)
			where e != effectCarrier
			select e).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new CourageBlessedEffect(2, data.StunRate, data.OutputReductionRate, effectCarrier), false).GetEnumerator();
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

	// Token: 0x02000F34 RID: 3892
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600625B RID: 25179 RVA: 0x00189B1D File Offset: 0x00187F1D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600625C RID: 25180 RVA: 0x00189B28 File Offset: 0x00187F28
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitCompletesTurn && evtType != AdventureEventType.UnitReadyInBattle) || !(specialEffectData is CourageBlessingData) || triggerUnit != effectCarrier)
				{
					goto IL_1F2;
				}
				data = (specialEffectData as CourageBlessingData);
				targets = (from e in effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true)
				where e != effectCarrier
				select e).ToList<IBattleUnit>();
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
					enumerator2 = battleUnit.ApplySkillEffect(new CourageBlessedEffect(2, data.StunRate, data.OutputReductionRate, <AsActiveUnitProcess>c__AnonStorey.effectCarrier), false).GetEnumerator();
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
			IL_1F2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001497 RID: 5271
		// (get) Token: 0x0600625D RID: 25181 RVA: 0x00189D50 File Offset: 0x00188150
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001498 RID: 5272
		// (get) Token: 0x0600625E RID: 25182 RVA: 0x00189D58 File Offset: 0x00188158
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600625F RID: 25183 RVA: 0x00189D60 File Offset: 0x00188160
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

		// Token: 0x06006260 RID: 25184 RVA: 0x00189DF4 File Offset: 0x001881F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006261 RID: 25185 RVA: 0x00189DFB File Offset: 0x001881FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006262 RID: 25186 RVA: 0x00189E04 File Offset: 0x00188204
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CourageBlessingEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new CourageBlessingEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040058A6 RID: 22694
		internal AdventureEventType evtType;

		// Token: 0x040058A7 RID: 22695
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040058A8 RID: 22696
		internal IBattleUnit triggerUnit;

		// Token: 0x040058A9 RID: 22697
		internal IBattleUnit effectCarrier;

		// Token: 0x040058AA RID: 22698
		internal CourageBlessingData <data>__1;

		// Token: 0x040058AB RID: 22699
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040058AC RID: 22700
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040058AD RID: 22701
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040058AE RID: 22702
		internal IEnumerator $locvar1;

		// Token: 0x040058AF RID: 22703
		internal object <_>__3;

		// Token: 0x040058B0 RID: 22704
		internal IDisposable $locvar2;

		// Token: 0x040058B1 RID: 22705
		internal object $current;

		// Token: 0x040058B2 RID: 22706
		internal bool $disposing;

		// Token: 0x040058B3 RID: 22707
		internal int $PC;

		// Token: 0x040058B4 RID: 22708
		private CourageBlessingEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x02000F35 RID: 3893
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006263 RID: 25187 RVA: 0x00189E5C File Offset: 0x0018825C
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006264 RID: 25188 RVA: 0x00189E64 File Offset: 0x00188264
			internal bool <>m__0(IBattleUnit e)
			{
				return e != this.effectCarrier;
			}

			// Token: 0x040058B5 RID: 22709
			internal IBattleUnit effectCarrier;

			// Token: 0x040058B6 RID: 22710
			internal CourageBlessingEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
