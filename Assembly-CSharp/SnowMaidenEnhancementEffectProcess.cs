using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000921 RID: 2337
public class SnowMaidenEnhancementEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040C8 RID: 16584 RVA: 0x001A3FF8 File Offset: 0x001A23F8
	public SnowMaidenEnhancementEffectProcess()
	{
	}

	// Token: 0x17000C03 RID: 3075
	// (get) Token: 0x060040C9 RID: 16585 RVA: 0x001A4000 File Offset: 0x001A2400
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.SnowMaideEnhancement;
		}
	}

	// Token: 0x17000C04 RID: 3076
	// (get) Token: 0x060040CA RID: 16586 RVA: 0x001A4008 File Offset: 0x001A2408
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x060040CB RID: 16587 RVA: 0x001A4024 File Offset: 0x001A2424
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && evtData is DamageComponent && specialEffectData is SnowMaideEnhancementData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.Dealer == effectCarrier && damage.IsDirectDamage && damage.IsFatal != null && damage.IsFatal.Value)
			{
				if (damage.Target.BattleEffects.Any((BattleEffectBase b) => b.BattleEffectType == BattleEffectType.Frozen))
				{
					List<IBattleUnit> targets = (from e in damage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
					where e != damage.Target
					select e).ToList<IBattleUnit>();
					SnowMaideEnhancementData data = specialEffectData as SnowMaideEnhancementData;
					foreach (IBattleUnit battleUnit in targets)
					{
						IEnumerator enumerator2 = LockTimeEffect.AddFrozenSeconds(battleUnit, Convert.ToSingle(data.Seconds), effectCarrier, false).GetEnumerator();
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

	// Token: 0x02000FB6 RID: 4022
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065E1 RID: 26081 RVA: 0x001A405E File Offset: 0x001A245E
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065E2 RID: 26082 RVA: 0x001A4068 File Offset: 0x001A2468
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !(evtData is DamageComponent) || !(specialEffectData is SnowMaideEnhancementData))
				{
					goto IL_280;
				}
				DamageComponent damage = evtData as DamageComponent;
				if (damage.Dealer != effectCarrier || !damage.IsDirectDamage || damage.IsFatal == null || !damage.IsFatal.Value)
				{
					goto IL_280;
				}
				if (!damage.Target.BattleEffects.Any((BattleEffectBase b) => b.BattleEffectType == BattleEffectType.Frozen))
				{
					goto IL_280;
				}
				targets = (from e in damage.Target.GetAllLiveFriendlyTargetsIncSelf(true)
				where e != damage.Target
				select e).ToList<IBattleUnit>();
				data = (specialEffectData as SnowMaideEnhancementData);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			}
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
					enumerator2 = LockTimeEffect.AddFrozenSeconds(battleUnit, Convert.ToSingle(data.Seconds), effectCarrier, false).GetEnumerator();
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
			IL_280:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700155B RID: 5467
		// (get) Token: 0x060065E3 RID: 26083 RVA: 0x001A431C File Offset: 0x001A271C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700155C RID: 5468
		// (get) Token: 0x060065E4 RID: 26084 RVA: 0x001A4324 File Offset: 0x001A2724
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065E5 RID: 26085 RVA: 0x001A432C File Offset: 0x001A272C
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

		// Token: 0x060065E6 RID: 26086 RVA: 0x001A43C0 File Offset: 0x001A27C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065E7 RID: 26087 RVA: 0x001A43C7 File Offset: 0x001A27C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065E8 RID: 26088 RVA: 0x001A43D0 File Offset: 0x001A27D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SnowMaidenEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SnowMaidenEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060065E9 RID: 26089 RVA: 0x001A4428 File Offset: 0x001A2828
		private static bool <>m__0(BattleEffectBase b)
		{
			return b.BattleEffectType == BattleEffectType.Frozen;
		}

		// Token: 0x04005ECB RID: 24267
		internal AdventureEventType evtType;

		// Token: 0x04005ECC RID: 24268
		internal object evtData;

		// Token: 0x04005ECD RID: 24269
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005ECE RID: 24270
		internal IBattleUnit effectCarrier;

		// Token: 0x04005ECF RID: 24271
		internal List<IBattleUnit> <targets>__2;

		// Token: 0x04005ED0 RID: 24272
		internal SnowMaideEnhancementData <data>__2;

		// Token: 0x04005ED1 RID: 24273
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005ED2 RID: 24274
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x04005ED3 RID: 24275
		internal IEnumerator $locvar1;

		// Token: 0x04005ED4 RID: 24276
		internal object <_>__4;

		// Token: 0x04005ED5 RID: 24277
		internal IDisposable $locvar2;

		// Token: 0x04005ED6 RID: 24278
		internal object $current;

		// Token: 0x04005ED7 RID: 24279
		internal bool $disposing;

		// Token: 0x04005ED8 RID: 24280
		internal int $PC;

		// Token: 0x04005ED9 RID: 24281
		private SnowMaidenEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x04005EDA RID: 24282
		private static Func<BattleEffectBase, bool> <>f__am$cache0;

		// Token: 0x02000FB7 RID: 4023
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060065EA RID: 26090 RVA: 0x001A4434 File Offset: 0x001A2834
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060065EB RID: 26091 RVA: 0x001A443C File Offset: 0x001A283C
			internal bool <>m__0(IBattleUnit e)
			{
				return e != this.damage.Target;
			}

			// Token: 0x04005EDB RID: 24283
			internal DamageComponent damage;

			// Token: 0x04005EDC RID: 24284
			internal SnowMaidenEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
