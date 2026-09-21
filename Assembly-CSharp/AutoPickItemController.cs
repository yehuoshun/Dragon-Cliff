using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002DD RID: 733
public class AutoPickItemController : MonoBehaviour
{
	// Token: 0x06001378 RID: 4984 RVA: 0x000A357A File Offset: 0x000A197A
	public AutoPickItemController()
	{
	}

	// Token: 0x06001379 RID: 4985 RVA: 0x000A3584 File Offset: 0x000A1984
	private string GetGradeKey()
	{
		string result = string.Empty;
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
		return result;
	}

	// Token: 0x04001400 RID: 5120
	public QualityGrade ItemGrade;

	// Token: 0x04001401 RID: 5121
	public Toggle AutoSellToggle;
}
