using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000725 RID: 1829
public class DamagePotionValue
{
	// Token: 0x06003346 RID: 13126 RVA: 0x001589D9 File Offset: 0x00156DD9
	private DamagePotionValue()
	{
	}

	// Token: 0x06003347 RID: 13127 RVA: 0x001589E4 File Offset: 0x00156DE4
	public DamagePotionValue(IBattleUnit dealer, IBattleUnit target, OutputType damageType, double percentage)
	{
		UnitOutputCapacity outputCapacity = dealer.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		this.DamageType = damageType;
		this.RawDamage = outputCapacity.Value * percentage;
		if (this.RawDamage > BattleDamage.MaxDamagePerPotion)
		{
			this.RawDamage = BattleDamage.MaxDamagePerPotion;
		}
		this.Dealer = dealer;
		this.Target = target;
	}

	// Token: 0x170007E0 RID: 2016
	// (get) Token: 0x06003348 RID: 13128 RVA: 0x00158A3E File Offset: 0x00156E3E
	// (set) Token: 0x06003349 RID: 13129 RVA: 0x00158A46 File Offset: 0x00156E46
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

	// Token: 0x170007E1 RID: 2017
	// (get) Token: 0x0600334A RID: 13130 RVA: 0x00158A4F File Offset: 0x00156E4F
	// (set) Token: 0x0600334B RID: 13131 RVA: 0x00158A57 File Offset: 0x00156E57
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

	// Token: 0x170007E2 RID: 2018
	// (get) Token: 0x0600334C RID: 13132 RVA: 0x00158A60 File Offset: 0x00156E60
	// (set) Token: 0x0600334D RID: 13133 RVA: 0x00158A68 File Offset: 0x00156E68
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

	// Token: 0x170007E3 RID: 2019
	// (get) Token: 0x0600334E RID: 13134 RVA: 0x00158A71 File Offset: 0x00156E71
	// (set) Token: 0x0600334F RID: 13135 RVA: 0x00158A79 File Offset: 0x00156E79
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

	// Token: 0x06003350 RID: 13136 RVA: 0x00158A84 File Offset: 0x00156E84
	public static DamagePotionValue CreateRawValuedDamageComponent(IBattleUnit target, IBattleUnit dealer, OutputType damageType, double damageValue)
	{
		return new DamagePotionValue
		{
			DamageType = damageType,
			RawDamage = damageValue,
			Target = target,
			Dealer = dealer
		};
	}

	// Token: 0x04002809 RID: 10249
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <DamageType>k__BackingField;

	// Token: 0x0400280A RID: 10250
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <RawDamage>k__BackingField;

	// Token: 0x0400280B RID: 10251
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x0400280C RID: 10252
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;
}
