import * as React from 'react';

interface MoveHistoryProps {
    history: { piece: string; from: string; to: string }[];
}

const MoveHistory: React.FC<MoveHistoryProps> = ({ history }) => (
    <div className="move-history">
        <h5>Game History</h5>
        <ul>
            {history.map((move, index) => (
                <li key={index}>
                    {move.piece} moved from {move.from} to {move.to}
                </li>
            ))}
        </ul>
    </div>
);

export default MoveHistory;
