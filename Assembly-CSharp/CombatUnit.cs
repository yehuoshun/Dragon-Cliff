using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
public class CombatUnit : MonoBehaviour
{
	// Token: 0x060007E8 RID: 2024 RVA: 0x0006B6F3 File Offset: 0x00069AF3
	public CombatUnit()
	{
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x0006B6FB File Offset: 0x00069AFB
	public void InitStandPoint(StandSlotPoints point)
	{
		this._standPoint = point;
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x0006B704 File Offset: 0x00069B04
	public StandSlotPoints GetStandPoint()
	{
		return this._standPoint;
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x0006B70C File Offset: 0x00069B0C
	public Transform CreateEeffect(GameObject effectObj, bool isCompetition = false)
	{
		return CombatManager.Instance.CombatPointsController.CreateEffect(effectObj, this._standPoint);
	}

	// Token: 0x04000AC3 RID: 2755
	private StandSlotPoints _standPoint;
}
