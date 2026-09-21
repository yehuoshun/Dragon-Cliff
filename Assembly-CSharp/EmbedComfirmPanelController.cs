using System;
using TMPro;
using UnityEngine;

// Token: 0x020001AF RID: 431
public class EmbedComfirmPanelController : MonoBehaviour
{
	// Token: 0x06000B54 RID: 2900 RVA: 0x00085B4B File Offset: 0x00083F4B
	public EmbedComfirmPanelController()
	{
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x00085B54 File Offset: 0x00083F54
	public void Init(string gemTitle, string equipmentTitle, QualityGrade equipmentGrade)
	{
		string content = UIComponentType.HeroMenuEmbedComfirmPanelDescription.GetName().ReplaceToBuilder(UIComponentKey.GemTitle, "[" + gemTitle + "]").ToString();
		Color gradeColor = FilePath.GetGradeColor(equipmentGrade);
		this.Description.text = content.ReplaceToBuilder(UIComponentKey.EquipmentTitle, ColorPicker.GetHaxString(gradeColor, equipmentTitle)).ToString();
	}

	// Token: 0x04000DD8 RID: 3544
	public TextMeshProUGUI Description;
}
