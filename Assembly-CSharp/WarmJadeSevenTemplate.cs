using System;
using System.Collections.Generic;

// Token: 0x02000575 RID: 1397
public class WarmJadeSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002823 RID: 10275 RVA: 0x0011A66E File Offset: 0x00118A6E
	public WarmJadeSevenTemplate()
	{
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06002824 RID: 10276 RVA: 0x0011A689 File Offset: 0x00118A89
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06002825 RID: 10277 RVA: 0x0011A691 File Offset: 0x00118A91
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002826 RID: 10278 RVA: 0x0011A69C File Offset: 0x00118A9C
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExcessiveHealToOtherUnitData
			{
				IsStar = true
			}
		};
	}

	// Token: 0x06002827 RID: 10279 RVA: 0x0011A6C4 File Offset: 0x00118AC4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.FriendlyAlive
				}
			}
		};
	}

	// Token: 0x06002828 RID: 10280 RVA: 0x0011A700 File Offset: 0x00118B00
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.21),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.8)
		};
	}

	// Token: 0x040021E0 RID: 8672
	private ResourceType _itemType = ResourceType.WarmJadeSeven;

	// Token: 0x040021E1 RID: 8673
	private int _itemTierNumber = 52;
}
