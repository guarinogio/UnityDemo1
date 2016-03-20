using UnityEngine;
using System.Collections;

public class UnityExtensions : NDiSingleton<UnityExtensions> {

    public static void Swap<T>(ref T x, ref T y)
    {
        T t = y;
        y = x;
        x = t;
    }

    public void Destroy(GameObject gameObject, float time) {
        StartCoroutine(CountdownToDestroy(gameObject, time));
    }

    private IEnumerator CountdownToDestroy(GameObject gameObject, float destroyTime) {
        float timer = destroyTime;

        while (timer > 0) {
            timer -= Time.deltaTime * Time.timeScale;

            if (!gameObject)
                break;

            yield return null;
        }

        if (gameObject)
            Destroy(gameObject);
    }

}
