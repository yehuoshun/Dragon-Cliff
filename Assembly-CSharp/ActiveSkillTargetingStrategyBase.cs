using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006D1 RID: 1745
public abstract class ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F64 RID: 12132 RVA: 0x001449B7 File Offset: 0x00142DB7
	protected ActiveSkillTargetingStrategyBase(AdventureUnitSkill skill)
	{
		this.Skill = skill;
	}

	// Token: 0x1700062E RID: 1582
	// (get) Token: 0x06002F65 RID: 12133 RVA: 0x001449C6 File Offset: 0x00142DC6
	// (set) Token: 0x06002F66 RID: 12134 RVA: 0x001449CE File Offset: 0x00142DCE
	public bool IsResolved
	{
		[CompilerGenerated]
		get
		{
			return this.<IsResolved>k__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			this.<IsResolved>k__BackingField = value;
		}
	}

	// Token: 0x1700062F RID: 1583
	// (get) Token: 0x06002F67 RID: 12135 RVA: 0x001449D7 File Offset: 0x00142DD7
	// (set) Token: 0x06002F68 RID: 12136 RVA: 0x001449DF File Offset: 0x00142DDF
	public AdventureUnitSkill Skill
	{
		[CompilerGenerated]
		get
		{
			return this.<Skill>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Skill>k__BackingField = value;
		}
	}

	// Token: 0x06002F69 RID: 12137
	public abstract List<IBattleUnit> GetCandidates();

	// Token: 0x17000630 RID: 1584
	// (get) Token: 0x06002F6A RID: 12138 RVA: 0x001449E8 File Offset: 0x00142DE8
	// (set) Token: 0x06002F6B RID: 12139 RVA: 0x001449F0 File Offset: 0x00142DF0
	public List<IBattleUnit> Selections
	{
		[CompilerGenerated]
		get
		{
			return this.<Selections>k__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			this.<Selections>k__BackingField = value;
		}
	}

	// Token: 0x06002F6C RID: 12140 RVA: 0x001449F9 File Offset: 0x00142DF9
	public void Resolve(List<IBattleUnit> selections)
	{
		if (!this.IsResolved && this.SelectionValidate(selections))
		{
			this.Selections = selections;
			this.IsResolved = true;
		}
	}

	// Token: 0x06002F6D RID: 12141
	protected abstract bool SelectionValidate(List<IBattleUnit> selections);

	// Token: 0x04002746 RID: 10054
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsResolved>k__BackingField;

	// Token: 0x04002747 RID: 10055
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <Skill>k__BackingField;

	// Token: 0x04002748 RID: 10056
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<IBattleUnit> <Selections>k__BackingField;
}
