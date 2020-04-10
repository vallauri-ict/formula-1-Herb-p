let app;

$(function () {
    app = new Vue({
        el: "#app",
        data: {
            teams: [],
            drivers: [],
            countries: [],
            circuits: [],
            races: [],
            races_scores: [],
            scores: []
        }
    });

    
});

function viewDrivers() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/drivers')
            .done(function (data) {
                app.teams = [];
                app.countries = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.drivers = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/drivers/' + $("#txtId").val())
            .done(function (data) {
                app.teams = [];
                app.countries = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.drivers = [data];
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
}

function viewTeams() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/teams')
            .done(function (data) {
                app.drivers = [];
                app.countries = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.teams = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/teams/' + $("#txtId").val())
            .done(function (data) {
                app.drivers = [];
                app.countries = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.teams = [data];
                
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
}

function viewCountries() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/countries')
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.countries = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/countries/' + $("#txtId").val())
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.countries = [data];
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
}

/*function viewCircuits() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/circuits')
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.races = [];
                app.scores = [];
                app.circuits = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/circuits/' + $("#txtId").val())
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.races = [];
                app.scores = [];
                app.circuits = [data];
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }

}

function viewRaces() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/races')
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.scores = [];
                app.circuits = [];
                app.races = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/races/' + $("#txtId").val())
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.scores = [];
                app.circuits = [];
                app.races = [data];
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
}

function vireScores() {
    if ($("#txtId").val() === "") {
        $.getJSON('api/scores')
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.races = [];
                app.circuits = [];
                app.scores = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
    else {
        $.getJSON('api/scores/' + $("#txtId").val())
            .done(function (data) {
                app.drivers = [];
                app.teams = [];
                app.countries = [];
                app.races = [];
                app.circuits = [];
                app.scores = [data];
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
    }
}*/