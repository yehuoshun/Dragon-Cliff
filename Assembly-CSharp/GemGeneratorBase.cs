using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000688 RID: 1672
public abstract class GemGeneratorBase
{
	// Token: 0x06002C97 RID: 11415 RVA: 0x00123D3B File Offset: 0x0012213B
	protected GemGeneratorBase()
	{
	}

	// Token: 0x06002C98 RID: 11416 RVA: 0x00123D44 File Offset: 0x00122144
	public static List<GemSetDescription> GetAllGemDescription()
	{
		return (from s in GemGeneratorBase.GemSocketTypeDictionary
		select new GemSetDescription
		{
			SocketType = s.Value,
			SetItemLogicBase = ItemExtensions.SetItemLogics[s.Key]
		} into s
		orderby s.SocketType
		select s).ToList<GemSetDescription>();
	}

	// Token: 0x06002C99 RID: 11417 RVA: 0x00123DA0 File Offset: 0x001221A0
	public static List<ResourceType> GetGemtypesOfColor(SocketType type)
	{
		return (from d in GemGeneratorBase.GemSocketTypeDictionary
		where d.Value == type
		select d into s
		select s.Key).ToList<ResourceType>();
	}

	// Token: 0x17000591 RID: 1425
	// (get) Token: 0x06002C9A RID: 11418
	public abstract ResourceType CorrespondingGemType { get; }

	// Token: 0x06002C9B RID: 11419
	public abstract List<AttributePresentable> PossibleAttributes(int level);

