using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator)),RequireComponent(typeof(DisplayIMGUI))]
public class FullScreenVideoCtr : Ivideo {
    private DisplayIMGUI displayIMGUI;
    private Animator animator;
    // Use this for initialization

    public new void initialization() {
        base.initialization();
        animator = GetComponent<Animator>();
        displayIMGUI = GetComponent<DisplayIMGUI>();
    }

    private void Hide() {
        animator.SetBool("Show", false);
    }

    private void Show() {
        animator.SetBool("Show", true);
    }

    public void Play(string path, bool autoPlay, bool isLoop) {
        LoadAndPlay(path, autoPlay, isLoop);
        Show();
    }

    public void Stop() {
        StopVideo();
        Hide();
    } 
}
