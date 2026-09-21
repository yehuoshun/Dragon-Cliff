using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000791 RID: 1937
	[Serializable]
	public class PaladinDecayEnhancementData : ISpecialEffectDataLoad
	{
		// Token: 0x06003912 RID: 14610 RVA: 0x00173090 File Offset: 0x00171490
		public PaladinDecayEnhancementData()
		{
		}

		// Token: 0x06003913 RID: 14611 RVA: 0x00173098 File Offset: 0x00171498
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.PaladinDecayEnhancement;
		}

		// Token: 0x06003914 RID: 14612 RVA: 0x001730A0 File Offset: 0x001714A0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003915 RID: 14613 RVA: 0x001730DB File Offset: 0x001714DB
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003916 RID: 14614 RVA: 0x001730DE File Offset: 0x001714DE
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C61 RID: 11361
		public double Rate;
	}
}
