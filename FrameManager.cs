using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FS_Emulator
{
    public class FrameManager
    {
        private System.Timers.Timer timer;
        private Stopwatch frame_timer = new Stopwatch();
        private DateTime previous_frame_time;
        private double delta_time = 0;
        public event Action<double> FrameUpdated;

        static long ticks_this_frame = 0;

        public FrameManager(double target_fps)
        {
            double ms_per_frame = 1000 / target_fps;
            timer = new System.Timers.Timer(ms_per_frame);
            frame_timer.Start();
            timer.Elapsed += OnFrame;
            timer.AutoReset = true;
            timer.Enabled = false;
            previous_frame_time = DateTime.Now;

        }

        public void Start()
        {
            timer.Enabled = true;
        }
        private void OnFrame(Object source, ElapsedEventArgs e)
        {
            DateTime current_frame_time = DateTime.Now;
            delta_time = (current_frame_time - previous_frame_time).TotalSeconds;
            previous_frame_time = current_frame_time;
            FrameUpdated?.Invoke(delta_time);
            
        }
    }
}
