using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200043D RID: 1085
public class ConsumableEventSource : IBattleEffectSource
{
	// Token: 0x06001E55 RID: 7765 RVA: 0x000D52E1 File Offset: 0x000D36E1
	public ConsumableEventSource(IBattleUnit sourceUnit, Item item)
	{
		this.SourceUnit = sourceUnit;
		this.Item = item;
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06001E56 RID: 7766 RVA: 0x000D52F7 File Offset: 0x000D36F7
	// (set) Token: 0x06001E57 RID: 7767 RVA: 0x000D52FF File Offset: 0x000D36FF
	public IBattleUnit SourceUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<SourceUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SourceUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06001E58 RID: 7768 RVA: 0x000D5308 File Offset: 0x000D3708
	// (set) Token: 0x06001E59 RID: 7769 RVA: 0x000D5310 File Offset: 0x000D3710
	public Item Item
	{
		[CompilerGenerated]
		get
		{
			return this.<Item>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Item>k__BackingField = value;
		}
	}

	// Token: 0x04001BF5 RID: 7157
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;

	// Token: 0x04001BF6 RID: 7158
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Item>k__BackingField;
}
