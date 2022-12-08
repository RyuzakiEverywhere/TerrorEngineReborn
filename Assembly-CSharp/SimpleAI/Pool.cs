using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleAI
{
	// Token: 0x02000196 RID: 406
	public class Pool<T> : IEnumerable<T>, IEnumerable where T : new()
	{
		// Token: 0x060009AF RID: 2479 RVA: 0x00054580 File Offset: 0x00052980
		public Pool(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("Pool must contain at least one item.");
			}
			this.pool = new Pool<T>.Node[capacity];
			this.active = new bool[capacity];
			this.available = new Queue<int>(capacity);
			for (int i = 0; i < capacity; i++)
			{
				this.pool[i] = default(Pool<T>.Node);
				this.pool[i].NodeIndex = i;
				this.pool[i].Item = Activator.CreateInstance<T>();
				this.active[i] = false;
				this.available.Enqueue(i);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x00054632 File Offset: 0x00052A32
		public int AvailableCount
		{
			get
			{
				return this.available.Count;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0005463F File Offset: 0x00052A3F
		public int ActiveCount
		{
			get
			{
				return this.pool.Length - this.available.Count;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x00054655 File Offset: 0x00052A55
		public int Capacity
		{
			get
			{
				return this.pool.Length;
			}
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00054660 File Offset: 0x00052A60
		public void Clear()
		{
			this.available.Clear();
			for (int i = 0; i < this.pool.Length; i++)
			{
				this.active[i] = false;
				this.available.Enqueue(i);
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000546A8 File Offset: 0x00052AA8
		public Pool<T>.Node Get()
		{
			int num = this.available.Dequeue();
			this.active[num] = true;
			return this.pool[num];
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000546DC File Offset: 0x00052ADC
		public void Return(Pool<T>.Node item)
		{
			if (item.NodeIndex < 0 || item.NodeIndex > this.pool.Length)
			{
				throw new ArgumentException("Invalid item node.");
			}
			if (!this.active[item.NodeIndex])
			{
				throw new InvalidOperationException("Attempt to return an inactive node.");
			}
			this.active[item.NodeIndex] = false;
			this.available.Enqueue(item.NodeIndex);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00054754 File Offset: 0x00052B54
		public void SetItemValue(Pool<T>.Node item)
		{
			if (item.NodeIndex < 0 || item.NodeIndex > this.pool.Length)
			{
				throw new ArgumentException("Invalid item node.");
			}
			this.pool[item.NodeIndex].Item = item.Item;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000547AC File Offset: 0x00052BAC
		public int CopyTo(T[] array, int arrayIndex)
		{
			int num = arrayIndex;
			foreach (Pool<T>.Node node in this.pool)
			{
				if (this.active[node.NodeIndex])
				{
					array[num++] = node.Item;
					if (num == array.Length)
					{
						return num - arrayIndex;
					}
				}
			}
			return num - arrayIndex;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00054818 File Offset: 0x00052C18
		public IEnumerator<T> GetEnumerator()
		{
			foreach (Pool<T>.Node item in this.pool)
			{
				if (this.active[item.NodeIndex])
				{
					yield return item.Item;
				}
			}
			yield break;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x00054834 File Offset: 0x00052C34
		public IEnumerable<Pool<T>.Node> ActiveNodes
		{
			get
			{
				foreach (Pool<T>.Node item in this.pool)
				{
					if (this.active[item.NodeIndex])
					{
						yield return item;
					}
				}
				yield break;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x00054858 File Offset: 0x00052C58
		public IEnumerable<Pool<T>.Node> AllNodes
		{
			get
			{
				foreach (Pool<T>.Node item in this.pool)
				{
					yield return item;
				}
				yield break;
			}
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0005487B File Offset: 0x00052C7B
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000B53 RID: 2899
		private Pool<T>.Node[] pool;

		// Token: 0x04000B54 RID: 2900
		private bool[] active;

		// Token: 0x04000B55 RID: 2901
		private Queue<int> available;

		// Token: 0x02000197 RID: 407
		public struct Node
		{
			// Token: 0x04000B56 RID: 2902
			internal int NodeIndex;

			// Token: 0x04000B57 RID: 2903
			public T Item;
		}
	}
}
