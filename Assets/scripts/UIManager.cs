using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool mbPause = false;
    public AudioMixer Mixer;
    [SerializeField] Button mPauseBtn;
    public Slider mVolumeSlider;
    void Start()
    {
        mPauseBtn.onClick.AddListener(GamePause);
        mVolumeSlider.onValueChanged.AddListener(GameVolumeChange);
    }
    public void GamePause()
    {
        if(!mbPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        mbPause = !mbPause;
    }
    public void GameVolumeChange(float fVolume)
    {
        Mixer.SetFloat("MasterVolume", fVolume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
