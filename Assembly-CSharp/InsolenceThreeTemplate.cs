using System;
using System.Collections.Generic;

// Token: 0x0200055B RID: 1371
public class InsolenceThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x060027A2 RID: 10146 RVA: 0x00119066 File Offset: 0x00117466
	public InsolenceThreeTemplate()
	{
	}

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x060027A3 RID: 10147 RVA: 0x00119081 File Offset: 0x00117481
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700034A RID: 842
	// (get) Token: 0x060027A4 RID: 10148 RVA: 0x00119089 File Offset: 0x00117489
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027A5 RID: 10149 RVA: 0x00119094 File Offset: 0x00117494
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 1,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}

	// Token: 0x060027A6 RID: 10150 RVA: 0x001190D0 File Offset: 0x001174D0
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.09),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.4)
		};
	}

	// Token: 0x040021AB RID: 8619
	private ResourceType _itemType = ResourceType.InsolenceThree;

	// Token: 0x040021AC RID: 8620
	private int _itemTierNumber = 17;
}
