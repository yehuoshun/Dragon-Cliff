using System;
using System.Collections.Generic;

// Token: 0x02000A2E RID: 2606
public abstract class AffixAttachmentRuleBase
{
	// Token: 0x06004724 RID: 18212 RVA: 0x001D171F File Offset: 0x001CFB1F
	protected AffixAttachmentRuleBase()
	{
	}

	// Token: 0x17000DD6 RID: 3542
	// (get) Token: 0x06004725 RID: 18213
	public abstract AffixType CorrespondingAffixType { get; }

	// Token: 0x06004726 RID: 18214 RVA: 0x001D1727 File Offset: 0x001CFB27
	public virtual List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>();
	}

	// Token: 0x06004727 RID: 18215 RVA: 0x001D172E File Offset: 0x001CFB2E
	public virtual List<ISpecialEffectDataLoad> GetAdditionalSpecialEffects(int monsterhiddenlevel)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004728 RID: 18216 RVA: 0x001D1735 File Offset: 0x001CFB35
	// Note: this type is marked as 'beforefieldinit'.
	static AffixAttachmentRuleBase()
	{
	}

	// Token: 0x04003955 RID: 14677
	public static float AffixCoreAttributeValueBase = 8f;
}
