using System;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class AdventurerEffectColorController : MonoBehaviour
{
	// Token: 0x06000751 RID: 1873 RVA: 0x00070C20 File Offset: 0x0006F020
	public AdventurerEffectColorController()
	{
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x00070C28 File Offset: 0x0006F028
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
		this._FX_Color = base.GetComponent<_2dxFX_Color>();
		this._sprite = base.GetComponent<SpriteRenderer>();
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x00070C4E File Offset: 0x0006F04E
	public void PlayHealed()
	{
		this._FX_Color._Alpha = 0.558f;
		this._sprite.sortingLayerName = "CharacterWeapons";
		this._animator.SetTrigger("Heal");
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x00070C80 File Offset: 0x0006F080
	public void PlayHurt()
	{
		this._FX_Color._Alpha = 0.558f;
		this._sprite.sortingLayerName = "Characters";
		this._animator.SetTrigger("Hurt");
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x00070CB2 File Offset: 0x0006F0B2
	private void OnEnable()
	{
		this._sprite.sortingLayerName = "CharacterWeapons";
		this._sprite.gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
	}

	// Token: 0x04000A1E RID: 2590
	private Animator _animator;

	// Token: 0x04000A1F RID: 2591
	private _2dxFX_Color _FX_Color;

	// Token: 0x04000A20 RID: 2592
	private SpriteRenderer _sprite;
}
