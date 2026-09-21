using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000785 RID: 1925
	[Serializable]
	public class DuelistStarSkillBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x060038D5 RID: 14549 RVA: 0x00172B96 File Offset: 0x00170F96
		public DuelistStarSkillBoostData()
		{
		}

		// Token: 0x060038D6 RID: 14550 RVA: 0x00172B9E File Offset: 0x00170F9E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.DuelistStarSkillBoost;
		}

		// Token: 0x060038D7 RID: 14551 RVA: 0x00172BA8 File Offset: 0x00170FA8
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038D8 RID: 14552 RVA: 0x00172BE3 File Offset: 0x00170FE3
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x00172BE6 File Offset: 0x00170FE6
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C50 RID: 11344
		public double Rate;
	}
}
