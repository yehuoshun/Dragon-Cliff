using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001C5 RID: 453
public class HeroSkillPanelController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000C0F RID: 3087 RVA: 0x00088B8F File Offset: 0x00086F8F
	public HeroSkillPanelController()
	{
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x00088B98 File Offset: 0x00086F98
	public void Init()
	{
		if (base.GetComponentInParent<HeroMenuController>().SelectedHero == null)
		{
			return;
		}
		List<Skill> skills = base.GetComponentInParent<HeroMenuController>().SelectedHero.AdventurerProfile.GetSkills();
		List<Skill> list = (from s in skills
		where s.CommandType == SkillCommandType.Secondary
		select s).ToList<Skill>();
		Skill skill = list.FirstOrDefault((Skill s) => s.IsEnabled);
		IEnumerator enumerator = this.Container.GetEnumerator();
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
		foreach (Skill skill2 in list)
		{
			PassiveSkillItemController passiveSkillItemController = UnityEngine.Object.Instantiate<PassiveSkillItemController>(this.SkillItemPre);
			bool selected = skill != null && skill.SkillType == skill2.SkillType;
			passiveSkillItemController.Init(skill2, selected);
			passiveSkillItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x00088D08 File Offset: 0x00087108
	public void OnPointerClick(PointerEventData eventData)
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x00088D16 File Offset: 0x00087116
	[CompilerGenerated]
	private static bool <Init>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Secondary;
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x00088D21 File Offset: 0x00087121
	[CompilerGenerated]
	private static bool <Init>m__1(Skill s)
	{
		return s.IsEnabled;
	}

	// Token: 0x04000E6A RID: 3690
	public Transform Container;

	// Token: 0x04000E6B RID: 3691
	public PassiveSkillItemController SkillItemPre;

	// Token: 0x04000E6C RID: 3692
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x04000E6D RID: 3693
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache1;
}
