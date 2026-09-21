using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200078C RID: 1932
	[Serializable]
	public class GoldenShamanStarHealData : ISpecialEffectDataLoad
	{
		// Token: 0x060038F9 RID: 14585 RVA: 0x00172ED1 File Offset: 0x001712D1
		public GoldenShamanStarHealData()
		{
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x00172ED9 File Offset: 0x001712D9
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.GoldenShamanStarHeal;
		}

		// Token: 0x060038FB RID: 14587 RVA: 0x00172EE0 File Offset: 0x001712E0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038FC RID: 14588 RVA: 0x00172F1B File Offset: 0x0017131B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038FD RID: 14589 RVA: 0x00172F1E File Offset: 0x0017131E
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C5B RID: 11355
		public double Rate;
	}
}
