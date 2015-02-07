﻿(function () {
    "use strict";

    var setColor = function (h, s, l) {
        document.body.style.backgroundColor = "hsl(" + h + "," + s + "%," + l + "%)";
    },
        getMillisecondsToday = function () {
            var date = new Date(),

                hours = date.getHours(),
                minutes = date.getMinutes(),
                seconds = date.getSeconds(),
                milliseconds = date.getMilliseconds(),

                millisecondsToday = milliseconds + seconds * 1000 + minutes * 60 * 1000 + hours * 60 * 60 * 1000;

            return millisecondsToday;
        },
        saturationFactor = 40, // from 0 - 100
        lightnessFactor = 30, // from 0 - 100
        getHue = function (x) {
            return x;
        },
        getSaturation = function (x) {
            var saturation = saturationFactor * Math.sin((Math.PI * (x + 3.75)) / 7.5) + 100 - saturationFactor;
            return saturation;
        },
        getLightness = function (x) {
            var lightness = (50 - lightnessFactor) * Math.sin((Math.PI * (x - 90)) / 180) + 50;
            return lightness;
        },
        // fakePercent = 0,
        msInDay = 86400000,
        updateColor = function () {
            var percent = getMillisecondsToday() / msInDay,
                pos = percent * 360,
                hue = getHue(pos),
                saturation = getSaturation(pos),
                lightness = getLightness(pos);

            // document.all.percent.innerHTML = percent;

            setColor(hue, saturation, lightness);

            // fakePercent += 0.0001
        },
        updateFrequency = 1000;

    updateColor();
    window.setInterval(updateColor, updateFrequency);
}());