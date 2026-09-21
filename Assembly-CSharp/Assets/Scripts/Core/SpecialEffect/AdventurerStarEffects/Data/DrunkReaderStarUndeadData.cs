using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000784 RID: 1924
	[Serializable]
	public class DrunkReaderStarUndeadData : ISpecialEffectDataLoad
	{
		// Token: 0x060038D0 RID: 14544 RVA: 0x00172B0E File Offset: 0x00170F0E
		public DrunkReaderStarUndeadData()
		{
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x00172B16 File Offset: 0x00170F16
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.DrunkReaderStarUndead;
		}

		// Token: 0x060038D2 RID: 14546 RVA: 0x00172B20 File Offset: 0x00170F20
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{revive}", this.RevivieRate.ToExpressionMultiply100()).Replace("{cost}", this.Cost.ToString());
			return description;
		}

		// Token: 0x060038D3 RID: 14547 RVA: 0x00172B8B File Offset: 0x00170F8B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038D4 RID: 14548 RVA: 0x00172B8E File Offset: 0x00170F8E
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x04002C4C RID: 11340
		public double Chance;

		// Token: 0x04002C4D RID: 11341
		public double RevivieRate;

		// Token: 0x04002C4E RID: 11342
		public int Cost;

		// Token: 0x04002C4F RID: 11343
		[NonSerialized]
		public bool IsInTrigger;
	}
}
