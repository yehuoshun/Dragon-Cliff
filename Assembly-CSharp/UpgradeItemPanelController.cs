using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001DD RID: 477
public class UpgradeItemPanelController : MonoBehaviour
{
	// Token: 0x06000CC8 RID: 3272 RVA: 0x0008BD55 File Offset: 0x0008A155
	public UpgradeItemPanelController()
	{
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x0008BD60 File Offset: 0x0008A160
	public void Init(Item item)
	{
		this._item = item;
		this.ItemController.Init(item.ConvertToUiNormalItem());
		this.Description.text = string.Empty;
		this.SuccessRateText.text = UIComponentType.SuccessRate.GetName().ReplaceToBuilder(UIComponentKey.Amount, item.GetTeamSetUpgradeSuccessChance().ToExpressionMultiply100() + "%").ToString();
		IEnumerator enumerator = this.RequirementContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		List<ResourceConsumptionRequirement> list = item.TeamSetUpgradeRequirements();
		foreach (ResourceConsumptionRequirement requirement in list)
		{
			ShipResourceItemController shipResourceItemController = UnityEngine.Object.Instantiate<ShipResourceItemController>(this.RequirementItem);
			shipResourceItemController.Init(requirement);
			shipResourceItemController.transform.SetParent(this.RequirementContainer, false);
		}
		this.UpgradeButton.interactable = item.CanTeamSetUpgrade();
		this.UpgradeMaxButton.interactable = item.CanTeamSetUpgrade();
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x0008BEC0 File Offset: 0x0008A2C0
	private void OnDisable()
	{
		this._item = null;
		this.ClosePreConfirm();
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x0008BECF File Offset: 0x0008A2CF
	public void PreConfirm()
	{
		this.ConfirmPanel.SetActive(true);
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x0008BEDD File Offset: 0x0008A2DD
	public void ClosePreConfirm()
	{
		this.ConfirmPanel.SetActive(false);
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x0008BEEB File Offset: 0x0008A2EB
	public void UpgradeToMax()
	{
		this.PreUpgrade();
		this.ConfirmPanel.SetActive(false);
		base.StartCoroutine(this.UpdateToMaxItemGlowEffect());
	}

	// Token: 0x06000CCE RID: 3278 RVA: 0x0008BF0C File Offset: 0x0008A30C
	public void Upgrade()
	{
		this.PreUpgrade();
		base.StartCoroutine(this.UpdateItemGlowEffect());
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x0008BF24 File Offset: 0x0008A324
	private IEnumerator UpdateToMaxItemGlowEffect()
	{
		yield return new WaitForSecondsRealtime(0.3f);
		this.PostUpgrade();
		if (this._item != null)
		{
			while (this._item.CanTeamSetUpgrade())
			{
				this._item.UpgradeTeamSetPiece();
			}
			this.Init(this._item);
			string text = string.Empty;
			foreach (AttributeModifier attributeModifier in this._item.GetAttributeModifiers())
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"* ",
					attributeModifier.AttributeType.GetDescription().Title,
					" ",
					(attributeModifier.Value <= 0.0) ? string.Empty : "+ ",
					attributeModifier.GetDisplayValue().ToDisplayValueFormat().ToColor(ColorPicker.White),
					"\n"
				});
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._item.GetSpecialEffects())
			{
				Color color = (!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Star;
				text = text + "* " + ColorPicker.GetHaxString(color, specialEffectDataLoad.GetDescription().Details1 + "\n");
			}
			this.Description.text = text;
			this.Animator.SetTrigger("Show");
		}
		yield break;
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x0008BF40 File Offset: 0x0008A340
	private IEnumerator UpdateItemGlowEffect()
	{
		yield return new WaitForSecondsRealtime(0.3f);
		this.PostUpgrade();
		if (this._item != null && this._item.CanTeamSetUpgrade())
		{
			List<AttributeModifier> attributeModifiers = this._item.GetAttributeModifiers();
			TeamSetItemUpgradeResult teamSetItemUpgradeResult = this._item.UpgradeTeamSetPiece();
			this.Init(this._item);
			if (teamSetItemUpgradeResult == null)
			{
				this.DisplayWarningText(UIComponentType.UpgradeFailed.GetName());
			}
			string text = string.Empty;
			using (List<AttributeModifier>.Enumerator enumerator = this._item.GetAttributeModifiers().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AttributeModifier attribute = enumerator.Current;
					bool flag = attributeModifiers.Any((AttributeModifier a) => a.AttributeType == attribute.AttributeType && a.Value != attribute.Value) || attributeModifiers.All((AttributeModifier a) => a.AttributeType != attribute.AttributeType);
					Color color = (!flag) ? Color.white : ColorPicker.PositiveGreen;
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"* ",
						attribute.AttributeType.GetDescription().Title,
						" ",
						(((attribute.Value <= 0.0) ? string.Empty : "+ ") + attribute.GetDisplayValue().ToDisplayValueFormat()).ToColor(color),
						"\n"
					});
				}
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._item.GetSpecialEffects())
			{
				Color color2 = (!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Star;
				text = text + "* " + ColorPicker.GetHaxString(color2, specialEffectDataLoad.GetDescription().Details1 + "\n");
			}
			this.Description.text = text;
			this.Animator.SetTrigger("Show");
		}
		yield break;
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x0008BF5B File Offset: 0x0008A35B
	private void PreUpgrade()
	{
		this.ItemGlowAnimator.SetTrigger("Glow");
		this.UpgradeButton.interactable = false;
		this.UpgradeMaxButton.interactable = false;
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x0008BF85 File Offset: 0x0008A385
	private void PostUpgrade()
	{
		this.UpgradeButton.interactable = true;
		this.UpgradeMaxButton.interactable = true;
	}

	// Token: 0x04000EE8 RID: 3816
	public ItemWithLevelItemController ItemController;

	// Token: 0x04000EE9 RID: 3817
	public Button UpgradeButton;

	// Token: 0x04000EEA RID: 3818
	public Button UpgradeMaxButton;

	// Token: 0x04000EEB RID: 3819
	public Transform RequirementContainer;

	// Token: 0x04000EEC RID: 3820
	public ShipResourceItemController RequirementItem;

	// Token: 0x04000EED RID: 3821
	public TextMeshProUGUI Description;

	// Token: 0x04000EEE RID: 3822
	public TextMeshProUGUI SuccessRateText;

	// Token: 0x04000EEF RID: 3823
	public Animator Animator;

	// Token: 0x04000EF0 RID: 3824
	public Animator ItemGlowAnimator;

	// Token: 0x04000EF1 RID: 3825
	public GameObject ConfirmPanel;

	// Token: 0x04000EF2 RID: 3826
	private Item _item;

	// Token: 0x02000C3B RID: 3131
	[CompilerGenerated]
	private sealed class <UpdateToMaxItemGlowEffect>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600524F RID: 21071 RVA: 0x0008BF9F File Offset: 0x0008A39F
		[DebuggerHidden]
		public <UpdateToMaxItemGlowEffect>c__Iterator0()
		{
		}

		// Token: 0x06005250 RID: 21072 RVA: 0x0008BFA8 File Offset: 0x0008A3A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSecondsRealtime(0.3f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.PostUpgrade();
				if (this._item != null)
				{
					while (this._item.CanTeamSetUpgrade())
					{
						this._item.UpgradeTeamSetPiece();
					}
					base.Init(this._item);
					string text = string.Empty;
					foreach (AttributeModifier attributeModifier in this._item.GetAttributeModifiers())
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							"* ",
							attributeModifier.AttributeType.GetDescription().Title,
							" ",
							(attributeModifier.Value <= 0.0) ? string.Empty : "+ ",
							attributeModifier.GetDisplayValue().ToDisplayValueFormat().ToColor(ColorPicker.White),
							"\n"
						});
					}
					foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._item.GetSpecialEffects())
					{
						Color color = (!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Star;
						text = text + "* " + ColorPicker.GetHaxString(color, specialEffectDataLoad.GetDescription().Details1 + "\n");
					}
					this.Description.text = text;
					this.Animator.SetTrigger("Show");
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x06005251 RID: 21073 RVA: 0x0008C1F4 File Offset: 0x0008A5F4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700118B RID: 4491
		// (get) Token: 0x06005252 RID: 21074 RVA: 0x0008C1FC File Offset: 0x0008A5FC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005253 RID: 21075 RVA: 0x0008C204 File Offset: 0x0008A604
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005254 RID: 21076 RVA: 0x0008C214 File Offset: 0x0008A614
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004044 RID: 16452
		internal UpgradeItemPanelController $this;

		// Token: 0x04004045 RID: 16453
		internal object $current;

		// Token: 0x04004046 RID: 16454
		internal bool $disposing;

		// Token: 0x04004047 RID: 16455
		internal int $PC;
	}

	// Token: 0x02000C3C RID: 3132
	[CompilerGenerated]
	private sealed class <UpdateItemGlowEffect>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005255 RID: 21077 RVA: 0x0008C21B File Offset: 0x0008A61B
		[DebuggerHidden]
		public <UpdateItemGlowEffect>c__Iterator1()
		{
		}

		// Token: 0x06005256 RID: 21078 RVA: 0x0008C224 File Offset: 0x0008A624
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSecondsRealtime(0.3f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.PostUpgrade();
				if (this._item != null && this._item.CanTeamSetUpgrade())
				{
					List<AttributeModifier> attributeModifiers = this._item.GetAttributeModifiers();
					TeamSetItemUpgradeResult teamSetItemUpgradeResult = this._item.UpgradeTeamSetPiece();
					base.Init(this._item);
					if (teamSetItemUpgradeResult == null)
					{
						this.DisplayWarningText(UIComponentType.UpgradeFailed.GetName());
					}
					string text = string.Empty;
					using (List<AttributeModifier>.Enumerator enumerator = this._item.GetAttributeModifiers().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							AttributeModifier attribute = enumerator.Current;
							bool flag = attributeModifiers.Any((AttributeModifier a) => a.AttributeType == attribute.AttributeType && a.Value != attribute.Value) || attributeModifiers.All((AttributeModifier a) => a.AttributeType != attribute.AttributeType);
							Color color = (!flag) ? Color.white : ColorPicker.PositiveGreen;
							string text2 = text;
							text = string.Concat(new string[]
							{
								text2,
								"* ",
								attribute.AttributeType.GetDescription().Title,
								" ",
								(((attribute.Value <= 0.0) ? string.Empty : "+ ") + attribute.GetDisplayValue().ToDisplayValueFormat()).ToColor(color),
								"\n"
							});
						}
					}
					foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._item.GetSpecialEffects())
					{
						Color color2 = (!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Star;
						text = text + "* " + ColorPicker.GetHaxString(color2, specialEffectDataLoad.GetDescription().Details1 + "\n");
					}
					this.Description.text = text;
					this.Animator.SetTrigger("Show");
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x06005257 RID: 21079 RVA: 0x0008C514 File Offset: 0x0008A914
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x06005258 RID: 21080 RVA: 0x0008C51C File Offset: 0x0008A91C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005259 RID: 21081 RVA: 0x0008C524 File Offset: 0x0008A924
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600525A RID: 21082 RVA: 0x0008C534 File Offset: 0x0008A934
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004048 RID: 16456
		internal UpgradeItemPanelController $this;

		// Token: 0x04004049 RID: 16457
		internal object $current;

		// Token: 0x0400404A RID: 16458
		internal bool $disposing;

		// Token: 0x0400404B RID: 16459
		internal int $PC;

		// Token: 0x02000C3D RID: 3133
		private sealed class <UpdateItemGlowEffect>c__AnonStorey2
		{
			// Token: 0x0600525B RID: 21083 RVA: 0x0008C53B File Offset: 0x0008A93B
			public <UpdateItemGlowEffect>c__AnonStorey2()
			{
			}

			// Token: 0x0600525C RID: 21084 RVA: 0x0008C543 File Offset: 0x0008A943
			internal bool <>m__0(AttributeModifier a)
			{
				return a.AttributeType == this.attribute.AttributeType && a.Value != this.attribute.Value;
			}

			// Token: 0x0600525D RID: 21085 RVA: 0x0008C574 File Offset: 0x0008A974
			internal bool <>m__1(AttributeModifier a)
			{
				return a.AttributeType != this.attribute.AttributeType;
			}

			// Token: 0x0400404C RID: 16460
			internal AttributeModifier attribute;
		}
	}
}
