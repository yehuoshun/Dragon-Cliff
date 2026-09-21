using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002A4 RID: 676
public class BoatManController : MonoBehaviour
{
	// Token: 0x06001231 RID: 4657 RVA: 0x0009D56D File Offset: 0x0009B96D
	public BoatManController()
	{
	}

	// Token: 0x06001232 RID: 4658 RVA: 0x0009D575 File Offset: 0x0009B975
	public void ShowNewBoatText()
	{
		this.NewBoatTextObj.SetActive(true);
		this.Animator.SetBool("Available", true);
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x0009D594 File Offset: 0x0009B994
	public void HideNewBoatText()
	{
		this.NewBoatTextObj.SetActive(false);
		this.Animator.SetBool("Available", false);
	}

	// Token: 0x06001234 RID: 4660 RVA: 0x0009D5B3 File Offset: 0x0009B9B3
	public void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		TownManager.Instance.Ui.OpenBuildShipMenu();
	}

	// Token: 0x040012FA RID: 4858
	public GameObject NewBoatTextObj;

	// Token: 0x040012FB RID: 4859
	public Animator Animator;
}
