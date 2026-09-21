using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class GenericAdventurerAnimations : MonoBehaviour
{
	// Token: 0x0600156B RID: 5483 RVA: 0x000AAD32 File Offset: 0x000A9132
	public GenericAdventurerAnimations()
	{
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x000AAD3A File Offset: 0x000A913A
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
		this.PlayIdle();
	}

	// Token: 0x0600156D RID: 5485 RVA: 0x000AAD4E File Offset: 0x000A914E
	public void PlayIdle()
	{
		if (this._animator == null)
		{
			return;
		}
		this.Laugh(false);
		this.Nod(false);
		this.Shake(false);
		this.Shock(false);
		this.Stand(0, 0);
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x000AAD86 File Offset: 0x000A9186
	public void WalkEast()
	{
		this.Move(1, 0);
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x000AAD90 File Offset: 0x000A9190
	public void FaceEast()
	{
		this.Stand(1, 0);
	}

	// Token: 0x06001570 RID: 5488 RVA: 0x000AAD9A File Offset: 0x000A919A
	public void FaceSouth()
	{
		this.Stand(0, -1);
	}

	// Token: 0x06001571 RID: 5489 RVA: 0x000AADA4 File Offset: 0x000A91A4
	public void WalkSouth()
	{
		this.Move(0, -1);
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x000AADAE File Offset: 0x000A91AE
	public void Laugh(bool isLaughing)
	{
		this._animator.SetBool("IsLaughing", isLaughing);
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x000AADC1 File Offset: 0x000A91C1
	public void Nod(bool isNodding)
	{
		this._animator.SetBool("Agree", isNodding);
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x000AADD4 File Offset: 0x000A91D4
	public void Shake(bool isShaking)
	{
		this._animator.SetBool("Disagree", isShaking);
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x000AADE7 File Offset: 0x000A91E7
	public void Shock(bool isShocked)
	{
		this._animator.SetBool("Shocking", isShocked);
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x000AADFA File Offset: 0x000A91FA
	public void Move(int xValue, int yValue)
	{
		this._animator.SetBool("IsMoving", true);
		this._animator.SetFloat("MoveX", (float)xValue);
		this._animator.SetFloat("MoveY", (float)yValue);
	}

	// Token: 0x06001577 RID: 5495 RVA: 0x000AAE31 File Offset: 0x000A9231
	public void Stand(int xValue, int yValue)
	{
		this._animator.SetBool("IsMoving", false);
		this._animator.SetFloat("LastMoveX", (float)xValue);
		this._animator.SetFloat("LastMoveY", (float)yValue);
	}

	// Token: 0x0400158F RID: 5519
	private Animator _animator;
}
