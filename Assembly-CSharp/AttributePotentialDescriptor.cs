using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020005ED RID: 1517
public class AttributePotentialDescriptor
{
	// Token: 0x060029DE RID: 10718 RVA: 0x0011C64D File Offset: 0x0011AA4D
	public AttributePotentialDescriptor(AttributeType type)
	{
		this.AttributeType = type;
		this.PowerLevel = AttributePowerLevel.ExtremeLow;
		this.Style = AttributeStyle.Beneficial;
	}

	// Token: 0x060029DF RID: 10719 RVA: 0x0011C66A File Offset: 0x0011AA6A
	public AttributePotentialDescriptor(AttributeType attributeType, AttributePowerLevel powerLevel, AttributeStyle style)
	{
		this.PowerLevel = powerLevel;
		this.Style = style;
		this.AttributeType = attributeType;
	}

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x060029E0 RID: 10720 RVA: 0x0011C687 File Offset: 0x0011AA87
	// (set) Token: 0x060029E1 RID: 10721 RVA: 0x0011C68F File Offset: 0x0011AA8F
	public AttributePowerLevel PowerLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<PowerLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PowerLevel>k__BackingField = value;
		}
	}

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x060029E2 RID: 10722 RVA: 0x0011C698 File Offset: 0x0011AA98
	// (set) Token: 0x060029E3 RID: 10723 RVA: 0x0011C6A0 File Offset: 0x0011AAA0
	public AttributeStyle Style
	{
		[CompilerGenerated]
		get
		{
			return this.<Style>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Style>k__BackingField = value;
		}
	}

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x060029E4 RID: 10724 RVA: 0x0011C6A9 File Offset: 0x0011AAA9
	// (set) Token: 0x060029E5 RID: 10725 RVA: 0x0011C6B1 File Offset: 0x0011AAB1
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

	// Token: 0x060029E6 RID: 10726 RVA: 0x0011C6BC File Offset: 0x0011AABC
	public double GetMean(ItemRoot root, AttributeGrade grade)
	{
		double additionValue = root.GetAdditionValue(this.AttributeType);
		double num = (grade != AttributeGrade.Primary) ? 0.5 : 1.0;
		if (this.Style == AttributeStyle.Penalty)
		{
			num *= -1.0;
		}
		if (this.PowerLevel == AttributePowerLevel.ExtremeHigh)
		{
			num *= 1.0;
		}
		if (this.PowerLevel == AttributePowerLevel.High)
		{
			num *= 0.8;
		}
		if (this.PowerLevel == AttributePowerLevel.Medium)
		{
			num *= 0.6;
		}
		if (this.PowerLevel == AttributePowerLevel.Low)
		{
			num *= 0.4;
		}
		if (this.PowerLevel == AttributePowerLevel.ExtremeLow)
		{
			num *= 0.2;
		}
		return additionValue * num;
	}

	// Token: 0x060029E7 RID: 10727 RVA: 0x0011C786 File Offset: 0x0011AB86
	public AttributePotentialDescriptor SetPowerLevel(AttributePowerLevel level)
	{
		this.PowerLevel = level;
		return this;
	}

	// Token: 0x060029E8 RID: 10728 RVA: 0x0011C790 File Offset: 0x0011AB90
	public AttributePotentialDescriptor SetStyle(AttributeStyle style)
	{
		this.Style = style;
		return this;
	}

	// Token: 0x0400224F RID: 8783
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributePowerLevel <PowerLevel>k__BackingField;

	// Token: 0x04002250 RID: 8784
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeStyle <Style>k__BackingField;

	// Token: 0x04002251 RID: 8785
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;
}
