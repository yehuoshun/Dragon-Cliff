using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class InstantVelocity : MonoBehaviour, IWalkingBattleUnit
{
	// Token: 0x0600179E RID: 6046 RVA: 0x000B6867 File Offset: 0x000B4C67
	public InstantVelocity()
	{
	}

	// Token: 0x0600179F RID: 6047 RVA: 0x000B6876 File Offset: 0x000B4C76
	private void Start()
	{
		this._animator = base.GetComponentInChildren<Animator>();
		this._healthBar = base.GetComponentInChildren<CombatUnitHealthController>();
		if (this._animator.GetComponent<global::AnimationEvent>() != null)
		{
			this._animator.Play("idle_1");
		}
	}

	// Token: 0x060017A0 RID: 6048 RVA: 0x000B68B6 File Offset: 0x000B4CB6
	public void SetSpeed(float backgroundSpeed)
	{
		this._speed = backgroundSpeed;
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x000B68BF File Offset: 0x000B4CBF
	private void FixedUpdate()
	{
		if (this._isWalking)
		{
			base.transform.Translate(new Vector3(this._speed * Time.fixedDeltaTime * -1f, 0f, 0f), Space.Self);
		}
	}

	// Token: 0x060017A2 RID: 6050 RVA: 0x000B68F9 File Offset: 0x000B4CF9
	public void EncountersPlayer()
	{
		this.StopMoving();
	}

	// Token: 0x060017A3 RID: 6051 RVA: 0x000B6901 File Offset: 0x000B4D01
	public void StopMoving()
	{
		this.SetHealthBarActiveStatus(true);
		this._isWalking = false;
	}

	// Token: 0x060017A4 RID: 6052 RVA: 0x000B6911 File Offset: 0x000B4D11
	public void ContinueMoving()
	{
		this.SetHealthBarActiveStatus(false);
		this._isWalking = true;
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x000B6921 File Offset: 0x000B4D21
	public void Finish()
	{
		if (base.isActiveAndEnabled)
		{
			GameObjectUtil.RecycleDestroy(base.gameObject);
		}
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x000B6939 File Offset: 0x000B4D39
	private void SetHealthBarActiveStatus(bool status)
	{
		if (this._healthBar != null)
		{
			this._healthBar.ResetHealth(status);
		}
	}

	// Token: 0x04001787 RID: 6023
	private bool _isWalking = true;

	// Token: 0x04001788 RID: 6024
	private Animator _animator;

	// Token: 0x04001789 RID: 6025
	private float _speed;

	// Token: 0x0400178A RID: 6026
	private CombatUnitHealthController _healthBar;
}
