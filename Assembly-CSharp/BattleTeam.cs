using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000989 RID: 2441
[Serializable]
public class BattleTeam
{
	// Token: 0x060042DE RID: 17118 RVA: 0x001B4FC7 File Offset: 0x001B33C7
	public BattleTeam()
	{
		this.Adventurers = new List<AdventurerProfile>();
		this.Rules = new List<StrategyRule>();
	}

	// Token: 0x17000D38 RID: 3384
	// (get) Token: 0x060042DF RID: 17119 RVA: 0x001B4FE5 File Offset: 0x001B33E5
	// (set) Token: 0x060042E0 RID: 17120 RVA: 0x001B4FED File Offset: 0x001B33ED
	public List<AdventurerProfile> Adventurers
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurers>k__BackingField = value;
		}
	}

	// Token: 0x17000D39 RID: 3385
	// (get) Token: 0x060042E1 RID: 17121 RVA: 0x001B4FF6 File Offset: 0x001B33F6
	// (set) Token: 0x060042E2 RID: 17122 RVA: 0x001B4FFE File Offset: 0x001B33FE
	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return this.<IsSelected>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsSelected>k__BackingField = value;
		}
	}

	// Token: 0x17000D3A RID: 3386
	// (get) Token: 0x060042E3 RID: 17123 RVA: 0x001B5007 File Offset: 0x001B3407
	// (set) Token: 0x060042E4 RID: 17124 RVA: 0x001B500F File Offset: 0x001B340F
	public bool AutoUseTactic
	{
		[CompilerGenerated]
		get
		{
			return this.<AutoUseTactic>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AutoUseTactic>k__BackingField = value;
		}
	}

	// Token: 0x17000D3B RID: 3387
	// (get) Token: 0x060042E5 RID: 17125 RVA: 0x001B5018 File Offset: 0x001B3418
	// (set) Token: 0x060042E6 RID: 17126 RVA: 0x001B5020 File Offset: 0x001B3420
	public List<StrategyRule> Rules
	{
		[CompilerGenerated]
		get
		{
			return this.<Rules>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Rules>k__BackingField = value;
		}
	}

	// Token: 0x040032EA RID: 13034
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventurerProfile> <Adventurers>k__BackingField;

	// Token: 0x040032EB RID: 13035
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsSelected>k__BackingField;

	// Token: 0x040032EC RID: 13036
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <AutoUseTactic>k__BackingField;

	// Token: 0x040032ED RID: 13037
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<StrategyRule> <Rules>k__BackingField;
}
