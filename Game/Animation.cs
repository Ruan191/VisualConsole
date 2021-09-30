using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public class Animation : MapObject
    {
        public readonly List<Sprite> frames = new List<Sprite>();
        public bool loopEnabled = true;
        public bool stopped;
        public int pausesBetweenFrames = 2;

        public Animation(string folderName, Vector2 position, Vector2 size = null, ConsoleColor color = ConsoleColor.Black){
            string[] fileNames = FileManager.GetAllFileNames("\\sprites\\animations\\" + folderName);
            this.color = color;
            this.position = position;

            if (size == null)
                this.size = size;

            foreach (string fileName in fileNames)
            {
                frames.Add(new Sprite($"animations\\{folderName}\\" + fileName.Split('\\').Last(), position, color:color));
            }
        }

        public void Play(){
            stopped = false;
            int biggestWidth = 1;
            int biggestHeight = 1;

            Task.Run(() => {
                while (loopEnabled && !stopped){
                    foreach (Sprite frame in frames.ToArray()){
                        Renderer.RequestRender((frame.id, () => {
                            if (frame.maxWidth > biggestWidth){
                                biggestWidth = frame.maxWidth;
                            }

                            if (frame.maxHeight > biggestHeight){
                                biggestHeight = frame.maxHeight;
                            }

                            frame.size.x = biggestWidth;
                            frame.size.y = biggestHeight;

                            frame.Render(position);
                            //Renderer.Render(frame, position);
                        }));

                        Thread.Sleep(pausesBetweenFrames);
                    }
                }
            });
        }

        public void Stop(){
            stopped = true;
        }
    }
}