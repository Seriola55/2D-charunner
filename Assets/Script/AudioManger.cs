using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource;

    public AudioClip bgmClip;

    public AudioClip jumpSE;
    public AudioClip chargeReleaseSE;
    public AudioClip breakWallSE;
    public AudioClip enemyDefeatSE;
    public AudioClip gameOverSE;
    public AudioClip clearSE;

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.8f);

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;

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

    void PlaySE(AudioClip clip)
    {
        if(clip == null) return;
        seSource.PlayOneShot(clip);
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
        PlayerPrefs.SetFloat("SEVolume", volume);
        PlayerPrefs.Save();
    }
}