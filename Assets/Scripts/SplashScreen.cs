using System.Collections;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject ui;
    private IEnumerator coroutine;
    static bool activated = false;
    void Awake() {
      if (activated == false) {
        ui.SetActive(false);
        coroutine = Waitforend(12.0f);
        StartCoroutine(coroutine);
      } if (activated == true) {
        Destroy(gameObject);
      }
    }
    private IEnumerator Waitforend(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        activated = true;
        ui.SetActive(true);
        Destroy(gameObject);
    }
}
