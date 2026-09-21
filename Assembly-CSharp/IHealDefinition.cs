using System;

// Token: 0x020006DC RID: 1756
public interface IHealDefinition
{
	// Token: 0x1700063C RID: 1596
	// (get) Token: 0x06002FA3 RID: 12195
	TargetDefinition TargetDefinition { get; }

	// Token: 0x1700063D RID: 1597
	// (get) Token: 0x06002FA4 RID: 12196
	OutputType HealType { get; }

	// Token: 0x06002FA5 RID: 12197
	ReleaseableHeal GetReleaseableHeal(IBattleUnit caster, IBattleEffectSource healSource, OutputType healType);
}
