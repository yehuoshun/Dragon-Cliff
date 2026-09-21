using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F0 RID: 2288
public class GrowthSpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FEC RID: 16364 RVA: 0x00196EB7 File Offset: 0x001952B7
	public GrowthSpecialEffectProcess()
	{
	}

	// Token: 0x17000BA2 RID: 2978
	// (get) Token: 0x06003FED RID: 16365 RVA: 0x00196EBF File Offset: 0x001952BF
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Growth;
		}
	}

	// Token: 0x17000BA3 RID: 2979
	// (get) Token: 0x06003FEE RID: 16366 RVA: 0x00196EC4 File Offset: 0x001952C4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage,
				AdventureEventType.UnitPostReceivesHeal
			};
		}
	}

	// Token: 0x06003FEF RID: 16367 RVA: 0x00196EE8 File Offset: 0x001952E8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		GrowthData growthData = specialEffectData as GrowthData;
		Item item = effectCarrier.Items.FirstOrDefault((Item i) => i.GetSpecialEffects().Any((ISpecialEffectDataLoad e) => e is GrowthData && (e as GrowthData).Id == growthData.Id));
		if (growthData == null)
		{
			yield break;
		}
		if (growthData.CurrentGrowthValue >= growthData.MaxGrowthValue)
		{
			yield break;
		}
		if (item == null)
		{
			yield break;
		}
		if (growthData.Condition == GrowthConditionType.DealCritDamage || growthData.Condition == GrowthConditionType.DealDamage || growthData.Condition == GrowthConditionType.ReceiveCritDamage || growthData.Condition == GrowthConditionType.ReceiveDamage)
		{
			if (evtType == AdventureEventType.UnitPostReceivesDamage)
			{
				BattleDamage battleDamage = evtData as BattleDamage;
				foreach (DamageComponent damageComponent in battleDamage.Damages)
				{
					if (!damageComponent.HasFullyNeutralized())
					{
						if (battleDamage.Dealer == effectCarrier && ((growthData.Condition == GrowthConditionType.DealCritDamage && damageComponent.IsCrit) || (growthData.Condition == GrowthConditionType.DealDamage && damageComponent.GetTotalDamageSoFar() >= growthData.ConditionValue)))
						{
							GrowthSpecialEffectProcess.UpdateValue(item, growthData);
						}
						if (triggerUnit == effectCarrier && ((growthData.Condition == GrowthConditionType.ReceiveDamage && growthData.CurrentGrowthValue < growthData.MaxGrowthValue) || (growthData.Condition == GrowthConditionType.ReceiveCritDamage && damageComponent.IsCrit)))
						{
							GrowthSpecialEffectProcess.UpdateValue(item, growthData);
						}
					}
				}
			}
			yield break;
		}
		if (evtType == AdventureEventType.UnitPostReceivesHeal)
		{
			BattleHeal battleHeal = evtData as BattleHeal;
			foreach (HealComponent healComponent in battleHeal.Heals)
			{
				if ((growthData.Condition == GrowthConditionType.Heal && battleHeal.Healer == effectCarrier && healComponent.GetFinalHealSoFar() >= growthData.ConditionValue) || (growthData.Condition == GrowthConditionType.CritHeal && battleHeal.Healer == effectCarrier && healComponent.IsCrit))
				{
					GrowthSpecialEffectProcess.UpdateValue(item, growthData);
				}
				if ((growthData.Condition == GrowthConditionType.ReceiveHeal && triggerUnit == effectCarrier && healComponent.GetFinalHealSoFar() >= growthData.ConditionValue) || (growthData.Condition == GrowthConditionType.ReceiveCritHeal && healComponent.IsCrit && triggerUnit == effectCarrier))
				{
					GrowthSpecialEffectProcess.UpdateValue(item, growthData);
				}
			}
		}
		yield break;
	}

	// Token: 0x06003FF0 RID: 16368 RVA: 0x00196F2C File Offset: 0x0019532C
	private static void UpdateValue(Item item, GrowthData growthData)
	{
		AttributeModifier attributeModifier = item.GetAttributeModifiers().FirstOrDefault((AttributeModifier a) => a.AttributeType == growthData.GrowthAttributeType && a.AttributeModifierType == AttributeModifierType.Growth);
		if (attributeModifier != null)
		{
			attributeModifier.Value += growthData.GrowthRate;
			if (attributeModifier.Value > growthData.MaxGrowthValue)
			{
				attributeModifier.Value = growthData.MaxGrowthValue;
			}
		}
		else
		{
			item.AdditionalAttributeModifiers.Add(new AttributeModifier
			{
				AttributeType = growthData.GrowthAttributeType,
				Value = growthData.GrowthRate,
				ModificationType = ModificationType.Addition,
				AttributeModifierType = AttributeModifierType.Growth,
				Key = string.Empty
			});
		}
		growthData.CurrentGrowthValue += growthData.GrowthRate;
		if (growthData.CurrentGrowthValue >= growthData.MaxGrowthValue)
		{
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ItemGrowthCompleted, item);
		}
	}

	// Token: 0x02000F72 RID: 3954
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006409 RID: 25609 RVA: 0x0019703F File Offset: 0x0019543F
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600640A RID: 25610 RVA: 0x00197048 File Offset: 0x00195448
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				GrowthData growthData = specialEffectData as GrowthData;
				Item item = effectCarrier.Items.FirstOrDefault((Item i) => i.GetSpecialEffects().Any((ISpecialEffectDataLoad e) => e is GrowthData && (e as GrowthData).Id == growthData.Id));
				if (growthData != null && growthData.CurrentGrowthValue < growthData.MaxGrowthValue && item != null)
				{
					if (growthData.Condition == GrowthConditionType.DealCritDamage || growthData.Condition == GrowthConditionType.DealDamage || growthData.Condition == GrowthConditionType.ReceiveCritDamage || growthData.Condition == GrowthConditionType.ReceiveDamage)
					{
						if (evtType == AdventureEventType.UnitPostReceivesDamage)
						{
							BattleDamage battleDamage = evtData as BattleDamage;
							foreach (DamageComponent damageComponent in battleDamage.Damages)
							{
								if (!damageComponent.HasFullyNeutralized())
								{
									if (battleDamage.Dealer == effectCarrier && ((growthData.Condition == GrowthConditionType.DealCritDamage && damageComponent.IsCrit) || (growthData.Condition == GrowthConditionType.DealDamage && damageComponent.GetTotalDamageSoFar() >= growthData.ConditionValue)))
									{
										GrowthSpecialEffectProcess.UpdateValue(item, growthData);
									}
									if (triggerUnit == effectCarrier && ((growthData.Condition == GrowthConditionType.ReceiveDamage && growthData.CurrentGrowthValue < growthData.MaxGrowthValue) || (growthData.Condition == GrowthConditionType.ReceiveCritDamage && damageComponent.IsCrit)))
									{
										GrowthSpecialEffectProcess.UpdateValue(item, growthData);
									}
								}
							}
						}
					}
					else if (evtType == AdventureEventType.UnitPostReceivesHeal)
					{
						BattleHeal battleHeal = evtData as BattleHeal;
						foreach (HealComponent healComponent in battleHeal.Heals)
						{
							if ((growthData.Condition == GrowthConditionType.Heal && battleHeal.Healer == effectCarrier && healComponent.GetFinalHealSoFar() >= growthData.ConditionValue) || (growthData.Condition == GrowthConditionType.CritHeal && battleHeal.Healer == effectCarrier && healComponent.IsCrit))
							{
								GrowthSpecialEffectProcess.UpdateValue(item, growthData);
							}
							if ((growthData.Condition == GrowthConditionType.ReceiveHeal && triggerUnit == effectCarrier && healComponent.GetFinalHealSoFar() >= growthData.ConditionValue) || (growthData.Condition == GrowthConditionType.ReceiveCritHeal && healComponent.IsCrit && triggerUnit == effectCarrier))
							{
								GrowthSpecialEffectProcess.UpdateValue(item, growthData);
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x170014F3 RID: 5363
		// (get) Token: 0x0600640B RID: 25611 RVA: 0x001973B0 File Offset: 0x001957B0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014F4 RID: 5364
		// (get) Token: 0x0600640C RID: 25612 RVA: 0x001973B8 File Offset: 0x001957B8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600640D RID: 25613 RVA: 0x001973C0 File Offset: 0x001957C0
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600640E RID: 25614 RVA: 0x001973C2 File Offset: 0x001957C2
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600640F RID: 25615 RVA: 0x001973C9 File Offset: 0x001957C9
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006410 RID: 25616 RVA: 0x001973D4 File Offset: 0x001957D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GrowthSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new GrowthSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005BB1 RID: 23473
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BB2 RID: 23474
		internal IBattleUnit effectCarrier;

		// Token: 0x04005BB3 RID: 23475
		internal AdventureEventType evtType;

		// Token: 0x04005BB4 RID: 23476
		internal object evtData;

		// Token: 0x04005BB5 RID: 23477
		internal IBattleUnit triggerUnit;

		// Token: 0x04005BB6 RID: 23478
		internal object $current;

		// Token: 0x04005BB7 RID: 23479
		internal bool $disposing;

		// Token: 0x04005BB8 RID: 23480
		internal int $PC;

		// Token: 0x02000F74 RID: 3956
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006413 RID: 25619 RVA: 0x00197438 File Offset: 0x00195838
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006414 RID: 25620 RVA: 0x00197440 File Offset: 0x00195840
			internal bool <>m__0(Item i)
			{
				return i.GetSpecialEffects().Any((ISpecialEffectDataLoad e) => e is GrowthData && (e as GrowthData).Id == this.growthData.Id);
			}

			// Token: 0x06006415 RID: 25621 RVA: 0x00197459 File Offset: 0x00195859
			internal bool <>m__1(ISpecialEffectDataLoad e)
			{
				return e is GrowthData && (e as GrowthData).Id == this.growthData.Id;
			}

			// Token: 0x04005BBA RID: 23482
			internal GrowthData growthData;

			// Token: 0x04005BBB RID: 23483
			internal GrowthSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000F73 RID: 3955
	[CompilerGenerated]
	private sealed class <UpdateValue>c__AnonStorey2
	{
		// Token: 0x06006411 RID: 25617 RVA: 0x00197484 File Offset: 0x00195884
		public <UpdateValue>c__AnonStorey2()
		{
		}

		// Token: 0x06006412 RID: 25618 RVA: 0x0019748C File Offset: 0x0019588C
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.growthData.GrowthAttributeType && a.AttributeModifierType == AttributeModifierType.Growth;
		}

		// Token: 0x04005BB9 RID: 23481
		internal GrowthData growthData;
	}
}
