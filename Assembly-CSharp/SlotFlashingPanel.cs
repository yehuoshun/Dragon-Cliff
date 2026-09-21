using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000291 RID: 657
public class SlotFlashingPanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600118D RID: 4493 RVA: 0x0009BB14 File Offset: 0x00099F14
	public SlotFlashingPanel()
	{
	}

	// Token: 0x0600118E RID: 4494 RVA: 0x0009BB1C File Offset: 0x00099F1C
	private void Start()
	{
		this._image = base.GetComponent<Image>();
		this._originalColor = this._image.color;
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x0009BB3B File Offset: 0x00099F3B
	private void Update()
	{
		if (this._isActive)
		{
			this._image.color = Color.Lerp(this._originalColor, ColorPicker.Transparent, Mathf.PingPong(Time.time, 1f));
		}
	}

	// Token: 0x06001190 RID: 4496 RVA: 0x0009BB72 File Offset: 0x00099F72
	public void Flash()
	{
		this._isActive = true;
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x0009BB7B File Offset: 0x00099F7B
	public void StopFlashing()
	{
		this._isActive = false;
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x0009BB84 File Offset: 0x00099F84
	public void OnPointerClick(PointerEventData eventData)
	{
		SlotPanelsController.Instance.SelectSlot(this.Slot);
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x0009BB96 File Offset: 0x00099F96
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.StopFlashing();
		this._image.color = this.MouseOverColor;
		this.Pointer.SetActive(true);
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x0009BBBB File Offset: 0x00099FBB
	public void OnPointerExit(PointerEventData eventData)
	{
		this.Flash();
		this.Pointer.SetActive(false);
	}

	// Token: 0x04001264 RID: 4708
	public TownSlot Slot;

	// Token: 0x04001265 RID: 4709
	public Color MouseOverColor;

	// Token: 0x04001266 RID: 4710
	public GameObject Pointer;

	// Token: 0x04001267 RID: 4711
	private bool _isActive;

	// Token: 0x04001268 RID: 4712
	private Image _image;

	// Token: 0x04001269 RID: 4713
	private Color _originalColor;
}
