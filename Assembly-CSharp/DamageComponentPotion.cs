using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000724 RID: 1828
public class DamageComponentPotion
{
	// Token: 0x06003332 RID: 13106 RVA: 0x0015869C File Offset: 0x00156A9C
	public DamageComponentPotion(DamagePotionValue value, bool isCrit, bool critCountered, bool isDirect)
	{
		IBattleUnit dealer = value.Dealer;
		IBattleUnit target = value.Target;
		this.Target = target;
		this.Dealer = dealer;
		this.RawDamage = value.RawDamage;
		this.DamageType = value.DamageType;
		this.RawDamage *= dealer.GetOutputEffectiveness(this.DamageType, AttributeRetrievalLevel.Skill);
		double num = target.GetDamageMultiplier(this.DamageType, AttributeRetrievalLevel.Skill, (int)dealer.Level, dealer);
		double num2 = 1.0;
		if (target.BattleEffects.Any((BattleEffectBase ef) => ef.BattleEffectType == BattleEffectType.Frozen))
		{
			if (dealer.SpecialEffects.OfType<ElementEffectData>().Any((ElementEffectData ef) => ef.ElementType == OutputType.Ice) && value.DamageType != OutputType.RealDamage)
			{
				num2 += dealer.SpecialEffects.OfType<IceEffectEnhancementData>().Sum((IceEffectEnhancementData e) => e.AdditionalRate);
			}
		}
		num *= num2;
		if (isCrit && !critCountered && this.DamageType != OutputType.RealDamage)
		{
			double num3 = dealer.GetCritDamageRate(AttributeRetrievalLevel.Skill) - 1.0;
			if (num3 >= 0.0)
			{
				double critDamageReductionRate = target.GetCritDamageReductionRate(dealer, AttributeRetrievalLevel.Skill);
				double num4 = 1.0 - critDamageReductionRate;
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				double num5 = num3 * num4;
				num *= 1.0 + num5;
			}
		}
		this.CalculatedDamageValue = this.RawDamage * num;
		if (this.CalculatedDamageValue < 0.0)
		{
			this.CalculatedDamageValue = 0.0;
		}
		if (this.CalculatedDamageValue > BattleDamage.MaxDamagePerPotion)
		{
			this.CalculatedDamageValue = BattleDamage.MaxDamagePerPotion;
		}
		this.IsNeutralized = false;
	}

	// Token: 0x170007DA RID: 2010
	// (get) Token: 0x06003333 RID: 13107 RVA: 0x00158893 File Offset: 0x00156C93
	// (set) Token: 0x06003334 RID: 13108 RVA: 0x0015889B File Offset: 0x00156C9B
	public double RawDamage
	{
		[CompilerGenerated]
		get
		{
			return this.<RawDamage>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<RawDamage>k__BackingField = value;
		}
	}

