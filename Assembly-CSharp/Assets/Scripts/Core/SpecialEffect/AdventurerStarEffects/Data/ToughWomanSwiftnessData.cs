using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200079B RID: 1947
	[Serializable]
	public class ToughWomanSwiftnessData : ISpecialEffectDataLoad
	{
		// Token: 0x06003946 RID: 14662 RVA: 0x00173536 File Offset: 0x00171936
		public ToughWomanSwiftnessData()
		{
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x0017353E File Offset: 0x0017193E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ToughWomanSwiftness;
		}

		// Token: 0x06003948 RID: 14664 RVA: 0x00173548 File Offset: 0x00171948
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003949 RID: 14665 RVA: 0x00173583 File Offset: 0x00171983
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600394A RID: 14666 RVA: 0x00173586 File Offset: 0x00171986
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C6C RID: 11372
		public double Rate;
	}
}
