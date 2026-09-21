using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200083C RID: 2108
public class PhenixEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003C6B RID: 15467 RVA: 0x0017B255 File Offset: 0x00179655
	public PhenixEffectProcess()
	{
	}

	// Token: 0x06003C6C RID: 15468 RVA: 0x0017B265 File Offset: 0x00179665
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x17000AE6 RID: 2790
	// (get) Token: 0x06003C6D RID: 15469 RVA: 0x0017B285 File Offset: 0x00179685
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000AE7 RID: 2791
	// (get) Token: 0x06003C6E RID: 15470 RVA: 0x0017B290 File Offset: 0x00179690
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x06003C6F RID: 15471 RVA: 0x0017B2AC File Offset: 0x001796AC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPreKilled && triggerUnit.HealthPoints <= 0.0)
		{
			List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false);
			if (friendlyUnits.Any((IBattleUnit u) => u == triggerUnit))
			{
				PhenixData data = specialEffectData as PhenixData;
				if ((double)UnityEngine.Random.value <= data.ReburnChance)
				{
					double heal = data.ReburnLifeRecoveryRate * triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
					ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = heal,
								HealType = OutputType.RealHeal,
								IsDirectHeal = false
							}
						}, true)
					}, effectCarrier);
					IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object _ = enumerator.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002E38 RID: 11832
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Phenix;

	// Token: 0x04002E39 RID: 11833
	public bool? IsStarEf;

	// Token: 0x02000EF7 RID: 3831
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060060A6 RID: 24742 RVA: 0x0017B2E5 File Offset: 0x001796E5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060060A7 RID: 24743 RVA: 0x0017B2F0 File Offset: 0x001796F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPreKilled || triggerUnit.HealthPoints > 0.0)
				{
					goto IL_1F9;
				}
				friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false);
				if (!friendlyUnits.Any((IBattleUnit u) => u == triggerUnit))
				{
					goto IL_1F9;
				}
				data = (specialEffectData as PhenixData);
				if ((double)UnityEngine.Random.value > data.ReburnChance)
				{
					goto IL_1F9;
				}
				heal = data.ReburnLifeRecoveryRate * triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
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
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
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
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_1F9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001438 RID: 5176
		// (get) Token: 0x060060A8 RID: 24744 RVA: 0x0017B510 File Offset: 0x00179910
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001439 RID: 5177
		// (get) Token: 0x060060A9 RID: 24745 RVA: 0x0017B518 File Offset: 0x00179918
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060060AA RID: 24746 RVA: 0x0017B520 File Offset: 0x00179920
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
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060060AB RID: 24747 RVA: 0x0017B590 File Offset: 0x00179990
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060060AC RID: 24748 RVA: 0x0017B597 File Offset: 0x00179997
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060060AD RID: 24749 RVA: 0x0017B5A0 File Offset: 0x001799A0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhenixEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new PhenixEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040055FB RID: 22011
		internal AdventureEventType evtType;

		// Token: 0x040055FC RID: 22012
		internal IBattleUnit triggerUnit;

		// Token: 0x040055FD RID: 22013
		internal IBattleUnit effectCarrier;

		// Token: 0x040055FE RID: 22014
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x040055FF RID: 22015
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005600 RID: 22016
		internal PhenixData <data>__2;

		// Token: 0x04005601 RID: 22017
		internal double <heal>__3;

		// Token: 0x04005602 RID: 22018
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04005603 RID: 22019
		internal IEnumerator $locvar0;

		// Token: 0x04005604 RID: 22020
		internal object <_>__4;

		// Token: 0x04005605 RID: 22021
		internal IDisposable $locvar1;

		// Token: 0x04005606 RID: 22022
		internal object $current;

		// Token: 0x04005607 RID: 22023
		internal bool $disposing;

		// Token: 0x04005608 RID: 22024
		internal int $PC;

		// Token: 0x04005609 RID: 22025
		private PhenixEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000EF8 RID: 3832
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060060AE RID: 24750 RVA: 0x0017B5F8 File Offset: 0x001799F8
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060060AF RID: 24751 RVA: 0x0017B600 File Offset: 0x00179A00
			internal bool <>m__0(IBattleUnit u)
			{
				return u == this.triggerUnit;
			}

			// Token: 0x0400560A RID: 22026
			internal IBattleUnit triggerUnit;

			// Token: 0x0400560B RID: 22027
			internal PhenixEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
