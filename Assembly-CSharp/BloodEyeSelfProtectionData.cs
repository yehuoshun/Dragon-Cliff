using System;

// Token: 0x020007BE RID: 1982
[Serializable]
public class BloodEyeSelfProtectionData : ISpecialEffectDataLoad
{
	// Token: 0x060039F7 RID: 14839 RVA: 0x001773C2 File Offset: 0x001757C2
	public BloodEyeSelfProtectionData()
	{
	}

	// Token: 0x060039F8 RID: 14840 RVA: 0x001773CA File Offset: 0x001757CA
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x060039F9 RID: 14841 RVA: 0x001773EA File Offset: 0x001757EA
	public double GetEffectPowerValue()
	{
		return this.HealPerGhost;
	}

	// Token: 0x060039FA RID: 14842 RVA: 0x001773F2 File Offset: 0x001757F2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BloodEyeSelfProtectionEffect;
	}

	// Token: 0x060039FB RID: 14843 RVA: 0x001773F8 File Offset: 0x001757F8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{seconds}", this.GhostLastingSeconds.FloatToString()).Replace("{healvalue}", this.HealPerGhost.DoubleToString()).ToString();
		return description;
	}

	// Token: 0x04002CCE RID: 11470
	public double HealPerGhost;

	// Token: 0x04002CCF RID: 11471
	public float GhostLastingSeconds;

	// Token: 0x04002CD0 RID: 11472
	public int MaxNumberOfGhostsPerTarget;

	// Token: 0x04002CD1 RID: 11473
	public bool? IsStarEf;
}
