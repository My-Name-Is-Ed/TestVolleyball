
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene(0);
    }
}
