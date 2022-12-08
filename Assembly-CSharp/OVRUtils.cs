using System;
using UnityEngine;

// Token: 0x0200011C RID: 284
public class OVRUtils
{
	// Token: 0x06000655 RID: 1621 RVA: 0x0003FD80 File Offset: 0x0003E180
	public static void SetLocalTransformIdentity(ref GameObject gameObject)
	{
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0003FDB5 File Offset: 0x0003E1B5
	public static void SetLocalTransform(ref GameObject gameObject, ref Transform xfrm)
	{
		gameObject.transform.localPosition = xfrm.position;
		gameObject.transform.localRotation = xfrm.rotation;
		gameObject.transform.localScale = xfrm.localScale;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0003FDF0 File Offset: 0x0003E1F0
	public void Blit(RenderTexture source, RenderTexture dest, Material m, bool flip)
	{
		RenderTexture.active = dest;
		source.SetGlobalShaderProperty("_MainTex");
		GL.PushMatrix();
		GL.LoadOrtho();
		for (int i = 0; i < m.passCount; i++)
		{
			m.SetPass(i);
			this.DrawQuad(flip);
		}
		GL.PopMatrix();
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0003FE48 File Offset: 0x0003E248
	public void DrawQuad(bool flip)
	{
		GL.Begin(7);
		if (flip)
		{
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 1f, 0.1f);
		}
		else
		{
			GL.TexCoord2(0f, 0f);
			GL.Vertex3(0f, 0f, 0.1f);
			GL.TexCoord2(1f, 0f);
			GL.Vertex3(1f, 0f, 0.1f);
			GL.TexCoord2(1f, 1f);
			GL.Vertex3(1f, 1f, 0.1f);
			GL.TexCoord2(0f, 1f);
			GL.Vertex3(0f, 1f, 0.1f);
		}
		GL.End();
	}
}
