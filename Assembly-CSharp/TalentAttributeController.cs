using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001D9 RID: 473
public class TalentAttributeController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000CB7 RID: 3255 RVA: 0x0008B0D4 File Offset: 0x000894D4
	public TalentAttributeController()
	{
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x0008B0DC File Offset: 0x000894DC
	public void Init(IAdventurerTalent talent, AdventurerProfile adventurer)
	{
		this._talent = talent;
		this.Icon.sprite = FilePath.GetAdventurerTalentIcon(talent.GetCorrespondingType());
		int currentLevel = talent.GetCurrentLevel();
		bool talentIsAvailable = talent.IsAvaliable(adventurer);
		this.LevelText.text = currentLevel + "/" + talent.GetMaxLevel();
		this.Cover.SetActive(!talentIsAvailable);
		this.AllButtons.ForEach(delegate(Button b)
		{
			b.interactable = talentIsAvailable;
		});
		if (!talentIsAvailable && currentLevel > 0)
		{
			this.Cover.SetActive(false);
		}
		this.LevelText.color = ((currentLevel <= 0) ? Color.white : Color.green);
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x0008B1B0 File Offset: 0x000895B0
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._talent == null)
		{
			return;
		}
		Description description = this._talent.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = ColorPicker.ReplaceSkillTag(description.Details1),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x0008B21C File Offset: 0x0008961C
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x0008B224 File Offset: 0x00089624
	public void UpgradeTalent()
	{
		if (this._talent == null)
		{
			return;
		}
		base.GetComponentInParent<HeroMenuController>().UpgradeTalent(this._talent);
	}

	// Token: 0x04000ECF RID: 3791
	public Image Icon;

	// Token: 0x04000ED0 RID: 3792
	public TextMeshProUGUI LevelText;

	// Token: 0x04000ED1 RID: 3793
	public GameObject Cover;

	// Token: 0x04000ED2 RID: 3794
	public List<Button> AllButtons;

	// Token: 0x04000ED3 RID: 3795
	private IAdventurerTalent _talent;

	// Token: 0x02000C39 RID: 3129
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x0600524B RID: 21067 RVA: 0x0008B243 File Offset: 0x00089643
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600524C RID: 21068 RVA: 0x0008B24B File Offset: 0x0008964B
		internal void <>m__0(Button b)
		{
			b.interactable = this.talentIsAvailable;
		}

		// Token: 0x04004042 RID: 16450
		internal bool talentIsAvailable;
	}
}
