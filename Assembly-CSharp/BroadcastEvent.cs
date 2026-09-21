using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200043C RID: 1084
public class BroadcastEvent
{
	// Token: 0x06001E4E RID: 7758 RVA: 0x000D5291 File Offset: 0x000D3691
	public BroadcastEvent(IBattleUnit eventTriggeringUnit, AdventureEventType eventType, object additionalData)
	{
		this.EventTriggeringUnit = eventTriggeringUnit;
		this.EventType = eventType;
		this.AdditionalData = additionalData;
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x06001E4F RID: 7759 RVA: 0x000D52AE File Offset: 0x000D36AE
	// (set) Token: 0x06001E50 RID: 7760 RVA: 0x000D52B6 File Offset: 0x000D36B6
	public IBattleUnit EventTriggeringUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<EventTriggeringUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EventTriggeringUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x06001E51 RID: 7761 RVA: 0x000D52BF File Offset: 0x000D36BF
	// (set) Token: 0x06001E52 RID: 7762 RVA: 0x000D52C7 File Offset: 0x000D36C7
	public AdventureEventType EventType
	{
		[CompilerGenerated]
		get
		{
			return this.<EventType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EventType>k__BackingField = value;
		}
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x06001E53 RID: 7763 RVA: 0x000D52D0 File Offset: 0x000D36D0
	// (set) Token: 0x06001E54 RID: 7764 RVA: 0x000D52D8 File Offset: 0x000D36D8
	public object AdditionalData
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalData>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdditionalData>k__BackingField = value;
		}
	}

	// Token: 0x04001BF2 RID: 7154
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <EventTriggeringUnit>k__BackingField;

	// Token: 0x04001BF3 RID: 7155
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureEventType <EventType>k__BackingField;

	// Token: 0x04001BF4 RID: 7156
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object <AdditionalData>k__BackingField;
}
