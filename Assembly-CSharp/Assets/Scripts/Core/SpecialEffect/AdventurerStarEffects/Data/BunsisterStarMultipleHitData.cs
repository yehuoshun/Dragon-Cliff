using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200077E RID: 1918
	[Serializable]
	public class BunsisterStarMultipleHitData : ISpecialEffectDataLoad
	{
		// Token: 0x060038B2 RID: 14514 RVA: 0x001728D1 File Offset: 0x00170CD1
		public BunsisterStarMultipleHitData()
		{
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x001728D9 File Offset: 0x00170CD9
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.BunSisterStarMultipleHit;
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x001728E0 File Offset: 0x00170CE0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x0017291B File Offset: 0x00170D1B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x0017291E File Offset: 0x00170D1E
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x04002C44 RID: 11332
		public double Chance;
	}
}
