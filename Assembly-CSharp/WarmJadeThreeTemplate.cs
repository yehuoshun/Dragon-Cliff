using System;
using System.Collections.Generic;

// Token: 0x02000577 RID: 1399
public class WarmJadeThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x0600282F RID: 10287 RVA: 0x0011A80E File Offset: 0x00118C0E
	public WarmJadeThreeTemplate()
	{
	}

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06002830 RID: 10288 RVA: 0x0011A829 File Offset: 0x00118C29
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x06002831 RID: 10289 RVA: 0x0011A831 File Offset: 0x00118C31
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002832 RID: 10290 RVA: 0x0011A83C File Offset: 0x00118C3C
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

	// Token: 0x06002833 RID: 10291 RVA: 0x0011A878 File Offset: 0x00118C78
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.09),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.4)
		};
	}

	// Token: 0x040021E4 RID: 8676
	private ResourceType _itemType = ResourceType.WarmJadeThree;

	// Token: 0x040021E5 RID: 8677
	private int _itemTierNumber = 17;
}
