using System;

// Token: 0x020006DB RID: 1755
public interface IDamageDefinition
{
	// Token: 0x1700063B RID: 1595
	// (get) Token: 0x06002FA1 RID: 12193
	TargetDefinition TargetDefinition { get; }

	// Token: 0x06002FA2 RID: 12194
	ReleaseableDamage GetReleaseableDamage(IBattleUnit caster, IBattleEffectSource damageSrouce);
}
