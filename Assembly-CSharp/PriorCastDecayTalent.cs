using System;
using System.Collections.Generic;

// Token: 0x020003F2 RID: 1010
[Serializable]
public class PriorCastDecayTalent : TacticTalentBase
{
	// Token: 0x06001B95 RID: 7061 RVA: 0x000C335F File Offset: 0x000C175F
	public PriorCastDecayTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001B96 RID: 7062 RVA: 0x000C336C File Offset: 0x000C176C
	public AttributeBuff GetBuff()
	{
		if (this.SkillType == SkillType.Brutality)
		{
			if (this.SlotNumber == 1)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Allresistances,
					ModificationType = ModificationType.Multiplication,
					Value = 0.2,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Resilience,
					ModificationType = ModificationType.Multiplication,
					Value = 0.2,
					Seconds = 5
				};
			}
		}
		throw new NotImplementedException();
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x000C3403 File Offset: 0x000C1803
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ActiveTargetAttributeDecayPriorCast;
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x000C3408 File Offset: 0x000C1808
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		AttributeBuff buff = this.GetBuff();
		return new List<ISpecialEffectDataLoad>
		{
			new ActiveTargetAttributeDecayPriorCastData
			{
				IsStar = false,
				ModificationType = buff.ModificationType,
				Type = buff.AttributeType,
				Seconds = buff.Seconds,
				Rate = buff.Value
			}
		};
	}
}
