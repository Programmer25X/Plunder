using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Create new Coin")]
public class CoinData : ScriptableObject
{
    [SerializeField] private AudioClip _clip;

    public AudioClip GetAudioClip()
    {
        return _clip;
    }  

}
