using System;
using TMPro;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class QuestRequirementController : MonoBehaviour
{
	// Token: 0x06000EF0 RID: 3824 RVA: 0x00092843 File Offset: 0x00090C43
	public QuestRequirementController()
	{
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x0009284B File Offset: 0x00090C4B
	public void Init(bool completed, string description)
	{
		this.Tick.SetActive(completed);
		this.Description.text = description;
	}

	// Token: 0x04001056 RID: 4182
	public GameObject Tick;

	// Token: 0x04001057 RID: 4183
	public TextMeshProUGUI Description;
}
