using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000727 RID: 1831
public class BattleHeal
{
	// Token: 0x0600335F RID: 13151 RVA: 0x00158B80 File Offset: 0x00156F80
	public BattleHeal(IBattleUnit target, IBattleEffectSource source, List<HealComponentValue> values, bool applicableToDeadUnit)
	{
		this.Heals = (from v in values
		select new HealComponent(target, source.SourceUnit, v)).ToList<HealComponent>();
		this.Target = target;
		this.HealSource = source;
		this.ApplicableToDeadUnit = applicableToDeadUnit;
	}

	// Token: 0x170007EA RID: 2026
	// (get) Token: 0x06003360 RID: 13152 RVA: 0x00158BE4 File Offset: 0x00156FE4
	// (set) Token: 0x06003361 RID: 13153 RVA: 0x00158BEC File Offset: 0x00156FEC
	public IBattleUnit Target
	{
		[CompilerGenerated]
		get
		{
			return this.<Target>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Target>k__BackingField = value;
		}
	}

	// Token: 0x170007EB RID: 2027
	// (get) Token: 0x06003362 RID: 13154 RVA: 0x00158BF5 File Offset: 0x00156FF5
	// (set) Token: 0x06003363 RID: 13155 RVA: 0x00158BFD File Offset: 0x00156FFD
	public List<HealComponent> Heals
	{
		[CompilerGenerated]
		get
		{
			return this.<Heals>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Heals>k__BackingField = value;
		}
	}

	// Token: 0x170007EC RID: 2028
	// (get) Token: 0x06003364 RID: 13156 RVA: 0x00158C06 File Offset: 0x00157006
	// (set) Token: 0x06003365 RID: 13157 RVA: 0x00158C0E File Offset: 0x0015700E
	public IBattleEffectSource HealSource
	{
		[CompilerGenerated]
		get
		{
			return this.<HealSource>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealSource>k__BackingField = value;
		}
	}

	// Token: 0x170007ED RID: 2029
	// (get) Token: 0x06003366 RID: 13158 RVA: 0x00158C17 File Offset: 0x00157017
	// (set) Token: 0x06003367 RID: 13159 RVA: 0x00158C1F File Offset: 0x0015701F
	public bool ApplicableToDeadUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<ApplicableToDeadUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<ApplicableToDeadUnit>k__BackingField = value;
		}
	}

	// Token: 0x170007EE RID: 2030
	// (get) Token: 0x06003368 RID: 13160 RVA: 0x00158C28 File Offset: 0x00157028
	public IBattleUnit Healer
	{
		get
		{
			return this.HealSource.SourceUnit;
		}
	}

	// Token: 0x170007EF RID: 2031
	// (get) Token: 0x06003369 RID: 13161 RVA: 0x00158C35 File Offset: 0x00157035
	// (set) Token: 0x0600336A RID: 13162 RVA: 0x00158C3D File Offset: 0x0015703D
	public ReleaseableHeal Releaseable
	{
		[CompilerGenerated]
		get
		{
			return this.<Releaseable>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Releaseable>k__BackingField = value;
		}
	}

	// Token: 0x04002813 RID: 10259
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x04002814 RID: 10260
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<HealComponent> <Heals>k__BackingField;

	// Token: 0x04002815 RID: 10261
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <HealSource>k__BackingField;

	// Token: 0x04002816 RID: 10262
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <ApplicableToDeadUnit>k__BackingField;

	// Token: 0x04002817 RID: 10263
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ReleaseableHeal <Releaseable>k__BackingField;

	// Token: 0x02000E89 RID: 3721
	[CompilerGenerated]
	private sealed class <BattleHeal>c__AnonStorey0
	{
		// Token: 0x06005DA7 RID: 23975 RVA: 0x00158C46 File Offset: 0x00157046
		public <BattleHeal>c__AnonStorey0()
		{
		}

		// Token: 0x06005DA8 RID: 23976 RVA: 0x00158C4E File Offset: 0x0015704E
		internal HealComponent <>m__0(HealComponentValue v)
		{
			return new HealComponent(this.target, this.source.SourceUnit, v);
		}

		// Token: 0x040050FD RID: 20733
		internal IBattleUnit target;

		// Token: 0x040050FE RID: 20734
		internal IBattleEffectSource source;
	}
}
