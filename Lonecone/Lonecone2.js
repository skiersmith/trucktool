// The important answer we need is the total quantity and item price of returns for each of the 5 return types (these are listed on the “Losses” tab). Amazon’s data is quite segmented, and these are the types of problems we’re trying to build long-term solutions to.


var csv = require('csv-parser')
var fs = require('fs')


function function3() {
    var returnObj = {
        SELLABLE: {
            orders: {},
            quantity: 0,
        },
        CUSTOMER_DAMAGED: {
            orders: {},
            quantity: 0,
        },
        DEFECTIVE: {
            orders: {},
            quantity: 0,
        },
        DAMAGED: {
            orders: {},
            quantity: 0,
        },
        CARRIER_DAMAGED: {
            orders: {},
            quantity: 0,
        }
    }
    // fs.createReadStream('Book23.csv')
    //     .pipe(csv())
    //     .on('data', function (data) {
    //         console.log()
    //     })


    fs.createReadStream('Book23.csv')
        .pipe(csv())
        .on('data', function (data) {
            console.log(data)
            if (data['detailed-disposition'] == "SELLABLE") {
                //   returnObj.SELLABLE.orders += data
                // console.log(returnObj.SELLABLE.orders)
                // console.log(data.quantity)
                // data['order-id'] += returnObj.SELLABLE.orders
                returnObj.SELLABLE.quantity++
                // console.log(returnObj.SELLABLE.quantity)
            }
            else if (data['detailed-disposition'] == "CUSTOMER_DAMAGED") {
                //   returnObj.CUSTOMER_DAMAGED.orders += data
                // console.log("CUSTOMER_DAMAGED")
                returnObj.CUSTOMER_DAMAGED.quantity++
            }
            else if (data['detailed-disposition'] == "DEFECTIVE") {
                //   returnObj.DEFECTIVE.orders += data
                // console.log("DEFECTIVE")
                returnObj.DEFECTIVE.quantity++
            }
            else if (data['detailed-disposition'] == "DAMAGED") {
                //   returnObj.DAMAGED.orders += data
                // console.log("DAMAGED")
                returnObj.DAMAGED.quantity++


            }
            else if (data['detailed-disposition'] == "CARRIER_DAMAGED") {
                //   returnObj.CARRIER_DAMAGED.orders += data
                // console.log("CARRIER_DAMAGED")
                returnObj.CARRIER_DAMAGED.quantity++
            }
        })
        .on('end', function () {
           console.log(returnObj)
        })

    //   returnObj = {
    //         SELLABLE: {
    //             orders: {},
    //             quantity: 0,
    //         },
    //         CUSTOMER_DAMAGED: {
    //             orders: {},
    //             quantity: 0,
    //         },
    //         DEFECTIVE: {
    //             orders: {},
    //             quantity: 0,
    //         },
    //         DAMAGED: {
    //             orders: {},
    //             quantity: 0,
    //         },
    //         CARRIER_DAMAGED: {
    //             orders: {},
    //             quantity: 0,
    //         }

    //     }
    return returnObj
}
console.log(function3())







// console.log(data)
            // console.log(data)
            if (data['detailed-disposition'] == "SELLABLE") {
                //   returnObj.SELLABLE.orders += data
                // console.log(returnObj.SELLABLE.orders)
                // console.log(data.quantity)
                // data['order-id'] += returnObj.SELLABLE.orders
                returnObj.SELLABLE.quantity++
                // console.log(returnObj.SELLABLE.quantity)
            }
            else if (data['detailed-disposition'] == "CUSTOMER_DAMAGED") {
                //   returnObj.CUSTOMER_DAMAGED.orders += data
                // console.log("CUSTOMER_DAMAGED")
                returnObj.CUSTOMER_DAMAGED.quantity++
            }
            else if (data['detailed-disposition'] == "DEFECTIVE") {
                //   returnObj.DEFECTIVE.orders += data
                // console.log("DEFECTIVE")
                returnObj.DEFECTIVE.quantity++
            }
            else if (data['detailed-disposition'] == "DAMAGED") {
                //   returnObj.DAMAGED.orders += data
                // console.log("DAMAGED")
                returnObj.DAMAGED.quantity++


            }
            else if (data['detailed-disposition'] == "CARRIER_DAMAGED") {
                //   returnObj.CARRIER_DAMAGED.orders += data
                // console.log("CARRIER_DAMAGED")
                returnObj.CARRIER_DAMAGED.quantity++
            }
