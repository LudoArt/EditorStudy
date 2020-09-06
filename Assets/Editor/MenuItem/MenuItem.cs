using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/*
 * 一些支持自定义的热键
 * % – CTRL on Windows / CMD on OSX
 * # – Shift
 * & – Alt
 * LEFT/RIGHT/UP/DOWN – Arrow keys
 * F1…F2 – F keys
 * HOME, END, PGUP, PGDN
*/


public class MenuItems
{

    #region 添加菜单项

    // 在菜单栏新建一个Tools，在Tools下有一个叫Clear PlayerPrefs的菜单项
    // 快捷键是ctrl+shift+A
    [MenuItem("Tools/Clear PlayerPrefs %#a")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }

    // 在已经存在的菜单Window下添加一个新的菜单项
    // 快捷键是G
    [MenuItem("Window/New Option _g")]
    private static void NewOptionWithHotkey()
    {
    }

    // 增加一个多级嵌套的菜单项
    [MenuItem("Tools/SubMenu/Option")]
    private static void NewNestedOption()
    {
    }

    #endregion

    #region 特殊路径

    // 在项目视图中，右键某个资源的菜单中添加一个菜单项
    [MenuItem("Assets/Load Additive Scene")]
    private static void LoadAdditiveScene()
    {
        var selected = Selection.activeObject;
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
    }


    // 在Assets/Create下添加一个新的菜单项
    [MenuItem("Assets/Create/Add Configuration")]
    private static void AddConfig()
    {

    }

    // 在RigidBody组件右键的菜单中添加一个新的菜单项
    [MenuItem("CONTEXT/Rigidbody/New Option")]
    private static void NewOpenForRigidBody()
    {
    }

    #endregion

    #region 验证

    // 两个函数，一个都不能少
    [MenuItem("Assets/ProcessTexture")]
    private static void DoSomethingWithTexture()
    {
        // 两个函数都会执行
        // 先执行这个
        Debug.Log("Do Something With Texture Without Valiation");
    }

    // 注意我们在传路径的同时，也传了第二个参数True
    [MenuItem("Assets/ProcessTexture", true)]
    private static bool NewMenuOptionValidation()
    {
        // 再执行这个
        Debug.Log("Do Something With Texture With Valiation");

        // 当所选对象是Texture2D时，该值返回true（否则该菜单项将被禁用）。
        return Selection.activeObject.GetType() == typeof(Texture2D);
    }


    #endregion

    #region 通过优先级控制菜单项顺序

    // 第三个参数代表了优先级，Unity自动将每50的增量作为一个组
    [MenuItem("NewMenu/Option1", false, 1)]
    private static void NewMenuOption1()
    {
    }

    [MenuItem("NewMenu/Option2", false, 2)]
    private static void NewMenuOption2()
    {
    }

    [MenuItem("NewMenu/Option3", false, 3)]
    private static void NewMenuOption3()
    {
    }

    [MenuItem("NewMenu/Option4", false, 51)]
    private static void NewMenuOption4()
    {
    }

    [MenuItem("NewMenu/Option5", false, 52)]
    private static void NewMenuOption5()
    {
    }

    #endregion


    #region 相关的类

    // 菜单命令(Menu Command)
    [MenuItem("CONTEXT/Rigidbody/Menu Command")]
    private static void NewMenuOption(MenuCommand menuCommand)
    {
        // RigidBody组件可以使用context字段从菜单命令中提取。
        var rigid = menuCommand.context as Rigidbody;
    }

    #endregion
}
