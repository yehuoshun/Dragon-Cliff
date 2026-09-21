using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B63 RID: 2915
	public class TMP_FrameRateCounter : MonoBehaviour
	{
		// Token: 0x06004D37 RID: 19767 RVA: 0x001F59A0 File Offset: 0x001F3DA0
		public TMP_FrameRateCounter()
		{
		}

		// Token: 0x06004D38 RID: 19768 RVA: 0x001F59BC File Offset: 0x001F3DBC
		private void Awake()
		{
			if (!base.enabled)
			{
				return;
			}
			this.m_camera = Camera.main;
			Application.targetFrameRate = -1;
			GameObject gameObject = new GameObject("Frame Counter");
			this.m_TextMeshPro = gameObject.AddComponent<TextMeshPro>();
			this.m_TextMeshPro.font = (Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset);
			this.m_TextMeshPro.fontSharedMaterial = (Resources.Load("Fonts & Materials/LiberationSans SDF - Overlay", typeof(Material)) as Material);
			this.m_frameCounter_transform = gameObject.transform;
			this.m_frameCounter_transform.SetParent(this.m_camera.transform);
			this.m_frameCounter_transform.localRotation = Quaternion.identity;
			this.m_TextMeshPro.enableWordWrapping = false;
			this.m_TextMeshPro.fontSize = 24f;
			this.m_TextMeshPro.isOverlay = true;
			this.Set_FrameCounter_Position(this.AnchorPosition);
			this.last_AnchorPosition = this.AnchorPosition;
		}

		// Token: 0x06004D39 RID: 19769 RVA: 0x001F5AB7 File Offset: 0x001F3EB7
		private void Start()
		{
			this.m_LastInterval = Time.realtimeSinceStartup;
			this.m_Frames = 0;
		}

		// Token: 0x06004D3A RID: 19770 RVA: 0x001F5ACC File Offset: 0x001F3ECC
		private void Update()
		{
			if (this.AnchorPosition != this.last_AnchorPosition)
			{
				this.Set_FrameCounter_Position(this.AnchorPosition);
			}
			this.last_AnchorPosition = this.AnchorPosition;
			this.m_Frames++;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup > this.m_LastInterval + this.UpdateInterval)
			{
				float num = (float)this.m_Frames / (realtimeSinceStartup - this.m_LastInterval);
				float arg = 1000f / Mathf.Max(num, 1E-05f);
				if (num < 30f)
				{
					this.htmlColorTag = "<color=yellow>";
				}
				else if (num < 10f)
				{
					this.htmlColorTag = "<color=red>";
				}
				else
				{
					this.htmlColorTag = "<color=green>";
				}
				this.m_TextMeshPro.SetText(this.htmlColorTag + "{0:2}</color> FPS \n{1:2} <#8080ff>MS", num, arg);
				this.m_Frames = 0;
				this.m_LastInterval = realtimeSinceStartup;
			}
		}

		// Token: 0x06004D3B RID: 19771 RVA: 0x001F5BB8 File Offset: 0x001F3FB8
		private void Set_FrameCounter_Position(TMP_FrameRateCounter.FpsCounterAnchorPositions anchor_position)
		{
			this.m_TextMeshPro.margin = new Vector4(1f, 1f, 1f, 1f);
			switch (anchor_position)
			{
			case TMP_FrameRateCounter.FpsCounterAnchorPositions.TopLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopLeft;
				this.m_TextMeshPro.rectTransform.pivot = new Vector2(0f, 1f);
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(0f, 1f, 100f));
				break;
			case TMP_FrameRateCounter.FpsCounterAnchorPositions.BottomLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
				this.m_TextMeshPro.rectTransform.pivot = new Vector2(0f, 0f);
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(0f, 0f, 100f));
				break;
			case TMP_FrameRateCounter.FpsCounterAnchorPositions.TopRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopRight;
				this.m_TextMeshPro.rectTransform.pivot = new Vector2(1f, 1f);
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(1f, 1f, 100f));
				break;
			case TMP_FrameRateCounter.FpsCounterAnchorPositions.BottomRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomRight;
				this.m_TextMeshPro.rectTransform.pivot = new Vector2(1f, 0f);
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(1f, 0f, 100f));
				break;
			}
		}

		// Token: 0x04003BA6 RID: 15270
		public float UpdateInterval = 5f;

		// Token: 0x04003BA7 RID: 15271
		private float m_LastInterval;

		// Token: 0x04003BA8 RID: 15272
		private int m_Frames;

		// Token: 0x04003BA9 RID: 15273
		public TMP_FrameRateCounter.FpsCounterAnchorPositions AnchorPosition = TMP_FrameRateCounter.FpsCounterAnchorPositions.TopRight;

		// Token: 0x04003BAA RID: 15274
		private string htmlColorTag;

		// Token: 0x04003BAB RID: 15275
		private const string fpsLabel = "{0:2}</color> FPS \n{1:2} <#8080ff>MS";

		// Token: 0x04003BAC RID: 15276
		private TextMeshPro m_TextMeshPro;

		// Token: 0x04003BAD RID: 15277
		private Transform m_frameCounter_transform;

		// Token: 0x04003BAE RID: 15278
		private Camera m_camera;

		// Token: 0x04003BAF RID: 15279
		private TMP_FrameRateCounter.FpsCounterAnchorPositions last_AnchorPosition;

		// Token: 0x02000B64 RID: 2916
		public enum FpsCounterAnchorPositions
		{
			// Token: 0x04003BB1 RID: 15281
			TopLeft,
			// Token: 0x04003BB2 RID: 15282
			BottomLeft,
			// Token: 0x04003BB3 RID: 15283
			TopRight,
			// Token: 0x04003BB4 RID: 15284
			BottomRight
		}
	}
}
