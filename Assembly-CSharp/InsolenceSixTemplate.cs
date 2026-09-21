using System;
using System.Collections.Generic;

// Token: 0x0200055A RID: 1370
public class InsolenceSixTemplate : AccessoryTemplateBase
{
	// Token: 0x0600279C RID: 10140 RVA: 0x00118F96 File Offset: 0x00117396
	public InsolenceSixTemplate()
	{
	}

	// Token: 0x17000347 RID: 839
	// (get) Token: 0x0600279D RID: 10141 RVA: 0x00118FB1 File Offset: 0x001173B1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x0600279E RID: 10142 RVA: 0x00118FB9 File Offset: 0x001173B9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600279F RID: 10143 RVA: 0x00118FC4 File Offset: 0x001173C4
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

	// Token: 0x060027A0 RID: 10144 RVA: 0x00119000 File Offset: 0x00117400
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

	// Token: 0x060027A1 RID: 10145 RVA: 0x00119028 File Offset: 0x00117428
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.18),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.7)
		};
	}

	// Token: 0x040021A9 RID: 8617
	private ResourceType _itemType = ResourceType.InsolenceSix;

	// Token: 0x040021AA RID: 8618
	private int _itemTierNumber = 45;
}
