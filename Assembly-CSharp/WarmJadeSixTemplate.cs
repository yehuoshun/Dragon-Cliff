using System;
using System.Collections.Generic;

// Token: 0x02000576 RID: 1398
public class WarmJadeSixTemplate : AccessoryTemplateBase
{
	// Token: 0x06002829 RID: 10281 RVA: 0x0011A73E File Offset: 0x00118B3E
	public WarmJadeSixTemplate()
	{
	}

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x0600282A RID: 10282 RVA: 0x0011A759 File Offset: 0x00118B59
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000380 RID: 896
	// (get) Token: 0x0600282B RID: 10283 RVA: 0x0011A761 File Offset: 0x00118B61
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600282C RID: 10284 RVA: 0x0011A76C File Offset: 0x00118B6C
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

	// Token: 0x0600282D RID: 10285 RVA: 0x0011A794 File Offset: 0x00118B94
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

	// Token: 0x0600282E RID: 10286 RVA: 0x0011A7D0 File Offset: 0x00118BD0
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.18),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.7)
		};
	}

	// Token: 0x040021E2 RID: 8674
	private ResourceType _itemType = ResourceType.WarmJadeSix;

	// Token: 0x040021E3 RID: 8675
	private int _itemTierNumber = 45;
}
