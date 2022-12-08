using System;
using UnityEngine;

// Token: 0x0200011A RID: 282
[RequireComponent(typeof(CharacterController))]
public class OVRPlayerController : OVRComponent
{
	// Token: 0x06000636 RID: 1590 RVA: 0x0003F2C8 File Offset: 0x0003D6C8
	public new virtual void Awake()
	{
		base.Awake();
		this.Controller = base.gameObject.GetComponent<CharacterController>();
		if (this.Controller == null)
		{
			Debug.LogWarning("OVRPlayerController: No CharacterController attached.");
		}
		OVRCameraController[] componentsInChildren = base.gameObject.GetComponentsInChildren<OVRCameraController>();
		if (componentsInChildren.Length == 0)
		{
			Debug.LogWarning("OVRPlayerController: No OVRCameraController attached.");
		}
		else if (componentsInChildren.Length > 1)
		{
			Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraController attached.");
		}
		else
		{
			this.CameraController = componentsInChildren[0];
		}
		this.DirXform = null;
		Transform[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			if (componentsInChildren2[i].name == "ForwardDirection")
			{
				this.DirXform = componentsInChildren2[i];
				break;
			}
		}
		if (this.DirXform == null)
		{
			Debug.LogWarning("OVRPlayerController: ForwardDirection game object not found. Do not use.");
		}
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0003F3B2 File Offset: 0x0003D7B2
	public new virtual void Start()
	{
		base.Start();
		this.InitializeInputs();
		this.SetCameras();
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0003F3C8 File Offset: 0x0003D7C8
	public new virtual void Update()
	{
		base.Update();
		if (OVRDevice.SensorCount == 2)
		{
			Quaternion identity = Quaternion.identity;
			OVRDevice.GetPredictedOrientation(1, ref identity);
			this.YfromSensor2 = identity.eulerAngles.y;
		}
		this.UpdateMovement();
		Vector3 vector = Vector3.zero;
		float num = 1f + this.Damping * this.DeltaTime;
		this.MoveThrottle.x = this.MoveThrottle.x / num;
		this.MoveThrottle.y = ((this.MoveThrottle.y <= 0f) ? this.MoveThrottle.y : (this.MoveThrottle.y / num));
		this.MoveThrottle.z = this.MoveThrottle.z / num;
		vector += this.MoveThrottle * this.DeltaTime;
		if (this.Controller.isGrounded && this.FallSpeed <= 0f)
		{
			this.FallSpeed = Physics.gravity.y * (this.GravityModifier * 0.002f);
		}
		else
		{
			this.FallSpeed += Physics.gravity.y * (this.GravityModifier * 0.002f) * this.DeltaTime;
		}
		vector.y += this.FallSpeed * this.DeltaTime;
		if (this.Controller.isGrounded && this.MoveThrottle.y <= 0.001f)
		{
			float stepOffset = this.Controller.stepOffset;
			Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
			float d = Mathf.Max(stepOffset, vector2.magnitude);
			vector -= d * Vector3.up;
		}
		Vector3 vector3 = Vector3.Scale(this.Controller.transform.localPosition + vector, new Vector3(1f, 0f, 1f));
		this.Controller.Move(vector);
		Vector3 vector4 = Vector3.Scale(this.Controller.transform.localPosition, new Vector3(1f, 0f, 1f));
		if (vector3 != vector4)
		{
			this.MoveThrottle += (vector4 - vector3) / this.DeltaTime;
		}
		this.UpdatePlayerForwardDirTransform();
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0003F64C File Offset: 0x0003DA4C
	public virtual void UpdateMovement()
	{
		if (this.HaltUpdateMovement)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		this.MoveScale = 1f;
		if (Input.GetKey(KeyCode.W))
		{
			flag = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			flag2 = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
			flag4 = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			flag3 = true;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			flag = true;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			flag2 = true;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			flag4 = true;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			flag3 = true;
		}
		if ((flag && flag2) || (flag && flag3) || (flag4 && flag2) || (flag4 && flag3))
		{
			this.MoveScale = 0.70710677f;
		}
		if (!this.Controller.isGrounded)
		{
			this.MoveScale = 0f;
		}
		this.MoveScale *= this.DeltaTime;
		float num = this.Acceleration * 0.1f * this.MoveScale * this.MoveScaleMultiplier;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			num *= 2f;
		}
		if (this.DirXform != null)
		{
			if (flag)
			{
				this.MoveThrottle += this.DirXform.TransformDirection(Vector3.forward * num);
			}
			if (flag4)
			{
				this.MoveThrottle += this.DirXform.TransformDirection(Vector3.back * num) * this.BackAndSideDampen;
			}
			if (flag2)
			{
				this.MoveThrottle += this.DirXform.TransformDirection(Vector3.left * num) * this.BackAndSideDampen;
			}
			if (flag3)
			{
				this.MoveThrottle += this.DirXform.TransformDirection(Vector3.right * num) * this.BackAndSideDampen;
			}
		}
		float num2 = this.DeltaTime * this.RotationAmount * this.RotationScaleMultiplier;
		if (Input.GetKey(KeyCode.Q))
		{
			this.YRotation -= num2 * 0.5f;
		}
		if (Input.GetKey(KeyCode.E))
		{
			this.YRotation += num2 * 0.5f;
		}
		float num3 = 0f;
		if (!this.AllowMouseRotation)
		{
			num3 = Input.GetAxis("Mouse X") * num2 * 3.25f;
		}
		float num4 = OVRPlayerController.sDeltaRotationOld * 0f + num3 * 1f;
		this.YRotation += num4;
		OVRPlayerController.sDeltaRotationOld = num4;
		num = this.Acceleration * 0.1f * this.MoveScale * this.MoveScaleMultiplier;
		num *= 1f + OVRGamepadController.GPC_GetAxis(4);
		if (this.DirXform != null)
		{
			float num5 = OVRGamepadController.GPC_GetAxis(1);
			float num6 = OVRGamepadController.GPC_GetAxis(0);
			if (num5 > 0f)
			{
				this.MoveThrottle += num5 * this.DirXform.TransformDirection(Vector3.forward * num);
			}
			if (num5 < 0f)
			{
				this.MoveThrottle += Mathf.Abs(num5) * this.DirXform.TransformDirection(Vector3.back * num) * this.BackAndSideDampen;
			}
			if (num6 < 0f)
			{
				this.MoveThrottle += Mathf.Abs(num6) * this.DirXform.TransformDirection(Vector3.left * num) * this.BackAndSideDampen;
			}
			if (num6 > 0f)
			{
				this.MoveThrottle += num6 * this.DirXform.TransformDirection(Vector3.right * num) * this.BackAndSideDampen;
			}
		}
		float num7 = OVRGamepadController.GPC_GetAxis(2);
		this.YRotation += num7 * num2;
		this.SetCameras();
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0003FABC File Offset: 0x0003DEBC
	public virtual void UpdatePlayerForwardDirTransform()
	{
		if (this.DirXform != null && this.CameraController != null)
		{
			Quaternion lhs = Quaternion.identity;
			lhs = Quaternion.Euler(0f, this.YfromSensor2, 0f);
			this.DirXform.rotation = lhs * this.CameraController.transform.rotation;
		}
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x0003FB28 File Offset: 0x0003DF28
	public bool Jump()
	{
		if (!this.Controller.isGrounded)
		{
			return false;
		}
		this.MoveThrottle += new Vector3(0f, this.JumpForce, 0f);
		return true;
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0003FB63 File Offset: 0x0003DF63
	public void Stop()
	{
		this.Controller.Move(Vector3.zero);
		this.MoveThrottle = Vector3.zero;
		this.FallSpeed = 0f;
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x0003FB8C File Offset: 0x0003DF8C
	public void InitializeInputs()
	{
		this.OrientationOffset = base.transform.rotation;
		this.YRotation = 0f;
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0003FBAA File Offset: 0x0003DFAA
	public void SetCameras()
	{
		if (this.CameraController != null)
		{
			this.CameraController.SetOrientationOffset(this.OrientationOffset);
			this.CameraController.SetYRotation(this.YRotation);
		}
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0003FBDF File Offset: 0x0003DFDF
	public void GetMoveScaleMultiplier(ref float moveScaleMultiplier)
	{
		moveScaleMultiplier = this.MoveScaleMultiplier;
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x0003FBE9 File Offset: 0x0003DFE9
	public void SetMoveScaleMultiplier(float moveScaleMultiplier)
	{
		this.MoveScaleMultiplier = moveScaleMultiplier;
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x0003FBF2 File Offset: 0x0003DFF2
	public void GetRotationScaleMultiplier(ref float rotationScaleMultiplier)
	{
		rotationScaleMultiplier = this.RotationScaleMultiplier;
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0003FBFC File Offset: 0x0003DFFC
	public void SetRotationScaleMultiplier(float rotationScaleMultiplier)
	{
		this.RotationScaleMultiplier = rotationScaleMultiplier;
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x0003FC05 File Offset: 0x0003E005
	public void GetAllowMouseRotation(ref bool allowMouseRotation)
	{
		allowMouseRotation = this.AllowMouseRotation;
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x0003FC0F File Offset: 0x0003E00F
	public void SetAllowMouseRotation(bool allowMouseRotation)
	{
		this.AllowMouseRotation = allowMouseRotation;
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0003FC18 File Offset: 0x0003E018
	public void GetHaltUpdateMovement(ref bool haltUpdateMovement)
	{
		haltUpdateMovement = this.HaltUpdateMovement;
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0003FC22 File Offset: 0x0003E022
	public void SetHaltUpdateMovement(bool haltUpdateMovement)
	{
		this.HaltUpdateMovement = haltUpdateMovement;
	}

	// Token: 0x040008C0 RID: 2240
	protected CharacterController Controller;

	// Token: 0x040008C1 RID: 2241
	protected OVRCameraController CameraController;

	// Token: 0x040008C2 RID: 2242
	public float Acceleration = 0.1f;

	// Token: 0x040008C3 RID: 2243
	public float Damping = 0.15f;

	// Token: 0x040008C4 RID: 2244
	public float BackAndSideDampen = 0.5f;

	// Token: 0x040008C5 RID: 2245
	public float JumpForce = 0.3f;

	// Token: 0x040008C6 RID: 2246
	public float RotationAmount = 1.5f;

	// Token: 0x040008C7 RID: 2247
	public float GravityModifier = 0.379f;

	// Token: 0x040008C8 RID: 2248
	private float MoveScale = 1f;

	// Token: 0x040008C9 RID: 2249
	private Vector3 MoveThrottle = Vector3.zero;

	// Token: 0x040008CA RID: 2250
	private float FallSpeed;

	// Token: 0x040008CB RID: 2251
	private Quaternion OrientationOffset = Quaternion.identity;

	// Token: 0x040008CC RID: 2252
	private float YRotation;

	// Token: 0x040008CD RID: 2253
	protected Transform DirXform;

	// Token: 0x040008CE RID: 2254
	private float MoveScaleMultiplier = 1f;

	// Token: 0x040008CF RID: 2255
	private float RotationScaleMultiplier = 1f;

	// Token: 0x040008D0 RID: 2256
	private bool AllowMouseRotation = true;

	// Token: 0x040008D1 RID: 2257
	private bool HaltUpdateMovement;

	// Token: 0x040008D2 RID: 2258
	private float YfromSensor2;

	// Token: 0x040008D3 RID: 2259
	private static float sDeltaRotationOld;
}
