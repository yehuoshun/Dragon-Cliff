using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000146 RID: 326
public class PathPointsManager : MonoBehaviour
{
	// Token: 0x060008E5 RID: 2277 RVA: 0x000787BC File Offset: 0x00076BBC
	public PathPointsManager()
	{
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x000787C4 File Offset: 0x00076BC4
	private void Awake()
	{
		if (PathPointsManager.Instance == null)
		{
			PathPointsManager.Instance = this;
		}
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000787DC File Offset: 0x00076BDC
	public List<Transform> GetPath(NodeController startPoint, NodeController destination)
	{
		return (from n in this.FindPath(startPoint, destination)
		select n.transform).ToList<Transform>();
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x00078810 File Offset: 0x00076C10
	public List<Transform> GetPath(Vector3 startPosition, int nextX, int nextY, NodeController destination)
	{
		NodeController nodeController = this.Nodes.FirstOrDefault((NodeController n) => n.PositionX == nextX && n.PositionY == nextY);
		List<Transform> list = (from n in this.FindPath(nodeController, destination)
		select n.transform).ToList<Transform>();
		list.Insert(0, nodeController.transform);
		return list;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x00078888 File Offset: 0x00076C88
	public List<NodeController> GetDistanceSortedNodes(Vector3 position)
	{
		List<NodeController> list = new List<NodeController>(this.Nodes);
		list.Sort((NodeController m, NodeController n) => Vector3.Distance(position, m.transform.position).CompareTo(Vector3.Distance(position, n.transform.position)));
		return list;
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x000788C4 File Offset: 0x00076CC4
	public NodeController GetNode(NodeType nodeType)
	{
		if (nodeType == NodeType.EntranceAndExit)
		{
			List<NodeController> list = (from n in this.Nodes
			where n.Type == NodeType.EntranceAndExit
			select n).ToList<NodeController>();
			int index = UnityEngine.Random.Range(0, list.Count<NodeController>() - 1);
			return list[index];
		}
		return this.Nodes.FirstOrDefault((NodeController n) => n.Type == nodeType);
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x00078948 File Offset: 0x00076D48
	public NodeController GetNode(TownSlot slot)
	{
		NodeType nodeType = NodeType.None;
		switch (slot)
		{
		case TownSlot.One:
			nodeType = NodeType.Slot1;
			break;
		case TownSlot.Two:
			nodeType = NodeType.Slot2;
			break;
		case TownSlot.Three:
			nodeType = NodeType.Slot3;
			break;
		case TownSlot.Four:
			nodeType = NodeType.Slot4;
			break;
		case TownSlot.Five:
			nodeType = NodeType.Slot5;
			break;
		case TownSlot.Six:
			nodeType = NodeType.Slot6;
			break;
		case TownSlot.Seven:
			nodeType = NodeType.Slot7;
			break;
		case TownSlot.Eight:
			nodeType = NodeType.Slot8;
			break;
		case TownSlot.Nine:
			nodeType = NodeType.Slot9;
			break;
		}
		return this.Nodes.Single((NodeController n) => n.Type == nodeType);
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x00078A17 File Offset: 0x00076E17
	public List<NodeController> GetNeighbours(NodeController node)
	{
		return node.Neighbours;
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x00078A20 File Offset: 0x00076E20
	public List<NodeController> FindPath(NodeController startNode, NodeController targetNode)
	{
		List<NodeController> list = new List<NodeController>();
		HashSet<NodeController> hashSet = new HashSet<NodeController>();
		list.Add(startNode);
		while (list.Count > 0)
		{
			NodeController nodeController = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].FCost < nodeController.FCost || (list[i].FCost == nodeController.FCost && list[i].HCost < nodeController.HCost))
				{
					nodeController = list[i];
				}
			}
			list.Remove(nodeController);
			hashSet.Add(nodeController);
			if (nodeController == targetNode)
			{
				return this.RetractPath(startNode, targetNode);
			}
			foreach (NodeController nodeController2 in nodeController.Neighbours)
			{
				if (!hashSet.Contains(nodeController2))
				{
					int num = nodeController.GCost + this.GetDistance(nodeController, nodeController2);
					if (num < nodeController2.GCost || !list.Contains(nodeController2))
					{
						nodeController2.GCost = num;
						nodeController2.HCost = this.GetDistance(nodeController2, targetNode);
						nodeController2.Parent = nodeController;
						if (!list.Contains(nodeController2))
						{
							list.Add(nodeController2);
						}
					}
				}
			}
		}
		return new List<NodeController>();
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00078BA8 File Offset: 0x00076FA8
	public List<NodeController> RetractPath(NodeController startNode, NodeController endNode)
	{
		List<NodeController> list = new List<NodeController>();
		NodeController nodeController = endNode;
		while (nodeController != startNode)
		{
			list.Add(nodeController);
			nodeController = nodeController.Parent;
		}
		list.Reverse();
		return list;
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x00078BE4 File Offset: 0x00076FE4
	private int GetDistance(NodeController nodeA, NodeController nodeB)
	{
		int num = Mathf.Abs(nodeA.PositionX - nodeB.PositionX);
		int num2 = Mathf.Abs(nodeA.PositionY - nodeB.PositionY);
		if (num > num2)
		{
			return 14 * num2 + 10 * (num - num2);
		}
		return 14 * num + 10 * (num2 - num);
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x00078C35 File Offset: 0x00077035
	[CompilerGenerated]
	private static Transform <GetPath>m__0(NodeController n)
	{
		return n.transform;
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00078C3D File Offset: 0x0007703D
	[CompilerGenerated]
	private static Transform <GetPath>m__1(NodeController n)
	{
		return n.transform;
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x00078C45 File Offset: 0x00077045
	[CompilerGenerated]
	private static bool <GetNode>m__2(NodeController n)
	{
		return n.Type == NodeType.EntranceAndExit;
	}

	// Token: 0x04000B88 RID: 2952
	public static PathPointsManager Instance;

	// Token: 0x04000B89 RID: 2953
	public List<NodeController> Nodes;

	// Token: 0x04000B8A RID: 2954
	[CompilerGenerated]
	private static Func<NodeController, Transform> <>f__am$cache0;

	// Token: 0x04000B8B RID: 2955
	[CompilerGenerated]
	private static Func<NodeController, Transform> <>f__am$cache1;

	// Token: 0x04000B8C RID: 2956
	[CompilerGenerated]
	private static Func<NodeController, bool> <>f__am$cache2;

	// Token: 0x02000C14 RID: 3092
	[CompilerGenerated]
	private sealed class <GetPath>c__AnonStorey0
	{
		// Token: 0x060051E2 RID: 20962 RVA: 0x00078C51 File Offset: 0x00077051
		public <GetPath>c__AnonStorey0()
		{
		}

		// Token: 0x060051E3 RID: 20963 RVA: 0x00078C59 File Offset: 0x00077059
		internal bool <>m__0(NodeController n)
		{
			return n.PositionX == this.nextX && n.PositionY == this.nextY;
		}

		// Token: 0x04003FFA RID: 16378
		internal int nextX;

		// Token: 0x04003FFB RID: 16379
		internal int nextY;
	}

	// Token: 0x02000C15 RID: 3093
	[CompilerGenerated]
	private sealed class <GetDistanceSortedNodes>c__AnonStorey1
	{
		// Token: 0x060051E4 RID: 20964 RVA: 0x00078C7D File Offset: 0x0007707D
		public <GetDistanceSortedNodes>c__AnonStorey1()
		{
		}

		// Token: 0x060051E5 RID: 20965 RVA: 0x00078C88 File Offset: 0x00077088
		internal int <>m__0(NodeController m, NodeController n)
		{
			return Vector3.Distance(this.position, m.transform.position).CompareTo(Vector3.Distance(this.position, n.transform.position));
		}

		// Token: 0x04003FFC RID: 16380
		internal Vector3 position;
	}

	// Token: 0x02000C16 RID: 3094
	[CompilerGenerated]
	private sealed class <GetNode>c__AnonStorey2
	{
		// Token: 0x060051E6 RID: 20966 RVA: 0x00078CC9 File Offset: 0x000770C9
		public <GetNode>c__AnonStorey2()
		{
		}

		// Token: 0x060051E7 RID: 20967 RVA: 0x00078CD1 File Offset: 0x000770D1
		internal bool <>m__0(NodeController n)
		{
			return n.Type == this.nodeType;
		}

		// Token: 0x04003FFD RID: 16381
		internal NodeType nodeType;
	}

	// Token: 0x02000C17 RID: 3095
	[CompilerGenerated]
	private sealed class <GetNode>c__AnonStorey3
	{
		// Token: 0x060051E8 RID: 20968 RVA: 0x00078CE1 File Offset: 0x000770E1
		public <GetNode>c__AnonStorey3()
		{
		}

		// Token: 0x060051E9 RID: 20969 RVA: 0x00078CE9 File Offset: 0x000770E9
		internal bool <>m__0(NodeController n)
		{
			return n.Type == this.nodeType;
		}

		// Token: 0x04003FFE RID: 16382
		internal NodeType nodeType;
	}
}
