using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000788 RID: 1928
	[Serializable]
	public class FireAssassinStarImmuneData : ISpecialEffectDataLoad
	{
		// Token: 0x060038E5 RID: 14565 RVA: 0x00172D26 File Offset: 0x00171126
		public FireAssassinStarImmuneData()
		{
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x00172D2E File Offset: 0x0017112E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FireAssassinStarImmune;
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x00172D38 File Offset: 0x00171138
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{number}", this.NumberOfShields.ToString());
			return description;
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x00172D8E File Offset: 0x0017118E
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038E9 RID: 14569 RVA: 0x00172D91 File Offset: 0x00171191
		public double GetEffectPowerValue()
		{
			return this.Chance * (double)this.NumberOfShields;
		}

		// Token: 0x04002C54 RID: 11348
		public double Chance;

		// Token: 0x04002C55 RID: 11349
		public int NumberOfShields;
	}
}
