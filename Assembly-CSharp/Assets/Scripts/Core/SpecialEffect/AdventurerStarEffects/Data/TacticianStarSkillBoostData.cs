using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000798 RID: 1944
	[Serializable]
	public class TacticianStarSkillBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x06003937 RID: 14647 RVA: 0x00173431 File Offset: 0x00171831
		public TacticianStarSkillBoostData()
		{
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x00173439 File Offset: 0x00171839
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.TacticianStarSkillBoost;
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x00173440 File Offset: 0x00171840
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x0017347B File Offset: 0x0017187B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x0017347E File Offset: 0x0017187E
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C69 RID: 11369
		public double Rate;
	}
}
