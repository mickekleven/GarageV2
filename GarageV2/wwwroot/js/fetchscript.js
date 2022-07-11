
// Script handles fetch and construction of items for updating DOM. 


const getOptions = {
    'method': 'GET',
    'Content-type': 'application/json'
};

const postOptions = {
    'method': 'POST',
    'Content-type': 'application/json'
};


const formObj = document.querySelector('#formid');


const fetchData = function (vehicleObj) {

    let url = 'Vehicles/SetVehicleType?SetVehicleType';

    try {
        const response = fetch(url, postOptions)
            .then(res => {
                if (!res.ok) {
                    console.log('Not sucessful');
                } else {
                    console.log('SUCCESS');
                    return res.json();

                }
            })
            .then((data) => {
                console.log('data ' + data);

                items.innerHTML = ""; 

                addItemToDom(data);

                element.value = "";


            })

            .catch((error) => {
                console.log(error);
            });

        console.log('response ' + response);
        return response;

    } catch (e) {
        console.error('Exception is thrown ' + e.message);
    }

}

const addItemToDom = function (_item) {

    items.insertAdjacentHTML('beforeend', `<tr>
            <th>${_item.regNr}</th>
            <th>${_item.color}</th>
            <th>${_item.wheels}</th>
            <th>${_item.brand}</th>
            <th>${_item.model}</th>
            <th>${_item.vehicleType}</th>
            <th>${_item.arrivalDate}</th>
        </tr>`);
}

class Item {
    constructor(regNr, color, wheels, brand, model, vehicleType, arrivalDate) {
        this.regNr = regNr;
        this.color = color;
        this.wheels = wheels;
        this.brand = brand;
        this.model = model;
        this.vehicleType = vehicleType;
        this.arrivalDate = arrivalDate;

    }
}

