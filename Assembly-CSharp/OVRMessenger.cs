using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000116 RID: 278
internal static class OVRMessenger
{
	// Token: 0x0600061B RID: 1563 RVA: 0x0003EC34 File Offset: 0x0003D034
	public static void MarkAsPermanent(string eventType)
	{
		OVRMessenger.permanentMessages.Add(eventType);
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x0003EC44 File Offset: 0x0003D044
	public static void Cleanup()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Delegate> keyValuePair in OVRMessenger.eventTable)
		{
			bool flag = false;
			foreach (string b in OVRMessenger.permanentMessages)
			{
				if (keyValuePair.Key == b)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (string key in list)
		{
			OVRMessenger.eventTable.Remove(key);
		}
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0003ED60 File Offset: 0x0003D160
	public static void PrintEventTable()
	{
		Debug.Log("\t\t\t=== MESSENGER PrintEventTable ===");
		foreach (KeyValuePair<string, Delegate> keyValuePair in OVRMessenger.eventTable)
		{
			Debug.Log(string.Concat(new object[]
			{
				"\t\t\t",
				keyValuePair.Key,
				"\t\t",
				keyValuePair.Value
			}));
		}
		Debug.Log("\n");
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x0003EDFC File Offset: 0x0003D1FC
	public static void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
		if (!OVRMessenger.eventTable.ContainsKey(eventType))
		{
			OVRMessenger.eventTable.Add(eventType, null);
		}
		Delegate @delegate = OVRMessenger.eventTable[eventType];
		if (@delegate != null && @delegate.GetType() != listenerBeingAdded.GetType())
		{
			throw new OVRMessenger.ListenerException(string.Format("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, @delegate.GetType().Name, listenerBeingAdded.GetType().Name));
		}
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x0003EE70 File Offset: 0x0003D270
	public static void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
	{
		if (!OVRMessenger.eventTable.ContainsKey(eventType))
		{
			throw new OVRMessenger.ListenerException(string.Format("Attempting to remove listener for type \"{0}\" but Messenger doesn't know about this event type.", eventType));
		}
		Delegate @delegate = OVRMessenger.eventTable[eventType];
		if (@delegate == null)
		{
			throw new OVRMessenger.ListenerException(string.Format("Attempting to remove listener with for event type \"{0}\" but current listener is null.", eventType));
		}
		if (@delegate.GetType() != listenerBeingRemoved.GetType())
		{
			throw new OVRMessenger.ListenerException(string.Format("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, @delegate.GetType().Name, listenerBeingRemoved.GetType().Name));
		}
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0003EEFE File Offset: 0x0003D2FE
	public static void OnListenerRemoved(string eventType)
	{
		if (OVRMessenger.eventTable[eventType] == null)
		{
			OVRMessenger.eventTable.Remove(eventType);
		}
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0003EF1C File Offset: 0x0003D31C
	public static void OnBroadcasting(string eventType)
	{
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0003EF1E File Offset: 0x0003D31E
	public static OVRMessenger.BroadcastException CreateBroadcastSignatureException(string eventType)
	{
		return new OVRMessenger.BroadcastException(string.Format("Broadcasting message \"{0}\" but listeners have a different signature than the broadcaster.", eventType));
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0003EF30 File Offset: 0x0003D330
	public static void AddListener(string eventType, OVRCallback handler)
	{
		OVRMessenger.OnListenerAdding(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback)Delegate.Combine((OVRCallback)OVRMessenger.eventTable[eventType], handler);
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x0003EF5F File Offset: 0x0003D35F
	public static void AddListener<T>(string eventType, OVRCallback<T> handler)
	{
		OVRMessenger.OnListenerAdding(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T>)Delegate.Combine((OVRCallback<T>)OVRMessenger.eventTable[eventType], handler);
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x0003EF8E File Offset: 0x0003D38E
	public static void AddListener<T, U>(string eventType, OVRCallback<T, U> handler)
	{
		OVRMessenger.OnListenerAdding(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T, U>)Delegate.Combine((OVRCallback<T, U>)OVRMessenger.eventTable[eventType], handler);
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x0003EFBD File Offset: 0x0003D3BD
	public static void AddListener<T, U, V>(string eventType, OVRCallback<T, U, V> handler)
	{
		OVRMessenger.OnListenerAdding(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T, U, V>)Delegate.Combine((OVRCallback<T, U, V>)OVRMessenger.eventTable[eventType], handler);
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0003EFEC File Offset: 0x0003D3EC
	public static void RemoveListener(string eventType, OVRCallback handler)
	{
		OVRMessenger.OnListenerRemoving(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback)Delegate.Remove((OVRCallback)OVRMessenger.eventTable[eventType], handler);
		OVRMessenger.OnListenerRemoved(eventType);
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0003F021 File Offset: 0x0003D421
	public static void RemoveListener<T>(string eventType, OVRCallback<T> handler)
	{
		OVRMessenger.OnListenerRemoving(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T>)Delegate.Remove((OVRCallback<T>)OVRMessenger.eventTable[eventType], handler);
		OVRMessenger.OnListenerRemoved(eventType);
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0003F056 File Offset: 0x0003D456
	public static void RemoveListener<T, U>(string eventType, OVRCallback<T, U> handler)
	{
		OVRMessenger.OnListenerRemoving(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T, U>)Delegate.Remove((OVRCallback<T, U>)OVRMessenger.eventTable[eventType], handler);
		OVRMessenger.OnListenerRemoved(eventType);
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x0003F08B File Offset: 0x0003D48B
	public static void RemoveListener<T, U, V>(string eventType, OVRCallback<T, U, V> handler)
	{
		OVRMessenger.OnListenerRemoving(eventType, handler);
		OVRMessenger.eventTable[eventType] = (OVRCallback<T, U, V>)Delegate.Remove((OVRCallback<T, U, V>)OVRMessenger.eventTable[eventType], handler);
		OVRMessenger.OnListenerRemoved(eventType);
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0003F0C0 File Offset: 0x0003D4C0
	public static void Broadcast(string eventType)
	{
		OVRMessenger.OnBroadcasting(eventType);
		Delegate @delegate;
		if (OVRMessenger.eventTable.TryGetValue(eventType, out @delegate))
		{
			OVRCallback ovrcallback = @delegate as OVRCallback;
			if (ovrcallback == null)
			{
				throw OVRMessenger.CreateBroadcastSignatureException(eventType);
			}
			ovrcallback();
		}
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x0003F104 File Offset: 0x0003D504
	public static void Broadcast<T>(string eventType, T arg1)
	{
		OVRMessenger.OnBroadcasting(eventType);
		Delegate @delegate;
		if (OVRMessenger.eventTable.TryGetValue(eventType, out @delegate))
		{
			OVRCallback<T> ovrcallback = @delegate as OVRCallback<T>;
			if (ovrcallback == null)
			{
				throw OVRMessenger.CreateBroadcastSignatureException(eventType);
			}
			ovrcallback(arg1);
		}
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0003F14C File Offset: 0x0003D54C
	public static void Broadcast<T, U>(string eventType, T arg1, U arg2)
	{
		OVRMessenger.OnBroadcasting(eventType);
		Delegate @delegate;
		if (OVRMessenger.eventTable.TryGetValue(eventType, out @delegate))
		{
			OVRCallback<T, U> ovrcallback = @delegate as OVRCallback<T, U>;
			if (ovrcallback == null)
			{
				throw OVRMessenger.CreateBroadcastSignatureException(eventType);
			}
			ovrcallback(arg1, arg2);
		}
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0003F194 File Offset: 0x0003D594
	public static void Broadcast<T, U, V>(string eventType, T arg1, U arg2, V arg3)
	{
		OVRMessenger.OnBroadcasting(eventType);
		Delegate @delegate;
		if (OVRMessenger.eventTable.TryGetValue(eventType, out @delegate))
		{
			OVRCallback<T, U, V> ovrcallback = @delegate as OVRCallback<T, U, V>;
			if (ovrcallback == null)
			{
				throw OVRMessenger.CreateBroadcastSignatureException(eventType);
			}
			ovrcallback(arg1, arg2, arg3);
		}
	}

	// Token: 0x040008BD RID: 2237
	private static MessengerHelper messengerHelper = new GameObject("MessengerHelper").AddComponent<MessengerHelper>();

	// Token: 0x040008BE RID: 2238
	public static Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

	// Token: 0x040008BF RID: 2239
	public static List<string> permanentMessages = new List<string>();

	// Token: 0x02000117 RID: 279
	public class BroadcastException : Exception
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x0003F205 File Offset: 0x0003D605
		public BroadcastException(string msg) : base(msg)
		{
		}
	}

	// Token: 0x02000118 RID: 280
	public class ListenerException : Exception
	{
		// Token: 0x06000631 RID: 1585 RVA: 0x0003F20E File Offset: 0x0003D60E
		public ListenerException(string msg) : base(msg)
		{
		}
	}
}
