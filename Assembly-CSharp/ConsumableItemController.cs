using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000325 RID: 805
public class ConsumableItemController : ItemControl
{
	// Token: 0x06001578 RID: 5496 RVA: 0x000AB3A8 File Offset: 0x000A97A8
	public ConsumableItemController()
	{
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x000AB3B0 File Offset: 0x000A97B0
	private void Start()
	{
		this.SelectionButton = base.GetComponent<Button>();
		this.SelectionButton.onClick.AddListener(new UnityAction(this.Selected));
		this.Deselect();
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x000AB3E0 File Offset: 0x000A97E0
	private void Selected()
	{
		this._control.SetConsumableToAdventure(this);
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x000AB3EE File Offset: 0x000A97EE
	public void Highlight()
	{
		base.Background.color = Color.green;
	}

	// Token: 0x0600157C RID: 5500 RVA: 0x000AB400 File Offset: 0x000A9800
	public void SetControl(AdventurerScrollList control)
	{
		this._control = control;
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x000AB409 File Offset: 0x000A9809
	public void Deselect()
	{
		base.Background.color = Color.white;
	}

	// Token: 0x04001590 RID: 5520
	private Button SelectionButton;

	// Token: 0x04001591 RID: 5521
	private AdventurerScrollList _control;
}
