using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002BD RID: 701
public class AutoSellListItem : MonoBehaviour
{
	// Token: 0x060012C5 RID: 4805 RVA: 0x0009FEC4 File Offset: 0x0009E2C4
	public AutoSellListItem()
	{
	}

	// Token: 0x060012C6 RID: 4806 RVA: 0x0009FECC File Offset: 0x0009E2CC
	private void OnEnable()
	{
		string gradeKey = this.GetGradeKey();
		if (!string.IsNullOrEmpty(gradeKey))
		{
			AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
			if (additionalData.ContainsBool(gradeKey))
			{
				this.AutoSellToggle.isOn = additionalData.GetBool(gradeKey);
			}
			else
			{
				this.AutoSellToggle.isOn = false;
			}
		}
		else
		{
			this.AutoSellToggle.isOn = false;
		}
	}

	// Token: 0x060012C7 RID: 4807 RVA: 0x0009FF3C File Offset: 0x0009E33C
	public void ToggleClick()
	{
		string gradeKey = this.GetGradeKey();
		if (!string.IsNullOrEmpty(gradeKey))
		{
			AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
			additionalData.AddOrUpdateData(gradeKey, this.AutoSellToggle.isOn);
		}
	}

	// Token: 0x060012C8 RID: 4808 RVA: 0x0009FF80 File Offset: 0x0009E380
	private string GetGradeKey()
	{
		string result = string.Empty;
		if (this.IsWeapon)
		{
			switch (this.ItemGrade)
			{
			case QualityGrade.Normal:
				result = UIAdditionalDataKey.WeaponGradeNormal;
				break;
			case QualityGrade.Rare:
				result = UIAdditionalDataKey.WeaponGradeRare;
				break;
			case QualityGrade.Epic:
				result = UIAdditionalDataKey.WeaponGradeEpic;
				break;
			case QualityGrade.Legendary:
				result = UIAdditionalDataKey.WeaponGradeLegendary;
				break;
			case QualityGrade.Ancient:
				result = UIAdditionalDataKey.WeaponGradeAncient;
				break;
			}
		}
		else
		{
			switch (this.ItemGrade)
			{
			case QualityGrade.Normal:
				result = UIAdditionalDataKey.ArmorGradeNormal;
				break;
			case QualityGrade.Rare:
				result = UIAdditionalDataKey.ArmorGradeRare;
				break;
			case QualityGrade.Epic:
				result = UIAdditionalDataKey.ArmorGradeEpic;
				break;
			case QualityGrade.Legendary:
				result = UIAdditionalDataKey.ArmorGradeLegendary;
				break;
			case QualityGrade.Ancient:
				result = UIAdditionalDataKey.ArmorGradeAncient;
				break;
			}
		}
		return result;
	}

	// Token: 0x04001370 RID: 4976
	public QualityGrade ItemGrade;

	// Token: 0x04001371 RID: 4977
	public bool IsWeapon;

	// Token: 0x04001372 RID: 4978
	public Toggle AutoSellToggle;
}
