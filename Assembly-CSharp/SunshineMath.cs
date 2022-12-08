using System;
using UnityEngine;

// Token: 0x020001B4 RID: 436
public static class SunshineMath
{
	// Token: 0x06000A56 RID: 2646 RVA: 0x0005BDFC File Offset: 0x0005A1FC
	public static int UnityStyleLightmapResolution(SunshineLightResolutions resolution)
	{
		if (resolution == SunshineLightResolutions.Custom)
		{
			return 0;
		}
		int num = Mathf.Max(Screen.width, Screen.height);
		int num2 = Mathf.NextPowerOfTwo((int)((float)num * 1.9f));
		int a = 2048;
		if (SystemInfo.graphicsMemorySize >= 512)
		{
			a = 4096;
		}
		num2 = Mathf.Min(a, num2);
		if (resolution != SunshineLightResolutions.LowResolution)
		{
			if (resolution != SunshineLightResolutions.MediumResolution)
			{
				if (resolution == SunshineLightResolutions.VeryHighResolution)
				{
					num2 *= 2;
				}
			}
			else
			{
				num2 /= 2;
			}
		}
		else
		{
			num2 /= 4;
		}
		return Mathf.Min(a, num2);
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x0005BE91 File Offset: 0x0005A291
	public static float ShadowTexelWorldSize(float resolution, float orthographicSize)
	{
		return orthographicSize * 2f / resolution;
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x0005BE9C File Offset: 0x0005A29C
	public static Matrix4x4 ToRectSpaceProjection(Rect rect)
	{
		return Matrix4x4.TRS(new Vector3(rect.width * 0.5f + rect.x, rect.height * 0.5f + rect.y, 0f), Quaternion.identity, new Vector3(rect.width * 0.5f, rect.height * 0.5f, 1f));
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0005BF0B File Offset: 0x0005A30B
	public static void SetLinearDepthProjection(ref Matrix4x4 projection, float farClip)
	{
		projection.SetRow(2, new Vector4(0f, 0f, -1f / farClip, 0f));
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0005BF2F File Offset: 0x0005A32F
	public static Matrix4x4 SetLinearDepthProjection(Matrix4x4 projection, float farClip)
	{
		SunshineMath.SetLinearDepthProjection(ref projection, farClip);
		return projection;
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x0005BF3A File Offset: 0x0005A33A
	public static Vector2 xy(Vector3 self)
	{
		return new Vector2(self.x, self.y);
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x0005BF4F File Offset: 0x0005A34F
	public static Vector2 xy(Vector4 self)
	{
		return new Vector2(self.x, self.y);
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x0005BF64 File Offset: 0x0005A364
	public static Vector3 xyz(Vector4 self)
	{
		return new Vector3(self.x, self.y, self.z);
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x0005BF80 File Offset: 0x0005A380
	public static Vector3 xy0(Vector2 self)
	{
		return new Vector3(self.x, self.y, 0f);
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0005BF9A File Offset: 0x0005A39A
	public static Vector3 xy0(Vector3 self)
	{
		return new Vector3(self.x, self.y, 0f);
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x0005BFB4 File Offset: 0x0005A3B4
	public static Vector3 xy0(Vector4 self)
	{
		return new Vector3(self.x, self.y, 0f);
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x0005BFCE File Offset: 0x0005A3CE
	public static Vector4 xy00(Vector2 self)
	{
		return new Vector4(self.x, self.y, 0f, 0f);
	}

	// Token: 0x06000A62 RID: 2658 RVA: 0x0005BFED File Offset: 0x0005A3ED
	public static Vector4 xy00(Vector3 self)
	{
		return new Vector4(self.x, self.y, 0f, 0f);
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0005C00C File Offset: 0x0005A40C
	public static Vector4 xy00(Vector4 self)
	{
		return new Vector4(self.x, self.y, 0f, 0f);
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x0005C02B File Offset: 0x0005A42B
	public static Vector4 xyz0(Vector3 self)
	{
		return new Vector4(self.x, self.y, self.z, 0f);
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x0005C04C File Offset: 0x0005A44C
	public static Vector4 xyz0(Vector4 self)
	{
		return new Vector4(self.x, self.y, self.z, 0f);
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x0005C06D File Offset: 0x0005A46D
	public static int RelativeResolutionDivisor(SunshineRelativeResolutions resolution)
	{
		switch (resolution)
		{
		case SunshineRelativeResolutions.Full:
			return 1;
		case SunshineRelativeResolutions.Half:
			return 2;
		case SunshineRelativeResolutions.Third:
			return 3;
		case SunshineRelativeResolutions.Quarter:
			return 4;
		case SunshineRelativeResolutions.Fifth:
			return 5;
		case SunshineRelativeResolutions.Sixth:
			return 6;
		case SunshineRelativeResolutions.Seventh:
			return 7;
		case SunshineRelativeResolutions.Eighth:
			return 8;
		default:
			return 1;
		}
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x0005C0AB File Offset: 0x0005A4AB
	public static float ShadowKernelRadius(SunshineShadowFilters filter)
	{
		switch (filter)
		{
		case SunshineShadowFilters.PCF2x2:
			return 1.414214f;
		case SunshineShadowFilters.PCF3x3:
			return 2.12132f;
		case SunshineShadowFilters.PCF4x4:
			return 2.828427f;
		}
		return 0.7071068f;
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x0005C0DF File Offset: 0x0005A4DF
	public static float QuantizeValue(float number, float step)
	{
		return Mathf.Floor(number / step + 0.5f) * step;
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x0005C0F4 File Offset: 0x0005A4F4
	public static float QuantizeValueWithoutFlicker(float number, float step, float lastResult)
	{
		float num = SunshineMath.QuantizeValue(number, step);
		if (Mathf.Abs(num - number) * 4f < Mathf.Abs(lastResult - number))
		{
			return num;
		}
		return lastResult;
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x0005C127 File Offset: 0x0005A527
	public static float QuantizeValue(float number, int resolution)
	{
		return SunshineMath.QuantizeValue(number, 1f / (float)resolution);
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x0005C137 File Offset: 0x0005A537
	public static float QuantizeValueWithoutFlicker(float number, int resolution, float lastResult)
	{
		return SunshineMath.QuantizeValueWithoutFlicker(number, 1f / (float)resolution, lastResult);
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x0005C148 File Offset: 0x0005A548
	public static float RadialClipCornerRatio(Camera cam)
	{
		Ray ray = cam.ViewportPointToRay(new Vector3(0f, 0f, 0f));
		return cam.transform.InverseTransformDirection(ray.direction).z;
	}

	// Token: 0x06000A6D RID: 2669 RVA: 0x0005C18C File Offset: 0x0005A58C
	public static float MinRadiusSq(Vector3 origin, Vector3[] points)
	{
		float num = 0f;
		for (int i = 0; i < points.Length; i++)
		{
			float sqrMagnitude = (points[i] - origin).sqrMagnitude;
			if (sqrMagnitude > num)
			{
				num = sqrMagnitude;
			}
		}
		return num;
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x0005C1D8 File Offset: 0x0005A5D8
	public static SunshineMath.BoundingSphere FrustumBoundingSphereBinarySearch(Camera camera, float nearClip, float farClip, bool radial, float radialPadding, float maxError = 0.01f, int maxSteps = 100)
	{
		float num = SunshineMath.RadialClipCornerRatio(camera);
		float z = (!radial) ? nearClip : (nearClip * num);
		float z2 = (!radial) ? farClip : (farClip * num);
		Vector3 a = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, nearClip));
		Vector3 b = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, z2));
		Vector3 vector = camera.ViewportToWorldPoint(new Vector3(0f, 0f, z));
		Vector3 vector2 = camera.ViewportToWorldPoint(new Vector3(1f, 1f, farClip));
		Vector3 vector3 = (!radial) ? vector2 : camera.ViewportToWorldPoint(new Vector3(1f, 1f, z2));
		SunshineMath._frustumTestPoints[0] = vector;
		SunshineMath._frustumTestPoints[1] = vector3;
		float num2 = float.MaxValue;
		Vector3 origin = Vector3.zero;
		float num3 = 0f;
		float num4 = 0.2f;
		for (int i = 0; i < maxSteps; i++)
		{
			Vector3 vector4 = Vector3.Lerp(a, b, num3);
			float num5 = SunshineMath.MinRadiusSq(vector4, SunshineMath._frustumTestPoints);
			if (num5 < num2)
			{
				num2 = num5;
				origin = vector4;
			}
			else
			{
				num4 *= -0.5f;
				if (Mathf.Abs(num4) < maxError)
				{
					break;
				}
			}
			num3 += num4;
		}
		return new SunshineMath.BoundingSphere
		{
			origin = origin,
			radius = Mathf.Sqrt(num2) + radialPadding
		};
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x0005C360 File Offset: 0x0005A760
	public static void SetupShadowCamera(Light light, Camera lightCamera, Camera eyeCamera, float eyeNearClip, float eyeFarClip, float paddingZ, float paddingRadius, int snapResolution, ref SunshineMath.BoundingSphere totalShadowBounds, ref SunshineMath.ShadowCameraTemporalData temporalData)
	{
		Transform transform = lightCamera.transform;
		SunshineMath.BoundingSphere boundingSphere = default(SunshineMath.BoundingSphere);
		if (Sunshine.Instance.UsingCustomBounds)
		{
			boundingSphere = Sunshine.Instance.CustomBounds;
		}
		else
		{
			boundingSphere = SunshineMath.FrustumBoundingSphereBinarySearch(eyeCamera, eyeNearClip, eyeFarClip, true, paddingRadius, 0.01f, 20);
		}
		float num = SunshineMath.QuantizeValueWithoutFlicker(boundingSphere.radius, 100, temporalData.boundingRadius);
		temporalData.boundingRadius = num;
		float num2 = num * 2f;
		lightCamera.aspect = 1f;
		lightCamera.orthographic = true;
		lightCamera.nearClipPlane = eyeCamera.nearClipPlane;
		lightCamera.farClipPlane = (totalShadowBounds.radius + paddingZ + lightCamera.nearClipPlane) * 2f;
		lightCamera.orthographicSize = num2 * 0.5f;
		transform.rotation = Quaternion.LookRotation(light.transform.forward);
		transform.position = boundingSphere.origin;
		Vector3 vector = transform.InverseTransformPoint(Vector3.zero);
		float step = num2 / (float)snapResolution;
		vector.x = SunshineMath.QuantizeValueWithoutFlicker(vector.x, step, temporalData.lightWorldOrigin.x);
		vector.y = SunshineMath.QuantizeValueWithoutFlicker(vector.y, step, temporalData.lightWorldOrigin.y);
		temporalData.lightWorldOrigin = vector;
		transform.position -= transform.TransformPoint(vector);
		Vector3 vector2 = transform.InverseTransformPoint(totalShadowBounds.origin);
		transform.position += transform.forward * (vector2.z - (totalShadowBounds.radius + lightCamera.nearClipPlane + paddingZ));
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x0005C4FC File Offset: 0x0005A8FC
	public static void ShadowCoordDataInRect(ref Vector4 shadowCoordData, ref Rect rect)
	{
		shadowCoordData.x = Mathf.Lerp(rect.xMin, rect.xMax, shadowCoordData.x);
		shadowCoordData.y = Mathf.Lerp(rect.yMin, rect.yMax, shadowCoordData.y);
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x0005C538 File Offset: 0x0005A938
	public static void ShadowCoordDataRayInRect(ref Vector4 shadowCoordDataRay, ref Rect rect)
	{
		shadowCoordDataRay.x *= rect.width;
		shadowCoordDataRay.y *= rect.height;
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x0005C560 File Offset: 0x0005A960
	public static LayerMask SubtractMask(LayerMask mask, LayerMask subtract)
	{
		return mask & ~subtract;
	}

	// Token: 0x04000C67 RID: 3175
	public static readonly Matrix4x4 ToTextureSpaceProjection = Matrix4x4.TRS(new Vector3(0.5f, 0.5f, 0f), Quaternion.identity, new Vector3(0.5f, 0.5f, 1f));

	// Token: 0x04000C68 RID: 3176
	public static readonly Rect[][] CascadeViewportArrangements = new Rect[][]
	{
		new Rect[]
		{
			new Rect(0f, 0f, 1f, 1f)
		},
		new Rect[]
		{
			new Rect(0f, 0f, 1f, 0.5f),
			new Rect(0f, 0.5f, 1f, 0.5f)
		},
		new Rect[]
		{
			new Rect(0f, 0f, 0.5f, 1f),
			new Rect(0.5f, 0f, 0.5f, 0.5f),
			new Rect(0.5f, 0.5f, 0.5f, 0.5f)
		},
		new Rect[]
		{
			new Rect(0f, 0f, 0.5f, 0.5f),
			new Rect(0f, 0.5f, 0.5f, 0.5f),
			new Rect(0.5f, 0f, 0.5f, 0.5f),
			new Rect(0.5f, 0.5f, 0.5f, 0.5f)
		}
	};

	// Token: 0x04000C69 RID: 3177
	private static Vector3[] _frustumTestPoints = new Vector3[2];

	// Token: 0x020001B5 RID: 437
	public struct BoundingSphere
	{
		// Token: 0x04000C6A RID: 3178
		public Vector3 origin;

		// Token: 0x04000C6B RID: 3179
		public float radius;
	}

	// Token: 0x020001B6 RID: 438
	public struct ShadowCameraTemporalData
	{
		// Token: 0x04000C6C RID: 3180
		public float boundingRadius;

		// Token: 0x04000C6D RID: 3181
		public Vector3 lightWorldOrigin;
	}
}
