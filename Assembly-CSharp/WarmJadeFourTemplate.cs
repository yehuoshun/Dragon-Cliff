using System;
using System.Collections.Generic;

// Token: 0x02000573 RID: 1395
public class WarmJadeFourTemplate : AccessoryTemplateBase
{
	// Token: 0x06002819 RID: 10265 RVA: 0x0011A522 File Offset: 0x00118922
	public WarmJadeFourTemplate()
	{
	}

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x0600281A RID: 10266 RVA: 0x0011A53D File Offset: 0x0011893D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x0600281B RID: 10267 RVA: 0x0011A545 File Offset: 0x00118945
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600281C RID: 10268 RVA: 0x0011A550 File Offset: 0x00118950
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

	// Token: 0x0600281D RID: 10269 RVA: 0x0011A58C File Offset: 0x0011898C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritRate, 0.12),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.CritDamage, 0.5)
		};
	}

	// Token: 0x040021DC RID: 8668
	private ResourceType _itemType = ResourceType.WarmJadeFour;

	// Token: 0x040021DD RID: 8669
	private int _itemTierNumber = 20;
}
