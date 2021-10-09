using System;

namespace VisualConsole.General
{
    public interface IRenderable
    {
        public void Render(Action action = null, Vector2 chosenPos = null);
    }
}
