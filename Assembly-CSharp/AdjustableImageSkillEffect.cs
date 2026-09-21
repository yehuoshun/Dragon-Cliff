using System;
using UnityEngine;

// Token: 0x0200010B RID: 267
public class AdjustableImageSkillEffect : AdjustableImageEffectFx
{
	// Token: 0x06000766 RID: 1894 RVA: 0x000714C7 File Offset: 0x0006F8C7
	public AdjustableImageSkillEffect()
	{
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x000714DC File Offset: 0x0006F8DC
	public override void Start()
	{
		base.Start();
		this._endPos = base.transform.position;
		Vector3 position = CombatManager.Instance.GetSkillCastPoint().position;
		base.transform.position = position;
		this.Child.SetActive(true);
		this._flying = true;
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00071530 File Offset: 0x0006F930
	private void FixedUpdate()
	{
		if (this._flying)
		{
			this._t += Time.fixedDeltaTime * this.Speed;
			base.transform.position = Vector3.Lerp(base.transform.position, this._endPos, this._t);
			if (Vector3.Distance(base.transform.position, this._endPos) <= 0.1f)
			{
				this.Collided();
				this._flying = false;
			}
		}
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x000715B5 File Offset: 0x0006F9B5
	private void Collided()
	{
		this.Animator.Play("Collided");
		this.Animator.GetComponent<FX_AnimShakeCamera>().ShakeCamera();
	}

	// Token: 0x04000A3A RID: 2618
	private Vector3 _endPos;

	// Token: 0x04000A3B RID: 2619
	private bool _flying;

	// Token: 0x04000A3C RID: 2620
	private float _t;

	// Token: 0x04000A3D RID: 2621
	public GameObject Child;

	// Token: 0x04000A3E RID: 2622
	public Animator Animator;

	// Token: 0x04000A3F RID: 2623
	public float Speed = 1f;
}
