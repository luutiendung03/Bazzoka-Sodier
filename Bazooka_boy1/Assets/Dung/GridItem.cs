using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GridItem : MonoBehaviour
{
    public static T GetItem<T>(GameObject obj) where T : GridItem
    {
        return obj.GetComponentInParent<T>();
    }

    public static T GetItem<T>(Transform tf) where T : GridItem
    {
        return tf.GetComponentInParent<T>();
    }

    public static float HoriGridResize(GridLayoutGroup grid, int size)
    {
        float f = size * grid.cellSize.x + (size - 1) * +grid.spacing.x + grid.padding.left + grid.padding.right;
        grid.GetComponent<RectTransform>().sizeDelta = Vector2.right * f;
        return f;
    }

    public abstract void Buy();
}
