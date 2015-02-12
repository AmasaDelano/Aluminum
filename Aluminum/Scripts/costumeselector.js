(function () {
    "use strict";

    var app = angular.module("costumeselector", []);

    app.controller("QuestionController", ['$http', function ($http) {
        var that = this,
            questions = [],
            costumes = [],
            answered = [],
            currentQuestionIndex = -1,
            getCurrentQuestion = function () {
                return questions[currentQuestionIndex];
            },
            revisitQuestion = function (question) {
                var questionIndex = questions.indexOf(question),
                    answeredIndex = answered.indexOf(question);
                currentQuestionIndex = questionIndex;
                answered.length = answeredIndex;
            },
            answerQuestion = function (questionIndex, answer) {
                var question = questions[questionIndex];
                question.answer = answer;
                answered.push(question);
            },
            getPossibleCostumes = function () {
                var possibleCostumes = [],
                    costumeIndex,
                    costume,
                    answerIndex,
                    answer,
                    possible;

                for (costumeIndex = 0; costumeIndex < costumes.length; costumeIndex += 1) {
                    costume = costumes[costumeIndex];
                    possible = true;
                    for (answerIndex = 0; answerIndex < answered.length; answerIndex += 1) {
                        answer = answered[answerIndex];
                        if (costume.properties[answer.dataField] !== answer.answer) {
                            possible = false;
                            break;
                        }
                    }
                    if (possible) {
                        possibleCostumes.push(costume);
                    }
                }

                return possibleCostumes;
            },
            getIndexOfHighestItem = function (array) {
                var index,
                    highestItem = 0,
                    indexOfHighestItem = 0;

                for (index = 0; index < array.length; index += 1) {
                    if (array[index] > highestItem) {
                        highestItem = array[index];
                        indexOfHighestItem = index;
                    }
                }

                return indexOfHighestItem;
            },
            getNextQuestionIndex = function () {
                var questionRatings = [],
                    possibleCostumes,
                    bestQuestionIndex,
                    questionIndex,
                    question,
                    costumeIndex,
                    costume,
                    oneRatingIsGood;

                // If there is only one costume that fits the criteria, we are done.
                possibleCostumes = getPossibleCostumes();

                if (possibleCostumes.length === 1) {
                    return -1;
                }

                for (questionIndex = 0; questionIndex < questions.length; questionIndex += 1) {
                    questionRatings[questionIndex] = 0;
                }

                for (questionIndex = 0; questionIndex < questions.length; questionIndex += 1) {
                    question = questions[questionIndex];
                    if (answered.indexOf(question) === -1) {
                        for (costumeIndex = 0; costumeIndex < possibleCostumes.length; costumeIndex += 1) {
                            costume = possibleCostumes[costumeIndex];
                            if (!!costume.properties[question.dataField]) {
                                questionRatings[questionIndex] += 1;
                            }
                        }
                    }
                }

                oneRatingIsGood = false;
                for (questionIndex = 0; questionIndex < questionRatings.length; questionIndex += 1) {
                    questionRatings[questionIndex] =
                        possibleCostumes.length -
                        Math.abs(possibleCostumes.length - questionRatings[questionIndex] * 2);

                    if (questionRatings[questionIndex] > 0) {
                        oneRatingIsGood = true;
                    }
                }

                if (!oneRatingIsGood) {
                    return -1;
                }

                bestQuestionIndex = getIndexOfHighestItem(questionRatings);

                if (answered.indexOf(questions[bestQuestionIndex]) !== -1) {
                    return -1;
                }

                return bestQuestionIndex;
            },
            answerCurrentQuestion = function (answer) {
                answerQuestion(currentQuestionIndex, answer);
                currentQuestionIndex = getNextQuestionIndex();
            },
            hasQuestionsLeft = function () {
                return questions.length > currentQuestionIndex && currentQuestionIndex >= 0;
            },
            isLoading = function () {
                return questions.length === 0 || costumes.length === 0;
            },
            getBestCostume = function () {
                var possibleCostumes = getPossibleCostumes();
                return possibleCostumes[0];
            };

        // Get question and costume data from the server.
        $http.get("/api/costumeApi/GetQuestions").success(function (data) {
            questions = data;
            if (costumes.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
        }).error(function () {
            alert("Problem getting questions.");
        });
        $http.get("/api/costumeApi/GetCostumes").success(function (data) {
            costumes = data;
            if (questions.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
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