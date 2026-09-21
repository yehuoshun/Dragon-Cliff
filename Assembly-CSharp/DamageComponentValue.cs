using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000726 RID: 1830
public class DamageComponentValue
{
	// Token: 0x06003351 RID: 13137 RVA: 0x00158AB4 File Offset: 0x00156EB4
	public DamageComponentValue(List<DamagePotionValue> damagePotions, IBattleUnit target, IBattleUnit dealer, bool isDirectDamage, bool isReflectedDamage)
	{
		this.DamagePotions = damagePotions;
		this.Target = target;
		this.Dealer = dealer;
		this.IsDirectDamage = isDirectDamage;
		this.IsReflectedDamage = isReflectedDamage;
		this.AdditionalCode = string.Empty;
	}

	// Token: 0x170007E4 RID: 2020
	// (get) Token: 0x06003352 RID: 13138 RVA: 0x00158AEC File Offset: 0x00156EEC
	// (set) Token: 0x06003353 RID: 13139 RVA: 0x00158AF4 File Offset: 0x00156EF4
	public List<DamagePotionValue> DamagePotions
	{
		[CompilerGenerated]
		get
		{
			return this.<DamagePotions>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamagePotions>k__BackingField = value;
		}
	}

	// Token: 0x170007E5 RID: 2021
	// (get) Token: 0x06003354 RID: 13140 RVA: 0x00158AFD File Offset: 0x00156EFD
	// (set) Token: 0x06003355 RID: 13141 RVA: 0x00158B05 File Offset: 0x00156F05
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

	// Token: 0x170007E6 RID: 2022
	// (get) Token: 0x06003356 RID: 13142 RVA: 0x00158B0E File Offset: 0x00156F0E
	// (set) Token: 0x06003357 RID: 13143 RVA: 0x00158B16 File Offset: 0x00156F16
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

	// Token: 0x170007E7 RID: 2023
	// (get) Token: 0x06003358 RID: 13144 RVA: 0x00158B1F File Offset: 0x00156F1F
	// (set) Token: 0x06003359 RID: 13145 RVA: 0x00158B27 File Offset: 0x00156F27
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

	// Token: 0x170007E8 RID: 2024
	// (get) Token: 0x0600335A RID: 13146 RVA: 0x00158B30 File Offset: 0x00156F30
	// (set) Token: 0x0600335B RID: 13147 RVA: 0x00158B38 File Offset: 0x00156F38
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

	// Token: 0x170007E9 RID: 2025
	// (get) Token: 0x0600335C RID: 13148 RVA: 0x00158B41 File Offset: 0x00156F41
	// (set) Token: 0x0600335D RID: 13149 RVA: 0x00158B49 File Offset: 0x00156F49
	public string AdditionalCode
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalCode>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdditionalCode>k__BackingField = value;
		}
	}

	// Token: 0x0600335E RID: 13150 RVA: 0x00158B52 File Offset: 0x00156F52
	public DamageComponentValue AddCode(string code)
	{
		this.AdditionalCode += ";";
		this.AdditionalCode += code;
		return this;
	}

	// Token: 0x0400280D RID: 10253
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamagePotionValue> <DamagePotions>k__BackingField;

	// Token: 0x0400280E RID: 10254
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x0400280F RID: 10255
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;

	// Token: 0x04002810 RID: 10256
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsDirectDamage>k__BackingField;

	// Token: 0x04002811 RID: 10257
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsReflectedDamage>k__BackingField;

	// Token: 0x04002812 RID: 10258
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <AdditionalCode>k__BackingField;
}
