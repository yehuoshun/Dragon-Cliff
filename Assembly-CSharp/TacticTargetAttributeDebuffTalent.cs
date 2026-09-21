using System;
using System.Collections.Generic;

// Token: 0x0200041B RID: 1051
[Serializable]
public class TacticTargetAttributeDebuffTalent : TacticTalentBase
{
	// Token: 0x06001CDF RID: 7391 RVA: 0x000C487F File Offset: 0x000C2C7F
	public TacticTargetAttributeDebuffTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CE0 RID: 7392 RVA: 0x000C488C File Offset: 0x000C2C8C
	public AttributeBuff GetBuff()
	{
		if (this.SkillType == SkillType.CurseOfTheDead)
		{
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
		if (this.SkillType == SkillType.GhostlySmoke)
		{
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.DodgeRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.08,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = 0.08,
					Seconds = 5
				};
			}
		}
		if (this.SkillType == SkillType.PoisonousMist)
		{
			if (this.SlotNumber == 2)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Allresistances,
					ModificationType = ModificationType.Multiplication,
					Value = 0.1,
					Seconds = 5
				};
			}
			if (this.SlotNumber == 3)
			{
				return new AttributeBuff
				{
					AttributeType = AttributeType.Resilience,
					ModificationType = ModificationType.Multiplication,
					Value = 0.08,
					Seconds = 5
				};
			}
		}
		if (this.SkillType == SkillType.Sunder)
		{
			return new AttributeBuff
			{
				AttributeType = AttributeType.Resilience,
				ModificationType = ModificationType.Multiplication,
				Value = 0.08,
				Seconds = 5
			};
		}
		if (this.SkillType == SkillType.Punishment && this.SlotNumber == 3)
		{
			return new AttributeBuff
			{
				AttributeType = AttributeType.Resilience,
				ModificationType = ModificationType.Multiplication,
				Value = 0.15,
				Seconds = 5
			};
		}
		if (this.SkillType == SkillType.GrandMeteorolite && this.SlotNumber == 1)
		{
			return new AttributeBuff
			{
				AttributeType = AttributeType.Allresistances,
				ModificationType = ModificationType.Multiplication,
				Value = 0.12,
				Seconds = 5
			};
		}
		throw new NotImplementedException();
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x000C4B08 File Offset: 0x000C2F08
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ActiveTargetDebuff;
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x000C4B0C File Offset: 0x000C2F0C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		AttributeBuff buff = this.GetBuff();
		return new List<ISpecialEffectDataLoad>
		{
			new ActiveStrategyTargetDebuffData
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
