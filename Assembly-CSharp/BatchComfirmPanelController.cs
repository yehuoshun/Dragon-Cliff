using System;
using TMPro;
using UnityEngine;

// Token: 0x020001A4 RID: 420
public class BatchComfirmPanelController : MonoBehaviour
{
	// Token: 0x06000B1E RID: 2846 RVA: 0x00084758 File Offset: 0x00082B58
	public BatchComfirmPanelController()
	{
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x00084760 File Offset: 0x00082B60
	public void Init(string batchTitle, string equipmentTitle, QualityGrade equipmentGrade)
	{
		string content = UIComponentType.HeroMenuBatchComfirmPanelDescription.GetName().ReplaceToBuilder(UIComponentKey.BatcherTitle, "[" + batchTitle + "]").ToString();
		Color gradeColor = FilePath.GetGradeColor(equipmentGrade);
		this.Description.text = content.ReplaceToBuilder(UIComponentKey.EquipmentTitle, ColorPicker.GetHaxString(gradeColor, equipmentTitle)).ToString();
	}

	// Token: 0x04000DAA RID: 3498
	public TextMeshProUGUI Description;
}
