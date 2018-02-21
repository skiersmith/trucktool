

function function1() {
    var returns = require('./returns.json');
    var returnObj = {
        SELLABLE: {
            orders: {},
            quantity: 0,
            price: 0
        },
        CUSTOMER_DAMAGED: {
            orders: {},
            quantity: 0,
            price: 0
        },
        DEFECTIVE: {
            orders: {},
            quantity: 0,
            price: 0
        },
        DAMAGED: {
            orders: {},
            quantity: 0,
            price: 0
        },
        CARRIER_DAMAGED: {
            orders: {},
            quantity: 0,
            price: 0
        }
    }
    for (let p = 0; p < returns.length; p++) {
        var element = returns[p];
        if (element['detailed-disposition'] == "SELLABLE") {
            returnObj.SELLABLE.quantity++
            returnObj.SELLABLE.orders[element.orderid] = element.quantity;
            var price = findPrice(element.orderid)
            var price2 = price * element.quantity
            returnObj.SELLABLE.price += price2
        }
        else if (element['detailed-disposition'] == "CUSTOMER_DAMAGED") {
            returnObj.CUSTOMER_DAMAGED.quantity++
            returnObj.CUSTOMER_DAMAGED.orders[element.orderid] = element.quantity;
            var price = findPrice(element.orderid)
            var price2 = price * element.quantity
            returnObj.CUSTOMER_DAMAGED.price += price2
        }
        else if (element['detailed-disposition'] == "DEFECTIVE") {
            returnObj.DEFECTIVE.quantity++
            returnObj.DEFECTIVE.orders[element.orderid] = element.quantity;
            var price = findPrice(element.orderid)
            var price2 = price * element.quantity
            returnObj.DEFECTIVE.price += price2
        }
        else if (element['detailed-disposition'] == "DAMAGED") {
            returnObj.DAMAGED.quantity++
            returnObj.DAMAGED.orders[element.orderid] = element.quantity;
            var price = findPrice(element.orderid)
            var price2 = price * element.quantity
            returnObj.DAMAGED.price += price2
        }
        else if (element['detailed-disposition'] == "CARRIER_DAMAGED") {
            returnObj.CARRIER_DAMAGED.quantity++
            returnObj.CARRIER_DAMAGED.orders[element.orderid] = element.quantity;
            var price = findPrice(element.orderid)
            var price2 = price * element.quantity
            returnObj.CARRIER_DAMAGED.price += price2
        }
    }
    return returnObj
}
console.log(function1())
function findPrice(oid) {
    var orders = require('./orders.json');
    for (let p = 0; p < orders.length; p++) {
        var element = orders[p];
        if (element['amazon-order-id'] == oid) {
            // console.log(element['item-price'])
            
            
            var number = Number(element['item-price'].replace(/[^0-9\.-]+/g, "") + 00);
            // console.log(number)
            return number;
        }
    }
}