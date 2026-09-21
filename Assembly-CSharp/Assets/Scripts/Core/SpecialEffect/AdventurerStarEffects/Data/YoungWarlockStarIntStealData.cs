using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200079D RID: 1949
	[Serializable]
	public class YoungWarlockStarIntStealData : ISpecialEffectDataLoad
	{
		// Token: 0x06003951 RID: 14673 RVA: 0x00173667 File Offset: 0x00171A67
		public YoungWarlockStarIntStealData()
		{
		}

		// Token: 0x06003952 RID: 14674 RVA: 0x0017366F File Offset: 0x00171A6F
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.YoungWarlockStarIntSteal;
		}

		// Token: 0x06003953 RID: 14675 RVA: 0x00173678 File Offset: 0x00171A78
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100()).Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003954 RID: 14676 RVA: 0x001736C8 File Offset: 0x00171AC8
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003955 RID: 14677 RVA: 0x001736CB File Offset: 0x00171ACB
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C6F RID: 11375
		public double Rate;

		// Token: 0x04002C70 RID: 11376
		public double Chance;
	}
}
