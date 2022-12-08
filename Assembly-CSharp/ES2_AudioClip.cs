using System;
using System.ComponentModel;
using UnityEngine;

// Token: 0x0200009E RID: 158
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class ES2_AudioClip : ES2Type
{
	// Token: 0x060002CA RID: 714 RVA: 0x0001C1E5 File Offset: 0x0001A5E5
	public ES2_AudioClip() : base(typeof(AudioClip))
	{
		this.key = 25;
	}

	// Token: 0x060002CB RID: 715 RVA: 0x0001C200 File Offset: 0x0001A600
	public override void Write(object data, ES2Writer writer)
	{
		AudioClip audioClip = (AudioClip)data;
		writer.writer.Write(5);
		float[] array = new float[audioClip.samples * audioClip.channels];
		audioClip.GetData(array, 0);
		writer.writer.Write(audioClip.name);
		writer.writer.Write(audioClip.samples);
		writer.writer.Write(audioClip.channels);
		writer.writer.Write(audioClip.frequency);
		writer.Write<float>(array);
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0001C288 File Offset: 0x0001A688
	public override object Read(ES2Reader reader)
	{
		AudioClip audioClip = null;
		string name = string.Empty;
		int lengthSamples = 0;
		int channels = 0;
		int frequency = 0;
		int num = (int)reader.reader.ReadByte();
		for (int i = 0; i < num; i++)
		{
			switch (i)
			{
			case 0:
				name = reader.reader.ReadString();
				break;
			case 1:
				lengthSamples = reader.reader.ReadInt32();
				break;
			case 2:
				channels = reader.reader.ReadInt32();
				break;
			case 3:
				frequency = reader.reader.ReadInt32();
				break;
			case 4:
				audioClip = AudioClip.Create(name, lengthSamples, channels, frequency, false);
				audioClip.SetData(reader.ReadArray<float>(new ES2_float()), 0);
				break;
			default:
				return audioClip;
			}
		}
		return audioClip;
	}
}
