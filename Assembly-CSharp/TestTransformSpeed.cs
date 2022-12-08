using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020001C0 RID: 448
public class TestTransformSpeed : MonoBehaviour
{
	// Token: 0x06000A9F RID: 2719 RVA: 0x0005CE74 File Offset: 0x0005B274
	private void Start()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < 10000; i++)
		{
			Vector3 position = base.transform.position;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log((float)stopwatch.ElapsedTicks / 10000000f);
		stopwatch.Reset();
		stopwatch.Start();
		for (int j = 0; j < 10000; j++)
		{
			Vector3 localPosition = base.transform.localPosition;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log((float)stopwatch.ElapsedTicks / 10000000f);
	}
}
