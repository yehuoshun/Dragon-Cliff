using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000100 RID: 256
public class SchoolBuildingController : MonoBehaviour
{
	// Token: 0x06000718 RID: 1816 RVA: 0x0006B38B File Offset: 0x0006978B
	public SchoolBuildingController()
	{
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000719 RID: 1817 RVA: 0x0006B393 File Offset: 0x00069793
	// (set) Token: 0x0600071A RID: 1818 RVA: 0x0006B39B File Offset: 0x0006979B
	public School School
	{
		[CompilerGenerated]
		get
		{
			return this.<School>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<School>k__BackingField = value;
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600071B RID: 1819 RVA: 0x0006B3A4 File Offset: 0x000697A4
	// (set) Token: 0x0600071C RID: 1820 RVA: 0x0006B3AC File Offset: 0x000697AC
	public List<SkillType> NewSills
	{
		[CompilerGenerated]
		get
		{
			return this.<NewSills>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NewSills>k__BackingField = value;
		}
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x0006B3B5 File Offset: 0x000697B5
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.D) && TownManager.Instance.Ui.CanUseHotKey())
		{
			this.OpenMenu();
		}
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x0006B3DD File Offset: 0x000697DD
	public void Init(School school)
	{
		this.School = school;
		this.NewSills = new List<SkillType>();
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x0006B3F1 File Offset: 0x000697F1
	public void ShowWidget(SkillType type)
	{
		this.NewSills.Add(type);
		this.NewSkillImage.sprite = FilePath.GetSkillIconImage(type);
		this.Widget.SetActive(true);
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0006B41C File Offset: 0x0006981C
	public void HideWidget()
	{
		this.Widget.SetActive(false);
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x0006B42A File Offset: 0x0006982A
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		this.OpenMenu();
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x0006B444 File Offset: 0x00069844
	private void OpenMenu()
	{
		TownManager.Instance.Ui.SchoolMenu.Init(this.School, this.NewSills);
		TownManager.Instance.Ui.OpenSchoolMenu();
		this.HideWidget();
		this.NewSills.Clear();
	}

	// Token: 0x04000A0C RID: 2572
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private School <School>k__BackingField;

	// Token: 0x04000A0D RID: 2573
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<SkillType> <NewSills>k__BackingField;

	// Token: 0x04000A0E RID: 2574
	public GameObject Widget;

	// Token: 0x04000A0F RID: 2575
	public Image NewSkillImage;
}
