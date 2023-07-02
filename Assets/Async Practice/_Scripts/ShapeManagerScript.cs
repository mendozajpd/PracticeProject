using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShapeManagerScript : MonoBehaviour
{
    [SerializeField] private ShapeMoveScript[] _shapeScripts;
    [SerializeField] private Canvas _canvas;


    public async void MoveAllShapes()
    {
        _canvas.enabled = false;


        await _shapeScripts[0].MoveShape(1);

        var tasks = new List<Task>();
        for (var i = 1; i < _shapeScripts.Length; i++)
        {
            tasks.Add(_shapeScripts[i].MoveShape((i)));
        }

        await Task.WhenAll(tasks);

        _canvas.enabled = true;
    }
}
