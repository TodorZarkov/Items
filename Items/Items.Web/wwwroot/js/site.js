
function cascadePlacesDropdown(baseHost) {
    if (!baseHost) {
        return;
    }

    window.onload = onLocationChange;
    const locationSelectEl = document.querySelector("#LocationId");
    if (locationSelectEl) {
        locationSelectEl.onchange = onLocationChange
    }



    async function onLocationChange(event) {

        const locationSelect = document.querySelector("#LocationId");
        const locationId = locationSelect?.value;
        const placeSelect = document.querySelector("#PlaceId");
        const currentPlaceId = placeSelect?.value;

        if (!locationId || !placeSelect) {
            return;
        }

        //base host ssshttps://localhost:7121
        const placesResponce = await fetch(baseHost + "/Place/AllByLocation/" + locationId, {
            credentials: "include",
        });
        if (placesResponce.status != 200) {
            const option = createOption("", "Select Place.")
            placeSelect.innerHTML = "";
            placeSelect.append(option);
            return;
        }
        const places = await placesResponce.json();



        if (event.type === "change") {
            placeSelect.innerHTML = "";
            options = places
                .map(p => createOption(p.placeId, p.placeName));
        } else {
            options = places
                .filter(p => p.placeId != currentPlaceId)
                .map(p => createOption(p.placeId, p.placeName));
        }
        placeSelect.append(...options);
    }

    function createOption(value, text) {
        const option = document.createElement("option");
        option.value = value;
        option.innerText = text;

        return option;
    }

}


