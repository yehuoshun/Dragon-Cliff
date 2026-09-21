using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000524 RID: 1316
public class LifeOnHitProcessor : AttributeProcessBase
{
	// Token: 0x060026AE RID: 9902 RVA: 0x00114114 File Offset: 0x00112514
	public LifeOnHitProcessor()
	{
	}

	// Token: 0x170002EE RID: 750
	// (get) Token: 0x060026AF RID: 9903 RVA: 0x0011411C File Offset: 0x0011251C
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.LifeOnHit;
		}
	}

	// Token: 0x060026B0 RID: 9904 RVA: 0x00114124 File Offset: 0x00112524
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x060026B1 RID: 9905 RVA: 0x00114140 File Offset: 0x00112540
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage battleDamage = data as ReleaseableDamage;
			double totalHealValue = 0.0;
			double loh = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.LifeOnHit, AttributeRetrievalLevel.Skill);
			foreach (BattleDamage battleDamage2 in battleDamage.BattleDamages)
			{
				foreach (DamageComponent damageComponent in battleDamage2.Damages)
				{
					if (!damageComponent.HasFullyNeutralized() && damageComponent.IsDirectDamage)
					{
						double num = loh * damageComponent.GetTotalDamageSoFar();
						if (num > 0.0)
						{
							totalHealValue += num;
						}
					}
				}
			}
			double maxPossiblePerAttack = battleDamage.Dealer.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.2;
			if (totalHealValue > maxPossiblePerAttack)
			{
				totalHealValue = maxPossiblePerAttack;
			}
			if (totalHealValue > 0.0)
			{
				ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(battleDamage.Dealer, battleDamage.Dealer, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHealValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, battleDamage.Dealer);
				IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000DBA RID: 3514
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058B2 RID: 22706 RVA: 0x00114179 File Offset: 0x00112579
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058B3 RID: 22707 RVA: 0x00114184 File Offset: 0x00112584
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
					goto IL_2C0;
				}
				battleDamage = (data as ReleaseableDamage);
				totalHealValue = 0.0;
				loh = battleDamage.Dealer.GetAttributeValue_Final(AttributeType.LifeOnHit, AttributeRetrievalLevel.Skill);
				enumerator = battleDamage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage2 = enumerator.Current;
						foreach (DamageComponent damageComponent in battleDamage2.Damages)
						{
							if (!damageComponent.HasFullyNeutralized() && damageComponent.IsDirectDamage)
							{
								double num2 = loh * damageComponent.GetTotalDamageSoFar();
								if (num2 > 0.0)
								{
									totalHealValue += num2;
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				maxPossiblePerAttack = battleDamage.Dealer.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.2;
				if (totalHealValue > maxPossiblePerAttack)
				{
					totalHealValue = maxPossiblePerAttack;
				}
				if (totalHealValue <= 0.0)
				{
					goto IL_2C0;
				}
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(battleDamage.Dealer, battleDamage.Dealer, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHealValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, battleDamage.Dealer);
				enumerator3 = releaseable.Release().GetEnumerator();
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
			IL_2C0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700128E RID: 4750
		// (get) Token: 0x060058B4 RID: 22708 RVA: 0x00114484 File Offset: 0x00112884
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700128F RID: 4751
		// (get) Token: 0x060058B5 RID: 22709 RVA: 0x0011448C File Offset: 0x0011288C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058B6 RID: 22710 RVA: 0x00114494 File Offset: 0x00112894
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060058B7 RID: 22711 RVA: 0x00114504 File Offset: 0x00112904
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058B8 RID: 22712 RVA: 0x0011450B File Offset: 0x0011290B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058B9 RID: 22713 RVA: 0x00114514 File Offset: 0x00112914
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeOnHitProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new LifeOnHitProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.data = data;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x0400488B RID: 18571
		internal AdventureEventType eventType;

		// Token: 0x0400488C RID: 18572
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400488D RID: 18573
		internal IBattleUnit listener;

		// Token: 0x0400488E RID: 18574
		internal object data;

		// Token: 0x0400488F RID: 18575
		internal ReleaseableDamage <battleDamage>__1;

		// Token: 0x04004890 RID: 18576
		internal double <totalHealValue>__1;

		// Token: 0x04004891 RID: 18577
		internal double <loh>__1;

		// Token: 0x04004892 RID: 18578
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004893 RID: 18579
		internal double <maxPossiblePerAttack>__1;

		// Token: 0x04004894 RID: 18580
		internal ReleaseableHeal <releaseable>__2;

		// Token: 0x04004895 RID: 18581
		internal IEnumerator $locvar2;

		// Token: 0x04004896 RID: 18582
		internal object <_>__3;

		// Token: 0x04004897 RID: 18583
		internal IDisposable $locvar3;

		// Token: 0x04004898 RID: 18584
		internal object $current;

		// Token: 0x04004899 RID: 18585
		internal bool $disposing;

		// Token: 0x0400489A RID: 18586
		internal int $PC;
	}
}
