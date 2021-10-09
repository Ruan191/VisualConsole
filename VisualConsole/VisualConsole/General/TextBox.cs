using System;
using System.Collections.Generic;
using System.Text;

namespace VisualConsole.General
{
    class TextBox : MapObject, IRenderable
    {
        public StringBuilder text = new StringBuilder();
        public int maxCharAllowed = 15;
        public bool selected;
        public static List<TextBox> textReads = new List<TextBox>();
        public static TextBox currentSelectedTextRead;

        /// <summary>
        /// Use this to enable users to type. Note needs to be rendered first.
        /// </summary>
        /// <param name="position">Position of the textBox</param>
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

        /// <summary>
        /// Selects a textbox to be used
        /// </summary>
        /// <param name="textRead">The textbox to be used</param>
        public static void Select(TextBox textRead)
        {
            currentSelectedTextRead.selected = false;
            Controls.OnKeyPressed -= currentSelectedTextRead._OnKeyPressed;
            textRead.selected = true;
            currentSelectedTextRead = textRead;
            Controls.OnKeyPressed += textRead._OnKeyPressed;
        }

        /// <summary>
        /// Selects a textbox to be used
        /// </summary>
        /// <param name="index">The textbox to be used based on index</param>
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

        /// <summary>
        /// Renders the textbox to the console
        /// </summary>
        /// <param name="action">no effect</param>
        /// <param name="chosenPos">no effect</param>
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
