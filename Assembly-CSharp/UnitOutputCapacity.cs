using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000B3C RID: 2876
public class UnitOutputCapacity
{
	// Token: 0x06004C88 RID: 19592 RVA: 0x001F2094 File Offset: 0x001F0494
	public UnitOutputCapacity(IBattleUnit unit, AttributeRetrievalLevel level)
	{
		double attributeValue_Final = unit.GetAttributeValue_Final(unit.GetOutputAttributeType(), level);
		double num = 0.0;
		this.Value = attributeValue_Final * (1.0 + num);
		if (this.Value < 0.0)
		{
			this.Value = 0.0;
		}
		if (this.Value > UnitOutputCapacity.MaxOutput)
		{
			this.Value = UnitOutputCapacity.MaxOutput;
		}
		this.OutputAttribute = unit.GetOutputAttributeType();
	}

	// Token: 0x06004C89 RID: 19593 RVA: 0x001F211C File Offset: 0x001F051C
	public UnitOutputCapacity(AdventurerProfile profile, AttributeRetrievalLevel level)
	{
		double attributeValue_Final = profile.GetAttributeValue_Final(profile.GetOutputAttributeType(), level);
		this.Value = attributeValue_Final;
		this.OutputAttribute = profile.GetOutputAttributeType();
	}

	// Token: 0x1700107D RID: 4221
	// (get) Token: 0x06004C8A RID: 19594 RVA: 0x001F2150 File Offset: 0x001F0550
	// (set) Token: 0x06004C8B RID: 19595 RVA: 0x001F2158 File Offset: 0x001F0558
	public double Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x1700107E RID: 4222
	// (get) Token: 0x06004C8C RID: 19596 RVA: 0x001F2161 File Offset: 0x001F0561
	// (set) Token: 0x06004C8D RID: 19597 RVA: 0x001F2169 File Offset: 0x001F0569
	public AttributeType OutputAttribute
	{
		[CompilerGenerated]
		get
		{
			return this.<OutputAttribute>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<OutputAttribute>k__BackingField = value;
		}
	}

	// Token: 0x06004C8E RID: 19598 RVA: 0x001F2172 File Offset: 0x001F0572
	// Note: this type is marked as 'beforefieldinit'.
	static UnitOutputCapacity()
	{
	}

	// Token: 0x04003AF2 RID: 15090
	public static double MaxOutput = 10000000000.0;

	// Token: 0x04003AF3 RID: 15091
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;

	// Token: 0x04003AF4 RID: 15092
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <OutputAttribute>k__BackingField;
}
