using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioPlayer))]
public class PipeAnimator : MonoBehaviour {

    [SerializeField] private AudioClip sfx;

    public static PipeAnimator Obj { get; private set; }

    protected void Start()
    {
        Obj = this;
    }

	public void PlayAnimation()
    {
        this.GetComponent<Animator>().SetBool("flowing", true);
        this.GetComponent<AudioPlayer>().PlayClip(sfx);
    }
}
