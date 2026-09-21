using System;
using UnityEngine;

// Token: 0x0200010D RID: 269
public class BothDirectionEffectController : MonoBehaviour
{
	// Token: 0x0600076D RID: 1901 RVA: 0x0007163F File Offset: 0x0006FA3F
	public BothDirectionEffectController()
	{
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00071654 File Offset: 0x0006FA54
	public void FixedUpdate()
	{
		if (this._flying)
		{
			this._t += Time.fixedDeltaTime * this.Speed;
			base.transform.position = Vector3.Lerp(base.transform.position, this._endPos, this._t);
			if (Vector3.Distance(base.transform.position, this._endPos) <= 0.1f)
			{
				this._flying = false;
			}
		}
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x000716D3 File Offset: 0x0006FAD3
	public void SetCasterTransform(Transform damageUnitTransform, Transform casterTrans)
	{
		this._endPos = (this.isInReverse ? casterTrans.position : base.transform.position);
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x000716FC File Offset: 0x0006FAFC
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x0007170A File Offset: 0x0006FB0A
	public void BackFire()
	{
		this._animator.Play("Back");
		this._flying = true;
	}

	// Token: 0x04000A42 RID: 2626
	private Vector3 _endPos;

	// Token: 0x04000A43 RID: 2627
	private bool _flying;

	// Token: 0x04000A44 RID: 2628
	private float _t;

	// Token: 0x04000A45 RID: 2629
	public bool isInReverse;

	// Token: 0x04000A46 RID: 2630
	public float Speed = 1f;

	// Token: 0x04000A47 RID: 2631
	private Animator _animator;
}
