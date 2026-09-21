using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200042A RID: 1066
public class AdventureEvent
{
	// Token: 0x06001D8C RID: 7564 RVA: 0x000CC5D4 File Offset: 0x000CA9D4
	public AdventureEvent(IBattleUnit eventTriggerUnit, IBattleUnit eventListener, AdventureEventType eventType, object additionalData)
	{
		this.EventTriggerUnit = eventTriggerUnit;
		this.EventListener = eventListener;
		this.EventType = eventType;
		this.AdditionalData = additionalData;
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x06001D8D RID: 7565 RVA: 0x000CC5F9 File Offset: 0x000CA9F9
	// (set) Token: 0x06001D8E RID: 7566 RVA: 0x000CC601 File Offset: 0x000CAA01
	public IBattleUnit EventTriggerUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<EventTriggerUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EventTriggerUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x06001D8F RID: 7567 RVA: 0x000CC60A File Offset: 0x000CAA0A
	// (set) Token: 0x06001D90 RID: 7568 RVA: 0x000CC612 File Offset: 0x000CAA12
	public IBattleUnit EventListener
	{
		[CompilerGenerated]
		get
		{
			return this.<EventListener>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EventListener>k__BackingField = value;
		}
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x06001D91 RID: 7569 RVA: 0x000CC61B File Offset: 0x000CAA1B
	// (set) Token: 0x06001D92 RID: 7570 RVA: 0x000CC623 File Offset: 0x000CAA23
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

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x06001D93 RID: 7571 RVA: 0x000CC62C File Offset: 0x000CAA2C
	// (set) Token: 0x06001D94 RID: 7572 RVA: 0x000CC634 File Offset: 0x000CAA34
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

	// Token: 0x04001B35 RID: 6965
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <EventTriggerUnit>k__BackingField;

	// Token: 0x04001B36 RID: 6966
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <EventListener>k__BackingField;

	// Token: 0x04001B37 RID: 6967
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureEventType <EventType>k__BackingField;

	// Token: 0x04001B38 RID: 6968
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object <AdditionalData>k__BackingField;
}
