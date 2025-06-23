using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource[] sfx;

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlaySFX(int index)
    {
        if (index >= sfx.Length) return;

        sfx[index].Play();
    }
}
