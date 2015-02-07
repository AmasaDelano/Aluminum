(function () {
    "use strict";

    var time = document.all.time,
        showTime = !!($.cookie("showClock") && JSON.parse($.cookie("showClock"))),
        setColor = function (h, s, l) {
            document.body.style.backgroundColor = "hsl(" + h + "," + s + "%," + l + "%)";
        },
        setTime = function (hours, minutes) {
            time.innerHTML = (hours % 12 === 0 ? 12 : hours % 12) + ":" + ("0" + minutes).substr(-2, 2) + " " + (hours < 12 ? "am" : "pm");
        },
        getMillisecondsToday = function () {
            var date = new Date(),

                hours = date.getHours(),
                minutes = date.getMinutes(),
                seconds = date.getSeconds(),
                milliseconds = date.getMilliseconds(),
                millisecondsToday = milliseconds + seconds * 1000 + minutes * 60 * 1000 + hours * 60 * 60 * 1000;

            setTime(hours, minutes);

            return millisecondsToday;
        },
        toggleShowTime = function () {
            showTime = !showTime;
            time.style.display = showTime ? "block" : "none";
            $.cookie("showClock", showTime);
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

    time.style.display = showTime ? "block" : "none";
    document.onclick = toggleShowTime;
}());