
window.onload = onLocationChange;

document.getElementById("LocationId").onchange = onLocationChange;

async function onLocationChange() {
    console.log("IN ONLOCATIONCHANGE")
    const locationId = document.getElementById("LocationId").value;

    const placesResponce = await fetch("https://localhost:7121/Place/AllByLocation/" + locationId, {
        credentials: "include",
    });
    if (placesResponce.status != 200) {
        // todo: show validation error according the api responce
        return;
    }
    const places = await placesResponce.json();

    options = places.map(p => placeOption(p));

    const placeSelect = document.getElementById("PlaceId");

    placeSelect.append(...options);
}

function placeOption(place) {
    const option = document.createElement("option");
    option.value = place.placeId;
    option.innerText = place.placeName;

    return option;
}