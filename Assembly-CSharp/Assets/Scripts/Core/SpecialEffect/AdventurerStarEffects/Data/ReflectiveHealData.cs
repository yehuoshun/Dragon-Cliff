using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000794 RID: 1940
	[Serializable]
	public class ReflectiveHealData : ISpecialEffectDataLoad
	{
		// Token: 0x06003922 RID: 14626 RVA: 0x00173202 File Offset: 0x00171602
		public ReflectiveHealData()
		{
		}

		// Token: 0x06003923 RID: 14627 RVA: 0x0017320A File Offset: 0x0017160A
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ReflectiveHeal;
		}

		// Token: 0x06003924 RID: 14628 RVA: 0x00173214 File Offset: 0x00171614
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x0017324F File Offset: 0x0017164F
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x00173252 File Offset: 0x00171652
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C64 RID: 11364
		public double Rate;
	}
}
