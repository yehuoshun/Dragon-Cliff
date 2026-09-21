using System;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000789 RID: 1929
	[Serializable]
	public class FireChargerDoTBlastData : ISpecialEffectDataLoad
	{
		// Token: 0x060038EA RID: 14570 RVA: 0x00172DA1 File Offset: 0x001711A1
		public FireChargerDoTBlastData()
		{
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x00172DA9 File Offset: 0x001711A9
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FireChargerDoTBlast;
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x00172DB0 File Offset: 0x001711B0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{rate}", this.AdditionalDamage.ToExpressionMultiply100()).Replace("{max}", this.MaxDamage.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x00172E15 File Offset: 0x00171215
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x00172E18 File Offset: 0x00171218
		public double GetEffectPowerValue()
		{
			return this.Chance * this.AdditionalDamage * this.MaxDamage;
		}

		// Token: 0x04002C56 RID: 11350
		public double Chance;

		// Token: 0x04002C57 RID: 11351
		public double AdditionalDamage;

		// Token: 0x04002C58 RID: 11352
		public double MaxDamage;
	}
}
