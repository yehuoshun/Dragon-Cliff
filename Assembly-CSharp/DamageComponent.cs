using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000723 RID: 1827
public class DamageComponent
{
	// Token: 0x060032F3 RID: 13043 RVA: 0x00157C64 File Offset: 0x00156064
	public DamageComponent(DamageComponentValue value, IBattleEffectSource damageSource)
	{
		this.Target = value.Target;
		this.Dealer = value.Dealer;
		this.DamageSource = damageSource;
		this.CompleteReflected = false;
		this.IsFatal = null;
		this.IsDirectDamage = value.IsDirectDamage;
		this.IsReflectedDamage = value.IsReflectedDamage;
		this.IsCrit = false;
		this.CritCountered = false;
		this._maxPossibleDamage = null;
		this.IsMissed = false;
		this.IsIneffective = false;
		this.CounteredDamageValue = 0.0;
		this._finalDamageAdditionalRateFilter = 1.0;
		if (value.DamagePotions.Any((DamagePotionValue p) => p.DamageType != OutputType.RealDamage))
		{
			this.IsCrit = ((double)UnityEngine.Random.value <= this.Dealer.CritRate(AttributeRetrievalLevel.Skill));
		}
		this.Potions = (from p in value.DamagePotions
		select new DamageComponentPotion(p, this.IsCrit, this.CritCountered, this.IsDirectDamage)).ToList<DamageComponentPotion>();
		this.ReflectedDamage = 0.0;
		this.ExceededDamageValue = null;
		this.AdditionalCode = value.AdditionalCode;
	}

	// Token: 0x170007CA RID: 1994
	// (get) Token: 0x060032F4 RID: 13044 RVA: 0x00157DA3 File Offset: 0x001561A3
	// (set) Token: 0x060032F5 RID: 13045 RVA: 0x00157DAB File Offset: 0x001561AB
	public List<DamageComponentPotion> Potions
	{
		[CompilerGenerated]
		get
		{
			return this.<Potions>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Potions>k__BackingField = value;
		}
	}

	// Token: 0x170007CB RID: 1995
	// (get) Token: 0x060032F6 RID: 13046 RVA: 0x00157DB4 File Offset: 0x001561B4
	// (set) Token: 0x060032F7 RID: 13047 RVA: 0x00157DBC File Offset: 0x001561BC
	public double ReflectedDamage
	{
		get
		{
			return this._reflectedDamage;
		}
		set
		{
			if (value >= this.GetTotalRawDamage())
			{
				this.CompleteReflected = true;
			}
			this._reflectedDamage = value;
		}
	}

	// Token: 0x170007CC RID: 1996
	// (get) Token: 0x060032F8 RID: 13048 RVA: 0x00157DD8 File Offset: 0x001561D8
	// (set) Token: 0x060032F9 RID: 13049 RVA: 0x00157DE0 File Offset: 0x001561E0
	public double? ExceededDamageValue
	{
		[CompilerGenerated]
		get
		{
			return this.<ExceededDamageValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ExceededDamageValue>k__BackingField = value;
		}
	}

	// Token: 0x170007CD RID: 1997
	// (get) Token: 0x060032FA RID: 13050 RVA: 0x00157DE9 File Offset: 0x001561E9
	// (set) Token: 0x060032FB RID: 13051 RVA: 0x00157DF1 File Offset: 0x001561F1
	public bool? IsFatal
	{
		[CompilerGenerated]
		get
		{
			return this.<IsFatal>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsFatal>k__BackingField = value;
		}
	}

	// Token: 0x170007CE RID: 1998
	// (get) Token: 0x060032FC RID: 13052 RVA: 0x00157DFA File Offset: 0x001561FA
	// (set) Token: 0x060032FD RID: 13053 RVA: 0x00157E02 File Offset: 0x00156202
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

	// Token: 0x170007CF RID: 1999
	// (get) Token: 0x060032FE RID: 13054 RVA: 0x00157E0B File Offset: 0x0015620B
	// (set) Token: 0x060032FF RID: 13055 RVA: 0x00157E13 File Offset: 0x00156213
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

