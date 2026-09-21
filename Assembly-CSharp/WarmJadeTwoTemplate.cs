using System;
using System.Collections.Generic;

// Token: 0x02000578 RID: 1400
public class WarmJadeTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002834 RID: 10292 RVA: 0x0011A8B6 File Offset: 0x00118CB6
	public WarmJadeTwoTemplate()
	{
	}

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06002835 RID: 10293 RVA: 0x0011A8D1 File Offset: 0x00118CD1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x06002836 RID: 10294 RVA: 0x0011A8D9 File Offset: 0x00118CD9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002837 RID: 10295 RVA: 0x0011A8E4 File Offset: 0x00118CE4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 1,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.FriendlyAlive
				}
			}
		};
	}

	// Token: 0x06002838 RID: 10296 RVA: 0x0011A920 File Offset: 0x00118D20
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.06),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.3)
		};
	}

	// Token: 0x040021E6 RID: 8678
	private ResourceType _itemType = ResourceType.WarmJadeTwo;

	// Token: 0x040021E7 RID: 8679
	private int _itemTierNumber = 10;
}
