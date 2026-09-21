using System;
using System.Collections.Generic;

// Token: 0x0200055C RID: 1372
public class InsolenceTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x060027A7 RID: 10151 RVA: 0x0011910E File Offset: 0x0011750E
	public InsolenceTwoTemplate()
	{
	}

	// Token: 0x1700034B RID: 843
	// (get) Token: 0x060027A8 RID: 10152 RVA: 0x00119129 File Offset: 0x00117529
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x060027A9 RID: 10153 RVA: 0x00119131 File Offset: 0x00117531
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027AA RID: 10154 RVA: 0x0011913C File Offset: 0x0011753C
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

	// Token: 0x060027AB RID: 10155 RVA: 0x00119178 File Offset: 0x00117578
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.06),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.3)
		};
	}

	// Token: 0x040021AD RID: 8621
	private ResourceType _itemType = ResourceType.InsolenceTwo;

	// Token: 0x040021AE RID: 8622
	private int _itemTierNumber = 10;
}
