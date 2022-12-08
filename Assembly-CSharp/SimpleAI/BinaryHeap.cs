using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleAI
{
	// Token: 0x02000172 RID: 370
	public class BinaryHeap<T> : ICollection<T>, IEnumerable, IEnumerable<T> where T : IComparable<T>
	{
		// Token: 0x060008B1 RID: 2225 RVA: 0x0005064C File Offset: 0x0004EA4C
		public BinaryHeap()
		{
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00050667 File Offset: 0x0004EA67
		private BinaryHeap(T[] data, int count)
		{
			this.Capacity = count;
			this._count = count;
			Array.Copy(data, this._data, count);
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0005069D File Offset: 0x0004EA9D
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x000506A5 File Offset: 0x0004EAA5
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x000506B0 File Offset: 0x0004EAB0
		public int Capacity
		{
			get
			{
				return this._capacity;
			}
			set
			{
				int capacity = this._capacity;
				this._capacity = Math.Max(value, this._count);
				if (this._capacity != capacity)
				{
					T[] array = new T[this._capacity];
					Array.Copy(this._data, array, this._count);
					this._data = array;
				}
			}
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00050707 File Offset: 0x0004EB07
		public T Peek()
		{
			return this._data[0];
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00050715 File Offset: 0x0004EB15
		public void Clear()
		{
			this._count = 0;
			this._data = new T[this._capacity];
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0005072F File Offset: 0x0004EB2F
		public void Add(T item)
		{
			if (this._count >= this.Capacity)
			{
				return;
			}
			this._data[this._count] = item;
			this.UpHeap();
			this._count++;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0005076C File Offset: 0x0004EB6C
		public T Remove()
		{
			if (this._count == 0)
			{
				throw new InvalidOperationException("Cannot remove item, heap is empty.");
			}
			T result = this._data[0];
			this._count--;
			this._data[0] = this._data[this._count];
			this._data[this._count] = default(T);
			this.DownHeap();
			return result;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x000507E8 File Offset: 0x0004EBE8
		private void UpHeap()
		{
			this._sorted = false;
			int num = this._count;
			T t = this._data[num];
			int num2 = BinaryHeap<T>.Parent(num);
			while (num2 > -1 && t.CompareTo(this._data[num2]) < 0)
			{
				this._data[num] = this._data[num2];
				num = num2;
				num2 = BinaryHeap<T>.Parent(num);
			}
			this._data[num] = t;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00050870 File Offset: 0x0004EC70
		private void DownHeap()
		{
			this._sorted = false;
			int num = 0;
			T t = this._data[num];
			for (;;)
			{
				int num2 = BinaryHeap<T>.Child1(num);
				if (num2 >= this._count)
				{
					break;
				}
				int num3 = BinaryHeap<T>.Child2(num);
				int num4;
				if (num3 >= this._count)
				{
					num4 = num2;
				}
				else
				{
					num4 = ((this._data[num2].CompareTo(this._data[num3]) >= 0) ? num3 : num2);
				}
				if (t.CompareTo(this._data[num4]) <= 0)
				{
					break;
				}
				this._data[num] = this._data[num4];
				num = num4;
			}
			this._data[num] = t;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00050951 File Offset: 0x0004ED51
		private void EnsureSort()
		{
			if (this._sorted)
			{
				return;
			}
			Array.Sort<T>(this._data, 0, this._count);
			this._sorted = true;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00050978 File Offset: 0x0004ED78
		private static int Parent(int index)
		{
			return index - 1 >> 1;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0005097F File Offset: 0x0004ED7F
		private static int Child1(int index)
		{
			return (index << 1) + 1;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00050986 File Offset: 0x0004ED86
		private static int Child2(int index)
		{
			return (index << 1) + 2;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0005098D File Offset: 0x0004ED8D
		public BinaryHeap<T> Copy()
		{
			return new BinaryHeap<T>(this._data, this._count);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x000509A0 File Offset: 0x0004EDA0
		public IEnumerator<T> GetEnumerator()
		{
			this.EnsureSort();
			for (int i = 0; i < this._count; i++)
			{
				yield return this._data[i];
			}
			yield break;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x000509BB File Offset: 0x0004EDBB
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000509C3 File Offset: 0x0004EDC3
		public bool Contains(T item)
		{
			this.EnsureSort();
			return Array.BinarySearch<T>(this._data, 0, this._count, item) >= 0;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000509E4 File Offset: 0x0004EDE4
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.EnsureSort();
			Array.Copy(this._data, array, this._count);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x000509FE File Offset: 0x0004EDFE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00050A04 File Offset: 0x0004EE04
		public bool Remove(T item)
		{
			this.EnsureSort();
			int num = Array.BinarySearch<T>(this._data, 0, this._count, item);
			if (num < 0)
			{
				return false;
			}
			Array.Copy(this._data, num + 1, this._data, num, this._count - num);
			this._data[this._count] = default(T);
			this._count--;
			return true;
		}

		// Token: 0x04000ACF RID: 2767
		private const int DEFAULT_SIZE = 4;

		// Token: 0x04000AD0 RID: 2768
		private T[] _data = new T[4];

		// Token: 0x04000AD1 RID: 2769
		private int _count;

		// Token: 0x04000AD2 RID: 2770
		private int _capacity = 4;

		// Token: 0x04000AD3 RID: 2771
		private bool _sorted;
	}
}
