using System;
using System.Collections.Generic;

// Token: 0x02000558 RID: 1368
public class InsolenceOneTemplate : AccessoryTemplateBase
{
	// Token: 0x06002791 RID: 10129 RVA: 0x00118E22 File Offset: 0x00117222
	public InsolenceOneTemplate()
	{
	}

	// Token: 0x17000343 RID: 835
	// (get) Token: 0x06002792 RID: 10130 RVA: 0x00118E3C File Offset: 0x0011723C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000344 RID: 836
	// (get) Token: 0x06002793 RID: 10131 RVA: 0x00118E44 File Offset: 0x00117244
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002794 RID: 10132 RVA: 0x00118E4C File Offset: 0x0011724C
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

	// Token: 0x06002795 RID: 10133 RVA: 0x00118E88 File Offset: 0x00117288
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.03),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.2)
		};
	}

	// Token: 0x040021A5 RID: 8613
	private ResourceType _itemType = ResourceType.InsolenceOne;

	// Token: 0x040021A6 RID: 8614
	private int _itemTierNumber = 5;
}
