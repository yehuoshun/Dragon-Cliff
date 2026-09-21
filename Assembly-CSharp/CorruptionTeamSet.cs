using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006AC RID: 1708
public class CorruptionTeamSet : TeamSetBase
{
	// Token: 0x06002D56 RID: 11606 RVA: 0x00128C54 File Offset: 0x00127054
	public CorruptionTeamSet()
	{
	}

	// Token: 0x170005B9 RID: 1465
	// (get) Token: 0x06002D57 RID: 11607 RVA: 0x00128C9C File Offset: 0x0012709C
	public override TeamSetType SetType
	{
		get
		{
			return this._setType;
		}
	}

	// Token: 0x170005BA RID: 1466
	// (get) Token: 0x06002D58 RID: 11608 RVA: 0x00128CA4 File Offset: 0x001270A4
	public override List<ResourceType> TeamSetPieces
	{
		get
		{
			return this._teamSetPieces;
		}
	}

	// Token: 0x06002D59 RID: 11609 RVA: 0x00128CAC File Offset: 0x001270AC
	public override AttributeType GeneratePrimaryAttributeType(ResourceType pieceType)
	{
		if (pieceType == ResourceType.DustOfCorruption)
		{
			return AttributeType.Agility;
		}
		if (pieceType == ResourceType.PetalOfCorruption)
		{
			return ((double)UnityEngine.Random.value > 0.5) ? AttributeType.Strength : AttributeType.Intelligience;
		}
		if (pieceType == ResourceType.GhostOfCorruption)
		{
			return AttributeType.Allresistances;
		}
		return AttributeType.None;
	}

	// Token: 0x06002D5A RID: 11610 RVA: 0x00128CFC File Offset: 0x001270FC
	public override ItemSuitableClassType GetItemSuitableClassType(ResourceType type)
	{
		if (type == ResourceType.DustOfCorruption)
		{
			return ItemSuitableClassType.Assassin;
		}
		if (type == ResourceType.PetalOfCorruption)
		{
			return ItemSuitableClassType.Balanced;
		}
		if (type == ResourceType.GhostOfCorruption)
		{
			return ItemSuitableClassType.Healer;
		}
		return ItemSuitableClassType.None;
	}

	// Token: 0x06002D5B RID: 11611 RVA: 0x00128D28 File Offset: 0x00127128
	public override List<ISpecialEffectDataLoad> GetTeamBonus()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AnnihilationData
			{
				EffectResistanceReductionRate = 0.1,
				OutputReductionRate = 0.05
			}
		};
	}

	// Token: 0x040026B6 RID: 9910
	private TeamSetType _setType = TeamSetType.Corruption;

	// Token: 0x040026B7 RID: 9911
	private List<ResourceType> _teamSetPieces = new List<ResourceType>
	{
		ResourceType.DustOfCorruption,
		ResourceType.PetalOfCorruption,
		ResourceType.GhostOfCorruption
	};
}
