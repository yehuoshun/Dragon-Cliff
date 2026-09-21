using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200078F RID: 1935
	[Serializable]
	public class MissionaryStarReflectionData : ISpecialEffectDataLoad
	{
		// Token: 0x06003908 RID: 14600 RVA: 0x0017300E File Offset: 0x0017140E
		public MissionaryStarReflectionData()
		{
		}

		// Token: 0x06003909 RID: 14601 RVA: 0x00173016 File Offset: 0x00171416
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.MissionaryStarReflection;
		}

		// Token: 0x0600390A RID: 14602 RVA: 0x00173020 File Offset: 0x00171420
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600390B RID: 14603 RVA: 0x0017305B File Offset: 0x0017145B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600390C RID: 14604 RVA: 0x0017305E File Offset: 0x0017145E
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x04002C60 RID: 11360
		public double Rate;
	}
}
