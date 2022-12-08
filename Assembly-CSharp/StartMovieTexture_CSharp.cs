using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class StartMovieTexture_CSharp : MonoBehaviour
{
	// Token: 0x0600035E RID: 862 RVA: 0x0001FF18 File Offset: 0x0001E318
	private void OnGUI()
	{
		int num = Screen.width - 210;
		if (GUI.Button(new Rect((float)num, 10f, 200f, 30f), "Start sphere parallax movies C#"))
		{
			base.SendMessage("StartMovies");
		}
		if (GUI.Button(new Rect((float)num, 45f, 200f, 30f), "Stop sphere parallax movies C#"))
		{
			base.SendMessage("StopMovies");
		}
		if (GUI.Button(new Rect((float)(num - 310), 10f, 300f, 30f), "Start all videos with delay 1 sec"))
		{
			PlayMovieTexture.StartAllMovies(1f);
		}
		if (GUI.Button(new Rect((float)(num - 310), 45f, 300f, 30f), "Stop all videos"))
		{
			PlayMovieTexture.StopAllMovies();
		}
	}

	// Token: 0x040003C4 RID: 964
	public GameObject target;
}
