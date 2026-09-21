using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000347 RID: 839
public class BattleChestRewardController : MonoBehaviour
{
	// Token: 0x06001670 RID: 5744 RVA: 0x000B076A File Offset: 0x000AEB6A
	public BattleChestRewardController()
	{
	}

	// Token: 0x06001671 RID: 5745 RVA: 0x000B077D File Offset: 0x000AEB7D
	public void Init(Chest chest)
	{
		this.Sprite.sprite = FilePath.GetRewardInChestImage(chest.Grade);
	}

	// Token: 0x06001672 RID: 5746 RVA: 0x000B0798 File Offset: 0x000AEB98
	public void PopReward()
	{
		this._speed = UnityEngine.Random.Range(-this.HorizontalSpeed, this.HorizontalSpeed);
		this._animationTime = this.Animator.runtimeAnimatorController.animationClips.First((AnimationClip x) => x.name == "Popup").length;
		this._t = 0f;
		this.Animator.SetTrigger("Pop");
		this.Sprite.sortingOrder = 2;
		this.Sprite.gameObject.SetActive(true);
	}

	// Token: 0x06001673 RID: 5747 RVA: 0x000B0832 File Offset: 0x000AEC32
	public void Reset()
	{
		this.Sprite.sortingOrder = 0;
		this.Animator.SetTrigger("Reset");
		this.Sprite.gameObject.SetActive(false);
	}

	// Token: 0x06001674 RID: 5748 RVA: 0x000B0861 File Offset: 0x000AEC61
	public void ShowReward()
	{
		this.Sprite.gameObject.SetActive(true);
	}

	// Token: 0x06001675 RID: 5749 RVA: 0x000B0874 File Offset: 0x000AEC74
	private void Update()
	{
		this._t += Time.deltaTime;
		if (this._t <= this._animationTime)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this._speed);
		}
	}

	// Token: 0x06001676 RID: 5750 RVA: 0x000B08C9 File Offset: 0x000AECC9
	[CompilerGenerated]
	private static bool <PopReward>m__0(AnimationClip x)
	{
		return x.name == "Popup";
	}

	// Token: 0x04001685 RID: 5765
	public SpriteRenderer Sprite;

	// Token: 0x04001686 RID: 5766
	public Animator Animator;

	// Token: 0x04001687 RID: 5767
	public float HorizontalSpeed = 2f;

	// Token: 0x04001688 RID: 5768
	private float _animationTime;

	// Token: 0x04001689 RID: 5769
	private float _speed;

	// Token: 0x0400168A RID: 5770
	private float _t;

	// Token: 0x0400168B RID: 5771
	[CompilerGenerated]
	private static Func<AnimationClip, bool> <>f__am$cache0;
}
