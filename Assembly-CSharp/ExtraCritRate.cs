using System;
using System.Collections.Generic;

// Token: 0x02000A32 RID: 2610
public class ExtraCritRate : AffixAttachmentRuleBase
{
	// Token: 0x06004733 RID: 18227 RVA: 0x001D17BF File Offset: 0x001CFBBF
	public ExtraCritRate()
	{
	}

	// Token: 0x17000DDA RID: 3546
	// (get) Token: 0x06004734 RID: 18228 RVA: 0x001D17C7 File Offset: 0x001CFBC7
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraCritRate;
		}
	}

	// Token: 0x06004735 RID: 18229 RVA: 0x001D17CC File Offset: 0x001CFBCC
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.CritRate,
				Value = 0.20000000298023224
			}
		};
	}
}
