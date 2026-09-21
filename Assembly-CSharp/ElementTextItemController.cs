using System;
using TMPro;
using UnityEngine;

// Token: 0x020001AE RID: 430
public class ElementTextItemController : MonoBehaviour
{
	// Token: 0x06000B52 RID: 2898 RVA: 0x00085A4C File Offset: 0x00083E4C
	public ElementTextItemController()
	{
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x00085A54 File Offset: 0x00083E54
	public void Init(AdventurerProfile selectedHero)
	{
		Description description = this.Type.GetDescription();
		this.Description.text = "<b>" + description.Title.ToColor(ColorPicker.GetOutputTypeColor(this.Type)) + "</b>";
		if (selectedHero == null)
		{
			this.Description.text = string.Empty;
		}
		else
		{
			bool flag = selectedHero.GetLevel() >= 30;
			if (flag)
			{
				TextMeshProUGUI description2 = this.Description;
				description2.text = description2.text + ": " + description.Details1;
			}
			else
			{
				TextMeshProUGUI description3 = this.Description;
				description3.text += string.Concat(new string[]
				{
					": ",
					description.Details1,
					" (",
					UIComponentType.ElementUnlockLevel.GetName(),
					")"
				}).ToColor(ColorPicker.Grey);
			}
		}
	}

	// Token: 0x04000DD6 RID: 3542
	public TextMeshProUGUI Description;

	// Token: 0x04000DD7 RID: 3543
	public OutputType Type;
}
