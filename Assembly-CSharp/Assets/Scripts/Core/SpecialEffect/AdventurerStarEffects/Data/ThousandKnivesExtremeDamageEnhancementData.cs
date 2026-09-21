using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000799 RID: 1945
	[Serializable]
	public class ThousandKnivesExtremeDamageEnhancementData : ISpecialEffectDataLoad
	{
		// Token: 0x0600393C RID: 14652 RVA: 0x00173486 File Offset: 0x00171886
		public ThousandKnivesExtremeDamageEnhancementData()
		{
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x0017348E File Offset: 0x0017188E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ThousandKnivesExtremeDamageEnhancement;
		}

		// Token: 0x0600393E RID: 14654 RVA: 0x00173498 File Offset: 0x00171898
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.ExtraDamageRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600393F RID: 14655 RVA: 0x001734D3 File Offset: 0x001718D3
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003940 RID: 14656 RVA: 0x001734D6 File Offset: 0x001718D6
		public double GetEffectPowerValue()
		{
			return this.ExtraDamageRate;
		}

		// Token: 0x04002C6A RID: 11370
		public double ExtraDamageRate;
	}
}
