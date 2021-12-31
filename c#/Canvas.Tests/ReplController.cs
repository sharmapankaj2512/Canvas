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
        switch (_commandSource.Current)
        {
            case CreateCanvas(var width, var height):
                Canvas.CreateCanvas(width, height)
                    .ConsumeLeft(error => _display.RenderError(error.Message))
                    .ConsumeRight(canvas => _display.Render(canvas.Points()));
                break;
        }
    }
}