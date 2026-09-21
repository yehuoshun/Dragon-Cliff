using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000320 RID: 800
public class AdventurerSkillManager : MonoBehaviour
{
	// Token: 0x0600154C RID: 5452 RVA: 0x000AA3F9 File Offset: 0x000A87F9
	public AdventurerSkillManager()
	{
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x000AA40C File Offset: 0x000A880C
	private void Start()
	{
		this.Deselect();
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x000AA414 File Offset: 0x000A8814
	private void Deselect()
	{
		foreach (AdventurerSkillController adventurerSkillController in this.PrimarySkills)
		{
			adventurerSkillController.gameObject.SetActive(false);
		}
		this._currentOnDisplay = null;
		this.AdventurerName.text = string.Empty;
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x000AA464 File Offset: 0x000A8864
	public void UpdateCapacity()
	{
		AdventurerProfile adventurerProfile = this._currentOnDisplay.GetAdventurerProfile();
		this.AdventurerName.text = adventurerProfile.UnitClass.GetDescription().Title;
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x000AA498 File Offset: 0x000A8898
	public void SetAdventurer(AdventurerObj adventurer)
	{
		if (this._currentOnDisplay != adventurer)
		{
			if (this._currentOnDisplay != null)
			{
				this._currentOnDisplay.NotOnSkillDisplay();
			}
			adventurer.OnSkillDisplay();
			this._currentOnDisplay = adventurer;
			AdventurerProfile adventurerProfile = this._currentOnDisplay.GetAdventurerProfile();
			List<Skill> skills = adventurerProfile.GetSkills();
			List<Skill> list = (from s in skills
			where s.CommandType == SkillCommandType.Main
			select s).ToList<Skill>();
			List<Skill> list2 = (from s in skills
			where s.CommandType == SkillCommandType.Secondary
			select s).ToList<Skill>();
			this.UpdateCapacity();
			for (int i = 0; i < this.PrimarySkills.Length; i++)
			{
				GameObject gameObject = this.PrimarySkills[i].gameObject;
				if (i < list.Count)
				{
					gameObject.gameObject.SetActive(true);
					this.SkillControllerSetup(gameObject, skills[i], adventurerProfile);
				}
				else
				{
					gameObject.gameObject.SetActive(false);
				}
			}
			this._secondarySkillControls.ForEach(delegate(AdventurerSkillController s)
			{
				s.gameObject.SetActive(false);
			});
			for (int j = 0; j < list2.Count; j++)
			{
				if (j < this._secondarySkillControls.Count)
				{
					this._secondarySkillControls[j].gameObject.SetActive(true);
					this.SkillControllerSetup(this._secondarySkillControls[j].gameObject, list2[j], adventurerProfile);
				}
				else
				{
					GameObject obj = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/SelectionList/SkillManagement/SkillIcon") as GameObject, this.SecondarySkillPanel.transform.position, this.SecondarySkillPanel);
					AdventurerSkillController item = this.SkillControllerSetup(obj, list2[j], adventurerProfile);
					this._secondarySkillControls.Add(item);
				}
			}
		}
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x000AA698 File Offset: 0x000A8A98
	private AdventurerSkillController SkillControllerSetup(GameObject obj, Skill skill, AdventurerProfile profile)
	{
		if (obj == null)
		{
			return null;
		}
		AdventurerSkillController component = obj.GetComponent<AdventurerSkillController>();
		component.SetAdventurerProfile(profile, skill);
		component.SetController(this);
		obj.transform.localScale = Vector3.one;
		return component;
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x000AA6DC File Offset: 0x000A8ADC
	public void RecheckBackgroundColor()
	{
		foreach (AdventurerSkillController adventurerSkillController in this.PrimarySkills)
		{
			adventurerSkillController.BackgroundImageCheck();
		}
		this._secondarySkillControls.ForEach(delegate(AdventurerSkillController s)
		{
			s.BackgroundImageCheck();
		});
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x000AA736 File Offset: 0x000A8B36
	[CompilerGenerated]
	private static bool <SetAdventurer>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Main;
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x000AA741 File Offset: 0x000A8B41
	[CompilerGenerated]
	private static bool <SetAdventurer>m__1(Skill s)
	{
		return s.CommandType == SkillCommandType.Secondary;
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x000AA74C File Offset: 0x000A8B4C
	[CompilerGenerated]
	private static void <SetAdventurer>m__2(AdventurerSkillController s)
	{
		s.gameObject.SetActive(false);
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x000AA75A File Offset: 0x000A8B5A
	[CompilerGenerated]
	private static void <RecheckBackgroundColor>m__3(AdventurerSkillController s)
	{
		s.BackgroundImageCheck();
	}

	// Token: 0x0400155E RID: 5470
	public AdventurerSkillController[] PrimarySkills;

	// Token: 0x0400155F RID: 5471
	public Text AdventurerName;

	// Token: 0x04001560 RID: 5472
	public GameObject SecondarySkillPanel;

	// Token: 0x04001561 RID: 5473
	private AdventurerObj _currentOnDisplay;

	// Token: 0x04001562 RID: 5474
	private readonly List<AdventurerSkillController> _secondarySkillControls = new List<AdventurerSkillController>();

	// Token: 0x04001563 RID: 5475
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x04001564 RID: 5476
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache1;

	// Token: 0x04001565 RID: 5477
	[CompilerGenerated]
	private static Action<AdventurerSkillController> <>f__am$cache2;

	// Token: 0x04001566 RID: 5478
	[CompilerGenerated]
	private static Action<AdventurerSkillController> <>f__am$cache3;
}
