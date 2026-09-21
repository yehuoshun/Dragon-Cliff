using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000304 RID: 772
public class WorldMapHeroItemController : WorldMapDefualtHeroController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600148A RID: 5258 RVA: 0x000A7D2E File Offset: 0x000A612E
	public WorldMapHeroItemController()
	{
	}

	// Token: 0x0600148B RID: 5259 RVA: 0x000A7D38 File Offset: 0x000A6138
	public new void Init(AdventurerProfile profile, int index)
	{
		this.Reset();
		base.Init(profile, index);
		if (profile != null)
		{
			if (index == GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers.Count - 1)
			{
				this.SwitchButton.SetActive(false);
			}
			else
			{
				this.SwitchButton.SetActive(true);
			}
		}
	}

	// Token: 0x0600148C RID: 5260 RVA: 0x000A7D97 File Offset: 0x000A6197
	public void MoveRight()
	{
		base.GetComponentInParent<WorldMapController>().MoveHero(base.Index, base.Index + 1);
	}

	// Token: 0x0600148D RID: 5261 RVA: 0x000A7DB2 File Offset: 0x000A61B2
	public new void Reset()
	{
		this.SwitchButton.SetActive(false);
		base.Reset();
	}

	// Token: 0x0600148E RID: 5262 RVA: 0x000A7DC6 File Offset: 0x000A61C6
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			base.GetComponentInParent<WorldMapController>().OpenHeroConfiguePanel();
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			base.GetComponentInParent<WorldMapController>().DeselectHero(base.Index);
		}
	}

	// Token: 0x040014C7 RID: 5319
	public GameObject SwitchButton;
}
