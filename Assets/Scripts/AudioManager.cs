using System;
using System.Linq;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
	public event Action OnBaseActionWindowStart;
	public event Action OnBaseActionWindowEnd;
	public event Action OnDashWindowStart;
	public event Action OnDashWindowEnd;
	public event Action OnFastClickWindowStart;
	public event Action OnFastClickWindowEnd;
	public event Action OnGrenadeChooseWindowStart;
	public event Action OnGrenadeChooseWindowEnd;
	public event Action OnGrenadeThrowWindowStart;
	public event Action OnGrenadeThrowWindowEnd;

	private MidiFile midiFile;

	private static Playback playback;


	private void Awake()
	{
		midiFile = MidiFile.Read("Assets/Audio/test.mid");
		playback = midiFile.GetPlayback();
		playback.Start();
		playback.NotesPlaybackStarted += HandleNotesPlaybackStarted;
		playback.NotesPlaybackFinished += HandleNotesPlaybackFinished;
	}


	private void HandleNotesPlaybackStarted(object sender, NotesEventArgs e)
	{
		if (e.Notes.Any(n => n.NoteName == NoteName.B))
			OnBaseActionWindowStart?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.D))
			OnDashWindowStart?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.F))
			OnFastClickWindowStart?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.G))
			OnGrenadeChooseWindowStart?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.GSharp))
			OnGrenadeThrowWindowStart?.Invoke();
	}

	private void HandleNotesPlaybackFinished(object sender, NotesEventArgs e)
	{
		if (e.Notes.Any(n => n.NoteName == NoteName.B))
			OnBaseActionWindowEnd?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.D))
			OnDashWindowEnd?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.F))
			OnFastClickWindowEnd?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.G))
			OnGrenadeChooseWindowEnd?.Invoke();
		if (e.Notes.Any(n => n.NoteName == NoteName.GSharp))
			OnGrenadeThrowWindowEnd?.Invoke();
	}
}