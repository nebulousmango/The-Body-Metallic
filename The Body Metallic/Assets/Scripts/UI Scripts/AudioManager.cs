using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundData[] soundsData;

    private void Awake()
    {
        CreateSources();
    }

    void CreateSources()
    {
        foreach (SoundData soundData in soundsData)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            soundData.AudioSource = src;
            soundData.AudioSource.clip = soundData.AudioClip;
            soundData.AudioSource.volume = soundData.F_Volume;
            soundData.AudioSource.playOnAwake = soundData.B_PlayOnAwake;
            soundData.AudioSource.loop = soundData.B_Loop;
        }
    }

    public void PlaySound(string name)
    {
        foreach (SoundData sd in soundsData)
        {
            if (sd.S_Name == name) sd.AudioSource.Play();
        }
    }

    public void StopSound(string name)
    {
        foreach (SoundData sd in soundsData)
        {
            if (sd.S_Name == name) sd.AudioSource.Stop();
        }
    }
}
