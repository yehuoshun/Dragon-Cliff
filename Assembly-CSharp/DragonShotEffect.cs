using System;
using UnityEngine;

// Token: 0x0200038B RID: 907
public class DragonShotEffect : MonoBehaviour
{
	// Token: 0x0600184A RID: 6218 RVA: 0x000B9DD4 File Offset: 0x000B81D4
	public DragonShotEffect()
	{
	}

	// Token: 0x0600184B RID: 6219 RVA: 0x000B9DE8 File Offset: 0x000B81E8
	private void Start()
	{
		this._endPos = base.transform.position;
		this._animator = base.GetComponentInChildren<Animator>();
		this._child = this._animator.gameObject;
		Vector3 position = CombatManager.Instance.GetSkillCastPoint().position;
		base.transform.position = position;
		this._child.SetActive(true);
		this._flying = true;
	}

	// Token: 0x0600184C RID: 6220 RVA: 0x000B9E54 File Offset: 0x000B8254
	public void SetPos(bool isOnAdventureSide)
	{
		this._child.transform.position = ((!isOnAdventureSide) ? new Vector3(0f, 90f, 0f) : new Vector3(0f, -90f, 0f));
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000B9EA4 File Offset: 0x000B82A4
	private void Update()
	{
		if (this._flying)
		{
			this._t += Time.deltaTime * this.Speed;
			base.transform.position = Vector3.Lerp(base.transform.position, this._endPos, this._t);
			if (Vector3.Distance(base.transform.position, this._endPos) <= 0.1f)
			{
				this.Explode();
			}
		}
	}

	// Token: 0x0600184E RID: 6222 RVA: 0x000B9F22 File Offset: 0x000B8322
	private void Explode()
	{
	}

	// Token: 0x04001801 RID: 6145
	private Vector3 _endPos;

	// Token: 0x04001802 RID: 6146
	private bool _flying;

	// Token: 0x04001803 RID: 6147
	private float _t;

	// Token: 0x04001804 RID: 6148
	private GameObject _child;

	// Token: 0x04001805 RID: 6149
	private Animator _animator;

	// Token: 0x04001806 RID: 6150
	public float Speed = 1f;
}
