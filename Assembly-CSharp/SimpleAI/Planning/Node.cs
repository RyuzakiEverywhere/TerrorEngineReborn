using System;

namespace SimpleAI.Planning
{
	// Token: 0x02000190 RID: 400
	public class Node : IComparable<Node>
	{
		// Token: 0x06000991 RID: 2449 RVA: 0x00054462 File Offset: 0x00052862
		public Node()
		{
			this.Awake(-1, Node.eState.kUnvisited);
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x00054472 File Offset: 0x00052872
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x0005447A File Offset: 0x0005287A
		public Node.eState State
		{
			get
			{
				return this.m_state;
			}
			set
			{
				this.m_state = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00054483 File Offset: 0x00052883
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x0005448B File Offset: 0x0005288B
		public Node Parent
		{
			get
			{
				return this.m_parent;
			}
			set
			{
				this.m_parent = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x00054494 File Offset: 0x00052894
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x0005449C File Offset: 0x0005289C
		public int Index
		{
			get
			{
				return this.m_index;
			}
			set
			{
				this.m_index = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x000544A5 File Offset: 0x000528A5
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x000544AD File Offset: 0x000528AD
		public float F
		{
			get
			{
				return this.m_f;
			}
			set
			{
				this.m_f = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x000544B6 File Offset: 0x000528B6
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x000544BE File Offset: 0x000528BE
		public float G
		{
			get
			{
				return this.m_g;
			}
			set
			{
				this.m_g = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x000544C7 File Offset: 0x000528C7
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x000544CF File Offset: 0x000528CF
		public float H
		{
			get
			{
				return this.m_h;
			}
			set
			{
				this.m_h = value;
			}
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000544D8 File Offset: 0x000528D8
		public int CompareTo(Node other)
		{
			if (this.m_f < other.m_f)
			{
				return -1;
			}
			if (this.m_f > other.m_f)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00054501 File Offset: 0x00052901
		public override string ToString()
		{
			return "Node:" + this.m_f.ToString();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0005451E File Offset: 0x0005291E
		public void Awake(int nodeIndex, Node.eState state)
		{
			this.m_index = nodeIndex;
			this.m_f = float.MaxValue;
			this.m_state = state;
			this.m_parent = null;
			this.m_g = float.MaxValue;
			this.m_h = float.MaxValue;
		}

		// Token: 0x04000B3E RID: 2878
		public const int kInvalidIndex = -1;

		// Token: 0x04000B3F RID: 2879
		private float m_f;

		// Token: 0x04000B40 RID: 2880
		private float m_g;

		// Token: 0x04000B41 RID: 2881
		private float m_h;

		// Token: 0x04000B42 RID: 2882
		private Node.eState m_state;

		// Token: 0x04000B43 RID: 2883
		private Node m_parent;

		// Token: 0x04000B44 RID: 2884
		private int m_index;

		// Token: 0x02000191 RID: 401
		public enum eState
		{
			// Token: 0x04000B46 RID: 2886
			kUnvisited,
			// Token: 0x04000B47 RID: 2887
			kOpen,
			// Token: 0x04000B48 RID: 2888
			kClosed,
			// Token: 0x04000B49 RID: 2889
			kBlocked
		}
	}
}
