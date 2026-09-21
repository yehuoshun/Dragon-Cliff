using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C6 RID: 2246
public class DarknessRevengeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F37 RID: 16183 RVA: 0x0018BCC3 File Offset: 0x0018A0C3
	public DarknessRevengeEffectProcess()
	{
	}

	// Token: 0x17000B4E RID: 2894
	// (get) Token: 0x06003F38 RID: 16184 RVA: 0x0018BCD3 File Offset: 0x0018A0D3
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B4F RID: 2895
	// (get) Token: 0x06003F39 RID: 16185 RVA: 0x0018BCDC File Offset: 0x0018A0DC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.AdventureInitialized,
				AdventureEventType.UnitPostReceivesDamage_Single,
				AdventureEventType.UnitEffectTriggered
			};
		}
	}

	// Token: 0x06003F3A RID: 16186 RVA: 0x0018BD08 File Offset: 0x0018A108
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.AdventureInitialized)
		{
			DarknessRevengeData darknessRevengeData = specialEffectData as DarknessRevengeData;
			if (darknessRevengeData != null)
			{
				darknessRevengeData.RevengeChargedSoFar = 0.0;
			}
		}
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single)
		{
			DamageComponent damageComponent = evt.AdditionalData as DamageComponent;
			DarknessRevengeData data = specialEffectData as DarknessRevengeData;
			if (damageComponent != null && data != null && !damageComponent.Dealer.IsPlayer && damageComponent.IsDirectDamage && !damageComponent.IsMissed)
			{
				double rawDamage = damageComponent.GetTotalDamageSoFar() * data.DarkDamageRatio;
				if (rawDamage > 0.0)
				{
					IEnumerator enumerator = damageComponent.Target.ApplySkillEffect(DamageOverTimeEffect.CreateDarknessRevengeEffect(rawDamage, damageComponent.Dealer, damageComponent.Target), false).GetEnumerator();
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
		if (evt.EventType == AdventureEventType.UnitEffectTriggered && evt.EventTriggeringUnit.IsPlayer)
		{
			DarknessRevengeData data2 = specialEffectData as DarknessRevengeData;
			if (evt.AdditionalData is DamageOverTimeEffect && data2 != null)
			{
				DamageOverTimeEffect dot = evt.AdditionalData as DamageOverTimeEffect;
				if (dot.EffectSourceIdentityCode == DamageOverTimeEffect.DarknessRevengeEffectKey)
				{
					data2.RevengeChargedSoFar += data2.RevengeChargeRatio;
					if (data2.RevengeChargedSoFar >= 100.0)
					{
						data2.RevengeChargedSoFar -= 100.0;
						BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
						if (battleEncounter != null)
						{
							List<IBattleUnit> playerUnits = (from u in battleEncounter.PlayerUnits
							where u.Status == BattleUnitStatus.Active
							select u).ToList<IBattleUnit>();
							foreach (IBattleUnit playerUnit in playerUnits)
							{
								IEnumerator enumerator3 = playerUnit.ApplySkillEffect(AttributeModificationEffect.CreateSinisterRageEffect(dot.EffectSource.SourceUnit, data2.AgilityPenaltyRatio, data2.RageRatioPenaltyRatio), false).GetEnumerator();
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
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F76 RID: 12150
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DarknessRevengeEffect;

	// Token: 0x02000F40 RID: 3904
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062A6 RID: 25254 RVA: 0x0018BD32 File Offset: 0x0018A132
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060062A7 RID: 25255 RVA: 0x0018BD3C File Offset: 0x0018A13C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType == AdventureEventType.AdventureInitialized)
				{
					DarknessRevengeData darknessRevengeData = specialEffectData as DarknessRevengeData;
					if (darknessRevengeData != null)
					{
						darknessRevengeData.RevengeChargedSoFar = 0.0;
					}
				}
				if (evt.EventType != AdventureEventType.UnitPostReceivesDamage_Single)
				{
					goto IL_1CF;
				}
				damageComponent = (evt.AdditionalData as DamageComponent);
				data = (specialEffectData as DarknessRevengeData);
				if (damageComponent == null || data == null || damageComponent.Dealer.IsPlayer || !damageComponent.IsDirectDamage || damageComponent.IsMissed)
				{
					goto IL_1CF;
				}
				rawDamage = damageComponent.GetTotalDamageSoFar() * data.DarkDamageRatio;
				if (rawDamage <= 0.0)
				{
					goto IL_1CF;
				}
				enumerator = damageComponent.Target.ApplySkillEffect(DamageOverTimeEffect.CreateDarknessRevengeEffect(rawDamage, damageComponent.Dealer, damageComponent.Target), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_20:
				try
				{
					switch (num)
					{
					case 2u:
						Block_28:
						try
						{
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
						break;
					}
					if (enumerator2.MoveNext())
					{
						playerUnit = enumerator2.Current;
						enumerator3 = playerUnit.ApplySkillEffect(AttributeModificationEffect.CreateSinisterRageEffect(dot.EffectSource.SourceUnit, data2.AgilityPenaltyRatio, data2.RageRatioPenaltyRatio), false).GetEnumerator();
						num = 4294967293u;
						goto Block_28;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				goto IL_42E;
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
			IL_1CF:
			if (evt.EventType == AdventureEventType.UnitEffectTriggered && evt.EventTriggeringUnit.IsPlayer)
			{
				data2 = (specialEffectData as DarknessRevengeData);
				if (evt.AdditionalData is DamageOverTimeEffect && data2 != null)
				{
					dot = (evt.AdditionalData as DamageOverTimeEffect);
					if (dot.EffectSourceIdentityCode == DamageOverTimeEffect.DarknessRevengeEffectKey)
					{
						data2.RevengeChargedSoFar += data2.RevengeChargeRatio;
						if (data2.RevengeChargedSoFar >= 100.0)
						{
							data2.RevengeChargedSoFar -= 100.0;
							battleEncounter = (evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter);
							if (battleEncounter != null)
							{
								playerUnits = (from u in battleEncounter.PlayerUnits
								where u.Status == BattleUnitStatus.Active
								select u).ToList<IBattleUnit>();
								enumerator2 = playerUnits.GetEnumerator();
								num = 4294967293u;
								goto Block_20;
							}
						}
					}
				}
			}
			IL_42E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014A5 RID: 5285
		// (get) Token: 0x060062A8 RID: 25256 RVA: 0x0018C1AC File Offset: 0x0018A5AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014A6 RID: 5286
		// (get) Token: 0x060062A9 RID: 25257 RVA: 0x0018C1B4 File Offset: 0x0018A5B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062AA RID: 25258 RVA: 0x0018C1BC File Offset: 0x0018A5BC
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
			case 2u:
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x060062AB RID: 25259 RVA: 0x0018C290 File Offset: 0x0018A690
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062AC RID: 25260 RVA: 0x0018C297 File Offset: 0x0018A697
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062AD RID: 25261 RVA: 0x0018C2A0 File Offset: 0x0018A6A0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DarknessRevengeEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new DarknessRevengeEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060062AE RID: 25262 RVA: 0x0018C2E0 File Offset: 0x0018A6E0
		private static bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x0400592B RID: 22827
		internal BroadcastEvent evt;

		// Token: 0x0400592C RID: 22828
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400592D RID: 22829
		internal DamageComponent <damageComponent>__1;

		// Token: 0x0400592E RID: 22830
		internal DarknessRevengeData <data>__1;

		// Token: 0x0400592F RID: 22831
		internal double <rawDamage>__2;

		// Token: 0x04005930 RID: 22832
		internal IEnumerator $locvar0;

		// Token: 0x04005931 RID: 22833
		internal object <_>__3;

		// Token: 0x04005932 RID: 22834
		internal IDisposable $locvar1;

		// Token: 0x04005933 RID: 22835
		internal DarknessRevengeData <data>__4;

		// Token: 0x04005934 RID: 22836
		internal DamageOverTimeEffect <dot>__5;

		// Token: 0x04005935 RID: 22837
		internal BattleEncounter <battleEncounter>__6;

		// Token: 0x04005936 RID: 22838
		internal List<IBattleUnit> <playerUnits>__7;

		// Token: 0x04005937 RID: 22839
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04005938 RID: 22840
		internal IBattleUnit <playerUnit>__8;

		// Token: 0x04005939 RID: 22841
		internal IEnumerator $locvar3;

		// Token: 0x0400593A RID: 22842
		internal object <_>__9;

		// Token: 0x0400593B RID: 22843
		internal IDisposable $locvar4;

		// Token: 0x0400593C RID: 22844
		internal object $current;

		// Token: 0x0400593D RID: 22845
		internal bool $disposing;

		// Token: 0x0400593E RID: 22846
		internal int $PC;

		// Token: 0x0400593F RID: 22847
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}
}
