namespace NETChessGame.Server.Logic.Command;

public interface ICommand
{
    void Execute();
    void Undo();
}