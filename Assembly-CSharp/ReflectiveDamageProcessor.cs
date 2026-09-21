using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000525 RID: 1317
public class ReflectiveDamageProcessor : AttributeProcessBase
{
	// Token: 0x060026B2 RID: 9906 RVA: 0x0011456C File Offset: 0x0011296C
	public ReflectiveDamageProcessor()
	{
	}

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x060026B3 RID: 9907 RVA: 0x00114574 File Offset: 0x00112974
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.ReflectiveDamage;
		}
	}

	// Token: 0x060026B4 RID: 9908 RVA: 0x0011457C File Offset: 0x0011297C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x060026B5 RID: 9909 RVA: 0x00114598 File Offset: 0x00112998
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage && eventTriggerUnit == listener)
		{
			BattleDamage battleDamage = data as BattleDamage;
			List<DamageComponentValue> reflectedDamages = new List<DamageComponentValue>();
			foreach (DamageComponent damageComponent in battleDamage.Damages)
			{
				if (!damageComponent.HasFullyNeutralized() && !damageComponent.IsReflectedDamage && !damageComponent.CompleteReflected)
				{
					double reflectiveRateInBattle = listener.GetReflectiveRateInBattle();
					if (listener.IsPlayer)
					{
						if (listener.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad s) => s.GetSpecialEffectType() == SpecialEffectType.Thorns) && listener.SpecialEffects.OfType<HealOverTimeData>().Any<HealOverTimeData>() && (double)UnityEngine.Random.value <= 0.3)
						{
							double damageValue = reflectiveRateInBattle * damageComponent.Dealer.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Gear);
							reflectedDamages.Add(new DamageComponentValue(new List<DamagePotionValue>
							{
								DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Dealer, listener, OutputType.RealDamage, damageValue)
							}, battleDamage.Dealer, listener, false, true));
						}
					}
					double num = (damageComponent.GetTotalRawDamage() - damageComponent.ReflectedDamage) * reflectiveRateInBattle;
					if (num > 0.0)
					{
						damageComponent.ReflectedDamage = damageComponent.GetTotalRawDamage();
						reflectedDamages.Add(new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Dealer, listener, OutputType.RealDamage, num)
						}, battleDamage.Dealer, listener, false, true));
					}
				}
			}
			if (reflectedDamages.Any<DamageComponentValue>())
			{
				ReleaseableDamage releaseable = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(battleDamage.Dealer, new ReflectDamageSource(listener, battleDamage.DamageSource), reflectedDamages)
				}, listener);
				IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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

	// Token: 0x02000DBB RID: 3515
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058BA RID: 22714 RVA: 0x001145D1 File Offset: 0x001129D1
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058BB RID: 22715 RVA: 0x001145DC File Offset: 0x001129DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage || eventTriggerUnit != listener)
				{
					goto IL_31D;
				}
				battleDamage = (data as BattleDamage);
				reflectedDamages = new List<DamageComponentValue>();
				enumerator = battleDamage.Damages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponent damageComponent = enumerator.Current;
						if (!damageComponent.HasFullyNeutralized() && !damageComponent.IsReflectedDamage && !damageComponent.CompleteReflected)
						{
							double reflectiveRateInBattle = listener.GetReflectiveRateInBattle();
							if (listener.IsPlayer)
							{
								if (listener.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad s) => s.GetSpecialEffectType() == SpecialEffectType.Thorns) && listener.SpecialEffects.OfType<HealOverTimeData>().Any<HealOverTimeData>() && (double)UnityEngine.Random.value <= 0.3)
								{
									double damageValue = reflectiveRateInBattle * damageComponent.Dealer.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Gear);
									reflectedDamages.Add(new DamageComponentValue(new List<DamagePotionValue>
									{
										DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Dealer, listener, OutputType.RealDamage, damageValue)
									}, battleDamage.Dealer, listener, false, true));
								}
							}
							double num2 = (damageComponent.GetTotalRawDamage() - damageComponent.ReflectedDamage) * reflectiveRateInBattle;
							if (num2 > 0.0)
							{
								damageComponent.ReflectedDamage = damageComponent.GetTotalRawDamage();
								reflectedDamages.Add(new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Dealer, listener, OutputType.RealDamage, num2)
								}, battleDamage.Dealer, listener, false, true));
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!reflectedDamages.Any<DamageComponentValue>())
				{
					goto IL_31D;
				}
				releaseable = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(battleDamage.Dealer, new ReflectDamageSource(listener, battleDamage.DamageSource), reflectedDamages)
				}, listener);
				enumerator2 = releaseable.Release().GetEnumerator();
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
			IL_31D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001290 RID: 4752
		// (get) Token: 0x060058BC RID: 22716 RVA: 0x00114944 File Offset: 0x00112D44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001291 RID: 4753
		// (get) Token: 0x060058BD RID: 22717 RVA: 0x0011494C File Offset: 0x00112D4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058BE RID: 22718 RVA: 0x00114954 File Offset: 0x00112D54
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060058BF RID: 22719 RVA: 0x001149C4 File Offset: 0x00112DC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058C0 RID: 22720 RVA: 0x001149CB File Offset: 0x00112DCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058C1 RID: 22721 RVA: 0x001149D4 File Offset: 0x00112DD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReflectiveDamageProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new ReflectiveDamageProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.data = data;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x060058C2 RID: 22722 RVA: 0x00114A2C File Offset: 0x00112E2C
		private static bool <>m__0(ISpecialEffectDataLoad s)
		{
			return s.GetSpecialEffectType() == SpecialEffectType.Thorns;
		}

		// Token: 0x0400489B RID: 18587
		internal AdventureEventType eventType;

		// Token: 0x0400489C RID: 18588
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400489D RID: 18589
		internal IBattleUnit listener;

		// Token: 0x0400489E RID: 18590
		internal object data;

		// Token: 0x0400489F RID: 18591
		internal BattleDamage <battleDamage>__1;

		// Token: 0x040048A0 RID: 18592
		internal List<DamageComponentValue> <reflectedDamages>__1;

		// Token: 0x040048A1 RID: 18593
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x040048A2 RID: 18594
		internal ReleaseableDamage <releaseable>__2;

		// Token: 0x040048A3 RID: 18595
		internal IEnumerator $locvar1;

		// Token: 0x040048A4 RID: 18596
		internal object <_>__3;

		// Token: 0x040048A5 RID: 18597
		internal IDisposable $locvar2;

		// Token: 0x040048A6 RID: 18598
		internal object $current;

		// Token: 0x040048A7 RID: 18599
		internal bool $disposing;

		// Token: 0x040048A8 RID: 18600
		internal int $PC;

		// Token: 0x040048A9 RID: 18601
		private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache0;
	}
}
