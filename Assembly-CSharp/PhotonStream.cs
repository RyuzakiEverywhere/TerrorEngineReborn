using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200013F RID: 319
public class PhotonStream
{
	// Token: 0x06000757 RID: 1879 RVA: 0x00047EFB File Offset: 0x000462FB
	public PhotonStream(bool write, object[] incomingData)
	{
		this.write = write;
		if (incomingData == null)
		{
			this.data = new List<object>();
		}
		else
		{
			this.data = new List<object>(incomingData);
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000758 RID: 1880 RVA: 0x00047F2C File Offset: 0x0004632C
	public bool isWriting
	{
		get
		{
			return this.write;
		}
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000759 RID: 1881 RVA: 0x00047F34 File Offset: 0x00046334
	public bool isReading
	{
		get
		{
			return !this.write;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x0600075A RID: 1882 RVA: 0x00047F3F File Offset: 0x0004633F
	public int Count
	{
		get
		{
			return this.data.Count;
		}
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00047F4C File Offset: 0x0004634C
	public object ReceiveNext()
	{
		if (this.write)
		{
			Debug.LogError("Error: you cannot read this stream that you are writing!");
			return null;
		}
		object result = this.data[(int)this.currentItem];
		this.currentItem += 1;
		return result;
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00047F92 File Offset: 0x00046392
	public void SendNext(object obj)
	{
		if (!this.write)
		{
			Debug.LogError("Error: you cannot write/send to this stream that you are reading!");
			return;
		}
		this.data.Add(obj);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00047FB6 File Offset: 0x000463B6
	public object[] ToArray()
	{
		return this.data.ToArray();
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00047FC4 File Offset: 0x000463C4
	public void Serialize(ref bool myBool)
	{
		if (this.write)
		{
			this.data.Add(myBool);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			myBool = (bool)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00048030 File Offset: 0x00046430
	public void Serialize(ref int myInt)
	{
		if (this.write)
		{
			this.data.Add(myInt);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			myInt = (int)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0004809C File Offset: 0x0004649C
	public void Serialize(ref string value)
	{
		if (this.write)
		{
			this.data.Add(value);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			value = (string)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00048104 File Offset: 0x00046504
	public void Serialize(ref char value)
	{
		if (this.write)
		{
			this.data.Add(value);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			value = (char)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00048170 File Offset: 0x00046570
	public void Serialize(ref short value)
	{
		if (this.write)
		{
			this.data.Add(value);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			value = (short)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x000481DC File Offset: 0x000465DC
	public void Serialize(ref float obj)
	{
		if (this.write)
		{
			this.data.Add(obj);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			obj = (float)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x00048248 File Offset: 0x00046648
	public void Serialize(ref PhotonPlayer obj)
	{
		if (this.write)
		{
			this.data.Add(obj);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			obj = (PhotonPlayer)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x000482B0 File Offset: 0x000466B0
	public void Serialize(ref Vector3 obj)
	{
		if (this.write)
		{
			this.data.Add(obj);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			obj = (Vector3)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00048324 File Offset: 0x00046724
	public void Serialize(ref Vector2 obj)
	{
		if (this.write)
		{
			this.data.Add(obj);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			obj = (Vector2)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x00048398 File Offset: 0x00046798
	public void Serialize(ref Quaternion obj)
	{
		if (this.write)
		{
			this.data.Add(obj);
		}
		else if (this.data.Count > (int)this.currentItem)
		{
			obj = (Quaternion)this.data[(int)this.currentItem];
			this.currentItem += 1;
		}
	}

	// Token: 0x040009DD RID: 2525
	private bool write;

	// Token: 0x040009DE RID: 2526
	internal List<object> data;

	// Token: 0x040009DF RID: 2527
	private byte currentItem;
}
