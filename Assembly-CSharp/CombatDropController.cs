using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200011C RID: 284
public class CombatDropController : MonoBehaviour
{
	// Token: 0x060007BD RID: 1981 RVA: 0x00072354 File Offset: 0x00070754
	public CombatDropController()
	{
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x00072368 File Offset: 0x00070768
	private void Start()
	{
		this._speed = UnityEngine.Random.Range(-this.HorizontalSpeed, this.HorizontalSpeed);
		this._animationTime = base.GetComponent<Animator>().runtimeAnimatorController.animationClips.First((AnimationClip x) => x.name == "Drop").length;
		this._t = 0f;
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000723D8 File Offset: 0x000707D8
	private void Update()
	{
		this._t += Time.deltaTime;
		if (this._t <= this._animationTime)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this._speed);
		}
		if (this._readyToBeCollected)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this._collectPoint, this._collectSpeed * Time.deltaTime);
			if (Vector3.Distance(base.transform.position, this._collectPoint) <= 0.1f)
			{
				this._readyToBeCollected = false;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x00072497 File Offset: 0x00070897
	public void Init(ResourceUpdate resource)
	{
		this.Sprite.sprite = FilePath.GetRecipeImage(resource.ResourceType);
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000724AF File Offset: 0x000708AF
	public void ToBeCollected(Vector3 collectPoint, float collectSpeed)
	{
		this._collectPoint = collectPoint;
		this._collectSpeed = collectSpeed;
		this._readyToBeCollected = true;
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000724C6 File Offset: 0x000708C6
	[CompilerGenerated]
	private static bool <Start>m__0(AnimationClip x)
	{
		return x.name == "Drop";
	}

	// Token: 0x04000A94 RID: 2708
	public SpriteRenderer Sprite;

	// Token: 0x04000A95 RID: 2709
	public float HorizontalSpeed = 2f;

	// Token: 0x04000A96 RID: 2710
	private float _animationTime;

	// Token: 0x04000A97 RID: 2711
	private float _speed;

	// Token: 0x04000A98 RID: 2712
	private float _t;

	// Token: 0x04000A99 RID: 2713
	private bool _readyToBeCollected;

	// Token: 0x04000A9A RID: 2714
	private Vector3 _collectPoint;

	// Token: 0x04000A9B RID: 2715
	private float _collectSpeed;

	// Token: 0x04000A9C RID: 2716
	[CompilerGenerated]
	private static Func<AnimationClip, bool> <>f__am$cache0;
}
