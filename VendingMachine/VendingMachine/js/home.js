                //total, # of $, # 0.25, # 0.1, # 0.05,
var coinsAdded = [0.00,      0,      0,     0,   0];

$(document).ready(function () {
    

    $("#moneyIn").text("$"+ coinsAdded[0]);

    loadItems();
    
    $("#coinReturn").on("click", function()
    {
        coinReturn();
    });

    //console.log(coinsAdded[0]);

    addMoney();
    
    makePurchase();

    clickID();

    // push current value of coinsAdded to message box for change/money in

    // push returned json from makepurchase to message box, otherwise, thank you 
    


});

function clickID()
{
    $("#dataColumn").on("click", "div.items", function(event)
    {
        $("#chosenItem").text("");
        var id = $("#" + this.id +" > #id").text();
        $("#chosenItem").text(id);
    
    }  );
}

function loadItems() 
// load items from get call and display on screen
{

    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function(itemArray){
            $.each(itemArray, function(index, item)
            {
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var newDiv = document.createElement("div");
                var h5 = document.createElement("h5");
                h5.setAttribute("id", "id");

                var p1 = document.createElement("p");
                p1.setAttribute("id", "name");
                var p2 = document.createElement("p");
                p2.setAttribute("id", "price");
                var p3 = document.createElement("p");
                p3.setAttribute("id", "quantity")

                var elementArray = [p1, p2, p3];

                newDiv.id = id;
                newDiv.className = "items";
                newDiv.appendChild(h5);

                for(var i = 0; i < 3; i++)
                {
                    newDiv.appendChild(elementArray[i]);
                }
                
                document.getElementById("dataColumn").appendChild(newDiv);


                $('#' + id + " > #id").text(id);
                //console.log(id);
                $('#' + id + " > #name").text(name);
                //console.log(name);
                $('#' + id + " > #price").text("$" + price);
                //console.log(price);
                $('#' + id + " > #quantity").text("Quantity:" + quantity);
                

            });
            
        },
        error: function() {
            alert("Ajax failure");
        }


    });
}

function addMoney() 
//adds value to the coinsAdded var from the buttons
//will form amount value in /money/<coinsAdded>/item/<id> get call
// total, dollar, quarter, dime, nickel
{
    //[total, dollar, quarter, dime, nickel]

    $("#addDollar").on("click", function()
    {
        console.log(coinsAdded[0]);
        coinsAdded[0] = coinsAdded[0] + 1.00;
        coinsAdded[1] = coinsAdded[1] + 1;
        $("#moneyIn").text("$"+ coinsAdded[0].toFixed(2));
        
        //console.log(coinsAdded[0]);
    });

    $("#addQuarter").on("click", function()
    {
        coinsAdded[0] = coinsAdded[0] + 0.25;
        coinsAdded[2] = coinsAdded[2] + 1;
        $("#moneyIn").text("$"+ coinsAdded[0].toFixed(2));
        //console.log(coinsAdded);
    });

    $("#addDime").on("click", function()
    {   
        //coinsAdded += [0.10, 0, 0, 1, 0];
        coinsAdded[0] = coinsAdded[0] + Number(Math.round(0.1+'e2')+'e-2');
        coinsAdded[3] = coinsAdded[3] + 1;
        $("#moneyIn").text("$"+ coinsAdded[0].toFixed(2));
    });

    $("#addNickel").on("click", function()
    {
        //coinsAdded += [0.05, 0, 0, 0, 1];
        coinsAdded[0] = coinsAdded[0] + Number(Math.round(0.05+'e2')+'e-2');
        coinsAdded[4] = coinsAdded[4] + 1;
        $("#moneyIn").text("$"+ coinsAdded[0].toFixed(2));
        
    });

}

function makePurchase()
// make ajax call to get with money added and current item id
{

    $("#makePurchase").on("click", function ()
    {
        $("#changeReturn").val("");
        var chosenItem = 0;
        chosenItem = document.getElementById("chosenItem").value;
        //console.log("ID:"+chosenItem);
        var returnedChange = [0, 0, 0, 0];
        var i = 0;

        $.ajax({
            type: "GET",
            url: "http://localhost:8080/money/" + coinsAdded[0] + "/item/" + chosenItem,
            success: function(changeArray){
                $.each(changeArray, function(index, change)
                {
                    returnedChange[i] = change;
                    i++;
                });

                    

                    if(returnedChange[0] != 0)
                    {
                        $("#changeReturn").val($("#changeReturn").val()+returnedChange[0]+" Quarters");
                    }               
                    if(returnedChange[1] != 0)
                    {
                        $("#changeReturn").val($("#changeReturn").val()+returnedChange[1]+" Dimes");
                    }
                    if(returnedChange[2] != 0)
                    {
                        $("#changeReturn").val($("#changeReturn").val()+returnedChange[2]+" Nickels");
                    }
                    if(returnedChange[3] != 0)
                    {
                        $("#changeReturn").val($("#changeReturn").val()+returnedChange[3]+" Pennies");
                    }
                    
                
                $("#messageOut").text("Thank you!!!");
                

            },
            error: function(responseArray) {
                $.each(responseArray, function(index, response)
                {
                    var message = response.message;
                     $("#messageOut").text(message);
                });
                   
                
            }


        });


    });

}

function coinReturn()
{

        coinsAdded = [0.00, 0, 0, 0, 0];
        $("#changeReturn").val("");
        $("#moneyIn").text("$" + coinsAdded[0]);
        $("#messageOut").text("");
        $("#chosenItem").text("");

        $.ajax({
            type: "GET",
            url: "http://localhost:8080/items",
            success: function(itemArray){
                $.each(itemArray, function(index, item)
                {
                    var id = item.id;

                    var quantity = item.quantity;
    
                    $("#" + id + " > #quantity").text("Quantity:" + quantity);
                    
    
                });
                
            },
            error: function() {
                alert("Ajax failure");
            }
    
    
        });


}