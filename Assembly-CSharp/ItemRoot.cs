using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020005FA RID: 1530
public class ItemRoot
{
	// Token: 0x06002A17 RID: 10775 RVA: 0x0011E4D3 File Offset: 0x0011C8D3
	public ItemRoot()
	{
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06002A18 RID: 10776 RVA: 0x0011E4DB File Offset: 0x0011C8DB
	// (set) Token: 0x06002A19 RID: 10777 RVA: 0x0011E4E3 File Offset: 0x0011C8E3
	public List<AttributeModifier> RootAdditionModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<RootAdditionModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RootAdditionModifiers>k__BackingField = value;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06002A1A RID: 10778 RVA: 0x0011E4EC File Offset: 0x0011C8EC
	// (set) Token: 0x06002A1B RID: 10779 RVA: 0x0011E4F4 File Offset: 0x0011C8F4
	public int CorrespondingItemTier
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingItemTier>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CorrespondingItemTier>k__BackingField = value;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06002A1C RID: 10780 RVA: 0x0011E4FD File Offset: 0x0011C8FD
	// (set) Token: 0x06002A1D RID: 10781 RVA: 0x0011E505 File Offset: 0x0011C905
	public int Workload
	{
		[CompilerGenerated]
		get
		{
			return this.<Workload>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Workload>k__BackingField = value;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06002A1E RID: 10782 RVA: 0x0011E50E File Offset: 0x0011C90E
	// (set) Token: 0x06002A1F RID: 10783 RVA: 0x0011E516 File Offset: 0x0011C916
	public int PriceBase
	{
		[CompilerGenerated]
		get
		{
			return this.<PriceBase>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PriceBase>k__BackingField = value;
		}
	}

	// Token: 0x06002A20 RID: 10784 RVA: 0x0011E520 File Offset: 0x0011C920
	public double GetAdditionValue(AttributeType type)
	{
		return this.RootAdditionModifiers.First((AttributeModifier a) => a.AttributeType == type).Value;
	}

	// Token: 0x06002A21 RID: 10785 RVA: 0x0011E558 File Offset: 0x0011C958
	public static List<ItemRoot> GenerateRoots(List<AttributeType> mainAttributes, List<AttributeType> minorAttributes, List<double> means)
	{
		if (mainAttributes.Any((AttributeType a) => minorAttributes.Any((AttributeType m) => m == a)))
		{
			throw new Exception("Invalid attributes: duplicated attributes");
		}
		List<AttributeType> allAttributeTypes = ItemExtensions.AllAttributeTypes;
		if (!allAttributeTypes.All((AttributeType t) => mainAttributes.Any((AttributeType m) => m == t) || minorAttributes.Any((AttributeType m) => m == t) || t == AttributeType.None))
		{
			List<AttributeType> source = (from t in allAttributeTypes
			where mainAttributes.All((AttributeType m) => m != t) && minorAttributes.All((AttributeType m) => m != t)
			select t).ToList<AttributeType>();
			throw new Exception("Invalid attributes: incomplete list: " + string.Join(", ", (from m in source
			select m.ToString()).ToArray<string>()));
		}
		List<ItemRoot> list = new List<ItemRoot>();
		for (int i = 0; i < means.Count; i++)
		{
			ItemRoot itemRoot = new ItemRoot
			{
				RootAdditionModifiers = new List<AttributeModifier>(),
				CorrespondingItemTier = i + 1,
				Workload = ((i >= 35) ? (1800 + (i - 35) * 20) : ((i + 1) * 60)),
				PriceBase = 50 + (i + 1) * 5
			};
			foreach (AttributeType attributeType in mainAttributes)
			{
				itemRoot.RootAdditionModifiers.Add(new AttributeModifier
				{
					AttributeType = attributeType,
					Value = ItemRoot.GetAttributeMean(attributeType, means[i], i + 1),
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Normal
				});
			}
			foreach (AttributeType attributeType2 in minorAttributes)
			{
				itemRoot.RootAdditionModifiers.Add(new AttributeModifier
				{
					AttributeType = attributeType2,
					Value = ItemRoot.GetAttributeMean(attributeType2, means[i], i + 1) / 2.0,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Normal
				});
			}
			list.Add(itemRoot);
		}
		return list;
	}

	// Token: 0x06002A22 RID: 10786 RVA: 0x0011E7C8 File Offset: 0x0011CBC8
	private static double GetAttributeMean(AttributeType type, double normalMean, int itemTier)
	{
		if (type.IsCoreAttributes())
		{
			if (type == AttributeType.CritDamage)
			{
				if (itemTier <= 50)
				{
					return 0.6;
				}
				return 1.6;
			}
			else if (type == AttributeType.CritRate)
			{
				if (itemTier <= 40)
				{
					return 0.3;
				}
				return 0.6;
			}
			else
			{
				if (type == AttributeType.Vitality)
				{
					return normalMean * 1.8;
				}
				if (type.IsResistanceAttribute())
				{
					return normalMean * 2.8;
				}
				if (type == AttributeType.Allresistances)
				{
					return normalMean * 2.8;
				}
				return normalMean;
			}
		}
		else
		{
			if (type == AttributeType.LifeOnHit)
			{
				return 0.1;
			}
			if (type == AttributeType.TauntOnHit)
			{
				if (itemTier <= 45)
				{
					return 0.2;
				}
				return 0.4;
			}
			else
			{
				if (type == AttributeType.StunOnHit)
				{
					return 0.3;
				}
				if (type == AttributeType.ReflectiveDamage)
				{
					if (itemTier <= 35)
					{
						return 0.6;
					}
					if (itemTier <= 50)
					{
						return 1.2;
					}
					return 2.0;
				}
				else
				{
					if (type == AttributeType.BattleStartHeal)
					{
						return 0.2;
					}
					if (type == AttributeType.TurnStartHeal)
					{
						return 0.12;
					}
					if (type == AttributeType.Mining)
					{
						if (itemTier <= 40)
						{
							return 1.0;
						}
						return 2.0;
					}
					else if (type == AttributeType.Logging)
					{
						if (itemTier <= 40)
						{
							return 1.0;
						}
						return 2.0;
					}
					else if (type == AttributeType.Hunting)
					{
						if (itemTier <= 40)
						{
							return 1.0;
						}
						return 2.0;
					}
					else
					{
						if (type == AttributeType.ReceivedHealEffectivenessChangeRate)
						{
							return 0.2;
						}
						if (type == AttributeType.DealFireDamageEffectivenessChangeRate || type == AttributeType.DealPhysicalDamageEffectivenessChangeRate || type == AttributeType.DealDivineDamageEffectivenessChangeRate || type == AttributeType.DealIceDamageEffectivenessChangeRate || type == AttributeType.DealShadowDamageEffectivenessChangeRate || type == AttributeType.DealPoisonDamageEffectivenessChangeRate || type == AttributeType.DealLightningDamageEffectivenessChangeRate)
						{
							if (itemTier <= 45)
							{
								return 0.4;
							}
							return 0.7;
						}
						else
						{
							if (type == AttributeType.Resilience)
							{
								return normalMean;
							}
							if (type == AttributeType.DamageReduction)
							{
								return 0.2;
							}
							if (type == AttributeType.SkillRageEfficiencyRate)
							{
								if (itemTier <= 45)
								{
									return 0.1;
								}
								return 0.2;
							}
							else
							{
								if (type == AttributeType.HealingAbsorbRate)
								{
									return 0.1;
								}
								if (type == AttributeType.EffectMastery)
								{
									return 0.2;
								}
								if (type == AttributeType.HitRateAdjustment)
								{
									return 0.15;
								}
								if (type == AttributeType.DodgeRateAdjustment)
								{
									return 0.15;
								}
								if (type == AttributeType.EffectHitRating || type == AttributeType.EffectResistanceRating)
								{
									if (itemTier <= 40)
									{
										return 100.0;
									}
									if (itemTier <= 50)
									{
										return 200.0;
									}
									return 300.0;
								}
								else
								{
									if (type == AttributeType.PhysicalPenetration || type == AttributeType.FirePenetration || type == AttributeType.IcePenetration || type == AttributeType.ShadowPenetration || type == AttributeType.PoisonPenetration || type == AttributeType.DivinePenetration || type == AttributeType.LighteningPenetration)
									{
										return 0.3;
									}
									throw new ArgumentOutOfRangeException("type", type, null);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06002A23 RID: 10787 RVA: 0x0011EB56 File Offset: 0x0011CF56
	[CompilerGenerated]
	private static string <GenerateRoots>m__0(AttributeType m)
	{
		return m.ToString();
	}

	// Token: 0x0400225E RID: 8798
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <RootAdditionModifiers>k__BackingField;

	// Token: 0x0400225F RID: 8799
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <CorrespondingItemTier>k__BackingField;

	// Token: 0x04002260 RID: 8800
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Workload>k__BackingField;

	// Token: 0x04002261 RID: 8801
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <PriceBase>k__BackingField;

	// Token: 0x04002262 RID: 8802
	[CompilerGenerated]
	private static Func<AttributeType, string> <>f__am$cache0;

	// Token: 0x02000DD4 RID: 3540
	[CompilerGenerated]
	private sealed class <GetAdditionValue>c__AnonStorey0
	{
		// Token: 0x0600590E RID: 22798 RVA: 0x0011EB65 File Offset: 0x0011CF65
		public <GetAdditionValue>c__AnonStorey0()
		{
		}

		// Token: 0x0600590F RID: 22799 RVA: 0x0011EB6D File Offset: 0x0011CF6D
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.type;
		}

		// Token: 0x040048EC RID: 18668
		internal AttributeType type;
	}

	// Token: 0x02000DD5 RID: 3541
	[CompilerGenerated]
	private sealed class <GenerateRoots>c__AnonStorey1
	{
		// Token: 0x06005910 RID: 22800 RVA: 0x0011EB7D File Offset: 0x0011CF7D
		public <GenerateRoots>c__AnonStorey1()
		{
		}

		// Token: 0x06005911 RID: 22801 RVA: 0x0011EB88 File Offset: 0x0011CF88
		internal bool <>m__0(AttributeType a)
		{
			return this.minorAttributes.Any((AttributeType m) => m == a);
		}

		// Token: 0x06005912 RID: 22802 RVA: 0x0011EBC0 File Offset: 0x0011CFC0
		internal bool <>m__1(AttributeType t)
		{
			return this.mainAttributes.Any((AttributeType m) => m == t) || this.minorAttributes.Any((AttributeType m) => m == t) || t == AttributeType.None;
		}

		// Token: 0x06005913 RID: 22803 RVA: 0x0011EC28 File Offset: 0x0011D028
		internal bool <>m__2(AttributeType t)
		{
			return this.mainAttributes.All((AttributeType m) => m != t) && this.minorAttributes.All((AttributeType m) => m != t);
		}

		// Token: 0x040048ED RID: 18669
		internal List<AttributeType> minorAttributes;

		// Token: 0x040048EE RID: 18670
		internal List<AttributeType> mainAttributes;

		// Token: 0x02000DD6 RID: 3542
		private sealed class <GenerateRoots>c__AnonStorey2
		{
			// Token: 0x06005914 RID: 22804 RVA: 0x0011EC7F File Offset: 0x0011D07F
			public <GenerateRoots>c__AnonStorey2()
			{
			}

			// Token: 0x06005915 RID: 22805 RVA: 0x0011EC87 File Offset: 0x0011D087
			internal bool <>m__0(AttributeType m)
			{
				return m == this.a;
			}

			// Token: 0x040048EF RID: 18671
			internal AttributeType a;

			// Token: 0x040048F0 RID: 18672
			internal ItemRoot.<GenerateRoots>c__AnonStorey1 <>f__ref$1;
		}

		// Token: 0x02000DD7 RID: 3543
		private sealed class <GenerateRoots>c__AnonStorey3
		{
			// Token: 0x06005916 RID: 22806 RVA: 0x0011EC92 File Offset: 0x0011D092
			public <GenerateRoots>c__AnonStorey3()
			{
			}

			// Token: 0x06005917 RID: 22807 RVA: 0x0011EC9A File Offset: 0x0011D09A
			internal bool <>m__0(AttributeType m)
			{
				return m == this.t;
			}

			// Token: 0x06005918 RID: 22808 RVA: 0x0011ECA5 File Offset: 0x0011D0A5
			internal bool <>m__1(AttributeType m)
			{
				return m == this.t;
			}

			// Token: 0x040048F1 RID: 18673
			internal AttributeType t;

			// Token: 0x040048F2 RID: 18674
			internal ItemRoot.<GenerateRoots>c__AnonStorey1 <>f__ref$1;
		}

		// Token: 0x02000DD8 RID: 3544
		private sealed class <GenerateRoots>c__AnonStorey4
		{
			// Token: 0x06005919 RID: 22809 RVA: 0x0011ECB0 File Offset: 0x0011D0B0
			public <GenerateRoots>c__AnonStorey4()
			{
			}

			// Token: 0x0600591A RID: 22810 RVA: 0x0011ECB8 File Offset: 0x0011D0B8
			internal bool <>m__0(AttributeType m)
			{
				return m != this.t;
			}

			// Token: 0x0600591B RID: 22811 RVA: 0x0011ECC6 File Offset: 0x0011D0C6
			internal bool <>m__1(AttributeType m)
			{
				return m != this.t;
			}

			// Token: 0x040048F3 RID: 18675
			internal AttributeType t;

			// Token: 0x040048F4 RID: 18676
			internal ItemRoot.<GenerateRoots>c__AnonStorey1 <>f__ref$1;
		}
	}
}
