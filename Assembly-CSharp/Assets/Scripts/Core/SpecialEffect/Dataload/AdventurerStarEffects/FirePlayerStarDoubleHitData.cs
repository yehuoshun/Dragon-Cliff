using System;

namespace Assets.Scripts.Core.SpecialEffect.Dataload.AdventurerStarEffects
{
	// Token: 0x0200078B RID: 1931
	[Serializable]
	public class FirePlayerStarDoubleHitData : ISpecialEffectDataLoad
	{
		// Token: 0x060038F4 RID: 14580 RVA: 0x00172E58 File Offset: 0x00171258
		public FirePlayerStarDoubleHitData()
		{
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x00172E60 File Offset: 0x00171260
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FirePlayerStarDoubleHit;
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x00172E68 File Offset: 0x00171268
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{hit}", this.NumberOfAdditionalHitCheck.ToString());
			return description;
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x00172EBE File Offset: 0x001712BE
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038F8 RID: 14584 RVA: 0x00172EC1 File Offset: 0x001712C1
		public double GetEffectPowerValue()
		{
			return this.Chance * (double)this.NumberOfAdditionalHitCheck;
		}

		// Token: 0x04002C59 RID: 11353
		public double Chance;

		// Token: 0x04002C5A RID: 11354
		public int NumberOfAdditionalHitCheck;
	}
}
