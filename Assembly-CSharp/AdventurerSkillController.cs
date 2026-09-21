using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200031F RID: 799
public class AdventurerSkillController : SkillIconController
{
	// Token: 0x06001544 RID: 5444 RVA: 0x000AA2C0 File Offset: 0x000A86C0
	public AdventurerSkillController()
	{
	}

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x06001545 RID: 5445 RVA: 0x000AA2C8 File Offset: 0x000A86C8
	// (set) Token: 0x06001546 RID: 5446 RVA: 0x000AA2D0 File Offset: 0x000A86D0
	public AdventurerProfile AdventurerProfile
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerProfile>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdventurerProfile>k__BackingField = value;
		}
	}

	// Token: 0x06001547 RID: 5447 RVA: 0x000AA2DC File Offset: 0x000A86DC
	public void Awake()
	{
		this._skillImage = base.transform.GetChild(0).GetComponentInChildren<Image>();
		this._backgroundImage = base.GetComponent<Image>();
		this._button = base.GetComponent<Button>();
		if (this._button != null)
		{
			this._button.onClick.AddListener(new UnityAction(this.ClickedOnSkill));
		}
		base.Start();
	}

	// Token: 0x06001548 RID: 5448 RVA: 0x000AA34B File Offset: 0x000A874B
	public void SetAdventurerProfile(AdventurerProfile profile, Skill skill)
	{
		this.AdventurerProfile = profile;
		base.Skill = skill;
		this._skillImage.sprite = FilePath.GetSkillIconImage(base.Skill.SkillType);
		this.BackgroundImageCheck();
	}

	// Token: 0x06001549 RID: 5449 RVA: 0x000AA37C File Offset: 0x000A877C
	public void SetController(AdventurerSkillManager manager)
	{
		this._manager = manager;
	}

	// Token: 0x0600154A RID: 5450 RVA: 0x000AA388 File Offset: 0x000A8788
	public void BackgroundImageCheck()
	{
		if (base.Skill != null)
		{
			this._backgroundImage.color = ((!base.Skill.IsEnabled) ? Color.white : Color.green);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600154B RID: 5451 RVA: 0x000AA3DB File Offset: 0x000A87DB
	private void ClickedOnSkill()
	{
		this.AdventurerProfile.DirectlyEnableSkill(base.Skill);
		this._manager.RecheckBackgroundColor();
	}

	// Token: 0x04001559 RID: 5465
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <AdventurerProfile>k__BackingField;

	// Token: 0x0400155A RID: 5466
	private Button _button;

	// Token: 0x0400155B RID: 5467
	private Image _skillImage;

	// Token: 0x0400155C RID: 5468
	private Image _backgroundImage;

	// Token: 0x0400155D RID: 5469
	private AdventurerSkillManager _manager;
}
