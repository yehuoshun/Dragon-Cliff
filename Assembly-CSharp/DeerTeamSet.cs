using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006AD RID: 1709
public class DeerTeamSet : TeamSetBase
{
	// Token: 0x06002D5C RID: 11612 RVA: 0x00128D68 File Offset: 0x00127168
	public DeerTeamSet()
	{
	}

	// Token: 0x170005BB RID: 1467
	// (get) Token: 0x06002D5D RID: 11613 RVA: 0x00128DB0 File Offset: 0x001271B0
	public override TeamSetType SetType
	{
		get
		{
			return this._setType;
		}
	}

	// Token: 0x170005BC RID: 1468
	// (get) Token: 0x06002D5E RID: 11614 RVA: 0x00128DB8 File Offset: 0x001271B8
	public override List<ResourceType> TeamSetPieces
	{
		get
		{
			return this._teamSetPieces;
		}
	}

	// Token: 0x06002D5F RID: 11615 RVA: 0x00128DC0 File Offset: 0x001271C0
	public override AttributeType GeneratePrimaryAttributeType(ResourceType pieceType)
	{
		if (pieceType == ResourceType.AshOfDeerGod)
		{
			return AttributeType.Resilience;
		}
		if (pieceType == ResourceType.RockOfDeerGod)
		{
			return AttributeType.Allresistances;
		}
		if (pieceType == ResourceType.TorchOfDeerGod)
		{
			return ((double)UnityEngine.Random.value > 0.5) ? AttributeType.Strength : AttributeType.Intelligience;
		}
		return AttributeType.None;
	}

	// Token: 0x06002D60 RID: 11616 RVA: 0x00128E14 File Offset: 0x00127214
	public override ItemSuitableClassType GetItemSuitableClassType(ResourceType type)
	{
		if (type == ResourceType.AshOfDeerGod)
		{
			return ItemSuitableClassType.Healer;
		}
		if (type == ResourceType.RockOfDeerGod)
		{
			return ItemSuitableClassType.Tank;
		}
		if (type == ResourceType.TorchOfDeerGod)
		{
			return ItemSuitableClassType.Assassin;
		}
		return ItemSuitableClassType.None;
	}

	// Token: 0x06002D61 RID: 11617 RVA: 0x00128E40 File Offset: 0x00127240
	public override List<ISpecialEffectDataLoad> GetTeamBonus()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ReincarnationData
			{
				DamageSuctionRate = 0.1,
				HealRate = 0.3
			}
		};
	}

	// Token: 0x040026B8 RID: 9912
	private TeamSetType _setType = TeamSetType.Deer;

	// Token: 0x040026B9 RID: 9913
	private List<ResourceType> _teamSetPieces = new List<ResourceType>
	{
		ResourceType.AshOfDeerGod,
		ResourceType.RockOfDeerGod,
		ResourceType.TorchOfDeerGod
	};
}
