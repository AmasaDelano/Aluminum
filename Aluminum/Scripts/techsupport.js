(function () {
    "use strict";

    var app = angular.module("techsupport", ['ngRoute']);

    app.controller("TabController", function ($location) {
        var tabCtrl = this,
            tabs = ["support", "thoughts", "contact"],
            routeTabName = $location.path().substr(1),
            isTab = function (tab) {
                return tab === tabCtrl.currentTab;
            },
            setTab = function (newTab) {
                tabCtrl.currentTab = newTab;
            };

        tabCtrl.currentTab = tabs.indexOf(routeTabName) + 1;
        tabCtrl.currentTab = tabCtrl.currentTab || 1;

        // Assign public functions to controller
        tabCtrl.isTab = isTab;
        tabCtrl.setTab = setTab;
    });

    app.controller("OsController", function () {
        var osCtrl = this,
            platform = navigator.userAgent,
            supportedOses = [
                {
                    platforms: /Windows|Win32/i,
                    displayName: "Windows",
                    downloadPath: "downloads/RemoteTechSupport_Windows.zip"
                },
                {
                    platforms: /Mac/i,
                    displayName: "Mac",
                    downloadPath: "downloads/RemoteTechSupport_Mac.dmg"
                },
                {
                    platforms: /Linux/i,
                    displayName: "Linux",
                    downloadPath: "downloads/RemoteTechSupport_Linux.tar.gz"
                },
                {
                    platforms: /Android/i,
                    displayName: "Android",
                    downloadPath: "http://play.google.com/store/apps/details?id=com.teamviewer.quicksupport.market"
                },
                {
                    platforms: /iPhone|iPod|iPad/i,
                    displayName: "iOS",
                    downloadPath: "https://itunes.apple.com/us/app/teamviewer-quicksupport/id661649585"
                }
            ],
            definiteOsIndex = -1,
            osIndex,
            multipleOses = function () {
                return osCtrl.possibleOses && osCtrl.possibleOses.length > 1;
            };

        // Figure out which OSes are possible
        osCtrl.possibleOses = [];
        for (osIndex = 0; osIndex < supportedOses.length; osIndex += 1) {
            if (supportedOses[osIndex].platforms.test(platform)) {
                definiteOsIndex = osIndex;
                break;
            }
        }
        if (definiteOsIndex === -1) { // || true) {
            osCtrl.possibleOses = supportedOses;
        } else {
            osCtrl.possibleOses = [ supportedOses[definiteOsIndex] ];
        }

        // Assign public functions to controller
        osCtrl.multipleOses = multipleOses;
    });

}());