import { PositionViewModel } from "../../models/PositionViewModel";
import { formatEUR } from "../../utils/InvoiceHelper";

interface PositionsTableProps {
    positions?: PositionViewModel[]
}

function PositionsTable({ positions }: PositionsTableProps) {
    if (!positions) return (
        <table className="table">
                <thead>
                    <tr>
                    <th scope="col">Amount</th>
                    <th scope="col">Article</th>
                    <th scope="col" className="text-end">Price (EUR)</th>
                    <th scope="col" className="text-end">Total Price (EUR)</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
    );

    return (
        <>            
            <table className="table">
                <thead>
                    <tr>
                    <th scope="col">Amount</th>
                    <th scope="col">Article</th>
                    <th scope="col" className="text-end">Price (EUR)</th>
                    <th scope="col" className="text-end">Total Price (EUR)</th>
                    </tr>
                </thead>
                <tbody>
                    {positions.map((position) => (
                        <tr key={position.id}>
                            <td>{position.amount}</td>
                            <td>{position.article?.name}</td>
                            <td className="text-end">{formatEUR(position.price)}</td>
                            <td className="text-end">{formatEUR(position.totalPrice)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default PositionsTable;
