using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public  AudioClip[] audioClips;

    public AudioClip[] AudioBgm;
    public AudioSource FireManVoiceOverAudioSource;
    public AudioSource BGM;

    public void initialization() {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnEnable()
    {
        CanvasManager.HangupPhone += StopFireManVoiceOver;
    }

    private void OnDisable()
    {
        CanvasManager.HangupPhone -= StopFireManVoiceOver;
    }

    public void PlayFireManVoiceOver(int num) {
        FireManVoiceOverAudioSource.PlayOneShot(audioClips[num]);
    }

    public void StopFireManVoiceOver() {
        FireManVoiceOverAudioSource.Stop();
    }

    public void playConnecting() {
        PlayBGM(AudioBgm[0]);
    }

    public void PlayBGM(AudioClip clip) {
        BGM.PlayOneShot(clip);
    }

    public void StopBGM()
    {
        BGM.Stop();
    }
}