	// Token: 0x170007D0 RID: 2000
	// (get) Token: 0x06003300 RID: 13056 RVA: 0x00157E1C File Offset: 0x0015621C
	// (set) Token: 0x06003301 RID: 13057 RVA: 0x00157E24 File Offset: 0x00156224
	public bool CompleteReflected
	{
		[CompilerGenerated]
		get
		{
			return this.<CompleteReflected>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CompleteReflected>k__BackingField = value;
		}
	}

	// Token: 0x170007D1 RID: 2001
	// (get) Token: 0x06003302 RID: 13058 RVA: 0x00157E2D File Offset: 0x0015622D
	// (set) Token: 0x06003303 RID: 13059 RVA: 0x00157E35 File Offset: 0x00156235
	public bool IsDirectDamage
	{
		[CompilerGenerated]
		get
		{
			return this.<IsDirectDamage>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsDirectDamage>k__BackingField = value;
		}
	}

	// Token: 0x170007D2 RID: 2002
	// (get) Token: 0x06003304 RID: 13060 RVA: 0x00157E3E File Offset: 0x0015623E
	// (set) Token: 0x06003305 RID: 13061 RVA: 0x00157E46 File Offset: 0x00156246
	public bool IsReflectedDamage
	{
		[CompilerGenerated]
		get
		{
			return this.<IsReflectedDamage>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsReflectedDamage>k__BackingField = value;
		}
	}

