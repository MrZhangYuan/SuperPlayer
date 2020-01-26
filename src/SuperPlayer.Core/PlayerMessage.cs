namespace SuperPlayer.Core
{
        public enum PLAY_STATE
        {
                PS_READY = 0,  // 准备就绪
                PS_OPENING = 1,  // 正在打开
                PS_PAUSING = 2,  // 正在暂停
                PS_PAUSED = 3,  // 暂停中
                PS_PLAYING = 4,  // 正在开始播放
                PS_PLAY = 5,  // 播放中
                PS_CLOSING = 6,  // 正在开始关闭
        }

        public enum PlayerMessage : int
        {
                /// <summary>
                /// 打开指定的文件
                /// </summary>
                OpenFileName,
                Open,
                OpenURL,
                /// <summary>
                /// 打开摄像头
                /// this.player.Open("camera://0");
                /// </summary>
                OpenCamera,
                Play,
                Pause,
                Stop,

                /// <summary>
                /// 当前的播放状态
                /// </summary>
                State,
                /// <summary>
                /// 播放文件的时常
                /// </summary>
                Duration,
                /// <summary>
                /// 当前进度
                /// </summary>
                Position,
                /// <summary>
                /// 音量 1-100  ，扩大到1000
                /// </summary>
                Volume,
                VideoSize,
                /// <summary>
                /// 是否处于设置播放进度(Seek)过程中
                /// </summary>
                IsSeeking,
                /// <summary>
                /// 当前播放的媒体的信息
                /// </summary>
                PlayerInfo,
                Version
        }
}
