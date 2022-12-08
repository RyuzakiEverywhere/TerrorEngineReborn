using System;
using UnityEngine;

namespace SimpleAI.Navigation
{
	// Token: 0x0200018C RID: 396
	public static class PathSmoother
	{
		// Token: 0x0600096D RID: 2413 RVA: 0x00053D04 File Offset: 0x00052104
		public static Vector3[] Smooth(Vector3[] roughPath, Vector3 startPos, Vector3 goalPos, Vector3[] aLeftPortalEndPts, Vector3[] aRightPortalEndPts)
		{
			if (roughPath.Length <= 2)
			{
				return new Vector3[]
				{
					startPos,
					goalPos
				};
			}
			return PathSmoother.ApplyFunnelPathSmoothing(aLeftPortalEndPts, aRightPortalEndPts, roughPath.Length + 1, startPos, goalPos);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00053D50 File Offset: 0x00052150
		private static Vector3[] ApplyFunnelPathSmoothing(Vector3[] aLeftEndPts, Vector3[] aRightEndPts, int maxNumSmoothPts, Vector3 startPos, Vector3 destPos)
		{
			int num = aLeftEndPts.Length + aRightEndPts.Length + 2 + 2;
			Vector3[] array = new Vector3[num];
			array[0] = startPos;
			array[1] = startPos;
			int num2 = 0;
			for (int i = 2; i < num - 2; i += 2)
			{
				array[i] = aLeftEndPts[num2];
				array[i + 1] = aRightEndPts[num2];
				num2++;
			}
			array[num - 2] = destPos;
			array[num - 1] = destPos;
			Vector3[] array2 = new Vector3[maxNumSmoothPts];
			int num3 = PathSmoother.StringPull(array, num, array2, maxNumSmoothPts);
			Vector3[] array3 = new Vector3[num3];
			for (int j = 0; j < num3; j++)
			{
				array3[j] = array2[j];
			}
			return array3;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00053E48 File Offset: 0x00052248
		private static float TriArea2(Vector3 a, Vector3 b, Vector3 c)
		{
			float num = b.x - a.x;
			float num2 = b.z - a.z;
			float num3 = c.x - a.x;
			float num4 = c.z - a.z;
			return num3 * num2 - num * num4;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00053E9C File Offset: 0x0005229C
		public static int StringPull(Vector3[] portals, int nportalPts, Vector3[] pts, int maxPts)
		{
			int num = 0;
			Vector3 vector = portals[0];
			Vector3 vector2 = portals[2];
			Vector3 vector3 = portals[3];
			int num2 = 0;
			int num3 = 0;
			pts[0] = vector;
			num++;
			int num4 = 1;
			while (num4 < nportalPts / 2 && num < maxPts)
			{
				Vector3 vector4 = portals[num4 * 2];
				Vector3 vector5 = portals[num4 * 2 + 1];
				if (PathSmoother.TriArea2(vector, vector3, vector5) > 0f)
				{
					goto IL_D9;
				}
				if (PathUtils.AreVertsTheSame(vector, vector3) || PathSmoother.TriArea2(vector, vector2, vector5) > 0f)
				{
					vector3 = vector5;
					num3 = num4;
					goto IL_D9;
				}
				pts[num] = vector2;
				num++;
				vector = vector2;
				int num5 = num2;
				vector2 = vector;
				vector3 = vector;
				num2 = num5;
				num3 = num5;
				num4 = num5;
				IL_143:
				num4++;
				continue;
				IL_D9:
				if (PathSmoother.TriArea2(vector, vector2, vector4) < 0f)
				{
					goto IL_143;
				}
				if (PathUtils.AreVertsTheSame(vector, vector2) || PathSmoother.TriArea2(vector, vector3, vector4) < 0f)
				{
					vector2 = vector4;
					num2 = num4;
					goto IL_143;
				}
				pts[num] = vector3;
				num++;
				vector = vector3;
				num5 = num3;
				vector2 = vector;
				vector3 = vector;
				num2 = num5;
				num3 = num5;
				num4 = num5;
				goto IL_143;
			}
			if (num < maxPts)
			{
				pts[num] = portals[nportalPts - 1];
				num++;
			}
			return num;
		}
	}
}
