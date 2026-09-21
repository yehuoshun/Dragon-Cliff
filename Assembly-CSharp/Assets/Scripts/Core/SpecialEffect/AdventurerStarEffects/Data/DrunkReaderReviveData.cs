using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000783 RID: 1923
	[Serializable]
	public class DrunkReaderReviveData : ISpecialEffectDataLoad
	{
		// Token: 0x060038CB RID: 14539 RVA: 0x00172AB9 File Offset: 0x00170EB9
		public DrunkReaderReviveData()
		{
		}

		// Token: 0x060038CC RID: 14540 RVA: 0x00172AC1 File Offset: 0x00170EC1
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.DrunkReaderRevive;
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x00172AC8 File Offset: 0x00170EC8
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038CE RID: 14542 RVA: 0x00172B03 File Offset: 0x00170F03
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038CF RID: 14543 RVA: 0x00172B06 File Offset: 0x00170F06
		public double GetEffectPowerValue()
		{
			return this.BoostRate;
		}

		// Token: 0x04002C4B RID: 11339
		public double BoostRate;
	}
}
