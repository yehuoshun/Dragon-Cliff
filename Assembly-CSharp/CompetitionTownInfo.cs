using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class CompetitionTownInfo : MonoBehaviour
{
	// Token: 0x06001833 RID: 6195 RVA: 0x000B9777 File Offset: 0x000B7B77
	public CompetitionTownInfo()
	{
	}

	// Token: 0x06001834 RID: 6196 RVA: 0x000B9780 File Offset: 0x000B7B80
	public void SetTownInfo(string townname, List<IBattleUnit> units)
	{
		this.TownName.text = townname;
		for (int i = 0; i < this.TeamMembers.Length; i++)
		{
			if (i < units.Count)
			{
				this.TeamMembers[i].SetATeamate(units[i]);
				this.TeamMembers[i].gameObject.SetActive(true);
			}
			else
			{
				this.TeamMembers[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x040017EC RID: 6124
	public TextMeshProUGUI TownName;

	// Token: 0x040017ED RID: 6125
	public CompetitionUITeamMember[] TeamMembers;
}
