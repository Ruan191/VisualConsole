using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VisualConsole
{
    public class Animation : MapObject
    {
        public readonly List<Sprite> frames = new List<Sprite>();
        public bool loopEnabled = true;
        public bool stopped;
        public int pausesBetweenFrames = 2;

        public Animation(string folderName, Vector2 position, ConsoleColor color = ConsoleColor.White){
            string[] fileNames = FileManager.GetAllFileNames("\\sprites\\animations\\" + folderName);
            this.color = color;
            this.position = position;

            foreach (string fileName in fileNames)
            {
                frames.Add(new Sprite($"animations\\{folderName}\\" + fileName.Split('\\').Last(), position, color:color));
            }
        }

        //TO DO
        public Animation(List<Sprite> frames, Vector2 position, ConsoleColor color = ConsoleColor.White){
            this.color = color;
            this.position = position;
            this.frames = frames;

            foreach (Sprite frame in frames){
                frame.color = this.color;
            }
        }


        /// <summary>
        /// Spawns the animation in the console and runs it in a loop unless disabled
        /// ,the size of the animation will be based on the size of the biggest sprite
        /// </summary>
        public void Play(){
            stopped = false;
            int biggestWidth = 1;
            int biggestHeight = 1;

            Task.Run(() => {
                while (loopEnabled && !stopped){
                    foreach (Sprite frame in this.frames.ToArray()){
                        Renderer.RequestRender((frame.id, () => {
                            if (frame.maxWidth > biggestWidth){
                                biggestWidth = frame.maxWidth;
                            }

                            if (frame.maxHeight > biggestHeight){
                                biggestHeight = frame.maxHeight;
                            }

                            frame.size.x = biggestWidth;
                            frame.size.y = biggestHeight;

                            Renderer.Render(frame, position);
                        }));

                        Thread.Sleep(pausesBetweenFrames);
                    }
                }
            });
        }
        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop(){
            stopped = true;
        }
    }
}