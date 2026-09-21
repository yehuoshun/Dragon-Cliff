using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200077F RID: 1919
	[Serializable]
	public class BurningHeartEnhancementData : ISpecialEffectDataLoad
	{
		// Token: 0x060038B7 RID: 14519 RVA: 0x00172926 File Offset: 0x00170D26
		public BurningHeartEnhancementData()
		{
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x0017292E File Offset: 0x00170D2E
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.BurningHeartEnhancement;
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x00172938 File Offset: 0x00170D38
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{extra}", this.ExtraTarget.ToString()).Replace("{rate}", this.HitReduction.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x0017298E File Offset: 0x00170D8E
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x00172991 File Offset: 0x00170D91
		public double GetEffectPowerValue()
		{
			return (double)this.ExtraTarget * this.HitReduction;
		}

		// Token: 0x04002C45 RID: 11333
		public int ExtraTarget;

		// Token: 0x04002C46 RID: 11334
		public double HitReduction;
	}
}
