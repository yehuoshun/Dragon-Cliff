using System;
using System.Collections.Generic;

// Token: 0x0200069F RID: 1695
public class FairyStoneSetLogic : SetItemLogicBase
{
	// Token: 0x06002CF9 RID: 11513 RVA: 0x001271FB File Offset: 0x001255FB
	public FairyStoneSetLogic()
	{
	}

	// Token: 0x170005A7 RID: 1447
	// (get) Token: 0x06002CFA RID: 11514 RVA: 0x0012720E File Offset: 0x0012560E
	public override ResourceType CorrespondingSetResourceType
	{
		get
		{
			return this._correspondingSetResourceType;
		}
	}

	// Token: 0x06002CFB RID: 11515 RVA: 0x00127218 File Offset: 0x00125618
	public override List<AttributeModifier> MinorAttributeModifiers()
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealFireDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealPhysicalDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealShadowDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealIceDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealLightningDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealPoisonDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.DealDivineDamageEffectivenessChangeRate,
				Value = 0.2,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06002CFC RID: 11516 RVA: 0x001273EC File Offset: 0x001257EC
	public override List<AttributeModifier> MajorAttributeModifiers()
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x06002CFD RID: 11517 RVA: 0x001273F3 File Offset: 0x001257F3
	public override List<ISpecialEffectDataLoad> MinorEffects()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002CFE RID: 11518 RVA: 0x001273FC File Offset: 0x001257FC
	public override List<ISpecialEffectDataLoad> MajorEffects()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FairyStoneData
			{
				Chance = 0.25
			}
		};
	}

	// Token: 0x040026A0 RID: 9888
	private ResourceType _correspondingSetResourceType = ResourceType.FairyStone;
}
