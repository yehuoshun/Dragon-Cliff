using System;
using System.Collections.Generic;

// Token: 0x020003B0 RID: 944
[Serializable]
public class ArmorOfWindBoostTalent : TacticTalentBase
{
	// Token: 0x0600191B RID: 6427 RVA: 0x000C004E File Offset: 0x000BE44E
	public ArmorOfWindBoostTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x0600191C RID: 6428 RVA: 0x000C0058 File Offset: 0x000BE458
	public AttributeBuff GetBuff()
	{
		if (this.SlotNumber == 2)
		{
			return new AttributeBuff
			{
				AttributeType = AttributeType.Agility,
				ModificationType = ModificationType.Multiplication,
				Value = 0.08,
				Seconds = 1
			};
		}
		return new AttributeBuff
		{
			AttributeType = AttributeType.CritDamage,
			ModificationType = ModificationType.Addition,
			Value = 0.15,
			Seconds = 1
		};
	}

	// Token: 0x0600191D RID: 6429 RVA: 0x000C00C8 File Offset: 0x000BE4C8
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ArmorOfWindAttributeBuff;
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x000C00CC File Offset: 0x000BE4CC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		AttributeBuff buff = this.GetBuff();
		return new List<ISpecialEffectDataLoad>
		{
			new ArmorOfWindAttributeEnhancementData
			{
				IsStar = false,
				ModificationType = buff.ModificationType,
				Value = buff.Value,
				Type = buff.AttributeType
			}
		};
	}
}
