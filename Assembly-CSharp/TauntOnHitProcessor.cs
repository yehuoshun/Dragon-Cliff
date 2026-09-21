using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x02000527 RID: 1319
public class TauntOnHitProcessor : AttributeProcessBase
{
	// Token: 0x060026BA RID: 9914 RVA: 0x00114DB4 File Offset: 0x001131B4
	public TauntOnHitProcessor()
	{
	}

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x060026BB RID: 9915 RVA: 0x00114DBC File Offset: 0x001131BC
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.TauntOnHit;
		}
	}

	// Token: 0x060026BC RID: 9916 RVA: 0x00114DC4 File Offset: 0x001131C4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x060026BD RID: 9917 RVA: 0x00114DE0 File Offset: 0x001131E0
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage battleDamage = data as ReleaseableDamage;
			double rate = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.TauntOnHit, AttributeRetrievalLevel.Skill);
			if (rate > 0.0)
			{
				bool isNonresistable = battleDamage.Dealer.GetUnitType() == UnitClass.Warrior && battleDamage.Dealer.SpecialEffects.OfType<WarriorStarTauntData>().Any<WarriorStarTauntData>() && (double)UnityEngine.Random.value <= battleDamage.Dealer.SpecialEffects.OfType<WarriorStarTauntData>().First<WarriorStarTauntData>().NonResistRate;
				foreach (BattleDamage battleDamageBattleDamage in battleDamage.BattleDamages)
				{
					bool taunt = false;
					foreach (DamageComponent damageComponent in battleDamageBattleDamage.Damages)
					{
						if (!damageComponent.IsMissed && damageComponent.IsDirectDamage && (double)UnityEngine.Random.value <= rate)
						{
							taunt = true;
						}
					}
					if (taunt)
					{
						IEnumerator enumerator3 = battleDamageBattleDamage.Target.ApplySkillEffect(new TauntEffect(battleDamage.Dealer, battleDamageBattleDamage.Target, battleDamage.Dealer, new int?(3), !isNonresistable), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000DBD RID: 3517
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058CB RID: 22731 RVA: 0x00114E19 File Offset: 0x00113219
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058CC RID: 22732 RVA: 0x00114E24 File Offset: 0x00113224
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || eventTriggerUnit != listener || !(data is ReleaseableDamage))
				{
					goto IL_2C4;
				}
				battleDamage = (data as ReleaseableDamage);
				rate = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.TauntOnHit, AttributeRetrievalLevel.Skill);
				if (rate <= 0.0)
				{
					goto IL_2C4;
				}
				isNonresistable = (battleDamage.Dealer.GetUnitType() == UnitClass.Warrior && battleDamage.Dealer.SpecialEffects.OfType<WarriorStarTauntData>().Any<WarriorStarTauntData>() && (double)UnityEngine.Random.value <= battleDamage.Dealer.SpecialEffects.OfType<WarriorStarTauntData>().First<WarriorStarTauntData>().NonResistRate);
				enumerator = battleDamage.BattleDamages.GetEnumerator();
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
					Block_12:
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
				while (enumerator.MoveNext())
				{
					battleDamageBattleDamage = enumerator.Current;
					taunt = false;
					enumerator2 = battleDamageBattleDamage.Damages.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							DamageComponent damageComponent = enumerator2.Current;
							if (!damageComponent.IsMissed && damageComponent.IsDirectDamage && (double)UnityEngine.Random.value <= rate)
							{
								taunt = true;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (taunt)
					{
						enumerator3 = battleDamageBattleDamage.Target.ApplySkillEffect(new TauntEffect(battleDamage.Dealer, battleDamageBattleDamage.Target, battleDamage.Dealer, new int?(3), !isNonresistable), false).GetEnumerator();
						num = 4294967293u;
						goto Block_12;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2C4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001294 RID: 4756
		// (get) Token: 0x060058CD RID: 22733 RVA: 0x0011514C File Offset: 0x0011354C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001295 RID: 4757
		// (get) Token: 0x060058CE RID: 22734 RVA: 0x00115154 File Offset: 0x00113554
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058CF RID: 22735 RVA: 0x0011515C File Offset: 0x0011355C
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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

		// Token: 0x060058D0 RID: 22736 RVA: 0x001151F0 File Offset: 0x001135F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058D1 RID: 22737 RVA: 0x001151F7 File Offset: 0x001135F7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058D2 RID: 22738 RVA: 0x00115200 File Offset: 0x00113600
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TauntOnHitProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new TauntOnHitProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.data = data;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x040048B8 RID: 18616
		internal AdventureEventType eventType;

		// Token: 0x040048B9 RID: 18617
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040048BA RID: 18618
		internal IBattleUnit listener;

		// Token: 0x040048BB RID: 18619
		internal object data;

		// Token: 0x040048BC RID: 18620
		internal ReleaseableDamage <battleDamage>__1;

		// Token: 0x040048BD RID: 18621
		internal double <rate>__1;

		// Token: 0x040048BE RID: 18622
		internal bool <isNonresistable>__2;

		// Token: 0x040048BF RID: 18623
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x040048C0 RID: 18624
		internal BattleDamage <battleDamageBattleDamage>__3;

		// Token: 0x040048C1 RID: 18625
		internal bool <taunt>__4;

		// Token: 0x040048C2 RID: 18626
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x040048C3 RID: 18627
		internal IEnumerator $locvar2;

		// Token: 0x040048C4 RID: 18628
		internal object <_>__5;

		// Token: 0x040048C5 RID: 18629
		internal IDisposable $locvar3;

		// Token: 0x040048C6 RID: 18630
		internal object $current;

		// Token: 0x040048C7 RID: 18631
		internal bool $disposing;

		// Token: 0x040048C8 RID: 18632
		internal int $PC;
	}
}
