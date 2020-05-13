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
            scores: [],
            infoDriver: null,
            infoTeam: null
        }
    });

    
});

function viewDrivers() {
        $.getJSON('api/drivers')
            .done(function (data) {
                app.teams = [];
                app.countries = [];
                app.circuits = [];
                app.races = [];
                app.scores = [];
                app.infoDriver = null;
                app.infoTeam = null;
                app.drivers = data;
            })
            .fail(function (jqXHR, textStatus, err) {
                alert(textStatus);
            });
}

function infoDriver(id) {
    $.getJSON('api/drivers/' + id)
        .done(function (data) {
            app.infoDriver = null;
            app.infoTeam = null;
            app.teams = [];
            app.countries = [];
            app.circuits = [];
            app.races = [];
            app.scores = [];
            app.drivers = [];
            app.infoDriver = data;
        })
        .fail(function (jqXHR, textStatus, err) {
            alert(textStatus);
        });
}

function viewTeams() {
        $.getJSON('api/teams')
            .done(function (data) {
                app.infoDriver = null;
                app.infoTeam = null;
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

function infoTeam(id) {
    $.getJSON('api/teams/' + id)
        .done(function (data) {
            app.infoDriver = null;
            app.infoTeam = null;
            app.drivers = [];
            app.countries = [];
            app.circuits = [];
            app.races = [];
            app.scores = [];
            app.teams = [];
            app.infoTeam = data;

        })
        .fail(function (jqXHR, textStatus, err) {
            alert(textStatus);
        });
}

function viewCircuits() {
        $.getJSON('api/circuits')
            .done(function (data) {
                app.infoDriver = null;
                app.infoTeam = null;
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

function infoCircuit(id) {
    $.getJSON('api/circuits/' + id)
        .done(function (data) {
            app.infoDriver = null;
            app.infoTeam = null;
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

function viewRaces() {
        $.getJSON('api/races')
            .done(function (data) {
                app.infoDriver = null;
                app.infoTeam = null;
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

function infoRace(id) {
    $.getJSON('api/races/' + id)
        .done(function (data) {
            app.infoDriver = null;
            app.infoTeam = null;
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