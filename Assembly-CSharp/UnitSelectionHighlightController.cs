using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class UnitSelectionHighlightController : MonoBehaviour
{
	// Token: 0x0600169B RID: 5787 RVA: 0x000B1FC2 File Offset: 0x000B03C2
	public UnitSelectionHighlightController()
	{
	}

	// Token: 0x0600169C RID: 5788 RVA: 0x000B1FCA File Offset: 0x000B03CA
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
		this._animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		this._renderer = base.GetComponent<SpriteRenderer>();
		this.Deselected();
	}

	// Token: 0x0600169D RID: 5789 RVA: 0x000B1FF8 File Offset: 0x000B03F8
	private void Update()
	{
		if (this._isSelected)
		{
			Transform transform = base.gameObject.transform.parent.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				if (gameObject.activeSelf && gameObject.name != "GroundLight" && gameObject.name != "EffectColor" && gameObject.name != "Weapon" && gameObject.name != "SelectionHighlight" && gameObject.name != "Target" && gameObject.name != "NewTarget(Clone)")
				{
					this._renderer.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
				}
			}
		}
	}

	// Token: 0x0600169E RID: 5790 RVA: 0x000B20E9 File Offset: 0x000B04E9
	public void Selected()
	{
		if (this._animator == null)
		{
			this.Awake();
		}
		this._animator.SetBool("isSelected", true);
		this._isSelected = true;
	}

	// Token: 0x0600169F RID: 5791 RVA: 0x000B211A File Offset: 0x000B051A
	public void Deselected()
	{
		if (this._animator == null)
		{
			this.Awake();
		}
		this._animator.SetBool("isSelected", false);
		this._isSelected = false;
	}

	// Token: 0x060016A0 RID: 5792 RVA: 0x000B214B File Offset: 0x000B054B
	private void OnDisable()
	{
		this.Deselected();
	}

	// Token: 0x040016AC RID: 5804
	private Animator _animator;

	// Token: 0x040016AD RID: 5805
	private SpriteRenderer _renderer;

	// Token: 0x040016AE RID: 5806
	private bool _isSelected;
}
