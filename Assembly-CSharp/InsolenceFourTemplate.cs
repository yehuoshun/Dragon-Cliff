using System;
using System.Collections.Generic;

// Token: 0x02000557 RID: 1367
public class InsolenceFourTemplate : AccessoryTemplateBase
{
	// Token: 0x0600278C RID: 10124 RVA: 0x00118D7A File Offset: 0x0011717A
	public InsolenceFourTemplate()
	{
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x0600278D RID: 10125 RVA: 0x00118D95 File Offset: 0x00117195
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x0600278E RID: 10126 RVA: 0x00118D9D File Offset: 0x0011719D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600278F RID: 10127 RVA: 0x00118DA8 File Offset: 0x001171A8
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

	// Token: 0x06002790 RID: 10128 RVA: 0x00118DE4 File Offset: 0x001171E4
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.12),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.5)
		};
	}

	// Token: 0x040021A3 RID: 8611
	private ResourceType _itemType = ResourceType.InsolenceFour;

	// Token: 0x040021A4 RID: 8612
	private int _itemTierNumber = 20;
}
