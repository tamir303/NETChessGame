import * as React from 'react';

interface SquareProps {
    x: number;
    y: number;
    isWhite: boolean;
    children?: React.ReactNode;
    onDrop: (e: React.DragEvent<HTMLDivElement>, x: number, y: number) => void;
}

const Square: React.FC<SquareProps> = ({ x, y, isWhite, children, onDrop }) => (
    <div
        className={`square ${isWhite ? "white-square" : "black-square"}`}
        data-x={x}
        data-y={y}
        onDragOver={(e) => e.preventDefault()}
        onDrop={(e) => onDrop(e, x, y)}
    >
        {children}
    </div>
);

export default Square;
