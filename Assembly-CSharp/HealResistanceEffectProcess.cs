using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F5 RID: 2293
public class HealResistanceEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004001 RID: 16385 RVA: 0x0019860C File Offset: 0x00196A0C
	public HealResistanceEffectProcess()
	{
	}

	// Token: 0x17000BAC RID: 2988
	// (get) Token: 0x06004002 RID: 16386 RVA: 0x0019863F File Offset: 0x00196A3F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BAD RID: 2989
	// (get) Token: 0x06004003 RID: 16387 RVA: 0x00198647 File Offset: 0x00196A47
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06004004 RID: 16388 RVA: 0x00198650 File Offset: 0x00196A50
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.PostHealRelease && triggerUnit == effectCarrier && triggerUnit.IsPlayer && triggerUnit.GetUnitClassStyle() == UnitClassStyle.Healer && evtData is ReleaseableHeal && specialEffectData is HealResistanceData)
		{
			ReleaseableHeal heal = evtData as ReleaseableHeal;
			HealResistanceData data = specialEffectData as HealResistanceData;
			foreach (BattleHeal battleHeal in (from h in heal.BattleHeals
			where h.Heals.Any((HealComponent hh) => hh.IsDirectHeal)
			select h).ToList<BattleHeal>())
			{
				IEnumerator enumerator2 = battleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						Value = data.BoostRate,
						ModificationType = ModificationType.Multiplication,
						Key = string.Empty,
						AttributeType = AttributeType.EffectResistanceRating,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "healresistanceboostunique", new int?(1), null, new int?(3), false, true, false), false).GetEnumerator();
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

	// Token: 0x04002F97 RID: 12183
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.HealResistanceBoost;

	// Token: 0x04002F98 RID: 12184
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.PostHealRelease
	};

	// Token: 0x02000F7A RID: 3962
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600643C RID: 25660 RVA: 0x00198691 File Offset: 0x00196A91
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600643D RID: 25661 RVA: 0x0019869C File Offset: 0x00196A9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.PostHealRelease || triggerUnit != effectCarrier || !triggerUnit.IsPlayer || triggerUnit.GetUnitClassStyle() != UnitClassStyle.Healer || !(evtData is ReleaseableHeal) || !(specialEffectData is HealResistanceData))
				{
					goto IL_24C;
				}
				heal = (evtData as ReleaseableHeal);
				data = (specialEffectData as HealResistanceData);
				enumerator = (from h in heal.BattleHeals
				where h.Heals.Any((HealComponent hh) => hh.IsDirectHeal)
				select h).ToList<BattleHeal>().GetEnumerator();
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
					Block_11:
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
					battleHeal = enumerator.Current;
					enumerator2 = battleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							Value = data.BoostRate,
							ModificationType = ModificationType.Multiplication,
							Key = string.Empty,
							AttributeType = AttributeType.EffectResistanceRating,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "healresistanceboostunique", new int?(1), null, new int?(3), false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_24C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014FD RID: 5373
		// (get) Token: 0x0600643E RID: 25662 RVA: 0x00198934 File Offset: 0x00196D34
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014FE RID: 5374
		// (get) Token: 0x0600643F RID: 25663 RVA: 0x0019893C File Offset: 0x00196D3C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006440 RID: 25664 RVA: 0x00198944 File Offset: 0x00196D44
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

		// Token: 0x06006441 RID: 25665 RVA: 0x001989D8 File Offset: 0x00196DD8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006442 RID: 25666 RVA: 0x001989DF File Offset: 0x00196DDF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006443 RID: 25667 RVA: 0x001989E8 File Offset: 0x00196DE8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealResistanceEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new HealResistanceEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006444 RID: 25668 RVA: 0x00198A4C File Offset: 0x00196E4C
		private static bool <>m__0(BattleHeal h)
		{
			return h.Heals.Any((HealComponent hh) => hh.IsDirectHeal);
		}

		// Token: 0x06006445 RID: 25669 RVA: 0x00198A76 File Offset: 0x00196E76
		private static bool <>m__1(HealComponent hh)
		{
			return hh.IsDirectHeal;
		}

		// Token: 0x04005C00 RID: 23552
		internal AdventureEventType evtType;

		// Token: 0x04005C01 RID: 23553
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C02 RID: 23554
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C03 RID: 23555
		internal object evtData;

		// Token: 0x04005C04 RID: 23556
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C05 RID: 23557
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005C06 RID: 23558
		internal HealResistanceData <data>__1;

		// Token: 0x04005C07 RID: 23559
		internal List<BattleHeal>.Enumerator $locvar0;

		// Token: 0x04005C08 RID: 23560
		internal BattleHeal <battleHeal>__2;

		// Token: 0x04005C09 RID: 23561
		internal IEnumerator $locvar1;

		// Token: 0x04005C0A RID: 23562
		internal object <_>__3;

		// Token: 0x04005C0B RID: 23563
		internal IDisposable $locvar2;

		// Token: 0x04005C0C RID: 23564
		internal object $current;

		// Token: 0x04005C0D RID: 23565
		internal bool $disposing;

		// Token: 0x04005C0E RID: 23566
		internal int $PC;

		// Token: 0x04005C0F RID: 23567
		private static Func<BattleHeal, bool> <>f__am$cache0;

		// Token: 0x04005C10 RID: 23568
		private static Func<HealComponent, bool> <>f__am$cache1;
	}
}
