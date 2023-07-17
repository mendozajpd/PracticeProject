using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AsyncPractice
{

public class ShapeMoveScript : MonoBehaviour
{
    public async Task MoveShape (float duration)
    {
        var end = Time.time + duration;

        while (Time.time < end)
        {
            Vector2 newPosition = new Vector2 (transform.position.x + 5 * Time.deltaTime, transform.position.y);
            transform.position = newPosition;

            await Task.Yield();
        }
    }
}

}