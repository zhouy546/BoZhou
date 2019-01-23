using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public  AudioClip[] audioClips;

    public AudioClip[] AudioBgm;
    public AudioSource FireManVoiceOverAudioSource;
    public AudioSource BGM;

    public AudioClip HintClip;

    public void initialization() {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnEnable()
    {
        CanvasManager.HangupPhone += StopFireManVoiceOver;
        CanvasManager.Call += PlayHint;
        CanvasManager.StartConversation += StopHint;
        CanvasManager.Failed += StopHint;


    }

    private void OnDisable()
    {
        CanvasManager.HangupPhone -= StopFireManVoiceOver;
        CanvasManager.Call -= PlayHint;
        CanvasManager.StartConversation -= StopHint;
        CanvasManager.Failed -= StopHint;
    }

    public void PlayHint() {
        PlayBGM(HintClip);
    }

    public void StopHint() {
        StopBGM();
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
