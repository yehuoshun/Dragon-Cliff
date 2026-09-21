using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C3 RID: 2243
public class DamageReductionByValueEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F2B RID: 16171 RVA: 0x0018AE1C File Offset: 0x0018921C
	public DamageReductionByValueEffectProcess()
	{
	}

	// Token: 0x17000B48 RID: 2888
	// (get) Token: 0x06003F2C RID: 16172 RVA: 0x0018AE4F File Offset: 0x0018924F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B49 RID: 2889
	// (get) Token: 0x06003F2D RID: 16173 RVA: 0x0018AE57 File Offset: 0x00189257
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003F2E RID: 16174 RVA: 0x0018AE60 File Offset: 0x00189260
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && (effectCarrier.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || effectCarrier.GetUnitClassStyle() == UnitClassStyle.SpellDefender || effectCarrier.GetUnitClassStyle() == UnitClassStyle.Protector) && specialEffectData is DamageReductionByValueData)
		{
			DamageReductionByValueData data = specialEffectData as DamageReductionByValueData;
			List<IBattleUnit> targets = (from u in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
			where u != triggerUnit
			select u).ToList<IBattleUnit>();
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new DamageReductionByValueEffect(data.Percentage * triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill), triggerUnit, null, null, false), false).GetEnumerator();
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

	// Token: 0x04002F72 RID: 12146
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.DamageReductionByHealth;

	// Token: 0x04002F73 RID: 12147
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitReadyInBattle
	};

	// Token: 0x02000F3A RID: 3898
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006283 RID: 25219 RVA: 0x0018AE99 File Offset: 0x00189299
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006284 RID: 25220 RVA: 0x0018AEA4 File Offset: 0x001892A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || (effectCarrier.GetUnitClassStyle() != UnitClassStyle.PhysicalDefender && effectCarrier.GetUnitClassStyle() != UnitClassStyle.SpellDefender && effectCarrier.GetUnitClassStyle() != UnitClassStyle.Protector) || !(specialEffectData is DamageReductionByValueData))
				{
					goto IL_231;
				}
				data = (specialEffectData as DamageReductionByValueData);
				targets = (from u in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
				where u != triggerUnit
				select u).ToList<IBattleUnit>();
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
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new DamageReductionByValueEffect(data.Percentage * <AsActiveUnitProcess>c__AnonStorey.triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill), <AsActiveUnitProcess>c__AnonStorey.triggerUnit, null, null, false), false).GetEnumerator();
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
			IL_231:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700149F RID: 5279
		// (get) Token: 0x06006285 RID: 25221 RVA: 0x0018B120 File Offset: 0x00189520
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014A0 RID: 5280
		// (get) Token: 0x06006286 RID: 25222 RVA: 0x0018B128 File Offset: 0x00189528
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006287 RID: 25223 RVA: 0x0018B130 File Offset: 0x00189530
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

		// Token: 0x06006288 RID: 25224 RVA: 0x0018B1C4 File Offset: 0x001895C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006289 RID: 25225 RVA: 0x0018B1CB File Offset: 0x001895CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600628A RID: 25226 RVA: 0x0018B1D4 File Offset: 0x001895D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageReductionByValueEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DamageReductionByValueEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040058F0 RID: 22768
		internal AdventureEventType evtType;

		// Token: 0x040058F1 RID: 22769
		internal IBattleUnit effectCarrier;

		// Token: 0x040058F2 RID: 22770
		internal IBattleUnit triggerUnit;

		// Token: 0x040058F3 RID: 22771
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040058F4 RID: 22772
		internal DamageReductionByValueData <data>__1;

		// Token: 0x040058F5 RID: 22773
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040058F6 RID: 22774
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040058F7 RID: 22775
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040058F8 RID: 22776
		internal IEnumerator $locvar1;

		// Token: 0x040058F9 RID: 22777
		internal object <_>__3;

		// Token: 0x040058FA RID: 22778
		internal IDisposable $locvar2;

		// Token: 0x040058FB RID: 22779
		internal object $current;

		// Token: 0x040058FC RID: 22780
		internal bool $disposing;

		// Token: 0x040058FD RID: 22781
		internal int $PC;

		// Token: 0x040058FE RID: 22782
		private DamageReductionByValueEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x02000F3B RID: 3899
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x0600628B RID: 25227 RVA: 0x0018B22C File Offset: 0x0018962C
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x0600628C RID: 25228 RVA: 0x0018B234 File Offset: 0x00189634
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.triggerUnit;
			}

			// Token: 0x040058FF RID: 22783
			internal IBattleUnit triggerUnit;

			// Token: 0x04005900 RID: 22784
			internal DamageReductionByValueEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
