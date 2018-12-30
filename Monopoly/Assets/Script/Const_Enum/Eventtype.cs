using UnityEngine;
using UnityEditor;

public enum Eventtype
{
    Forest,//森林事件，採到森林發生
    Personal,//個人事件，發生於個人內部
    Word,//全體事件，發生於所有人身上
    Apes,//猩猩事件，猩猩行動
    Block//格子事件，發生於踩到別人格子時
}