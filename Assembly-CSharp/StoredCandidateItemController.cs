using System;
using UnityEngine.EventSystems;

// Token: 0x02000251 RID: 593
public class StoredCandidateItemController : ResidentItemBaseController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000F6A RID: 3946 RVA: 0x00094774 File Offset: 0x00092B74
	public StoredCandidateItemController()
	{
	}

	// Token: 0x06000F6B RID: 3947 RVA: 0x0009477C File Offset: 0x00092B7C
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<ResidentMenuController>().ShowStoredCandidateOperationPanel(base.Resident, base.transform.position);
	}
}
