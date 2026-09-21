using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A6 RID: 1190
public class BattleUnitSpeaksEvent
{
	// Token: 0x06002361 RID: 9057 RVA: 0x00102E63 File Offset: 0x00101263
	public BattleUnitSpeaksEvent()
	{
	}

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06002362 RID: 9058 RVA: 0x00102E6B File Offset: 0x0010126B
	// (set) Token: 0x06002363 RID: 9059 RVA: 0x00102E73 File Offset: 0x00101273
	public IBattleUnit BattleUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06002364 RID: 9060 RVA: 0x00102E7C File Offset: 0x0010127C
	// (set) Token: 0x06002365 RID: 9061 RVA: 0x00102E84 File Offset: 0x00101284
	public List<DialogDetails> DialogDetails
	{
		[CompilerGenerated]
		get
		{
			return this.<DialogDetails>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DialogDetails>k__BackingField = value;
		}
	}

	// Token: 0x04001E63 RID: 7779
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x04001E64 RID: 7780
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogDetails> <DialogDetails>k__BackingField;
}
