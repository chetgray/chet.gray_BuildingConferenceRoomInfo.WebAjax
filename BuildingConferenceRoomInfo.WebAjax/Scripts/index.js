// @ts-check

/**
 * @template T
 * @typedef {Object} ApiResult
 * @property {string} Context
 * @property {string} Message
 * @property {T | null} Data
 */

/**
 * @typedef {Object} BuildingInfo
 * @property {string} Name
 * @property {string} AddressStreet
 * @property {string} AddressCity
 * @property {string} AddressState
 * @property {string} AddressZip
 * @property {string} AddressCountry
 * @property {string} MainPhone
 * @property {number?} FloorCount
 * @property {number} ConferenceRoomCount
 */

/**
 * @typedef {Object} ConferenceRoomInfo
 * @property {string} Name
 * @property {string} BuildingName
 * @property {string} Phone
 * @property {boolean} IsAVCapable
 * @property {number?} Capacity
 */

$(function () {
    function handleBuildingSearch() {
        const buildingName = /** @type {string} */ ($("#buildingName").val());
        const $resultsContainer = $("#buildingResults");
        $.ajax({
            url: "/api/Buildings/listByName",
            data: { name: buildingName },
            dataType: "json",
        })
            .done(function (/** @type {ApiResult<BuildingInfo[]>} */ result) {
                if (result.Context !== "success") {
                    setAlert($resultsContainer, result.Context, result.Message);
                    return;
                }
                if (!result.Data || result.Data.length === 0) {
                    setAlert($resultsContainer, "warning", "No results found.");
                    return;
                }
                setResults($resultsContainer, result.Data);
            })
            .fail(function (jqXHR, textStatus) {
                setAlert(
                    $resultsContainer,
                    "danger",
                    `Request failed: ${textStatus} ${jqXHR.responseText}`
                );
            });
    }

    $("#buildingSearch").on("click", handleBuildingSearch);
    $("#buildingName").on("keypress", function (e) {
        if (e.which === 13) {
            handleBuildingSearch();
        }
    });

    function handleConferenceRoomSearch() {
        const conferenceRoomName = /** @type {string} */ ($("#conferenceRoomName").val());
        const $resultsContainer = $("#conferenceRoomResults");
        $.ajax({
            url: "/api/ConferenceRooms/listByName",
            data: { name: conferenceRoomName },
            dataType: "json",
        })
            .done(function (/** @type {ApiResult<ConferenceRoomInfo[]>} */ result) {
                if (result.Context !== "success") {
                    setAlert($resultsContainer, result.Context, result.Message);
                    return;
                }
                if (!result.Data || result.Data.length === 0) {
                    setAlert($resultsContainer, "warning", "No results found.");
                    return;
                }
                setResults($resultsContainer, result.Data);
            })
            .fail(function (jqXHR, textStatus) {
                setAlert(
                    $resultsContainer,
                    "danger",
                    `Request failed: ${textStatus} ${jqXHR.responseText}`
                );
            });
    }

    $("#conferenceRoomSearch").on("click", handleConferenceRoomSearch);
    $("#conferenceRoomName").on("keypress", function (e) {
        if (e.which === 13) {
            handleConferenceRoomSearch();
        }
    });
});

/**
 * @param {JQuery<HTMLElement>} $container
 * @param {string} context
 * @param {string} message
 */
function setAlert($container, context, message) {
    $container.empty();
    $container.html(`<div class="alert alert-${context}" role="alert">${message}</div>`);
}

/**
 * @param {JQuery<HTMLElement>} $resultsContainer
 * @param {BuildingInfo[] | ConferenceRoomInfo[]} data
 */
function setResults($resultsContainer, data) {
    $resultsContainer.empty();
    const $table = $("<table class='table table-striped'></table>");
    $resultsContainer.append($table);
    const $thead = $("<thead></thead>");
    $table.append($thead);
    const $tbody = $("<tbody></tbody>");
    $table.append($tbody);

    const $tr = $("<tr></tr>");
    $thead.append($tr);
    for (const key in data[0]) {
        if (data[0].hasOwnProperty(key)) {
            const $th = $(`<th>${key}</th>`);
            $tr.append($th);
        }
    }

    for (const item of data) {
        const $tr = $("<tr></tr>");
        $tbody.append($tr);
        for (const key in item) {
            if (item.hasOwnProperty(key)) {
                // @ts-ignore
                const $td = $(`<td>${item[key]}</td>`);
                $tr.append($td);
            }
        }
    }
}
