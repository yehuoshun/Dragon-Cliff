using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200022C RID: 556
public class PageResidentController : PageCharacterController
{
	// Token: 0x06000E76 RID: 3702 RVA: 0x00091565 File Offset: 0x0008F965
	public PageResidentController()
	{
	}

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x06000E77 RID: 3703 RVA: 0x0009156D File Offset: 0x0008F96D
	// (set) Token: 0x06000E78 RID: 3704 RVA: 0x0009158D File Offset: 0x0008F98D
	protected ResidentMenuController ResidentMenu
	{
		get
		{
			if (this._residentMenu == null)
			{
				return base.GetComponentInParent<ResidentMenuController>();
			}
			return this._residentMenu;
		}
		set
		{
			this._residentMenu = value;
		}
	}

	// Token: 0x1700008D RID: 141
	// (get) Token: 0x06000E79 RID: 3705 RVA: 0x00091596 File Offset: 0x0008F996
	// (set) Token: 0x06000E7A RID: 3706 RVA: 0x0009159E File Offset: 0x0008F99E
	public PageResident PageResident
	{
		[CompilerGenerated]
		get
		{
			return this.<PageResident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PageResident>k__BackingField = value;
		}
	}

	// Token: 0x06000E7B RID: 3707 RVA: 0x000915A8 File Offset: 0x0008F9A8
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.PageResident = (PageResident)item;
		ResidentType type = this.PageResident.Resident.Type;
		this.NameText.text = type.GetDescription().Title;
		this.LevelText.text = this.PageResident.Resident.Level.ToLevelText();
		CharacterBasicAppearance residentAppearence = FilePath.GetResidentAppearence(type);
		this.AvatarImage.sprite = residentAppearence.GetStandSprite();
		this.GradeFrame.sprite = FilePath.GetAdventurerGradeBackground(this.PageResident.Resident.Grade, false);
		this.ResetEffectContainer();
		foreach (IResidentEffect effect in this.PageResident.Resident.Effects)
		{
			ResidentEffectIconController residentEffectIconController = UnityEngine.Object.Instantiate<ResidentEffectIconController>(this.EffectIconPre);
			residentEffectIconController.Init(effect);
			residentEffectIconController.transform.SetParent(this.EffectContainer, false);
		}
	}

	// Token: 0x06000E7C RID: 3708 RVA: 0x000916C8 File Offset: 0x0008FAC8
	private void ResetEffectContainer()
	{
		IEnumerator enumerator = this.EffectContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x0400100A RID: 4106
	public Image AvatarImage;

	// Token: 0x0400100B RID: 4107
	public Image GradeFrame;

	// Token: 0x0400100C RID: 4108
	public TextMeshProUGUI NameText;

	// Token: 0x0400100D RID: 4109
	public TextMeshProUGUI LevelText;

	// Token: 0x0400100E RID: 4110
	public Transform EffectContainer;

	// Token: 0x0400100F RID: 4111
	public ResidentEffectIconController EffectIconPre;

	// Token: 0x04001010 RID: 4112
	protected ResidentMenuController _residentMenu;

	// Token: 0x04001011 RID: 4113
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageResident <PageResident>k__BackingField;
}
