using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000608 RID: 1544
public class ItemPropertyPotential
{
	// Token: 0x06002A5A RID: 10842 RVA: 0x0011F143 File Offset: 0x0011D543
	public ItemPropertyPotential()
	{
	}

	// Token: 0x170004A1 RID: 1185
	// (get) Token: 0x06002A5B RID: 10843 RVA: 0x0011F14B File Offset: 0x0011D54B
	// (set) Token: 0x06002A5C RID: 10844 RVA: 0x0011F153 File Offset: 0x0011D553
	public bool IsGuaranteed
	{
		[CompilerGenerated]
		get
		{
			return this.<IsGuaranteed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsGuaranteed>k__BackingField = value;
		}
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06002A5D RID: 10845 RVA: 0x0011F15C File Offset: 0x0011D55C
	// (set) Token: 0x06002A5E RID: 10846 RVA: 0x0011F164 File Offset: 0x0011D564
	public bool IsPrimary
	{
		[CompilerGenerated]
		get
		{
			return this.<IsPrimary>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsPrimary>k__BackingField = value;
		}
	}

	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06002A5F RID: 10847 RVA: 0x0011F16D File Offset: 0x0011D56D
	// (set) Token: 0x06002A60 RID: 10848 RVA: 0x0011F175 File Offset: 0x0011D575
	public double Mean
	{
		[CompilerGenerated]
		get
		{
			return this.<Mean>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Mean>k__BackingField = value;
		}
	}

	// Token: 0x170004A4 RID: 1188
	// (get) Token: 0x06002A61 RID: 10849 RVA: 0x0011F17E File Offset: 0x0011D57E
	// (set) Token: 0x06002A62 RID: 10850 RVA: 0x0011F186 File Offset: 0x0011D586
	public AttributeType AttributeType
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeType>k__BackingField = value;
		}
	}

	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0011F18F File Offset: 0x0011D58F
	// (set) Token: 0x06002A64 RID: 10852 RVA: 0x0011F197 File Offset: 0x0011D597
	public ModificationType ModificationType
	{
		[CompilerGenerated]
		get
		{
			return this.<ModificationType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ModificationType>k__BackingField = value;
		}
	}

	// Token: 0x170004A6 RID: 1190
	// (get) Token: 0x06002A65 RID: 10853 RVA: 0x0011F1A0 File Offset: 0x0011D5A0
	// (set) Token: 0x06002A66 RID: 10854 RVA: 0x0011F1A8 File Offset: 0x0011D5A8
	public AttributeGrade AttributeGrade
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeGrade>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeGrade>k__BackingField = value;
		}
	}

	// Token: 0x06002A67 RID: 10855 RVA: 0x0011F1B4 File Offset: 0x0011D5B4
	public string GetRangeFrom(double randomness)
	{
		return (!this.AttributeType.IsPercentageValue()) ? (ItemExtensions.GetGradedAttributeValue(this.AttributeType, QualityGrade.Normal, Convert.ToSingle(this.Mean)) * (1.0 - randomness)).ToExpression() : ((ItemExtensions.GetGradedAttributeValue(this.AttributeType, QualityGrade.Normal, Convert.ToSingle(this.Mean)) * (1.0 - randomness)).ToExpressionMultiply100() + "%");
	}

	// Token: 0x06002A68 RID: 10856 RVA: 0x0011F230 File Offset: 0x0011D630
	public string GetRangeTo(double randomness)
	{
		return (!this.AttributeType.IsPercentageValue()) ? (ItemExtensions.GetGradedAttributeValue(this.AttributeType, QualityGrade.Ancient, Convert.ToSingle(this.Mean)) * (1.0 + randomness)).ToExpression() : ((ItemExtensions.GetGradedAttributeValue(this.AttributeType, QualityGrade.Ancient, Convert.ToSingle(this.Mean)) * (1.0 + randomness)).ToExpressionMultiply100() + "%");
	}

	// Token: 0x06002A69 RID: 10857 RVA: 0x0011F2AC File Offset: 0x0011D6AC
	public static ItemPropertyPotential CreatePrimaryGuarranteedProperty_Addition(AttributeType type, double mean)
	{
		return new ItemPropertyPotential
		{
			AttributeType = type,
			ModificationType = ModificationType.Addition,
			IsPrimary = true,
			IsGuaranteed = true,
			Mean = mean
		};
	}

	// Token: 0x06002A6A RID: 10858 RVA: 0x0011F2E4 File Offset: 0x0011D6E4
	public static ItemPropertyPotential CreatePrimaryGuarranteedProperty_Multiplication(AttributeType type, double mean)
	{
		return new ItemPropertyPotential
		{
			AttributeType = type,
			ModificationType = ModificationType.Multiplication,
			IsPrimary = true,
			IsGuaranteed = true,
			Mean = mean
		};
	}

	// Token: 0x06002A6B RID: 10859 RVA: 0x0011F31C File Offset: 0x0011D71C
	public static ItemPropertyPotential CreateAdditionalPotentialProperty_Addition(AttributeType type, double mean)
	{
		return new ItemPropertyPotential
		{
			AttributeType = type,
			ModificationType = ModificationType.Addition,
			IsPrimary = false,
			IsGuaranteed = false,
			Mean = mean
		};
	}

	// Token: 0x06002A6C RID: 10860 RVA: 0x0011F354 File Offset: 0x0011D754
	public static ItemPropertyPotential CreateAdditionalGuarranteedProperty_Addition(AttributeType type, double mean)
	{
		return new ItemPropertyPotential
		{
			AttributeType = type,
			ModificationType = ModificationType.Addition,
			IsPrimary = false,
			IsGuaranteed = true,
			Mean = mean
		};
	}

	// Token: 0x04002277 RID: 8823
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsGuaranteed>k__BackingField;

	// Token: 0x04002278 RID: 8824
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsPrimary>k__BackingField;

	// Token: 0x04002279 RID: 8825
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Mean>k__BackingField;

	// Token: 0x0400227A RID: 8826
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;

	// Token: 0x0400227B RID: 8827
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ModificationType <ModificationType>k__BackingField;

	// Token: 0x0400227C RID: 8828
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeGrade <AttributeGrade>k__BackingField;
}
