using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightDacneManager : MonoBehaviour
{
    [SerializeField] private Light lightWorld;
    [SerializeField] private List<AudioClip> _audioClips;
    [SerializeField] private Light lightLocal;
    [SerializeField] private AudioSource audioDance;
    [SerializeField] private List<Animator> characterDance;
    private bool isOpen = false;
    public int nameClip = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isOpen)
        {
            isOpen = true;
            for (int i = 0; i < characterDance.Count; i++)
            {
                characterDance[i].enabled = true;
            }
            audioDance.clip = _audioClips[nameClip];
            nameClip++;
            if (nameClip == _audioClips.Count) nameClip = 0;
            audioDance.Play();
            DOTween.To(value => lightWorld.intensity = value, 1, 0, 0.5f);
            DOTween.To(value => lightLocal.intensity = value, 0, 23, 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.O) && isOpen)
        {
            isOpen = false;
            for (int i = 0; i < characterDance.Count; i++)
            {
                characterDance[i].enabled = false;
            }
            audioDance.Stop();
            DOTween.To(value => lightWorld.intensity = value, 0, 1, 0.5f);
            DOTween.To(value => lightLocal.intensity = value, 23, 0, 0.5f);
        }
    }
}
