using UnityEngine.SceneManagement;

namespace VRTactics.Utils
{
    public class SceneLoader
    {
        public static void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
}