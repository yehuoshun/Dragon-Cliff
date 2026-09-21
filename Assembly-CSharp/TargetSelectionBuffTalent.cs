using System;
using System.Collections.Generic;

// Token: 0x0200041D RID: 1053
[Serializable]
public class TargetSelectionBuffTalent : TacticTalentBase
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x000C70DD File Offset: 0x000C54DD
	public TargetSelectionBuffTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x000C70E8 File Offset: 0x000C54E8
	public AttributeBuff GetBuff()
	{
		if (this.SkillType == SkillType.SpellOfHoliness)
		{
			return new AttributeBuff
			{
				AttributeType = AttributeType.EffectResistanceRating,
				ModificationType = ModificationType.Addition,
				Value = 150.0,
				Seconds = 5
			};
		}
		if (this.SkillType == SkillType.IronBlood)
		{
			if (this.SlotNumber == 1)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.EffectHitRating,
					ModificationType = ModificationType.Addition,
					Value = 180.0,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.DodgeRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 5
				};
			}
		}
		if (this.SkillType == SkillType.Drunkenness)
		{
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Allresistances,
					ModificationType = ModificationType.Multiplication,
					Value = 0.15,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 5
				};
			}
		}
		if (this.SkillType == SkillType.Encouragement)
		{
			if (this.SlotNumber == 1)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Allresistances,
					ModificationType = ModificationType.Multiplication,
					Value = 0.1,
					Seconds = 10
				};
			}
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 10
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Resilience,
					ModificationType = ModificationType.Multiplication,
					Value = 0.1,
					Seconds = 10
				};
			}
		}
		if (this.SkillType == SkillType.DivineRemedy)
		{
			if (this.SlotNumber == 1)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.EffectResistanceRating,
					ModificationType = ModificationType.Addition,
					Value = 200.0,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.DodgeRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.1,
					Seconds = 5
				};
			}
		}
		throw new NotImplementedException();
	}

	// Token: 0x06001CFE RID: 7422 RVA: 0x000C740B File Offset: 0x000C580B
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TargetSelectionBuff;
	}

	// Token: 0x06001CFF RID: 7423 RVA: 0x000C7410 File Offset: 0x000C5810
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		AttributeBuff buff = this.GetBuff();
		return new List<ISpecialEffectDataLoad>
		{
			new ActiveStrategyTargetBoostData
			{
				IsStar = false,
				ModificationType = buff.ModificationType,
				Value = buff.Value,
				Type = buff.AttributeType,
				Seconds = buff.Seconds
			}
		};
	}
}