	// Token: 0x170007DB RID: 2011
	// (get) Token: 0x06003335 RID: 13109 RVA: 0x001588A4 File Offset: 0x00156CA4
	// (set) Token: 0x06003336 RID: 13110 RVA: 0x001588AC File Offset: 0x00156CAC
	public OutputType DamageType
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageType>k__BackingField = value;
		}
	}

	// Token: 0x170007DC RID: 2012
	// (get) Token: 0x06003337 RID: 13111 RVA: 0x001588B5 File Offset: 0x00156CB5
	// (set) Token: 0x06003338 RID: 13112 RVA: 0x001588BD File Offset: 0x00156CBD
	public IBattleUnit Target
	{
		[CompilerGenerated]
		get
		{
			return this.<Target>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Target>k__BackingField = value;
		}
	}

	// Token: 0x170007DD RID: 2013
	// (get) Token: 0x06003339 RID: 13113 RVA: 0x001588C6 File Offset: 0x00156CC6
	// (set) Token: 0x0600333A RID: 13114 RVA: 0x001588CE File Offset: 0x00156CCE
	public IBattleUnit Dealer
	{
		[CompilerGenerated]
		get
		{
			return this.<Dealer>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Dealer>k__BackingField = value;
		}
	}

	// Token: 0x170007DE RID: 2014
	// (get) Token: 0x0600333B RID: 13115 RVA: 0x001588D7 File Offset: 0x00156CD7
	// (set) Token: 0x0600333C RID: 13116 RVA: 0x001588DF File Offset: 0x00156CDF
	public double CalculatedDamageValue
	{
		[CompilerGenerated]
		get
		{
			return this.<CalculatedDamageValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CalculatedDamageValue>k__BackingField = value;
		}
	}

	// Token: 0x170007DF RID: 2015
	// (get) Token: 0x0600333D RID: 13117 RVA: 0x001588E8 File Offset: 0x00156CE8
	// (set) Token: 0x0600333E RID: 13118 RVA: 0x001588F0 File Offset: 0x00156CF0
	public bool IsNeutralized
	{
		[CompilerGenerated]
		get
		{
			return this.<IsNeutralized>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsNeutralized>k__BackingField = value;
		}
	}

	// Token: 0x0600333F RID: 13119 RVA: 0x001588F9 File Offset: 0x00156CF9
	public void SetNeutralize(bool neutralize)
	{
		this.IsNeutralized = neutralize;
	}

	// Token: 0x06003340 RID: 13120 RVA: 0x00158904 File Offset: 0x00156D04
	public double GetFinalDamageSoFar()
	{
		if (this.IsNeutralized)
		{
			return 0.0;
		}
		double num = this.CalculatedDamageValue - this._extraReducedValue;
		if (num <= 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	// Token: 0x06003341 RID: 13121 RVA: 0x0015894E File Offset: 0x00156D4E
	public void ReduceDamageValue(double value)
	{
		this._extraReducedValue += value;
		if (this.CalculatedDamageValue - this._extraReducedValue <= 0.0)
		{
			this.IsNeutralized = true;
		}
	}

	// Token: 0x06003342 RID: 13122 RVA: 0x00158980 File Offset: 0x00156D80
	public void MultiplyCalculatedDamageValue(double rate)
	{
		if (rate > 0.0)
		{
			this.CalculatedDamageValue *= rate;
			if (this.CalculatedDamageValue > BattleDamage.MaxDamagePerPotion)
			{
				this.CalculatedDamageValue = BattleDamage.MaxDamagePerPotion;
			}
		}
	}

	// Token: 0x06003343 RID: 13123 RVA: 0x001589BA File Offset: 0x00156DBA
	[CompilerGenerated]
	private static bool <DamageComponentPotion>m__0(BattleEffectBase ef)
	{
		return ef.BattleEffectType == BattleEffectType.Frozen;
	}

	// Token: 0x06003344 RID: 13124 RVA: 0x001589C6 File Offset: 0x00156DC6
	[CompilerGenerated]
	private static bool <DamageComponentPotion>m__1(ElementEffectData ef)
	{
		return ef.ElementType == OutputType.Ice;
	}

	// Token: 0x06003345 RID: 13125 RVA: 0x001589D1 File Offset: 0x00156DD1
	[CompilerGenerated]
	private static double <DamageComponentPotion>m__2(IceEffectEnhancementData e)
	{
		return e.AdditionalRate;
	}

	// Token: 0x040027FF RID: 10239
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <RawDamage>k__BackingField;

	// Token: 0x04002800 RID: 10240
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <DamageType>k__BackingField;

	// Token: 0x04002801 RID: 10241
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x04002802 RID: 10242
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;

	// Token: 0x04002803 RID: 10243
	private double _extraReducedValue;

	// Token: 0x04002804 RID: 10244
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CalculatedDamageValue>k__BackingField;

	// Token: 0x04002805 RID: 10245
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsNeutralized>k__BackingField;

	// Token: 0x04002806 RID: 10246
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache0;

	// Token: 0x04002807 RID: 10247
	[CompilerGenerated]
	private static Func<ElementEffectData, bool> <>f__am$cache1;

	// Token: 0x04002808 RID: 10248
	[CompilerGenerated]
	private static Func<IceEffectEnhancementData, double> <>f__am$cache2;
}
