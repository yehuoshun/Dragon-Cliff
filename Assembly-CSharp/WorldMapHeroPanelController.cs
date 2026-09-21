using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class WorldMapHeroPanelController : MonoBehaviour
{
	// Token: 0x0600148F RID: 5263 RVA: 0x000A7DFB File Offset: 0x000A61FB
	public WorldMapHeroPanelController()
	{
	}

	// Token: 0x06001490 RID: 5264 RVA: 0x000A7E04 File Offset: 0x000A6204
	public void Init(AdventurerProfile[] heros, bool showFiveHeros = false)
	{
		foreach (WorldMapHeroItemController worldMapHeroItemController in this.Avatars)
		{
			worldMapHeroItemController.Reset();
		}
		for (int i = 0; i < heros.Length; i++)
		{
			if (heros[i] != null)
			{
				this.Avatars[i].Init(heros[i], i);
			}
		}
		foreach (GameObject gameObject in this.AdvanceAvatarObj)
		{
			gameObject.SetActive(showFiveHeros);
		}
	}

	// Token: 0x040014C8 RID: 5320
	public List<GameObject> AdvanceAvatarObj;

	// Token: 0x040014C9 RID: 5321
	public List<WorldMapHeroItemController> Avatars;
}
