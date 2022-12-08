using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class ErrorLog : MonoBehaviour
{
	// Token: 0x06000076 RID: 118 RVA: 0x000088E8 File Offset: 0x00006CE8
	private IEnumerator Start()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 4)
		{
			this.ismm = true;
		}
		else
		{
			yield return new WaitForSeconds(0.1f);
		}
		yield break;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00008903 File Offset: 0x00006D03
	private void Update()
	{
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00008908 File Offset: 0x00006D08
	public void CheckNow()
	{
		this.totalerrors = 0;
		this.errors = string.Empty;
		this.modelerror = false;
		this.poserror = false;
		this.triggererror = false;
		this.timererror = false;
		this.audioerror = false;
		PositionAndScale[] array = UnityEngine.Object.FindObjectsOfType(typeof(PositionAndScale)) as PositionAndScale[];
		if (array.Length > 0)
		{
			foreach (PositionAndScale positionAndScale in array)
			{
				Regex regex = new Regex("[^0-9.-]");
				if (regex.IsMatch(positionAndScale.posx))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.posx = regex.Replace(positionAndScale.posx, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.posy))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.posy = regex.Replace(positionAndScale.posy, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.posz))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.posz = regex.Replace(positionAndScale.posz, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.rotx))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.rotx = regex.Replace(positionAndScale.rotx, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.roty))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.roty = regex.Replace(positionAndScale.roty, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.rotz))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.rotz = regex.Replace(positionAndScale.rotz, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.scalex))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.scalex = regex.Replace(positionAndScale.scalex, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.scaley))
				{
					positionAndScale.scaley = regex.Replace(positionAndScale.scaley, string.Empty);
				}
				if (regex.IsMatch(positionAndScale.scalez))
				{
					this.poserror = true;
					this.totalerrors++;
					positionAndScale.scalez = regex.Replace(positionAndScale.scalez, string.Empty);
				}
				if (positionAndScale.gameObject.GetComponent<ModelProperties>() && !this.ignoreModels && positionAndScale.gameObject.GetComponent<Renderer>().material.mainTexture == null)
				{
					this.modelerror = true;
					this.totalerrors++;
					UnityEngine.Object.Destroy(positionAndScale.gameObject);
				}
				if (positionAndScale.gameObject.GetComponent<TriggerProperties>())
				{
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().playsound)
					{
						string path = Application.dataPath + "/Audio/" + positionAndScale.gameObject.GetComponent<TriggerProperties>().soundpath;
						if (!File.Exists(path))
						{
							this.triggererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TriggerProperties>().playsound = false;
						}
					}
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().displayimg)
					{
						string path2 = Application.dataPath + "/Images/" + positionAndScale.gameObject.GetComponent<TriggerProperties>().imgpath;
						if (!File.Exists(path2))
						{
							this.triggererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TriggerProperties>().displayimg = false;
						}
					}
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().playvideo)
					{
						string path3 = Application.dataPath + "/Video/" + positionAndScale.gameObject.GetComponent<TriggerProperties>().videopath;
						if (!File.Exists(path3))
						{
							this.triggererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TriggerProperties>().playvideo = false;
						}
					}
				}
				if (positionAndScale.gameObject.GetComponent<AudioProperties>())
				{
					string path4 = Application.dataPath + "/Audio/" + positionAndScale.gameObject.GetComponent<AudioProperties>().audioname;
					if (!File.Exists(path4))
					{
						this.audioerror = true;
						this.totalerrors++;
						UnityEngine.Object.Destroy(positionAndScale.gameObject);
					}
				}
				if (positionAndScale.gameObject.GetComponent<CinematicProperties>())
				{
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<CinematicProperties>().xpos))
					{
						this.cinematicerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<CinematicProperties>().xpos = regex.Replace(positionAndScale.gameObject.GetComponent<CinematicProperties>().xpos, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<CinematicProperties>().ypos))
					{
						this.cinematicerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<CinematicProperties>().ypos = regex.Replace(positionAndScale.gameObject.GetComponent<CinematicProperties>().ypos, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<CinematicProperties>().zpos))
					{
						this.cinematicerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<CinematicProperties>().zpos = regex.Replace(positionAndScale.gameObject.GetComponent<CinematicProperties>().zpos, string.Empty);
					}
				}
				if (positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>())
				{
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().walkspeed))
					{
						this.playerprefserror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().walkspeed = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().walkspeed, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().runspeed))
					{
						this.playerprefserror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().runspeed = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().runspeed, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().jumpheight))
					{
						this.playerprefserror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().jumpheight = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerPrefsProperties>().jumpheight, string.Empty);
					}
				}
				if (positionAndScale.gameObject.GetComponent<PlayerProperties>())
				{
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerProperties>().walkspeed))
					{
						this.playerstartpointerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerProperties>().walkspeed = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerProperties>().walkspeed, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerProperties>().runspeed))
					{
						this.playerstartpointerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerProperties>().runspeed = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerProperties>().runspeed, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<PlayerProperties>().jumpheight))
					{
						this.playerstartpointerror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<PlayerProperties>().jumpheight = regex.Replace(positionAndScale.gameObject.GetComponent<PlayerProperties>().jumpheight, string.Empty);
					}
				}
				if (positionAndScale.gameObject.GetComponent<AdvTeleportProperties>())
				{
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().xpos))
					{
						this.advteleporterror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().xpos = regex.Replace(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().xpos, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().ypos))
					{
						this.advteleporterror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().ypos = regex.Replace(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().ypos, string.Empty);
					}
					if (regex.IsMatch(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().zpos))
					{
						this.advteleporterror = true;
						this.totalerrors++;
						positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().zpos = regex.Replace(positionAndScale.gameObject.GetComponent<AdvTeleportProperties>().zpos, string.Empty);
					}
				}
				if (positionAndScale.gameObject.GetComponent<TimerProperties>())
				{
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().playsound)
					{
						string path5 = Application.dataPath + "/Audio/" + positionAndScale.gameObject.GetComponent<TimerProperties>().soundpath;
						if (!File.Exists(path5))
						{
							this.timererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TimerProperties>().playsound = false;
						}
					}
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().displayimg)
					{
						string path6 = Application.dataPath + "/Images/" + positionAndScale.gameObject.GetComponent<TimerProperties>().imgpath;
						if (!File.Exists(path6))
						{
							this.timererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TimerProperties>().displayimg = false;
						}
					}
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().playvideo)
					{
						string path7 = Application.dataPath + "/Video/" + positionAndScale.gameObject.GetComponent<TimerProperties>().videopath;
						if (!File.Exists(path7))
						{
							this.timererror = true;
							this.totalerrors++;
							positionAndScale.gameObject.GetComponent<TimerProperties>().playvideo = false;
						}
					}
				}
			}
		}
		if (this.modelerror)
		{
			this.errors += "<b>ERROR:</b> Could not load model(s) or texture(s) from model folder, model(s) or texture(s) could be missing.  <b>Deleted objects(s) with this error!</b>\n";
		}
		if (this.poserror)
		{
			this.errors += "<b>ERROR:</b> Object(s) had letters in Position, Rotation and/or Scale XYZ co-ordinate(s).  <b>Removed letters from objects(s) with this error!</b>\n";
		}
		if (this.triggererror)
		{
			this.errors += "<b>ERROR:</b> Trigger Zone(s) is missing file for 'play audio', 'display image' and/or 'play video'.  <b>Disabled 'play audio', 'display image' and/or 'play video' from Trigger Zones(s) with this error!</b>\n";
		}
		if (this.timererror)
		{
			this.errors += "<b>ERROR:</b> Timer Zone(s) is missing file for 'play audio', 'display image' and/or 'play video'.  <b>Disabled 'play audio', 'display image' and/or 'play video' from Timer Zones(s) with this error!</b>\n";
		}
		if (this.audioerror)
		{
			this.errors += "<b>ERROR:</b> Audio Zone(s) could not load audio file(s) from audio folder, audio files(s) could be missing.  <b>Deleted objects(s) with this error!</b>\n";
		}
		if (this.cinematicerror)
		{
			this.errors += "<b>ERROR:</b> Cinematic Camera(s) had letters in Position, Rotation and/or Scale XYZ Camera co-ordinate(s).  <b>Removed letters from Cinematic Camera(s) with this error!</b>\n";
		}
		if (this.playerstartpointerror)
		{
			this.errors += "<b>ERROR:</b> Player Start Point(s) had letters in walk speed, run speed and/or jump height.  <b>Removed letters from Player Start Point(s) with this error!</b>\n";
		}
		if (this.playerprefserror)
		{
			this.errors += "<b>ERROR:</b> Player Prefs Zone(s) had letters in walk speed, run speed and/or jump height.  <b>Removed letters from Player Prefs Zone(s) with this error!</b>\n";
		}
		if (this.advteleporterror)
		{
			this.errors += "<b>ERROR:</b> Advanced Teleport Zone(s) had letters in Position, Rotation and/or Scale XYZ teleport co-ordinate(s).  <b>Removed letters from Advanced Teleport Zone(s) with this error!</b>\n";
		}
		this.showlog = true;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000094EC File Offset: 0x000078EC
	private void ErrorWindow(int windowID)
	{
		GUI.Label(new Rect(12f, 40f, 376f, 22f), this.totalerrors.ToString() + " Errors found and fixed!");
		this.scrollPosition = GUI.BeginScrollView(new Rect(0f, 80f, 370f, 85f), this.scrollPosition, new Rect(0f, 0f, 350f, 350f));
		GUI.TextArea(new Rect(15f, 0f, 350f, 350f), this.errors);
		GUI.EndScrollView();
	}

	// Token: 0x0600007A RID: 122 RVA: 0x000095A0 File Offset: 0x000079A0
	private void OnGUI()
	{
		GUI.skin = this.guiSkin;
		if (this.ismm)
		{
			if (this.showlog)
			{
				GUI.Window(21, new Rect(2f, (float)(Screen.height - 220), 400f, 200f), new GUI.WindowFunction(this.ErrorWindow), "Error Log");
			}
			if (GUI.Button(new Rect(2f, (float)(Screen.height - 22), 150f, 20f), "Error Log / Fix Errors"))
			{
				if (this.showlog)
				{
					this.showlog = false;
				}
				else
				{
					this.CheckNow();
				}
			}
		}
	}

	// Token: 0x040000AB RID: 171
	public GUISkin guiSkin;

	// Token: 0x040000AC RID: 172
	public bool ismm;

	// Token: 0x040000AD RID: 173
	public bool showlog;

	// Token: 0x040000AE RID: 174
	public int totalerrors;

	// Token: 0x040000AF RID: 175
	public bool modelerror;

	// Token: 0x040000B0 RID: 176
	public bool poserror;

	// Token: 0x040000B1 RID: 177
	public bool triggererror;

	// Token: 0x040000B2 RID: 178
	public bool timererror;

	// Token: 0x040000B3 RID: 179
	public bool audioerror;

	// Token: 0x040000B4 RID: 180
	public bool cinematicerror;

	// Token: 0x040000B5 RID: 181
	public bool playerprefserror;

	// Token: 0x040000B6 RID: 182
	public bool advteleporterror;

	// Token: 0x040000B7 RID: 183
	public bool playerstartpointerror;

	// Token: 0x040000B8 RID: 184
	public bool ignoreModels;

	// Token: 0x040000B9 RID: 185
	public string errors;

	// Token: 0x040000BA RID: 186
	public string indextocheck;

	// Token: 0x040000BB RID: 187
	public Vector2 scrollPosition;
}
