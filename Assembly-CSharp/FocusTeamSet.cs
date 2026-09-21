using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006AE RID: 1710
public class FocusTeamSet : TeamSetBase
{
	// Token: 0x06002D62 RID: 11618 RVA: 0x00128E80 File Offset: 0x00127280
	public FocusTeamSet()
	{
	}

	// Token: 0x170005BD RID: 1469
	// (get) Token: 0x06002D63 RID: 11619 RVA: 0x00128EC8 File Offset: 0x001272C8
	public override TeamSetType SetType
	{
		get
		{
			return this._setType;
		}
	}

	// Token: 0x170005BE RID: 1470
	// (get) Token: 0x06002D64 RID: 11620 RVA: 0x00128ED0 File Offset: 0x001272D0
	public override List<ResourceType> TeamSetPieces
	{
		get
		{
			return this._teamSetPieces;
		}
	}

	// Token: 0x06002D65 RID: 11621 RVA: 0x00128ED8 File Offset: 0x001272D8
	public override AttributeType GeneratePrimaryAttributeType(ResourceType pieceType)
	{
		if (pieceType == ResourceType.CircleOfFocus)
		{
			return AttributeType.CritDamage;
		}
		if (pieceType == ResourceType.WheelOfFocus)
		{
			return AttributeType.Agility;
		}
		if (pieceType == ResourceType.SpikeOfFocus)
		{
			return ((double)UnityEngine.Random.value > 0.5) ? AttributeType.Strength : AttributeType.Intelligience;
		}
		return AttributeType.None;
	}

	// Token: 0x06002D66 RID: 11622 RVA: 0x00128F27 File Offset: 0x00127327
	public override ItemSuitableClassType GetItemSuitableClassType(ResourceType type)
	{
		if (type == ResourceType.CircleOfFocus)
		{
			return ItemSuitableClassType.Balanced;
		}
		if (type == ResourceType.WheelOfFocus)
		{
			return ItemSuitableClassType.Healer;
		}
		if (type == ResourceType.SpikeOfFocus)
		{
			return ItemSuitableClassType.Assassin;
		}
		return ItemSuitableClassType.None;
	}

	// Token: 0x06002D67 RID: 11623 RVA: 0x00128F54 File Offset: 0x00127354
	public override List<ISpecialEffectDataLoad> GetTeamBonus()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FocusEffectData
			{
				DamageBoostRate = 15.0,
				DamageReductionRate = 5.0
			}
		};
	}

	// Token: 0x040026BA RID: 9914
	private TeamSetType _setType = TeamSetType.Focus;

	// Token: 0x040026BB RID: 9915
	private List<ResourceType> _teamSetPieces = new List<ResourceType>
	{
		ResourceType.CircleOfFocus,
		ResourceType.WheelOfFocus,
		ResourceType.SpikeOfFocus
	};
}
