using System;
using System.Collections.Generic;

// Token: 0x02000559 RID: 1369
public class InsolenceSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002796 RID: 10134 RVA: 0x00118EC6 File Offset: 0x001172C6
	public InsolenceSevenTemplate()
	{
	}

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x06002797 RID: 10135 RVA: 0x00118EE1 File Offset: 0x001172E1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x06002798 RID: 10136 RVA: 0x00118EE9 File Offset: 0x001172E9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002799 RID: 10137 RVA: 0x00118EF4 File Offset: 0x001172F4
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

	// Token: 0x0600279A RID: 10138 RVA: 0x00118F30 File Offset: 0x00117330
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

	// Token: 0x0600279B RID: 10139 RVA: 0x00118F58 File Offset: 0x00117358
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.21),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.8)
		};
	}

	// Token: 0x040021A7 RID: 8615
	private ResourceType _itemType = ResourceType.InsolenceSeven;

	// Token: 0x040021A8 RID: 8616
	private int _itemTierNumber = 52;
}
