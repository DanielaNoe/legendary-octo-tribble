import { AddressViewModel } from "../../models/AddressViewModel";

interface AddressProps {
    address?: AddressViewModel
}

function Address({ address }: AddressProps) {
    if (!address) return (<></>);

    return (
        <>
            <div>{address.name}</div>
            <div>{address.street} {address.houseNumber}</div>
            <div>{address.postalCode} {address.country}</div>
        </>
    );
};

export default Address;
