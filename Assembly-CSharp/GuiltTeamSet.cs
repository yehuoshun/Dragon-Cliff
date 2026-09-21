using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006AF RID: 1711
public class GuiltTeamSet : TeamSetBase
{
	// Token: 0x06002D68 RID: 11624 RVA: 0x00128F94 File Offset: 0x00127394
	public GuiltTeamSet()
	{
	}

	// Token: 0x170005BF RID: 1471
	// (get) Token: 0x06002D69 RID: 11625 RVA: 0x00128FDC File Offset: 0x001273DC
	public override TeamSetType SetType
	{
		get
		{
			return this._setType;
		}
	}

	// Token: 0x170005C0 RID: 1472
	// (get) Token: 0x06002D6A RID: 11626 RVA: 0x00128FE4 File Offset: 0x001273E4
	public override List<ResourceType> TeamSetPieces
	{
		get
		{
			return this._teamSetPieces;
		}
	}

	// Token: 0x06002D6B RID: 11627 RVA: 0x00128FEC File Offset: 0x001273EC
	public override AttributeType GeneratePrimaryAttributeType(ResourceType pieceType)
	{
		if (pieceType == ResourceType.HatredOfPrince)
		{
			return ((double)UnityEngine.Random.value > 0.5) ? AttributeType.Strength : AttributeType.Intelligience;
		}
		if (pieceType == ResourceType.LoveOfPrince)
		{
			return AttributeType.CritDamage;
		}
		if (pieceType == ResourceType.SinOfPrince)
		{
			return AttributeType.Agility;
		}
		return AttributeType.None;
	}

	// Token: 0x06002D6C RID: 11628 RVA: 0x0012903B File Offset: 0x0012743B
	public override ItemSuitableClassType GetItemSuitableClassType(ResourceType type)
	{
		if (type == ResourceType.HatredOfPrince)
		{
			return ItemSuitableClassType.Assassin;
		}
		if (type == ResourceType.LoveOfPrince)
		{
			return ItemSuitableClassType.Support;
		}
		if (type == ResourceType.SinOfPrince)
		{
			return ItemSuitableClassType.Tank;
		}
		return ItemSuitableClassType.None;
	}

	// Token: 0x06002D6D RID: 11629 RVA: 0x00129068 File Offset: 0x00127468
	public override List<ISpecialEffectDataLoad> GetTeamBonus()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GuiltEffectData
			{
				DirectDamageBoostRate = 4.0,
				HitRatingBoost = 1.0,
				EffectHitReduction = 0.1
			}
		};
	}

	// Token: 0x040026BC RID: 9916
	private TeamSetType _setType = TeamSetType.Guilt;

	// Token: 0x040026BD RID: 9917
	private List<ResourceType> _teamSetPieces = new List<ResourceType>
	{
		ResourceType.HatredOfPrince,
		ResourceType.LoveOfPrince,
		ResourceType.SinOfPrince
	};
}
