using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008AF RID: 2223
public class AttributeStealingEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003ECC RID: 16076 RVA: 0x00184855 File Offset: 0x00182C55
	public AttributeStealingEffectProcess()
	{
	}

	// Token: 0x17000B20 RID: 2848
	// (get) Token: 0x06003ECD RID: 16077 RVA: 0x0018485D File Offset: 0x00182C5D
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.AttributeStealing;
		}
	}

	// Token: 0x17000B21 RID: 2849
	// (get) Token: 0x06003ECE RID: 16078 RVA: 0x00184860 File Offset: 0x00182C60
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.DamageReleased
			};
		}
	}

	// Token: 0x06003ECF RID: 16079 RVA: 0x0018487C File Offset: 0x00182C7C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage && specialEffectData is AttributeStealData)
		{
			AttributeStealData data = specialEffectData as AttributeStealData;
			ReleaseableDamage releaseable = evtData as ReleaseableDamage;
			if (string.IsNullOrEmpty(data.Key))
			{
				data.Key = Guid.NewGuid().ToString();
			}
			foreach (BattleDamage releaseableBattleDamage in releaseable.BattleDamages)
			{
				if (releaseableBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
				{
					double attributeValue = releaseableBattleDamage.Target.GetAttributeValue_Final(data.StealAttributeType, AttributeRetrievalLevel.Skill);
					double stolenAmount = ((attributeValue < 0.0) ? 0.0 : attributeValue) * data.SteamPercentage;
					double currentBoostValue = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
					where ef.EffectSourceIdentityCode == this.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + data.Key
					select ef).Sum((AttributeModificationEffect ef) => (from m in ef.GetAdditionalModifiers(effectCarrier, effectCarrier.CurrentEncounter)
					where m.AttributeType == data.StealAttributeType
					select m).Sum((AttributeModifier a) => a.Value));
					if (currentBoostValue <= 0.0)
					{
						currentBoostValue = 0.0;
					}
					double maxPossibleBoost = data.MaximumStolenValue - currentBoostValue;
					if (maxPossibleBoost <= 0.0)
					{
						maxPossibleBoost = 0.0;
					}
					double boostValue = (stolenAmount >= maxPossibleBoost) ? maxPossibleBoost : stolenAmount;
					if (boostValue > 0.0)
					{
						AttributeModificationEffect reductionEffect = AttributeModificationEffect.CreateAttributeStolenEffect(effectCarrier, data.StealAttributeType, -boostValue, base.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + data.Key);
						if (releaseableBattleDamage.Target.IsAliveInBattle())
						{
							IEnumerator enumerator2 = releaseableBattleDamage.Target.ApplySkillEffect(reductionEffect, false).GetEnumerator();
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
						AttributeModificationEffect boostEffect = AttributeModificationEffect.CreateAttributeObtainEffect(effectCarrier, data.StealAttributeType, boostValue, base.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + data.Key);
						IEnumerator enumerator3 = effectCarrier.ApplySkillEffect(boostEffect, false).GetEnumerator();
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

	// Token: 0x06003ED0 RID: 16080 RVA: 0x001848C4 File Offset: 0x00182CC4
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003ED1 RID: 16081 RVA: 0x001848C8 File Offset: 0x00182CC8
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.5)
		{
			List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
			allResistances.Shuffle<AttributeType>();
			List<AttributeType> list = allResistances.Take(3).ToList<AttributeType>();
			List<ISpecialEffectDataLoad> list2 = new List<ISpecialEffectDataLoad>();
			foreach (AttributeType attributeType in list)
			{
				double itemRootValue = SpecialEffectProcessBase.GetItemRootValue(itemTierLevel, itemType, attributeType);
				double maximumStolenValue = itemRootValue * 0.6 * (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f));
				list2.Add(new AttributeStealData
				{
					MaximumStolenValue = maximumStolenValue,
					SteamPercentage = 0.8,
					StealAttributeType = attributeType,
					IsStarEf = new bool?(false)
				});
			}
			return list2;
		}
		List<AttributePresentable> list3 = new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Agility)
		};
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		if (resourceCategory.IsCasterArmor() || resourceCategory.IsCasterWeapon())
		{
			list3.Add(new AttributePresentable(100, AttributeType.Intelligience));
		}
		if (resourceCategory.IsMeleeWeapon() || resourceCategory.IsMeleeArmor())
		{
			list3.Add(new AttributePresentable(100, AttributeType.Strength));
		}
		AttributePresentable attributePresentable = list3.WeightedRandomSelect<AttributePresentable>();
		double itemRootValue2 = SpecialEffectProcessBase.GetItemRootValue(itemTierLevel, itemType, attributePresentable.AttributeType);
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeStealData
			{
				SteamPercentage = 0.7,
				StealAttributeType = attributePresentable.AttributeType,
				MaximumStolenValue = itemRootValue2 * 0.6 * (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f)),
				IsStarEf = new bool?(false)
			}
		};
	}

	// Token: 0x02000F17 RID: 3863
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061A1 RID: 24993 RVA: 0x00184ADC File Offset: 0x00182EDC
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061A2 RID: 24994 RVA: 0x00184AE4 File Offset: 0x00182EE4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitProcess>c__AnonStorey = new AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2();
				<AsActiveUnitProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != <AsActiveUnitProcess>c__AnonStorey.effectCarrier || !(evtData is ReleaseableDamage) || !(specialEffectData is AttributeStealData))
				{
					goto IL_50A;
				}
				AttributeStealData data = specialEffectData as AttributeStealData;
				releaseable = (evtData as ReleaseableDamage);
				if (string.IsNullOrEmpty(data.Key))
				{
					data.Key = Guid.NewGuid().ToString();
				}
				enumerator = releaseable.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_17:
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
					goto IL_3E2;
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
				while (enumerator.MoveNext())
				{
					releaseableBattleDamage = enumerator.Current;
					if (releaseableBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
					{
						attributeValue = releaseableBattleDamage.Target.GetAttributeValue_Final(<AsActiveUnitProcess>c__AnonStorey2.data.StealAttributeType, AttributeRetrievalLevel.Skill);
						stolenAmount = ((attributeValue < 0.0) ? 0.0 : attributeValue) * <AsActiveUnitProcess>c__AnonStorey2.data.SteamPercentage;
						currentBoostValue = (from ef in <AsActiveUnitProcess>c__AnonStorey.effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
						where ef.EffectSourceIdentityCode == <AsActiveUnitProcess>c__AnonStorey2.<>f__ref$0.$this.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + <AsActiveUnitProcess>c__AnonStorey2.data.Key
						select ef).Sum((AttributeModificationEffect ef) => (from m in ef.GetAdditionalModifiers(<AsActiveUnitProcess>c__AnonStorey2.<>f__ref$2.effectCarrier, <AsActiveUnitProcess>c__AnonStorey2.<>f__ref$2.effectCarrier.CurrentEncounter)
						where m.AttributeType == <AsActiveUnitProcess>c__AnonStorey2.data.StealAttributeType
						select m).Sum((AttributeModifier a) => a.Value));
						if (currentBoostValue <= 0.0)
						{
							currentBoostValue = 0.0;
						}
						maxPossibleBoost = <AsActiveUnitProcess>c__AnonStorey2.data.MaximumStolenValue - currentBoostValue;
						if (maxPossibleBoost <= 0.0)
						{
							maxPossibleBoost = 0.0;
						}
						boostValue = ((stolenAmount >= maxPossibleBoost) ? maxPossibleBoost : stolenAmount);
						if (boostValue > 0.0)
						{
							reductionEffect = AttributeModificationEffect.CreateAttributeStolenEffect(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, <AsActiveUnitProcess>c__AnonStorey2.data.StealAttributeType, -boostValue, base.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + <AsActiveUnitProcess>c__AnonStorey2.data.Key);
							if (releaseableBattleDamage.Target.IsAliveInBattle())
							{
								enumerator2 = releaseableBattleDamage.Target.ApplySkillEffect(reductionEffect, false).GetEnumerator();
								num = 4294967293u;
								goto Block_17;
							}
							goto IL_3E2;
						}
					}
				}
				goto IL_50A;
				IL_3E2:
				boostEffect = AttributeModificationEffect.CreateAttributeObtainEffect(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, <AsActiveUnitProcess>c__AnonStorey2.data.StealAttributeType, boostValue, base.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + <AsActiveUnitProcess>c__AnonStorey2.data.Key);
				enumerator3 = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.ApplySkillEffect(boostEffect, false).GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_50A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001473 RID: 5235
		// (get) Token: 0x060061A3 RID: 24995 RVA: 0x00185054 File Offset: 0x00183454
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001474 RID: 5236
		// (get) Token: 0x060061A4 RID: 24996 RVA: 0x0018505C File Offset: 0x0018345C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061A5 RID: 24997 RVA: 0x00185064 File Offset: 0x00183464
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					case 2u:
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
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060061A6 RID: 24998 RVA: 0x0018514C File Offset: 0x0018354C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061A7 RID: 24999 RVA: 0x00185153 File Offset: 0x00183553
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061A8 RID: 25000 RVA: 0x0018515C File Offset: 0x0018355C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060061A9 RID: 25001 RVA: 0x001851CC File Offset: 0x001835CC
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005763 RID: 22371
		internal AdventureEventType evtType;

		// Token: 0x04005764 RID: 22372
		internal IBattleUnit triggerUnit;

		// Token: 0x04005765 RID: 22373
		internal IBattleUnit effectCarrier;

		// Token: 0x04005766 RID: 22374
		internal object evtData;

		// Token: 0x04005767 RID: 22375
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005768 RID: 22376
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04005769 RID: 22377
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x0400576A RID: 22378
		internal BattleDamage <releaseableBattleDamage>__2;

		// Token: 0x0400576B RID: 22379
		internal double <attributeValue>__3;

		// Token: 0x0400576C RID: 22380
		internal double <stolenAmount>__3;

		// Token: 0x0400576D RID: 22381
		internal double <currentBoostValue>__3;

		// Token: 0x0400576E RID: 22382
		internal double <maxPossibleBoost>__3;

		// Token: 0x0400576F RID: 22383
		internal double <boostValue>__3;

		// Token: 0x04005770 RID: 22384
		internal AttributeModificationEffect <reductionEffect>__4;

		// Token: 0x04005771 RID: 22385
		internal IEnumerator $locvar1;

		// Token: 0x04005772 RID: 22386
		internal object <_>__5;

		// Token: 0x04005773 RID: 22387
		internal IDisposable $locvar2;

		// Token: 0x04005774 RID: 22388
		internal AttributeModificationEffect <boostEffect>__4;

		// Token: 0x04005775 RID: 22389
		internal IEnumerator $locvar3;

		// Token: 0x04005776 RID: 22390
		internal object <_>__6;

		// Token: 0x04005777 RID: 22391
		internal IDisposable $locvar4;

		// Token: 0x04005778 RID: 22392
		internal AttributeStealingEffectProcess $this;

		// Token: 0x04005779 RID: 22393
		internal object $current;

		// Token: 0x0400577A RID: 22394
		internal bool $disposing;

		// Token: 0x0400577B RID: 22395
		internal int $PC;

		// Token: 0x0400577C RID: 22396
		private AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar5;

		// Token: 0x0400577D RID: 22397
		private AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar6;

		// Token: 0x0400577E RID: 22398
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x02000F18 RID: 3864
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x060061AA RID: 25002 RVA: 0x001851E5 File Offset: 0x001835E5
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x0400577F RID: 22399
			internal IBattleUnit effectCarrier;
		}

		// Token: 0x02000F19 RID: 3865
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060061AB RID: 25003 RVA: 0x001851ED File Offset: 0x001835ED
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060061AC RID: 25004 RVA: 0x001851F5 File Offset: 0x001835F5
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.<>f__ref$0.$this.GetType().FullName + AttributeModificationEffect.AttributeObtain_PartialKey + this.data.Key;
			}

			// Token: 0x060061AD RID: 25005 RVA: 0x0018522C File Offset: 0x0018362C
			internal double <>m__1(AttributeModificationEffect ef)
			{
				return (from m in ef.GetAdditionalModifiers(this.<>f__ref$2.effectCarrier, this.<>f__ref$2.effectCarrier.CurrentEncounter)
				where m.AttributeType == this.data.StealAttributeType
				select m).Sum((AttributeModifier a) => a.Value);
			}

			// Token: 0x060061AE RID: 25006 RVA: 0x0018528D File Offset: 0x0018368D
			internal bool <>m__2(AttributeModifier m)
			{
				return m.AttributeType == this.data.StealAttributeType;
			}

			// Token: 0x060061AF RID: 25007 RVA: 0x001852A2 File Offset: 0x001836A2
			private static double <>m__3(AttributeModifier a)
			{
				return a.Value;
			}

			// Token: 0x04005780 RID: 22400
			internal AttributeStealData data;

			// Token: 0x04005781 RID: 22401
			internal AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005782 RID: 22402
			internal AttributeStealingEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 <>f__ref$2;

			// Token: 0x04005783 RID: 22403
			private static Func<AttributeModifier, double> <>f__am$cache0;
		}
	}
}
