using System;
using System.Collections.Generic;

// Token: 0x02000A34 RID: 2612
public class ExtraHitLife : AffixAttachmentRuleBase
{
	// Token: 0x06004739 RID: 18233 RVA: 0x001D184E File Offset: 0x001CFC4E
	public ExtraHitLife()
	{
	}

	// Token: 0x17000DDC RID: 3548
	// (get) Token: 0x0600473A RID: 18234 RVA: 0x001D1856 File Offset: 0x001CFC56
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraHitLife;
		}
	}

	// Token: 0x0600473B RID: 18235 RVA: 0x001D185C File Offset: 0x001CFC5C
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.LifeOnHit,
				Value = 0.20000000298023224
			}
		};
	}
}
