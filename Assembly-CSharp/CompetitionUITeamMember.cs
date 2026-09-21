using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000384 RID: 900
public class CompetitionUITeamMember : MonoBehaviour
{
	// Token: 0x06001835 RID: 6197 RVA: 0x000B97FD File Offset: 0x000B7BFD
	public CompetitionUITeamMember()
	{
	}

	// Token: 0x06001836 RID: 6198 RVA: 0x000B9808 File Offset: 0x000B7C08
	public void SetATeamate(IBattleUnit unit)
	{
		this.AdventurerName.text = unit.GetUnitType().GetDescription().Title;
		this.AdventurerGrade.sprite = FilePath.GetAdventurerGradeBackground(unit.Grade, false);
		this.Avatar.sprite = FilePath.GetAdventuererAvatarSprite(unit.GetUnitType());
		this.Points.text = "战斗点数: " + unit.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value.ToExpression();
	}

	// Token: 0x040017EE RID: 6126
	public Image Avatar;

	// Token: 0x040017EF RID: 6127
	public Image AdventurerGrade;

	// Token: 0x040017F0 RID: 6128
	public TextMeshProUGUI Points;

	// Token: 0x040017F1 RID: 6129
	public TextMeshProUGUI AdventurerName;
}
