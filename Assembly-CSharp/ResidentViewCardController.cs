using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000250 RID: 592
public class ResidentViewCardController : MonoBehaviour
{
	// Token: 0x06000F66 RID: 3942 RVA: 0x000931D2 File Offset: 0x000915D2
	public ResidentViewCardController()
	{
	}

	// Token: 0x17000099 RID: 153
	// (get) Token: 0x06000F67 RID: 3943 RVA: 0x000931DA File Offset: 0x000915DA
	// (set) Token: 0x06000F68 RID: 3944 RVA: 0x000931E2 File Offset: 0x000915E2
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x06000F69 RID: 3945 RVA: 0x000931EC File Offset: 0x000915EC
	public void Init(Resident resident)
	{
		this.Resident = resident;
		this.ResidentTitleText.text = resident.Type.GetDescription().Title;
		string text = string.Empty;
		foreach (IResidentEffect effect in resident.Effects)
		{
			text = text + effect.GetDescription().Details1 + "\n";
		}
		this.ResidentDescription.text = text;
		this.ResidentAvatar.sprite = FilePath.GetResidentAppearence(resident.Type).GetStandSprite();
		Sprite residentGradeGem = FilePath.GetResidentGradeGem(resident.Grade);
		if (residentGradeGem == null)
		{
			this.GradeImage.color = ColorPicker.Transparent;
		}
		else
		{
			this.GradeImage.color = ColorPicker.White;
			this.GradeImage.sprite = residentGradeGem;
		}
	}

	// Token: 0x040010B3 RID: 4275
	public TextMeshProUGUI ResidentTitleText;

	// Token: 0x040010B4 RID: 4276
	public TextMeshProUGUI ResidentDescription;

	// Token: 0x040010B5 RID: 4277
	public Image ResidentAvatar;

	// Token: 0x040010B6 RID: 4278
	public Image GradeImage;

	// Token: 0x040010B7 RID: 4279
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;
}
