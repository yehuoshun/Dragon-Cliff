using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001A0 RID: 416
public class AdventurerGroupTagController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B05 RID: 2821 RVA: 0x000841D1 File Offset: 0x000825D1
	public AdventurerGroupTagController()
	{
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x000841DC File Offset: 0x000825DC
	public void Init(AdventurerProfile adventurer)
	{
		List<BattleTeam> list = (from b in GameWorld.instance.PlayerProfile.GetBattleTeams()
		where b.Adventurers.Contains(adventurer)
		select b).ToList<BattleTeam>();
		this.GroupText.text = string.Empty;
		foreach (BattleTeam item in list)
		{
			TextMeshProUGUI groupText = this.GroupText;
			groupText.text += GameWorld.instance.PlayerProfile.GetBattleTeams().IndexOf(item) + 1;
		}
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x000842A4 File Offset: 0x000826A4
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenDescriptionTooltip(new TooltipItem
		{
			Description = UIComponentType.AdventurerGroupDescription.GetName(),
			Position = base.transform.position
		});
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x000842DF File Offset: 0x000826DF
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseDescriptionTooltip();
	}

	// Token: 0x04000DA0 RID: 3488
	public TextMeshProUGUI GroupText;

	// Token: 0x02000C28 RID: 3112
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x0600521D RID: 21021 RVA: 0x000842E7 File Offset: 0x000826E7
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600521E RID: 21022 RVA: 0x000842EF File Offset: 0x000826EF
		internal bool <>m__0(BattleTeam b)
		{
			return b.Adventurers.Contains(this.adventurer);
		}

		// Token: 0x0400401F RID: 16415
		internal AdventurerProfile adventurer;
	}
}
