using System;
using System.Collections.Generic;

// Token: 0x02000A33 RID: 2611
public class ExtraHealth : AffixAttachmentRuleBase
{
	// Token: 0x06004736 RID: 18230 RVA: 0x001D1803 File Offset: 0x001CFC03
	public ExtraHealth()
	{
	}

	// Token: 0x17000DDB RID: 3547
	// (get) Token: 0x06004737 RID: 18231 RVA: 0x001D180B File Offset: 0x001CFC0B
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraHealth;
		}
	}

	// Token: 0x06004738 RID: 18232 RVA: 0x001D1810 File Offset: 0x001CFC10
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.Vitality,
				Value = (double)AffixAttachmentRuleBase.AffixCoreAttributeValueBase * 1.5
			}
		};
	}
}
