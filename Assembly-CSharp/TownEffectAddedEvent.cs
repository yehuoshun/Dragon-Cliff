using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004BB RID: 1211
public class TownEffectAddedEvent
{
	// Token: 0x060023CC RID: 9164 RVA: 0x001031E7 File Offset: 0x001015E7
	public TownEffectAddedEvent()
	{
	}

	// Token: 0x1700026C RID: 620
	// (get) Token: 0x060023CD RID: 9165 RVA: 0x001031EF File Offset: 0x001015EF
	// (set) Token: 0x060023CE RID: 9166 RVA: 0x001031F7 File Offset: 0x001015F7
	public TownEffectBase Effect
	{
		[CompilerGenerated]
		get
		{
			return this.<Effect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Effect>k__BackingField = value;
		}
	}

	// Token: 0x1700026D RID: 621
	// (get) Token: 0x060023CF RID: 9167 RVA: 0x00103200 File Offset: 0x00101600
	// (set) Token: 0x060023D0 RID: 9168 RVA: 0x00103208 File Offset: 0x00101608
	public object Trigger
	{
		[CompilerGenerated]
		get
		{
			return this.<Trigger>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Trigger>k__BackingField = value;
		}
	}

	// Token: 0x04001EF4 RID: 7924
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownEffectBase <Effect>k__BackingField;

	// Token: 0x04001EF5 RID: 7925
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object <Trigger>k__BackingField;
}
