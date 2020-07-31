$(document).ready(function () {

    //Initial State.
    loadItems();

    //Click to get item #.
    $('.sq').click(function() {
        selectItem($(this).attr('id'));
    });

    //Button click to get totals.
    $('#add-dollar, #add-quarter, #add-dime, #add-nickel').click(function () {
        TotalAmount($(this).attr('id'));
    });

    //Button click to make purchase.
    $('#makePurchase').click(function() {
        makePurchase(parseFloat($('#total-in').val()).toFixed(2), $('#item').val());
    });

    //Button click to change return.
    $('#changeReturn').click(function() {
        changeReturn();
    });


});

function selectItem(input) {
        //Grabs the value 
        $('#item').val('');
        //Finds the id of the item
        var itemTableId = $("#" + input).find('[id*="item"]').attr('id');
        //takes the id and place it on the first table row.
        var itemTableFirstRowId = "#" + itemTableId + " tr:first";
        //Converts to a text.
        var itemId = $(itemTableFirstRowId).text();
        //assigns itemId value to the element.
        $('#item').val(itemId);
}

function TotalAmount(input) {
       var addButton = input;
       //Sets the value of the property to readonly.
       $('#total-in').prop("readonly", false);
       //Parse the value or set the value.
       var currentTotal = parseFloat($('#total-in').val()) || 0.00;
       var finalTotal = currentTotal;
       switch (addButton) {
           case "add-dollar":
                finalTotal += 1.00;
                break;
           case "add-quarter":
                finalTotal += 0.25;
                break;
           case "add-dime":
                finalTotal += 0.10;
                break;
           case "add-nickel":
                finalTotal += 0.05;
                break;
           default:
                finalTotal += 0.00;
       }
       //assign parsed value with a fixed-point.
       $('#total-in').val(parseFloat(finalTotal).toFixed(2));
       $('#total-in').prop("readonly", true);
}

function loadItems() {
    // we need to clear the previous content so we don't append to it
   clearItemTables();

    var itemTable = [];
    // grab the the tbody element that will hold the rows of contact information
    for (var loopCounter = 1;loopCounter < 100;loopCounter++) {
        itemTable[loopCounter] = $('#item' + loopCounter);
    }
    $.ajax ({
        type: 'GET',
        url: 'https://tsg-vending.herokuapp.com/items',
        success: function (data, status) {
            $.each(data, function (index, item) {
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var row = '<tr align="left"><td>' + id + '</td></tr>';
                    row += '<tr><td>' + name + '</td></tr>';
                    row += '<tr><td>' + '$' + parseFloat(price).toFixed(2) + '</td></tr>';
                    row += '<tr><td>' + 'Quantity Left: ' + quantity + '</td></tr>';

                itemTable[index + 1].append(row);
                row = '';
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
            $('#bodyContent, #endingRule').hide();
        }
    });
}


function makePurchase(money, item) {

    $.ajax ({
        type: 'POST',
        url: 'https://tsg-vending.herokuapp.com/money/' + money + '/item/' + item,
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        success: function(data, status) {
              $('#messages').val('Thank You!!!');
              var balance = '';
              if(data.quarters > 0) {
                    balance += data.quarters + ' Quarter(s) ';
              }
              if(data.dimes > 0) {
                    balance += data.dimes + ' Dime(s) ';
              }
              if(data.nickels > 0) {
                    balance += data.nickels + ' Nickel(s) ';
              }
              if(data.pennies > 0) {
                    balance += data.pennies + ' Penny(s) ';
              }
              $('#change').val(balance);
              $('#change').prop("readonly", true);
          },
        error: function(xhr, errorThrown) {
            if((errorThrown == "Unprocessable Entity") || (xhr.status == "422")) {
                // Will tell user either SOLD OUT!! or Enter a certain amount.
                //Parses the JSON error and converts it into human-readable description of the error.
                $('#messages').val((jQuery.parseJSON(xhr.responseText)).message);
            }
            else {
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
                $('#bodyContent, #endingRule').hide();
            }
        }
    });

   //Load the current data;
   loadItems();
}

function changeReturn() {
        var currentTotal = 0.00;

        var quarter = 0.25;
        var dime    = 0.10;
        var nickel  = 0.05;
        var penny   = 0.01;

        var quarters = '', dimes = '', nickels = '', pennies = '', balance = '';
        //Remaining quarters after purchase.
        var quarters = parseInt(currentTotal / quarter);
        currenttotal = parseFloat(currentTotal % quarter).toFixed(2);
        //Remaining dimes after purchase.
        var dimes = parseInt(currentTotal / dime);
        currenttotal = parseFloat(currentTotal % dime).toFixed(2);
        //Remaining nickels after purchase.
        var nickels = parseInt(currentTotal / nickel);
        currenttotal = parseFloat(currentTotal % nickel).toFixed(2);
        //Remaining pennies after purchase.
        var pennies = parseInt(currentTotal / pennies);
        currentTotal = parseFloat(currentTotal % pennies).toFixed(2);

        if(quarters < 0) {
            balance += quarters + ' Quarter(s) ';
        }
        if(dimes < 0) {
            balance += dimes + ' Dime(s) ';
        }
        if(nickels < 0) {
            balance += nickels + ' Nickel(s) ';
        }
        if(pennies < 0) {
            balance += pennies + ' Penny(s) ';
        }
        //Gets the property value for only the first element in the matched set. set it to readonly.
       $('#total-in, #messages, #change').prop("readonly", false);
       //Clear the values out.
       $('#total-in, #messages, #item').val('');
       //#change value is set to balance.
       $('#change').val(balance);
       $('#total-in, #messages, #change').prop("readonly", true);
       //Load the current data;
       loadItems();
}

function clearItemTables() {
    for (var loopCounter = 1;loopCounter < 10;loopCounter++) {
        $('#item' + loopCounter).empty();
    }
}
