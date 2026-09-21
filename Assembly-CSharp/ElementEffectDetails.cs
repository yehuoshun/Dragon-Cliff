using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000A2A RID: 2602
public class ElementEffectDetails
{
	// Token: 0x06004710 RID: 18192 RVA: 0x001D1341 File Offset: 0x001CF741
	public ElementEffectDetails()
	{
	}

	// Token: 0x17000DCE RID: 3534
	// (get) Token: 0x06004711 RID: 18193 RVA: 0x001D1349 File Offset: 0x001CF749
	// (set) Token: 0x06004712 RID: 18194 RVA: 0x001D1351 File Offset: 0x001CF751
	public OutputType Type
	{
		[CompilerGenerated]
		get
		{
			return this.<Type>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Type>k__BackingField = value;
		}
	}

	// Token: 0x17000DCF RID: 3535
	// (get) Token: 0x06004713 RID: 18195 RVA: 0x001D135A File Offset: 0x001CF75A
	// (set) Token: 0x06004714 RID: 18196 RVA: 0x001D1362 File Offset: 0x001CF762
	public bool Unlocked
	{
		[CompilerGenerated]
		get
		{
			return this.<Unlocked>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Unlocked>k__BackingField = value;
		}
	}

	// Token: 0x17000DD0 RID: 3536
	// (get) Token: 0x06004715 RID: 18197 RVA: 0x001D136B File Offset: 0x001CF76B
	// (set) Token: 0x06004716 RID: 18198 RVA: 0x001D1373 File Offset: 0x001CF773
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return this.<Description>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Description>k__BackingField = value;
		}
	}

	// Token: 0x0400393E RID: 14654
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <Type>k__BackingField;

	// Token: 0x0400393F RID: 14655
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <Unlocked>k__BackingField;

	// Token: 0x04003940 RID: 14656
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Description>k__BackingField;
}
