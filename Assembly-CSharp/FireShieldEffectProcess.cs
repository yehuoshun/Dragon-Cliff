using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008E9 RID: 2281
public class FireShieldEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FCD RID: 16333 RVA: 0x00195B18 File Offset: 0x00193F18
	public FireShieldEffectProcess()
	{
	}

	// Token: 0x17000B94 RID: 2964
	// (get) Token: 0x06003FCE RID: 16334 RVA: 0x00195B20 File Offset: 0x00193F20
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.FireShield;
		}
	}

	// Token: 0x17000B95 RID: 2965
	// (get) Token: 0x06003FCF RID: 16335 RVA: 0x00195B24 File Offset: 0x00193F24
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003FD0 RID: 16336 RVA: 0x00195B40 File Offset: 0x00193F40
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && evtData is DamageComponent && specialEffectData is FireShieldData && triggerUnit == effectCarrier)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage)
			{
				FireShieldData data = specialEffectData as FireShieldData;
				if (damage.Dealer.IsAliveInBattle())
				{
					IEnumerator enumerator = FireSeedEffect.AddFireSeed(damage.Dealer, data.FireSeedRate * damage.Dealer.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
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

	// Token: 0x02000F69 RID: 3945
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063D4 RID: 25556 RVA: 0x00195B81 File Offset: 0x00193F81
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063D5 RID: 25557 RVA: 0x00195B8C File Offset: 0x00193F8C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !(evtData is DamageComponent) || !(specialEffectData is FireShieldData) || triggerUnit != effectCarrier)
				{
					goto IL_170;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage)
				{
					goto IL_170;
				}
				data = (specialEffectData as FireShieldData);
				if (!damage.Dealer.IsAliveInBattle())
				{
					goto IL_170;
				}
				enumerator = FireSeedEffect.AddFireSeed(damage.Dealer, data.FireSeedRate * damage.Dealer.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
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
			IL_170:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014E7 RID: 5351
		// (get) Token: 0x060063D6 RID: 25558 RVA: 0x00195D24 File Offset: 0x00194124
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014E8 RID: 5352
		// (get) Token: 0x060063D7 RID: 25559 RVA: 0x00195D2C File Offset: 0x0019412C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063D8 RID: 25560 RVA: 0x00195D34 File Offset: 0x00194134
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

		// Token: 0x060063D9 RID: 25561 RVA: 0x00195DA4 File Offset: 0x001941A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063DA RID: 25562 RVA: 0x00195DAB File Offset: 0x001941AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063DB RID: 25563 RVA: 0x00195DB4 File Offset: 0x001941B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FireShieldEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B63 RID: 23395
		internal AdventureEventType evtType;

		// Token: 0x04005B64 RID: 23396
		internal object evtData;

		// Token: 0x04005B65 RID: 23397
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B66 RID: 23398
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B67 RID: 23399
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B68 RID: 23400
		internal DamageComponent <damage>__1;

		// Token: 0x04005B69 RID: 23401
		internal FireShieldData <data>__2;

		// Token: 0x04005B6A RID: 23402
		internal IEnumerator $locvar0;

		// Token: 0x04005B6B RID: 23403
		internal object <_>__3;

		// Token: 0x04005B6C RID: 23404
		internal IDisposable $locvar1;

		// Token: 0x04005B6D RID: 23405
		internal object $current;

		// Token: 0x04005B6E RID: 23406
		internal bool $disposing;

		// Token: 0x04005B6F RID: 23407
		internal int $PC;
	}
}
