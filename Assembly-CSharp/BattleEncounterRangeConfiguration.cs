using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000448 RID: 1096
public class BattleEncounterRangeConfiguration
{
	// Token: 0x06001EAB RID: 7851 RVA: 0x000D5E20 File Offset: 0x000D4220
	public BattleEncounterRangeConfiguration()
	{
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x06001EAC RID: 7852 RVA: 0x000D5E28 File Offset: 0x000D4228
	// (set) Token: 0x06001EAD RID: 7853 RVA: 0x000D5E30 File Offset: 0x000D4230
	public int EnemyAmountInBattleInclusiveFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<EnemyAmountInBattleInclusiveFrom>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EnemyAmountInBattleInclusiveFrom>k__BackingField = value;
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06001EAE RID: 7854 RVA: 0x000D5E39 File Offset: 0x000D4239
	// (set) Token: 0x06001EAF RID: 7855 RVA: 0x000D5E41 File Offset: 0x000D4241
	public int EnemyAmountInBattleExclusiveTo
	{
		[CompilerGenerated]
		get
		{
			return this.<EnemyAmountInBattleExclusiveTo>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EnemyAmountInBattleExclusiveTo>k__BackingField = value;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x06001EB0 RID: 7856 RVA: 0x000D5E4A File Offset: 0x000D424A
	// (set) Token: 0x06001EB1 RID: 7857 RVA: 0x000D5E52 File Offset: 0x000D4252
	public int NumberOfRounds
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfRounds>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfRounds>k__BackingField = value;
		}
	}

	// Token: 0x04001C19 RID: 7193
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EnemyAmountInBattleInclusiveFrom>k__BackingField;

	// Token: 0x04001C1A RID: 7194
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EnemyAmountInBattleExclusiveTo>k__BackingField;

	// Token: 0x04001C1B RID: 7195
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NumberOfRounds>k__BackingField;
}
