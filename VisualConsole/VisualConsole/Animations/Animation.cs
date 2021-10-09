using System;
using VisualConsole.General;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VisualConsole.Animations
{
    public class Animation : MapObject
    {
        public readonly List<Sprite> frames = new List<Sprite>();
        public bool loopEnabled = true;
        public bool stopped;
        public int pausesBetweenFrames = 2;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName">Name of the folder containing your animation. Note frames in the animations needs to be numberd in some way starting from 1</param>
        /// <param name="position">position where the animation should be on the console</param>
        /// <param name="dupeFileNames">Name of the duplicate file containing a number next to it</param>
        /// <param name="color">The color of the animation</param>
        public Animation(string folderName, Vector2 position, string dupeFileNames = "", ConsoleColor color = ConsoleColor.White)
        {
            int ln = FileManager.GetAllFileNames($"\\sprites\\animations\\" + folderName).Length;
            List<string> fileNames = new List<string>();

            for (int i = 1; i < ln; i++)
            {
                frames.Add(new Sprite($"\\animations\\{folderName}\\{dupeFileNames}{i}.txt", position, color: color));
            }

            this.color = color;
            this.position = position;
        }

        //TO DO
        public Animation(List<Sprite> frames, Vector2 position, ConsoleColor color = ConsoleColor.White)
        {
            this.color = color;
            this.position = position;
            this.frames = frames;

            foreach (Sprite frame in frames)
            {
                frame.color = this.color;
            }
        }

        /// <summary>
        /// Spawns the animation in the console and runs it in a loop unless disabled
        /// ,the size of the animation will be based on the size of the biggest sprite
        /// </summary>
        /// <param name="onFrameChange">If not null runs a Action every frame</param>
        public void Play(Action onFrameChange = null)
        {
            stopped = false;
            int biggestWidth = 1;
            int biggestHeight = 1;

            Task.Run(() => {
                while (loopEnabled && !stopped)
                {
                    foreach (Sprite frame in this.frames.ToArray())
                    {
                        frame.position = this.position;
                        frame.color = this.color;

                        if (frame.maxWidth > biggestWidth)
                        {
                            biggestWidth = frame.maxWidth;
                        }

                        if (frame.maxHeight > biggestHeight)
                        {
                            biggestHeight = frame.maxHeight;
                        }

                        frame.size.x = biggestWidth;
                        frame.size.y = biggestHeight;

                        this.size = new Vector2(biggestWidth, biggestHeight);
                        Renderer.RequestRender((frame.id, frame));

                        Task.Delay(pausesBetweenFrames).Wait();

                        onFrameChange();
                    }
                }
            });
        }
        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop()
        {
            stopped = true;
        }
    }
}
