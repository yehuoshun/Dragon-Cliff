using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000900 RID: 2304
public class LifePotionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004036 RID: 16438 RVA: 0x0019C206 File Offset: 0x0019A606
	public LifePotionEffectProcess()
	{
	}

	// Token: 0x17000BC0 RID: 3008
	// (get) Token: 0x06004037 RID: 16439 RVA: 0x0019C215 File Offset: 0x0019A615
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BC1 RID: 3009
	// (get) Token: 0x06004038 RID: 16440 RVA: 0x0019C220 File Offset: 0x0019A620
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06004039 RID: 16441 RVA: 0x0019C23C File Offset: 0x0019A63C
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		LifePotionData data = specialEffectData as LifePotionData;
		if (data != null && evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer == data.IsPlayerUnit && evt.EventTriggeringUnit.Status == BattleUnitStatus.Active)
		{
			ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = (double)data.HealValue,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}, false)
			}, evt.EventTriggeringUnit);
			IEnumerator enumerator = heal.Release().GetEnumerator();
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
			foreach (BattleHeal healBattleHeal in heal.BattleHeals)
			{
				if (healBattleHeal.Heals.Any((HealComponent h) => h.ExceededHealValue > 0.0))
				{
					double totalShield = healBattleHeal.Heals.Sum((HealComponent h) => h.ExceededHealValue).GetValueOrDefault();
					IEnumerator enumerator3 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(healBattleHeal.Target, evt.EventTriggeringUnit, totalShield).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F9D RID: 12189
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.LifePotion;

	// Token: 0x02000F8E RID: 3982
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064C4 RID: 25796 RVA: 0x0019C266 File Offset: 0x0019A666
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060064C5 RID: 25797 RVA: 0x0019C270 File Offset: 0x0019A670
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as LifePotionData);
				if (data == null || evt.EventType != AdventureEventType.UnitReadyInBattle || evt.EventTriggeringUnit.IsPlayer != data.IsPlayerUnit || evt.EventTriggeringUnit.Status != BattleUnitStatus.Active)
				{
					goto IL_328;
				}
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = (double)data.HealValue,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, evt.EventTriggeringUnit);
				enumerator = heal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1BA;
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
			enumerator2 = heal.BattleHeals.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1BA:
				switch (num)
				{
				case 2u:
					Block_18:
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
				while (enumerator2.MoveNext())
				{
					healBattleHeal = enumerator2.Current;
					if (healBattleHeal.Heals.Any((HealComponent h) => h.ExceededHealValue > 0.0))
					{
						totalShield = healBattleHeal.Heals.Sum((HealComponent h) => h.ExceededHealValue).GetValueOrDefault();
						enumerator3 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(healBattleHeal.Target, evt.EventTriggeringUnit, totalShield).GetEnumerator();
						num = 4294967293u;
						goto Block_18;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_328:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700151B RID: 5403
		// (get) Token: 0x060064C6 RID: 25798 RVA: 0x0019C5FC File Offset: 0x0019A9FC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700151C RID: 5404
		// (get) Token: 0x060064C7 RID: 25799 RVA: 0x0019C604 File Offset: 0x0019AA04
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064C8 RID: 25800 RVA: 0x0019C60C File Offset: 0x0019AA0C
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

		// Token: 0x060064C9 RID: 25801 RVA: 0x0019C6E0 File Offset: 0x0019AAE0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064CA RID: 25802 RVA: 0x0019C6E7 File Offset: 0x0019AAE7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064CB RID: 25803 RVA: 0x0019C6F0 File Offset: 0x0019AAF0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifePotionEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new LifePotionEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060064CC RID: 25804 RVA: 0x0019C730 File Offset: 0x0019AB30
		private static bool <>m__0(HealComponent h)
		{
			return h.ExceededHealValue > 0.0;
		}

		// Token: 0x060064CD RID: 25805 RVA: 0x0019C765 File Offset: 0x0019AB65
		private static double? <>m__1(HealComponent h)
		{
			return h.ExceededHealValue;
		}

		// Token: 0x04005CF1 RID: 23793
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005CF2 RID: 23794
		internal LifePotionData <data>__0;

		// Token: 0x04005CF3 RID: 23795
		internal BroadcastEvent evt;

		// Token: 0x04005CF4 RID: 23796
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005CF5 RID: 23797
		internal IEnumerator $locvar0;

		// Token: 0x04005CF6 RID: 23798
		internal object <_>__2;

		// Token: 0x04005CF7 RID: 23799
		internal IDisposable $locvar1;

		// Token: 0x04005CF8 RID: 23800
		internal List<BattleHeal>.Enumerator $locvar2;

		// Token: 0x04005CF9 RID: 23801
		internal BattleHeal <healBattleHeal>__3;

		// Token: 0x04005CFA RID: 23802
		internal double <totalShield>__4;

		// Token: 0x04005CFB RID: 23803
		internal IEnumerator $locvar3;

		// Token: 0x04005CFC RID: 23804
		internal object <_>__5;

		// Token: 0x04005CFD RID: 23805
		internal IDisposable $locvar4;

		// Token: 0x04005CFE RID: 23806
		internal object $current;

		// Token: 0x04005CFF RID: 23807
		internal bool $disposing;

		// Token: 0x04005D00 RID: 23808
		internal int $PC;

		// Token: 0x04005D01 RID: 23809
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x04005D02 RID: 23810
		private static Func<HealComponent, double?> <>f__am$cache1;
	}
}
