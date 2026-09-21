using System;
using System.Collections.Generic;

// Token: 0x02000574 RID: 1396
public class WarmJadeOneTemplate : AccessoryTemplateBase
{
	// Token: 0x0600281E RID: 10270 RVA: 0x0011A5CA File Offset: 0x001189CA
	public WarmJadeOneTemplate()
	{
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x0600281F RID: 10271 RVA: 0x0011A5E4 File Offset: 0x001189E4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06002820 RID: 10272 RVA: 0x0011A5EC File Offset: 0x001189EC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002821 RID: 10273 RVA: 0x0011A5F4 File Offset: 0x001189F4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 1,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.FriendlyAlive
				}
			}
		};
	}

	// Token: 0x06002822 RID: 10274 RVA: 0x0011A630 File Offset: 0x00118A30
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.03),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.2)
		};
	}

	// Token: 0x040021DE RID: 8670
	private ResourceType _itemType = ResourceType.WarmJadeOne;

	// Token: 0x040021DF RID: 8671
	private int _itemTierNumber = 5;
}
