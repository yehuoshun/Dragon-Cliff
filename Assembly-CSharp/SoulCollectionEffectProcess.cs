using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000922 RID: 2338
public class SoulCollectionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040CC RID: 16588 RVA: 0x001A444F File Offset: 0x001A284F
	public SoulCollectionEffectProcess()
	{
	}

	// Token: 0x17000C05 RID: 3077
	// (get) Token: 0x060040CD RID: 16589 RVA: 0x001A445F File Offset: 0x001A285F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C06 RID: 3078
	// (get) Token: 0x060040CE RID: 16590 RVA: 0x001A4468 File Offset: 0x001A2868
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitKilled
			};
		}
	}

	// Token: 0x060040CF RID: 16591 RVA: 0x001A4484 File Offset: 0x001A2884
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled)
		{
			List<IBattleUnit> enemies = effectCarrier.GetDeadEnemyTargets();
			BattleDamage damage = evtData as BattleDamage;
			if (enemies.Any((IBattleUnit e) => e == triggerUnit) && damage != null && damage.Dealer == effectCarrier)
			{
				SoulCollectionData data = specialEffectData as SoulCollectionData;
				List<IBattleUnit> liveFriendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false);
				if (liveFriendlyUnits.Any<IBattleUnit>())
				{
					IBattleUnit selected = liveFriendlyUnits[UnityEngine.Random.Range(0, liveFriendlyUnits.Count)];
					BoostType selectedBoostType = data.BoostTypes[UnityEngine.Random.Range(0, data.BoostTypes.Count)];
					AttributeType boostAttributeType = this.GetRelatetdAttributeBoostType(selectedBoostType, selected);
					IEnumerator enumerator = selected.ApplySkillEffect(new SoulCollectedBoostEffect(boostAttributeType, data.IncreaseAmount, effectCarrier, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x060040D0 RID: 16592 RVA: 0x001A44CC File Offset: 0x001A28CC
	private AttributeType GetRelatetdAttributeBoostType(BoostType type, IBattleUnit target)
	{
		if (type == BoostType.Output)
		{
			return target.GetOutputAttributeType();
		}
		if (type != BoostType.Agility)
		{
			throw new ArgumentOutOfRangeException("type", type, null);
		}
		return AttributeType.Agility;
	}

	// Token: 0x04002FAF RID: 12207
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.SoulCollection;

	// Token: 0x02000FB8 RID: 4024
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065EC RID: 26092 RVA: 0x001A44FA File Offset: 0x001A28FA
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065ED RID: 26093 RVA: 0x001A4504 File Offset: 0x001A2904
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitKilled)
				{
					goto IL_222;
				}
				enemies = effectCarrier.GetDeadEnemyTargets();
				damage = (evtData as BattleDamage);
				if (!enemies.Any((IBattleUnit e) => e == triggerUnit) || damage == null || damage.Dealer != effectCarrier)
				{
					goto IL_222;
				}
				data = (specialEffectData as SoulCollectionData);
				liveFriendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false);
				if (!liveFriendlyUnits.Any<IBattleUnit>())
				{
					goto IL_222;
				}
				selected = liveFriendlyUnits[UnityEngine.Random.Range(0, liveFriendlyUnits.Count)];
				selectedBoostType = data.BoostTypes[UnityEngine.Random.Range(0, data.BoostTypes.Count)];
				boostAttributeType = base.GetRelatetdAttributeBoostType(selectedBoostType, selected);
				enumerator = selected.ApplySkillEffect(new SoulCollectedBoostEffect(boostAttributeType, data.IncreaseAmount, effectCarrier, base.GetType().FullName), false).GetEnumerator();
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
			IL_222:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700155D RID: 5469
		// (get) Token: 0x060065EE RID: 26094 RVA: 0x001A4750 File Offset: 0x001A2B50
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700155E RID: 5470
		// (get) Token: 0x060065EF RID: 26095 RVA: 0x001A4758 File Offset: 0x001A2B58
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065F0 RID: 26096 RVA: 0x001A4760 File Offset: 0x001A2B60
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

		// Token: 0x060065F1 RID: 26097 RVA: 0x001A47D0 File Offset: 0x001A2BD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065F2 RID: 26098 RVA: 0x001A47D7 File Offset: 0x001A2BD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065F3 RID: 26099 RVA: 0x001A47E0 File Offset: 0x001A2BE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SoulCollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SoulCollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005EDD RID: 24285
		internal AdventureEventType evtType;

		// Token: 0x04005EDE RID: 24286
		internal IBattleUnit effectCarrier;

		// Token: 0x04005EDF RID: 24287
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04005EE0 RID: 24288
		internal object evtData;

		// Token: 0x04005EE1 RID: 24289
		internal BattleDamage <damage>__1;

		// Token: 0x04005EE2 RID: 24290
		internal IBattleUnit triggerUnit;

		// Token: 0x04005EE3 RID: 24291
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005EE4 RID: 24292
		internal SoulCollectionData <data>__2;

		// Token: 0x04005EE5 RID: 24293
		internal List<IBattleUnit> <liveFriendlyUnits>__2;

		// Token: 0x04005EE6 RID: 24294
		internal IBattleUnit <selected>__3;

		// Token: 0x04005EE7 RID: 24295
		internal BoostType <selectedBoostType>__3;

		// Token: 0x04005EE8 RID: 24296
		internal AttributeType <boostAttributeType>__3;

		// Token: 0x04005EE9 RID: 24297
		internal IEnumerator $locvar0;

		// Token: 0x04005EEA RID: 24298
		internal object <_>__4;

		// Token: 0x04005EEB RID: 24299
		internal IDisposable $locvar1;

		// Token: 0x04005EEC RID: 24300
		internal SoulCollectionEffectProcess $this;

		// Token: 0x04005EED RID: 24301
		internal object $current;

		// Token: 0x04005EEE RID: 24302
		internal bool $disposing;

		// Token: 0x04005EEF RID: 24303
		internal int $PC;

		// Token: 0x04005EF0 RID: 24304
		private SoulCollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000FB9 RID: 4025
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060065F4 RID: 26100 RVA: 0x001A4850 File Offset: 0x001A2C50
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060065F5 RID: 26101 RVA: 0x001A4858 File Offset: 0x001A2C58
			internal bool <>m__0(IBattleUnit e)
			{
				return e == this.triggerUnit;
			}

			// Token: 0x04005EF1 RID: 24305
			internal IBattleUnit triggerUnit;

			// Token: 0x04005EF2 RID: 24306
			internal SoulCollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
