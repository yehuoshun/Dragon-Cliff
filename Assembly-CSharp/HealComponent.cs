using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000728 RID: 1832
public class HealComponent
{
	// Token: 0x0600336B RID: 13163 RVA: 0x00158C68 File Offset: 0x00157068
	public HealComponent(IBattleUnit target, IBattleUnit healer, HealComponentValue value)
	{
		this.RawHeal = value.RawHeal;
		double num = 1.0 + target.GetAttributeValue_Final(AttributeType.ReceivedHealEffectivenessChangeRate, AttributeRetrievalLevel.Skill);
		if (healer.SpecialEffects.OfType<ConfidentHealerData>().Any<ConfidentHealerData>())
		{
			num += healer.SpecialEffects.OfType<ConfidentHealerData>().Sum((ConfidentHealerData e) => e.HealBoostRate);
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		double num2 = this.RawHeal * num;
		this.HealType = value.HealType;
		this.IsDirectHeal = value.IsDirectHeal;
		this.IsCrit = (value.HealType != OutputType.RealHeal && (double)UnityEngine.Random.value <= healer.CritRate(AttributeRetrievalLevel.Skill));
		if (this.IsCrit)
		{
			this.CalculatedHealValue = num2 * healer.GetCritDamageRate(AttributeRetrievalLevel.Skill);
		}
		else
		{
			this.CalculatedHealValue = num2;
		}
		if (this.CalculatedHealValue < 0.0)
		{
			this.CalculatedHealValue = 0.0;
		}
		this.IsNeutralized = false;
		this.ExceededHealValue = null;
		this.FinalHealValue = null;
	}

	// Token: 0x170007F0 RID: 2032
	// (get) Token: 0x0600336C RID: 13164 RVA: 0x00158DB3 File Offset: 0x001571B3
	// (set) Token: 0x0600336D RID: 13165 RVA: 0x00158DBB File Offset: 0x001571BB
	public double RawHeal
	{
		[CompilerGenerated]
		get
		{
			return this.<RawHeal>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<RawHeal>k__BackingField = value;
		}
	}

	// Token: 0x170007F1 RID: 2033
	// (get) Token: 0x0600336E RID: 13166 RVA: 0x00158DC4 File Offset: 0x001571C4
	// (set) Token: 0x0600336F RID: 13167 RVA: 0x00158DCC File Offset: 0x001571CC
	public OutputType HealType
	{
		[CompilerGenerated]
		get
		{
			return this.<HealType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealType>k__BackingField = value;
		}
	}

	// Token: 0x170007F2 RID: 2034
	// (get) Token: 0x06003370 RID: 13168 RVA: 0x00158DD5 File Offset: 0x001571D5
	// (set) Token: 0x06003371 RID: 13169 RVA: 0x00158DDD File Offset: 0x001571DD
	public bool IsDirectHeal
	{
		[CompilerGenerated]
		get
		{
			return this.<IsDirectHeal>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsDirectHeal>k__BackingField = value;
		}
	}

	// Token: 0x170007F3 RID: 2035
	// (get) Token: 0x06003372 RID: 13170 RVA: 0x00158DE6 File Offset: 0x001571E6
	// (set) Token: 0x06003373 RID: 13171 RVA: 0x00158DEE File Offset: 0x001571EE
	public double CalculatedHealValue
	{
		[CompilerGenerated]
		get
		{
			return this.<CalculatedHealValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CalculatedHealValue>k__BackingField = value;
		}
	}

	// Token: 0x170007F4 RID: 2036
	// (get) Token: 0x06003374 RID: 13172 RVA: 0x00158DF7 File Offset: 0x001571F7
	// (set) Token: 0x06003375 RID: 13173 RVA: 0x00158DFF File Offset: 0x001571FF
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

	// Token: 0x170007F5 RID: 2037
	// (get) Token: 0x06003376 RID: 13174 RVA: 0x00158E08 File Offset: 0x00157208
	// (set) Token: 0x06003377 RID: 13175 RVA: 0x00158E10 File Offset: 0x00157210
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

	// Token: 0x170007F6 RID: 2038
	// (get) Token: 0x06003378 RID: 13176 RVA: 0x00158E19 File Offset: 0x00157219
	// (set) Token: 0x06003379 RID: 13177 RVA: 0x00158E21 File Offset: 0x00157221
	public double? ExceededHealValue
	{
		[CompilerGenerated]
		get
		{
			return this.<ExceededHealValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ExceededHealValue>k__BackingField = value;
		}
	}

	// Token: 0x170007F7 RID: 2039
	// (get) Token: 0x0600337A RID: 13178 RVA: 0x00158E2A File Offset: 0x0015722A
	// (set) Token: 0x0600337B RID: 13179 RVA: 0x00158E32 File Offset: 0x00157232
	public double? FinalHealValue
	{
		[CompilerGenerated]
		get
		{
			return this.<FinalHealValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FinalHealValue>k__BackingField = value;
		}
	}

	// Token: 0x0600337C RID: 13180 RVA: 0x00158E3C File Offset: 0x0015723C
	public double GetFinalHealSoFar()
	{
		double? finalHealValue = this.FinalHealValue;
		return (finalHealValue == null) ? this.CalculatedHealValue : finalHealValue.Value;
	}

	// Token: 0x0600337D RID: 13181 RVA: 0x00158E6E File Offset: 0x0015726E
	[CompilerGenerated]
	private static double <HealComponent>m__0(ConfidentHealerData e)
	{
		return e.HealBoostRate;
	}

	// Token: 0x04002818 RID: 10264
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <RawHeal>k__BackingField;

	// Token: 0x04002819 RID: 10265
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <HealType>k__BackingField;

	// Token: 0x0400281A RID: 10266
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsDirectHeal>k__BackingField;

	// Token: 0x0400281B RID: 10267
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CalculatedHealValue>k__BackingField;

	// Token: 0x0400281C RID: 10268
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsNeutralized>k__BackingField;

	// Token: 0x0400281D RID: 10269
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsCrit>k__BackingField;

	// Token: 0x0400281E RID: 10270
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double? <ExceededHealValue>k__BackingField;

	// Token: 0x0400281F RID: 10271
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double? <FinalHealValue>k__BackingField;

	// Token: 0x04002820 RID: 10272
	[CompilerGenerated]
	private static Func<ConfidentHealerData, double> <>f__am$cache0;
}
