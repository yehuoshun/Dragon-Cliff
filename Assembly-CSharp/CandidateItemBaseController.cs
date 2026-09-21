using System;
using UnityEngine.EventSystems;

// Token: 0x02000243 RID: 579
public class CandidateItemBaseController : ResidentItemBaseController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000F0A RID: 3850 RVA: 0x00093310 File Offset: 0x00091710
	public CandidateItemBaseController()
	{
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x00093318 File Offset: 0x00091718
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<ResidentMenuController>().ShowCandidateOperationPanel(base.Resident, base.transform.position);
	}
}
