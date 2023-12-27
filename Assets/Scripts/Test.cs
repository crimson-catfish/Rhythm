using System;
using System.Linq;
using Melanchall.DryWetMidi.Multimedia;
using Unity;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AudioManager audioManager;

    private void Start()
    {


        //AudioManager.playback.NotesPlaybackStarted += HandleNoteStart(); //OnNoteStart += HandleNoteStart;
    }

    private static void HandleNoteStart(object sender, NotesEventArgs args)
    {
        Debug.Log(args.Notes.Any());






    }
}