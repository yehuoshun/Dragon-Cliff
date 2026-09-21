using System;
using UnityEngine;

// Token: 0x02000102 RID: 258
public class AdventurerCombatAnimator : MonoBehaviour
{
	// Token: 0x0600072C RID: 1836 RVA: 0x0006B558 File Offset: 0x00069958
	public AdventurerCombatAnimator()
	{
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x0006B560 File Offset: 0x00069960
	private void Awake()
	{
		this._animator = base.GetComponentInChildren<Animator>();
		this._animator.updateMode = AnimatorUpdateMode.Normal;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x0006B57A File Offset: 0x0006997A
	public void WalkEastWithWeapon()
	{
		this.ChangeAnimationState(AdventurerAnimationState.WalkEastWithWeapon);
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x0006B583 File Offset: 0x00069983
	public void WalkWestWithWeapon()
	{
		this.ChangeAnimationState(AdventurerAnimationState.WalkWestWithWeapon);
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x0006B58C File Offset: 0x0006998C
	public void StandEastWithWeapon()
	{
		this.ChangeAnimationState(AdventurerAnimationState.StandEastWithWeapon);
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x0006B595 File Offset: 0x00069995
	public void IdleInCombat()
	{
		this.ChangeAnimationState(AdventurerAnimationState.InCombat);
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x0006B59E File Offset: 0x0006999E
	public void Attack()
	{
		this._animator.SetTrigger("Attack");
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x0006B5B0 File Offset: 0x000699B0
	public void CastSkill()
	{
		this._animator.SetTrigger("CastSkill");
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x0006B5C2 File Offset: 0x000699C2
	public void Hurt()
	{
		this._animator.SetTrigger("Hurt");
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x0006B5D4 File Offset: 0x000699D4
	private void WalkDir(float dir)
	{
		this._animator.SetFloat("WalkDir", dir);
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x0006B5E7 File Offset: 0x000699E7
	private void StandDir(float dir)
	{
		this._animator.SetFloat("StandDir", dir);
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x0006B5FA File Offset: 0x000699FA
	private void Walk(bool isWalking)
	{
		this._animator.SetBool("IsWalking", isWalking);
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x0006B60D File Offset: 0x00069A0D
	private void WalkEastWithWeapon(bool isDoing)
	{
		this._animator.SetBool("WalkEastWithWeapon", isDoing);
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x0006B620 File Offset: 0x00069A20
	private void WalkWestWithWeapon(bool isDoing)
	{
		this._animator.SetBool("WalkWestWithWeapon", isDoing);
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x0006B633 File Offset: 0x00069A33
	private void StandEastWithWeapon(bool isDoing)
	{
		this._animator.SetBool("StandEastWithWeapon", isDoing);
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x0006B646 File Offset: 0x00069A46
	private void StandWestWithWeapon(bool isDoing)
	{
		this._animator.SetBool("StandWestWithWeapon", isDoing);
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x0006B65C File Offset: 0x00069A5C
	private void ChangeAnimationState(AdventurerAnimationState state)
	{
		this._animator.SetBool("WalkEastWithWeapon", state == AdventurerAnimationState.WalkEastWithWeapon);
		this._animator.SetBool("WalkWestWithWeapon", state == AdventurerAnimationState.WalkWestWithWeapon);
		this._animator.SetBool("StandEastWithWeapon", state == AdventurerAnimationState.StandEastWithWeapon);
		this._animator.SetBool("StandWestWithWeapon", state == AdventurerAnimationState.StandWestWithWeapon);
		this._animator.SetBool("InCombat", state == AdventurerAnimationState.InCombat);
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x0006B6CD File Offset: 0x00069ACD
	private void InCombat(bool isInCombat)
	{
		this._animator.SetBool("InCombat", isInCombat);
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x0006B6E0 File Offset: 0x00069AE0
	public void SetTargetSelectionState(bool isTargeted)
	{
		this._animator.SetBool("isTargeted", isTargeted);
	}

	// Token: 0x04000A12 RID: 2578
	private Animator _animator;
}
