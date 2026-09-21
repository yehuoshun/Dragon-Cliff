using System;
using TMPro;
using UnityEngine;

// Token: 0x02000300 RID: 768
public class WorldMapDifficultyPanelController : MonoBehaviour
{
	// Token: 0x06001473 RID: 5235 RVA: 0x000A7321 File Offset: 0x000A5721
	public WorldMapDifficultyPanelController()
	{
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x000A732C File Offset: 0x000A572C
	private void Start()
	{
		int starRating = GameWorld.instance.PlayerProfile.GetStarRating();
		if (starRating != 1)
		{
			if (starRating == 2)
			{
				this.DifficultyLevelText.text = UIComponentType.DifficultyLevel2.GetName();
			}
		}
		else
		{
			this.DifficultyLevelText.text = UIComponentType.DifficultyLevel1.GetName();
		}
	}

	// Token: 0x040014A2 RID: 5282
	public TextMeshProUGUI DifficultyLevelText;
}
