using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008FE RID: 2302
public class LifeBindEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600402C RID: 16428 RVA: 0x0019B737 File Offset: 0x00199B37
	public LifeBindEffectProcess()
	{
	}

	// Token: 0x17000BBC RID: 3004
	// (get) Token: 0x0600402D RID: 16429 RVA: 0x0019B73F File Offset: 0x00199B3F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LifeBind;
		}
	}

	// Token: 0x17000BBD RID: 3005
	// (get) Token: 0x0600402E RID: 16430 RVA: 0x0019B744 File Offset: 0x00199B44
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitKilled
			};
		}
	}

	// Token: 0x0600402F RID: 16431 RVA: 0x0019B768 File Offset: 0x00199B68
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
			where t != triggerUnit
			select t).ToList<IBattleUnit>();
			List<OutputType> types = UnitExtensions.GetAllDamageElements();
			types.Add(OutputType.RealDamage);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new DamageImmuneEffect(LifeBindEffectProcess._key, null, null, effectCarrier, types, false, 1), false).GetEnumerator();
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

	// Token: 0x06004030 RID: 16432 RVA: 0x0019B79C File Offset: 0x00199B9C
	public override IEnumerable AsInactiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> targets = triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			List<OutputType> types = UnitExtensions.GetAllDamageElements();
			types.Add(OutputType.RealDamage);
			foreach (IBattleUnit battleUnit in targets)
			{
				List<DamageImmuneEffect> toremove = (from i in battleUnit.BattleEffects.OfType<DamageImmuneEffect>()
				where i.EffectSourceIdentityCode == LifeBindEffectProcess._key
				select i).ToList<DamageImmuneEffect>();
				foreach (DamageImmuneEffect tor in toremove)
				{
					IEnumerator enumerator3 = battleUnit.LooseSkillEffect(tor, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x06004031 RID: 16433 RVA: 0x0019B7CE File Offset: 0x00199BCE
	// Note: this type is marked as 'beforefieldinit'.
	static LifeBindEffectProcess()
	{
	}

	// Token: 0x04002F9C RID: 12188
	private static string _key = "lifebind";

	// Token: 0x02000F88 RID: 3976
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064A6 RID: 25766 RVA: 0x0019B7DA File Offset: 0x00199BDA
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060064A7 RID: 25767 RVA: 0x0019B7E4 File Offset: 0x00199BE4
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
					goto IL_1E0;
				}
				targets = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				where t != triggerUnit
				select t).ToList<IBattleUnit>();
				types = UnitExtensions.GetAllDamageElements();
				types.Add(OutputType.RealDamage);
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
					enumerator2 = battleUnit.ApplySkillEffect(new DamageImmuneEffect(LifeBindEffectProcess._key, null, null, effectCarrier, types, false, 1), false).GetEnumerator();
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
			IL_1E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001515 RID: 5397
		// (get) Token: 0x060064A8 RID: 25768 RVA: 0x0019B9F8 File Offset: 0x00199DF8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001516 RID: 5398
		// (get) Token: 0x060064A9 RID: 25769 RVA: 0x0019BA00 File Offset: 0x00199E00
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064AA RID: 25770 RVA: 0x0019BA08 File Offset: 0x00199E08
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

		// Token: 0x060064AB RID: 25771 RVA: 0x0019BA9C File Offset: 0x00199E9C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064AC RID: 25772 RVA: 0x0019BAA3 File Offset: 0x00199EA3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064AD RID: 25773 RVA: 0x0019BAAC File Offset: 0x00199EAC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeBindEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new LifeBindEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005CBF RID: 23743
		internal AdventureEventType evtType;

		// Token: 0x04005CC0 RID: 23744
		internal IBattleUnit triggerUnit;

		// Token: 0x04005CC1 RID: 23745
		internal IBattleUnit effectCarrier;

		// Token: 0x04005CC2 RID: 23746
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005CC3 RID: 23747
		internal List<OutputType> <types>__1;

		// Token: 0x04005CC4 RID: 23748
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005CC5 RID: 23749
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005CC6 RID: 23750
		internal IEnumerator $locvar1;

		// Token: 0x04005CC7 RID: 23751
		internal object <_>__3;

		// Token: 0x04005CC8 RID: 23752
		internal IDisposable $locvar2;

		// Token: 0x04005CC9 RID: 23753
		internal object $current;

		// Token: 0x04005CCA RID: 23754
		internal bool $disposing;

		// Token: 0x04005CCB RID: 23755
		internal int $PC;

		// Token: 0x04005CCC RID: 23756
		private LifeBindEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000F8A RID: 3978
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x060064B7 RID: 25783 RVA: 0x0019BAF8 File Offset: 0x00199EF8
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060064B8 RID: 25784 RVA: 0x0019BB00 File Offset: 0x00199F00
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.triggerUnit;
			}

			// Token: 0x04005CDE RID: 23774
			internal IBattleUnit triggerUnit;

			// Token: 0x04005CDF RID: 23775
			internal LifeBindEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000F89 RID: 3977
	[CompilerGenerated]
	private sealed class <AsInactiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064AE RID: 25774 RVA: 0x0019BB0E File Offset: 0x00199F0E
		[DebuggerHidden]
		public <AsInactiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060064AF RID: 25775 RVA: 0x0019BB18 File Offset: 0x00199F18
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
					goto IL_20B;
				}
				targets = triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				types = UnitExtensions.GetAllDamageElements();
				types.Add(OutputType.RealDamage);
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
						case 1u:
							Block_10:
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
							tor = enumerator2.Current;
							enumerator3 = battleUnit.LooseSkillEffect(tor, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_10;
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
					toremove = (from i in battleUnit.BattleEffects.OfType<DamageImmuneEffect>()
					where i.EffectSourceIdentityCode == LifeBindEffectProcess._key
					select i).ToList<DamageImmuneEffect>();
					enumerator2 = toremove.GetEnumerator();
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
			IL_20B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001517 RID: 5399
		// (get) Token: 0x060064B0 RID: 25776 RVA: 0x0019BD88 File Offset: 0x0019A188
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001518 RID: 5400
		// (get) Token: 0x060064B1 RID: 25777 RVA: 0x0019BD90 File Offset: 0x0019A190
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064B2 RID: 25778 RVA: 0x0019BD98 File Offset: 0x0019A198
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

		// Token: 0x060064B3 RID: 25779 RVA: 0x0019BE50 File Offset: 0x0019A250
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064B4 RID: 25780 RVA: 0x0019BE57 File Offset: 0x0019A257
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064B5 RID: 25781 RVA: 0x0019BE60 File Offset: 0x0019A260
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeBindEffectProcess.<AsInactiveUnitProcess>c__Iterator1 <AsInactiveUnitProcess>c__Iterator = new LifeBindEffectProcess.<AsInactiveUnitProcess>c__Iterator1();
			<AsInactiveUnitProcess>c__Iterator.evtType = evtType;
			<AsInactiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsInactiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsInactiveUnitProcess>c__Iterator;
		}

		// Token: 0x060064B6 RID: 25782 RVA: 0x0019BEAC File Offset: 0x0019A2AC
		private static bool <>m__0(DamageImmuneEffect i)
		{
			return i.EffectSourceIdentityCode == LifeBindEffectProcess._key;
		}

		// Token: 0x04005CCD RID: 23757
		internal AdventureEventType evtType;

		// Token: 0x04005CCE RID: 23758
		internal IBattleUnit triggerUnit;

		// Token: 0x04005CCF RID: 23759
		internal IBattleUnit effectCarrier;

		// Token: 0x04005CD0 RID: 23760
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005CD1 RID: 23761
		internal List<OutputType> <types>__1;

		// Token: 0x04005CD2 RID: 23762
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005CD3 RID: 23763
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005CD4 RID: 23764
		internal List<DamageImmuneEffect> <toremove>__3;

		// Token: 0x04005CD5 RID: 23765
		internal List<DamageImmuneEffect>.Enumerator $locvar1;

		// Token: 0x04005CD6 RID: 23766
		internal DamageImmuneEffect <tor>__4;

		// Token: 0x04005CD7 RID: 23767
		internal IEnumerator $locvar2;

		// Token: 0x04005CD8 RID: 23768
		internal object <_>__5;

		// Token: 0x04005CD9 RID: 23769
		internal IDisposable $locvar3;

		// Token: 0x04005CDA RID: 23770
		internal object $current;

		// Token: 0x04005CDB RID: 23771
		internal bool $disposing;

		// Token: 0x04005CDC RID: 23772
		internal int $PC;

		// Token: 0x04005CDD RID: 23773
		private static Func<DamageImmuneEffect, bool> <>f__am$cache0;
	}
}
