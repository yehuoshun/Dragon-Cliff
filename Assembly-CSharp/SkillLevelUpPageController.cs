using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000290 RID: 656
public class SkillLevelUpPageController : MonoBehaviour
{
	// Token: 0x0600118A RID: 4490 RVA: 0x0009B9C7 File Offset: 0x00099DC7
	public SkillLevelUpPageController()
	{
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x0009B9D0 File Offset: 0x00099DD0
	public void UpdatePage(SLUTextItem item)
	{
		if (item.Adventurer != null)
		{
			this.Reset();
			AdventurerUIAnimation component = GameObjectCreator.CreateUiHero(item.Adventurer, this.HeroContainer).GetComponent<AdventurerUIAnimation>();
			UnityEngine.Object.Destroy(component.GetComponent<Button>());
			UnityEngine.Object.Destroy(component.GetComponent<AdventurerUIController>());
			component.Init(FixedAdventurerAnimation.Happy);
			this.SkillIcon1.sprite = FilePath.GetSkillIconImage(item.Skill.SkillType);
			this.SkillIcon2.sprite = FilePath.GetSkillIconImage(item.Skill.SkillType);
			this.PreviousLevelText.text = "Lv " + item.PreivousLevel;
			this.NewLevelText.text = "Lv " + item.NewLevel;
			return;
		}
		throw new Exception("Adventrurer is empty, please check initialization.");
	}

	// Token: 0x0600118C RID: 4492 RVA: 0x0009BAA8 File Offset: 0x00099EA8
	private void Reset()
	{
		IEnumerator enumerator = this.HeroContainer.GetEnumerator();
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

	// Token: 0x0400125F RID: 4703
	public Transform HeroContainer;

	// Token: 0x04001260 RID: 4704
	public Image SkillIcon1;

	// Token: 0x04001261 RID: 4705
	public Image SkillIcon2;

	// Token: 0x04001262 RID: 4706
	public Text PreviousLevelText;

	// Token: 0x04001263 RID: 4707
	public Text NewLevelText;
}
