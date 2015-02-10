(function () {
    "use strict";

    var app = angular.module("costumeselector", []);

    app.controller("QuestionController", ['$http', function ($http) {
        var that = this,
            questions = [],
            costumes = [],
            answered = [],
            currentQuestionIndex = 0,
            getCurrentQuestion = function () {
                return questions[currentQuestionIndex];
            },
            revisitQuestion = function (question) {
                var questionIndex = questions.indexOf(question),
                    answeredIndex = answered.indexOf(question);
                currentQuestionIndex = questionIndex;
                answered.length = answeredIndex;
            },
            answerQuestion = function (questionIndex, isYes) {
                var question = questions[questionIndex];
                question.isYes = !!isYes;
                answered.push(question);
            },
            answerCurrentQuestion = function (isYes) {
                answerQuestion(currentQuestionIndex, isYes);
                currentQuestionIndex += 1;
            },
            hasQuestionsLeft = function () {
                return questions.length > currentQuestionIndex;
            },
            isLoading = function () {
                return questions.length === 0 || costumes.length === 0;
            },
            getBestCostume = function () {
                var costumeRatings = [],
                    costumeIndex,
                    costume,
                    answeredIndex,
                    answer,
                    bestCostumeIndex,
                    highestCostumeRating;

                for (costumeIndex = 0; costumeIndex < costumes.length; costumeIndex += 1) {
                    costumeRatings.push(0);
                }

                // Rate the costumes based on the answered questions.
                for (answeredIndex = 0; answeredIndex < answered.length; answeredIndex += 1) {
                    answer = answered[answeredIndex];
                    for (costumeIndex = 0; costumeIndex < costumes.length; costumeIndex += 1) {
                        costume = costumes[costumeIndex];

                        // If the value of the data field that the answer answered
                        // is the same as the answer given to the answer,
                        // increase this costume's rating.
                        if (!!costume[answer.dataField] === !!answer.isYes) {
                            costumeRatings[costumeIndex] += 1;
                        }
                    }
                }

                // Get the index of the highest rated costume.
                highestCostumeRating = 0;
                bestCostumeIndex = 0;
                for (costumeIndex = 0; costumeIndex < costumeRatings.length; costumeIndex += 1) {
                    if (costumeRatings[costumeIndex] > highestCostumeRating) {
                        highestCostumeRating = costumeRatings[costumeIndex];
                        bestCostumeIndex = costumeIndex;
                    }
                }

                return costumes[bestCostumeIndex];
            };

        // Get question and costume data from the server.
        $http.get("/api/costumeApi/GetQuestions").success(function (data) {
            questions = data;
        }).error(function () {
            alert("Problem getting questions.");
        });
        $http.get("/api/costumeApi/GetCostumes").success(function (data) {
            costumes = data;
        }).error(function () {
            alert("Problem getting costumes.");
        });

        that.getCurrentQuestion = getCurrentQuestion;
        that.answered = answered;
        that.answerCurrentQuestion = answerCurrentQuestion;
        that.hasQuestionsLeft = hasQuestionsLeft;
        that.revisitQuestion = revisitQuestion;
        that.getBestCostume = getBestCostume;
        that.isLoading = isLoading;

        return that;
    }]);
}());