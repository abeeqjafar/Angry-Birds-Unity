using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    bool isPressed = false;
    public Rigidbody2D rb;
    public Rigidbody2D hookRb;
    public float relaseTime = 0.15f;
    public float maxDragDistance = 2f;
    public GameObject Next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mpos, hookRb.position)<=maxDragDistance)
            {
                rb.position = mpos;
            }
            else
            {
                rb.position = (mpos - hookRb.position).normalized * maxDragDistance + hookRb.position;
            }
            if (EnemyScript.count == 0)
            {
                Debug.Log("You Won the Game!!!");
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");

                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (SceneManager.GetActiveScene().name == "Level3")
                {
                    SceneManager.LoadScene("Level1");
                }
            }
        }
        
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        
        StartCoroutine(release());
    }

    IEnumerator release()
    {
        yield return new WaitForSeconds(relaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(4f);
        if(Next!=null)
        {
            Next.SetActive(true);
            if (EnemyScript.count == 0)
            {
                Debug.Log("You Won the Game!!!");
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");

                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (SceneManager.GetActiveScene().name == "Level3")
                {
                    SceneManager.LoadScene("Level1");
                }
            }

        }
        else
        {
            if(EnemyScript.count>0)
            {
                Debug.Log("You Lost the Game!!!");
                SceneManager.LoadScene("Level1");
            }
            else
            {
                Debug.Log("You Won the Game!!!");
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");

                }
                else if(SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if(SceneManager.GetActiveScene().name == "Level3")
                {
                    SceneManager.LoadScene("Level1");
                }
            }
            
            
        }
        
    }
}
