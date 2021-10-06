using System;
using System.Collections.Generic;
using System.Text;

namespace VisualConsole
{
    class TextBox : MapObject, IRenderable
    {
        public StringBuilder text = new StringBuilder();
        public int maxCharAllowed = 15;
        public bool selected;
        public static List<TextBox> textReads = new List<TextBox>();
        public static TextBox currentSelectedTextRead;

        public TextBox(Vector2 position)
        {
            this.position = position;
            color = ConsoleColor.White;
            textReads.Add(this);

            if (textReads.Count == 1)
            {
                currentSelectedTextRead = this;
            }
        }

        public static void Select(TextBox textRead)
        {
            currentSelectedTextRead.selected = false;
            Controls.OnKeyPressed -= currentSelectedTextRead._OnKeyPressed;
            textRead.selected = true;
            currentSelectedTextRead = textRead;
            Controls.OnKeyPressed += textRead._OnKeyPressed;
        }

        public static void SelectByIndex(int index)
        {
            currentSelectedTextRead.selected = false;
            Controls.OnKeyPressed -= currentSelectedTextRead._OnKeyPressed;
            textReads[index].selected = true;
            currentSelectedTextRead = textReads[index];
            Controls.OnKeyPressed += textReads[index]._OnKeyPressed;
        }

        void _OnKeyPressed(object sender, Controls.KeyPressedHandler e)
        {

            if ((int)e.keyPressed == 8)
            {

                if (text.Length > 0)
                {
                    MapObject clear = new MapObject(Map.background, new Vector2(position.x + text.Length - 1, position.y));
                    clear.Render();
                    Renderer.RequestRender((clear.id, clear));

                    text.Remove(text.Length - 1, 1);
                }
            }
            else
            {
                if (text.Length < maxCharAllowed && e.keyPressed != 13)
                    text.Append(e.keyPressed);
            }

            Renderer.RequestRender((this.id, this));
        }

        public new void Render(Action action = null, Vector2 chosenPos = null)
        {
            Map.map[position.x, position.y] = this;
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
