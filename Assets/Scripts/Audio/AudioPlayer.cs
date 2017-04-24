using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private float MinPitch = 0.9f;
    [SerializeField] private float MaxPitch = 1.1f;

    private System.Random random;
    private AudioSource Player { get { return this.GetComponent<AudioSource>(); } }

    protected void Start()
    {
        this.random = new System.Random();
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            this.Player.clip = clip;
            this.Player.pitch = (float)(random.NextDouble() * (MaxPitch - MinPitch)) + MinPitch;
            this.Player.Play();
        }
    }
}
