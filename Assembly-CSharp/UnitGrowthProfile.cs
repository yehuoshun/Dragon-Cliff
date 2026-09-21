using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000B37 RID: 2871
public class UnitGrowthProfile
{
	// Token: 0x06004C60 RID: 19552 RVA: 0x001F19A8 File Offset: 0x001EFDA8
	public UnitGrowthProfile()
	{
		this.UnitGrowthValues = new List<UnitGrowthValue>
		{
			new UnitGrowthValue
			{
				AttributeType = AttributeType.CritDamage,
				Potential = 2.0,
				GuarranteedValue = true
			}
		};
		this.AffixTypes = new List<AffixType>();
	}

	// Token: 0x1700106D RID: 4205
	// (set) Token: 0x06004C61 RID: 19553 RVA: 0x001F19FD File Offset: 0x001EFDFD
	public float IntelligiencePotential
	{
		set
		{
			this.SetValue(AttributeType.Intelligience, (double)value, false);
		}
	}

	// Token: 0x1700106E RID: 4206
	// (set) Token: 0x06004C62 RID: 19554 RVA: 0x001F1A0A File Offset: 0x001EFE0A
	public float FocusPotential
	{
		set
		{
			this.SetValue(AttributeType.CritRate, (double)value, false);
		}
	}

	// Token: 0x1700106F RID: 4207
	// (set) Token: 0x06004C63 RID: 19555 RVA: 0x001F1A17 File Offset: 0x001EFE17
	public float StrengthPotential
	{
		set
		{
			this.SetValue(AttributeType.Strength, (double)value, false);
		}
	}

	// Token: 0x17001070 RID: 4208
	// (set) Token: 0x06004C64 RID: 19556 RVA: 0x001F1A24 File Offset: 0x001EFE24
	public float AgilityPotential
	{
		set
		{
			this.SetValue(AttributeType.Agility, (double)value, false);
		}
	}

	// Token: 0x17001071 RID: 4209
	// (set) Token: 0x06004C65 RID: 19557 RVA: 0x001F1A31 File Offset: 0x001EFE31
	public float VitalityPotential
	{
		set
		{
			this.SetValue(AttributeType.Vitality, (double)value, false);
		}
	}

	// Token: 0x17001072 RID: 4210
	// (get) Token: 0x06004C66 RID: 19558 RVA: 0x001F1A3E File Offset: 0x001EFE3E
	// (set) Token: 0x06004C67 RID: 19559 RVA: 0x001F1A46 File Offset: 0x001EFE46
	public List<UnitGrowthValue> UnitGrowthValues
	{
		[CompilerGenerated]
		get
		{
			return this.<UnitGrowthValues>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<UnitGrowthValues>k__BackingField = value;
		}
	}

	// Token: 0x17001073 RID: 4211
	// (get) Token: 0x06004C68 RID: 19560 RVA: 0x001F1A4F File Offset: 0x001EFE4F
	// (set) Token: 0x06004C69 RID: 19561 RVA: 0x001F1A57 File Offset: 0x001EFE57
	public List<AffixType> AffixTypes
	{
		[CompilerGenerated]
		get
		{
			return this.<AffixTypes>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AffixTypes>k__BackingField = value;
		}
	}

	// Token: 0x06004C6A RID: 19562 RVA: 0x001F1A60 File Offset: 0x001EFE60
	public List<AttributeModifier> GetInitializedAttributes(double multiplier = 1.0)
	{
		List<AttributeModifier> list = AttributeModifier.InitializeAttributes();
		foreach (UnitGrowthValue unitGrowthValue in this.UnitGrowthValues)
		{
			if (unitGrowthValue.GuarranteedValue)
			{
				list.AddValue(unitGrowthValue.AttributeType, unitGrowthValue.Potential);
			}
			else if (!unitGrowthValue.AttributeType.IsUpgradeableAttribute())
			{
				double potential = unitGrowthValue.Potential;
				list.AddValue(unitGrowthValue.AttributeType, potential);
			}
			else
			{
				double num = unitGrowthValue.Potential * multiplier;
				list.AddValue(unitGrowthValue.AttributeType, num * 0.5);
			}
		}
		return list;
	}

	// Token: 0x06004C6B RID: 19563 RVA: 0x001F1B2C File Offset: 0x001EFF2C
	public UnitLevelUpChange GetLevelUpChange(double multiplier, double rate)
	{
		UnitLevelUpChange unitLevelUpChange = new UnitLevelUpChange
		{
			ChangedValues = new List<LevelUpChangeValue>()
		};
		foreach (UnitGrowthValue unitGrowthValue in from v in this.UnitGrowthValues
		where v.AttributeType.IsUpgradeableAttribute()
		select v)
		{
			if (unitGrowthValue.GuarranteedValue)
			{
				unitLevelUpChange.ChangedValues.Add(new LevelUpChangeValue
				{
					AttributeType = unitGrowthValue.AttributeType,
					Value = unitGrowthValue.Potential * rate
				});
			}
			else if (unitGrowthValue.Potential > 0.0)
			{
				unitLevelUpChange.ChangedValues.Add(new LevelUpChangeValue
				{
					AttributeType = unitGrowthValue.AttributeType,
					Value = UnitGrowthProfile.GetRandomAttributeValue(unitGrowthValue.Potential) * multiplier * rate
				});
			}
		}
		return unitLevelUpChange;
	}

