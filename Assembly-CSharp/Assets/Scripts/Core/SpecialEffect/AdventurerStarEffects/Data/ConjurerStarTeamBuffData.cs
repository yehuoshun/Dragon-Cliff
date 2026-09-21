using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000781 RID: 1921
	[Serializable]
	public class ConjurerStarTeamBuffData : ISpecialEffectDataLoad
	{
		// Token: 0x060038C1 RID: 14529 RVA: 0x001729CB File Offset: 0x00170DCB
		public ConjurerStarTeamBuffData()
		{
		}

		// Token: 0x060038C2 RID: 14530 RVA: 0x001729D3 File Offset: 0x00170DD3
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ConjurerStarTeamBoost;
		}

		// Token: 0x060038C3 RID: 14531 RVA: 0x001729DC File Offset: 0x00170DDC
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{reflective}", this.ReflectionRate.ToExpressionMultiply100()).Replace("{hit}", this.HitRate.ToExpressionMultiply100()).Replace("{dodge}", this.DodgeRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038C4 RID: 14532 RVA: 0x00172A41 File Offset: 0x00170E41
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x00172A44 File Offset: 0x00170E44
		public double GetEffectPowerValue()
		{
			return this.DodgeRate * this.HitRate * this.ReflectionRate;
		}

		// Token: 0x04002C47 RID: 11335
		public double ReflectionRate;

		// Token: 0x04002C48 RID: 11336
		public double HitRate;

		// Token: 0x04002C49 RID: 11337
		public double DodgeRate;
	}
}