	// Token: 0x06002C9C RID: 11420 RVA: 0x00123DF8 File Offset: 0x001221F8
	private double GetAttributeContribution(AttributeType type, int level)
	{
		if (level <= 1)
		{
			level = 1;
		}
		if (level >= ItemExtensions.MaxGemLevel)
		{
			level = ItemExtensions.MaxGemLevel;
		}
		if ((type.IsCoreAttributes() && type != AttributeType.CritDamage && type != AttributeType.CritRate) || type == AttributeType.Resilience)
		{
			List<double> list = new List<double>
			{
				10.0,
				30.0,
				66.0,
				108.0,
				160.0,
				225.0,
				350.0,
				550.0,
				600.0,
				650.0,
				700.0,
				760.0,
				820.0,
				880.0,
				940.0,
				1000.0,
				1050.0,
				1100.0,
				1300.0,
				1400.0,
				1500.0,
				1600.0,
				1700.0,
				1800.0,
				1900.0,
				2000.0,
				2100.0
			};
			if (type.IsResistanceAttribute())
			{
				return list[level - 1] * 2.5;
			}
			return list[level - 1];
		}
		else
		{
			if (type == AttributeType.CritRate)
			{
				List<double> list2 = new List<double>
				{
					0.08,
					0.1,
					0.12,
					0.14,
					0.16,
					0.18,
					0.2,
					0.22,
					0.22,
					0.24,
					0.24,
					0.24,
					0.25,
					0.25,
					0.26,
					0.26,
					0.27,
					0.27,
					0.28,
					0.28,
					0.3,
					0.31,
					0.32,
					0.33,
					0.35,
					0.37,
					0.39,
					0.41
				};
				return list2[level - 1];
			}
			if (type == AttributeType.CritDamage)
			{
				List<double> list3 = new List<double>
				{
					0.5,
					0.6,
					0.7,
					0.8,
					0.9,
					1.0,
					1.1,
					1.2,
					1.2,
					1.3,
					1.3,
					1.4,
					1.4,
					1.5,
					1.5,
					1.6,
					1.6,
					1.7,
					1.9,
					2.1,
					2.3,
					2.5,
					2.7,
					2.9,
					3.1,
					3.3,
					3.5,
					3.7,
					3.9
				};
				return list3[level - 1];
			}
			if (type == AttributeType.LifeOnHit || type == AttributeType.TauntOnHit || type == AttributeType.StunOnHit)
			{
				List<double> list4 = new List<double>
				{
					0.06,
					0.07,
					0.08,
					0.09,
					0.1,
					0.11,
					0.12,
					0.13,
					0.14,
					0.15,
					0.15,
					0.15,
					0.16,
					0.16,
					0.17,
					0.17,
					0.17,
					0.17,
					0.18,
					0.18,
					0.18,
					0.19,
					0.19,
					0.2,
					0.2,
					0.21,
					0.21,
					0.22
				};
				return list4[level - 1];
			}
			if (type == AttributeType.BattleStartHeal)
			{
				List<double> list5 = new List<double>
				{
					0.08,
					0.08,
					0.1,
					0.1,
					0.12,
					0.12,
					0.14,
					0.14,
					0.14,
					0.15,
					0.15,
					0.15,
					0.16,
					0.16,
					0.16,
					0.16,
					0.16,
					0.17,
					0.17,
					0.17,
					0.17,
					0.18,
					0.18,
					0.19,
					0.19,
					0.2,
					0.2,
					0.21
				};
				return list5[level - 1];
			}
			if (type == AttributeType.ReflectiveDamage)
			{
				List<double> list6 = new List<double>
				{
					0.5,
					0.7,
					0.9,
					1.2,
					1.35,
					1.5,
					1.6,
					1.8,
					1.9,
					2.0,
					2.0,
					2.0,
					2.1,
					2.1,
					2.2,
					2.2,
					2.2,
					2.5,
					3.0,
					3.2,
					3.4,
					3.6,
					3.8,
					4.0,
					4.2,
					4.4,
					4.6,
					4.8,
					5.0
				};
				return list6[level - 1];
			}
			if (type == AttributeType.TurnStartHeal)
			{
				List<double> list7 = new List<double>
				{
					0.06,
					0.06,
					0.08,
					0.08,
					0.1,
					0.1,
					0.12,
					0.12,
					0.12,
					0.13,
					0.13,
					0.13,
					0.14,
					0.14,
					0.14,
					0.15,
					0.15,
					0.15,
					0.15,
					0.15,
					0.16,
					0.16,
					0.17,
					0.18,
					0.19,
					0.2,
					0.21,
					0.22,
					0.23
				};
				return list7[level - 1];
			}
			if (type == AttributeType.Mining || type == AttributeType.Hunting)
			{
				List<double> list8 = new List<double>
				{
					0.2,
					0.25,
					0.3,
					0.35,
					0.4,
					0.45,
					0.5,
					0.55,
					0.6,
					0.65,
					0.7,
					0.75,
					0.8,
					0.85,
					0.9,
					0.95,
					1.0,
					1.0,
					1.0,
					1.1,
					1.1,
					1.2,
					1.3,
					1.4,
					1.5,
					1.6,
					1.7,
					1.7
				};
				return list8[level - 1];
			}
			if (type == AttributeType.ReceivedHealEffectivenessChangeRate)
			{
				List<double> list9 = new List<double>
				{
					0.08,
					0.08,
					0.08,
					0.08,
					0.1,
					0.1,
					0.1,
					0.1,
					0.12,
					0.14,
					0.15,
					0.15,
					0.16,
					0.16,
					0.16,
					0.17,
					0.17,
					0.17,
					0.17,
					0.18,
					0.18,
					0.19,
					0.2,
					0.21,
					0.22,
					0.23,
					0.23,
					0.24
				};
				return list9[level - 1];
			}
			if (type == AttributeType.DealFireDamageEffectivenessChangeRate || type == AttributeType.DealPhysicalDamageEffectivenessChangeRate || type == AttributeType.DealPoisonDamageEffectivenessChangeRate || type == AttributeType.DealShadowDamageEffectivenessChangeRate || type == AttributeType.DealIceDamageEffectivenessChangeRate || type == AttributeType.DealDivineDamageEffectivenessChangeRate || type == AttributeType.DealLightningDamageEffectivenessChangeRate)
			{
				List<double> list10 = new List<double>
				{
					0.06,
					0.08,
					0.1,
					0.12,
					0.14,
					0.18,
					0.22,
					0.24,
					0.26,
					0.28,
					0.29,
					0.3,
					0.3,
					0.31,
					0.31,
					0.31,
					0.32,
					0.32,
					0.32,
					0.32,
					0.32,
					0.33,
					0.34,
					0.35,
					0.36,
					0.36,
					0.37,
					0.37,
					0.37
				};
				return list10[level - 1];
			}
			if (type == AttributeType.SkillRageEfficiencyRate || type == AttributeType.HealingAbsorbRate)
			{
				List<double> list11 = new List<double>
				{
					0.03,
					0.04,
					0.05,
					0.06,
					0.07,
					0.08,
					0.09,
					0.1,
					0.1,
					0.1,
					0.11,
					0.11,
					0.12,
					0.12,
					0.13,
					0.13,
					0.13,
					0.14,
					0.14,
					0.14,
					0.15,
					0.15,
					0.15,
					0.16,
					0.16,
					0.17,
					0.17,
					0.17
				};
				return list11[level - 1];
			}
			if (type == AttributeType.EffectMastery)
			{
				List<double> list12 = new List<double>
				{
					0.05,
					0.06,
					0.07,
					0.08,
					0.09,
					0.1,
					0.11,
					0.12,
					0.13,
					0.14,
					0.14,
					0.15,
					0.15,
					0.16,
					0.16,
					0.17,
					0.17,
					0.18,
					0.18,
					0.2,
					0.2,
					0.21,
					0.21,
					0.22,
					0.22,
					0.23,
					0.23,
					0.24,
					0.24
				};
				return list12[level - 1];
			}
			if (type == AttributeType.EffectHitRating || type == AttributeType.EffectResistanceRating)
			{
				List<double> list13 = new List<double>
				{
					10.0,
					10.0,
					12.0,
					12.0,
					14.0,
					14.0,
					16.0,
					16.0,
					18.0,
					18.0,
					22.0,
					22.0,
					28.0,
					28.0,
					32.0,
					32.0,
					36.0,
					40.0,
					45.0,
					46.0,
					48.0,
					50.0,
					54.0,
					58.0,
					62.0,
					64.0,
					66.0,
					68.0
				};
				return list13[level - 1];
			}
			if (type != AttributeType.HitRateAdjustment && type != AttributeType.DodgeRateAdjustment)
			{
				throw new NotImplementedException();
			}
			if (level <= 17)
			{
				return 0.03;
			}
			if (level <= 21)
			{
				return 0.06;
			}
			return 0.12;
		}
	}

