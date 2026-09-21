using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
public class FireballEffectController : MonoBehaviour
{
	// Token: 0x060008CD RID: 2253 RVA: 0x00078381 File Offset: 0x00076781
	public FireballEffectController()
	{
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00078394 File Offset: 0x00076794
	private void Start()
	{
		this._endPos = base.transform.position;
		Vector3 position = CombatManager.Instance.GetSkillCastPoint().position;
		base.transform.position = position;
		this.Child.SetActive(true);
		this._flying = true;
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000783E4 File Offset: 0x000767E4
	public void FixedUpdate()
	{
		if (this._flying)
		{
			this._t += Time.fixedDeltaTime * this.Speed;
			base.transform.position = Vector3.Lerp(base.transform.position, this._endPos, this._t);
			if (Vector3.Distance(base.transform.position, this._endPos) <= 0.1f)
			{
				this.Explode();
				this._flying = false;
			}
		}
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x00078469 File Offset: 0x00076869
	private void Explode()
	{
		this.Animator.Play("Explode");
	}

	// Token: 0x04000B54 RID: 2900
	private Vector3 _endPos;

	// Token: 0x04000B55 RID: 2901
	private bool _flying;

	// Token: 0x04000B56 RID: 2902
	private float _t;

	// Token: 0x04000B57 RID: 2903
	public GameObject Child;

	// Token: 0x04000B58 RID: 2904
	public Animator Animator;

	// Token: 0x04000B59 RID: 2905
	public float Speed = 1f;
}
