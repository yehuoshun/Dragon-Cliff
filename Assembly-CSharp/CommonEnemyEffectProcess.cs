using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008BB RID: 2235
public class CommonEnemyEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F07 RID: 16135 RVA: 0x00188B38 File Offset: 0x00186F38
	public CommonEnemyEffectProcess()
	{
	}

	// Token: 0x17000B38 RID: 2872
	// (get) Token: 0x06003F08 RID: 16136 RVA: 0x00188B40 File Offset: 0x00186F40
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.CommonEnemy;
		}
	}

	// Token: 0x17000B39 RID: 2873
	// (get) Token: 0x06003F09 RID: 16137 RVA: 0x00188B44 File Offset: 0x00186F44
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003F0A RID: 16138 RVA: 0x00188B68 File Offset: 0x00186F68
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is CommonEnemyData)
		{
			CommonEnemyData commonEnemyData = specialEffectData as CommonEnemyData;
			commonEnemyData.RatePerBattle = 1.0;
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && evtData is DamageComponent)
		{
			List<IBattleUnit> team = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			if (team.Any((IBattleUnit m) => m == triggerUnit) && specialEffectData is CommonEnemyData)
			{
				DamageComponent damage = evtData as DamageComponent;
				CommonEnemyData data = specialEffectData as CommonEnemyData;
				if (data.RatePerBattle > 0.0)
				{
					if (damage.IsDirectDamage && damage.IsCrit && !damage.IsMissed)
					{
						foreach (IBattleUnit unit in team)
						{
							IEnumerator enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(unit, effectCarrier, data.PushRate * data.RatePerBattle).GetEnumerator();
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
					data.RatePerBattle -= 0.3;
				}
			}
		}
		yield break;
	}

	// Token: 0x06003F0B RID: 16139 RVA: 0x00188BA9 File Offset: 0x00186FA9
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003F0C RID: 16140 RVA: 0x00188BAC File Offset: 0x00186FAC
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CommonEnemyData
			{
				IsStar = true,
				PushRate = (double)UnityEngine.Random.Range(0.1f, 0.2f)
			}
		};
	}

	// Token: 0x02000F2F RID: 3887
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006234 RID: 25140 RVA: 0x00188BEA File Offset: 0x00186FEA
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006235 RID: 25141 RVA: 0x00188BF4 File Offset: 0x00186FF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is CommonEnemyData)
				{
					CommonEnemyData commonEnemyData = specialEffectData as CommonEnemyData;
					commonEnemyData.RatePerBattle = 1.0;
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !(evtData is DamageComponent))
				{
					goto IL_298;
				}
				team = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				if (!team.Any((IBattleUnit m) => m == triggerUnit) || !(specialEffectData is CommonEnemyData))
				{
					goto IL_298;
				}
				damage = (evtData as DamageComponent);
				data = (specialEffectData as CommonEnemyData);
				if (data.RatePerBattle <= 0.0)
				{
					goto IL_298;
				}
				if (!damage.IsDirectDamage || !damage.IsCrit || damage.IsMissed)
				{
					goto IL_27D;
				}
				enumerator = team.GetEnumerator();
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
					Block_15:
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
					unit = enumerator.Current;
					enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(unit, effectCarrier, data.PushRate * data.RatePerBattle).GetEnumerator();
					num = 4294967293u;
					goto Block_15;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_27D:
			data.RatePerBattle -= 0.3;
			IL_298:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700148F RID: 5263
		// (get) Token: 0x06006236 RID: 25142 RVA: 0x00188EC0 File Offset: 0x001872C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001490 RID: 5264
		// (get) Token: 0x06006237 RID: 25143 RVA: 0x00188EC8 File Offset: 0x001872C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006238 RID: 25144 RVA: 0x00188ED0 File Offset: 0x001872D0
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

		// Token: 0x06006239 RID: 25145 RVA: 0x00188F64 File Offset: 0x00187364
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600623A RID: 25146 RVA: 0x00188F6B File Offset: 0x0018736B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600623B RID: 25147 RVA: 0x00188F74 File Offset: 0x00187374
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CommonEnemyEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new CommonEnemyEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005868 RID: 22632
		internal AdventureEventType evtType;

		// Token: 0x04005869 RID: 22633
		internal IBattleUnit triggerUnit;

		// Token: 0x0400586A RID: 22634
		internal IBattleUnit effectCarrier;

		// Token: 0x0400586B RID: 22635
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400586C RID: 22636
		internal object evtData;

		// Token: 0x0400586D RID: 22637
		internal List<IBattleUnit> <team>__1;

		// Token: 0x0400586E RID: 22638
		internal DamageComponent <damage>__2;

		// Token: 0x0400586F RID: 22639
		internal CommonEnemyData <data>__2;

		// Token: 0x04005870 RID: 22640
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005871 RID: 22641
		internal IBattleUnit <unit>__3;

		// Token: 0x04005872 RID: 22642
		internal IEnumerator $locvar1;

		// Token: 0x04005873 RID: 22643
		internal object <_>__4;

		// Token: 0x04005874 RID: 22644
		internal IDisposable $locvar2;

		// Token: 0x04005875 RID: 22645
		internal object $current;

		// Token: 0x04005876 RID: 22646
		internal bool $disposing;

		// Token: 0x04005877 RID: 22647
		internal int $PC;

		// Token: 0x04005878 RID: 22648
		private CommonEnemyEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x02000F30 RID: 3888
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x0600623C RID: 25148 RVA: 0x00188FD8 File Offset: 0x001873D8
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x0600623D RID: 25149 RVA: 0x00188FE0 File Offset: 0x001873E0
			internal bool <>m__0(IBattleUnit m)
			{
				return m == this.triggerUnit;
			}

			// Token: 0x04005879 RID: 22649
			internal IBattleUnit triggerUnit;

			// Token: 0x0400587A RID: 22650
			internal CommonEnemyEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
