# 概述
这是[柚子柚子](https://space.bilibili.com/1377882998)制作的MD5加密工具，可被用于命令行软件。
# 使用
## 所需文件
- md5.deps.json
- md5.dll
- md5.exe
- md5.runtimeconfig.json
## 运行
在文件目录下启动终端，执行命令：`md5 text`。其中，text为需要加密的内容。

如果运行无误，则命令行应该可以呈现出加密结果了。

如果需要加密的内容带有空格，您无需使用引号包裹文本，例如：`md5 t e x t`也可达到同样的效果。

如需将加密结果输入进文件，请运行：`md5 text>file.txt`。请注意，如果存在file.txt，该文件将会被覆盖。如需追加，请使用`md5 text>>file.txt`。
## 错误
如果运行出现错误，将会呈现错误信息。
### 哈希值不同
为了防止系统不稳定对加密结果的影响，该程序会进行两次加密，并比较结果。

当两次加密后的哈希值为不同数值，将会返回以下信息：

0x0000000

Error: Hash values are different.

This would usually caused by the system delay.

Please retry to solve this problem.

如果将结果输出至一个文件，您可以通过执行命令`type file.txt`以获取错误代码。
