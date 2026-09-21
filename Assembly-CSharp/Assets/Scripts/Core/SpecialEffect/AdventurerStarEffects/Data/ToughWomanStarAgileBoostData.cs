using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200079A RID: 1946
	[Serializable]
	public class ToughWomanStarAgileBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x06003941 RID: 14657 RVA: 0x001734DE File Offset: 0x001718DE
		public ToughWomanStarAgileBoostData()
		{
		}

		// Token: 0x06003942 RID: 14658 RVA: 0x001734E6 File Offset: 0x001718E6
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ToughWomanStarAgileBoost;
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x001734F0 File Offset: 0x001718F0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003944 RID: 14660 RVA: 0x0017352B File Offset: 0x0017192B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x0017352E File Offset: 0x0017192E
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C6B RID: 11371
		public double Rate;
	}
}
