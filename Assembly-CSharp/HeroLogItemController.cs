using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001BE RID: 446
public class HeroLogItemController : MonoBehaviour
{
	// Token: 0x06000BA1 RID: 2977 RVA: 0x00087320 File Offset: 0x00085720
	public HeroLogItemController()
	{
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x00087328 File Offset: 0x00085728
	public void Init(UnitClass unit, bool isUnlocked)
	{
		this.HeroTitle.text = ((!isUnlocked) ? "???" : unit.GetDescription().Title);
		this.HeroImage.sprite = FilePath.GetCharacterBasicAppearance(unit, false).GetStandSprite();
		this.HeroImage.color = ((!isUnlocked) ? Color.black : Color.white);
		if (isUnlocked)
		{
			AdventurerUnitConfigurationBase adventurerUnitConfigurationBase = unit.GetConfiguration() as AdventurerUnitConfigurationBase;
			this.PrimarySkill.Init(adventurerUnitConfigurationBase.DefaultPrimarySkill.CreatePlayerSkill());
			this.ActiveSkill.Init(adventurerUnitConfigurationBase.DefaultActiveSkills[0].CreatePlayerSkill());
			this.PrimarySkill.gameObject.SetActive(true);
			this.ActiveSkill.gameObject.SetActive(true);
		}
		else
		{
			this.PrimarySkill.gameObject.SetActive(false);
			this.ActiveSkill.gameObject.SetActive(false);
		}
	}

	// Token: 0x04000E19 RID: 3609
	public TextMeshProUGUI HeroTitle;

	// Token: 0x04000E1A RID: 3610
	public Image HeroImage;

	// Token: 0x04000E1B RID: 3611
	public LogSkillIconController PrimarySkill;

	// Token: 0x04000E1C RID: 3612
	public LogSkillIconController ActiveSkill;
}
