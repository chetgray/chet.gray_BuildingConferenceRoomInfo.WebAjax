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
    $("#buildingSearch").on("click", function () {
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
    });

    $("#conferenceRoomSearch").on("click", function () {
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
    setAlert($resultsContainer, "success", "Success!");
    $resultsContainer.append(`<pre>${JSON.stringify(data, null, 2)}</pre>`);
}
