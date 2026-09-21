using System;
using System.Collections.Generic;

// Token: 0x02000556 RID: 1366
public class InsolenceFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x06002786 RID: 10118 RVA: 0x00118CAA File Offset: 0x001170AA
	public InsolenceFiveTemplate()
	{
	}

	// Token: 0x1700033F RID: 831
	// (get) Token: 0x06002787 RID: 10119 RVA: 0x00118CC5 File Offset: 0x001170C5
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000340 RID: 832
	// (get) Token: 0x06002788 RID: 10120 RVA: 0x00118CCD File Offset: 0x001170CD
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002789 RID: 10121 RVA: 0x00118CD8 File Offset: 0x001170D8
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExcessiveDamageToOtherUnitData
			{
				IsStar = true
			}
		};
	}

	// Token: 0x0600278A RID: 10122 RVA: 0x00118D00 File Offset: 0x00117100
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}

	// Token: 0x0600278B RID: 10123 RVA: 0x00118D3C File Offset: 0x0011713C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.15),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.6)
		};
	}

	// Token: 0x040021A1 RID: 8609
	private ResourceType _itemType = ResourceType.InsolenceFive;

	// Token: 0x040021A2 RID: 8610
	private int _itemTierNumber = 37;
}