	// Token: 0x06002C9D RID: 11421 RVA: 0x00125630 File Offset: 0x00123A30
	private double GetRandomCoeff()
	{
		return (double)UnityEngine.Random.Range(1f - GemGeneratorBase.GemAttributeRandomness, 1f);
	}

	// Token: 0x06002C9E RID: 11422 RVA: 0x00125648 File Offset: 0x00123A48
	public Item GenerateGem(int level)
	{
		if (level <= 1)
		{
			level = 1;
		}
		if (level >= ItemExtensions.MaxGemLevel)
		{
			level = ItemExtensions.MaxGemLevel;
		}
		List<int> list = new List<int>
		{
			2,
			3,
			4
		};
		int numberOfSelections = list[UnityEngine.Random.Range(0, list.Count)];
		List<AttributeModifier> list2 = new List<AttributeModifier>();
		List<double> list3 = new List<double>
		{
			100.0,
			300.0,
			500.0,
			800.0,
			1200.0,
			1600.0,
			2000.0,
			2500.0,
			3000.0,
			3500.0,
			3800.0,
			4100.0,
			4400.0,
			4700.0,
			5000.0,
			5300.0,
			5600.0,
			5900.0,
			6200.0,
			6500.0,
			6500.0,
			6500.0,
			6500.0,
			6500.0,
			6500.0
		};
		double value = list3[level - 1];
		List<AttributePresentable> list4 = this.PossibleAttributes(level);
		if ((double)UnityEngine.Random.value <= 0.5)
		{
			list4 = (from a in list4
			where a.AttributeType != AttributeType.Strength
			select a).ToList<AttributePresentable>();
		}
		else
		{
			list4 = (from a in list4
			where a.AttributeType != AttributeType.Intelligience
			select a).ToList<AttributePresentable>();
		}
		List<AttributePresentable> list5 = list4.WeightedRandomSelectMaxUniquenessNoRepeat((AttributePresentable a, AttributePresentable b) => a.AttributeType == b.AttributeType, numberOfSelections);
		if (list5.Count == 2 || list5.Count == 1)
		{
			foreach (AttributePresentable attributePresentable in list5)
			{
				list2.Add(new AttributeModifier
				{
					ModificationType = ModificationType.Addition,
					AttributeType = attributePresentable.AttributeType,
					Value = this.GetAttributeContribution(attributePresentable.AttributeType, level) * this.GetRandomCoeff(),
					AttributeModifierType = AttributeModifierType.Embeded,
					Key = string.Empty
				});
			}
		}
		else if (list5.Count == 3)
		{
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[0].AttributeType,
				Value = this.GetAttributeContribution(list5[0].AttributeType, level) * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[1].AttributeType,
				Value = this.GetAttributeContribution(list5[1].AttributeType, level) * 0.65 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[2].AttributeType,
				Value = this.GetAttributeContribution(list5[2].AttributeType, level) * 0.65 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
		}
		else if (list5.Count == 4)
		{
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[0].AttributeType,
				Value = this.GetAttributeContribution(list5[0].AttributeType, level) * 0.75 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[1].AttributeType,
				Value = this.GetAttributeContribution(list5[1].AttributeType, level) * 0.75 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[2].AttributeType,
				Value = this.GetAttributeContribution(list5[2].AttributeType, level) * 0.75 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
			list2.Add(new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = list5[3].AttributeType,
				Value = this.GetAttributeContribution(list5[3].AttributeType, level) * 0.75 * this.GetRandomCoeff(),
				AttributeModifierType = AttributeModifierType.Embeded,
				Key = string.Empty
			});
		}
		return new Item
		{
			Level = level,
			Type = this.CorrespondingGemType,
			Value = value,
			Id = Guid.NewGuid().ToString(),
			Sockets = new List<ItemSocket>(),
			ItemGrade = QualityGrade.Normal,
			SpecialEffects = new List<ISpecialEffectDataLoad>(),
			AdditionalAttributeModifiers = new List<AttributeModifier>(),
			PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional,
			SlotType = ItemType.Normal,
			ItemStatus = ItemStatus.Reserved,
			Locked = false,
			PrimaryAttributeModifiers = list2,
			CanBeReforged = new bool?(false)
		};
	}

	// Token: 0x06002C9F RID: 11423 RVA: 0x00125D5C File Offset: 0x0012415C
	// Note: this type is marked as 'beforefieldinit'.
	static GemGeneratorBase()
	{
	}

	// Token: 0x06002CA0 RID: 11424 RVA: 0x00125E34 File Offset: 0x00124234
	[CompilerGenerated]
	private static GemSetDescription <GetAllGemDescription>m__0(KeyValuePair<ResourceType, SocketType> s)
	{
		return new GemSetDescription
		{
			SocketType = s.Value,
			SetItemLogicBase = ItemExtensions.SetItemLogics[s.Key]
		};
	}

	// Token: 0x06002CA1 RID: 11425 RVA: 0x00125E6C File Offset: 0x0012426C
	[CompilerGenerated]
	private static SocketType <GetAllGemDescription>m__1(GemSetDescription s)
	{
		return s.SocketType;
	}

	// Token: 0x06002CA2 RID: 11426 RVA: 0x00125E74 File Offset: 0x00124274
	[CompilerGenerated]
	private static ResourceType <GetGemtypesOfColor>m__2(KeyValuePair<ResourceType, SocketType> s)
	{
		return s.Key;
	}

	// Token: 0x06002CA3 RID: 11427 RVA: 0x00125E7D File Offset: 0x0012427D
	[CompilerGenerated]
	private static bool <GenerateGem>m__3(AttributePresentable a)
	{
		return a.AttributeType != AttributeType.Strength;
	}

	// Token: 0x06002CA4 RID: 11428 RVA: 0x00125E8B File Offset: 0x0012428B
	[CompilerGenerated]
	private static bool <GenerateGem>m__4(AttributePresentable a)
	{
		return a.AttributeType != AttributeType.Intelligience;
	}

	// Token: 0x06002CA5 RID: 11429 RVA: 0x00125E99 File Offset: 0x00124299
	[CompilerGenerated]
	private static bool <GenerateGem>m__5(AttributePresentable a, AttributePresentable b)
	{
		return a.AttributeType == b.AttributeType;
	}

	// Token: 0x0400267E RID: 9854
	private static float GemAttributeRandomness = 0.2f;

	// Token: 0x0400267F RID: 9855
	public static Dictionary<ResourceType, SocketType> GemSocketTypeDictionary = new Dictionary<ResourceType, SocketType>
	{
		{
			ResourceType.SpiritOfDeadGeneral,
			SocketType.Red
		},
		{
			ResourceType.FairyStone,
			SocketType.Red
		},
		{
			ResourceType.EmeraldOfClearHeart,
			SocketType.Blue
		},
		{
			ResourceType.BoneOfRapture,
			SocketType.Green
		},
		{
			ResourceType.UndeadAsh,
			SocketType.Yellow
		},
		{
			ResourceType.MonksEyes,
			SocketType.Blue
		},
		{
			ResourceType.StoneOfSoulbringer,
			SocketType.Yellow
		},
		{
			ResourceType.SavageHeart,
			SocketType.Red
		},
		{
			ResourceType.FlyingFeather,
			SocketType.Blue
		},
		{
			ResourceType.GodsMoral,
			SocketType.Green
		},
		{
			ResourceType.DemonicFire,
			SocketType.Yellow
		},
		{
			ResourceType.EyeOfPrecision,
			SocketType.Red
		},
		{
			ResourceType.StoneOfExorcism,
			SocketType.Green
		},
		{
			ResourceType.CommandmentOfSpell,
			SocketType.Blue
		},
		{
			ResourceType.EvilHeart,
			SocketType.Green
		}
	};

	// Token: 0x04002680 RID: 9856
	[CompilerGenerated]
	private static Func<KeyValuePair<ResourceType, SocketType>, GemSetDescription> <>f__am$cache0;

	// Token: 0x04002681 RID: 9857
	[CompilerGenerated]
	private static Func<GemSetDescription, SocketType> <>f__am$cache1;

	// Token: 0x04002682 RID: 9858
	[CompilerGenerated]
	private static Func<KeyValuePair<ResourceType, SocketType>, ResourceType> <>f__am$cache2;

	// Token: 0x04002683 RID: 9859
	[CompilerGenerated]
	private static Func<AttributePresentable, bool> <>f__am$cache3;

	// Token: 0x04002684 RID: 9860
	[CompilerGenerated]
	private static Func<AttributePresentable, bool> <>f__am$cache4;

	// Token: 0x04002685 RID: 9861
	[CompilerGenerated]
	private static Func<AttributePresentable, AttributePresentable, bool> <>f__am$cache5;

	// Token: 0x02000DE3 RID: 3555
	[CompilerGenerated]
	private sealed class <GetGemtypesOfColor>c__AnonStorey0
	{
		// Token: 0x06005933 RID: 22835 RVA: 0x00125EA9 File Offset: 0x001242A9
		public <GetGemtypesOfColor>c__AnonStorey0()
		{
		}

		// Token: 0x06005934 RID: 22836 RVA: 0x00125EB1 File Offset: 0x001242B1
		internal bool <>m__0(KeyValuePair<ResourceType, SocketType> d)
		{
			return d.Value == this.type;
		}

		// Token: 0x04004902 RID: 18690
		internal SocketType type;
	}
}
