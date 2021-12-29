namespace Canvas.Tests;

public class ReplController
{
    private readonly ICommandSource _commandSource;
    private readonly IDisplay _display;

    public ReplController(ICommandSource commandSource, IDisplay display)
    {
        _commandSource = commandSource;
        _display = display;
    }

    public void Start()
    {
        _commandSource.MoveNext();
        var (width, height) = _commandSource.Current;
        if (width >= 0)
        {
            var canvas = Canvas.CreateCanvas(width, height);
            _display.Render(canvas.Points());
        }
        else
            _display.RenderError("Width should not be negative");
    }
}