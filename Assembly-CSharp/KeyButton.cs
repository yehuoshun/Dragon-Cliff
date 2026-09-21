using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200027C RID: 636
[RequireComponent(typeof(Button))]
public class KeyButton : MonoBehaviour
{
	// Token: 0x060010D0 RID: 4304 RVA: 0x00098876 File Offset: 0x00096C76
	public KeyButton()
	{
	}

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0009887E File Offset: 0x00096C7E
	// (set) Token: 0x060010D2 RID: 4306 RVA: 0x00098886 File Offset: 0x00096C86
	public Button Button
	{
		[CompilerGenerated]
		get
		{
			return this.<Button>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Button>k__BackingField = value;
		}
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x0009888F File Offset: 0x00096C8F
	private void Awake()
	{
		this.Button = base.GetComponent<Button>();
		this._targetGraphic = base.GetComponent<Graphic>();
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x000988A9 File Offset: 0x00096CA9
	private void Start()
	{
	}

	// Token: 0x060010D5 RID: 4309 RVA: 0x000988AC File Offset: 0x00096CAC
	private void Update()
	{
		if (Input.GetKeyDown(this.Key) && ((this.IsBattleComponent && !TownManager.Instance.Ui.IsInTown) || !this.IsBattleComponent) && !TownManager.Instance.Ui.IsUsingInput())
		{
			this.Down();
		}
		else if (Input.GetKeyUp(this.Key) && ((this.IsBattleComponent && !TownManager.Instance.Ui.IsInTown) || (!this.IsBattleComponent && TownManager.Instance.Ui.IsInTown)) && !TownManager.Instance.Ui.IsUsingInput())
		{
			this.Up();
			this.Button.onClick.Invoke();
			this.CloseTooltip();
		}
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x00098990 File Offset: 0x00096D90
	private void Up()
	{
		this.StartColorTween(this.Button.colors.normalColor, false);
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x000989B8 File Offset: 0x00096DB8
	private void Down()
	{
		this.StartColorTween(this.Button.colors.pressedColor, false);
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x000989E0 File Offset: 0x00096DE0
	private void StartColorTween(Color targetColor, bool instant)
	{
		if (this._targetGraphic == null)
		{
			return;
		}
		this._targetGraphic.CrossFadeColor(targetColor, (!instant) ? this.Button.colors.fadeDuration : 0f, true, true);
	}

	// Token: 0x040011E1 RID: 4577
	public KeyCode Key;

	// Token: 0x040011E2 RID: 4578
	public bool IsBattleComponent;

	// Token: 0x040011E3 RID: 4579
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button <Button>k__BackingField;

	// Token: 0x040011E4 RID: 4580
	private Graphic _targetGraphic;

	// Token: 0x040011E5 RID: 4581
	private Color _normalColor;
}
