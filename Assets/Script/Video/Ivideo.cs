using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
public class Ivideo : MonoBehaviour {
    public MediaPlayer mediaPlayer;

	// Use this for initialization
	public void initialization() {
		
	}

    protected void LoadAndPlay(string path, bool autoPlay, bool isLoop) {
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, autoPlay);
        mediaPlayer.Control.SetLooping(isLoop);
    }

    protected void StopVideo() {
        mediaPlayer.Stop();
    }


}
