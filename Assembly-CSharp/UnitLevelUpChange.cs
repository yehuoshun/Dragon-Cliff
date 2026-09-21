using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B3A RID: 2874
public class UnitLevelUpChange
{
	// Token: 0x06004C7E RID: 19582 RVA: 0x001F1F93 File Offset: 0x001F0393
	public UnitLevelUpChange()
	{
	}

	// Token: 0x1700107A RID: 4218
	// (get) Token: 0x06004C7F RID: 19583 RVA: 0x001F1F9B File Offset: 0x001F039B
	// (set) Token: 0x06004C80 RID: 19584 RVA: 0x001F1FA3 File Offset: 0x001F03A3
	public List<LevelUpChangeValue> ChangedValues
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangedValues>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangedValues>k__BackingField = value;
		}
	}

	// Token: 0x06004C81 RID: 19585 RVA: 0x001F1FAC File Offset: 0x001F03AC
	public double GetChangedValue(AttributeType type)
	{
		if (this.ChangedValues.Any((LevelUpChangeValue t) => t.AttributeType == type))
		{
			return this.ChangedValues.First((LevelUpChangeValue a) => a.AttributeType == type).Value;
		}
		return 0.0;
	}

	// Token: 0x06004C82 RID: 19586 RVA: 0x001F2008 File Offset: 0x001F0408
	public string ToDisplayFormat(AttributeType type)
	{
		double changedValue = this.GetChangedValue(type);
		if (changedValue > 0.0)
		{
			return "+" + changedValue.ToExpression();
		}
		return string.Empty;
	}

	// Token: 0x04003AEF RID: 15087
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<LevelUpChangeValue> <ChangedValues>k__BackingField;

	// Token: 0x02001081 RID: 4225
	[CompilerGenerated]
	private sealed class <GetChangedValue>c__AnonStorey0
	{
		// Token: 0x06006982 RID: 27010 RVA: 0x001F2042 File Offset: 0x001F0442
		public <GetChangedValue>c__AnonStorey0()
		{
		}

		// Token: 0x06006983 RID: 27011 RVA: 0x001F204A File Offset: 0x001F044A
		internal bool <>m__0(LevelUpChangeValue t)
		{
			return t.AttributeType == this.type;
		}

		// Token: 0x06006984 RID: 27012 RVA: 0x001F205A File Offset: 0x001F045A
		internal bool <>m__1(LevelUpChangeValue a)
		{
			return a.AttributeType == this.type;
		}

		// Token: 0x04006402 RID: 25602
		internal AttributeType type;
	}
}
