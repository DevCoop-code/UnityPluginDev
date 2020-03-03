# Unity Low-level native plug-in interface
https://docs.unity3d.com/Manual/NativePluginInterface.html

## Native plug-ins
Unity has extensive support for native plug-ins which are libraries of native code written in C, C++, Objective-C etc.<br>In Unity, you will also need to create a C# script which calls functions in the native library<br>
https://docs.unity3d.com/Manual/NativePlugins.html

## Interface Registry
A plug-in should export
- <b>UnityPluginLoad</b>
- <b>UnityPluginUnload</b>
<br>to handle main Unity events<br>
<b>IUnityInterfaces</b> is provided to the plug-in to access further Unity APIs

## Access to the Graphics Device
A plug-in can access generic graphics device functionality by getting the <b>IUnityGraphics</b> interface.(Since Unity 5.2)<br>
In earlier version, Instead of IUnityGraphics using <b>UnitySetGraphicsDevice</b> function

## Plug-in Callbacks on the Rendering Thread
When multithreaded rendering is used, the rendering API commands happen on a thread which is completely separate from the one that runs MonoBehaviour scripts<br><br>
In order to do any rendering from the plugin, you should call <b>GL.IssuePluginEvent</b> from your script. This will cause the provided native function to be called from the render thread.<br>
For example if you call GL.IssuePluginEvent from the camera's onPostRender function, you get a plugin callback immediately after the camera has finished rendering.

## Location of Unity API Header files
In Mac OS
- /Applications/Unity/Hub/Editor/<Your_Version>/Unity.app/Contents/PluginAPI

<br>In Window OS
- C:\Program Files\Unity\Editor\Data\PluginAPI\