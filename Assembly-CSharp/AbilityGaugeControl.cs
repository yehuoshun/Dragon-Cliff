using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000355 RID: 853
public class AbilityGaugeControl : MonoBehaviour
{
	// Token: 0x060016B7 RID: 5815 RVA: 0x000B27AB File Offset: 0x000B0BAB
	public AbilityGaugeControl()
	{
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x000B27C9 File Offset: 0x000B0BC9
	private void Awake()
	{
		this.Fill.fillAmount = 0f;
		this._flash = false;
		this.ParticleEffect.SetActive(false);
		this.UpdatePowerAmountText(0.0);
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x000B2800 File Offset: 0x000B0C00
	public void GaugeValueUpdated(IBattleUnit unit, AdventureEventType type, object obj)
	{
		BattleGaugeUpdateEvent battleGaugeUpdateEvent = obj as BattleGaugeUpdateEvent;
		if (battleGaugeUpdateEvent == null)
		{
			return;
		}
		if (base.isActiveAndEnabled)
		{
			base.StartCoroutine(this.ChangeValue(battleGaugeUpdateEvent.CurrentValue / 100.0));
		}
		else
		{
			this.Fill.fillAmount = (float)battleGaugeUpdateEvent.CurrentValue / 100f;
		}
		this.UpdatePowerAmountText(battleGaugeUpdateEvent.CurrentValue);
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x000B286C File Offset: 0x000B0C6C
	private IEnumerator ChangeValue(double changeTo)
	{
		float currentvaule = this.Fill.fillAmount;
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime;
			float amount = Mathf.Lerp(currentvaule, (float)changeTo, t * this.ChangeSpeed);
			this.Fill.fillAmount = amount;
			yield return null;
		}
		this.Fill.fillAmount = (float)changeTo;
		yield return new WaitForSeconds(1f);
		yield break;
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x000B288E File Offset: 0x000B0C8E
	public void GaugeReleased()
	{
		this._flash = false;
		this.ParticleEffect.SetActive(false);
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x000B28A3 File Offset: 0x000B0CA3
	public void GaugeFullyCharged()
	{
		this._flash = true;
		this.ParticleEffect.SetActive(true);
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x000B28B8 File Offset: 0x000B0CB8
	private void Update()
	{
		if (this._flash)
		{
			this._timer += Time.deltaTime;
			this.Fill.color = Color.Lerp(this.OriginalColor, this.FlashColor, Mathf.PingPong(Time.time * this.FlashRate, 1f));
		}
		else if (this.Fill.color != this.OriginalColor && this._resetTimer < 1f)
		{
			this._resetTimer += Time.deltaTime;
			this.Fill.color = Color.Lerp(this.Fill.color, this.OriginalColor, this._resetTimer);
		}
		if (this._resetTimer >= 1f || this.Fill.color == this.OriginalColor)
		{
			this._resetTimer = 0f;
			this.Fill.color = this.OriginalColor;
		}
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x000B29C4 File Offset: 0x000B0DC4
	private void UpdatePowerAmountText(double value)
	{
		this.PowerAmount.text = value.DoubleToString() + "/" + 100;
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x000B29E8 File Offset: 0x000B0DE8
	public void CompleteEncounter()
	{
		this.GaugeReleased();
		this.Fill.fillAmount = 0f;
		this.UpdatePowerAmountText(0.0);
	}

	// Token: 0x040016C3 RID: 5827
	public Image Fill;

	// Token: 0x040016C4 RID: 5828
	public TextMeshProUGUI PowerAmount;

	// Token: 0x040016C5 RID: 5829
	public Color OriginalColor;

	// Token: 0x040016C6 RID: 5830
	public Color FlashColor;

	// Token: 0x040016C7 RID: 5831
	public GameObject ParticleEffect;

	// Token: 0x040016C8 RID: 5832
	public float FlashRate = 2f;

	// Token: 0x040016C9 RID: 5833
	public float ChangeSpeed = 5f;

	// Token: 0x040016CA RID: 5834
	private bool _flash;

	// Token: 0x040016CB RID: 5835
	private float _timer;

	// Token: 0x040016CC RID: 5836
	private float _resetTimer;

	// Token: 0x02000CAE RID: 3246
	[CompilerGenerated]
	private sealed class <ChangeValue>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053F8 RID: 21496 RVA: 0x000B2A0F File Offset: 0x000B0E0F
		[DebuggerHidden]
		public <ChangeValue>c__Iterator0()
		{
		}

		// Token: 0x060053F9 RID: 21497 RVA: 0x000B2A18 File Offset: 0x000B0E18
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			double targetvalue;
			switch (num)
			{
			case 0u:
				currentvaule = this.Fill.fillAmount;
				targetvalue = changeTo;
				t = 0f;
				break;
			case 1u:
				break;
			case 2u:
				this.$PC = -1;
				return false;
			default:
				return false;
			}
			if (t >= 1f)
			{
				this.Fill.fillAmount = (float)targetvalue;
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
			}
			else
			{
				t += Time.deltaTime;
				amount = Mathf.Lerp(currentvaule, (float)targetvalue, t * this.ChangeSpeed);
				this.Fill.fillAmount = amount;
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
			}
			return true;
		}

		// Token: 0x170011CE RID: 4558
		// (get) Token: 0x060053FA RID: 21498 RVA: 0x000B2B3E File Offset: 0x000B0F3E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011CF RID: 4559
		// (get) Token: 0x060053FB RID: 21499 RVA: 0x000B2B46 File Offset: 0x000B0F46
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053FC RID: 21500 RVA: 0x000B2B4E File Offset: 0x000B0F4E
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053FD RID: 21501 RVA: 0x000B2B5E File Offset: 0x000B0F5E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004179 RID: 16761
		internal float <currentvaule>__0;

		// Token: 0x0400417A RID: 16762
		internal double changeTo;

		// Token: 0x0400417B RID: 16763
		internal double <targetvalue>__0;

		// Token: 0x0400417C RID: 16764
		internal float <t>__0;

		// Token: 0x0400417D RID: 16765
		internal float <amount>__1;

		// Token: 0x0400417E RID: 16766
		internal AbilityGaugeControl $this;

		// Token: 0x0400417F RID: 16767
		internal object $current;

		// Token: 0x04004180 RID: 16768
		internal bool $disposing;

		// Token: 0x04004181 RID: 16769
		internal int $PC;
	}
}
