using System;
using UnityEngine;

// Token: 0x02000114 RID: 276
public class AdventurerUIAnimation : MonoBehaviour
{
	// Token: 0x06000784 RID: 1924 RVA: 0x00071953 File Offset: 0x0006FD53
	public AdventurerUIAnimation()
	{
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x0007195B File Offset: 0x0006FD5B
	public void Init(FixedAdventurerAnimation fixedAnim)
	{
		this._fixedAnim = fixedAnim;
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x00071964 File Offset: 0x0006FD64
	private void Awake()
	{
		this._animator = base.GetComponentInChildren<Animator>();
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x00071974 File Offset: 0x0006FD74
	private void Update()
	{
		if (!this._isAnimating)
		{
			switch (this._fixedAnim)
			{
			case FixedAdventurerAnimation.None:
				break;
			case FixedAdventurerAnimation.Happy:
				this.PlayLaught();
				break;
			case FixedAdventurerAnimation.Walk:
				this.PlayWalk();
				break;
			case FixedAdventurerAnimation.Idle:
				this.PlayIdle();
				break;
			case FixedAdventurerAnimation.WalkRight:
				this.PlayWalkRight();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x000719E9 File Offset: 0x0006FDE9
	public void PlayIdle()
	{
		this._animator.SetBool("isLaughing", false);
		this._animator.SetBool("isWalking", false);
		this._animator.SetBool("isRunning", false);
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x00071A1E File Offset: 0x0006FE1E
	public void PlayLaught()
	{
		this._animator.SetBool("isLaughing", true);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00071A31 File Offset: 0x0006FE31
	public void StopLaught()
	{
		this._animator.SetBool("isLaughing", false);
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x00071A44 File Offset: 0x0006FE44
	public void PlayWalk()
	{
		this._animator.SetBool("isWalking", true);
		this._animator.SetFloat("walkDir", 1f);
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x00071A6C File Offset: 0x0006FE6C
	public void PlayWalkRight()
	{
		this._animator.SetBool("isWalking", true);
		this._animator.SetFloat("walkDir", 2f);
	}

	// Token: 0x04000A73 RID: 2675
	private Animator _animator;

	// Token: 0x04000A74 RID: 2676
	private bool _isAnimating;

	// Token: 0x04000A75 RID: 2677
	private FixedAdventurerAnimation _fixedAnim;
}
