using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200078D RID: 1933
	[Serializable]
	public class IronSoilderStarHitBoostData : ISpecialEffectDataLoad
	{
		// Token: 0x060038FE RID: 14590 RVA: 0x00172F26 File Offset: 0x00171326
		public IronSoilderStarHitBoostData()
		{
		}

		// Token: 0x060038FF RID: 14591 RVA: 0x00172F2E File Offset: 0x0017132E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.IronSoilderStarHitBoost;
		}

		// Token: 0x06003900 RID: 14592 RVA: 0x00172F38 File Offset: 0x00171338
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{hit}", this.HitBoost.ToExpressionMultiply100()).Replace("{dodge}", this.DodgeBoost.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003901 RID: 14593 RVA: 0x00172F9D File Offset: 0x0017139D
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003902 RID: 14594 RVA: 0x00172FA0 File Offset: 0x001713A0
		public double GetEffectPowerValue()
		{
			return this.Chance * this.HitBoost * this.DodgeBoost;
		}

		// Token: 0x04002C5C RID: 11356
		public double Chance;

		// Token: 0x04002C5D RID: 11357
		public double HitBoost;

		// Token: 0x04002C5E RID: 11358
		public double DodgeBoost;
	}
}
