using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BAA RID: 2986
	public static class GizmosEx
	{
		// Token: 0x06004F51 RID: 20305 RVA: 0x00205598 File Offset: 0x00203998
		public static float GetGizmoSize(Vector3 position)
		{
			Camera current = Camera.current;
			position = Gizmos.matrix.MultiplyPoint(position);
			if (current)
			{
				Transform transform = current.transform;
				Vector3 position2 = transform.position;
				float z = Vector3.Dot(position - position2, transform.TransformDirection(new Vector3(0f, 0f, 1f)));
				Vector3 a = current.WorldToScreenPoint(position2 + transform.TransformDirection(new Vector3(0f, 0f, z)));
				Vector3 b = current.WorldToScreenPoint(position2 + transform.TransformDirection(new Vector3(1f, 0f, z)));
				float magnitude = (a - b).magnitude;
				return 80f / Mathf.Max(magnitude, 0.0001f);
			}
			return 20f;
		}

		// Token: 0x06004F52 RID: 20306 RVA: 0x00205674 File Offset: 0x00203A74
		public static void DrawRect(Transform transform, Rect rect, Color color)
		{
			Vector3[] array = new Vector3[]
			{
				transform.TransformPoint(new Vector3(rect.x, rect.y, 0f)),
				transform.TransformPoint(new Vector3(rect.x + rect.width, rect.y, 0f)),
				transform.TransformPoint(new Vector3(rect.x + rect.width, rect.y + rect.height, 0f)),
				transform.TransformPoint(new Vector3(rect.x, rect.y + rect.height, 0f))
			};
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(array[0], array[1]);
			Gizmos.DrawLine(array[1], array[2]);
			Gizmos.DrawLine(array[2], array[3]);
			Gizmos.DrawLine(array[3], array[0]);
			Gizmos.color = color2;
		}

		// Token: 0x06004F53 RID: 20307 RVA: 0x002057D8 File Offset: 0x00203BD8
		public static void DrawDot(Transform transform, Vector3 position, float size, Color color)
		{
			Rect rect = new Rect(-size / (2f * transform.localScale.x), -size / (2f * transform.localScale.y), size / transform.localScale.x, size / transform.localScale.y);
			Vector3[] array = new Vector3[]
			{
				transform.TransformPoint(position + new Vector3(rect.x, rect.y, 0f)),
				transform.TransformPoint(position + new Vector3(rect.x + rect.width, rect.y, 0f)),
				transform.TransformPoint(position + new Vector3(rect.x + rect.width, rect.y + rect.height, 0f)),
				transform.TransformPoint(position + new Vector3(rect.x, rect.y + rect.height, 0f))
			};
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(array[0], array[1]);
			Gizmos.DrawLine(array[1], array[2]);
			Gizmos.DrawLine(array[2], array[3]);
			Gizmos.DrawLine(array[3], array[0]);
			Gizmos.color = color2;
		}

		// Token: 0x06004F54 RID: 20308 RVA: 0x002059B4 File Offset: 0x00203DB4
		public static void DrawRect(Rect rect, Color color)
		{
			Vector3[] array = new Vector3[]
			{
				new Vector3(rect.x, rect.y, 0f),
				new Vector3(rect.x + rect.width, rect.y, 0f),
				new Vector3(rect.x + rect.width, rect.y + rect.height, 0f),
				new Vector3(rect.x, rect.y + rect.height, 0f)
			};
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(array[0], array[1]);
			Gizmos.DrawLine(array[1], array[2]);
			Gizmos.DrawLine(array[2], array[3]);
			Gizmos.DrawLine(array[3], array[0]);
			Gizmos.color = color2;
		}

		// Token: 0x06004F55 RID: 20309 RVA: 0x00205B00 File Offset: 0x00203F00
		public static void DrawDot(Vector3 position, float size, Color color)
		{
			Rect rect = new Rect(-size / 2f, -size / 2f, size, size);
			Vector3[] array = new Vector3[]
			{
				position + new Vector3(rect.x, rect.y, 0f),
				position + new Vector3(rect.x + rect.width, rect.y, 0f),
				position + new Vector3(rect.x + rect.width, rect.y + rect.height, 0f),
				position + new Vector3(rect.x, rect.y + rect.height, 0f)
			};
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(array[0], array[1]);
			Gizmos.DrawLine(array[1], array[2]);
			Gizmos.DrawLine(array[2], array[3]);
			Gizmos.DrawLine(array[3], array[0]);
			Gizmos.color = color2;
		}
	}
}
