window.VSTSInfoScreen = window.VSTSInfoScreen || {};
window.VSTSInfoScreen.Data = window.VSTSInfoScreen.Data || {};

(function (scope, $, undefined) {
    'use strict';

    var serviceBase = '/Data/';

    scope.getAdditionalInformation = function () {
        return $.ajax({
            url: serviceBase + 'GetAdditionalInformation',
            type: 'POST'
        });
    }

    scope.getAllBuilds = function () {
        return $.ajax({
            url: serviceBase + 'GetBuilds',
            type: 'POST'
        });
    }

    scope.getAllPullRequests = function () {
        return $.ajax({
            url: serviceBase + 'GetPullRequests',
            type: 'POST'
        });
    }

    scope.getAllReleases = function () {
        return $.ajax({
            url: serviceBase + 'GetReleases',
            type: 'POST'
        });
    }
})(
    window.VSTSInfoScreen.Data,
    jQuery
)