using System;

// Token: 0x0200051D RID: 1309
[Serializable]
public class ResidentHappinessRecord
{
	// Token: 0x06002694 RID: 9876 RVA: 0x00113B16 File Offset: 0x00111F16
	public ResidentHappinessRecord()
	{
	}

	// Token: 0x06002695 RID: 9877 RVA: 0x00113B1E File Offset: 0x00111F1E
	public bool CanAddHappiness()
	{
		return !this.IsInCoolingDown;
	}

	// Token: 0x06002696 RID: 9878 RVA: 0x00113B2C File Offset: 0x00111F2C
	public void AddContribution(double value)
	{
		if (this.CanAddHappiness())
		{
			this.CurrentContributedValue += value * this.ToleranceRatio;
			if (this.CurrentContributedValue >= 100.0)
			{
				this.CurrentContributedValue = 100.0;
				this.IsInCoolingDown = true;
			}
		}
	}

	// Token: 0x06002697 RID: 9879 RVA: 0x00113B84 File Offset: 0x00111F84
	public void DailyCoolDownWhileERventActive()
	{
		if (this.IsInCoolingDown)
		{
			this.CurrentContributedValue -= 2.0;
			if (this.CurrentContributedValue <= 0.0)
			{
				this.CurrentContributedValue = 0.0;
				this.IsInCoolingDown = false;
			}
		}
	}

	// Token: 0x06002698 RID: 9880 RVA: 0x00113BDC File Offset: 0x00111FDC
	public void DailyCoolDownWhileERventInactive()
	{
		this.CurrentContributedValue -= 1.0;
		if (this.CurrentContributedValue <= 0.0)
		{
			this.CurrentContributedValue = 0.0;
			this.IsInCoolingDown = false;
		}
	}

	// Token: 0x040020E7 RID: 8423
	public TownEventType RelevantType;

	// Token: 0x040020E8 RID: 8424
	public double CurrentContributedValue;

	// Token: 0x040020E9 RID: 8425
	public bool IsInCoolingDown;

	// Token: 0x040020EA RID: 8426
	public double ToleranceRatio;
}
