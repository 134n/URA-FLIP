using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryController : MonoBehaviour
{
    private bool canRetry = false;

    private void Update()
    {
        if(!canRetry){return;}
        if(InputRetry() == true)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EnableRetry()
    {
        canRetry = true;
    }
    
    public bool InputRetry()
    {
        if(Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame){return true;}
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame){return true;}
        return false;
    }
}
