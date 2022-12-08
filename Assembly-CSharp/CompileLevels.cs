using System;
using System.Collections;
using System.IO;
using UnityEngine;

// Token: 0x02000093 RID: 147
public class CompileLevels : MonoBehaviour
{
	// Token: 0x0600028F RID: 655 RVA: 0x00018500 File Offset: 0x00016900
	private void Awake()
	{
		if (CryptoPlayerPrefs.GetInt("Mode", 0) == 21)
		{
			this.isbuilder = true;
			this.thepath = CryptoPlayerPrefs.GetString("path", string.Empty);
			this.curlevelid = CryptoPlayerPrefs.GetInt("CurLevel", 0);
			this.totallevels = CryptoPlayerPrefs.GetInt("TotalLevels", 0);
			this.gamename = CryptoPlayerPrefs.GetString("GameName", string.Empty);
			this.bitversion = CryptoPlayerPrefs.GetString("BitVersion", string.Empty);
			GameObject.Find("EditorCam").active = false;
			base.GetComponent<Camera>().enabled = true;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000290 RID: 656 RVA: 0x000185B4 File Offset: 0x000169B4
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(5f);
		ErrorLog el = GameObject.Find("Log").GetComponent<ErrorLog>();
		el.ignoreModels = true;
		el.CheckNow();
		yield return new WaitForSeconds(5f);
		yield return new WaitForEndOfFrame();
		this.gamedatafolder = string.Concat(new string[]
		{
			this.thepath,
			"/",
			this.gamename,
			this.bitversion,
			"/",
			this.gamename,
			"_Data"
		});
		this.datapath = Application.dataPath;
		SettingsProperties settingsobj = GameObject.Find("Settings").GetComponent<SettingsProperties>();
		if (!File.Exists(this.gamedatafolder + "/Images/" + settingsobj.gameovername))
		{
			File.Copy(this.datapath + "/Images/" + settingsobj.gameovername, this.gamedatafolder + "/Images/" + settingsobj.gameovername);
		}
		if (!File.Exists(this.gamedatafolder + "/Images/" + settingsobj.winname))
		{
			File.Copy(this.datapath + "/Images/" + settingsobj.winname, this.gamedatafolder + "/Images/" + settingsobj.winname);
		}
		if (!File.Exists(this.gamedatafolder + "/Audio/" + settingsobj.footsteps))
		{
			File.Copy(this.datapath + "/Audio/" + settingsobj.footsteps, this.gamedatafolder + "/Audio/" + settingsobj.footsteps);
		}
		for (int i = 0; i < this.itemtypes.Length; i++)
		{
			string text = this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname;
			string[] array = text.Split(new char[]
			{
				"/"[0]
			});
			string text2 = string.Empty;
			for (int j = 0; j < array.Length; j++)
			{
				if (j != array.Length - 1)
				{
					if (j != array.Length - 2)
					{
						text2 = text2 + array[j] + "/";
					}
					else
					{
						text2 += array[j];
					}
				}
			}
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			if (!File.Exists(this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + ".model"))
			{
				File.Copy(this.datapath + "/Models/Items/" + this.itemtypes[i].modelname + ".model", this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + ".model");
				if (File.Exists(this.datapath + "/Models/Items/" + this.itemtypes[i].modelname + "_icon.png") && !File.Exists(this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + "_icon.png"))
				{
					File.Copy(this.datapath + "/Models/Items/" + this.itemtypes[i].modelname + "_icon.png", this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + "_icon.png");
				}
				if (File.Exists(this.datapath + "/Models/Items/" + this.itemtypes[i].modelname + ".png") && !File.Exists(this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + ".png"))
				{
					File.Copy(this.datapath + "/Models/Items/" + this.itemtypes[i].modelname + ".png", this.gamedatafolder + "/Models/Items/" + this.itemtypes[i].modelname + ".png");
				}
			}
			string text3 = this.gamedatafolder + "/Audio/" + this.itemtypes[i].firesound;
			string[] array2 = text3.Split(new char[]
			{
				"/"[0]
			});
			string text4 = string.Empty;
			for (int k = 0; k < array2.Length; k++)
			{
				if (k != array2.Length - 1)
				{
					if (k != array2.Length - 2)
					{
						text4 = text4 + array2[k] + "/";
					}
					else
					{
						text4 += array2[k];
					}
				}
			}
			if (!Directory.Exists(text4))
			{
				Directory.CreateDirectory(text4);
			}
			if (!File.Exists(this.gamedatafolder + "/Audio/" + this.itemtypes[i].firesound))
			{
				File.Copy(this.datapath + "/Audio/" + this.itemtypes[i].firesound, this.gamedatafolder + "/Audio/" + this.itemtypes[i].firesound);
			}
		}
		PositionAndScale[] allobjs = UnityEngine.Object.FindObjectsOfType(typeof(PositionAndScale)) as PositionAndScale[];
		if (allobjs.Length > 0)
		{
			foreach (PositionAndScale positionAndScale in allobjs)
			{
				if (positionAndScale.gameObject.GetComponent<ModelProperties>() && positionAndScale.gameObject.name.Contains(".model"))
				{
					string text5 = positionAndScale.gameObject.name;
					text5 = text5.Replace(",", "/");
					int num = text5.LastIndexOf("-");
					if (num > -1)
					{
						text5 = text5.Remove(num);
					}
					string text6 = this.gamedatafolder + "/" + text5;
					string[] array4 = text6.Split(new char[]
					{
						"/"[0]
					});
					string text7 = string.Empty;
					for (int m = 0; m < array4.Length; m++)
					{
						if (m != array4.Length - 1)
						{
							if (m != array4.Length - 2)
							{
								text7 = text7 + array4[m] + "/";
							}
							else
							{
								text7 += array4[m];
							}
						}
					}
					if (!Directory.Exists(text7))
					{
						Directory.CreateDirectory(text7);
					}
					if (!File.Exists(this.gamedatafolder + "/" + text5) && File.Exists(this.datapath + "/" + text5))
					{
						File.Copy(this.datapath + "/" + text5, this.gamedatafolder + "/" + text5);
					}
					string str = string.Empty;
					int num2 = text5.LastIndexOf(".");
					if (num2 > -1)
					{
						str = text5.Remove(num2);
					}
					else
					{
						str = text5;
					}
					if (File.Exists(this.datapath + "/" + str + ".png") && !File.Exists(this.gamedatafolder + "/" + str + ".png"))
					{
						File.Copy(this.datapath + "/" + str + ".png", this.gamedatafolder + "/" + str + ".png");
					}
					if (File.Exists(this.datapath + "/" + str + ".jpg") && !File.Exists(this.gamedatafolder + "/" + str + ".jpg"))
					{
						File.Copy(this.datapath + "/" + str + ".jpg", this.gamedatafolder + "/" + str + ".jpg");
					}
				}
				if (positionAndScale.gameObject.GetComponent<TriggerProperties>())
				{
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().playsound)
					{
						string soundpath = positionAndScale.gameObject.GetComponent<TriggerProperties>().soundpath;
						string text8 = this.gamedatafolder + "/Audio/" + soundpath;
						string[] array5 = text8.Split(new char[]
						{
							"/"[0]
						});
						string text9 = string.Empty;
						for (int n = 0; n < array5.Length; n++)
						{
							if (n != array5.Length - 1)
							{
								if (n != array5.Length - 2)
								{
									text9 = text9 + array5[n] + "/";
								}
								else
								{
									text9 += array5[n];
								}
							}
						}
						if (!Directory.Exists(text9))
						{
							Directory.CreateDirectory(text9);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + soundpath))
						{
							File.Copy(this.datapath + "/Audio/" + soundpath, this.gamedatafolder + "/Audio/" + soundpath);
						}
					}
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().displayimg)
					{
						string imgpath = positionAndScale.gameObject.GetComponent<TriggerProperties>().imgpath;
						string text10 = this.gamedatafolder + "/Images/" + imgpath;
						string[] array6 = text10.Split(new char[]
						{
							"/"[0]
						});
						string text11 = string.Empty;
						for (int num3 = 0; num3 < array6.Length; num3++)
						{
							if (num3 != array6.Length - 1)
							{
								if (num3 != array6.Length - 2)
								{
									text11 = text11 + array6[num3] + "/";
								}
								else
								{
									text11 += array6[num3];
								}
							}
						}
						if (!Directory.Exists(text11))
						{
							Directory.CreateDirectory(text11);
						}
						if (!File.Exists(this.gamedatafolder + "/Images/" + imgpath))
						{
							File.Copy(this.datapath + "/Images/" + imgpath, this.gamedatafolder + "/Images/" + imgpath);
						}
					}
					if (positionAndScale.gameObject.GetComponent<TriggerProperties>().playvideo)
					{
						string videopath = positionAndScale.gameObject.GetComponent<TriggerProperties>().videopath;
						string text12 = this.gamedatafolder + "/Video/" + videopath;
						string[] array7 = text12.Split(new char[]
						{
							"/"[0]
						});
						string text13 = string.Empty;
						for (int num4 = 0; num4 < array7.Length; num4++)
						{
							if (num4 != array7.Length - 1)
							{
								if (num4 != array7.Length - 2)
								{
									text13 = text13 + array7[num4] + "/";
								}
								else
								{
									text13 += array7[num4];
								}
							}
						}
						if (!Directory.Exists(text13))
						{
							Directory.CreateDirectory(text13);
						}
						if (!File.Exists(this.gamedatafolder + "/Video/" + videopath))
						{
							File.Copy(this.datapath + "/Video/" + videopath, this.gamedatafolder + "/Video/" + videopath);
						}
					}
				}
				if (positionAndScale.gameObject.GetComponent<TimerProperties>())
				{
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().playsound)
					{
						string soundpath2 = positionAndScale.gameObject.GetComponent<TimerProperties>().soundpath;
						string text14 = this.gamedatafolder + "/Audio/" + soundpath2;
						string[] array8 = text14.Split(new char[]
						{
							"/"[0]
						});
						string text15 = string.Empty;
						for (int num5 = 0; num5 < array8.Length; num5++)
						{
							if (num5 != array8.Length - 1)
							{
								if (num5 != array8.Length - 2)
								{
									text15 = text15 + array8[num5] + "/";
								}
								else
								{
									text15 += array8[num5];
								}
							}
						}
						if (!Directory.Exists(text15))
						{
							Directory.CreateDirectory(text15);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + soundpath2))
						{
							File.Copy(this.datapath + "/Audio/" + soundpath2, this.gamedatafolder + "/Audio/" + soundpath2);
						}
					}
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().displayimg)
					{
						string imgpath2 = positionAndScale.gameObject.GetComponent<TimerProperties>().imgpath;
						string text16 = this.gamedatafolder + "/Images/" + imgpath2;
						string[] array9 = text16.Split(new char[]
						{
							"/"[0]
						});
						string text17 = string.Empty;
						for (int num6 = 0; num6 < array9.Length; num6++)
						{
							if (num6 != array9.Length - 1)
							{
								if (num6 != array9.Length - 2)
								{
									text17 = text17 + array9[num6] + "/";
								}
								else
								{
									text17 += array9[num6];
								}
							}
						}
						if (!Directory.Exists(text17))
						{
							Directory.CreateDirectory(text17);
						}
						if (!File.Exists(this.gamedatafolder + "/Images/" + imgpath2))
						{
							File.Copy(this.datapath + "/Images/" + imgpath2, this.gamedatafolder + "/Images/" + imgpath2);
						}
					}
					if (positionAndScale.gameObject.GetComponent<TimerProperties>().playvideo)
					{
						string videopath2 = positionAndScale.gameObject.GetComponent<TimerProperties>().videopath;
						string text18 = this.gamedatafolder + "/Video/" + videopath2;
						string[] array10 = text18.Split(new char[]
						{
							"/"[0]
						});
						string text19 = string.Empty;
						for (int num7 = 0; num7 < array10.Length; num7++)
						{
							if (num7 != array10.Length - 1)
							{
								if (num7 != array10.Length - 2)
								{
									text19 = text19 + array10[num7] + "/";
								}
								else
								{
									text19 += array10[num7];
								}
							}
						}
						if (!Directory.Exists(text19))
						{
							Directory.CreateDirectory(text19);
						}
						if (!File.Exists(this.gamedatafolder + "/Video/" + videopath2))
						{
							File.Copy(this.datapath + "/Video/" + videopath2, this.gamedatafolder + "/Video/" + videopath2);
						}
					}
				}
				if (positionAndScale.gameObject.GetComponent<AudioProperties>())
				{
					string audioname = positionAndScale.gameObject.GetComponent<AudioProperties>().audioname;
					string text20 = this.gamedatafolder + "/Audio/" + audioname;
					string[] array11 = text20.Split(new char[]
					{
						"/"[0]
					});
					string text21 = string.Empty;
					for (int num8 = 0; num8 < array11.Length; num8++)
					{
						if (num8 != array11.Length - 1)
						{
							if (num8 != array11.Length - 2)
							{
								text21 = text21 + array11[num8] + "/";
							}
							else
							{
								text21 += array11[num8];
							}
						}
					}
					if (!Directory.Exists(text21))
					{
						Directory.CreateDirectory(text21);
					}
					if (!File.Exists(this.gamedatafolder + "/Audio/" + audioname))
					{
						File.Copy(this.datapath + "/Audio/" + audioname, this.gamedatafolder + "/Audio/" + audioname);
					}
				}
				if (positionAndScale.gameObject.GetComponent<PlayerProperties>())
				{
					string hud = positionAndScale.gameObject.GetComponent<PlayerProperties>().hud;
					string text22 = this.gamedatafolder + "/Images/HUD/" + hud;
					string[] array12 = text22.Split(new char[]
					{
						"/"[0]
					});
					string text23 = string.Empty;
					for (int num9 = 0; num9 < array12.Length; num9++)
					{
						if (num9 != array12.Length - 1)
						{
							if (num9 != array12.Length - 2)
							{
								text23 = text23 + array12[num9] + "/";
							}
							else
							{
								text23 += array12[num9];
							}
						}
					}
					if (!Directory.Exists(text23))
					{
						Directory.CreateDirectory(text23);
					}
					if (!File.Exists(this.gamedatafolder + "/Images/HUD/" + hud))
					{
						File.Copy(this.datapath + "/Images/HUD/" + hud, this.gamedatafolder + "/Images/HUD/" + hud);
					}
				}
				if (positionAndScale.gameObject.GetComponent<ModProperties>() && !File.Exists(this.gamedatafolder + "/Mods/" + positionAndScale.GetComponent<ModProperties>().modname + ".mod"))
				{
					File.Copy(this.datapath + "/Mods/" + positionAndScale.GetComponent<ModProperties>().modname + ".mod", this.gamedatafolder + "/Mods/" + positionAndScale.GetComponent<ModProperties>().modname + ".mod");
				}
			}
			yield return new WaitForSeconds(1f);
			base.StartCoroutine(this.CompletedNow());
			if (this.npctypes.Length < 1)
			{
				this.npctypes = new NPCProperties[10];
			}
			if (this.npctypes[0] == null)
			{
				this.npctypes = new NPCProperties[10];
				this.npctypes[0] = GameObject.Find("NPC_Type1").GetComponent<NPCProperties>();
			}
			if (this.npctypes[1] == null)
			{
				this.npctypes[1] = GameObject.Find("NPC_Type2").GetComponent<NPCProperties>();
			}
			if (this.npctypes[2] == null)
			{
				this.npctypes[2] = GameObject.Find("NPC_Type3").GetComponent<NPCProperties>();
			}
			if (this.npctypes[3] == null)
			{
				this.npctypes[3] = GameObject.Find("NPC_Type4").GetComponent<NPCProperties>();
			}
			if (this.npctypes[4] == null)
			{
				this.npctypes[4] = GameObject.Find("NPC_Type5").GetComponent<NPCProperties>();
			}
			if (this.npctypes[5] == null)
			{
				this.npctypes[5] = GameObject.Find("NPC_Type6").GetComponent<NPCProperties>();
			}
			if (this.npctypes[6] == null)
			{
				this.npctypes[6] = GameObject.Find("NPC_Type7").GetComponent<NPCProperties>();
			}
			if (this.npctypes[7] == null)
			{
				this.npctypes[7] = GameObject.Find("NPC_Type8").GetComponent<NPCProperties>();
			}
			if (this.npctypes[8] == null)
			{
				this.npctypes[8] = GameObject.Find("NPC_Type9").GetComponent<NPCProperties>();
			}
			if (this.npctypes[9] == null)
			{
				this.npctypes[9] = GameObject.Find("NPC_Type10").GetComponent<NPCProperties>();
			}
			if (this.npctypes[0] != null && this.npctypes[1] != null && this.npctypes[2] != null && this.npctypes[3] != null && this.npctypes[4] != null && this.npctypes[5] != null && this.npctypes[6] != null && this.npctypes[7] != null && this.npctypes[8] != null && this.npctypes[9] != null)
			{
				for (int num10 = 0; num10 < this.npctypes.Length; num10++)
				{
					if (!File.Exists(this.gamedatafolder + "/Characters/NPC/" + this.npctypes[num10].npcmodelname + ".npc") && this.npctypes[num10].npcmodelname != string.Empty)
					{
						File.Copy(this.datapath + "/Characters/NPC/" + this.npctypes[num10].npcmodelname + ".npc", this.gamedatafolder + "/Characters/NPC/" + this.npctypes[num10].npcmodelname + ".npc");
					}
					if (this.npctypes[num10].detectsound != string.Empty)
					{
						string text24 = this.gamedatafolder + "/Audio/" + this.npctypes[num10].detectsound;
						string[] array13 = text24.Split(new char[]
						{
							"/"[0]
						});
						string text25 = string.Empty;
						for (int num11 = 0; num11 < array13.Length; num11++)
						{
							if (num11 != array13.Length - 1)
							{
								if (num11 != array13.Length - 2)
								{
									text25 = text25 + array13[num11] + "/";
								}
								else
								{
									text25 += array13[num11];
								}
							}
						}
						if (!Directory.Exists(text25))
						{
							Directory.CreateDirectory(text25);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + this.npctypes[num10].detectsound))
						{
							File.Copy(this.datapath + "/Audio/" + this.npctypes[num10].detectsound, this.gamedatafolder + "/Audio/" + this.npctypes[num10].detectsound);
						}
					}
					if (this.npctypes[num10].footstepsound.Contains(".ogg") || this.npctypes[num10].footstepsound.Contains(".wav"))
					{
						string text26 = this.gamedatafolder + "/Audio/" + this.npctypes[num10].footstepsound;
						string[] array14 = text26.Split(new char[]
						{
							"/"[0]
						});
						string text27 = string.Empty;
						for (int num12 = 0; num12 < array14.Length; num12++)
						{
							if (num12 != array14.Length - 1)
							{
								if (num12 != array14.Length - 2)
								{
									text27 = text27 + array14[num12] + "/";
								}
								else
								{
									text27 += array14[num12];
								}
							}
						}
						if (!Directory.Exists(text27))
						{
							Directory.CreateDirectory(text27);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + this.npctypes[num10].footstepsound))
						{
							File.Copy(this.datapath + "/Audio/" + this.npctypes[num10].footstepsound, this.gamedatafolder + "/Audio/" + this.npctypes[num10].footstepsound);
						}
					}
					if (this.npctypes[num10].attacksound.Contains(".wav") || this.npctypes[num10].attacksound.Contains(".ogg"))
					{
						string text28 = this.gamedatafolder + "/Audio/" + this.npctypes[num10].attacksound;
						string[] array15 = text28.Split(new char[]
						{
							"/"[0]
						});
						string text29 = string.Empty;
						for (int num13 = 0; num13 < array15.Length; num13++)
						{
							if (num13 != array15.Length - 1)
							{
								if (num13 != array15.Length - 2)
								{
									text29 = text29 + array15[num13] + "/";
								}
								else
								{
									text29 += array15[num13];
								}
							}
						}
						if (!Directory.Exists(text29))
						{
							Directory.CreateDirectory(text29);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + this.npctypes[num10].attacksound))
						{
							File.Copy(this.datapath + "/Audio/" + this.npctypes[num10].attacksound, this.gamedatafolder + "/Audio/" + this.npctypes[num10].attacksound);
						}
					}
					if (this.npctypes[num10].staticsound.Contains(".wav") || this.npctypes[num10].staticsound.Contains(".ogg"))
					{
						string text30 = this.gamedatafolder + "/Audio/" + this.npctypes[num10].staticsound;
						string[] array16 = text30.Split(new char[]
						{
							"/"[0]
						});
						string text31 = string.Empty;
						for (int num14 = 0; num14 < array16.Length; num14++)
						{
							if (num14 != array16.Length - 1)
							{
								if (num14 != array16.Length - 2)
								{
									text31 = text31 + array16[num14] + "/";
								}
								else
								{
									text31 += array16[num14];
								}
							}
						}
						if (!Directory.Exists(text31))
						{
							Directory.CreateDirectory(text31);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + this.npctypes[num10].staticsound))
						{
							File.Copy(this.datapath + "/Audio/" + this.npctypes[num10].staticsound, this.gamedatafolder + "/Audio/" + this.npctypes[num10].staticsound);
						}
					}
					if (this.npctypes[num10].viewsound.Contains(".wav") || this.npctypes[num10].viewsound.Contains(".ogg"))
					{
						string text32 = this.gamedatafolder + "/Audio/" + this.npctypes[num10].viewsound;
						string[] array17 = text32.Split(new char[]
						{
							"/"[0]
						});
						string text33 = string.Empty;
						for (int num15 = 0; num15 < array17.Length; num15++)
						{
							if (num15 != array17.Length - 1)
							{
								if (num15 != array17.Length - 2)
								{
									text33 = text33 + array17[num15] + "/";
								}
								else
								{
									text33 += array17[num15];
								}
							}
						}
						if (!Directory.Exists(text33))
						{
							Directory.CreateDirectory(text33);
						}
						if (!File.Exists(this.gamedatafolder + "/Audio/" + this.npctypes[num10].viewsound))
						{
							File.Copy(this.datapath + "/Audio/" + this.npctypes[num10].viewsound, this.gamedatafolder + "/Audio/" + this.npctypes[num10].viewsound);
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000185D0 File Offset: 0x000169D0
	private IEnumerator CompletedNow()
	{
		yield return new WaitForSeconds(5f);
		if (this.curlevelid != this.totallevels)
		{
			this.curlevelid++;
			CryptoPlayerPrefs.SetInt("CurLevel", this.curlevelid);
			this.nextlevelname = CryptoPlayerPrefs.GetString("level" + this.curlevelid.ToString(), string.Empty);
			UniSave.Load(this.nextlevelname);
		}
		else
		{
			Application.LoadLevel("BuildSuccess");
		}
		yield break;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x000185EC File Offset: 0x000169EC
	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height - 50), 300f, 22f), "Gathering assets from Level '" + this.curlevelid.ToString() + "'...");
	}

	// Token: 0x04000315 RID: 789
	public bool isbuilder;

	// Token: 0x04000316 RID: 790
	public int curlevelid;

	// Token: 0x04000317 RID: 791
	public int totallevels;

	// Token: 0x04000318 RID: 792
	public string gamedatafolder;

	// Token: 0x04000319 RID: 793
	public string datapath;

	// Token: 0x0400031A RID: 794
	public CustomItemsProperties[] itemtypes;

	// Token: 0x0400031B RID: 795
	public NPCProperties[] npctypes;

	// Token: 0x0400031C RID: 796
	private string nextlevelname;

	// Token: 0x0400031D RID: 797
	private string gamename;

	// Token: 0x0400031E RID: 798
	private string bitversion;

	// Token: 0x0400031F RID: 799
	private string thepath;
}
