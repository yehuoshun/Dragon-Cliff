using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000202 RID: 514
public class LoadingSceneManager : MonoBehaviour
{
	// Token: 0x06000D9E RID: 3486 RVA: 0x0008F21C File Offset: 0x0008D61C
	public LoadingSceneManager()
	{
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x0008F23A File Offset: 0x0008D63A
	public static void LoadScene(int levelNum)
	{
		Application.backgroundLoadingPriority = ThreadPriority.High;
		LoadingSceneManager.sceneToLoad = levelNum;
		SceneManager.LoadScene(LoadingSceneManager.loadingSceneIndex);
	}

	// Token: 0x06000DA0 RID: 3488 RVA: 0x0008F252 File Offset: 0x0008D652
	private void Start()
	{
		if (LoadingSceneManager.sceneToLoad < 0)
		{
			return;
		}
		this.fadeOverlay.gameObject.SetActive(true);
		this.currentScene = SceneManager.GetActiveScene();
		base.StartCoroutine(this.LoadAsync(LoadingSceneManager.sceneToLoad));
	}

	// Token: 0x06000DA1 RID: 3489 RVA: 0x0008F290 File Offset: 0x0008D690
	private IEnumerator LoadAsync(int levelNum)
	{
		this.ShowLoadingVisuals();
		yield return null;
		this.FadeIn();
		this.StartOperation(levelNum);
		float lastProgress = 0f;
		while (!this.DoneLoading())
		{
			yield return null;
			if (!Mathf.Approximately(this.operation.progress, lastProgress))
			{
				this.progressBar.fillAmount = this.operation.progress;
				lastProgress = this.operation.progress;
			}
		}
		if (this.loadSceneMode == LoadSceneMode.Additive)
		{
			this.audioListener.enabled = false;
		}
		this.ShowCompletionVisuals();
		yield return new WaitForSeconds(this.waitOnLoadEnd);
		this.FadeOut();
		yield return new WaitForSeconds(this.fadeDuration);
		if (this.loadSceneMode == LoadSceneMode.Additive)
		{
			SceneManager.UnloadScene(this.currentScene.name);
		}
		else
		{
			this.operation.allowSceneActivation = true;
		}
		yield break;
	}

	// Token: 0x06000DA2 RID: 3490 RVA: 0x0008F2B2 File Offset: 0x0008D6B2
	private void StartOperation(int levelNum)
	{
		Application.backgroundLoadingPriority = this.loadThreadPriority;
		this.operation = SceneManager.LoadSceneAsync(levelNum, this.loadSceneMode);
		if (this.loadSceneMode == LoadSceneMode.Single)
		{
			this.operation.allowSceneActivation = false;
		}
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x0008F2E8 File Offset: 0x0008D6E8
	private bool DoneLoading()
	{
		return (this.loadSceneMode == LoadSceneMode.Additive && this.operation.isDone) || (this.loadSceneMode == LoadSceneMode.Single && this.operation.progress >= 0.9f);
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x0008F337 File Offset: 0x0008D737
	private void FadeIn()
	{
		this.fadeOverlay.CrossFadeAlpha(0f, this.fadeDuration, true);
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x0008F350 File Offset: 0x0008D750
	private void FadeOut()
	{
		this.fadeOverlay.CrossFadeAlpha(1f, this.fadeDuration, true);
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x0008F36C File Offset: 0x0008D76C
	private void ShowLoadingVisuals()
	{
		this.loadingIcon.gameObject.SetActive(true);
		this.loadingDoneIcon.gameObject.SetActive(false);
		this.progressBar.fillAmount = 0f;
		this.loadingText.text = UIComponentType.LoadingSceneLoadingText.GetName();
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x0008F3C0 File Offset: 0x0008D7C0
	private void ShowCompletionVisuals()
	{
		this.loadingIcon.gameObject.SetActive(false);
		this.loadingDoneIcon.gameObject.SetActive(true);
		this.progressBar.fillAmount = 1f;
		this.loadingText.text = UIComponentType.LoadingSceneLoadingDoneText.GetName();
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0008F414 File Offset: 0x0008D814
	// Note: this type is marked as 'beforefieldinit'.
	static LoadingSceneManager()
	{
	}

	// Token: 0x04000F99 RID: 3993
	[Header("Loading Visuals")]
	public Image loadingIcon;

	// Token: 0x04000F9A RID: 3994
	public Image loadingDoneIcon;

	// Token: 0x04000F9B RID: 3995
	public TextMeshProUGUI loadingText;

	// Token: 0x04000F9C RID: 3996
	public Image progressBar;

	// Token: 0x04000F9D RID: 3997
	public Image fadeOverlay;

	// Token: 0x04000F9E RID: 3998
	[Header("Timing Settings")]
	public float waitOnLoadEnd = 0.25f;

	// Token: 0x04000F9F RID: 3999
	public float fadeDuration = 0.25f;

	// Token: 0x04000FA0 RID: 4000
	[Header("Loading Settings")]
	public LoadSceneMode loadSceneMode;

	// Token: 0x04000FA1 RID: 4001
	public ThreadPriority loadThreadPriority;

	// Token: 0x04000FA2 RID: 4002
	[Header("Other")]
	public AudioListener audioListener;

	// Token: 0x04000FA3 RID: 4003
	private AsyncOperation operation;

	// Token: 0x04000FA4 RID: 4004
	private Scene currentScene;

	// Token: 0x04000FA5 RID: 4005
	public static int sceneToLoad = -1;

	// Token: 0x04000FA6 RID: 4006
	private static int loadingSceneIndex = 1;

	// Token: 0x02000C44 RID: 3140
	[CompilerGenerated]
	private sealed class <LoadAsync>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600526F RID: 21103 RVA: 0x0008F422 File Offset: 0x0008D822
		[DebuggerHidden]
		public <LoadAsync>c__Iterator0()
		{
		}

		// Token: 0x06005270 RID: 21104 RVA: 0x0008F42C File Offset: 0x0008D82C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				base.ShowLoadingVisuals();
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.FadeIn();
				base.StartOperation(levelNum);
				lastProgress = 0f;
				break;
			case 2u:
				if (!Mathf.Approximately(this.operation.progress, lastProgress))
				{
					this.progressBar.fillAmount = this.operation.progress;
					lastProgress = this.operation.progress;
				}
				break;
			case 3u:
				base.FadeOut();
				this.$current = new WaitForSeconds(this.fadeDuration);
				if (!this.$disposing)
				{
					this.$PC = 4;
				}
				return true;
			case 4u:
				if (this.loadSceneMode == LoadSceneMode.Additive)
				{
					SceneManager.UnloadScene(this.currentScene.name);
				}
				else
				{
					this.operation.allowSceneActivation = true;
				}
				this.$PC = -1;
				return false;
			default:
				return false;
			}
			if (base.DoneLoading())
			{
				if (this.loadSceneMode == LoadSceneMode.Additive)
				{
					this.audioListener.enabled = false;
				}
				base.ShowCompletionVisuals();
				this.$current = new WaitForSeconds(this.waitOnLoadEnd);
				if (!this.$disposing)
				{
					this.$PC = 3;
				}
				return true;
			}
			this.$current = null;
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
		}

		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x06005271 RID: 21105 RVA: 0x0008F60C File Offset: 0x0008DA0C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x06005272 RID: 21106 RVA: 0x0008F614 File Offset: 0x0008DA14
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005273 RID: 21107 RVA: 0x0008F61C File Offset: 0x0008DA1C
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005274 RID: 21108 RVA: 0x0008F62C File Offset: 0x0008DA2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004059 RID: 16473
		internal int levelNum;

		// Token: 0x0400405A RID: 16474
		internal float <lastProgress>__0;

		// Token: 0x0400405B RID: 16475
		internal LoadingSceneManager $this;

		// Token: 0x0400405C RID: 16476
		internal object $current;

		// Token: 0x0400405D RID: 16477
		internal bool $disposing;

		// Token: 0x0400405E RID: 16478
		internal int $PC;
	}
}
