using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
public class ReverseSkillEffect : MonoBehaviour
{
	// Token: 0x06000774 RID: 1908 RVA: 0x0007172D File Offset: 0x0006FB2D
	public ReverseSkillEffect()
	{
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00071740 File Offset: 0x0006FB40
	private void Start()
	{
		this._endPos = CombatManager.Instance.GetSkillCastPoint().position;
		Vector3 position = base.transform.position;
		base.transform.position = position;
		this.Child.SetActive(true);
		this._flying = true;
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x00071790 File Offset: 0x0006FB90
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

	// Token: 0x06000777 RID: 1911 RVA: 0x00071815 File Offset: 0x0006FC15
	private void Explode()
	{
		this.Animator.Play("Back");
	}

	// Token: 0x04000A48 RID: 2632
	public GameObject SourceUnitEffect;

	// Token: 0x04000A49 RID: 2633
	public GameObject DestinationGameObject;

	// Token: 0x04000A4A RID: 2634
	private Vector3 _endPos;

	// Token: 0x04000A4B RID: 2635
	private bool _flying;

	// Token: 0x04000A4C RID: 2636
	private float _t;

	// Token: 0x04000A4D RID: 2637
	public GameObject Child;

	// Token: 0x04000A4E RID: 2638
	public Animator Animator;

	// Token: 0x04000A4F RID: 2639
	public float Speed = 1f;
}
