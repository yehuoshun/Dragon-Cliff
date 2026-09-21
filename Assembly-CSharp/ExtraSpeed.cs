using System;
using System.Collections.Generic;

// Token: 0x02000A37 RID: 2615
public class ExtraSpeed : AffixAttachmentRuleBase
{
	// Token: 0x06004742 RID: 18242 RVA: 0x001D1953 File Offset: 0x001CFD53
	public ExtraSpeed()
	{
	}

	// Token: 0x17000DDF RID: 3551
	// (get) Token: 0x06004743 RID: 18243 RVA: 0x001D195B File Offset: 0x001CFD5B
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraSpeed;
		}
	}

	// Token: 0x06004744 RID: 18244 RVA: 0x001D1960 File Offset: 0x001CFD60
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.Agility,
				Value = (double)AffixAttachmentRuleBase.AffixCoreAttributeValueBase
			}
		};
	}
}
