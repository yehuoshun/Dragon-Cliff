using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
public class SeaShipController : MonoBehaviour
{
	// Token: 0x0600124B RID: 4683 RVA: 0x0009DBCB File Offset: 0x0009BFCB
	public SeaShipController()
	{
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x0009DBD3 File Offset: 0x0009BFD3
	public void Init(Vehicle vehicle)
	{
		this._vehicle = vehicle;
		this.Renderer.sprite = FilePath.GetVehicleSprite(vehicle.Type);
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x0009DBF2 File Offset: 0x0009BFF2
	public void StartJourneyAnim()
	{
		this.Animator.SetTrigger("GoTrip");
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x0009DC04 File Offset: 0x0009C004
	public void IdleAnim()
	{
		this.Animator.SetTrigger("ComeBack");
	}

	// Token: 0x04001312 RID: 4882
	public SpriteRenderer Renderer;

	// Token: 0x04001313 RID: 4883
	public Animator Animator;

	// Token: 0x04001314 RID: 4884
	private Vehicle _vehicle;
}
