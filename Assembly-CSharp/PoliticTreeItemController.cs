using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000239 RID: 569
public class PoliticTreeItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000EC4 RID: 3780 RVA: 0x00091BAC File Offset: 0x0008FFAC
	public PoliticTreeItemController()
	{
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x00091BB4 File Offset: 0x0008FFB4
	public IEnumerator RemoveCover()
	{
		this.Cover.SetTrigger("Remove");
		yield return new WaitForSeconds(1f);
		this.Cover.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x00091BCF File Offset: 0x0008FFCF
	public void Upgrade()
	{
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x00091BD1 File Offset: 0x0008FFD1
	private void DisplayParticles()
	{
		this.Particles.SetActive(false);
		this.Particles.SetActive(true);
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x00091BEB File Offset: 0x0008FFEB
	private int GetChildRequiredLevel()
	{
		return 100;
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x00091BF0 File Offset: 0x0008FFF0
	private IEnumerator LightArrow()
	{
		this.Arrow.SetTrigger("Fill");
		yield return new WaitForSeconds(this.Arrow.playbackTime);
		yield break;
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x00091C0B File Offset: 0x0009000B
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x00091C0D File Offset: 0x0009000D
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x00091C15 File Offset: 0x00090015
	public void OnPointerClick(PointerEventData eventData)
	{
		this.Upgrade();
	}

	// Token: 0x0400102C RID: 4140
	public TextMeshProUGUI ItemName;

	// Token: 0x0400102D RID: 4141
	public Image Background;

	// Token: 0x0400102E RID: 4142
	public Image ItemImage;

	// Token: 0x0400102F RID: 4143
	public Animator Cover;

	// Token: 0x04001030 RID: 4144
	public Animator Arrow;

	// Token: 0x04001031 RID: 4145
	public TextMeshProUGUI LevelText;

	// Token: 0x04001032 RID: 4146
	public GameObject Particles;

	// Token: 0x04001033 RID: 4147
	private bool _lastMetRequirement;

	// Token: 0x04001034 RID: 4148
	private IPointerClickHandler _pointerClickHandlerImplementation;

	// Token: 0x02000C4E RID: 3150
	[CompilerGenerated]
	private sealed class <RemoveCover>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600528B RID: 21131 RVA: 0x00091C1D File Offset: 0x0009001D
		[DebuggerHidden]
		public <RemoveCover>c__Iterator0()
		{
		}

		// Token: 0x0600528C RID: 21132 RVA: 0x00091C28 File Offset: 0x00090028
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.Cover.SetTrigger("Remove");
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.Cover.gameObject.SetActive(false);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001194 RID: 4500
		// (get) Token: 0x0600528D RID: 21133 RVA: 0x00091CAF File Offset: 0x000900AF
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001195 RID: 4501
		// (get) Token: 0x0600528E RID: 21134 RVA: 0x00091CB7 File Offset: 0x000900B7
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600528F RID: 21135 RVA: 0x00091CBF File Offset: 0x000900BF
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005290 RID: 21136 RVA: 0x00091CCF File Offset: 0x000900CF
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400406B RID: 16491
		internal PoliticTreeItemController $this;

		// Token: 0x0400406C RID: 16492
		internal object $current;

		// Token: 0x0400406D RID: 16493
		internal bool $disposing;

		// Token: 0x0400406E RID: 16494
		internal int $PC;
	}

	// Token: 0x02000C4F RID: 3151
	[CompilerGenerated]
	private sealed class <LightArrow>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005291 RID: 21137 RVA: 0x00091CD6 File Offset: 0x000900D6
		[DebuggerHidden]
		public <LightArrow>c__Iterator1()
		{
		}

		// Token: 0x06005292 RID: 21138 RVA: 0x00091CE0 File Offset: 0x000900E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.Arrow.SetTrigger("Fill");
				this.$current = new WaitForSeconds(this.Arrow.playbackTime);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001196 RID: 4502
		// (get) Token: 0x06005293 RID: 21139 RVA: 0x00091D5C File Offset: 0x0009015C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001197 RID: 4503
		// (get) Token: 0x06005294 RID: 21140 RVA: 0x00091D64 File Offset: 0x00090164
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005295 RID: 21141 RVA: 0x00091D6C File Offset: 0x0009016C
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005296 RID: 21142 RVA: 0x00091D7C File Offset: 0x0009017C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400406F RID: 16495
		internal PoliticTreeItemController $this;

		// Token: 0x04004070 RID: 16496
		internal object $current;

		// Token: 0x04004071 RID: 16497
		internal bool $disposing;

		// Token: 0x04004072 RID: 16498
		internal int $PC;
	}
}