	// Token: 0x06004C6C RID: 19564 RVA: 0x001F1C40 File Offset: 0x001F0040
	public static double GetRandomAttributeValue(double mean)
	{
		float min = Convert.ToSingle(mean) * 0.8f;
		float max = Convert.ToSingle(mean) * 1f;
		float num = UnityEngine.Random.Range(min, max);
		return Math.Round((double)num, 4, MidpointRounding.AwayFromZero);
	}

	// Token: 0x06004C6D RID: 19565 RVA: 0x001F1C78 File Offset: 0x001F0078
	public UnitGrowthProfile SetValue(AttributeType type, double potentialValue, bool guarranteed = false)
	{
		if (this.UnitGrowthValues.Any((UnitGrowthValue f) => f.AttributeType == type))
		{
			UnitGrowthValue unitGrowthValue = this.UnitGrowthValues.First((UnitGrowthValue g) => g.AttributeType == type);
			unitGrowthValue.Potential = potentialValue;
			unitGrowthValue.GuarranteedValue = guarranteed;
		}
		else
		{
			this.UnitGrowthValues.Add(new UnitGrowthValue
			{
				AttributeType = type,
				GuarranteedValue = guarranteed,
				Potential = potentialValue
			});
		}
		return this;
	}

	// Token: 0x06004C6E RID: 19566 RVA: 0x001F1D08 File Offset: 0x001F0108
	public UnitGrowthProfile Combine(List<AffixType> affixs)
	{
		using (List<AffixType>.Enumerator enumerator = affixs.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AffixType affixt = enumerator.Current;
				if (this.AffixTypes.All((AffixType a) => a != affixt))
				{
					this.AffixTypes.Add(affixt);
				}
				List<AttributeAffix> affixAdditionalAttributes = affixt.GetAffixRule().GetAffixAdditionalAttributes(1);
				using (List<AttributeAffix>.Enumerator enumerator2 = affixAdditionalAttributes.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						AttributeAffix affix = enumerator2.Current;
						if (this.UnitGrowthValues.Any((UnitGrowthValue p) => p.AttributeType == affix.AttributeType))
						{
							UnitGrowthValue unitGrowthValue = this.UnitGrowthValues.First((UnitGrowthValue g) => g.AttributeType == affix.AttributeType);
							unitGrowthValue.Potential += affix.Value;
						}
						else
						{
							this.UnitGrowthValues.Add(new UnitGrowthValue
							{
								AttributeType = affix.AttributeType,
								Potential = affix.Value,
								GuarranteedValue = false
							});
						}
					}
				}
			}
		}
		return this;
	}

	// Token: 0x06004C6F RID: 19567 RVA: 0x001F1EA0 File Offset: 0x001F02A0
	[CompilerGenerated]
	private static bool <GetLevelUpChange>m__0(UnitGrowthValue v)
	{
		return v.AttributeType.IsUpgradeableAttribute();
	}

	// Token: 0x04003AE6 RID: 15078
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<UnitGrowthValue> <UnitGrowthValues>k__BackingField;

	// Token: 0x04003AE7 RID: 15079
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AffixType> <AffixTypes>k__BackingField;

	// Token: 0x04003AE8 RID: 15080
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x0200107E RID: 4222
	[CompilerGenerated]
	private sealed class <SetValue>c__AnonStorey0
	{
		// Token: 0x0600697A RID: 27002 RVA: 0x001F1EAD File Offset: 0x001F02AD
		public <SetValue>c__AnonStorey0()
		{
		}

		// Token: 0x0600697B RID: 27003 RVA: 0x001F1EB5 File Offset: 0x001F02B5
		internal bool <>m__0(UnitGrowthValue f)
		{
			return f.AttributeType == this.type;
		}

		// Token: 0x0600697C RID: 27004 RVA: 0x001F1EC5 File Offset: 0x001F02C5
		internal bool <>m__1(UnitGrowthValue g)
		{
			return g.AttributeType == this.type;
		}

		// Token: 0x040063FF RID: 25599
		internal AttributeType type;
	}

	// Token: 0x0200107F RID: 4223
	[CompilerGenerated]
	private sealed class <Combine>c__AnonStorey1
	{
		// Token: 0x0600697D RID: 27005 RVA: 0x001F1ED5 File Offset: 0x001F02D5
		public <Combine>c__AnonStorey1()
		{
		}

		// Token: 0x0600697E RID: 27006 RVA: 0x001F1EDD File Offset: 0x001F02DD
		internal bool <>m__0(AffixType a)
		{
			return a != this.affixt;
		}

		// Token: 0x04006400 RID: 25600
		internal AffixType affixt;
	}

	// Token: 0x02001080 RID: 4224
	[CompilerGenerated]
	private sealed class <Combine>c__AnonStorey2
	{
		// Token: 0x0600697F RID: 27007 RVA: 0x001F1EEB File Offset: 0x001F02EB
		public <Combine>c__AnonStorey2()
		{
		}

		// Token: 0x06006980 RID: 27008 RVA: 0x001F1EF3 File Offset: 0x001F02F3
		internal bool <>m__0(UnitGrowthValue p)
		{
			return p.AttributeType == this.affix.AttributeType;
		}

		// Token: 0x06006981 RID: 27009 RVA: 0x001F1F08 File Offset: 0x001F0308
		internal bool <>m__1(UnitGrowthValue g)
		{
			return g.AttributeType == this.affix.AttributeType;
		}

		// Token: 0x04006401 RID: 25601
		internal AttributeAffix affix;
	}
}
