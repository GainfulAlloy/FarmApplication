// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function initMap() {
    var uk = { lat: 53.290, lng: -1.368 }
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: uk,
        mapTypeId: "terrain",
    });
    const field = [
        { lat: 53.0538, lng: 0.0640 },
        { lat: 53.0533, lng: 0.0641 },
        { lat: 53.0534, lng: 0.0652 },
        { lat: 53.0538, lng: 0.0652 },
    ];
    const fieldArea = new google.maps.Polygon({
        path: field,
        geodesic: true,
        strokeColor: "Blue",
        strokeOpacity: 1.0,
        strokeWeight: 2,
    });

    fieldArea.setMap(map);
}

window.initMap = initMap;

