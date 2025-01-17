import * as React from 'react';
import { useState, useEffect } from 'react';
import Board from '../components/Board';
import MoveHistory from '../components/MoveHistory';
import { ApiClient, ResponseProps } from '../services/ApiClient';

const apiClient = new ApiClient('http://localhost:5256/api/v1/chess');

const ChessPage: React.FC = () => {
    const [pieces, setPieces] = useState([]);
    const [history, setHistory] = useState([]);
    const [isLoading, setLoading] = useState(true)
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchPieces = async () => {
            setLoading(true);
            await apiClient.get('')
                .then((response) => {
                    if (response.success) {
                        setPieces(response.data.pieces);
                    } else {
                        setError(response.message || 'Failed to load pieces');
                    }
                })
                .catch((error) => {
                    console.error('Error fetching pieces:', error);
                    setError('Failed to load pieces');
                })
            setLoading(false);
        };

        fetchPieces();
    }, [])

    const handleDrop = async (id: string, toX: number, toY: number) => {
        try {
            await apiClient.post(`/move`, { Id: id, Position: { X: toX, Y: toY } })
                .then(response => {
                    if (response.success) {
                        // Update the piece's position
                        setPieces((prev) =>
                            prev.map((p) =>
                                p.id === id ? { ...p, x: response.data.to.x, y: response.data.to.y } : p
                            )
                        );

                        // Add the move to the history
                        setHistory((prev) => [
                            ...prev,
                            {
                                piece: id,
                                from: `(${response.data.from.x}, ${response.data.from.y})`,
                                to: `(${response.data.to.x}, ${response.data.to.y})`,
                            },
                        ]);
                    }
                })
                .catch((error) => console.error("Error moving piece:", error));
        } catch (error) {
            console.error("Error moving piece:", error);
        }
    };

    return (
        <div>
            <Board pieces={pieces} onDrop={handleDrop} />
            <MoveHistory history={history} />
        </div>
    );
};

export default ChessPage;
