using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020001B2 RID: 434
public class EquipmentDropdownBaseController : MonoBehaviour
{
	// Token: 0x06000B65 RID: 2917 RVA: 0x00085DEE File Offset: 0x000841EE
	public EquipmentDropdownBaseController()
	{
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000B66 RID: 2918 RVA: 0x00085DF6 File Offset: 0x000841F6
	// (set) Token: 0x06000B67 RID: 2919 RVA: 0x00085DFE File Offset: 0x000841FE
	public List<OrderTypeDropdownValue> DropdownValues
	{
		[CompilerGenerated]
		get
		{
			return this.<DropdownValues>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DropdownValues>k__BackingField = value;
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x06000B68 RID: 2920 RVA: 0x00085E07 File Offset: 0x00084207
	// (set) Token: 0x06000B69 RID: 2921 RVA: 0x00085E0F File Offset: 0x0008420F
	public int SelectedValue
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedValue>k__BackingField = value;
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x00085E18 File Offset: 0x00084218
	protected string GetOrderTypeTitle(ItemOrderType type)
	{
		switch (type)
		{
		case ItemOrderType.Default:
			return UIComponentType.ItemOrderTypeDefault.GetName();
		case ItemOrderType.OrderByGrade:
			return UIComponentType.ItemOrderTypeGrade.GetName();
		case ItemOrderType.OrderByLevel:
			return UIComponentType.ItemOrderTypeLevel.GetName();
		case ItemOrderType.OrderByType:
			return UIComponentType.ItemOrderTypeType.GetName();
		case ItemOrderType.OrderByTime:
			return UIComponentType.ItemOrderTypeTime.GetName();
		case ItemOrderType.OrderByStrength:
			return UIComponentType.ItemOrderTypeStrength.GetName();
		case ItemOrderType.OrderByIntelligence:
			return UIComponentType.ItemOrderTypeIntelligence.GetName();
		case ItemOrderType.OrderBySpeed:
			return UIComponentType.ItemOrderTypeSpeed.GetName();
		case ItemOrderType.OrderByVitality:
			return UIComponentType.ItemOrderTypeVitality.GetName();
		case ItemOrderType.OrderByCritRate:
			return UIComponentType.ItemOrderTypeCritRate.GetName();
		case ItemOrderType.OrderByCritDamage:
			return UIComponentType.ItemOrderTypeCritDamge.GetName();
		case ItemOrderType.OrderByResilience:
			return UIComponentType.OrderByResilience.GetName();
		case ItemOrderType.OrderByReflectiveDamage:
			return UIComponentType.ItemOrderTypeReflectiveDamage.GetName();
		case ItemOrderType.OrderByLifeOnHit:
			return UIComponentType.ItemOrderTypeLifeOnHit.GetName();
		case ItemOrderType.OrderByStunOnHit:
			return UIComponentType.ItemOrderByStunOnHit.GetName();
		case ItemOrderType.OrderByTauntOnHit:
			return UIComponentType.ItemOrderByTauntOnHit.GetName();
		case ItemOrderType.OrderByHealAbsorbRate:
			return UIComponentType.OrderByHealAbsorbRate.GetName();
		case ItemOrderType.OrderByEffectMastery:
			return UIComponentType.OrderByEffectMastery.GetName();
		case ItemOrderType.OrderByRageEfficiency:
			return UIComponentType.OrderByRageEfficiency.GetName();
		case ItemOrderType.OrderByBattleStartHeal:
			return UIComponentType.OrderByBattleStartHeal.GetName();
		case ItemOrderType.OrderByTurnStartHeal:
			return UIComponentType.OrderByTurnStartHeal.GetName();
		case ItemOrderType.OrderByReceivedHealEffectivenessChangeRate:
			return UIComponentType.OrderByReceivedHealEffectivenessChangeRate.GetName();
		case ItemOrderType.OrderByAllResistance:
			return UIComponentType.ItemOrderByAllResistance.GetName();
		case ItemOrderType.OrderByMining:
			return UIComponentType.OrderByMining.GetName();
		case ItemOrderType.OrderByLogging:
			return UIComponentType.OrderByLogging.GetName();
		case ItemOrderType.OrderByHunting:
			return UIComponentType.OrderByHunting.GetName();
		case ItemOrderType.OrderByHitRateAdjustment:
			return UIComponentType.ItemOrderByHitRateAdjustment.GetName();
		case ItemOrderType.OrderByDodgeRateAdjustment:
			return UIComponentType.ItemOrderByDodgeRateAdjustment.GetName();
		case ItemOrderType.OrderByEffectHitRating:
			return UIComponentType.OrderByEffectHitRating.GetName();
		case ItemOrderType.OrderByEffectResistanceRating:
			return UIComponentType.OrderByEffectResistanceRating.GetName();
		case ItemOrderType.OrderByFireEnhancement:
			return UIComponentType.ItemOrderByFireEnhancement.GetName();
		case ItemOrderType.OrderByLightingEnhancement:
			return UIComponentType.ItemOrderByLightingEnhancement.GetName();
		case ItemOrderType.OrderByPoisonEnhancement:
			return UIComponentType.ItemOrderByPoisonEnhancement.GetName();
		case ItemOrderType.OrderByPhysicalEnhancement:
			return UIComponentType.ItemOrderByPhysicalEnhancement.GetName();
		case ItemOrderType.OrderByIceEnhancement:
			return UIComponentType.ItemOrderByIceEnhancement.GetName();
		case ItemOrderType.OrderByDivineEnhancement:
			return UIComponentType.ItemOrderByDivineEnhancement.GetName();
		case ItemOrderType.OrderByShadowEnhancement:
			return UIComponentType.ItemOrderByShadowEnhancement.GetName();
		case ItemOrderType.OrderByPhysicalPenetration:
			return UIComponentType.OrderByPhysicalPenetration.GetName();
		case ItemOrderType.OrderByFirePenetration:
			return UIComponentType.OrderByFirePenetration.GetName();
		case ItemOrderType.OrderByIcePenetration:
			return UIComponentType.OrderByIcePenetration.GetName();
		case ItemOrderType.OrderByShadowPenetration:
			return UIComponentType.OrderByShadowPenetration.GetName();
		case ItemOrderType.OrderByPoisonPenetration:
			return UIComponentType.OrderByPoisonPenetration.GetName();
		case ItemOrderType.OrderByDivinePenetration:
			return UIComponentType.OrderByDivinePenetration.GetName();
		case ItemOrderType.OrderByLighteningPenetration:
			return UIComponentType.OrderByLighteningPenetration.GetName();
		default:
			return string.Empty;
		}
	}

	// Token: 0x04000DDD RID: 3549
	public TMP_Dropdown Dropdown;

	// Token: 0x04000DDE RID: 3550
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<OrderTypeDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x04000DDF RID: 3551
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;
}
