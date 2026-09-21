using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class UnitTargetObj : MonoBehaviour
{
	// Token: 0x0600182B RID: 6187 RVA: 0x000B96C4 File Offset: 0x000B7AC4
	public UnitTargetObj()
	{
	}

	// Token: 0x0600182C RID: 6188 RVA: 0x000B96CC File Offset: 0x000B7ACC
	public void SetIsFriendlyUnit(bool isFriendlyUnit)
	{
		foreach (SpriteRenderer spriteRenderer in this._sprites)
		{
			spriteRenderer.sprite = FilePath.GetTargetSprite(isFriendlyUnit);
		}
	}

	// Token: 0x0600182D RID: 6189 RVA: 0x000B9704 File Offset: 0x000B7B04
	public void IsHovering(bool isHovering)
	{
		this._animator.SetBool("isHovering", isHovering);
	}

	// Token: 0x040017E9 RID: 6121
	public SpriteRenderer[] _sprites;

	// Token: 0x040017EA RID: 6122
	public Animator _animator;
}
