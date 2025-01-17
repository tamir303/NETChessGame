import * as React from 'react';
import Square from './Square';
import Piece from './Piece';

interface BoardProps {
    pieces: { id: string; type: string; color: string, x: number; y: number }[];
    onDrop: (id: string, toX: number, toY: number) => void;
}

const Board: React.FC<BoardProps> = ({ pieces, onDrop }) => {
    const squares = Array.from({ length: 8 }, (_, row) =>
        Array.from({ length: 8 }, (_, col) => {
            const isWhite = (row + col) % 2 === 0;
            const piece = pieces.find((p) => p.x === col && p.y === 7 - row);

            return (
                <Square
                    key={`${row}-${col}`}
                    x={col}
                    y={7 - row}
                    isWhite={isWhite}
                    onDrop={(e, x, y) => {
                        const id = e.dataTransfer.getData("id");
                        onDrop(id, x, y);
                    }}
                >
                    {piece && (
                        <Piece
                            id={piece.id}
                            type={piece.type}
                            color={piece.color}
                            x={col}
                            y={7 - row}
                            draggable={true}
                            onDragStart={(e, id) => e.dataTransfer.setData("id", id)}
                        />
                    )}
                </Square>
            );
        })
    );

    return <div className="board">{squares}</div>;
};

export default Board;