	// Token: 0x170007D3 RID: 2003
	// (get) Token: 0x06003306 RID: 13062 RVA: 0x00157E4F File Offset: 0x0015624F
	// (set) Token: 0x06003307 RID: 13063 RVA: 0x00157E57 File Offset: 0x00156257
	private string AdditionalCode
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalCode>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdditionalCode>k__BackingField = value;
		}
	}

	// Token: 0x170007D4 RID: 2004
	// (get) Token: 0x06003308 RID: 13064 RVA: 0x00157E60 File Offset: 0x00156260
	// (set) Token: 0x06003309 RID: 13065 RVA: 0x00157E68 File Offset: 0x00156268
	public bool IsMissed
	{
		[CompilerGenerated]
		get
		{
			return this.<IsMissed>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsMissed>k__BackingField = value;
		}
	}

	// Token: 0x170007D5 RID: 2005
	// (get) Token: 0x0600330A RID: 13066 RVA: 0x00157E71 File Offset: 0x00156271
	// (set) Token: 0x0600330B RID: 13067 RVA: 0x00157E79 File Offset: 0x00156279
	public bool IsIneffective
	{
		[CompilerGenerated]
		get
		{
			return this.<IsIneffective>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsIneffective>k__BackingField = value;
		}
	}

	// Token: 0x170007D6 RID: 2006
	// (get) Token: 0x0600330C RID: 13068 RVA: 0x00157E82 File Offset: 0x00156282
	// (set) Token: 0x0600330D RID: 13069 RVA: 0x00157E8A File Offset: 0x0015628A
	public double CounteredDamageValue
	{
		[CompilerGenerated]
		get
		{
			return this.<CounteredDamageValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CounteredDamageValue>k__BackingField = value;
		}
	}

	// Token: 0x170007D7 RID: 2007
	// (get) Token: 0x0600330E RID: 13070 RVA: 0x00157E93 File Offset: 0x00156293
	// (set) Token: 0x0600330F RID: 13071 RVA: 0x00157E9B File Offset: 0x0015629B
	public IBattleEffectSource DamageSource
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageSource>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageSource>k__BackingField = value;
		}
	}

	// Token: 0x170007D8 RID: 2008
	// (get) Token: 0x06003310 RID: 13072 RVA: 0x00157EA4 File Offset: 0x001562A4
	// (set) Token: 0x06003311 RID: 13073 RVA: 0x00157EAC File Offset: 0x001562AC
	public bool IsCrit
	{
		[CompilerGenerated]
		get
		{
			return this.<IsCrit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsCrit>k__BackingField = value;
		}
	}

	// Token: 0x170007D9 RID: 2009
	// (get) Token: 0x06003312 RID: 13074 RVA: 0x00157EB5 File Offset: 0x001562B5
	// (set) Token: 0x06003313 RID: 13075 RVA: 0x00157EBD File Offset: 0x001562BD
	public bool CritCountered
	{
		[CompilerGenerated]
		get
		{
			return this.<CritCountered>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CritCountered>k__BackingField = value;
		}
	}

	// Token: 0x06003314 RID: 13076 RVA: 0x00157EC6 File Offset: 0x001562C6
	public List<string> GetCodes()
	{
		return this.AdditionalCode.Split(new char[]
		{
			';'
		}).ToList<string>();
	}

	// Token: 0x06003315 RID: 13077 RVA: 0x00157EE3 File Offset: 0x001562E3
	public void UpdateMaximumPossibleDamage(double damage)
	{
		this._maxPossibleDamage = new double?(damage);
	}

	// Token: 0x06003316 RID: 13078 RVA: 0x00157EF1 File Offset: 0x001562F1
	public void UpdateCounteredDamage(double countered)
	{
		this.CounteredDamageValue = countered;
	}

	// Token: 0x06003317 RID: 13079 RVA: 0x00157EFA File Offset: 0x001562FA
	public void UpdateFinalDamageFilter(double rate)
	{
		this._finalDamageAdditionalRateFilter *= rate;
	}

	// Token: 0x06003318 RID: 13080 RVA: 0x00157F0C File Offset: 0x0015630C
	public double GetTotalRawDamage()
	{
		return (from p in this.Potions
		where !p.IsNeutralized
		select p).Sum((DamageComponentPotion p) => p.RawDamage);
	}

	// Token: 0x06003319 RID: 13081 RVA: 0x00157F64 File Offset: 0x00156364
	public double GetTotalDamageSoFar()
	{
		double num = this.Potions.Sum((DamageComponentPotion p) => p.GetFinalDamageSoFar());
		num -= this.CounteredDamageValue;
		if (this._maxPossibleDamage != null && this._maxPossibleDamage <= num)
		{
			num = this._maxPossibleDamage.Value;
		}
		num *= this._finalDamageAdditionalRateFilter;
		double maxDamagePerHit = BattleDamage.MaxDamagePerHit;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > maxDamagePerHit)
		{
			num = maxDamagePerHit;
		}
		if (double.IsNaN(num))
		{
			object[] array = new object[4];
			array[0] = "NAN from ";
			array[1] = this.Dealer.GetUnitType();
			array[2] = ": ";
			array[3] = string.Join(",", (from p in this.Potions
			select p.DamageType + ". " + p.CalculatedDamageValue).ToArray<string>());
			SteamExceptionHandle.Handle(new Exception(string.Concat(array)), 0u);
			object[] array2 = new object[4];
			array2[0] = "NAN from ";
			array2[1] = this.Dealer.GetUnitType();
			array2[2] = ": ";
			array2[3] = string.Join(", ", (from p in this.Potions
			select p.DamageType + ". " + p.CalculatedDamageValue).ToArray<string>());
			UnityEngine.Debug.LogError(string.Concat(array2));
			num = 0.0;
		}
		if (this.Dealer.IsPlayer && !this.IsReflectedDamage)
		{
			if (this.Dealer.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad ef) => ef.GetSpecialEffectType() == SpecialEffectType.Thorns))
			{
				num *= 0.1;
			}
		}
		return num;
	}

	// Token: 0x0600331A RID: 13082 RVA: 0x0015816C File Offset: 0x0015656C
	public double GetTotalDamageSoFar_WithoutNeutralization()
	{
		double num = this.Potions.Sum((DamageComponentPotion p) => p.CalculatedDamageValue);
		if (this._maxPossibleDamage != null && this._maxPossibleDamage <= num)
		{
			num = this._maxPossibleDamage.Value;
		}
		num *= this._finalDamageAdditionalRateFilter;
		double maxDamagePerHit = BattleDamage.MaxDamagePerHit;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > maxDamagePerHit)
		{
			num = maxDamagePerHit;
		}
		if (double.IsNaN(num))
		{
			object[] array = new object[4];
			array[0] = "NAN from ";
			array[1] = this.Dealer.GetUnitType();
			array[2] = ": ";
			array[3] = string.Join(",", (from p in this.Potions
			select p.DamageType + ". " + p.CalculatedDamageValue).ToArray<string>());
			SteamExceptionHandle.Handle(new Exception(string.Concat(array)), 0u);
			object[] array2 = new object[4];
			array2[0] = "NAN from ";
			array2[1] = this.Dealer.GetUnitType();
			array2[2] = ": ";
			array2[3] = string.Join(", ", (from p in this.Potions
			select p.DamageType + ". " + p.CalculatedDamageValue).ToArray<string>());
			UnityEngine.Debug.LogError(string.Concat(array2));
			num = 0.0;
		}
		return num;
	}

	// Token: 0x0600331B RID: 13083 RVA: 0x0015830D File Offset: 0x0015670D
	public double GetElementalTotal(OutputType elementType)
	{
		return this.GetTotalDamageSoFar() * this.GetElementalPercentage(elementType);
	}

	// Token: 0x0600331C RID: 13084 RVA: 0x0015831D File Offset: 0x0015671D
	public double GetElementalTotal_WithoutNeutralization(OutputType elementType)
	{
		return this.GetTotalDamageSoFar_WithoutNeutralization() * this.GetElementalPercentage(elementType);
	}

	// Token: 0x0600331D RID: 13085 RVA: 0x00158330 File Offset: 0x00156730
	public double GetElementalPercentage(OutputType elementType)
	{
		if (this.Potions.Any((DamageComponentPotion p) => p.DamageType == elementType))
		{
			double num = (from p in this.Potions
			where p.DamageType == elementType
			select p).Sum((DamageComponentPotion p) => p.CalculatedDamageValue);
			return num / this.Potions.Sum((DamageComponentPotion p) => p.CalculatedDamageValue);
		}
		return 0.0;
	}

	// Token: 0x0600331E RID: 13086 RVA: 0x001583D8 File Offset: 0x001567D8
	public bool CanMiss()
	{
		if (this.IsDirectDamage)
		{
			if (this.Potions.Any((DamageComponentPotion p) => !p.IsNeutralized && p.DamageType != OutputType.RealDamage))
			{
				return !this.Dealer.BattleEffects.OfType<GuiltEffect>().Any<GuiltEffect>();
			}
		}
		return false;
	}

	// Token: 0x0600331F RID: 13087 RVA: 0x00158438 File Offset: 0x00156838
	public void SetMiss()
	{
		this.IsMissed = true;
		foreach (DamageComponentPotion damageComponentPotion in this.Potions)
		{
			if (damageComponentPotion.DamageType != OutputType.RealDamage)
			{
				damageComponentPotion.SetNeutralize(true);
			}
		}
	}

	// Token: 0x06003320 RID: 13088 RVA: 0x001584A8 File Offset: 0x001568A8
	public bool HasFullyNeutralized()
	{
		return this.Potions.All((DamageComponentPotion p) => p.IsNeutralized);
	}

	// Token: 0x06003321 RID: 13089 RVA: 0x001584D2 File Offset: 0x001568D2
	public bool IsCritDamage()
	{
		return this.IsCrit && !this.CritCountered;
	}

	// Token: 0x06003322 RID: 13090 RVA: 0x001584EC File Offset: 0x001568EC
	public void SetIneffective()
	{
		this.IsIneffective = true;
		foreach (DamageComponentPotion damageComponentPotion in this.Potions)
		{
			if (damageComponentPotion.DamageType != OutputType.RealDamage)
			{
				damageComponentPotion.SetNeutralize(true);
			}
		}
	}

	// Token: 0x06003323 RID: 13091 RVA: 0x0015855C File Offset: 0x0015695C
	[CompilerGenerated]
	private static bool <GetTotalRawDamage>m__0(DamageComponentPotion p)
	{
		return !p.IsNeutralized;
	}

	// Token: 0x06003324 RID: 13092 RVA: 0x00158567 File Offset: 0x00156967
	[CompilerGenerated]
	private static double <GetTotalRawDamage>m__1(DamageComponentPotion p)
	{
		return p.RawDamage;
	}

	// Token: 0x06003325 RID: 13093 RVA: 0x0015856F File Offset: 0x0015696F
	[CompilerGenerated]
	private static double <GetTotalDamageSoFar>m__2(DamageComponentPotion p)
	{
		return p.GetFinalDamageSoFar();
	}

	// Token: 0x06003326 RID: 13094 RVA: 0x00158577 File Offset: 0x00156977
	[CompilerGenerated]
	private static string <GetTotalDamageSoFar>m__3(DamageComponentPotion p)
	{
		return p.DamageType + ". " + p.CalculatedDamageValue;
	}

	// Token: 0x06003327 RID: 13095 RVA: 0x00158599 File Offset: 0x00156999
	[CompilerGenerated]
	private static string <GetTotalDamageSoFar>m__4(DamageComponentPotion p)
	{
		return p.DamageType + ". " + p.CalculatedDamageValue;
	}

	// Token: 0x06003328 RID: 13096 RVA: 0x001585BB File Offset: 0x001569BB
	[CompilerGenerated]
	private static bool <GetTotalDamageSoFar>m__5(ISpecialEffectDataLoad ef)
	{
		return ef.GetSpecialEffectType() == SpecialEffectType.Thorns;
	}

	// Token: 0x06003329 RID: 13097 RVA: 0x001585CA File Offset: 0x001569CA
	[CompilerGenerated]
	private static double <GetTotalDamageSoFar_WithoutNeutralization>m__6(DamageComponentPotion p)
	{
		return p.CalculatedDamageValue;
	}

	// Token: 0x0600332A RID: 13098 RVA: 0x001585D2 File Offset: 0x001569D2
	[CompilerGenerated]
	private static string <GetTotalDamageSoFar_WithoutNeutralization>m__7(DamageComponentPotion p)
	{
		return p.DamageType + ". " + p.CalculatedDamageValue;
	}

	// Token: 0x0600332B RID: 13099 RVA: 0x001585F4 File Offset: 0x001569F4
	[CompilerGenerated]
	private static string <GetTotalDamageSoFar_WithoutNeutralization>m__8(DamageComponentPotion p)
	{
		return p.DamageType + ". " + p.CalculatedDamageValue;
	}

	// Token: 0x0600332C RID: 13100 RVA: 0x00158616 File Offset: 0x00156A16
	[CompilerGenerated]
	private static double <GetElementalPercentage>m__9(DamageComponentPotion p)
	{
		return p.CalculatedDamageValue;
	}

	// Token: 0x0600332D RID: 13101 RVA: 0x0015861E File Offset: 0x00156A1E
	[CompilerGenerated]
	private static double <GetElementalPercentage>m__A(DamageComponentPotion p)
	{
		return p.CalculatedDamageValue;
	}

	// Token: 0x0600332E RID: 13102 RVA: 0x00158626 File Offset: 0x00156A26
	[CompilerGenerated]
	private static bool <CanMiss>m__B(DamageComponentPotion p)
	{
		return !p.IsNeutralized && p.DamageType != OutputType.RealDamage;
	}

	// Token: 0x0600332F RID: 13103 RVA: 0x00158642 File Offset: 0x00156A42
	[CompilerGenerated]
	private static bool <HasFullyNeutralized>m__C(DamageComponentPotion p)
	{
		return p.IsNeutralized;
	}

	// Token: 0x06003330 RID: 13104 RVA: 0x0015864A File Offset: 0x00156A4A
	[CompilerGenerated]
	private static bool <DamageComponent>m__D(DamagePotionValue p)
	{
		return p.DamageType != OutputType.RealDamage;
	}

	// Token: 0x06003331 RID: 13105 RVA: 0x00158658 File Offset: 0x00156A58
	[CompilerGenerated]
	private DamageComponentPotion <DamageComponent>m__E(DamagePotionValue p)
	{
		return new DamageComponentPotion(p, this.IsCrit, this.CritCountered, this.IsDirectDamage);
	}

	// Token: 0x040027DF RID: 10207
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamageComponentPotion> <Potions>k__BackingField;

	// Token: 0x040027E0 RID: 10208
	private double _reflectedDamage;

	// Token: 0x040027E1 RID: 10209
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double? <ExceededDamageValue>k__BackingField;

	// Token: 0x040027E2 RID: 10210
	private double _finalDamageAdditionalRateFilter;

	// Token: 0x040027E3 RID: 10211
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool? <IsFatal>k__BackingField;

	// Token: 0x040027E4 RID: 10212
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x040027E5 RID: 10213
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;

	// Token: 0x040027E6 RID: 10214
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CompleteReflected>k__BackingField;

	// Token: 0x040027E7 RID: 10215
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsDirectDamage>k__BackingField;

	// Token: 0x040027E8 RID: 10216
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsReflectedDamage>k__BackingField;

	// Token: 0x040027E9 RID: 10217
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <AdditionalCode>k__BackingField;

	// Token: 0x040027EA RID: 10218
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsMissed>k__BackingField;

	// Token: 0x040027EB RID: 10219
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsIneffective>k__BackingField;

	// Token: 0x040027EC RID: 10220
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CounteredDamageValue>k__BackingField;

	// Token: 0x040027ED RID: 10221
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <DamageSource>k__BackingField;

	// Token: 0x040027EE RID: 10222
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsCrit>k__BackingField;

	// Token: 0x040027EF RID: 10223
	private double? _maxPossibleDamage;

	// Token: 0x040027F0 RID: 10224
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CritCountered>k__BackingField;

	// Token: 0x040027F1 RID: 10225
	[CompilerGenerated]
	private static Func<DamageComponentPotion, bool> <>f__am$cache0;

	// Token: 0x040027F2 RID: 10226
	[CompilerGenerated]
	private static Func<DamageComponentPotion, double> <>f__am$cache1;

	// Token: 0x040027F3 RID: 10227
	[CompilerGenerated]
	private static Func<DamageComponentPotion, double> <>f__am$cache2;

	// Token: 0x040027F4 RID: 10228
	[CompilerGenerated]
	private static Func<DamageComponentPotion, string> <>f__am$cache3;

	// Token: 0x040027F5 RID: 10229
	[CompilerGenerated]
	private static Func<DamageComponentPotion, string> <>f__am$cache4;

	// Token: 0x040027F6 RID: 10230
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache5;

	// Token: 0x040027F7 RID: 10231
	[CompilerGenerated]
	private static Func<DamageComponentPotion, double> <>f__am$cache6;

	// Token: 0x040027F8 RID: 10232
	[CompilerGenerated]
	private static Func<DamageComponentPotion, string> <>f__am$cache7;

	// Token: 0x040027F9 RID: 10233
	[CompilerGenerated]
	private static Func<DamageComponentPotion, string> <>f__am$cache8;

	// Token: 0x040027FA RID: 10234
	[CompilerGenerated]
	private static Func<DamageComponentPotion, double> <>f__am$cache9;

	// Token: 0x040027FB RID: 10235
	[CompilerGenerated]
	private static Func<DamageComponentPotion, double> <>f__am$cacheA;

	// Token: 0x040027FC RID: 10236
	[CompilerGenerated]
	private static Func<DamageComponentPotion, bool> <>f__am$cacheB;

	// Token: 0x040027FD RID: 10237
	[CompilerGenerated]
	private static Func<DamageComponentPotion, bool> <>f__am$cacheC;

	// Token: 0x040027FE RID: 10238
	[CompilerGenerated]
	private static Func<DamagePotionValue, bool> <>f__am$cacheD;

	// Token: 0x02000E88 RID: 3720
	[CompilerGenerated]
	private sealed class <GetElementalPercentage>c__AnonStorey0
	{
		// Token: 0x06005DA4 RID: 23972 RVA: 0x00158672 File Offset: 0x00156A72
		public <GetElementalPercentage>c__AnonStorey0()
		{
		}

		// Token: 0x06005DA5 RID: 23973 RVA: 0x0015867A File Offset: 0x00156A7A
		internal bool <>m__0(DamageComponentPotion p)
		{
			return p.DamageType == this.elementType;
		}

		// Token: 0x06005DA6 RID: 23974 RVA: 0x0015868A File Offset: 0x00156A8A
		internal bool <>m__1(DamageComponentPotion p)
		{
			return p.DamageType == this.elementType;
		}

		// Token: 0x040050FC RID: 20732
		internal OutputType elementType;
	}
}
