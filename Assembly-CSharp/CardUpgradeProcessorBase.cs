using System;
using UnityEngine;

// Token: 0x02000B3F RID: 2879
public abstract class CardUpgradeProcessorBase : IPresentable
{
	// Token: 0x06004C97 RID: 19607 RVA: 0x001F2182 File Offset: 0x001F0582
	protected CardUpgradeProcessorBase()
	{
	}

	// Token: 0x17001080 RID: 4224
	// (get) Token: 0x06004C98 RID: 19608
	public abstract UpgradeCardType UpgradeType { get; }

	// Token: 0x06004C99 RID: 19609
	public abstract int GetPresence();

	// Token: 0x06004C9A RID: 19610
	protected abstract bool AdditionalAvaliablityCheck(AdventurerProfile profile);

	// Token: 0x06004C9B RID: 19611 RVA: 0x001F218A File Offset: 0x001F058A
	public bool IsAvaliable(AdventurerProfile profile)
	{
		return this.AdditionalAvaliablityCheck(profile);
	}

	// Token: 0x06004C9C RID: 19612
	public abstract CardUpgrade Create(AdventurerProfile profile, int? rerollLevel);

	// Token: 0x06004C9D RID: 19613
	public abstract void Select(AdventurerProfile profile, CardUpgrade upgrade);

	// Token: 0x06004C9E RID: 19614
	public abstract void DeSelect(AdventurerProfile profile, CardUpgrade upgrade);

	// Token: 0x06004C9F RID: 19615 RVA: 0x001F2194 File Offset: 0x001F0594
	protected double GetRandomValueForBoost(double qualityCoefficient, double fromValue, double toValue)
	{
		double num = qualityCoefficient;
		if (num > 2.0)
		{
			num = 2.0;
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		num /= 2.0;
		double num2 = (toValue - fromValue) * (double)Convert.ToSingle(num) + fromValue;
		return num2 * (double)UnityEngine.Random.Range(0.8f, 1f);
	}
}
