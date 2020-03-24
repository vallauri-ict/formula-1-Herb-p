let app;

$(function () {
    app = new Vue({
        el: "#app",
        data: {
            teams: [],
            drivers: [],
            countries:[]
        }
    });

    
});

function viewDrivers() {
    $.getJSON('api/drivers')
        .done(function (data) {
            app.teams = [];
            app.countries = [];
            app.drivers = data;
        })
        .fail(function (jqXHR, textStatus, err) {
            alert(textStatus);
        });
}

function viewTeams() {
    $.getJSON('api/teams')
        .done(function (data) {
            app.drivers = [];
            app.countries = [];
            app.teams = data;
        })
        .fail(function (jqXHR, textStatus, err) {
            alert(textStatus);
        });
}

function viewCountries() {
    $.getJSON('api/countries')
        .done(function (data) {
            app.drivers = [];
            app.teams = [];
            app.countries = data;
        })
        .fail(function (jqXHR, textStatus, err) {
            alert(textStatus);
        });
}