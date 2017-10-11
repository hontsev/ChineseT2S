# C# 下繁体字与简体字的转化

C#下虽然可以采用Microsoft.VisualBasic.Strings.StrConv()函数进行繁简转化（参考[此文][1]），但是存在转化不完全的问题。主要是部分异体字无法转化。
因此，我们根据[异体字整理表][2]和[繁简字对照表][3]来构建辅助字典，用于将未能成功转化的异体字或繁体字转化为简体字。
格式化的文档v2t.txt和s2t.txt放在了`Source/`中。已制作成dll便于调用。


#### DLL调用方法

```c#
var resString = T2SUtility.ToSimplified(oriString);
```



[1]: http://www.cnblogs.com/Clin/archive/2013/03/14/2959280.html
[2]: http://xh.5156edu.com/page/z5236m9179j19350.html
[3]: https://wenku.baidu.com/view/c812ed80a98271fe900ef904.html
