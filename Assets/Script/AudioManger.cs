using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource;
    public AudioSource loopSource;

    public AudioClip bgmClip;

    public AudioClip jumpSE;
    public AudioClip chargeReleaseSE;
    public AudioClip breakWallSE;
    public AudioClip enemyDefeatSE;
    public AudioClip gameOverSE;
    public AudioClip clearSE;
    public AudioClip buttonSE;
    public AudioClip inchargeSE;

    public float chargeRate = 0.8f;

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.8f);

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;
        loopSource.volume =seVolume*chargeRate;

        if(bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayJump()
    {
        PlaySE(jumpSE);
    }

    public void PlayChargeRelease()
    {
        PlaySE(chargeReleaseSE);
    }

    public void PlayBreakWall()
    {
        PlaySE(breakWallSE);
    }

    public void PlayEnemyDefeat()
    {
        PlaySE(enemyDefeatSE);
    }

    public void PlayGameOver()
    {
        PlaySE(gameOverSE);
    }

    public void PlayClear()
    {
        PlaySE(clearSE);
    }

    public void PlayButton()
    {
        PlaySE(buttonSE);
    }

    void PlaySE(AudioClip clip)
    {
        if(clip == null) return;
        seSource.PlayOneShot(clip);
    }

     public void StartChargeLoop()
    {
        if(inchargeSE == null) return;
        if(loopSource.isPlaying) return;

        loopSource.clip = inchargeSE;
        loopSource.loop = true;
        loopSource.Play();
    }

    public void StopChargeLoop()
    {
        if(!loopSource.isPlaying) return;

        loopSource.Stop();
        loopSource.loop = false;
        loopSource.clip = null;
    }


    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSEVolume(float volume)
    {
        seSource.volume = volume;
        loopSource.volume= volume * chargeRate;
        PlayerPrefs.SetFloat("SEVolume", volume);
        PlayerPrefs.Save();
    }
}