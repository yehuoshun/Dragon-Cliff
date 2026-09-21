using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000786 RID: 1926
	[Serializable]
	public class ElementalWizardStarHealShieldData : ISpecialEffectDataLoad
	{
		// Token: 0x060038DA RID: 14554 RVA: 0x00172BEE File Offset: 0x00170FEE
		public ElementalWizardStarHealShieldData()
		{
		}

		// Token: 0x060038DB RID: 14555 RVA: 0x00172BF6 File Offset: 0x00170FF6
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ElementalWizardStarHeal;
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x00172C00 File Offset: 0x00171000
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100()).Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x00172C50 File Offset: 0x00171050
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x00172C53 File Offset: 0x00171053
		public double GetEffectPowerValue()
		{
			return this.Rate * this.Chance;
		}

		// Token: 0x04002C51 RID: 11345
		public double Chance;

		// Token: 0x04002C52 RID: 11346
		public double Rate;
	}
}
