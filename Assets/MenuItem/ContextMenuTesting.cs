using UnityEngine;

public class ContextMenuTesting : MonoBehaviour
{
    // 在Name这个属性的右键菜单中添加一个菜单项
    [ContextMenuItem("Randomize Name", "Randomize")]
    public string Name;

    // 在该组件的右键菜单中添加一个菜单项
    [ContextMenu("Reset Name")]
    private void ResetName()
    {
        Name = string.Empty;
    }

    private void Randomize()
    {
        Name = "Some Random Name";
    }
}
