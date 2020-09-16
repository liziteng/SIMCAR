# SIMCAR
car simulator app

如果升级Unity版本会遇到如下问题:
1. Open_VR插件就会被删除. 这个插件删除了没事, 因为之后版本已经内置了.
2. 默认摄像机可能会被删除. 摄像机被删了再创建就好了. XR_Rig -> Camera_Offset -> Main_Camera(修改Tag)
3. 需要在项目设置里面把Player下面的XR_Setting再打开一下, 升级以后可能会自动关闭, 渲染模式还是改成单通道.(不用Oculus的话改一下SDK顺序)
