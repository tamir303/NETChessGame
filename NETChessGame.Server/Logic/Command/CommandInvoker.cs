namespace NETChessGame.Server.Logic.Command;

public class CommandInvoker
{
    private readonly Stack<ICommand> _commandStack = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        try
        {
            command.Execute();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            _commandStack.Push(command);
        }
    }

    public void Undo()
    {
        if (_commandStack.Count == 0) return;
        var command = _commandStack.Pop();
        command.Undo();
    }
}