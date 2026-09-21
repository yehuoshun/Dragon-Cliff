using System;
using System.Collections.Generic;

// Token: 0x020006B4 RID: 1716
public class ThornsTeamSet : TeamSetBase
{
	// Token: 0x06002D85 RID: 11653 RVA: 0x001290E0 File Offset: 0x001274E0
	public ThornsTeamSet()
	{
	}

	// Token: 0x170005C5 RID: 1477
	// (get) Token: 0x06002D86 RID: 11654 RVA: 0x00129128 File Offset: 0x00127528
	public override TeamSetType SetType
	{
		get
		{
			return this._setType;
		}
	}

	// Token: 0x170005C6 RID: 1478
	// (get) Token: 0x06002D87 RID: 11655 RVA: 0x00129130 File Offset: 0x00127530
	public override List<ResourceType> TeamSetPieces
	{
		get
		{
			return this._teamSetPieces;
		}
	}

	// Token: 0x06002D88 RID: 11656 RVA: 0x00129138 File Offset: 0x00127538
	public override AttributeType GeneratePrimaryAttributeType(ResourceType pieceType)
	{
		if (pieceType == ResourceType.HeartOfThorns)
		{
			return AttributeType.Vitality;
		}
		if (pieceType == ResourceType.EyesOfThorns)
		{
			return AttributeType.Resilience;
		}
		if (pieceType == ResourceType.BoneOfThorns)
		{
			return AttributeType.Allresistances;
		}
		return AttributeType.None;
	}

	// Token: 0x06002D89 RID: 11657 RVA: 0x00129167 File Offset: 0x00127567
	public override ItemSuitableClassType GetItemSuitableClassType(ResourceType type)
	{
		if (type == ResourceType.HeartOfThorns)
		{
			return ItemSuitableClassType.Healer;
		}
		if (type == ResourceType.EyesOfThorns)
		{
			return ItemSuitableClassType.Tank;
		}
		if (type == ResourceType.BoneOfThorns)
		{
			return ItemSuitableClassType.Support;
		}
		return ItemSuitableClassType.None;
	}

	// Token: 0x06002D8A RID: 11658 RVA: 0x00129194 File Offset: 0x00127594
	public override List<ISpecialEffectDataLoad> GetTeamBonus()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThornsData()
		};
	}

	// Token: 0x040026D2 RID: 9938
	private TeamSetType _setType = TeamSetType.Thorns;

	// Token: 0x040026D3 RID: 9939
	private List<ResourceType> _teamSetPieces = new List<ResourceType>
	{
		ResourceType.HeartOfThorns,
		ResourceType.EyesOfThorns,
		ResourceType.BoneOfThorns
	};
}
