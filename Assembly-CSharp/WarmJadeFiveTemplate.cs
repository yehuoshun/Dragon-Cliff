using System;
using System.Collections.Generic;

// Token: 0x02000572 RID: 1394
public class WarmJadeFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x06002813 RID: 10259 RVA: 0x0011A453 File Offset: 0x00118853
	public WarmJadeFiveTemplate()
	{
	}

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x06002814 RID: 10260 RVA: 0x0011A46E File Offset: 0x0011886E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x06002815 RID: 10261 RVA: 0x0011A476 File Offset: 0x00118876
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002816 RID: 10262 RVA: 0x0011A480 File Offset: 0x00118880
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

	// Token: 0x06002817 RID: 10263 RVA: 0x0011A4A8 File Offset: 0x001188A8
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

	// Token: 0x06002818 RID: 10264 RVA: 0x0011A4E4 File Offset: 0x001188E4
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.15),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.6)
		};
	}

	// Token: 0x040021DA RID: 8666
	private ResourceType _itemType = ResourceType.WarmJadeFive;

	// Token: 0x040021DB RID: 8667
	private int _itemTierNumber = 37;
}
