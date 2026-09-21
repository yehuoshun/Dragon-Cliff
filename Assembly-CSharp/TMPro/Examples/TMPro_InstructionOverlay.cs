using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B70 RID: 2928
	public class TMPro_InstructionOverlay : MonoBehaviour
	{
		// Token: 0x06004D6E RID: 19822 RVA: 0x001F7AE4 File Offset: 0x001F5EE4
		public TMPro_InstructionOverlay()
		{
		}

		// Token: 0x06004D6F RID: 19823 RVA: 0x001F7AF4 File Offset: 0x001F5EF4
		private void Awake()
		{
			if (!base.enabled)
			{
				return;
			}
			this.m_camera = Camera.main;
			GameObject gameObject = new GameObject("Frame Counter");
			this.m_frameCounter_transform = gameObject.transform;
			this.m_frameCounter_transform.SetParent(this.m_camera.transform, false);
			this.m_frameCounter_transform.localRotation = Quaternion.identity;
			this.m_TextMeshPro = gameObject.AddComponent<TextMeshPro>();
			this.m_TextMeshPro.font = (Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset);
			this.m_TextMeshPro.fontSharedMaterial = (Resources.Load("Fonts & Materials/LiberationSans SDF - Overlay", typeof(Material)) as Material);
			this.m_TextMeshPro.fontSize = 30f;
			this.m_TextMeshPro.isOverlay = true;
			this.m_textContainer = gameObject.GetComponent<TextContainer>();
			this.Set_FrameCounter_Position(this.AnchorPosition);
			this.m_TextMeshPro.text = "Camera Control - <#ffff00>Shift + RMB\n</color>Zoom - <#ffff00>Mouse wheel.";
		}

		// Token: 0x06004D70 RID: 19824 RVA: 0x001F7BF0 File Offset: 0x001F5FF0
		private void Set_FrameCounter_Position(TMPro_InstructionOverlay.FpsCounterAnchorPositions anchor_position)
		{
			switch (anchor_position)
			{
			case TMPro_InstructionOverlay.FpsCounterAnchorPositions.TopLeft:
				this.m_textContainer.anchorPosition = TextContainerAnchors.TopLeft;
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(0f, 1f, 100f));
				break;
			case TMPro_InstructionOverlay.FpsCounterAnchorPositions.BottomLeft:
				this.m_textContainer.anchorPosition = TextContainerAnchors.BottomLeft;
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(0f, 0f, 100f));
				break;
			case TMPro_InstructionOverlay.FpsCounterAnchorPositions.TopRight:
				this.m_textContainer.anchorPosition = TextContainerAnchors.TopRight;
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(1f, 1f, 100f));
				break;
			case TMPro_InstructionOverlay.FpsCounterAnchorPositions.BottomRight:
				this.m_textContainer.anchorPosition = TextContainerAnchors.BottomRight;
				this.m_frameCounter_transform.position = this.m_camera.ViewportToWorldPoint(new Vector3(1f, 0f, 100f));
				break;
			}
		}

		// Token: 0x04003BEC RID: 15340
		public TMPro_InstructionOverlay.FpsCounterAnchorPositions AnchorPosition = TMPro_InstructionOverlay.FpsCounterAnchorPositions.BottomLeft;

		// Token: 0x04003BED RID: 15341
		private const string instructions = "Camera Control - <#ffff00>Shift + RMB\n</color>Zoom - <#ffff00>Mouse wheel.";

		// Token: 0x04003BEE RID: 15342
		private TextMeshPro m_TextMeshPro;

		// Token: 0x04003BEF RID: 15343
		private TextContainer m_textContainer;

		// Token: 0x04003BF0 RID: 15344
		private Transform m_frameCounter_transform;

		// Token: 0x04003BF1 RID: 15345
		private Camera m_camera;

		// Token: 0x02000B71 RID: 2929
		public enum FpsCounterAnchorPositions
		{
			// Token: 0x04003BF3 RID: 15347
			TopLeft,
			// Token: 0x04003BF4 RID: 15348
			BottomLeft,
			// Token: 0x04003BF5 RID: 15349
			TopRight,
			// Token: 0x04003BF6 RID: 15350
			BottomRight
		}
	}
}
