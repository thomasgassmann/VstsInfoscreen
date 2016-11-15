window.VSTSInfoScreen = window.VSTSInfoScreen || {};
window.VSTSInfoScreen.UI = window.VSTSInfoScreen.UI || {};

(function (scope, $, undefined) {
    'use strict'

    var builds = {};
    var buildOrder = [];

    var pullrequests = {};
    var pullrequestOrder = [];

    var release = {};
    var releaseOrder = [];

    function cleanArray(array, deleteValue) {
        for (var i = 0; i < array.length; i++) {
            if (array[i] == deleteValue) {
                array.splice(i, 1);
                i--;
            }
        }
    };

    function addAdditionalInformation() {
        var deferred = $.Deferred();
        VSTSInfoScreen.Data.getAdditionalInformation().done(function (data) {
            $('#loadingContent').html('Finished loading additional information...');
            $('#additionalInformation').hide().html(data).fadeIn('slow');
            deferred.resolve();
        }).fail(function (xhr) {
            $('#errorMessage').html(xhr.status + ' ' + xhr.statusText);
            deferred.fail();
        });
        return deferred.promise();
    }

    function addBuilds() {
        var deferred = $.Deferred();
        VSTSInfoScreen.Data.getAllBuilds().done(function (data) {
            $('#loadingContent').html('Finished loading builds...');
            if (!scope.switchCards || data.indexOf('No builds found') > 0) {
                $('#builds').html(data);
            } else {
                initialSort('#builds', data, buildOrder, builds);
            }
            deferred.resolve();
        }).fail(function (xhr) {
            $('#errorMessage').html(xhr.status + ' ' + xhr.statusText);
            deferred.fail();
        });
        return deferred.promise();
    }

    function addPullRequests() {
        var deferred = $.Deferred();
        VSTSInfoScreen.Data.getAllPullRequests().done(function (data) {
            $('#loadingContent').html('Finished loading pull requests...');
            if (!scope.switchCards || data.indexOf('No pull requests found') > 0) {
                $('#pullrequests').html(data);
            } else {
                initialSort('#pullrequests', data, pullrequestOrder, pullrequests);
            }
            deferred.resolve();
        }).fail(function (xhr) {
            $('#errorMessage').html(xhr.status + ' ' + xhr.statusText);
            deferred.fail();
        });
        return deferred.promise();
    }

    function addReleases() {
        var deferred = $.Deferred();
        VSTSInfoScreen.Data.getAllReleases().done(function (data) {
            $('#loadingContent').html('Finished loading releases...');
            if (!scope.switchCards || data.indexOf('No releases found') > 0) {
                $('#release').html(data);
            } else {
                initialSort('#release', data, releaseOrder, release);
            }
            deferred.resolve();
        }).fail(function (xhr) {
            $('#errorMessage').html(xhr.status + ' ' + xhr.statusText);
            deferred.fail();
        });
        return deferred.promise();
    }

    function initialSort(selector, serverData, orderArray, contentArray) {
        var ids = [];
        $(serverData).each(function (child) {
            var id = $(this).attr('id');
            ids.push(id);
            contentArray[id] = this;
            if (orderArray.indexOf(id) < 0) {
                orderArray.push(id);
            }
        });
        for (var build in orderArray) {
            if (ids.indexOf(orderArray[build]) < 0) {
                orderArray.splice(build, 1);
            }
        }
        display(selector, orderArray, contentArray);
    }

    function order(orderArray, selector) {
        if (scope.switchCards && orderArray.length > 1) {
            for (var i = 0; i < orderArray.length; i++) {
                if (orderArray[i] === undefined) {
                    orderArray.splice(i, 1);
                }
            }

            $(selector).children().each(function () {
                if ($(this).find('.loader').length) {
                    orderArray.splice(orderArray.indexOf($(this).attr('id')), 1);
                    orderArray.splice(0, 0, $(this).attr('id'));
                }
            });
            var firstIndex = 0;
            var counting = true;
            for (var item in orderArray) {
                if ($('#' + orderArray[item]).find('.loader').length < 1) {
                    if (counting) {
                        firstIndex = item;
                        counting = false;
                    }
                }
            }
            var element = orderArray[firstIndex];
            orderArray.splice(firstIndex, 1);
            orderArray.push(element);
        }
    }

    function display(selector, orderArray, contentArray) {
        if ($(selector).html().indexOf('No builds found') > 0 ||
            $(selector).html().indexOf('No pull requests found') > 0 ||
            $(selector).html().indexOf('No releases found') > 0) {
            return;
        }
        $(selector).html('');
        for (var i = 0; i < orderArray.length; i++) {
            $(selector).append(contentArray[orderArray[i]]);
        }
    }

    $(function () {
        $('#main-content').hide();
        $.when(
            addAdditionalInformation(),
            addBuilds(),
            addPullRequests(),
            addReleases()).then(function () {
                $('#loading').hide();
                $('#main-content').fadeIn();
                setInterval(addBuilds, scope.updateBuild);
                setInterval(addPullRequests, scope.updatePullRequest);
                setInterval(addReleases, scope.updateRelease);
                setInterval(addAdditionalInformation, scope.updateAdditionalInformation);
                if (scope.switchCards) {
                    setInterval(function () {
                        order(buildOrder, '#builds');
                        display('#builds', buildOrder, builds);
                    }, scope.switchInterval);
                    setInterval(function () {
                        order(pullrequestOrder, '#pullrequests');
                        display('#pullrequests', pullrequestOrder, pullrequests);
                    }, scope.switchInterval);
                    setInterval(function () {
                        order(releaseOrder, '#release');
                        display('#release', releaseOrder, release);
                    }, scope.switchInterval);
                }
            }).fail(function () {
                $('#loadingContent').html('Failed loading content...');
                $('#loadingContentLoader').hide();
                $('#main-content').remove();
            });
    });
})(window.VSTSInfoScreen.UI, jQuery)