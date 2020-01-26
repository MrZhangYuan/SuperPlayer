namespace SuperPlayer.Core
{
    public enum ConfigID
    {
        /// <summary>
        /// ConfigId：1
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取一个 APlayer 引擎的组成文件的信息串。
        /// </summary>
        APlayerInfo = 1,

        /// <summary>
        /// ConfigId：2
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：解码器路径，允许用户自定义解码器的存放路径，默认为 APlayer.DLL 所在的路径的 codecs 目录
        /// </summary>
        Codecspath = 2,

        /// <summary>
        /// ConfigId：3
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：屏蔽的解码器 CLSID 列表
        /// </summary>
        Codecsdisablelist = 3,

        /// <summary>
        /// ConfigId：4
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  当前播放的媒体文件的 URL
        /// </summary>
        CurrentURL = 4,

        /// <summary>
        /// ConfigId：5
        /// 值类型：int64
        /// 读写（R/W）： R
        /// 描述：  当前播放的媒体文件的文件大小
        /// </summary>
        Filesize = 5,

        /// <summary>
        /// ConfigId：6
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：播放模式设置，1-播放, 2-格式转换, 3-转码, 默认值为1
        /// </summary>
        Playmode = 6,

        /// <summary>
        /// ConfigId：7
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  播放结果，0-播放完成, 1-主动关闭，其他-播放失败错误代码。
        /// </summary>
        Playresult = 7,

        /// <summary>
        /// ConfigId：8
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置是否打开成功后自动播放，0-不自动播放，1-自动播放，默认为1
        /// </summary>
        Autoplay = 8,

        /// <summary>
        /// ConfigId：9
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：当 APlayer 内部解码器播放失败后尝试使用系统解码器，0-不尝试，1-尝试，默认为0，尝试使用系统解码器可能会造成播放不稳定。
        /// </summary>
        Useopenchain = 9,

        /// <summary>
        /// ConfigId：10
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  查询系统声音设备列表，用";"分割。
        /// </summary>
        Sounddevicelist = 10,

        /// <summary>
        /// ConfigId：11
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置当前使用的声音设备。
        /// </summary>
        Sounddevicecurrent = 11,

        /// <summary>
        /// ConfigId：12
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：静音
        /// </summary>
        Soundsilent = 12,

        /// <summary>
        /// ConfigId：13
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：左右声道音量平衡，范围0-100，50代表左右声道音量相等。
        /// </summary>
        Soundbalance = 13,

        /// <summary>
        /// ConfigId：14
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：不渲染视频，即把视频当音频播放
        /// </summary>
        Disablevideo = 14,

        /// <summary>
        /// ConfigId：15
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：不渲染音频，即把视频无声播放
        /// </summary>
        Disableaudio = 15,

        /// <summary>
        /// ConfigId：16
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：是否激活 VsFilter，默认为1，即激活
        /// </summary>
        EnableVsFilter = 16,

        /// <summary>
        /// ConfigId：17
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否激活 AudioSwitcher，默认为1，即激活
        /// </summary>
        EnableAudioSwitcher = 17,

        /// <summary>
        /// ConfigId：18
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：下载解码器的模式，0-异步，1-同步，默认0
        /// </summary>
        Downloadcodecssync = 18,

        /// <summary>
        /// ConfigId：19
        /// 值类型： void
        /// 读写（R/W）：  W
        /// 描述：  用于在异步模式下，通知 APlayer，下载解码器已完成。
        /// </summary>
        Downloadcodecscompleted = 19,

        /// <summary>
        /// ConfigId：20
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  APlayer 视频窗口句柄
        /// </summary>
        Windowhandle = 20,

        /// <summary>
        /// ConfigId：21
        /// 值类型：  void
        /// 读写（R/W）：  W
        /// 描述：  通知 APlayer 顶层窗口位置已改变，更新 Overlay 渲染模式时的覆盖表面，使播放暂停时视频画面能跟着窗口移动。
        /// </summary>
        Windowmoved = 21,

        /// <summary>
        /// ConfigId：22
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  所支持的文本设置列表解释说明，例如：""video_bitrate;kbps;range(100,20000) \r\n 64_profile;none;list(main,base,high)"
        /// </summary>
        Settingexplain = 22,

        /// <summary>
        /// ConfigId：23
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：读取或修改文本设置，例如："video_bitrate=600;audio_bitrate=32;" 代表转码时把视频设置为600kbps，音频码率设置为32kbps
        /// </summary>
        Settingvalues = 23,

        /// <summary>
        /// ConfigId：24
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  装载 APlayer 插件，参数为插件 DLL 的全路径名（如果调用者需要获取或者修改 APlayer 解码后的图像和视频，可以使用 APlayer 插件来实现，详见 PluginDemo 例子)
        /// </summary>
        Loadplugin = 24,

        /// <summary>
        /// ConfigId：25
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  卸载 APlayer 插件，参数为插件 DLL 的全路径名（详见 PluginDemo 例子) 
        /// </summary>
        Freeplugin = 25,

        /// <summary>
        /// ConfigId：26
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：开启或者禁止播放 Flash 时的用户交互，1-开启，0-禁止，默认1
        /// </summary>
        Flashinteraction = 26,

        /// <summary>
        /// ConfigId：27
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否优先使用 Intel Media SDK 解码，1-优先，0-不优先，默认0
        /// </summary>
        IntelmediaSDKdecoder = 27,

        /// <summary>
        /// ConfigId：28
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否优先使用 Intel Media SDK 编码，1-优先，0-不优先，默认0
        /// </summary>
        IntelmediaSDKencoder = 28,

        /// <summary>
        /// ConfigId：29
        /// 值类型：  int64
        /// 读写（R/W）： R
        /// 描述：  当前播放文件总共读取字节数。
        /// </summary>
        Readsize = 29,

        /// <summary>
        /// ConfigId：30
        /// 值类型：int64
        /// 读写（R/W）： R
        /// 描述：  当前读取文件偏移字节数。
        /// </summary>
        Readoffset = 30,

        /// <summary>
        /// ConfigId：31
        /// 值类型： int64
        /// 读写（R/W）： R
        /// 描述：  当前读取时间点，单位毫秒。
        /// </summary>
        Readposition = 31,

        /// <summary>
        /// ConfigId：32
        /// 值类型：  int64
        /// 读写（R/W）： R
        /// 描述：  当前写入文件偏移(转码/转格式时候用到)。
        /// </summary>
        Writeoffset = 32,

        /// <summary>
        /// ConfigId：33
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置是否允许用户打开播放日志，1-允许，0-不允许，默认1
        /// </summary>
        Allowlog = 33,

        /// <summary>
        /// ConfigId：35
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置 APlayer 插件的导出函数调用方式，1-stdcall, 0-cdecl，默认0；设置这个参数的目的是支持不方便编译出 cdecl 调用的动态链接库的语言。
        /// </summary>
        Pluginstdcall = 35,

        /// <summary>
        /// ConfigId：36
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：Logo 风格设置，格式："backcolor;xpercent;ypercent"，例如设置白色背景(16777215为0xffffff的十进制串)、水平偏左(30%)、垂直居中(50%)的 Logo 位置："16777215;30;50"
        /// </summary>
        Logosettings = 36,

        /// <summary>
        /// ConfigId：37
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  设置本地或者 http 网络文件作为 Logo 图片，目前支持两种格式 BMP 和 JPG，参数为图片的全文件名或 URL，如果本地文件不存在或未拉取到网络图片，则不显示任何 Logo（相当于隐藏 Logo）。
        /// </summary>
        Logofile = 37,

        /// <summary>
        /// ConfigId：38
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置在 APlayer 视频窗口上显示的鼠标指针，参数为光标句柄 HCURSOR 类型，设置为 0 时恢复默认鼠标指针。
        /// </summary>
        Customcursor = 38,

        /// <summary>
        /// ConfigId：39
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置是否在播放 HLS 播放列表切换 URL 时发送 EVENTCODE_PLAYLIST 事件(id=10009)，适应某些不支持多线程事件的语言，比如 VB6。
        /// </summary>
        Disableplaylistevent = 39,

        /// <summary>
        /// ConfigId：40
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：获取或设置自定义 HLS 路径，当某些特殊 m3u8 地址，其 m3u8 引用的媒体文件或者 AES-Key 的路径不是地址中的路径时，使用本设置；本设置默认值为空；不再需要自定义HLS路径时，需要手动在APlayer.Open方法前把本参数设置为空字符串。
        /// </summary>
        HLSpath = 40,

        /// <summary>
        /// ConfigId：41
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  获取当前读取速度（对于网络文件来说就是下载速度），单位千字节每秒 (KB/s)
        /// </summary>
        Readspeed = 41,

        /// <summary>
        /// ConfigId：101
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  标志 GetPosition/SetPosition/GetDuration 函数所使用的单位是帧，还是毫秒，为1表示帧，0表示毫秒。
        /// </summary>
        Timeisframe = 101,

        /// <summary>
        /// ConfigId：102
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置文件打开后跳到哪里开始播放，单位毫秒。
        /// </summary>
        Startposition = 102,

        /// <summary>
        /// ConfigId：103
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置播放到哪里自动停止播放，单位毫秒。
        /// </summary>
        Stopposition = 103,

        /// <summary>
        /// ConfigId：104
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：播放速度，100-为正常速度，>100为快速播放，<100 为慢速播放。
        /// </summary>
        Playspeed = 104,

        /// <summary>
        /// ConfigId：105
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置 Seek 模式，1-Keyframe(Seek较快但不精确), 0-normal(Seek较慢但精确), 默认1
        /// </summary>
        Keyframeseek = 105,

        /// <summary>
        /// ConfigId：106
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  当前播放视频的关键帧个数
        /// </summary>
        Keyframecount = 106,

        /// <summary>
        /// ConfigId：107
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  当前播放视频的关键帧列表，单位毫秒，即这些时间点为关键帧，例如："0;12000;36000;52000;98000"
        /// </summary>
        Keyframelist = 107,

        /// <summary>
        /// ConfigId：108
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：当前播放的关键帧索引
        /// </summary>
        Keyframecurrent = 108,

        /// <summary>
        /// ConfigId：109
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  检查当前视频是否支持单帧步进
        /// </summary>
        Canframestepforwardone = 109,

        /// <summary>
        /// ConfigId：110
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  检查当前视频是否支持多帧步进
        /// </summary>
        Canframestepforwardmulti = 110,

        /// <summary>
        /// ConfigId：111
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  检查当前视频是否支持单帧步退
        /// </summary>
        Canframestepbackwardone = 111,

        /// <summary>
        /// ConfigId：112
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  检查当前视频是否支持多帧步退
        /// </summary>
        Canframestepbackwardmulti = 112,

        /// <summary>
        /// ConfigId：113
        /// 值类型： int
        /// 读写（R/W）：W
        /// 描述：  帧步进或步退，例如，1-单帧步进，-1-单帧步退，2-步进两帧，依此类推。
        /// </summary>
        Framestep = 113,

        /// <summary>
        /// ConfigId：114
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询是否当前正在帧步进步退过程中
        /// </summary>
        Isframestepping = 114,

        /// <summary>
        /// ConfigId：115
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：对于 RM/RMVB 文件为了打开速度快，默认不读取索引信息，所以不会有关键列表信息，设置这个参数为1后会打开时读取索引信息。
        /// </summary>
        Readindexwhenopen = 115,

        /// <summary>
        /// ConfigId：116
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  比关键帧信息更详细的关键帧-文件偏移列表信息，显示网络缓冲数据段状态时能用到该信息。
        /// </summary>
        Timepositionlist = 116,

        /// <summary>
        /// ConfigId：117
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取平均视频帧间隔，单位：毫秒。
        /// </summary>
        Frameinterval = 117,

        /// <summary>
        /// ConfigId：118
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  获取视频渲染器本次当前已经绘制的帧数。
        /// </summary>
        Framesdrawn = 118,

        /// <summary>
        /// ConfigId：119
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置循环播放, 0-自动, 1-循环, 2-不循环, 默认0 (自动模式中, GIF 会自动循环, 其他格式默认不循环)
        /// </summary>
        Loopplay = 119,

        /// <summary>
        /// ConfigId：120
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置是否播放完成不自动 Close (自动 Close 会返回 PS_READY 状态)，0-自动 Close，1-不自动 Close，默认 0，设置为1时，播放结束不自动 Close，调用者还可以 SetPositon 继续播放，但还是会发送 OnEvent(PLAYCOMPLETE) 事件
        /// </summary>
        Noclosewhencomplete = 120,

        /// <summary>
        /// ConfigId：121
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前视频的实时渲染帧率，返回格式为一个两位小数的浮点字符串，例如“30.26”。
        /// </summary>
        Framepersecond = 121,

        /// <summary>
        /// ConfigId：201
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：渲染模式设置, 1-Overlay, 2-Renderless, 3-EVR, 4-EVRCP, 5-AVR
        /// </summary>
        Rendermodeconfig = 201,

        /// <summary>
        /// ConfigId：202
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  当前使用的渲染模式。
        /// </summary>
        Rendermodecurrent = 202,

        /// <summary>
        /// ConfigId：203
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  视频的自然纵横比，格式："4;3"
        /// </summary>
        Aspectrationative = 203,

        /// <summary>
        /// ConfigId：204
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：视频的自定义纵横比，格式："4;3"
        /// </summary>
        Aspectratiocustom = 204,

        /// <summary>
        /// ConfigId：205
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：视频的源矩形，格式："left;top;right;bottom", 例如只显示左上角400x300区域："0;0;400;300"
        /// </summary>
        Videosourceposition = 205,

        /// <summary>
        /// ConfigId：206
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：视频的目标矩形，即视频画面在视频区域的中的位置，格式："left;top;right;bottom"
        /// </summary>
        Videotargetpsoition = 206,

        /// <summary>
        /// ConfigId：207
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：播放时智能去除当前视频黑边 (只是渲染时去除，不改变视频内容)
        /// </summary>
        Clipblackbandenable = 207,

        /// <summary>
        /// ConfigId：208
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置智能去黑边的阈值，低于这个亮度就算做黑边。
        /// </summary>
        Clipblackbandstill = 208,

        /// <summary>
        /// ConfigId：209
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置是否开启硬件加速，1-开启，0-不开启
        /// </summary>
        Speedupenable = 209,

        /// <summary>
        /// ConfigId：210
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置硬件加速优先使用 CUDA，而不是 DXVA/DXVA2。
        /// </summary>
        SpeedupCUDAfirst = 210,

        /// <summary>
        /// ConfigId：211
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  返回硬件加速的开启状态：0 - 未开启, 1 - 开启成功, 2 - 未知错误, 3 - 设备不支持, 4 - 格式不支持, 5 - 操作系统不支持, 6 - 解码器不支持
        /// </summary>
        Speedupstatus = 211,

        /// <summary>
        /// ConfigId：212
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  返回一个字符串，表征开启了何种硬件加速。
        /// </summary>
        Speedupquery = 212,

        /// <summary>
        /// ConfigId：213
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  查询色彩调节功能是否可用，0-不可用，1-可用
        /// </summary>
        Videoadjustusable = 213,

        /// <summary>
        /// ConfigId：214
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：亮度调节，范围 0-100，默认50
        /// </summary>
        Brightness = 214,

        /// <summary>
        /// ConfigId：215
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：对比度调节，范围 0-100，默认50
        /// </summary>
        Contrast = 215,

        /// <summary>
        /// ConfigId：216
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：饱和度调节，范围 0-100，默认50
        /// </summary>
        Saturation = 216,

        /// <summary>
        /// ConfigId：217
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：色相调节，范围 0-100，默认50
        /// </summary>
        Hue = 217,

        /// <summary>
        /// ConfigId：220
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  获取视频编码格式，例如："AVC1"
        /// </summary>
        Videocodec = 220,

        /// <summary>
        /// ConfigId：221
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前视频输出格式，例如："YV12"
        /// </summary>
        Videooutputformat = 221,

        /// <summary>
        /// ConfigId：301
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询视频图像处理功能是否可用。
        /// </summary>
        Imageprocessusable = 301,

        /// <summary>
        /// ConfigId：302
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：水平翻转, 1-翻转, 0-不翻转
        /// </summary>
        ImageflipH = 302,

        /// <summary>
        /// ConfigId：303
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：垂直翻转, 1-翻转, 0-不翻转
        /// </summary>
        ImageflipV = 303,

        /// <summary>
        /// ConfigId：304
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：图像旋转, 参数为旋转度数(0-360)
        /// </summary>
        Imagerotate = 304,

        /// <summary>
        /// ConfigId：305
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：画质增强, 1-开启, 0-不开启
        /// </summary>
        Imagenormalizeenable = 305,

        /// <summary>
        /// ConfigId：306
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：画质对比, 1-开启, 0-不开启
        /// </summary>
        Imagenormalizecompare = 306,

        /// <summary>
        /// ConfigId：308
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：激活分色 3D 播放模式，1-激活, 0-不激活，默认0，Open 之前调用
        /// </summary>
        Image3Denable = 308,

        /// <summary>
        /// ConfigId：309
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  查询分色 3D 模式是否已激活，1-激活, 0-未激活。
        /// </summary>
        Image3Dokay = 309,

        /// <summary>
        /// ConfigId：310
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否显示分色 3D 效果，1-显示，0-不显示，默认 1
        /// </summary>
        Image3Dshow = 310,

        /// <summary>
        /// ConfigId：311
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：分色模式，1-虚拟(2D转3D)，2-左右，3-上下，默认 1
        /// </summary>
        Image3Dmode = 311,

        /// <summary>
        /// ConfigId：312
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：分色颜色，以匹配不同的 3D 眼镜，1:红青,2:青红,3:黄蓝,4:蓝黄,5:绿紫,6:紫绿,7:红绿,8:绿红,9:绿蓝,10:蓝绿,11:红蓝,12:蓝红, 默认 1
        /// </summary>
        Image3Dcolor = 312,

        /// <summary>
        /// ConfigId：313
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：图像处理是否使用 OpenGL 加速，1-使用，0-不是用，默认1
        /// </summary>
        ImageuseOpenCL = 313,

        /// <summary>
        /// ConfigId：314
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：图像处理是否使用 AVX2 加速，1-使用，0-不是用，默认1
        /// </summary>
        ImageuseAVX2 = 314,

        /// <summary>
        /// ConfigId：315
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：图像处理是否使用 SSE2 加速，1-使用，0-不是用，默认1
        /// </summary>
        ImageuseSSE2 = 315,

        /// <summary>
        /// ConfigId：401
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询声音处理功能是否可用。
        /// </summary>
        Audioprocessusable = 401,

        /// <summary>
        /// ConfigId：402
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  音轨列表, 格式: "音轨1;音轨2"
        /// </summary>
        Audiotracklist = 402,

        /// <summary>
        /// ConfigId：403
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置当前音轨索引, 索引值从 0 开始
        /// </summary>
        Audiotrackcurrent = 403,

        /// <summary>
        /// ConfigId：404
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置声道映射, 0-立体声, 1-左声道, 2-右声道, 3-左右混合
        /// </summary>
        Audiochannel = 404,

        /// <summary>
        /// ConfigId：405
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：声道延时设置, +值为延后, -值为提前, 单位毫秒。
        /// </summary>
        Audiotimeshift = 405,

        /// <summary>
        /// ConfigId：406
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：统一音量功能, 1-开启, 0-不开启
        /// </summary>
        Audionormalize = 406,

        /// <summary>
        /// ConfigId：407
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：开启虚拟环绕声功能，1-开启, 0-不开启，默认0
        /// </summary>
        AudioVSSEnable = 407,

        /// <summary>
        /// ConfigId：408
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：虚拟环绕声深度，0-30，默认10。
        /// </summary>
        AudioVSSdeep = 408,

        /// <summary>
        /// ConfigId：409
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  加载外部媒体文件作为当前媒体的一个音轨，参数值为外部媒体文件路径。
        /// </summary>
        Audioloadtrack = 409,

        /// <summary>
        /// ConfigId：410
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  获取输入音频编码格式，例如："AAC"
        /// </summary>
        Audiocodec = 410,

        /// <summary>
        /// ConfigId：411
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取输入音频的声道数
        /// </summary>
        Audioinputchannels = 411,

        /// <summary>
        /// ConfigId：412
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取输入音频的采样率，例如: "44100"
        /// </summary>
        Audioinputsamplerate = 412,

        /// <summary>
        /// ConfigId：413
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  获取输入音频的采样位数，例如："16"
        /// </summary>
        Audioinputsamplebit = 413,

        /// <summary>
        /// ConfigId：414
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前音频输出格式，例如："PCM"
        /// </summary>
        Audiooutputformat = 414,

        /// <summary>
        /// ConfigId：415
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  获取当前音频输出声道数
        /// </summary>
        Audiooutputchannels = 415,

        /// <summary>
        /// ConfigId：416
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  获取当前音频输出采样率，例如："44100"
        /// </summary>
        Audiooutputsamplerate = 416,

        /// <summary>
        /// ConfigId：417
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取当前音频输出采样位数，例如："16"
        /// </summary>
        Audiooutputsamplebit = 417,

        /// <summary>
        /// ConfigId：501
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  查询字幕加载功能是否可用。
        /// </summary>
        Subtilteusable = 501,

        /// <summary>
        /// ConfigId：502
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  支持的字幕格式列表，例如："srt;ssa;ass;idx"
        /// </summary>
        Subtitleextnamelist = 502,

        /// <summary>
        /// ConfigId：503
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：外挂字幕的文件名，例如："c:\subtitle.srt"
        /// </summary>
        Subtiltefilename = 503,

        /// <summary>
        /// ConfigId：504
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：显示或隐藏字幕，0-隐藏，1-显示
        /// </summary>
        Subtitleshow = 504,

        /// <summary>
        /// ConfigId：505
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  当前加载的字幕的可用语言列表，用";"分割，例如："chinese;english"
        /// </summary>
        Subtitlelanguagelist = 505,

        /// <summary>
        /// ConfigId：506
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：当前选择的字幕语言索引。
        /// </summary>
        Subtitlelangeuagecurrent = 506,

        /// <summary>
        /// ConfigId：507
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕位置，例如："1;50;90"，其中 1表示设置生效，50表示设置在水平位置 50%，90垂直位置 90%"
        /// </summary>
        Subtitleplacement = 507,

        /// <summary>
        /// ConfigId：508
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕默认字体，格式："fontname;fontsize;fontcolor;shadow"，例如："宋体;18;16777215;1"
        /// </summary>
        Subtitlefont = 508,

        /// <summary>
        /// ConfigId：509
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕延时，格式，"delay;speedmul;speeddiv"，例如："5000;1000;1000"，表示字幕延时 5000 毫秒。
        /// </summary>
        Subtitletiming = 509,

        /// <summary>
        /// ConfigId：510
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置字幕3D渲染模式，0-正常(2D)，1-左右3D，2-上下3D。
        /// </summary>
        Subtitle3D = 510,

        /// <summary>
        /// ConfigId：511
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  设置字符串形式的内存字幕，Unicode 格式。
        /// </summary>
        Subtitlecontent = 511,

        /// <summary>
        /// ConfigId：601
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询视频叠图加功能是否可用。
        /// </summary>
        Pictureusable = 601,

        /// <summary>
        /// ConfigId：602
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：激活视频叠图加功能, 1-激活, 0-不激活
        /// </summary>
        Pictureenable = 602,

        /// <summary>
        /// ConfigId：603
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取图像可叠加区域，坐标基于 APlayer 视频窗口, 格式："left;top;right;bottom"
        /// </summary>
        Picturebound = 603,

        /// <summary>
        /// ConfigId：604
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  获取图像宽度, 单位像素。
        /// </summary>
        Picturewidth = 604,

        /// <summary>
        /// ConfigId：605
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取图像高度, 单位像素。
        /// </summary>
        Pictureheight = 605,

        /// <summary>
        /// ConfigId：606
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置叠加图像水平位置，单位像素。
        /// </summary>
        Pictureleft = 606,

        /// <summary>
        /// ConfigId：607
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置叠加图像垂直位置，单位像素。
        /// </summary>
        Picturetop = 607,

        /// <summary>
        /// ConfigId：608
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置叠加图像的 alpha 值，范围 0-255，0为完全透明，255为完全不透明。
        /// </summary>
        Picturealpha = 608,

        /// <summary>
        /// ConfigId：609
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：图像颜色键，图像中颜色等于颜色键的区域自动完全透明，如果该值为-1，则使用图像自身的 Alpha 通道。
        /// </summary>
        Picturecolorkey = 609,

        /// <summary>
        /// ConfigId：610
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  测试一个位置是否命中了所叠加的图像，格式："x;y"，返回值，0-未命中，1-命中图像的矩形区域，2-命中图像的可见区域。
        /// </summary>
        Picturehittest = 610,

        /// <summary>
        /// ConfigId：611
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置命中测试的 alpha 下限，如果图像中某像素的 alpha 值小于该下限则不会被视为可命中的可见区域。
        /// </summary>
        Picturehitalpha = 611,

        /// <summary>
        /// ConfigId：612
        /// 值类型： str
        /// 读写（R/W）：W
        /// 描述：  设置一段文本作为叠加图像，值为文本内容，支持回车换行符主动换行和自动换行（文本宽度参数 623 限制下的自动换行）。
        /// </summary>
        Picturetext = 612,

        /// <summary>
        /// ConfigId：613
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：获取或设置叠加文本的字体，格式："fontname;fontsize;fontcolor;edge"
        /// </summary>
        Picturefont = 613,

        /// <summary>
        /// ConfigId：614
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  叠加一个 RGBA 内存区，格式："address;width;height"
        /// </summary>
        PictureRGBAbuffer = 614,

        /// <summary>
        /// ConfigId：615
        /// 值类型： int
        /// 读写（R/W）：W
        /// 描述：  叠加一个 BMP 位图，参数为该位图的句柄
        /// </summary>
        PictureBMPhandle = 615,

        /// <summary>
        /// ConfigId：616
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  叠加一个 BMP 位图文件，值为文件的路径，例如："C:\test.bmp"
        /// </summary>
        PictureBMPfilename = 616,

        /// <summary>
        /// ConfigId：617
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  叠加一个 PNG 图像文件，值为文件的路径，例如："C:\test.png"
        /// </summary>
        PicturePNGfilename = 617,

        /// <summary>
        /// ConfigId：618
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  叠加一个 SWF 动画文件，值为文件的路径，例如："C:\test.swf"
        /// </summary>
        PictureSWFfilename = 618,

        /// <summary>
        /// ConfigId：619
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：获取或设置叠加 SWF 图像大小，格式："width;height"，默认值："150;150"
        /// </summary>
        PictureSWFsize = 619,

        /// <summary>
        /// ConfigId：620
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  获取所叠加的 SWF 文件的 OLE 容器控件的指针，即 ShockwaveFlashObjects::IShockwaveFlash* 类型
        /// </summary>
        PictureSWFcontrol = 620,

        /// <summary>
        /// ConfigId：621
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置 EVRCP 是否使用线形插值叠图，0-不是用，1-使用，默认0
        /// </summary>
        PictureEVRCPlinear = 621,

        /// <summary>
        /// ConfigId：622
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置为 0 时图片在窗口上，设置为 1 时，图片附加到视频上，而不是在当前视口，感觉就像场景中的物体，这时的可叠加范围为视频尺寸。
        /// </summary>
        PictureattachtoVR = 622,

        /// <summary>
        /// ConfigId：623
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置多行文本时每行文本的宽度，默认2000像素。
        /// </summary>
        Picturelinewidth = 623,

        /// <summary>
        /// ConfigId：624
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置多行文本时的行距，默认5像素。
        /// </summary>
        Picturelinespace = 624,

        /// <summary>
        /// ConfigId：701
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  查询截图功能是否可用。
        /// </summary>
        Snapshotusable = 701,

        /// <summary>
        /// ConfigId：702
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  截取当前视频图像，值为文件路径，例如："C:\snapshot.bmp"
        /// </summary>
        Snapshotimage = 702,

        /// <summary>
        /// ConfigId：703
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：截图的宽度，单位像素。
        /// </summary>
        Snapshotwidth = 703,

        /// <summary>
        /// ConfigId：704
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：截图的高度，单位像素。
        /// </summary>
        Snapshotheight = 704,

        /// <summary>
        /// ConfigId：705
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置选择截取视频画面矩形的哪些区域，格式："left;top;right;bottom"，默认："0;0;视频宽度;视频高度"
        /// </summary>
        Snapshotsourceposition = 705,

        /// <summary>
        /// ConfigId：706
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置截图时是否保持纵横比，需要 703 和 704 参数均不设置为 0
        /// </summary>
        Snapshotkeepaspect = 706,

        /// <summary>
        /// ConfigId：707
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：截图的输出格式，1-bmp, 2-jpg, 3-png, 4-gif, 默认为 1。
        /// </summary>
        Snapshotformat = 707,

        /// <summary>
        /// ConfigId：708
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：截取成 jpeg 时候的画面质量，范围：10-100，默认 75，越高质量越好，文件越大。
        /// </summary>
        Snapshotjpegquality = 708,

        /// <summary>
        /// ConfigId：709
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：GIF截取时的附加参数，格式："length=6000;cutinterval=200;playinterval=100"，其中数值单位为毫秒
        /// </summary>
        Snapshotgifparam = 709,

        /// <summary>
        /// ConfigId：710
        /// 值类型：  void
        /// 读写（R/W）：  W
        /// 描述：  终止一个正在进行的 GIF 截取操作。
        /// </summary>
        Snapshotabort = 710,

        /// <summary>
        /// ConfigId：711
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询是否正在进行 GIF 截取操作
        /// </summary>
        Snapshotgifworking = 711,

        /// <summary>
        /// ConfigId：712
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  查询当前 GIF 截取操作的进度百分比，范围 0-100，100表示截取完成。
        /// </summary>
        Snapshotgifprogress = 712,

        /// <summary>
        /// ConfigId：801
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  查询视频截取功能是否可用。
        /// </summary>
        Cutusable = 801,

        /// <summary>
        /// ConfigId：802
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  可用的截取输出格式，用分号分割，格式："wmv;mp4;rmvb"
        /// </summary>
        Cutformatlist = 802,

        /// <summary>
        /// ConfigId：803
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：选择使用的截取格式。
        /// </summary>
        Cutformatcurrent = 803,

        /// <summary>
        /// ConfigId：804
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：视频截取输出文件名。
        /// </summary>
        Cutfilename = 804,

        /// <summary>
        /// ConfigId：901
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：视频转码输出宽度，单位像素。
        /// </summary>
        Transcodevideowidth = 901,

        /// <summary>
        /// ConfigId：902
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：视频转码输出高度，单位像素。
        /// </summary>
        Transcodevideoheight = 902,

        /// <summary>
        /// ConfigId：903
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：视频转码时是否保持原始视频的纵横比，1-保持，0-不保持，默认为保持1
        /// </summary>
        Transcodekeepaspectratio = 903,

        /// <summary>
        /// ConfigId：904
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置转码时是否把视频 Resize 到 16 的整倍数。
        /// </summary>
        Transcoderoundsize = 904,

        /// <summary>
        /// ConfigId：905
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：视频转码输出的音轨的索引，从0开始
        /// </summary>
        Transcodeaudiotrack = 905,

        /// <summary>
        /// ConfigId：906
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：视频转码输出的字幕语言的索引，从0开始
        /// </summary>
        Transcodesubtitlelanguage = 906,

        /// <summary>
        /// ConfigId：907
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置视频转码时"左上右下"需要去除的黑边值，单位为像素，格式："left;top;right;bottom"，默认为："0;0;0;0"，如果设置了该值不为"0;0;0;0"，为保持视频不被拉伸变形，请设置符合原始纵横比的新转码输出宽高，并且把 903 设置为"不保持纵横比"
        /// </summary>
        Transcodecropborder = 907,

        /// <summary>
        /// ConfigId：1001
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置当网络没有读取到数据时，等待多少个视频帧进入缓冲（可以通过视频帧率换算成时间），默认为 500
        /// </summary>
        Networkbufferenter = 1001,

        /// <summary>
        /// ConfigId：1002
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置在缓冲状态下，缓冲多少个帧退出缓冲，默认为 1000
        /// </summary>
        Networkbufferleave = 1002,

        /// <summary>
        /// ConfigId：1003
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置未缓冲状态下，最多预先读取多少个帧，即数据读取时间点超前当前播放时间点的距离。
        /// </summary>
        Networknobufferdry = 1003,

        /// <summary>
        /// ConfigId：1004
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置拖动播放进度后，没有数据时多久进入缓冲，单位毫秒。
        /// </summary>
        Networkseekbuffertimeout = 1004,

        /// <summary>
        /// ConfigId：1102
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：播放 HTTP 网络视频时，失败重连次数，默认为 5 次。
        /// </summary>
        Httpfailreconnectcount = 1102,

        /// <summary>
        /// ConfigId：1103
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：HTTP 重连间隔，默认为 500 毫秒。
        /// </summary>
        Httpfailreconnectinterval = 1103,

        /// <summary>
        /// ConfigId：1104
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置工作模式，0-常规，1-直播，默认为 0。
        /// </summary>
        Httplive = 1104,

        /// <summary>
        /// ConfigId：1105
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 Cookie 字符串，默认为无。
        /// </summary>
        Httpcookie = 1105,

        /// <summary>
        /// ConfigId：1106
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 Referer 字符串，默认为无。
        /// </summary>
        Httpreferer = 1106,

        /// <summary>
        /// ConfigId：1107
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 自定义头字段列表，每个头字段之间用回车换行符号 "\r\n"(即 0x0d，0x0a) 分割。
        /// </summary>
        Httpcustomheaders = 1107,

        /// <summary>
        /// ConfigId：1108
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 User Agent 字符串，默认为 APlayer 的默认值。
        /// </summary>
        Httpuseragent = 1108,

        /// <summary>
        /// ConfigId：1109
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 Connection 字符串，默认为 "Keep-Alive"
        /// </summary>
        Httpconnection = 1109,

        /// <summary>
        /// ConfigId：1110
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 Accept 字符串，默认为 "*/*"
        /// </summary>
        Httpaccept = 1110,

        /// <summary>
        /// ConfigId：1111
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置 HTTP 请求头中带的 Accept-Encoding 字符串 "identity"
        /// </summary>
        Httpacceptencoding = 1111,

        /// <summary>
        /// ConfigId：1301
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  查询歌词功能是否可用，该功能可以用来在播放音乐文件时显示歌词。
        /// </summary>
        Lyricusable = 1301,

        /// <summary>
        /// ConfigId：1302
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：显示或隐藏歌词, 0-隐藏, 1-显示, 默认1
        /// </summary>
        Lyricshow = 1302,

        /// <summary>
        /// ConfigId：1303
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：歌词显示动画更新间隔, 单位毫秒, 间隔越小消耗的CPU越多, 但越流畅。
        /// </summary>
        Lyricupdatetime = 1303,

        /// <summary>
        /// ConfigId：1304
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置的歌词格式，0-LRC格式，目前只支持 LRC 格式。
        /// </summary>
        Lyricformat = 1304,

        /// <summary>
        /// ConfigId：1305
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置显示歌词的文件名，例如：C:\mysong.lrc，目前只支持 LRC 格式的歌词。
        /// </summary>
        Lyricfile = 1305,

        /// <summary>
        /// ConfigId：1306
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：如果不通过文件名来设置歌词，也可以通过歌词内容字符串来设置歌词，同样字符串为 LRC 格式。
        /// </summary>
        Lyriccontent = 1306,

        /// <summary>
        /// ConfigId：1307
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：歌词背景颜色，例如白色为"16777215"，即 0xffffff 的十进制串。
        /// </summary>
        Lyricbackcolor = 1307,

        /// <summary>
        /// ConfigId：1308
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：歌词背景图片文件，目前支持 bmp/jpeg 两种格式；设置为空串，则清除背景图片。
        /// </summary>
        Lyricpicturefilename = 1308,

        /// <summary>
        /// ConfigId：1309
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：歌词背景位图句柄，为 HBITMAP 类型的值；设置为0时，则清除背景图片。
        /// </summary>
        Lyricpicturehandle = 1309,

        /// <summary>
        /// ConfigId：1310
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：歌词背景图覆盖模式，1-居中，2-拉伸，3-保持纵横比拉伸，默认为1
        /// </summary>
        Lyricpicturemode = 1310,

        /// <summary>
        /// ConfigId：1311
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：歌词字体设置，格式："font_name;font_width;font_height;font_weight;linespace"，font_weight 为字重，linespace 为行距，例如："黑体;30;20;500;10"
        /// </summary>
        Lyricfont = 1311,

        /// <summary>
        /// ConfigId：1312
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：歌词文字颜色，例如白色为"16777215"，即 0xffffff 的十进制串。
        /// </summary>
        Lyricfontnormalcolor = 1312,

        /// <summary>
        /// ConfigId：1313
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：歌词文字高亮色，例如白色为"16777215"，即 0xffffff 的十进制串。
        /// </summary>
        Lyricfonthighlightcolor = 1313,

        /// <summary>
        /// ConfigId：1314
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否现实文字左右边框。
        /// </summary>
        Lyricframeenable = 1314,

        /// <summary>
        /// ConfigId：1315
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：文字框颜色。
        /// </summary>
        Lyricframecolor = 1315,

        /// <summary>
        /// ConfigId：1316
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：歌词边缘模糊度，默认为1，越大越模糊，便于融入背景图片。
        /// </summary>
        Lyricsmoothmultiple = 1316,

        /// <summary>
        /// ConfigId：1318
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词顶部和底部是否开启渐入渐出效果，1-开启，0-关闭，默认为1
        /// </summary>
        Lyricalpha = 1318,

        /// <summary>
        /// ConfigId：1319
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置当前所唱句歌词动画风格，0-无动画，1-渐变，2-进度条，默认为 2
        /// </summary>
        Lyricanimation = 1319,

        /// <summary>
        /// ConfigId：1320
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词的时间偏移，单位毫秒。
        /// </summary>
        Lyrictimeoffset = 1320,

        /// <summary>
        /// ConfigId：1321
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：开启或者屏蔽歌词拖动功能(用来方便用户手动调整时间偏移)，1-开启，0-屏蔽，默认为1
        /// </summary>
        Lyricdragenable = 1321,

        /// <summary>
        /// ConfigId：1322
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖动线颜色，例如白色为"16777215"，即 0xffffff 的十进制串。
        /// </summary>
        Lyricdraglinecolor = 1322,

        /// <summary>
        /// ConfigId：1323
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖动同步提示文本颜色，例如白色为"16777215"，即 0xffffff 的十进制串。
        /// </summary>
        Lyricdragtextcolor = 1323,

        /// <summary>
        /// ConfigId：1324
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖动同步提示左侧文本，默认为“按住Ctrl同步歌词"
        /// </summary>
        Lyricdragtextleft = 1324,

        /// <summary>
        /// ConfigId：1325
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖动同步提示右侧文本提前提示，默认为“歌词提前 %.1f 秒”
        /// </summary>
        Lyricdragtextrightfront = 1325,

        /// <summary>
        /// ConfigId：1326
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖动同步提示右侧文本推迟提示，默认为“歌词推迟 %.1f 秒”
        /// </summary>
        Lyricdragtextrightback = 1326,

        /// <summary>
        /// ConfigId：1327
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词拖东同步提示文本数值单位，默认为 100，即 1毫秒数/100=0.1秒，该值不能为0
        /// </summary>
        Lyricdragtextrightdiv = 1327,

        /// <summary>
        /// ConfigId：1328
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置歌词文本对齐方式，0-居中对齐，1-左对齐，2-右对齐，默认为0
        /// </summary>
        Lyricalign = 1328,

        //注：APlayer 打开一个完整DVD文件夹(可以存储在光碟或者硬盘中)中的 VIDEO_TS.IFO 文件即进入DVD播放模式。

        /// <summary>
        /// ConfigId：1401
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  播放 DVD 视频时章节列表, 格式："主题1章结数;主题2章结数;主题3章节数"，例如："5;3"，代表主题1包含5个章节，主题2包含3个章节；
        /// </summary>
        DVDchapters = 1401,

        /// <summary>
        /// ConfigId：1402
        /// 值类型：int
        /// 读写（R/W）：R
        /// 描述：  DVD 观察视角数。
        /// </summary>
        DVDanglecount = 1402,

        /// <summary>
        /// ConfigId：1403
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  DVD 音轨列表，例如："中文对白;英文对白"
        /// </summary>
        DVDaudios = 1403,

        /// <summary>
        /// ConfigId：1404
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  DVD 字幕列表，例如："中文字幕;英文字幕;繁体字幕"
        /// </summary>
        DVDsubpictures = 1404,

        /// <summary>
        /// ConfigId：1405
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置或获取 DVD 当前播放的章节索引，格式："主题索引;章节索引"，例如："1;3"，代表播放主题1中的第3章节，索引从1开始。
        /// </summary>
        DVDcurrentchapter = 1405,

        /// <summary>
        /// ConfigId：1406
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取 DVD 当前播放的观察视角索引，从1开始。
        /// </summary>
        DVDcurrentangle = 1406,

        /// <summary>
        /// ConfigId：1407
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取 DVD 当前播放的音轨索引，从1开始。
        /// </summary>
        DVDcurrentaudio = 1407,

        /// <summary>
        /// ConfigId：1408
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取 DVD 当前播放的字幕索引，从1开始。
        /// </summary>
        DVDcurrentsubpicture = 1408,

        /// <summary>
        /// ConfigId：1409
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取 DVD 当前播放的内容分级，从1开始。
        /// </summary>
        DVDcurrentparentallevel = 1409,

        /// <summary>
        /// ConfigId：1410
        /// 值类型：  int
        /// 读写（R/W）：W
        /// 描述：  在视频窗口显示 DVD 菜单，参数为菜单 ID，1-主题菜单，2-根菜单，3-字幕菜单，4-音轨菜单，5-视角菜单，6-章节菜单。
        /// </summary>
        DVDshowmenu = 1410,

        /// <summary>
        /// ConfigId：1411
        /// 值类型：  int
        /// 读写（R/W）：W
        /// 描述：  按下 DVD 视频中某个键，参数为键的类型，1-左键，2-右键，3-上键，4-下键，5-接受键，6-返回键
        /// </summary>
        DVDpressbutton = 1411,

        /// <summary>
        /// ConfigId：1412
        /// 值类型：  int
        /// 读写（R/W）：W
        /// 描述：  DVD 章节跳播，1-跳到下一章节，2-跳到上一章节。
        /// </summary>
        DVDskipchapter = 1412,

        /// <summary>
        /// ConfigId：1413
        /// 值类型：  int
        /// 读写（R/W）：W
        /// 描述：  DVD 快进，参数为快进速度，例如：100 为正常速度，800 为 8 倍速快进。
        /// </summary>
        DVDplayforward = 1413,

        /// <summary>
        /// ConfigId：1414
        /// 值类型： int
        /// 读写（R/W）：W
        /// 描述：  DVD 快退，参数为快退速度，例如：100 为正常速度，800 为 8 倍速快退。
        /// </summary>
        DVDplaybackward = 1414,

        /// <summary>
        /// ConfigId：1415
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  查询 DVD 视频是否现在需要进行交互。
        /// </summary>
        DVDneedinteraction = 1415,

        /// <summary>
        /// ConfigId：1501
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  查询 AC3-DTS 5.1声道等控制功能是否可用。
        /// </summary>
        AC3DTSusable = 1501,

        /// <summary>
        /// ConfigId：1502
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：AC3-DTS 5.1声道混合输出模式，1-单声道输出，2-立体声输出，3-5.1声道输出，4-SPDIF 输出。
        /// </summary>
        AC3DTSoutputmode = 1502,

        /// <summary>
        /// ConfigId：1503
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：AC3-DTS 5.1声道中人声音量，范围0-100，默认 20
        /// </summary>
        AC3DTSvoicevolume = 1503,

        /// <summary>
        /// ConfigId：1801
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取是否激活 DLNA(数字生活网络联盟) 功能，该功能允许把播放画面投射到支持 DLNA 设备的电视机或其他显示设备上。
        /// </summary>
        DLNAenable = 1801,

        /// <summary>
        /// ConfigId：1802
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  当前局域网中可用的 DLNA 设备列表，格式："name1;id1;wmv,mp4\r\nname2;id2;flv,wmv,mkv\r\n..."，每行表示一个设备的信息，其中id为设备标识。
        /// </summary>
        DLNAdevicelist = 1802,

        /// <summary>
        /// ConfigId：1803
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：当前选择的设备标识，空字符串意味着不在任何DLNA设备上播放（即在本机播放)。
        /// </summary>
        DLNAcurrentdevice = 1803,

        /// <summary>
        /// ConfigId：1804
        /// 值类型：void
        /// 读写（R/W）：  W
        /// 描述：  强制刷新设备列表，刷新后的设备列表可以用 1802 参数获取。
        /// </summary>
        DLNAsearchdevice = 1804,

        /// <summary>
        /// ConfigId：2101
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  查询字幕2加载功能是否可用。
        /// </summary>
        Subtilte2usable = 2101,

        /// <summary>
        /// ConfigId：2102
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  支持的字幕2格式列表，例如："srt;ssa;ass;idx"
        /// </summary>
        Subtitle2extnamelist = 2102,

        /// <summary>
        /// ConfigId：2103
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：外挂字幕2的文件名，例如："c:\subtitle.srt"
        /// </summary>
        Subtilte2filename = 2103,

        /// <summary>
        /// ConfigId：2104
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：显示或隐藏字幕2，0-隐藏，1-显示
        /// </summary>
        Subtitle2show = 2104,

        /// <summary>
        /// ConfigId：2105
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  当前加载的字幕2的可用语言列表，用";"分割，例如："chinese;english"
        /// </summary>
        Subtitle2languagelist = 2105,

        /// <summary>
        /// ConfigId：2106
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：当前选择的字幕2语言索引。
        /// </summary>
        Subtitle2langeuagecurrent = 2106,

        /// <summary>
        /// ConfigId：2107
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕2位置，例如："1;50;90"，其中 1表示设置生效，50表示设置在水平位置 50%，90垂直位置 90%"
        /// </summary>
        Subtitle2placement = 2107,

        /// <summary>
        /// ConfigId：2108
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕2默认字体，格式："fontname;fontsize;fontcolor;shadow"，例如："宋体;18;16777215;1"
        /// </summary>
        Subtitle2font = 2108,

        /// <summary>
        /// ConfigId：2109
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：设置字幕2延时，格式，"delay;speedmul;speeddiv"，例如："5000;1000;1000"，表示字幕延时 5000 毫秒。
        /// </summary>
        Subtitle2timing = 2109,

        /// <summary>
        /// ConfigId：2110
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置字幕2的3D渲染模式，0-正常(2D)，1-左右3D，1-上下3D。
        /// </summary>
        Subtitle23D = 2110,

        /// <summary>
        /// ConfigId：2111
        /// 值类型： str
        /// 读写（R/W）：W
        /// 描述：  设置字符串形式的内存字幕2，Unicode 格式。
        /// </summary>
        Subtitle2content = 2111,

        /// <summary>
        /// ConfigId：2201
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：在线播放时本地缓存文件名，如设置为空字符串，则不缓存到本地；该参数默认值为空字符串；缓存文件也可以用 APlayer 打开继续播放。
        /// </summary>
        Cachefilename = 2201,

        /// <summary>
        /// ConfigId：2202
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：强制清除缓存文件的内容，该参数设置后，若打开在线文件，则本地文件重新开始缓存。
        /// </summary>
        Cacheclear = 2202,

        /// <summary>
        /// ConfigId：2203
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  读取整个缓存中已下载块信息列表，格式“110100111010...”，其中每个字符代表一个缓存块（大小640KB），这些块从文件头开始顺序排列，如果该块下载完成了则为1，否则为0。
        /// </summary>
        Cachedownloadlist = 2203,

        /// <summary>
        /// ConfigId：2204
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  判断指定缓存文件的所有缓存块是否已全部下载完成，参数为要判断的文件名，返回值1为下载完成，0为未完成。
        /// </summary>
        Cachecompleted = 2204,

        /// <summary>
        /// ConfigId：2205
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  把缓存文件转换成媒体文件，参数格式："缓存文件名;媒体文件名"，即使未下载完成的缓存文件也能转换成媒体文件，不过未完成的数据块被填充为0。
        /// </summary>
        Cacheconvert = 2205,

        /// <summary>
        /// ConfigId：2206
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置打开缓存文件时是否忽略文件头中的 URL 比较。
        /// </summary>
        CacheignorecompareURL = 2206,

        /// <summary>
        /// ConfigId：2207
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置是否在播放媒体文件时贪婪下载所有的数据到缓存文件。
        /// </summary>
        Cachegreed = 2207,

        /// <summary>
        /// ConfigId：2301
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  视频 2D 精灵功能是高性能叠加多个文本对象和 GIF 动画图片的接口，这配置查询该功能是否可用，目前只有 Renderless(WinXP)/EVRCP(Win7) 渲染器支持。
        /// </summary>
        Spriteusable = 2301,

        /// <summary>
        /// ConfigId：2302
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  查询已经存在的 2D 精灵对象，格式为精灵的 ID 列表，例如："1;3;5;7;8;"，代表现在有 5 个精灵对象，ID 分别为 1、3、5、7、8。
        /// </summary>
        Spritelist = 2302,

        /// <summary>
        /// ConfigId：2303
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  创建一个 2D 精灵，文本精灵格式为："text:文本;字体名;字宽;字高;粗体;斜体;下划线;颜色;描边宽度;行宽;行距"，其中描边宽度可以为0(即不描边)，超过行宽的部分会显示在下一行，默认行宽为 2000，默认行距为 5，例如："text:abc;宋体;20;50;0;0;0;16777215;2;300;5" 表示创建一个文本为 abc ，字体是宋体，颜色为白色，描边宽度为2像素，行宽限制为300像素，行距为5像素的 2D 精灵。图像精灵格式1为："image:源文件路径;透明色"，例如："image:h:\test.gif;16777215" 表示使用 h:\test.gif 源来创建一个动画，透明色为白色。图像精灵格式2为："image:handle:位图句柄;透明色"，例如："image:handle:2030377632;16777215" 表示使用位图句柄值(十进制）2030377632 为源来创建一个动画，透明色为白色。
        /// </summary>
        Spriteadd = 2303,

        /// <summary>
        /// ConfigId：2304
        /// 值类型：  int
        /// 读写（R/W）：W
        /// 描述：  删除一个 2D 精灵，参数为精灵的 ID。
        /// </summary>
        Spritedelete = 2304,

        /// <summary>
        /// ConfigId：2305
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置当前的 2D 精灵，参数为精灵 ID，要设置精灵位置和移动一个精灵需要先将其设为当前精灵，刚创建好的精灵会被自动设置为当前精灵。
        /// </summary>
        Spritecurrent = 2305,

        /// <summary>
        /// ConfigId：2306
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前 2D 精灵所占的的矩形区域，返回格式："left;top;right;bottom"
        /// </summary>
        Spritebound = 2306,

        /// <summary>
        /// ConfigId：2307
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  设置当前 2D 精灵的位置，格式： "left;top"，设置位置时，会自动中止当前的移动过程。
        /// </summary>
        Spriteposition = 2307,

        /// <summary>
        /// ConfigId：2308
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  把当前 2D 精灵按照指定的速度移动到指定位置，格式："x;y;speed"，设置后，当前精灵会按照速度逐帧均匀移动到目标位置，看起来是一个动画。
        /// </summary>
        Spritemoveto = 2308,

        /// <summary>
        /// ConfigId：2309
        /// 值类型：  void
        /// 读写（R/W）：  W
        /// 描述：  选择视频区域，作为 2D 精灵跟随使用，该设置需要在暂停播放时调用，调用该参数后，鼠标左键在视频窗口上按下拖动会绘制一个选择框，左键释放后，选择框的区域即为所选视频区域。
        /// </summary>
        Spriteselectvideo = 2309,

        /// <summary>
        /// ConfigId：2310
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取由 2309 设置所选择的选择框的位置，坐标为视频窗口坐标，格式为："left;top;right;bottom"
        /// </summary>
        Spriteselectrect = 2310,

        /// <summary>
        /// ConfigId：2311
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置是否在播放时仍显示视频选择框。
        /// </summary>
        Spriteshowselect = 2311,

        /// <summary>
        /// ConfigId：2312
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  附加当前 2D 精灵到所选视频区域上，随着视频一起移动，直到切换镜头，参数为所附加的视频区域，格式为："left;top;right;bottom"。
        /// </summary>
        Spriteattachvideo = 2312,

        /// <summary>
        /// ConfigId：2313
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置为 0 时精灵在窗口上，设置为 1 时，精灵附加到视频上，而不是在当前视口，感觉就像场景中的物体，这时的可叠加范围为视频尺寸。
        /// </summary>
        SpriteattachtoVR = 2313,

        /// <summary>
        /// ConfigId：2401
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取是否激活虚拟现实(VR)播放功能，该设置需在 APlayer.Open 之前调用。
        /// </summary>
        VRenable = 2401,

        /// <summary>
        /// ConfigId：2402
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当前使用的虚拟现实视频(VR)绘制模式，0-无效果，1-矩形全景左右，3-圆形半景外下内上，4-圆形半景内下外上，7-矩形双目全景左右，9-矩形双目立体全景左右, 11-圆形全景左右，15-圆形双目全景左右。
        /// </summary>
        VRmode = 2402,

        /// <summary>
        /// ConfigId：2403
        /// 值类型： str
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当前虚拟现实视频(VR)中的观察者视角和距离，参数之间分号分割，格式："水平视角;垂直视角;距离", 视角单位弧度，距离单位像素，允许浮点数，例如 "1.28;1.02;350.6"
        /// </summary>
        VRposition = 2403,

        /// <summary>
        /// ConfigId：2404
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当前使用的虚拟现实设备（头盔/眼镜）, 0-无设备，1-Oculus DK2
        /// </summary>
        VRdevice = 2404,

        /// <summary>
        /// ConfigId：2405
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当使用虚拟现实设备时，视频画面刷新间隔，单位毫秒，默认为5毫秒。
        /// </summary>
        VRdelay = 2405,

        /// <summary>
        /// ConfigId：2406
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置或获取圆形左右全景渲染时的设备相关参数："x1;x2;y;w;h;a1;a2"。
        /// </summary>
        VRcircularparameter = 2406,

        /// <summary>
        /// ConfigId：2407
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当使用虚拟现实设备时，监视窗口的显示方式，0-左右双目视口，1-单目全景，2-无监视（画面不更新）
        /// </summary>
        VRmonitorparameter = 2407,

        /// <summary>
        /// ConfigId：2408
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：设置或获取当前全景视频顶部和底部的覆盖圆，格式："top;bottom;color"，例如："0;200;16777215"，代表在全景视频底部填充一个半径为 200 像素的白色圆。
        /// </summary>
        VRfillband = 2408,

        /// <summary>
        /// ConfigId：2409
        /// 值类型： str
        /// 读写（R/W）：R
        /// 描述：  获取当前屏幕中心点或 VR 头盔中心焦点在视频坐标系的位置，格式："x;y"，例如："1302;500"，说明用户屏幕或头盔正聚焦在原始全景视频 x=1302,y=500 处的图像上。
        /// </summary>
        VRfocusposition = 2409,

        /// <summary>
        /// ConfigId：2410
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：设置或获取全景视频的渲染质量，范围 10-100，默认值为 50。
        /// </summary>
        VRquality = 2410,

        /// <summary>
        /// ConfigId：2501
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：是否激活AI功能，需要在打开媒体文件之前设置，AI功能需要依赖AI库文件，可以到官方论坛下载。
        /// </summary>
        AIenable = 2501,

        /// <summary>
        /// ConfigId：2502
        /// 值类型： int
        /// 读写（R/W）：R
        /// 描述：  获取当前已加载了多少个人脸标签，标签可以是人名什么的，也可以是别的文字；标签的用途：如果视频中出现了该标签的人脸，APlayer就会在返回的人脸信息中给出来。
        /// </summary>
        AIfacegetlabelcount = 2502,

        /// <summary>
        /// ConfigId：2503
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前已加载的人脸标签列表，格式："李某某;刘某某;张某某"。
        /// </summary>
        AIfacegetlabels = 2503,

        /// <summary>
        /// ConfigId：2504
        /// 值类型： void
        /// 读写（R/W）：  W
        /// 描述：  清除所有标签。
        /// </summary>
        AIfaceclearlabels = 2504,

        /// <summary>
        /// ConfigId：2505
        /// 值类型：  str
        /// 读写（R/W）：W
        /// 描述：  添加人脸照片文件标签，标签需要在 EVENTCODE_AILOADCOMPLETED 后添加才会成功，格式 "李某某;C:\test.jpg"。
        /// </summary>
        AIfaceaddlabelfile = 2505,

        /// <summary>
        /// ConfigId：2506
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  添加一个标签目录，文件名即为标签名（不包含后缀），格式："C:\test_dir"。
        /// </summary>
        AIfaceaddlabeldirectory = 2506,

        /// <summary>
        /// ConfigId：2507
        /// 值类型： str
        /// 读写（R/W）：W
        /// 描述：  添加当前播放视频的当前画面中的人脸作为标签（在程序退出后会自动保存），格式："C:\李某某.jpg" 或者 "C:\李某某.bmp"，文件名（不包含后缀）即为标签。
        /// </summary>
        AIfaceaddlabelsnapshot = 2507,

        /// <summary>
        /// ConfigId：2508
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  因为添加目录标签是一个耗时的过程，该配置获取当前添加目录标签的进度，返回格式："current;total"
        /// </summary>
        AIfacelabelprogress = 2508,

        /// <summary>
        /// ConfigId：2509
        /// 值类型：void
        /// 读写（R/W）：  W
        /// 描述：  立即保存当前所有标签到加载标签的目录的 Faces.txt 文本文件中，从而下次不需要重新扫描标签图像文件快速加载
        /// </summary>
        AIfacesavetextlabels = 2509,

        /// <summary>
        /// ConfigId：2510
        /// 值类型：str
        /// 读写（R/W）：W
        /// 描述：  重新装载 Faces.txt 文件，这对于多个应用程序共享 Faces.txt 很有效，对于这种情况下，某个应用产生标签，其他应用使用这些标签，这些应用可是是在不同机器上，通过共享目录访问 Faces.txt。
        /// </summary>
        AIfaceloadtextlabels = 2510,

        /// <summary>
        /// ConfigId：2511
        /// 值类型： str
        /// 读写（R/W）：W
        /// 描述：  通过标签添加一个人脸饰物，当APlayer识别到视频中这个标签的人出现的时候，自动绘制饰物，格式："TheMode;FileName;DstX;DstY;DstZ;SrcX;SrcY;SrcZ;Extra;Label(VideoX;VideoY)"，格式解释如下：TheMode为饰物模式，目前支持1，即3D模型，FileName是x模型文件，Dst开头的为相对人脸鼻尖的目标偏移,Src开头的为模型附着点的偏移，Label和VideoX;VideoY 设置其中一个，如果设置Label则叠加到识别出来的标签头上，否则叠加到视频当前画面的位置（VideoX，VideoY）所在位置的人脸上。
        /// </summary>
        AIfaceaddornament = 2511,

        /// <summary>
        /// ConfigId：2512
        /// 值类型：  str
        /// 读写（R/W）：R
        /// 描述：  获取当前视频中人脸信息，返回格式："lablel1,error,left,top,right,bottom,angleX,angleY,angleZ;lablel2,error,left,top,right,bottom,angleX,angleY,angleZ;..."，其中 error 为匹配误差，angle开头的为角度
        /// </summary>
        AIfacegetinfo = 2512,

        /// <summary>
        /// ConfigId：2513
        /// 值类型：str
        /// 读写（R/W）：R
        /// 描述：  获取当前视频中人脸信息的关键点，每行一个人脸信息，每个人脸68个关键点，这些关键点数值上都基于视频像素坐标，格式 "lablel1;x1,y1;x2,y2;x3,y3;...x68,y68\r\nlablel2;x1,y1;x2,y2;x3,y3;...x68,y68"
        /// </summary>
        AIfacegetpoints = 2513,

        /// <summary>
        /// ConfigId：2514
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：动态开启或者禁止AI检测功能，1开启，0禁止，默认为1。
        /// </summary>
        AIdetect = 2514,

        /// <summary>
        /// ConfigId：2515
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置是否显示人脸调试信息，方便调试程序，1显示，0不显示，默认为0。
        /// </summary>
        AIdebug = 2515,

        /// <summary>
        /// ConfigId：2516
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置人脸识别时的允许误差，某个人脸和标签的误差超过该值将不识别为标签，范围 0-100, 默认 36，该值越小越准确，但越不容易识别。
        /// </summary>
        AIallowerror = 2516,

        /// <summary>
        /// ConfigId：2517
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置人脸识别图像大小，范围 200-1000, 默认 800，该数值越大越能识别小尺寸人脸，但性能越慢。
        /// </summary>
        AIimagesize = 2517,

        /// <summary>
        /// ConfigId：2518
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或者设置人脸识别操作频率，该数值越小，识别越及时，但性能越慢，范围 10 - 500, 默认 30。
        /// </summary>
        AImatchinterval = 2518,

        /// <summary>
        /// ConfigId：2601
        /// 值类型：  int
        /// 读写（R/W）：R
        /// 描述：  获取录制当前媒体功能现在是否可用。
        /// </summary>
        Recordusable = 2601,

        /// <summary>
        /// ConfigId：2602
        /// 值类型：int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的视频宽度，设置了录制宽度后，录制高度依照横纵比自动计算。
        /// </summary>
        Recordvideowidth = 2602,

        /// <summary>
        /// ConfigId：2603
        /// 值类型：  int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的视频高度，设置了录制高度后，录制宽度依照横纵比自动计算。
        /// </summary>
        Recordvideoheight = 2603,

        /// <summary>
        /// ConfigId：2604
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的视频比特率，单位 Kbps。
        /// </summary>
        Recordvideobitrate = 2604,

        /// <summary>
        /// ConfigId：2605
        /// 值类型： int
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的音频比特率，单位 Kbps。
        /// </summary>
        Recordaudiobitrate = 2605,

        /// <summary>
        /// ConfigId：2606
        /// 值类型：  str
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的媒体文件的封装格式，格式必须是 GetConfig(802) 返回的格式中的一个。
        /// </summary>
        Recordformat = 2606,

        /// <summary>
        /// ConfigId：2607
        /// 值类型：str
        /// 读写（R/W）：R/W
        /// 描述：获取或设置录制的媒体文件的存储路径。
        /// </summary>
        Recordfilename = 2607,

        /// <summary>
        /// ConfigId：2608
        /// 值类型：void
        /// 读写（R/W）：  W
        /// 描述：  在当前播放的位置开始录制，调用后开始写入录制文件。
        /// </summary>
        Recordstart = 2608,

        /// <summary>
        /// ConfigId：2609
        /// 值类型： void
        /// 读写（R/W）：  W
        /// 描述：  在当前播放的位置停止录制，调用后录制文件写入完毕，即可以取用了。
        /// </summary>
        Recordstop = 2609
    }
}
