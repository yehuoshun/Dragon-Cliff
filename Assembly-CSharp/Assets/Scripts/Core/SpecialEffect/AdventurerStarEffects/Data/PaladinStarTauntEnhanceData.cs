using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000792 RID: 1938
	[Serializable]
	public class PaladinStarTauntEnhanceData : ISpecialEffectDataLoad
	{
		// Token: 0x06003917 RID: 14615 RVA: 0x001730E6 File Offset: 0x001714E6
		public PaladinStarTauntEnhanceData()
		{
		}

		// Token: 0x06003918 RID: 14616 RVA: 0x001730EE File Offset: 0x001714EE
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.PaladinStarTauntEnhance;
		}

		// Token: 0x06003919 RID: 14617 RVA: 0x001730F8 File Offset: 0x001714F8
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600391A RID: 14618 RVA: 0x00173133 File Offset: 0x00171533
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600391B RID: 14619 RVA: 0x00173136 File Offset: 0x00171536
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x04002C62 RID: 11362
		public double Chance;
	}
}
