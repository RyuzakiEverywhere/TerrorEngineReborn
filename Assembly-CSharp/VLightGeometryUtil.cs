using System;
using UnityEngine;

// Token: 0x0200025F RID: 607
public static class VLightGeometryUtil
{
	// Token: 0x0600111F RID: 4383 RVA: 0x0006EA6C File Offset: 0x0006CE6C
	public static void RecalculateFrustrumPoints(Camera camera, float aspectRatio, out Vector3[] _frustrumPoints)
	{
		float far = camera.far;
		float near = camera.near;
		if (!camera.orthographic)
		{
			float num = 2f * Mathf.Tan(camera.fov * 0.5f * 0.017453292f) * near;
			float d = num * aspectRatio;
			float num2 = 2f * Mathf.Tan(camera.fov * 0.5f * 0.017453292f) * far;
			float d2 = num2 * aspectRatio;
			Vector3 a = Vector3.forward * far;
			Vector3 vector = a + Vector3.up * num2 / 2f - Vector3.right * d2 / 2f;
			Vector3 vector2 = a + Vector3.up * num2 / 2f + Vector3.right * d2 / 2f;
			Vector3 vector3 = a - Vector3.up * num2 / 2f - Vector3.right * d2 / 2f;
			Vector3 vector4 = a - Vector3.up * num2 / 2f + Vector3.right * d2 / 2f;
			Vector3 a2 = Vector3.forward * near;
			Vector3 vector5 = a2 + Vector3.up * num / 2f - Vector3.right * d / 2f;
			Vector3 vector6 = a2 + Vector3.up * num / 2f + Vector3.right * d / 2f;
			Vector3 vector7 = a2 - Vector3.up * num / 2f - Vector3.right * d / 2f;
			Vector3 vector8 = a2 - Vector3.up * num / 2f + Vector3.right * d / 2f;
			_frustrumPoints = new Vector3[8];
			_frustrumPoints[0] = vector5;
			_frustrumPoints[1] = vector;
			_frustrumPoints[2] = vector6;
			_frustrumPoints[3] = vector2;
			_frustrumPoints[4] = vector7;
			_frustrumPoints[5] = vector3;
			_frustrumPoints[6] = vector8;
			_frustrumPoints[7] = vector4;
		}
		else
		{
			float num3 = camera.orthographicSize * 0.5f;
			_frustrumPoints = new Vector3[8];
			_frustrumPoints[0] = new Vector3(-num3, num3, near);
			_frustrumPoints[1] = new Vector3(-num3, num3, far);
			_frustrumPoints[2] = new Vector3(num3, num3, near);
			_frustrumPoints[3] = new Vector3(num3, num3, far);
			_frustrumPoints[4] = new Vector3(-num3, -num3, near);
			_frustrumPoints[5] = new Vector3(-num3, -num3, far);
			_frustrumPoints[6] = new Vector3(num3, -num3, near);
			_frustrumPoints[7] = new Vector3(num3, -num3, far);
		}
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x0006EE1C File Offset: 0x0006D21C
	public static Vector3[] ClipPolygonAgainstPlane(Vector3[] subjectPolygon, Plane[] planes)
	{
		Array.Copy(subjectPolygon, VLightGeometryUtil._outputList, subjectPolygon.Length);
		int num = subjectPolygon.Length;
		foreach (Plane plane in planes)
		{
			Array.Copy(VLightGeometryUtil._outputList, VLightGeometryUtil._inputList, num);
			int num2 = num;
			num = 0;
			if (num2 != 0)
			{
				Vector3 vector = VLightGeometryUtil._inputList[num2 - 1];
				for (int j = 0; j < num2; j++)
				{
					Vector3 vector2 = VLightGeometryUtil._inputList[j];
					bool side = plane.GetSide(vector2);
					bool side2 = plane.GetSide(vector);
					if (side)
					{
						Vector3 vector3;
						if (!side2 && VLightGeometryUtil.ComputeIntersection(vector, vector2, plane, 0f, out vector3))
						{
							VLightGeometryUtil._outputList[num++] = vector3;
						}
						VLightGeometryUtil._outputList[num++] = vector2;
					}
					else if (side2)
					{
						Vector3 vector4;
						if (VLightGeometryUtil.ComputeIntersection(vector, vector2, plane, 0f, out vector4))
						{
							VLightGeometryUtil._outputList[num++] = vector4;
						}
						else
						{
							VLightGeometryUtil._outputList[num++] = vector2;
						}
					}
					vector = vector2;
				}
				if (num == 0)
				{
				}
			}
		}
		Vector3[] array = new Vector3[num];
		Array.Copy(VLightGeometryUtil._outputList, array, num);
		return array;
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x0006EFA8 File Offset: 0x0006D3A8
	public static bool ComputeIntersection(Vector3 start, Vector3 end, Plane plane, float e, out Vector3 result)
	{
		Vector3 rhs = start - end;
		float num = Vector3.Dot(plane.normal, start) + plane.distance;
		float num2 = Vector3.Dot(plane.normal, rhs);
		float num3 = num / num2;
		if (Mathf.Abs(num3) < e)
		{
			result = Vector3.zero;
		}
		else
		{
			if (num3 > 0f && num3 < 1f)
			{
				result = (end - start) * num3 + start;
				return true;
			}
			result = Vector3.zero;
		}
		return false;
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x0006F044 File Offset: 0x0006D444
	public static Vector4 Vector4Multiply(Vector4 right, Vector4 left)
	{
		return new Vector4(right.x * left.x, right.y * left.y, right.z * left.z, right.w * left.w);
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x0006F092 File Offset: 0x0006D492
	public static Vector4 Vector4Frac(Vector4 vector)
	{
		return new Vector4(VLightGeometryUtil.Frac(vector.x), VLightGeometryUtil.Frac(vector.y), VLightGeometryUtil.Frac(vector.z), VLightGeometryUtil.Frac(vector.w));
	}

	// Token: 0x06001124 RID: 4388 RVA: 0x0006F0C9 File Offset: 0x0006D4C9
	public static float Frac(float value)
	{
		return value - (float)Mathf.FloorToInt(value);
	}

	// Token: 0x06001125 RID: 4389 RVA: 0x0006F0D4 File Offset: 0x0006D4D4
	public static Color FloatToRGBA(float value)
	{
		Vector4 vector = new Vector4(1f, 255f, 65025f, 160581380f) * value;
		vector = VLightGeometryUtil.Vector4Frac(vector);
		vector -= VLightGeometryUtil.Vector4Multiply(new Vector4(vector.y, vector.z, vector.w, vector.w), new Vector4(0.003921569f, 0.003921569f, 0.003921569f, 0f));
		return vector;
	}

	// Token: 0x040011CB RID: 4555
	private static Vector3[] _outputList = new Vector3[20];

	// Token: 0x040011CC RID: 4556
	private static Vector3[] _inputList = new Vector3[20];
}
