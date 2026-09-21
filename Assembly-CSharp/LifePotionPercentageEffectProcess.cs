using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000901 RID: 2305
public class LifePotionPercentageEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600403A RID: 16442 RVA: 0x0019C76D File Offset: 0x0019AB6D
	public LifePotionPercentageEffectProcess()
	{
	}

	// Token: 0x17000BC2 RID: 3010
	// (get) Token: 0x0600403B RID: 16443 RVA: 0x0019C775 File Offset: 0x0019AB75
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LifePotionPercentage;
		}
	}

	// Token: 0x17000BC3 RID: 3011
	// (get) Token: 0x0600403C RID: 16444 RVA: 0x0019C77C File Offset: 0x0019AB7C
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

	// Token: 0x0600403D RID: 16445 RVA: 0x0019C798 File Offset: 0x0019AB98
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		LifePotionPercentageData data = specialEffectData as LifePotionPercentageData;
		if (data != null && evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer == data.IsPlayerUnit && evt.EventTriggeringUnit.Status == BattleUnitStatus.Active)
		{
			ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = data.Rate * evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
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

	// Token: 0x02000F8F RID: 3983
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064CE RID: 25806 RVA: 0x0019C7C2 File Offset: 0x0019ABC2
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060064CF RID: 25807 RVA: 0x0019C7CC File Offset: 0x0019ABCC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as LifePotionPercentageData);
				if (data == null || evt.EventType != AdventureEventType.UnitReadyInBattle || evt.EventTriggeringUnit.IsPlayer != data.IsPlayerUnit || evt.EventTriggeringUnit.Status != BattleUnitStatus.Active)
				{
					goto IL_339;
				}
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = data.Rate * evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
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
				goto IL_1CB;
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
				IL_1CB:
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
			IL_339:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700151D RID: 5405
		// (get) Token: 0x060064D0 RID: 25808 RVA: 0x0019CB68 File Offset: 0x0019AF68
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700151E RID: 5406
		// (get) Token: 0x060064D1 RID: 25809 RVA: 0x0019CB70 File Offset: 0x0019AF70
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064D2 RID: 25810 RVA: 0x0019CB78 File Offset: 0x0019AF78
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

		// Token: 0x060064D3 RID: 25811 RVA: 0x0019CC4C File Offset: 0x0019B04C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064D4 RID: 25812 RVA: 0x0019CC53 File Offset: 0x0019B053
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064D5 RID: 25813 RVA: 0x0019CC5C File Offset: 0x0019B05C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifePotionPercentageEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new LifePotionPercentageEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060064D6 RID: 25814 RVA: 0x0019CC9C File Offset: 0x0019B09C
		private static bool <>m__0(HealComponent h)
		{
			return h.ExceededHealValue > 0.0;
		}

		// Token: 0x060064D7 RID: 25815 RVA: 0x0019CCD1 File Offset: 0x0019B0D1
		private static double? <>m__1(HealComponent h)
		{
			return h.ExceededHealValue;
		}

		// Token: 0x04005D03 RID: 23811
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D04 RID: 23812
		internal LifePotionPercentageData <data>__0;

		// Token: 0x04005D05 RID: 23813
		internal BroadcastEvent evt;

		// Token: 0x04005D06 RID: 23814
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005D07 RID: 23815
		internal IEnumerator $locvar0;

		// Token: 0x04005D08 RID: 23816
		internal object <_>__2;

		// Token: 0x04005D09 RID: 23817
		internal IDisposable $locvar1;

		// Token: 0x04005D0A RID: 23818
		internal List<BattleHeal>.Enumerator $locvar2;

		// Token: 0x04005D0B RID: 23819
		internal BattleHeal <healBattleHeal>__3;

		// Token: 0x04005D0C RID: 23820
		internal double <totalShield>__4;

		// Token: 0x04005D0D RID: 23821
		internal IEnumerator $locvar3;

		// Token: 0x04005D0E RID: 23822
		internal object <_>__5;

		// Token: 0x04005D0F RID: 23823
		internal IDisposable $locvar4;

		// Token: 0x04005D10 RID: 23824
		internal object $current;

		// Token: 0x04005D11 RID: 23825
		internal bool $disposing;

		// Token: 0x04005D12 RID: 23826
		internal int $PC;

		// Token: 0x04005D13 RID: 23827
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x04005D14 RID: 23828
		private static Func<HealComponent, double?> <>f__am$cache1;
	}
}
