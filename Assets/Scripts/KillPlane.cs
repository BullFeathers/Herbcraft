using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlane : MonoBehaviour
{
    bool dead = false;

    void Update()
    {
        if (transform.position.y < -10f && !dead)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
