using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000796 RID: 1942
	[Serializable]
	public class SoulThiefStarEffectBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x0600392D RID: 14637 RVA: 0x0017337C File Offset: 0x0017177C
		public SoulThiefStarEffectBoostData()
		{
		}

		// Token: 0x0600392E RID: 14638 RVA: 0x00173384 File Offset: 0x00171784
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SoulThiefStarEffectBoost;
		}

		// Token: 0x0600392F RID: 14639 RVA: 0x0017338C File Offset: 0x0017178C
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003930 RID: 14640 RVA: 0x001733C7 File Offset: 0x001717C7
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003931 RID: 14641 RVA: 0x001733CA File Offset: 0x001717CA
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x04002C67 RID: 11367
		public double Chance;
	}
}
