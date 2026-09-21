using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008B2 RID: 2226
public class BloodEyeselfProtectionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EDB RID: 16091 RVA: 0x00185E25 File Offset: 0x00184225
	public BloodEyeselfProtectionEffectProcess()
	{
	}

	// Token: 0x17000B26 RID: 2854
	// (get) Token: 0x06003EDC RID: 16092 RVA: 0x00185E35 File Offset: 0x00184235
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B27 RID: 2855
	// (get) Token: 0x06003EDD RID: 16093 RVA: 0x00185E40 File Offset: 0x00184240
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single,
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x06003EDE RID: 16094 RVA: 0x00185E64 File Offset: 0x00184264
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
		{
			BattleEncounter battleEncounter = triggerUnit.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				if (battleEncounter.EnemyUnits.All((IBattleUnit e) => e.Status == BattleUnitStatus.Active))
				{
					DamageComponent damageComponent = evtData as DamageComponent;
					BloodEyeSelfProtectionData data = specialEffectData as BloodEyeSelfProtectionData;
					if (damageComponent != null && data != null && damageComponent.IsDirectDamage && !damageComponent.IsMissed)
					{
						IEnumerator enumerator = damageComponent.Dealer.ApplySkillEffect(new StrangeGhostEffect(data.GhostLastingSeconds, effectCarrier, data.HealPerGhost, data.MaxNumberOfGhostsPerTarget), false).GetEnumerator();
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
		}
		if (evtType == AdventureEventType.BattleEncounterStarts && effectCarrier.IsBoss() && effectCarrier.GetUnitType() == UnitClass.BloodyEye)
		{
			BattleEncounter battleEncounter2 = triggerUnit.CurrentEncounter as BattleEncounter;
			if (battleEncounter2 != null)
			{
				if (battleEncounter2.EnemyUnits.Any((IBattleUnit u) => u.GetUnitType() == UnitClass.Savagery))
				{
					List<IBattleUnit> savageries = (from u in battleEncounter2.EnemyUnits
					where u.GetUnitType() == UnitClass.Savagery
					select u).ToList<IBattleUnit>();
					foreach (IBattleUnit battleUnit in savageries)
					{
						IEnumerator enumerator3 = battleUnit.ApplySkillEffect(new LifeLinkEffect(effectCarrier, 2.0), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F6A RID: 12138
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.BloodEyeSelfProtectionEffect;

	// Token: 0x02000F20 RID: 3872
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061D1 RID: 25041 RVA: 0x00185EA5 File Offset: 0x001842A5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061D2 RID: 25042 RVA: 0x00185EB0 File Offset: 0x001842B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier)
				{
					goto IL_1BD;
				}
				battleEncounter = (triggerUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_1BD;
				}
				if (!battleEncounter.EnemyUnits.All((IBattleUnit e) => e.Status == BattleUnitStatus.Active))
				{
					goto IL_1BD;
				}
				damageComponent = (evtData as DamageComponent);
				data = (specialEffectData as BloodEyeSelfProtectionData);
				if (damageComponent == null || data == null || !damageComponent.IsDirectDamage || damageComponent.IsMissed)
				{
					goto IL_1BD;
				}
				enumerator = damageComponent.Dealer.ApplySkillEffect(new StrangeGhostEffect(data.GhostLastingSeconds, effectCarrier, data.HealPerGhost, data.MaxNumberOfGhostsPerTarget), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_19:
				try
				{
					switch (num)
					{
					case 2u:
						Block_27:
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
						battleUnit = enumerator2.Current;
						enumerator3 = battleUnit.ApplySkillEffect(new LifeLinkEffect(effectCarrier, 2.0), false).GetEnumerator();
						num = 4294967293u;
						goto Block_27;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				goto IL_38B;
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
			IL_1BD:
			if (evtType == AdventureEventType.BattleEncounterStarts && effectCarrier.IsBoss() && effectCarrier.GetUnitType() == UnitClass.BloodyEye)
			{
				battleEncounter2 = (triggerUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter2 != null)
				{
					if (battleEncounter2.EnemyUnits.Any((IBattleUnit u) => u.GetUnitType() == UnitClass.Savagery))
					{
						savageries = (from u in battleEncounter2.EnemyUnits
						where u.GetUnitType() == UnitClass.Savagery
						select u).ToList<IBattleUnit>();
						enumerator2 = savageries.GetEnumerator();
						num = 4294967293u;
						goto Block_19;
					}
				}
			}
			IL_38B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700147B RID: 5243
		// (get) Token: 0x060061D3 RID: 25043 RVA: 0x0018627C File Offset: 0x0018467C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700147C RID: 5244
		// (get) Token: 0x060061D4 RID: 25044 RVA: 0x00186284 File Offset: 0x00184684
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061D5 RID: 25045 RVA: 0x0018628C File Offset: 0x0018468C
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

		// Token: 0x060061D6 RID: 25046 RVA: 0x00186360 File Offset: 0x00184760
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061D7 RID: 25047 RVA: 0x00186367 File Offset: 0x00184767
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061D8 RID: 25048 RVA: 0x00186370 File Offset: 0x00184770
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BloodEyeselfProtectionEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new BloodEyeselfProtectionEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060061D9 RID: 25049 RVA: 0x001863D4 File Offset: 0x001847D4
		private static bool <>m__0(IBattleUnit e)
		{
			return e.Status == BattleUnitStatus.Active;
		}

		// Token: 0x060061DA RID: 25050 RVA: 0x001863DF File Offset: 0x001847DF
		private static bool <>m__1(IBattleUnit u)
		{
			return u.GetUnitType() == UnitClass.Savagery;
		}

		// Token: 0x060061DB RID: 25051 RVA: 0x001863EE File Offset: 0x001847EE
		private static bool <>m__2(IBattleUnit u)
		{
			return u.GetUnitType() == UnitClass.Savagery;
		}

		// Token: 0x040057B6 RID: 22454
		internal AdventureEventType evtType;

		// Token: 0x040057B7 RID: 22455
		internal IBattleUnit triggerUnit;

		// Token: 0x040057B8 RID: 22456
		internal IBattleUnit effectCarrier;

		// Token: 0x040057B9 RID: 22457
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x040057BA RID: 22458
		internal object evtData;

		// Token: 0x040057BB RID: 22459
		internal DamageComponent <damageComponent>__2;

		// Token: 0x040057BC RID: 22460
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040057BD RID: 22461
		internal BloodEyeSelfProtectionData <data>__2;

		// Token: 0x040057BE RID: 22462
		internal IEnumerator $locvar0;

		// Token: 0x040057BF RID: 22463
		internal object <_>__3;

		// Token: 0x040057C0 RID: 22464
		internal IDisposable $locvar1;

		// Token: 0x040057C1 RID: 22465
		internal BattleEncounter <battleEncounter>__4;

		// Token: 0x040057C2 RID: 22466
		internal List<IBattleUnit> <savageries>__5;

		// Token: 0x040057C3 RID: 22467
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x040057C4 RID: 22468
		internal IBattleUnit <battleUnit>__6;

		// Token: 0x040057C5 RID: 22469
		internal IEnumerator $locvar3;

		// Token: 0x040057C6 RID: 22470
		internal object <_>__7;

		// Token: 0x040057C7 RID: 22471
		internal IDisposable $locvar4;

		// Token: 0x040057C8 RID: 22472
		internal object $current;

		// Token: 0x040057C9 RID: 22473
		internal bool $disposing;

		// Token: 0x040057CA RID: 22474
		internal int $PC;

		// Token: 0x040057CB RID: 22475
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x040057CC RID: 22476
		private static Func<IBattleUnit, bool> <>f__am$cache1;

		// Token: 0x040057CD RID: 22477
		private static Func<IBattleUnit, bool> <>f__am$cache2;
	}
}
