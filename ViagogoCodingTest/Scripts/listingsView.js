var app = angular.module("app", []);

app.service ("DataService",["$http",function ($http) {

    var quantityNeeded;
    var dataAfterFilter;

    return {
        loadData : function () {
            return $http.get("http://localhost:51946/Home/Listings")
               .then(function (res) {
                   return JSON.parse(res.data);
               })
        },
        setQuantity : function (quantity) {
            quantityNeeded = quantity;
        },
        filterData : function (data) {
            var filteredData = [];
            data.forEach(function (listing) {
                if (listing.ticketsAvailable === quantityNeeded) {
                filteredData.push(listing);
                }
                else if (quantityNeeded === "Any") {
                    filteredData = data;
                }
                else if (quantityNeeded === "5+") {
                    if (listing.ticketsAvailable > 5) {
                        filteredData.push(listing);
                    }
                }
                dataAfterFilter = filteredData;
            })
        },
        getFilteredData: function () {
            return dataAfterFilter;
        }
    }

 
}]);

app.service("TicketService", function () {

    var counter = "Any";
    return {
        addTicket : function () {
            if (counter < 5) {
                counter++;
            }
            else if (counter === "Any") {
                counter = 1;
            }
            else {
                counter = "5+";
            }
        },

        removeTicket : function () {
        if (counter > 1) {
            counter -= 1;
        }
        else if (counter === "5+") {
            counter = 5;
        }
        else {
            counter = "Any";
        }
        },

        getCount: function () {
            return counter;
        }
    }
})


app.controller("myCtrl", function ($scope,DataService,TicketService) {
    var listings;

    $scope.filteredData = listings;

    (function getData() {
        DataService.loadData().then(function (res) {
            listings = res;
            $scope.filteredData = res;
        })
    })();

    $scope.counter = "Any";

    function changeTicketNum(bool) {
        if (bool) {
            TicketService.addTicket();
        }
        else {
            TicketService.removeTicket();
        }
        $scope.counter = TicketService.getCount();
        DataService.setQuantity($scope.counter);
        DataService.filterData(listings);
        $scope.filteredData = DataService.getFilteredData();
    }

    this.addTicket = function () {
        changeTicketNum(true);
    }

    this.removeTicket = function () {
        changeTicketNum(false);
    }
});


$(".arrow-up").click(function () {
    $(".newTicket").attr("src", "../Content/icons/ticketIconAdd.png");
    $(".newTicket").css("visibility","visible");
    $(".newTicket").toggleClass("newTicket-add");

    setTimeout(function () {
        $(".newTicket-add").removeClass().addClass("newTicket");
        $(".newTicket").css("visibility", "hidden");
    }, 700);

});


$(".arrow-down").click(function () {
    $(".newTicket").attr("src", "../Content/icons/ticketIconRemove.png");
    $(".newTicket").css("visibility", "visible");
    $(".newTicket").toggleClass("newTicket-remove");


    setTimeout(function () {
        $(".newTicket-add").removeClass().addClass("newTicket");
        $(".newTicket").css("visibility", "hidden");
    }, 700);
});



