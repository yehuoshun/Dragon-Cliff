using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200078E RID: 1934
	[Serializable]
	public class KillerStarReflectionData : ISpecialEffectDataLoad
	{
		// Token: 0x06003903 RID: 14595 RVA: 0x00172FB6 File Offset: 0x001713B6
		public KillerStarReflectionData()
		{
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x00172FBE File Offset: 0x001713BE
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.KillerStarReflection;
		}

		// Token: 0x06003905 RID: 14597 RVA: 0x00172FC8 File Offset: 0x001713C8
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003906 RID: 14598 RVA: 0x00173003 File Offset: 0x00171403
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003907 RID: 14599 RVA: 0x00173006 File Offset: 0x00171406
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x04002C5F RID: 11359
		public double Chance;
	}
}
