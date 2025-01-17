import * as React from 'react';

interface PieceProps {
    id: string;
    type: string;
    color: string;
    x: number;
    y: number;
    draggable: boolean;
    onDragStart: (e: React.DragEvent<HTMLImageElement>, id: string) => void;
}

const Piece: React.FC<PieceProps> = ({ id, type, color, x, y, draggable, onDragStart }) => (
    <img
        className="piece"
        src={`/public/${ type }-${ color }.svg`}
        alt={ id }
        aria-label={ type }
        draggable={ draggable }
        data-x={ x }
        data-y={ y }
        onDragStart={(e) => onDragStart(e, id)}
    />
);

export default Piece;