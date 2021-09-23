
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneManager.LoadScene("SampleScene");
    }
}
