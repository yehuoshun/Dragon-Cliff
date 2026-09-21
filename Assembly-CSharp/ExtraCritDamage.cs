using System;
using System.Collections.Generic;

// Token: 0x02000A31 RID: 2609
public class ExtraCritDamage : AffixAttachmentRuleBase
{
	// Token: 0x06004730 RID: 18224 RVA: 0x001D177B File Offset: 0x001CFB7B
	public ExtraCritDamage()
	{
	}

	// Token: 0x17000DD9 RID: 3545
	// (get) Token: 0x06004731 RID: 18225 RVA: 0x001D1783 File Offset: 0x001CFB83
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraCritDamage;
		}
	}

	// Token: 0x06004732 RID: 18226 RVA: 0x001D1788 File Offset: 0x001CFB88
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.CritDamage,
				Value = 0.800000011920929
			}
		};
	}
}
